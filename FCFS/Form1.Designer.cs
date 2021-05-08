
namespace FCFS
{
    partial class Form1
    {
        private const int NUM_HORSES = 3;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
            // this.pictureBoxesHorses = new List<System.Windows.Forms.PictureBox>();
            this.pictureBoxesHorse = new System.Collections.Generic.List<System.Windows.Forms.PictureBox>();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBackground
            // 
            this.pictureBoxBackground.Image = ((System.Drawing.Image)(resources.GetObject("Background")));
            this.pictureBoxBackground.Location = new System.Drawing.Point(-1, 0);
            this.pictureBoxBackground.Name = "pictureBoxBackground";
            this.pictureBoxBackground.Size = new System.Drawing.Size(801, 449);
            this.pictureBoxBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBackground.TabIndex = 0;
            this.pictureBoxBackground.TabStop = false;

            // 
            // pictureBoxListHorses
            // 
            System.Windows.Forms.PictureBox pictureBoxHorse;
            for (int i = 0; i < NUM_HORSES; i++) {
                pictureBoxHorse = new System.Windows.Forms.PictureBox();
                ((System.ComponentModel.ISupportInitialize)(pictureBoxHorse)).BeginInit();
                pictureBoxHorse.Image = ((System.Drawing.Image)(resources.GetObject("Horse")));
                pictureBoxHorse.Location = new System.Drawing.Point(35, 154 + (80 * i));
                pictureBoxHorse.Name = "Horse" + (i + 1).ToString();
                pictureBoxHorse.Size = new System.Drawing.Size(70, 35);
                pictureBoxHorse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                pictureBoxHorse.TabIndex = i + 1;
                pictureBoxHorse.TabStop = false;
                ((System.ComponentModel.ISupportInitialize)(pictureBoxHorse)).EndInit();
                this.Controls.Add(pictureBoxHorse);
                this.pictureBoxesHorse.Add(pictureBoxHorse);
            }
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBoxBackground);
            this.Name = "FCFS";
            this.Text = "FCFS";

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).EndInit();
            // ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            // ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            // ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();

            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBackground;
        private System.Collections.Generic.List<System.Windows.Forms.PictureBox> pictureBoxesHorse;
    }
}

