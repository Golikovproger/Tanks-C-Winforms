namespace Kursovaya_Tanchiki
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.TimeFirstTank = new System.Windows.Forms.Timer(this.components);
            this.Timerbullet = new System.Windows.Forms.Timer(this.components);
            this.TimerSecTank = new System.Windows.Forms.Timer(this.components);
            this.TimerforEnd = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // TimeFirstTank
            // 
            this.TimeFirstTank.Enabled = true;
            this.TimeFirstTank.Interval = 1;
            this.TimeFirstTank.Tick += new System.EventHandler(this.TimerforFirstTank);
            // 
            // Timerbullet
            // 
            this.Timerbullet.Enabled = true;
            this.Timerbullet.Interval = 20;
            this.Timerbullet.Tick += new System.EventHandler(this.TimerforBullet);
            // 
            // TimerSecTank
            // 
            this.TimerSecTank.Enabled = true;
            this.TimerSecTank.Interval = 1;
            this.TimerSecTank.Tag = "";
            this.TimerSecTank.Tick += new System.EventHandler(this.TimerforSec);
            // 
            // TimerforEnd
            // 
            this.TimerforEnd.Enabled = true;
            this.TimerforEnd.Interval = 1;
            this.TimerforEnd.Tick += new System.EventHandler(this.TimerForEnd);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(645, 641);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Танчики";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer TimeFirstTank;
        private System.Windows.Forms.Timer Timerbullet;
        private System.Windows.Forms.Timer TimerSecTank;
        private System.Windows.Forms.Timer TimerforEnd;
    }
}