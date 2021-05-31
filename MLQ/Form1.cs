using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Practica
{
    public partial class Form1 : Form
    {
        private const int UNIT_TIME = 100; // 100ms
        private const int MAX_PROCESSES = 20;
        private const int MAX_EXECUTION_TIME = 21;
        private const int MAX_SCHEDULE_TIME = 9;

        private Random rand;
        private int quantum = 500; // 500ms
        private int actualTime = 0;
        private int idleTime = 0;

        private Thread threadMain;
        private Thread threadForegroundProcesses;
        private Thread threadBackgrounProcesses;

        private Queue<Process> processes;
        private Queue<Process> foreProcesses;
        private Queue<Process> backProcesses;

        private List<int> responseTimes;
        private List<int> turnaroundTimes;

        public Form1()
        {
            InitializeComponent();
            this.rand = new Random();
            this.processes = new Queue<Process>();
            this.foreProcesses = new Queue<Process>();
            this.backProcesses = new Queue<Process>();
            this.responseTimes = new List<int>();
            this.turnaroundTimes = new List<int>();

            this.GenerateProcesses();
        }

        private void GenerateProcesses()
        {
            Process p;
            Series s;
            string prior;

            this.processes.Clear();
            this.foreProcesses.Clear();
            this.backProcesses.Clear();
            this.chart1.Series.Clear();

            for (int i = 0; i < MAX_PROCESSES; i++)
            {
                p = new Process()
                {
                    ID = i + 1,
                    ExecutionTime = rand.Next(1, MAX_EXECUTION_TIME) * UNIT_TIME, //Tiempo de ejecución entre 100 y 2000 ms
                    priority = rand.Next(0, 10), // Prioridad entre 0-9, [0-4] <- Prioridad Alta, [5, 9] <- Prioridad Baja
                };

                this.processes.Enqueue(p);

                s = this.chart1.Series.Add(p.ID.ToString());
                s.Color = Color.White;
                s.BorderColor = Color.Black;
                s.Points.Add(p.ExecutionTime);
                prior = p.priority < 5 ? "A" : "B";
                s.Label = p.ID.ToString() + " (" + prior + ")";
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            this.threadMain = new Thread(new ThreadStart(this.RunProcessScheduler));
            this.threadForegroundProcesses = new Thread(new ThreadStart(this.RunRoundRobin));
            this.threadBackgrounProcesses = new Thread(new ThreadStart(this.RunFCFS));

            this.threadMain.Start();
            this.threadForegroundProcesses.Start();
            this.threadBackgrounProcesses.Start();

            this.btnStart.Enabled = false;
        }

        // Al cerrar la ventana se abrotarán los hilos
        public void ActionFormClosing(object sender, FormClosingEventArgs e)
        {
            this.KillProcesses();
        }

        private void KillProcesses()
        {
            if (this.threadMain != null)
            {
                this.threadMain.Abort();
                this.threadMain = null;
            }
            if (this.threadForegroundProcesses != null)
            {
                this.threadForegroundProcesses.Abort();
                this.threadForegroundProcesses = null;
            }
            if (this.threadBackgrounProcesses != null)
            {
                this.threadBackgrounProcesses.Abort();
                this.threadBackgrounProcesses = null;
            }
        }

        private void RunProcessScheduler()
        {
            Process p;

            UpdateProcessInChartCallback cbChart = new UpdateProcessInChartCallback(this.UpdateProcessInChart);
            UpdateCpuTimeCallback cbCPU = new UpdateCpuTimeCallback(this.UpdateCpuTime);

            this.actualTime = 0;
            this.idleTime = 0;
            // Tiempo en que se encolará nuevo proceso entre 100 a 800 ms
            int timeToNewProcess = actualTime + rand.Next(1, MAX_SCHEDULE_TIME) * UNIT_TIME;

            while (this.processes.Count > 0 || this.foreProcesses.Count > 0 || this.backProcesses.Count > 0)
            {
                Thread.Sleep(UNIT_TIME);
                this.actualTime += UNIT_TIME;

                if (this.foreProcesses.Count == 0 && this.backProcesses.Count == 0) // No hay ningun proceso en ninguna de las colas
                {
                    this.idleTime += UNIT_TIME;
                }

                this.Invoke(cbCPU);

                if (this.actualTime == timeToNewProcess) // Llega nuevo proceso
                {
                    if (this.processes.Count > 0)
                    {
                        p = this.processes.Dequeue();
                        p.ArrivalTime = this.actualTime;
                        this.Invoke(cbChart, p, Color.MidnightBlue);

                        if (p.priority < 5) // Prioridad Alta, se manda a la cola con Round Robin
                        {
                            this.foreProcesses.Enqueue(p);
                        }
                        else // Prioridad Baja, se manda a la cola con FCFS
                        {
                            this.backProcesses.Enqueue(p);
                        }

                        // Tiempo en que se encolará nuevo proceso entre 100 a 800 ms
                        timeToNewProcess = actualTime + rand.Next(1, MAX_SCHEDULE_TIME) * UNIT_TIME;
                    }
                }
            }
        }

        private void RunRoundRobin()
        {
            Process p;

            UpdateProcessInChartCallback cbChart = new UpdateProcessInChartCallback(this.UpdateProcessInChart);
            UpdateResponseTimeCallback cbResponse = new UpdateResponseTimeCallback(this.UpdateResponseTime);
            UpdateTurnaroundTimeCallback cbTurnaround = new UpdateTurnaroundTimeCallback(this.UpdateTurnaroundTime);

            // Tiempo en que se encolará nuevo proceso entre 100 a 1400 ms
            int timeToNewProcess = actualTime + rand.Next(1, MAX_SCHEDULE_TIME) * UNIT_TIME;

            while (this.processes.Count > 0 || this.foreProcesses.Count > 0)
            {
                p = this.foreProcesses.Count > 0
                    ? this.foreProcesses.Peek()
                    : null;

                if (p != null) // Proceso ejecutandose
                {
                    if (p.ExecutedTime == 0) //Calculo tiempo de respuesta (TiempoPrimeraEjecucion - TiempoLlegada)
                    {
                        this.Invoke(cbResponse, this.actualTime - p.ArrivalTime);
                    }

                    this.Invoke(cbChart, p, Color.Red);

                }

                Thread.Sleep(UNIT_TIME);

                if (p != null)
                {
                    p.ExecutedTime += UNIT_TIME; // Actualización del tiempo de ejecución del proceso actual

                    if (p.ExecutedTime == p.ExecutionTime) // Proceso Terminado
                    {
                        p = this.foreProcesses.Dequeue();
                        this.Invoke(cbChart, p, Color.White);

                        // Calculo Tiempo Tournaround (TiempoTerminaEjecucion - TiempoLLegada)
                        this.Invoke(cbTurnaround, this.actualTime - p.ArrivalTime);
                    }
                    else if ((p.ExecutedTime % this.quantum) == 0) // Proceso Bloqueado porqué llegó al límete del Quantum
                    {
                        p = this.foreProcesses.Dequeue(); //Se Desencola el proceso actual para darle paso a los demás
                        this.Invoke(cbChart, p, Color.DarkGreen);
                        this.foreProcesses.Enqueue(p);
                    }
                }
            }
        }

        private void RunFCFS()
        {
            Process p;

            UpdateProcessInChartCallback cbChart = new UpdateProcessInChartCallback(this.UpdateProcessInChart);
            UpdateResponseTimeCallback cbResponse = new UpdateResponseTimeCallback(this.UpdateResponseTime);
            UpdateTurnaroundTimeCallback cbTurnaround = new UpdateTurnaroundTimeCallback(this.UpdateTurnaroundTime);

            while (this.processes.Count > 0 || this.backProcesses.Count > 0)
            {
                p = this.backProcesses.Count > 0
                    ? this.backProcesses.Peek()
                    : null;

                if (p != null) // Proceso ejecutandose
                {
                    if (p.ExecutedTime == 0) //Calculo tiempo de respuesta (TiempoPrimeraEjecucion - TiempoLlegada)
                    {
                        this.Invoke(cbResponse, this.actualTime - p.ArrivalTime);
                    }

                    this.Invoke(cbChart, p, Color.Red);
                }

                Thread.Sleep(UNIT_TIME);

                if (p != null)
                {
                    p.ExecutedTime += UNIT_TIME; // Actualización del tiempo de ejecución del proceso actual

                    if (p.ExecutedTime == p.ExecutionTime) // Proceso Terminado
                    {
                        p = this.backProcesses.Dequeue();
                        this.Invoke(cbChart, p, Color.White);

                        // Calculo Tiempo Tournaround (TiempoTerminaEjecucion - TiempoLLegada)
                        this.Invoke(cbTurnaround, this.actualTime - p.ArrivalTime);
                    }
                }
            }
        }

        private void UpdateProcessInChart(Process p, Color c)
        {
            Series s = this.chart1.Series.FindByName(p.ID.ToString());
            if (p.ExecutionTime == p.ExecutedTime)
            {
                this.chart1.Series.Remove(s);
                return;
            }

            s.Color = c;
            s.Points[0].SetValueY(p.RemaingTime);
        }

        private void UpdateResponseTime(int responseTime)
        {
            this.responseTimes.Add(responseTime);

            int minTime = responseTime;
            int avgTime = 0;
            int desvTime = 0;
            int maxTime = responseTime;

            foreach (int time in this.responseTimes)
            {
                avgTime += time;

                if (time < minTime)
                {
                    minTime = time;
                }

                if (time > maxTime)
                {
                    maxTime = time;
                }
            }

            avgTime /= this.responseTimes.Count;
            foreach (int time in this.responseTimes)
            {
                desvTime += (int)Math.Pow(time - avgTime, 2);
            }
            desvTime = (int)Math.Sqrt(desvTime / this.responseTimes.Count);

            // Actualización de la interfaz
            this.rtMinLabel.Text = minTime.ToString() + " ms";
            this.rtAvgLabel.Text = avgTime.ToString() + " ms";
            this.rtDesvLabel.Text = desvTime.ToString() + " ms";
            this.rtMaxLabel.Text = maxTime.ToString() + " ms";
        }

        private void UpdateTurnaroundTime(int turnaroundTime)
        {
            this.turnaroundTimes.Add(turnaroundTime);

            int minTime = turnaroundTime;
            int avgTime = 0;
            int maxTime = turnaroundTime;
            int desvTime = 0;

            foreach (int time in this.turnaroundTimes) {
                avgTime += time;

                if (time < minTime)
                {
                    minTime = time;
                }

                if (time > maxTime)
                {
                    maxTime = time;
                }
            }

            avgTime /= this.turnaroundTimes.Count;
            foreach (int time in this.turnaroundTimes)
            {
                desvTime += (int) Math.Pow(time - avgTime, 2);
            }
            desvTime = (int) Math.Sqrt(desvTime / this.turnaroundTimes.Count);

            // Actualización de la interfaz
            this.taMinLabel.Text = minTime.ToString() + " ms";
            this.taAvgLabel.Text = avgTime.ToString() + " ms";
            this.taDesvLabel.Text = desvTime.ToString() + " ms";
            this.taMaxLabel.Text = maxTime.ToString() + " ms";
        }

        private void UpdateCpuTime()
        {
            this.cpuTimeLabel.Text = this.actualTime.ToString() + " ms";
            this.labelIdleCpu.Text = this.idleTime.ToString() + " ms";
            this.cpuBussyLabel.Text = (this.actualTime - this.idleTime).ToString() + " ms";
            
        }

        delegate void UpdateProcessInChartCallback(Process p, Color c);
        delegate void UpdateResponseTimeCallback(int responseTime);
        delegate void UpdateTurnaroundTimeCallback(int responseTime);
        delegate void UpdateCpuTimeCallback();

        private void btnRestartProcesses_Click(object sender, EventArgs e)
        {
            this.KillProcesses();
            this.GenerateProcesses();
            this.btnStart.Enabled = true;

            // Limpiar Listas de tiempos
            this.responseTimes.Clear();
            this.turnaroundTimes.Clear();

            // Limpiar todas las etiquetas
            this.taMinLabel.Text = "0 ms";
            this.taAvgLabel.Text = "0 ms";
            this.taDesvLabel.Text = "0 ms";
            this.taMaxLabel.Text = "0 ms";
            this.rtMinLabel.Text = "0 ms";
            this.rtDesvLabel.Text = "0 ms";
            this.rtAvgLabel.Text = "0 ms";
            this.rtMaxLabel.Text = "0 ms";
            this.cpuTimeLabel.Text = "0 ms";
            this.labelIdleCpu.Text = "0 ms";
            this.cpuBussyLabel.Text = "0 ms";
        }
    }
}
