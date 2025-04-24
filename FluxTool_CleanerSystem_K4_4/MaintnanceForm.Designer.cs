
namespace FluxTool_CleanerSystem_K4_4
{
    partial class MaintnanceForm
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
            this.displayTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // displayTimer
            // 
            this.displayTimer.Enabled = true;
            this.displayTimer.Interval = 1000;
            this.displayTimer.Tick += new System.EventHandler(this.displayTimer_Tick);
            // 
            // MaintnanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1172, 824);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MaintnanceForm";
            this.Text = "MaintnanceForm";
            this.Activated += new System.EventHandler(this.MaintnanceForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaintnanceForm_FormClosing);
            this.Load += new System.EventHandler(this.MaintnanceForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer displayTimer;
    }
}