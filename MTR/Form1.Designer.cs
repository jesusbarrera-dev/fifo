
namespace Practica
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnStart = new System.Windows.Forms.Button();
            this.cpuLabel = new System.Windows.Forms.Label();
            this.rtLabel = new System.Windows.Forms.Label();
            this.taLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cpuTimeLabel = new System.Windows.Forms.Label();
            this.cpuBussyLabel = new System.Windows.Forms.Label();
            this.rtMinLabel = new System.Windows.Forms.Label();
            this.rtMaxLabel = new System.Windows.Forms.Label();
            this.taMinLabel = new System.Windows.Forms.Label();
            this.taMaxLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnRestartProcesses = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelIdleCpu = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.rtAvgLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.taAvgLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.rtDesvLabel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.taDesvLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(776, 164);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(673, 394);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Iniciar";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // cpuLabel
            // 
            this.cpuLabel.AutoSize = true;
            this.cpuLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpuLabel.Location = new System.Drawing.Point(79, 213);
            this.cpuLabel.Name = "cpuLabel";
            this.cpuLabel.Size = new System.Drawing.Size(32, 13);
            this.cpuLabel.TabIndex = 2;
            this.cpuLabel.Text = "CPU";
            // 
            // rtLabel
            // 
            this.rtLabel.AutoSize = true;
            this.rtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtLabel.Location = new System.Drawing.Point(254, 213);
            this.rtLabel.Name = "rtLabel";
            this.rtLabel.Size = new System.Drawing.Size(125, 13);
            this.rtLabel.TabIndex = 4;
            this.rtLabel.Text = "Tiempo de respuesta";
            // 
            // taLabel
            // 
            this.taLabel.AutoSize = true;
            this.taLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taLabel.Location = new System.Drawing.Point(493, 213);
            this.taLabel.Name = "taLabel";
            this.taLabel.Size = new System.Drawing.Size(113, 13);
            this.taLabel.TabIndex = 5;
            this.taLabel.Text = "Tiempo turnaround";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tiempo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ocupado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Min";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(493, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Min";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(257, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Max";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(493, 306);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Max";
            // 
            // cpuTimeLabel
            // 
            this.cpuTimeLabel.AutoSize = true;
            this.cpuTimeLabel.Location = new System.Drawing.Point(180, 259);
            this.cpuTimeLabel.Name = "cpuTimeLabel";
            this.cpuTimeLabel.Size = new System.Drawing.Size(29, 13);
            this.cpuTimeLabel.TabIndex = 12;
            this.cpuTimeLabel.Text = "0 ms";
            // 
            // cpuBussyLabel
            // 
            this.cpuBussyLabel.AutoSize = true;
            this.cpuBussyLabel.Location = new System.Drawing.Point(180, 306);
            this.cpuBussyLabel.Name = "cpuBussyLabel";
            this.cpuBussyLabel.Size = new System.Drawing.Size(29, 13);
            this.cpuBussyLabel.TabIndex = 13;
            this.cpuBussyLabel.Text = "0 ms";
            // 
            // rtMinLabel
            // 
            this.rtMinLabel.AutoSize = true;
            this.rtMinLabel.Location = new System.Drawing.Point(388, 260);
            this.rtMinLabel.Name = "rtMinLabel";
            this.rtMinLabel.Size = new System.Drawing.Size(29, 13);
            this.rtMinLabel.TabIndex = 14;
            this.rtMinLabel.Text = "0 ms";
            // 
            // rtMaxLabel
            // 
            this.rtMaxLabel.AutoSize = true;
            this.rtMaxLabel.Location = new System.Drawing.Point(388, 307);
            this.rtMaxLabel.Name = "rtMaxLabel";
            this.rtMaxLabel.Size = new System.Drawing.Size(29, 13);
            this.rtMaxLabel.TabIndex = 15;
            this.rtMaxLabel.Text = "0 ms";
            // 
            // taMinLabel
            // 
            this.taMinLabel.AutoSize = true;
            this.taMinLabel.Location = new System.Drawing.Point(611, 259);
            this.taMinLabel.Name = "taMinLabel";
            this.taMinLabel.Size = new System.Drawing.Size(29, 13);
            this.taMinLabel.TabIndex = 16;
            this.taMinLabel.Text = "0 ms";
            // 
            // taMaxLabel
            // 
            this.taMaxLabel.AutoSize = true;
            this.taMaxLabel.Location = new System.Drawing.Point(611, 307);
            this.taMaxLabel.Name = "taMaxLabel";
            this.taMaxLabel.Size = new System.Drawing.Size(29, 13);
            this.taMaxLabel.TabIndex = 17;
            this.taMaxLabel.Text = "0 ms";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(79, 404);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Leyenda:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DarkGreen;
            this.label9.Location = new System.Drawing.Point(144, 404);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Bloqueado";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label10.Location = new System.Drawing.Point(221, 404);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "En Cola";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(289, 404);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Ejecutando";
            // 
            // btnRestartProcesses
            // 
            this.btnRestartProcesses.Location = new System.Drawing.Point(557, 394);
            this.btnRestartProcesses.Name = "btnRestartProcesses";
            this.btnRestartProcesses.Size = new System.Drawing.Size(110, 23);
            this.btnRestartProcesses.TabIndex = 22;
            this.btnRestartProcesses.Text = "Reinicar Procesos";
            this.btnRestartProcesses.UseVisualStyleBackColor = true;
            this.btnRestartProcesses.Click += new System.EventHandler(this.btnRestartProcesses_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Idle";
            // 
            // labelIdleCpu
            // 
            this.labelIdleCpu.AutoSize = true;
            this.labelIdleCpu.Location = new System.Drawing.Point(180, 283);
            this.labelIdleCpu.Name = "labelIdleCpu";
            this.labelIdleCpu.Size = new System.Drawing.Size(29, 13);
            this.labelIdleCpu.TabIndex = 24;
            this.labelIdleCpu.Text = "0 ms";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(258, 283);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Avg";
            // 
            // rtAvgLabel
            // 
            this.rtAvgLabel.AutoSize = true;
            this.rtAvgLabel.Location = new System.Drawing.Point(388, 283);
            this.rtAvgLabel.Name = "rtAvgLabel";
            this.rtAvgLabel.Size = new System.Drawing.Size(29, 13);
            this.rtAvgLabel.TabIndex = 26;
            this.rtAvgLabel.Text = "0 ms";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(493, 283);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Avg";
            // 
            // taAvgLabel
            // 
            this.taAvgLabel.AutoSize = true;
            this.taAvgLabel.Location = new System.Drawing.Point(611, 283);
            this.taAvgLabel.Name = "taAvgLabel";
            this.taAvgLabel.Size = new System.Drawing.Size(29, 13);
            this.taAvgLabel.TabIndex = 28;
            this.taAvgLabel.Text = "0 ms";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(257, 331);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Desv";
            // 
            // rtDesvLabel
            // 
            this.rtDesvLabel.AutoSize = true;
            this.rtDesvLabel.Location = new System.Drawing.Point(388, 331);
            this.rtDesvLabel.Name = "rtDesvLabel";
            this.rtDesvLabel.Size = new System.Drawing.Size(29, 13);
            this.rtDesvLabel.TabIndex = 30;
            this.rtDesvLabel.Text = "0 ms";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(493, 331);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "Desv";
            // 
            // taDesvLabel
            // 
            this.taDesvLabel.AutoSize = true;
            this.taDesvLabel.Location = new System.Drawing.Point(611, 331);
            this.taDesvLabel.Name = "taDesvLabel";
            this.taDesvLabel.Size = new System.Drawing.Size(29, 13);
            this.taDesvLabel.TabIndex = 32;
            this.taDesvLabel.Text = "0 ms";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.taDesvLabel);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.rtDesvLabel);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.taAvgLabel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.rtAvgLabel);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.labelIdleCpu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRestartProcesses);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.taMaxLabel);
            this.Controls.Add(this.taMinLabel);
            this.Controls.Add(this.rtMaxLabel);
            this.Controls.Add(this.rtMinLabel);
            this.Controls.Add(this.cpuBussyLabel);
            this.Controls.Add(this.cpuTimeLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.taLabel);
            this.Controls.Add(this.rtLabel);
            this.Controls.Add(this.cpuLabel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ActionFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label cpuLabel;
        private System.Windows.Forms.Label rtLabel;
        private System.Windows.Forms.Label taLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label cpuTimeLabel;
        private System.Windows.Forms.Label cpuBussyLabel;
        private System.Windows.Forms.Label rtMinLabel;
        private System.Windows.Forms.Label rtMaxLabel;
        private System.Windows.Forms.Label taMinLabel;
        private System.Windows.Forms.Label taMaxLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnRestartProcesses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelIdleCpu;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label rtAvgLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label taAvgLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label rtDesvLabel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label taDesvLabel;
    }
}

