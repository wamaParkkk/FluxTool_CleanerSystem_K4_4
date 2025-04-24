
namespace FluxTool_CleanerSystem_K4_4
{
    partial class RecipeForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.listBox_RecipeName = new System.Windows.Forms.ListBox();
            this.recipeGrid = new System.Windows.Forms.DataGridView();
            this.btn_RecipeStep_Add = new System.Windows.Forms.Button();
            this.btn_RecipeStep_Del = new System.Windows.Forms.Button();
            this.btn_RecipeFile_Del = new System.Windows.Forms.Button();
            this.btn_RecipeFile_New = new System.Windows.Forms.Button();
            this.btn_RecipeFile_Copy = new System.Windows.Forms.Button();
            this.btn_RecipeFile_Cancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_CurStep = new System.Windows.Forms.Label();
            this.txt_RecipeFileName = new System.Windows.Forms.Label();
            this.txt_Step = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_RecipeStep_Insert = new System.Windows.Forms.Button();
            this.btn_RecipeFile_Edit = new System.Windows.Forms.Button();
            this.btn_RecipeFile_Save = new System.Windows.Forms.Button();
            this.txt_Mode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.recipeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_RecipeName
            // 
            this.listBox_RecipeName.BackColor = System.Drawing.Color.White;
            this.listBox_RecipeName.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_RecipeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBox_RecipeName.FormattingEnabled = true;
            this.listBox_RecipeName.ItemHeight = 20;
            this.listBox_RecipeName.Location = new System.Drawing.Point(12, 42);
            this.listBox_RecipeName.Name = "listBox_RecipeName";
            this.listBox_RecipeName.Size = new System.Drawing.Size(286, 644);
            this.listBox_RecipeName.TabIndex = 0;
            this.listBox_RecipeName.SelectedIndexChanged += new System.EventHandler(this.listBox_RecipeName_SelectedIndexChanged);
            // 
            // recipeGrid
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipeGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.recipeGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.recipeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.recipeGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.recipeGrid.Location = new System.Drawing.Point(304, 42);
            this.recipeGrid.Name = "recipeGrid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.recipeGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipeGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.recipeGrid.RowTemplate.Height = 23;
            this.recipeGrid.Size = new System.Drawing.Size(803, 652);
            this.recipeGrid.TabIndex = 1;
            this.recipeGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.recipeGrid_CellClick);
            this.recipeGrid.SelectionChanged += new System.EventHandler(this.recipeGrid_SelectionChanged);
            // 
            // btn_RecipeStep_Add
            // 
            this.btn_RecipeStep_Add.BackColor = System.Drawing.Color.Transparent;
            this.btn_RecipeStep_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RecipeStep_Add.FlatAppearance.BorderSize = 0;
            this.btn_RecipeStep_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RecipeStep_Add.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RecipeStep_Add.ForeColor = System.Drawing.Color.Navy;
            this.btn_RecipeStep_Add.Location = new System.Drawing.Point(514, 700);
            this.btn_RecipeStep_Add.Name = "btn_RecipeStep_Add";
            this.btn_RecipeStep_Add.Size = new System.Drawing.Size(67, 37);
            this.btn_RecipeStep_Add.TabIndex = 42;
            this.btn_RecipeStep_Add.Text = "Add";
            this.btn_RecipeStep_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_RecipeStep_Add.UseVisualStyleBackColor = false;
            this.btn_RecipeStep_Add.Click += new System.EventHandler(this.btn_RecipeStep_Add_Click);
            // 
            // btn_RecipeStep_Del
            // 
            this.btn_RecipeStep_Del.BackColor = System.Drawing.Color.Transparent;
            this.btn_RecipeStep_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RecipeStep_Del.FlatAppearance.BorderSize = 0;
            this.btn_RecipeStep_Del.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RecipeStep_Del.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RecipeStep_Del.ForeColor = System.Drawing.Color.Red;
            this.btn_RecipeStep_Del.Location = new System.Drawing.Point(660, 700);
            this.btn_RecipeStep_Del.Name = "btn_RecipeStep_Del";
            this.btn_RecipeStep_Del.Size = new System.Drawing.Size(67, 37);
            this.btn_RecipeStep_Del.TabIndex = 43;
            this.btn_RecipeStep_Del.Text = "Delete";
            this.btn_RecipeStep_Del.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_RecipeStep_Del.UseVisualStyleBackColor = false;
            this.btn_RecipeStep_Del.Click += new System.EventHandler(this.btn_RecipeStep_Del_Click);
            // 
            // btn_RecipeFile_Del
            // 
            this.btn_RecipeFile_Del.BackColor = System.Drawing.Color.Transparent;
            this.btn_RecipeFile_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RecipeFile_Del.FlatAppearance.BorderSize = 0;
            this.btn_RecipeFile_Del.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RecipeFile_Del.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RecipeFile_Del.ForeColor = System.Drawing.Color.Red;
            this.btn_RecipeFile_Del.Location = new System.Drawing.Point(12, 743);
            this.btn_RecipeFile_Del.Name = "btn_RecipeFile_Del";
            this.btn_RecipeFile_Del.Size = new System.Drawing.Size(67, 37);
            this.btn_RecipeFile_Del.TabIndex = 45;
            this.btn_RecipeFile_Del.Text = "Delete";
            this.btn_RecipeFile_Del.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_RecipeFile_Del.UseVisualStyleBackColor = false;
            this.btn_RecipeFile_Del.Click += new System.EventHandler(this.btn_RecipeFile_Del_Click);
            // 
            // btn_RecipeFile_New
            // 
            this.btn_RecipeFile_New.BackColor = System.Drawing.Color.Transparent;
            this.btn_RecipeFile_New.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RecipeFile_New.FlatAppearance.BorderSize = 0;
            this.btn_RecipeFile_New.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RecipeFile_New.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RecipeFile_New.ForeColor = System.Drawing.Color.Navy;
            this.btn_RecipeFile_New.Location = new System.Drawing.Point(12, 700);
            this.btn_RecipeFile_New.Name = "btn_RecipeFile_New";
            this.btn_RecipeFile_New.Size = new System.Drawing.Size(67, 37);
            this.btn_RecipeFile_New.TabIndex = 44;
            this.btn_RecipeFile_New.Text = "New";
            this.btn_RecipeFile_New.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_RecipeFile_New.UseVisualStyleBackColor = false;
            this.btn_RecipeFile_New.Click += new System.EventHandler(this.btn_RecipeFile_New_Click);
            // 
            // btn_RecipeFile_Copy
            // 
            this.btn_RecipeFile_Copy.BackColor = System.Drawing.Color.Transparent;
            this.btn_RecipeFile_Copy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RecipeFile_Copy.FlatAppearance.BorderSize = 0;
            this.btn_RecipeFile_Copy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RecipeFile_Copy.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RecipeFile_Copy.ForeColor = System.Drawing.Color.Navy;
            this.btn_RecipeFile_Copy.Location = new System.Drawing.Point(158, 700);
            this.btn_RecipeFile_Copy.Name = "btn_RecipeFile_Copy";
            this.btn_RecipeFile_Copy.Size = new System.Drawing.Size(67, 37);
            this.btn_RecipeFile_Copy.TabIndex = 46;
            this.btn_RecipeFile_Copy.Text = "Copy";
            this.btn_RecipeFile_Copy.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_RecipeFile_Copy.UseVisualStyleBackColor = false;
            this.btn_RecipeFile_Copy.Click += new System.EventHandler(this.btn_RecipeFile_Copy_Click);
            // 
            // btn_RecipeFile_Cancel
            // 
            this.btn_RecipeFile_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_RecipeFile_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RecipeFile_Cancel.FlatAppearance.BorderSize = 0;
            this.btn_RecipeFile_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RecipeFile_Cancel.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RecipeFile_Cancel.ForeColor = System.Drawing.Color.Navy;
            this.btn_RecipeFile_Cancel.Location = new System.Drawing.Point(85, 743);
            this.btn_RecipeFile_Cancel.Name = "btn_RecipeFile_Cancel";
            this.btn_RecipeFile_Cancel.Size = new System.Drawing.Size(67, 37);
            this.btn_RecipeFile_Cancel.TabIndex = 47;
            this.btn_RecipeFile_Cancel.Text = "Cancel";
            this.btn_RecipeFile_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_RecipeFile_Cancel.UseVisualStyleBackColor = false;
            this.btn_RecipeFile_Cancel.Click += new System.EventHandler(this.btn_RecipeFile_Cancel_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(505, 700);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(3, 35);
            this.label3.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(304, 700);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 35);
            this.label2.TabIndex = 49;
            this.label2.Text = "Current Step";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_CurStep
            // 
            this.txt_CurStep.BackColor = System.Drawing.Color.White;
            this.txt_CurStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_CurStep.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CurStep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_CurStep.Location = new System.Drawing.Point(442, 700);
            this.txt_CurStep.Name = "txt_CurStep";
            this.txt_CurStep.Size = new System.Drawing.Size(57, 35);
            this.txt_CurStep.TabIndex = 50;
            this.txt_CurStep.Text = "0";
            this.txt_CurStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_RecipeFileName
            // 
            this.txt_RecipeFileName.BackColor = System.Drawing.Color.White;
            this.txt_RecipeFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_RecipeFileName.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_RecipeFileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_RecipeFileName.Location = new System.Drawing.Point(442, 9);
            this.txt_RecipeFileName.Name = "txt_RecipeFileName";
            this.txt_RecipeFileName.Size = new System.Drawing.Size(509, 30);
            this.txt_RecipeFileName.TabIndex = 53;
            this.txt_RecipeFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Step
            // 
            this.txt_Step.BackColor = System.Drawing.Color.White;
            this.txt_Step.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Step.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Step.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Step.Location = new System.Drawing.Point(957, 9);
            this.txt_Step.Name = "txt_Step";
            this.txt_Step.Size = new System.Drawing.Size(150, 30);
            this.txt_Step.TabIndex = 54;
            this.txt_Step.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 30);
            this.label1.TabIndex = 51;
            this.label1.Text = "Process Recipe List";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_RecipeStep_Insert
            // 
            this.btn_RecipeStep_Insert.BackColor = System.Drawing.Color.Transparent;
            this.btn_RecipeStep_Insert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RecipeStep_Insert.FlatAppearance.BorderSize = 0;
            this.btn_RecipeStep_Insert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RecipeStep_Insert.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RecipeStep_Insert.ForeColor = System.Drawing.Color.Navy;
            this.btn_RecipeStep_Insert.Location = new System.Drawing.Point(587, 700);
            this.btn_RecipeStep_Insert.Name = "btn_RecipeStep_Insert";
            this.btn_RecipeStep_Insert.Size = new System.Drawing.Size(67, 37);
            this.btn_RecipeStep_Insert.TabIndex = 55;
            this.btn_RecipeStep_Insert.Text = "Insert";
            this.btn_RecipeStep_Insert.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_RecipeStep_Insert.UseVisualStyleBackColor = false;
            this.btn_RecipeStep_Insert.Click += new System.EventHandler(this.btn_RecipeStep_Insert_Click);
            // 
            // btn_RecipeFile_Edit
            // 
            this.btn_RecipeFile_Edit.BackColor = System.Drawing.Color.Transparent;
            this.btn_RecipeFile_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RecipeFile_Edit.FlatAppearance.BorderSize = 0;
            this.btn_RecipeFile_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RecipeFile_Edit.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RecipeFile_Edit.ForeColor = System.Drawing.Color.Navy;
            this.btn_RecipeFile_Edit.Location = new System.Drawing.Point(85, 700);
            this.btn_RecipeFile_Edit.Name = "btn_RecipeFile_Edit";
            this.btn_RecipeFile_Edit.Size = new System.Drawing.Size(67, 37);
            this.btn_RecipeFile_Edit.TabIndex = 56;
            this.btn_RecipeFile_Edit.Text = "Edit";
            this.btn_RecipeFile_Edit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_RecipeFile_Edit.UseVisualStyleBackColor = false;
            this.btn_RecipeFile_Edit.Click += new System.EventHandler(this.btn_RecipeFile_Edit_Click);
            // 
            // btn_RecipeFile_Save
            // 
            this.btn_RecipeFile_Save.BackColor = System.Drawing.Color.Transparent;
            this.btn_RecipeFile_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RecipeFile_Save.FlatAppearance.BorderSize = 0;
            this.btn_RecipeFile_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RecipeFile_Save.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RecipeFile_Save.ForeColor = System.Drawing.Color.Navy;
            this.btn_RecipeFile_Save.Location = new System.Drawing.Point(231, 700);
            this.btn_RecipeFile_Save.Name = "btn_RecipeFile_Save";
            this.btn_RecipeFile_Save.Size = new System.Drawing.Size(67, 37);
            this.btn_RecipeFile_Save.TabIndex = 57;
            this.btn_RecipeFile_Save.Text = "Save";
            this.btn_RecipeFile_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_RecipeFile_Save.UseVisualStyleBackColor = false;
            this.btn_RecipeFile_Save.Click += new System.EventHandler(this.btn_RecipeFile_Save_Click);
            // 
            // txt_Mode
            // 
            this.txt_Mode.BackColor = System.Drawing.Color.White;
            this.txt_Mode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Mode.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Mode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Mode.Location = new System.Drawing.Point(304, 9);
            this.txt_Mode.Name = "txt_Mode";
            this.txt_Mode.Size = new System.Drawing.Size(132, 30);
            this.txt_Mode.TabIndex = 58;
            this.txt_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1172, 824);
            this.Controls.Add(this.txt_Mode);
            this.Controls.Add(this.btn_RecipeFile_Save);
            this.Controls.Add(this.btn_RecipeFile_Edit);
            this.Controls.Add(this.btn_RecipeStep_Insert);
            this.Controls.Add(this.txt_RecipeFileName);
            this.Controls.Add(this.txt_Step);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_CurStep);
            this.Controls.Add(this.btn_RecipeFile_Cancel);
            this.Controls.Add(this.btn_RecipeFile_Copy);
            this.Controls.Add(this.btn_RecipeFile_Del);
            this.Controls.Add(this.btn_RecipeFile_New);
            this.Controls.Add(this.btn_RecipeStep_Del);
            this.Controls.Add(this.btn_RecipeStep_Add);
            this.Controls.Add(this.recipeGrid);
            this.Controls.Add(this.listBox_RecipeName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecipeForm";
            this.Text = "Recipe";
            this.Activated += new System.EventHandler(this.RecipeForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecipeForm_FormClosing);
            this.Load += new System.EventHandler(this.RecipeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recipeGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_RecipeName;
        private System.Windows.Forms.DataGridView recipeGrid;
        private System.Windows.Forms.Button btn_RecipeStep_Add;
        private System.Windows.Forms.Button btn_RecipeStep_Del;
        private System.Windows.Forms.Button btn_RecipeFile_Del;
        private System.Windows.Forms.Button btn_RecipeFile_New;
        private System.Windows.Forms.Button btn_RecipeFile_Copy;
        private System.Windows.Forms.Button btn_RecipeFile_Cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txt_CurStep;
        private System.Windows.Forms.Label txt_RecipeFileName;
        private System.Windows.Forms.Label txt_Step;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_RecipeStep_Insert;
        private System.Windows.Forms.Button btn_RecipeFile_Edit;
        private System.Windows.Forms.Button btn_RecipeFile_Save;
        private System.Windows.Forms.Label txt_Mode;
    }
}