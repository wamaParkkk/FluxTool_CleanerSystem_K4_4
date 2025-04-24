
namespace FluxTool_CleanerSystem_K4_4
{
    partial class DigitalDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DigitalDlg));
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lstState = new System.Windows.Forms.ListBox();
            this.m_Key_Cancel = new System.Windows.Forms.Button();
            this.m_Key_OK = new System.Windows.Forms.Button();
            this.labelIOName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.m_lstState);
            this.panel1.Location = new System.Drawing.Point(12, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 155);
            this.panel1.TabIndex = 44;
            // 
            // m_lstState
            // 
            this.m_lstState.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lstState.FormattingEnabled = true;
            this.m_lstState.ItemHeight = 25;
            this.m_lstState.Location = new System.Drawing.Point(3, 3);
            this.m_lstState.Name = "m_lstState";
            this.m_lstState.Size = new System.Drawing.Size(230, 129);
            this.m_lstState.TabIndex = 5;
            this.m_lstState.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_lstState_MouseDoubleClick);
            // 
            // m_Key_Cancel
            // 
            this.m_Key_Cancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_Key_Cancel.BackgroundImage")));
            this.m_Key_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("m_Key_Cancel.Image")));
            this.m_Key_Cancel.Location = new System.Drawing.Point(134, 198);
            this.m_Key_Cancel.Name = "m_Key_Cancel";
            this.m_Key_Cancel.Size = new System.Drawing.Size(80, 40);
            this.m_Key_Cancel.TabIndex = 46;
            this.m_Key_Cancel.UseVisualStyleBackColor = true;
            this.m_Key_Cancel.Click += new System.EventHandler(this.m_Key_Cancel_Click);
            // 
            // m_Key_OK
            // 
            this.m_Key_OK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_Key_OK.BackgroundImage")));
            this.m_Key_OK.Image = ((System.Drawing.Image)(resources.GetObject("m_Key_OK.Image")));
            this.m_Key_OK.Location = new System.Drawing.Point(48, 198);
            this.m_Key_OK.Name = "m_Key_OK";
            this.m_Key_OK.Size = new System.Drawing.Size(80, 40);
            this.m_Key_OK.TabIndex = 45;
            this.m_Key_OK.UseVisualStyleBackColor = true;
            this.m_Key_OK.Click += new System.EventHandler(this.m_Key_OK_Click);
            // 
            // labelIOName
            // 
            this.labelIOName.AutoSize = true;
            this.labelIOName.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIOName.ForeColor = System.Drawing.Color.Navy;
            this.labelIOName.Location = new System.Drawing.Point(13, 9);
            this.labelIOName.Name = "labelIOName";
            this.labelIOName.Size = new System.Drawing.Size(22, 21);
            this.labelIOName.TabIndex = 47;
            this.labelIOName.Text = "--";
            // 
            // DigitalDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 244);
            this.Controls.Add(this.labelIOName);
            this.Controls.Add(this.m_Key_Cancel);
            this.Controls.Add(this.m_Key_OK);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DigitalDlg";
            this.Text = "Digital";
            this.Load += new System.EventHandler(this.DigitalDlg_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox m_lstState;
        private System.Windows.Forms.Button m_Key_Cancel;
        private System.Windows.Forms.Button m_Key_OK;
        public System.Windows.Forms.Label labelIOName;
    }
}