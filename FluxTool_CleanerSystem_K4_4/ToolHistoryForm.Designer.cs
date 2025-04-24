
namespace FluxTool_CleanerSystem_K4_4
{
    partial class ToolHistoryForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this._clearButton = new System.Windows.Forms.Button();
            this.labelToolCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._filterTextBox = new System.Windows.Forms.TextBox();
            this._excelDownloadButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._monthCalendar = new System.Windows.Forms.MonthCalendar();
            this._listBox = new System.Windows.Forms.ListBox();
            this._searchButton = new System.Windows.Forms.Button();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MintCream;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._clearButton);
            this.panel1.Controls.Add(this.labelToolCount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this._filterTextBox);
            this.panel1.Controls.Add(this._excelDownloadButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._monthCalendar);
            this.panel1.Controls.Add(this._listBox);
            this.panel1.Controls.Add(this._searchButton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1148, 624);
            this.panel1.TabIndex = 8;
            // 
            // _clearButton
            // 
            this._clearButton.BackColor = System.Drawing.Color.MistyRose;
            this._clearButton.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._clearButton.Location = new System.Drawing.Point(242, 137);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(100, 60);
            this._clearButton.TabIndex = 11;
            this._clearButton.Text = "List clear";
            this._clearButton.UseVisualStyleBackColor = false;
            this._clearButton.Click += new System.EventHandler(this._clearButton_Click);
            // 
            // labelToolCount
            // 
            this.labelToolCount.AutoSize = true;
            this.labelToolCount.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelToolCount.ForeColor = System.Drawing.Color.Blue;
            this.labelToolCount.Location = new System.Drawing.Point(352, 10);
            this.labelToolCount.Name = "labelToolCount";
            this.labelToolCount.Size = new System.Drawing.Size(139, 20);
            this.labelToolCount.TabIndex = 10;
            this.labelToolCount.Text = "Cleaned tools : 0개";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(900, 599);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "(필터링 후 다른 파일을 보려면 재검색)";
            // 
            // _filterTextBox
            // 
            this._filterTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this._filterTextBox.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._filterTextBox.Location = new System.Drawing.Point(447, 583);
            this._filterTextBox.Name = "_filterTextBox";
            this._filterTextBox.Size = new System.Drawing.Size(447, 33);
            this._filterTextBox.TabIndex = 8;
            this._filterTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._filterTextBox.TextChanged += new System.EventHandler(this._filterTextBox_TextChanged);
            // 
            // _excelDownloadButton
            // 
            this._excelDownloadButton.BackColor = System.Drawing.Color.Aquamarine;
            this._excelDownloadButton.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._excelDownloadButton.Location = new System.Drawing.Point(322, 937);
            this._excelDownloadButton.Name = "_excelDownloadButton";
            this._excelDownloadButton.Size = new System.Drawing.Size(130, 60);
            this._excelDownloadButton.TabIndex = 7;
            this._excelDownloadButton.Text = "Excel 파일\r\n다운로드";
            this._excelDownloadButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Plum;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _monthCalendar
            // 
            this._monthCalendar.Location = new System.Drawing.Point(10, 35);
            this._monthCalendar.Name = "_monthCalendar";
            this._monthCalendar.TabIndex = 0;
            // 
            // _listBox
            // 
            this._listBox.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._listBox.FormattingEnabled = true;
            this._listBox.ItemHeight = 16;
            this._listBox.Location = new System.Drawing.Point(356, 35);
            this._listBox.Name = "_listBox";
            this._listBox.Size = new System.Drawing.Size(777, 532);
            this._listBox.TabIndex = 3;
            this._listBox.SelectedIndexChanged += new System.EventHandler(this._listBox_SelectedIndexChanged);
            // 
            // _searchButton
            // 
            this._searchButton.BackColor = System.Drawing.Color.PaleGreen;
            this._searchButton.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._searchButton.Location = new System.Drawing.Point(242, 71);
            this._searchButton.Name = "_searchButton";
            this._searchButton.Size = new System.Drawing.Size(100, 60);
            this._searchButton.TabIndex = 2;
            this._searchButton.Text = "Search";
            this._searchButton.UseVisualStyleBackColor = false;
            this._searchButton.Click += new System.EventHandler(this._searchButton_Click);
            // 
            // _dataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dataGridView.BackgroundColor = System.Drawing.Color.White;
            this._dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this._dataGridView.Location = new System.Drawing.Point(12, 642);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this._dataGridView.RowHeadersWidth = 30;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this._dataGridView.RowTemplate.Height = 23;
            this._dataGridView.Size = new System.Drawing.Size(1148, 170);
            this._dataGridView.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(351, 586);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "keyword";
            // 
            // ToolHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1172, 824);
            this.Controls.Add(this._dataGridView);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "ToolHistoryForm";
            this.Text = "Configure";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ToolHistoryForm_FormClosing);
            this.Load += new System.EventHandler(this.ToolHistoryForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _clearButton;
        private System.Windows.Forms.Label labelToolCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _filterTextBox;
        private System.Windows.Forms.Button _excelDownloadButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar _monthCalendar;
        private System.Windows.Forms.ListBox _listBox;
        private System.Windows.Forms.Button _searchButton;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.Label label2;
    }
}