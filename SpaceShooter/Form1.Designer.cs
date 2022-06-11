
namespace SpaceShooter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            this.pbUFO = new System.Windows.Forms.PictureBox();
            this.timeGameLoop = new System.Windows.Forms.Timer(this.components);
            this.progBarHealth = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbUFO)).BeginInit();
            this.SuspendLayout();
            // 
            // pbUFO
            // 
            this.pbUFO.BackColor = System.Drawing.Color.Transparent;
            this.pbUFO.BackgroundImage = global::SpaceShooter.Properties.Resources.ufoRed;
            this.pbUFO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbUFO.Location = new System.Drawing.Point(278, 308);
            this.pbUFO.Margin = new System.Windows.Forms.Padding(0);
            this.pbUFO.Name = "pbUFO";
            this.pbUFO.Size = new System.Drawing.Size(120, 102);
            this.pbUFO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbUFO.TabIndex = 0;
            this.pbUFO.TabStop = false;
            // 
            // timeGameLoop
            // 
            this.timeGameLoop.Enabled = true;
            this.timeGameLoop.Interval = 30;
            this.timeGameLoop.Tick += new System.EventHandler(this.timeGameLoop_Tick);
            // 
            // progBarHealth
            // 
            this.progBarHealth.Location = new System.Drawing.Point(278, 413);
            this.progBarHealth.Name = "progBarHealth";
            this.progBarHealth.Size = new System.Drawing.Size(120, 10);
            this.progBarHealth.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progBarHealth.TabIndex = 1;
            this.progBarHealth.Value = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SpaceShooter.Properties.Resources.STEALER___cyberpunk_puzzle_platformer;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progBarHealth);
            this.Controls.Add(this.pbUFO);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbUFO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbUFO;
        private System.Windows.Forms.Timer timeGameLoop;
        private System.Windows.Forms.ProgressBar progBarHealth;
    }
}

