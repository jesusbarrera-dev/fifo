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
        private const int MAX_SCHEDULE_TIME = 15;

        private Random rand;
        private int quantum = 500; // 500ms
        private int actualTime = 0;
        private int idleTime = 0;

        private Thread threadProcesses;
        private Queue<Process> processes;

        private List<int> responseTimes;
        private List<int> turnaroundTimes;

        public Form1()
        {
            InitializeComponent();
            this.rand = new Random();
            this.processes = new Queue<Process>();
            this.responseTimes = new List<int>();
            this.turnaroundTimes = new List<int>();

            this.GenerateProcesses();
        }

        private void GenerateProcesses()
        {
            Process p;
            Series s;

            this.processes.Clear();
            this.chart1.Series.Clear();

            for (int i = 0; i < MAX_PROCESSES; i++)
            {
                p = new Process()
                {
                    ID = i + 1,
                    ExecutionTime = rand.Next(1, MAX_EXECUTION_TIME) * UNIT_TIME, //Tiempo de ejecución entre 100 y 2000 ms
                };

                this.processes.Enqueue(p);

                s = this.chart1.Series.Add(p.ID.ToString());
                s.Color = Color.White;
                s.BorderColor = Color.Black;
                s.Points.Add(p.ExecutionTime);
                s.Label = p.ID.ToString();
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            this.threadProcesses = new Thread(new ThreadStart(this.RunRoundRobin));
            this.threadProcesses.Start();

            this.btnStart.Enabled = false;
        }

        // Al cerrar la ventana se abrotará el hilo
        public void ActionFormClosing(object sender, FormClosingEventArgs e)
        {
            this.KillProcesses();
        }

        private void KillProcesses()
        {
            if (this.threadProcesses != null)
            {
                this.threadProcesses.Abort();
                this.threadProcesses = null;
            }
        }

        private void RunRoundRobin()
        {
            Queue<Process> queue = new Queue<Process>();
            Process p;
            UpdateProcessInChartCallback cbChart = new UpdateProcessInChartCallback(this.UpdateProcessInChart);
            UpdateResponseTimeCallback cbResponse = new UpdateResponseTimeCallback(this.UpdateResponseTime);
            UpdateTurnaroundTimeCallback cbTurnaround = new UpdateTurnaroundTimeCallback(this.UpdateTurnaroundTime);
            UpdateCpuTimeCallback cbCPU = new UpdateCpuTimeCallback(this.UpdateCpuTime);

            this.actualTime = 0;
            this.idleTime = 0;

            // Tiempo en que se encolará nuevo proceso entre 100 a 1400 ms
            int timeToNewProcess = actualTime + rand.Next(1, MAX_SCHEDULE_TIME) * UNIT_TIME;

            while (this.processes.Count > 0 || queue.Count > 0)
            {
                p = queue.Count > 0
                    ? queue.Peek()
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
                this.actualTime += UNIT_TIME;

                if (p != null)
                {
                    p.ExecutedTime += UNIT_TIME; // Actualización del tiempo de ejecución del proceso actual

                    if (p.ExecutedTime == p.ExecutionTime) // Proceso Terminado
                    {
                        p = queue.Dequeue();
                        this.Invoke(cbChart, p, Color.White);

                        // Calculo Tiempo Tournaround (TiempoTerminaEjecucion - TiempoLLegada)
                        this.Invoke(cbTurnaround, this.actualTime - p.ArrivalTime);
                    }
                    else if ((p.ExecutedTime % this.quantum) == 0) // Proceso Bloqueado porqué llegó al límete del Quantum
                    {
                        p = queue.Dequeue(); //Se Desencola el proceso actual para darle paso a los demás
                        this.Invoke(cbChart, p, Color.DarkGreen);
                        queue.Enqueue(p);
                    }
                }
                else // No hubo ningun proceso en la cola de ejecución
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
                        queue.Enqueue(p); // Proceso encolado

                        // Tiempo en que se encolará nuevo proceso entre 100 a 1400 ms
                        timeToNewProcess = actualTime + rand.Next(1, MAX_EXECUTION_TIME) * UNIT_TIME; 
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
            s.Points[0].SetValueY(p.ExecutionTime - p.ExecutedTime);
        }

        private void UpdateResponseTime(int responseTime)
        {
            this.responseTimes.Add(responseTime);

            int minTime = responseTime;
            int avgTime = 0;
            int maxTime = responseTime;
            // TODO Desviación estandar

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

            // Actualización de la interfaz
            // TODO Mostrar promedio y desviacion
            this.rtMinLabel.Text = minTime.ToString();
            this.rtMaxLabel.Text = maxTime.ToString();
        }

        private void UpdateTurnaroundTime(int turnaroundTime)
        {
            this.turnaroundTimes.Add(turnaroundTime);

            int minTime = turnaroundTime;
            int avgTime = 0;
            int maxTime = turnaroundTime;
            // TODO Desviación estandar

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

            // Actualización de la interfaz
            // TODO Mostrar promedio y desviacion
            this.taMinLabel.Text = minTime.ToString();
            this.taMaxLabel.Text = maxTime.ToString();
        }

        private void UpdateCpuTime()
        {
            this.cpuTimeLabel.Text = this.actualTime.ToString();
            this.cpuBussyLabel.Text = (this.actualTime - this.idleTime).ToString();
            // TODO Idle Time
            // this.cpuIdleLabel.Text = this.idleTime.ToString();
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
            this.taMinLabel.Text = "0";
            this.taMaxLabel.Text = "0";
            this.rtMinLabel.Text = "0";
            this.rtMaxLabel.Text = "0";
            this.cpuTimeLabel.Text = "0";
            this.cpuBussyLabel.Text = "0";
        }
    }
}
