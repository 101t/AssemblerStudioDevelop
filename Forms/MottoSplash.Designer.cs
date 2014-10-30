namespace AssemblerStudioDevelop
{
    partial class MottoSplash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MottoSplash));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Percentagelabel1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Percentagelabel1
            // 
            this.Percentagelabel1.AutoSize = true;
            this.Percentagelabel1.BackColor = System.Drawing.Color.Transparent;
            this.Percentagelabel1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.Percentagelabel1.Location = new System.Drawing.Point(13, 131);
            this.Percentagelabel1.Name = "Percentagelabel1";
            this.Percentagelabel1.Size = new System.Drawing.Size(24, 13);
            this.Percentagelabel1.TabIndex = 0;
            this.Percentagelabel1.Text = "0%";
            // 
            // MottoSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::AssemblerStudioDevelop.Properties.Resources.zxoscq3vu1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(320, 480);
            this.Controls.Add(this.Percentagelabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MottoSplash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MottoSplash";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Percentagelabel1;
    }
}