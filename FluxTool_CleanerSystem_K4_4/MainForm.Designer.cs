
namespace FluxTool_CleanerSystem_K4_4
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timerDisplay = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.labelInterlockEnaDis = new System.Windows.Forms.Label();
            this.pictureBoxEventLog = new System.Windows.Forms.PictureBox();
            this.btnEventLog = new System.Windows.Forms.Button();
            this.pictureBoxAlarm = new System.Windows.Forms.PictureBox();
            this.pictureBoxAlarm2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxUserRegist = new System.Windows.Forms.PictureBox();
            this.btnUserRegist = new System.Windows.Forms.Button();
            this.laUserLevel = new System.Windows.Forms.Label();
            this.btnAlarm = new System.Windows.Forms.Button();
            this.labelPageName = new System.Windows.Forms.Label();
            this.laTime = new System.Windows.Forms.Label();
            this.laDate = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.pictureBoxToolHistory = new System.Windows.Forms.PictureBox();
            this.btnToolHistory = new System.Windows.Forms.Button();
            this.pictureBoxOperation = new System.Windows.Forms.PictureBox();
            this.btnOperation = new System.Windows.Forms.Button();
            this.pictureBoxExit = new System.Windows.Forms.PictureBox();
            this.pictureBoxIO = new System.Windows.Forms.PictureBox();
            this.pictureBoxConfigure = new System.Windows.Forms.PictureBox();
            this.pictureBoxRecipe = new System.Windows.Forms.PictureBox();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.btnMaintnance = new System.Windows.Forms.Button();
            this.btnConfigure = new System.Windows.Forms.Button();
            this.btnRecipe = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnIO = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnWaterTank = new System.Windows.Forms.Button();
            this.btnRightModule = new System.Windows.Forms.Button();
            this.btnCenterModule = new System.Windows.Forms.Button();
            this.btnLeftModule = new System.Windows.Forms.Button();
            this.panelOption = new System.Windows.Forms.Panel();
            this.checkBoxInterlockRelease = new System.Windows.Forms.CheckBox();
            this.simulationTimer = new System.Windows.Forms.Timer(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.HeaterInitTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEventLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlarm2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserRegist)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxToolHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConfigure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRecipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panelOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerDisplay
            // 
            this.timerDisplay.Interval = 500;
            this.timerDisplay.Tick += new System.EventHandler(this.timerDisplay_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 100);
            this.panel1.TabIndex = 31;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(275, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1005, 100);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.labelInterlockEnaDis);
            this.panel5.Controls.Add(this.pictureBoxEventLog);
            this.panel5.Controls.Add(this.btnEventLog);
            this.panel5.Controls.Add(this.pictureBoxAlarm);
            this.panel5.Controls.Add(this.pictureBoxAlarm2);
            this.panel5.Controls.Add(this.pictureBoxUserRegist);
            this.panel5.Controls.Add(this.btnUserRegist);
            this.panel5.Controls.Add(this.laUserLevel);
            this.panel5.Controls.Add(this.btnAlarm);
            this.panel5.Controls.Add(this.labelPageName);
            this.panel5.Controls.Add(this.laTime);
            this.panel5.Controls.Add(this.laDate);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1005, 100);
            this.panel5.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Lime;
            this.button1.Location = new System.Drawing.Point(296, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 50);
            this.button1.TabIndex = 161;
            this.button1.Text = "Buzzer\r\noff";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.pictureBoxAlarm_Click);
            // 
            // labelInterlockEnaDis
            // 
            this.labelInterlockEnaDis.AutoSize = true;
            this.labelInterlockEnaDis.BackColor = System.Drawing.Color.Transparent;
            this.labelInterlockEnaDis.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInterlockEnaDis.ForeColor = System.Drawing.Color.Yellow;
            this.labelInterlockEnaDis.Location = new System.Drawing.Point(53, 67);
            this.labelInterlockEnaDis.Name = "labelInterlockEnaDis";
            this.labelInterlockEnaDis.Size = new System.Drawing.Size(211, 32);
            this.labelInterlockEnaDis.TabIndex = 157;
            this.labelInterlockEnaDis.Text = "Interlock release!";
            this.labelInterlockEnaDis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelInterlockEnaDis.Visible = false;
            // 
            // pictureBoxEventLog
            // 
            this.pictureBoxEventLog.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEventLog.BackgroundImage = global::FluxTool_CleanerSystem_K4_4.Properties.Resources.log;
            this.pictureBoxEventLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxEventLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxEventLog.Location = new System.Drawing.Point(529, 29);
            this.pictureBoxEventLog.Name = "pictureBoxEventLog";
            this.pictureBoxEventLog.Size = new System.Drawing.Size(42, 42);
            this.pictureBoxEventLog.TabIndex = 156;
            this.pictureBoxEventLog.TabStop = false;
            this.pictureBoxEventLog.Click += new System.EventHandler(this.btnEventLog_Click);
            // 
            // btnEventLog
            // 
            this.btnEventLog.BackColor = System.Drawing.Color.Transparent;
            this.btnEventLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEventLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEventLog.FlatAppearance.BorderSize = 0;
            this.btnEventLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEventLog.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEventLog.ForeColor = System.Drawing.Color.White;
            this.btnEventLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEventLog.Location = new System.Drawing.Point(570, 29);
            this.btnEventLog.Name = "btnEventLog";
            this.btnEventLog.Size = new System.Drawing.Size(111, 42);
            this.btnEventLog.TabIndex = 155;
            this.btnEventLog.Text = "Event Log";
            this.btnEventLog.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnEventLog.UseVisualStyleBackColor = false;
            this.btnEventLog.Click += new System.EventHandler(this.btnEventLog_Click);
            // 
            // pictureBoxAlarm
            // 
            this.pictureBoxAlarm.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxAlarm.BackgroundImage = global::FluxTool_CleanerSystem_K4_4.Properties.Resources.Alarm1;
            this.pictureBoxAlarm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxAlarm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxAlarm.Location = new System.Drawing.Point(371, 29);
            this.pictureBoxAlarm.Name = "pictureBoxAlarm";
            this.pictureBoxAlarm.Size = new System.Drawing.Size(42, 42);
            this.pictureBoxAlarm.TabIndex = 150;
            this.pictureBoxAlarm.TabStop = false;
            this.pictureBoxAlarm.Click += new System.EventHandler(this.pictureBoxAlarm_Click);
            // 
            // pictureBoxAlarm2
            // 
            this.pictureBoxAlarm2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxAlarm2.BackgroundImage = global::FluxTool_CleanerSystem_K4_4.Properties.Resources.Alarm2;
            this.pictureBoxAlarm2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxAlarm2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxAlarm2.Location = new System.Drawing.Point(371, 29);
            this.pictureBoxAlarm2.Name = "pictureBoxAlarm2";
            this.pictureBoxAlarm2.Size = new System.Drawing.Size(42, 42);
            this.pictureBoxAlarm2.TabIndex = 154;
            this.pictureBoxAlarm2.TabStop = false;
            this.pictureBoxAlarm2.Click += new System.EventHandler(this.pictureBoxAlarm_Click);
            // 
            // pictureBoxUserRegist
            // 
            this.pictureBoxUserRegist.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxUserRegist.BackgroundImage = global::FluxTool_CleanerSystem_K4_4.Properties.Resources.register;
            this.pictureBoxUserRegist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxUserRegist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxUserRegist.Location = new System.Drawing.Point(687, 29);
            this.pictureBoxUserRegist.Name = "pictureBoxUserRegist";
            this.pictureBoxUserRegist.Size = new System.Drawing.Size(42, 42);
            this.pictureBoxUserRegist.TabIndex = 153;
            this.pictureBoxUserRegist.TabStop = false;
            this.pictureBoxUserRegist.Click += new System.EventHandler(this.btnUserRegist_Click);
            // 
            // btnUserRegist
            // 
            this.btnUserRegist.BackColor = System.Drawing.Color.Transparent;
            this.btnUserRegist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUserRegist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserRegist.FlatAppearance.BorderSize = 0;
            this.btnUserRegist.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUserRegist.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserRegist.ForeColor = System.Drawing.Color.White;
            this.btnUserRegist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserRegist.Location = new System.Drawing.Point(728, 29);
            this.btnUserRegist.Name = "btnUserRegist";
            this.btnUserRegist.Size = new System.Drawing.Size(111, 42);
            this.btnUserRegist.TabIndex = 152;
            this.btnUserRegist.Text = "User regist";
            this.btnUserRegist.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnUserRegist.UseVisualStyleBackColor = false;
            this.btnUserRegist.Click += new System.EventHandler(this.btnUserRegist_Click);
            // 
            // laUserLevel
            // 
            this.laUserLevel.AutoSize = true;
            this.laUserLevel.BackColor = System.Drawing.Color.Transparent;
            this.laUserLevel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laUserLevel.ForeColor = System.Drawing.Color.Yellow;
            this.laUserLevel.Location = new System.Drawing.Point(890, 17);
            this.laUserLevel.Name = "laUserLevel";
            this.laUserLevel.Size = new System.Drawing.Size(17, 14);
            this.laUserLevel.TabIndex = 151;
            this.laUserLevel.Text = "--";
            // 
            // btnAlarm
            // 
            this.btnAlarm.BackColor = System.Drawing.Color.Transparent;
            this.btnAlarm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAlarm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlarm.FlatAppearance.BorderSize = 0;
            this.btnAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAlarm.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlarm.ForeColor = System.Drawing.Color.White;
            this.btnAlarm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlarm.Location = new System.Drawing.Point(412, 29);
            this.btnAlarm.Name = "btnAlarm";
            this.btnAlarm.Size = new System.Drawing.Size(111, 42);
            this.btnAlarm.TabIndex = 18;
            this.btnAlarm.Text = "Alarm";
            this.btnAlarm.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAlarm.UseVisualStyleBackColor = false;
            this.btnAlarm.Click += new System.EventHandler(this.btnAlarm_Click);
            // 
            // labelPageName
            // 
            this.labelPageName.AutoSize = true;
            this.labelPageName.BackColor = System.Drawing.Color.Transparent;
            this.labelPageName.Font = new System.Drawing.Font("Nirmala UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPageName.ForeColor = System.Drawing.Color.White;
            this.labelPageName.Location = new System.Drawing.Point(20, 16);
            this.labelPageName.Name = "labelPageName";
            this.labelPageName.Size = new System.Drawing.Size(55, 54);
            this.labelPageName.TabIndex = 149;
            this.labelPageName.Text = "--";
            this.labelPageName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // laTime
            // 
            this.laTime.AutoSize = true;
            this.laTime.BackColor = System.Drawing.Color.Transparent;
            this.laTime.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laTime.ForeColor = System.Drawing.SystemColors.Window;
            this.laTime.Location = new System.Drawing.Point(890, 57);
            this.laTime.Name = "laTime";
            this.laTime.Size = new System.Drawing.Size(63, 14);
            this.laTime.TabIndex = 148;
            this.laTime.Text = "00:00:00";
            // 
            // laDate
            // 
            this.laDate.AutoSize = true;
            this.laDate.BackColor = System.Drawing.Color.Transparent;
            this.laDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laDate.ForeColor = System.Drawing.SystemColors.Window;
            this.laDate.Location = new System.Drawing.Point(890, 37);
            this.laDate.Name = "laDate";
            this.laDate.Size = new System.Drawing.Size(79, 14);
            this.laDate.TabIndex = 147;
            this.laDate.Text = "0000.00.00";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelLogo);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(276, 100);
            this.panel2.TabIndex = 0;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(146)))), ((int)(((byte)(190)))));
            this.panelLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLogo.BackgroundImage")));
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(276, 100);
            this.panelLogo.TabIndex = 18;
            this.panelLogo.Click += new System.EventHandler(this.panelLogo_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 924);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1280, 100);
            this.panel9.TabIndex = 38;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel10.BackgroundImage")));
            this.panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel10.Controls.Add(this.pictureBoxToolHistory);
            this.panel10.Controls.Add(this.btnToolHistory);
            this.panel10.Controls.Add(this.pictureBoxOperation);
            this.panel10.Controls.Add(this.btnOperation);
            this.panel10.Controls.Add(this.pictureBoxExit);
            this.panel10.Controls.Add(this.pictureBoxIO);
            this.panel10.Controls.Add(this.pictureBoxConfigure);
            this.panel10.Controls.Add(this.pictureBoxRecipe);
            this.panel10.Controls.Add(this.pictureBoxMain);
            this.panel10.Controls.Add(this.btnMaintnance);
            this.panel10.Controls.Add(this.btnConfigure);
            this.panel10.Controls.Add(this.btnRecipe);
            this.panel10.Controls.Add(this.btnExit);
            this.panel10.Controls.Add(this.btnIO);
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1286, 106);
            this.panel10.TabIndex = 34;
            // 
            // pictureBoxToolHistory
            // 
            this.pictureBoxToolHistory.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxToolHistory.BackgroundImage = global::FluxTool_CleanerSystem_K4_4.Properties.Resources.History;
            this.pictureBoxToolHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxToolHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxToolHistory.Location = new System.Drawing.Point(866, 43);
            this.pictureBoxToolHistory.Name = "pictureBoxToolHistory";
            this.pictureBoxToolHistory.Size = new System.Drawing.Size(42, 42);
            this.pictureBoxToolHistory.TabIndex = 43;
            this.pictureBoxToolHistory.TabStop = false;
            this.pictureBoxToolHistory.Click += new System.EventHandler(this.btnToolHistory_Click);
            // 
            // btnToolHistory
            // 
            this.btnToolHistory.BackColor = System.Drawing.Color.Transparent;
            this.btnToolHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnToolHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToolHistory.FlatAppearance.BorderSize = 0;
            this.btnToolHistory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnToolHistory.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToolHistory.ForeColor = System.Drawing.Color.White;
            this.btnToolHistory.Location = new System.Drawing.Point(907, 43);
            this.btnToolHistory.Name = "btnToolHistory";
            this.btnToolHistory.Size = new System.Drawing.Size(100, 42);
            this.btnToolHistory.TabIndex = 42;
            this.btnToolHistory.Text = "Tool history";
            this.btnToolHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnToolHistory.UseVisualStyleBackColor = false;
            this.btnToolHistory.Click += new System.EventHandler(this.btnToolHistory_Click);
            // 
            // pictureBoxOperation
            // 
            this.pictureBoxOperation.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxOperation.BackgroundImage = global::FluxTool_CleanerSystem_K4_4.Properties.Resources.Operation;
            this.pictureBoxOperation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxOperation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxOperation.Location = new System.Drawing.Point(131, 43);
            this.pictureBoxOperation.Name = "pictureBoxOperation";
            this.pictureBoxOperation.Size = new System.Drawing.Size(42, 42);
            this.pictureBoxOperation.TabIndex = 41;
            this.pictureBoxOperation.TabStop = false;
            this.pictureBoxOperation.Click += new System.EventHandler(this.btnOperation_Click);
            // 
            // btnOperation
            // 
            this.btnOperation.BackColor = System.Drawing.Color.Transparent;
            this.btnOperation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOperation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOperation.FlatAppearance.BorderSize = 0;
            this.btnOperation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOperation.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOperation.ForeColor = System.Drawing.Color.White;
            this.btnOperation.Location = new System.Drawing.Point(172, 43);
            this.btnOperation.Name = "btnOperation";
            this.btnOperation.Size = new System.Drawing.Size(100, 42);
            this.btnOperation.TabIndex = 40;
            this.btnOperation.Text = "Operation";
            this.btnOperation.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnOperation.UseVisualStyleBackColor = false;
            this.btnOperation.Click += new System.EventHandler(this.btnOperation_Click);
            // 
            // pictureBoxExit
            // 
            this.pictureBoxExit.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxExit.BackgroundImage = global::FluxTool_CleanerSystem_K4_4.Properties.Resources.ExitButton;
            this.pictureBoxExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxExit.Location = new System.Drawing.Point(1013, 43);
            this.pictureBoxExit.Name = "pictureBoxExit";
            this.pictureBoxExit.Size = new System.Drawing.Size(42, 42);
            this.pictureBoxExit.TabIndex = 39;
            this.pictureBoxExit.TabStop = false;
            this.pictureBoxExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBoxIO
            // 
            this.pictureBoxIO.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxIO.BackgroundImage = global::FluxTool_CleanerSystem_K4_4.Properties.Resources.IOButton;
            this.pictureBoxIO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxIO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxIO.Location = new System.Drawing.Point(719, 43);
            this.pictureBoxIO.Name = "pictureBoxIO";
            this.pictureBoxIO.Size = new System.Drawing.Size(42, 42);
            this.pictureBoxIO.TabIndex = 38;
            this.pictureBoxIO.TabStop = false;
            this.pictureBoxIO.Click += new System.EventHandler(this.btnIO_Click);
            // 
            // pictureBoxConfigure
            // 
            this.pictureBoxConfigure.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxConfigure.BackgroundImage = global::FluxTool_CleanerSystem_K4_4.Properties.Resources.ConfigButton;
            this.pictureBoxConfigure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxConfigure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxConfigure.Location = new System.Drawing.Point(572, 43);
            this.pictureBoxConfigure.Name = "pictureBoxConfigure";
            this.pictureBoxConfigure.Size = new System.Drawing.Size(42, 42);
            this.pictureBoxConfigure.TabIndex = 37;
            this.pictureBoxConfigure.TabStop = false;
            this.pictureBoxConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
            // 
            // pictureBoxRecipe
            // 
            this.pictureBoxRecipe.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRecipe.BackgroundImage = global::FluxTool_CleanerSystem_K4_4.Properties.Resources.RecipeButton;
            this.pictureBoxRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxRecipe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxRecipe.Location = new System.Drawing.Point(425, 43);
            this.pictureBoxRecipe.Name = "pictureBoxRecipe";
            this.pictureBoxRecipe.Size = new System.Drawing.Size(42, 42);
            this.pictureBoxRecipe.TabIndex = 36;
            this.pictureBoxRecipe.TabStop = false;
            this.pictureBoxRecipe.Click += new System.EventHandler(this.btnRecipe_Click);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxMain.BackgroundImage = global::FluxTool_CleanerSystem_K4_4.Properties.Resources.Maint;
            this.pictureBoxMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMain.Location = new System.Drawing.Point(278, 43);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(42, 42);
            this.pictureBoxMain.TabIndex = 35;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // btnMaintnance
            // 
            this.btnMaintnance.BackColor = System.Drawing.Color.Transparent;
            this.btnMaintnance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMaintnance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaintnance.FlatAppearance.BorderSize = 0;
            this.btnMaintnance.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMaintnance.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaintnance.ForeColor = System.Drawing.Color.White;
            this.btnMaintnance.Location = new System.Drawing.Point(319, 43);
            this.btnMaintnance.Name = "btnMaintnance";
            this.btnMaintnance.Size = new System.Drawing.Size(100, 42);
            this.btnMaintnance.TabIndex = 33;
            this.btnMaintnance.Text = "Maintnance";
            this.btnMaintnance.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMaintnance.UseVisualStyleBackColor = false;
            this.btnMaintnance.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // btnConfigure
            // 
            this.btnConfigure.BackColor = System.Drawing.Color.Transparent;
            this.btnConfigure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnConfigure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfigure.FlatAppearance.BorderSize = 0;
            this.btnConfigure.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfigure.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigure.ForeColor = System.Drawing.Color.White;
            this.btnConfigure.Location = new System.Drawing.Point(613, 43);
            this.btnConfigure.Name = "btnConfigure";
            this.btnConfigure.Size = new System.Drawing.Size(100, 42);
            this.btnConfigure.TabIndex = 34;
            this.btnConfigure.Text = "Configure";
            this.btnConfigure.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnConfigure.UseVisualStyleBackColor = false;
            this.btnConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
            // 
            // btnRecipe
            // 
            this.btnRecipe.BackColor = System.Drawing.Color.Transparent;
            this.btnRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRecipe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecipe.FlatAppearance.BorderSize = 0;
            this.btnRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRecipe.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecipe.ForeColor = System.Drawing.Color.White;
            this.btnRecipe.Location = new System.Drawing.Point(466, 43);
            this.btnRecipe.Name = "btnRecipe";
            this.btnRecipe.Size = new System.Drawing.Size(100, 42);
            this.btnRecipe.TabIndex = 32;
            this.btnRecipe.Text = "Recipe";
            this.btnRecipe.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnRecipe.UseVisualStyleBackColor = false;
            this.btnRecipe.Click += new System.EventHandler(this.btnRecipe_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(1054, 43);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 42);
            this.btnExit.TabIndex = 31;
            this.btnExit.Text = "Exit";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnIO
            // 
            this.btnIO.BackColor = System.Drawing.Color.Transparent;
            this.btnIO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIO.FlatAppearance.BorderSize = 0;
            this.btnIO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIO.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIO.ForeColor = System.Drawing.Color.White;
            this.btnIO.Location = new System.Drawing.Point(760, 43);
            this.btnIO.Name = "btnIO";
            this.btnIO.Size = new System.Drawing.Size(100, 42);
            this.btnIO.TabIndex = 20;
            this.btnIO.Text = "In/Output";
            this.btnIO.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnIO.UseVisualStyleBackColor = false;
            this.btnIO.Click += new System.EventHandler(this.btnIO_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(1194, 100);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(86, 824);
            this.panel7.TabIndex = 40;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel8.BackgroundImage")));
            this.panel8.Controls.Add(this.btnWaterTank);
            this.panel8.Controls.Add(this.btnRightModule);
            this.panel8.Controls.Add(this.btnCenterModule);
            this.panel8.Controls.Add(this.btnLeftModule);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(86, 824);
            this.panel8.TabIndex = 41;
            // 
            // btnWaterTank
            // 
            this.btnWaterTank.BackColor = System.Drawing.Color.Transparent;
            this.btnWaterTank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWaterTank.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnWaterTank.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWaterTank.ForeColor = System.Drawing.Color.White;
            this.btnWaterTank.Location = new System.Drawing.Point(14, 447);
            this.btnWaterTank.Name = "btnWaterTank";
            this.btnWaterTank.Size = new System.Drawing.Size(69, 50);
            this.btnWaterTank.TabIndex = 9;
            this.btnWaterTank.Text = "WaterTank";
            this.btnWaterTank.UseVisualStyleBackColor = false;
            this.btnWaterTank.Click += new System.EventHandler(this.btnModule_Click);
            // 
            // btnRightModule
            // 
            this.btnRightModule.BackColor = System.Drawing.Color.Transparent;
            this.btnRightModule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRightModule.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRightModule.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightModule.ForeColor = System.Drawing.Color.White;
            this.btnRightModule.Location = new System.Drawing.Point(14, 391);
            this.btnRightModule.Name = "btnRightModule";
            this.btnRightModule.Size = new System.Drawing.Size(69, 50);
            this.btnRightModule.TabIndex = 8;
            this.btnRightModule.Text = "CH3";
            this.btnRightModule.UseVisualStyleBackColor = false;
            this.btnRightModule.Click += new System.EventHandler(this.btnModule_Click);
            // 
            // btnCenterModule
            // 
            this.btnCenterModule.BackColor = System.Drawing.Color.Transparent;
            this.btnCenterModule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCenterModule.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCenterModule.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCenterModule.ForeColor = System.Drawing.Color.White;
            this.btnCenterModule.Location = new System.Drawing.Point(14, 335);
            this.btnCenterModule.Name = "btnCenterModule";
            this.btnCenterModule.Size = new System.Drawing.Size(69, 50);
            this.btnCenterModule.TabIndex = 7;
            this.btnCenterModule.Text = "CH2";
            this.btnCenterModule.UseVisualStyleBackColor = false;
            this.btnCenterModule.Click += new System.EventHandler(this.btnModule_Click);
            // 
            // btnLeftModule
            // 
            this.btnLeftModule.BackColor = System.Drawing.Color.Transparent;
            this.btnLeftModule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeftModule.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLeftModule.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftModule.ForeColor = System.Drawing.Color.White;
            this.btnLeftModule.Location = new System.Drawing.Point(14, 279);
            this.btnLeftModule.Name = "btnLeftModule";
            this.btnLeftModule.Size = new System.Drawing.Size(69, 50);
            this.btnLeftModule.TabIndex = 6;
            this.btnLeftModule.Text = "CH1";
            this.btnLeftModule.UseVisualStyleBackColor = false;
            this.btnLeftModule.Click += new System.EventHandler(this.btnModule_Click);
            // 
            // panelOption
            // 
            this.panelOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelOption.Controls.Add(this.checkBoxInterlockRelease);
            this.panelOption.Location = new System.Drawing.Point(28, 106);
            this.panelOption.Name = "panelOption";
            this.panelOption.Size = new System.Drawing.Size(248, 102);
            this.panelOption.TabIndex = 154;
            this.panelOption.Visible = false;
            // 
            // checkBoxInterlockRelease
            // 
            this.checkBoxInterlockRelease.AutoSize = true;
            this.checkBoxInterlockRelease.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxInterlockRelease.ForeColor = System.Drawing.Color.Navy;
            this.checkBoxInterlockRelease.Location = new System.Drawing.Point(16, 19);
            this.checkBoxInterlockRelease.Name = "checkBoxInterlockRelease";
            this.checkBoxInterlockRelease.Size = new System.Drawing.Size(155, 25);
            this.checkBoxInterlockRelease.TabIndex = 0;
            this.checkBoxInterlockRelease.Text = "Interlock release";
            this.checkBoxInterlockRelease.UseVisualStyleBackColor = true;
            this.checkBoxInterlockRelease.Click += new System.EventHandler(this.checkBoxInterlockRelease_Click);
            // 
            // panel6
            // 
            this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 100);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(22, 824);
            this.panel6.TabIndex = 39;
            // 
            // HeaterInitTimer
            // 
            this.HeaterInitTimer.Interval = 5000;
            this.HeaterInitTimer.Tick += new System.EventHandler(this.HeaterInitTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1280, 1024);
            this.Controls.Add(this.panelOption);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Fluxtool cleaning system";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEventLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlarm2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserRegist)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxToolHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConfigure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRecipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panelOption.ResumeLayout(false);
            this.panelOption.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerDisplay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBoxAlarm;
        private System.Windows.Forms.Button btnAlarm;
        public System.Windows.Forms.Label labelPageName;
        private System.Windows.Forms.Label laTime;
        private System.Windows.Forms.Label laDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.PictureBox pictureBoxOperation;
        private System.Windows.Forms.PictureBox pictureBoxExit;
        private System.Windows.Forms.PictureBox pictureBoxIO;
        private System.Windows.Forms.PictureBox pictureBoxConfigure;
        private System.Windows.Forms.PictureBox pictureBoxRecipe;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.Button btnMaintnance;
        private System.Windows.Forms.Button btnConfigure;
        private System.Windows.Forms.Button btnRecipe;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnIO;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label laUserLevel;
        private System.Windows.Forms.PictureBox pictureBoxUserRegist;
        private System.Windows.Forms.Button btnUserRegist;
        public System.Windows.Forms.Button btnRightModule;
        public System.Windows.Forms.Button btnCenterModule;
        public System.Windows.Forms.Button btnLeftModule;
        private System.Windows.Forms.Button btnOperation;
        public System.Windows.Forms.Button btnWaterTank;
        private System.Windows.Forms.Panel panelOption;
        private System.Windows.Forms.CheckBox checkBoxInterlockRelease;
        private System.Windows.Forms.PictureBox pictureBoxAlarm2;
        private System.Windows.Forms.PictureBox pictureBoxEventLog;
        private System.Windows.Forms.Button btnEventLog;
        private System.Windows.Forms.Timer simulationTimer;
        public System.Windows.Forms.Label labelInterlockEnaDis;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBoxToolHistory;
        private System.Windows.Forms.Button btnToolHistory;
        private System.Windows.Forms.Timer HeaterInitTimer;
    }
}