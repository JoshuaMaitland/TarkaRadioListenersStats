namespace TarkaRadioListenersStats
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblListenersCount = new System.Windows.Forms.Label();
            this.lblListenersPeak = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblListenersCount
            // 
            this.lblListenersCount.AutoSize = true;
            this.lblListenersCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListenersCount.Location = new System.Drawing.Point(12, 9);
            this.lblListenersCount.Name = "lblListenersCount";
            this.lblListenersCount.Size = new System.Drawing.Size(371, 51);
            this.lblListenersCount.TabIndex = 0;
            this.lblListenersCount.Text = "Listeners Count: 0";
            // 
            // lblListenersPeak
            // 
            this.lblListenersPeak.AutoSize = true;
            this.lblListenersPeak.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListenersPeak.Location = new System.Drawing.Point(12, 70);
            this.lblListenersPeak.Name = "lblListenersPeak";
            this.lblListenersPeak.Size = new System.Drawing.Size(355, 51);
            this.lblListenersPeak.TabIndex = 1;
            this.lblListenersPeak.Text = "Listeners Peak: 0";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 10000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 161);
            this.Controls.Add(this.lblListenersPeak);
            this.Controls.Add(this.lblListenersCount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 200);
            this.Name = "Form1";
            this.Text = "Tarka Radio Listeners Stats";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblListenersCount;
        private System.Windows.Forms.Label lblListenersPeak;
        private System.Windows.Forms.Timer timerRefresh;
    }
}

