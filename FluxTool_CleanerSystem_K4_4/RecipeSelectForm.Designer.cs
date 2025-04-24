
namespace FluxTool_CleanerSystem_K4_4
{
    partial class RecipeSelectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipeSelectForm));
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_RecipeName = new System.Windows.Forms.ListBox();
            this.btn_RecipeFile_SelectCancel = new System.Windows.Forms.Button();
            this.btn_RecipeFile_Select = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 30);
            this.label1.TabIndex = 52;
            this.label1.Text = "Process Recipe Select";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox_RecipeName
            // 
            this.listBox_RecipeName.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_RecipeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBox_RecipeName.FormattingEnabled = true;
            this.listBox_RecipeName.ItemHeight = 20;
            this.listBox_RecipeName.Location = new System.Drawing.Point(12, 42);
            this.listBox_RecipeName.Name = "listBox_RecipeName";
            this.listBox_RecipeName.Size = new System.Drawing.Size(286, 284);
            this.listBox_RecipeName.TabIndex = 53;
            // 
            // btn_RecipeFile_SelectCancel
            // 
            this.btn_RecipeFile_SelectCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_RecipeFile_SelectCancel.BackgroundImage")));
            this.btn_RecipeFile_SelectCancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_RecipeFile_SelectCancel.Image")));
            this.btn_RecipeFile_SelectCancel.Location = new System.Drawing.Point(219, 340);
            this.btn_RecipeFile_SelectCancel.Name = "btn_RecipeFile_SelectCancel";
            this.btn_RecipeFile_SelectCancel.Size = new System.Drawing.Size(80, 40);
            this.btn_RecipeFile_SelectCancel.TabIndex = 60;
            this.btn_RecipeFile_SelectCancel.UseVisualStyleBackColor = true;
            this.btn_RecipeFile_SelectCancel.Click += new System.EventHandler(this.btn_RecipeFile_SelectCancel_Click);
            // 
            // btn_RecipeFile_Select
            // 
            this.btn_RecipeFile_Select.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_RecipeFile_Select.BackgroundImage")));
            this.btn_RecipeFile_Select.Image = ((System.Drawing.Image)(resources.GetObject("btn_RecipeFile_Select.Image")));
            this.btn_RecipeFile_Select.Location = new System.Drawing.Point(133, 340);
            this.btn_RecipeFile_Select.Name = "btn_RecipeFile_Select";
            this.btn_RecipeFile_Select.Size = new System.Drawing.Size(80, 40);
            this.btn_RecipeFile_Select.TabIndex = 59;
            this.btn_RecipeFile_Select.UseVisualStyleBackColor = true;
            this.btn_RecipeFile_Select.Click += new System.EventHandler(this.btn_RecipeFile_Select_Click);
            // 
            // RecipeSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(311, 388);
            this.Controls.Add(this.btn_RecipeFile_SelectCancel);
            this.Controls.Add(this.btn_RecipeFile_Select);
            this.Controls.Add(this.listBox_RecipeName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RecipeSelectForm";
            this.Text = "Recipe File Select";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecipeSelectForm_FormClosing);
            this.Load += new System.EventHandler(this.RecipeSelectForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_RecipeName;
        private System.Windows.Forms.Button btn_RecipeFile_SelectCancel;
        private System.Windows.Forms.Button btn_RecipeFile_Select;
    }
}