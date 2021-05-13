using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FCFS
{
    public partial class Form1 : Form
    {

        private Thread threadProcesses;

        public Form1()
        {
            InitializeComponent();
        }

        public void ButtonStartClick(object sender, EventArgs e)
        {
            //Restart horses postion
            foreach (PictureBox pbHorse in this.pictureBoxesHorse)
            {
                pbHorse.Location = new Point(35, pbHorse.Location.Y);
            }

            threadProcesses = new Thread(new ThreadStart(this.RunProcesses));
            threadProcesses.Start();

            this.buttonStart.Enabled = false;
        }

        public void ButtonStopClick(object sender, EventArgs e)
        {
            this.KillProcesses();
        }

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
                this.buttonStart.Enabled = true;
            }
        }

        private void RunProcesses() {
            foreach (PictureBox pbHorse in this.pictureBoxesHorse)
            {
                for (int i = 0; i < 70; i++) {
                    pbHorse.Location = new Point(35 + (10 * i),
                        pbHorse.Location.Y);
                    Thread.Sleep(100);
                }
            }

            this.buttonStart.Enabled = true;
        }

    }
}
