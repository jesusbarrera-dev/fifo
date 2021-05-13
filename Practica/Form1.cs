using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Practica
{
    public partial class Form1 : Form
    {
        int [] conjunto = {5,8,9,2,7,4};
        String[] datos = {"A", "B", "C", "D", "E", "F" };
        Burbuja b;

        public Form1()
        {
            InitializeComponent();
            b = new Burbuja(conjunto);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            b.Ordenar();
            conjunto = b.getConjunto();

            System.Windows.Forms.DataVisualization.Charting.Series series = this.chart1.Series.Add("Total ");
            this.chart1.Series.Clear();

            this.chart1.Palette = ChartColorPalette.SeaGreen;
            //this.chart1.Titles.Add("Ventas");
            for (int i = 0; i < conjunto.Length; i++)
            {
                series = this.chart1.Series.Add(datos[i]);
                series.Points.Add(conjunto[i]);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
