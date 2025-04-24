
namespace FluxTool_CleanerSystem_K4_4
{
    partial class WaterTankForm
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRetry = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.listBoxEventLog = new System.Windows.Forms.ListBox();
            this.label35 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label_Alarm = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnHeaterOn = new System.Windows.Forms.Button();
            this.btnHeaterOff = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSettingTemp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCurrentTemp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.WaterLevelHighSns = new System.Windows.Forms.Label();
            this.WaterLevelLowSns = new System.Windows.Forms.Label();
            this.Water_Tank = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxWaterSupply = new System.Windows.Forms.TextBox();
            this.textBoxWaterHeater = new System.Windows.Forms.TextBox();
            this.textBoxWaterPump = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Water_Tank.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.btnRetry);
            this.panel2.Controls.Add(this.btnAbort);
            this.panel2.Controls.Add(this.btnProcess);
            this.panel2.Location = new System.Drawing.Point(1036, 654);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 160);
            this.panel2.TabIndex = 142;
            this.panel2.Visible = false;
            // 
            // btnRetry
            // 
            this.btnRetry.BackColor = System.Drawing.Color.White;
            this.btnRetry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRetry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetry.FlatAppearance.BorderSize = 0;
            this.btnRetry.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRetry.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetry.ForeColor = System.Drawing.Color.Navy;
            this.btnRetry.Location = new System.Drawing.Point(4, 54);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(112, 42);
            this.btnRetry.TabIndex = 28;
            this.btnRetry.Tag = "";
            this.btnRetry.Text = "Retry";
            this.btnRetry.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnRetry.UseVisualStyleBackColor = false;
            this.btnRetry.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.BackColor = System.Drawing.Color.White;
            this.btnAbort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAbort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbort.FlatAppearance.BorderSize = 0;
            this.btnAbort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAbort.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbort.ForeColor = System.Drawing.Color.Navy;
            this.btnAbort.Location = new System.Drawing.Point(4, 102);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(112, 42);
            this.btnAbort.TabIndex = 26;
            this.btnAbort.Text = "Stop";
            this.btnAbort.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAbort.UseVisualStyleBackColor = false;
            this.btnAbort.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.Color.Transparent;
            this.btnProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcess.FlatAppearance.BorderSize = 0;
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProcess.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.ForeColor = System.Drawing.Color.Navy;
            this.btnProcess.Location = new System.Drawing.Point(4, 6);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(112, 42);
            this.btnProcess.TabIndex = 23;
            this.btnProcess.Tag = "";
            this.btnProcess.Text = "Start";
            this.btnProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // listBoxEventLog
            // 
            this.listBoxEventLog.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxEventLog.FormattingEnabled = true;
            this.listBoxEventLog.ItemHeight = 17;
            this.listBoxEventLog.Location = new System.Drawing.Point(12, 759);
            this.listBoxEventLog.Name = "listBoxEventLog";
            this.listBoxEventLog.Size = new System.Drawing.Size(1018, 55);
            this.listBoxEventLog.TabIndex = 147;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("Nirmala UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.Navy;
            this.label35.Location = new System.Drawing.Point(467, 15);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(204, 47);
            this.label35.TabIndex = 272;
            this.label35.Text = "Water tank";
            // 
            // label_Alarm
            // 
            this.label_Alarm.AutoSize = true;
            this.label_Alarm.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Alarm.ForeColor = System.Drawing.Color.Red;
            this.label_Alarm.Location = new System.Drawing.Point(350, 55);
            this.label_Alarm.Name = "label_Alarm";
            this.label_Alarm.Size = new System.Drawing.Size(34, 32);
            this.label_Alarm.TabIndex = 331;
            this.label_Alarm.Text = "--";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnHeaterOn);
            this.groupBox3.Controls.Add(this.btnHeaterOff);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBoxSettingTemp);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBoxCurrentTemp);
            this.groupBox3.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Red;
            this.groupBox3.Location = new System.Drawing.Point(970, 300);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(172, 153);
            this.groupBox3.TabIndex = 270;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Temp";
            // 
            // btnHeaterOn
            // 
            this.btnHeaterOn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHeaterOn.ForeColor = System.Drawing.Color.Navy;
            this.btnHeaterOn.Location = new System.Drawing.Point(89, 121);
            this.btnHeaterOn.Name = "btnHeaterOn";
            this.btnHeaterOn.Size = new System.Drawing.Size(70, 25);
            this.btnHeaterOn.TabIndex = 270;
            this.btnHeaterOn.Text = "ON";
            this.btnHeaterOn.UseVisualStyleBackColor = true;
            this.btnHeaterOn.Click += new System.EventHandler(this.Digital_Click);
            // 
            // btnHeaterOff
            // 
            this.btnHeaterOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHeaterOff.ForeColor = System.Drawing.Color.Red;
            this.btnHeaterOff.Location = new System.Drawing.Point(13, 121);
            this.btnHeaterOff.Name = "btnHeaterOff";
            this.btnHeaterOff.Size = new System.Drawing.Size(70, 25);
            this.btnHeaterOff.TabIndex = 269;
            this.btnHeaterOff.Text = "OFF";
            this.btnHeaterOff.UseVisualStyleBackColor = true;
            this.btnHeaterOff.Click += new System.EventHandler(this.Digital_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(144, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 17);
            this.label6.TabIndex = 268;
            this.label6.Text = "C";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(144, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 17);
            this.label5.TabIndex = 267;
            this.label5.Text = "C";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 266;
            this.label4.Text = "Setting";
            // 
            // textBoxSettingTemp
            // 
            this.textBoxSettingTemp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBoxSettingTemp.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSettingTemp.Location = new System.Drawing.Point(66, 54);
            this.textBoxSettingTemp.Name = "textBoxSettingTemp";
            this.textBoxSettingTemp.ReadOnly = true;
            this.textBoxSettingTemp.Size = new System.Drawing.Size(72, 27);
            this.textBoxSettingTemp.TabIndex = 265;
            this.textBoxSettingTemp.TabStop = false;
            this.textBoxSettingTemp.Tag = "1";
            this.textBoxSettingTemp.Text = "0";
            this.textBoxSettingTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSettingTemp.Click += new System.EventHandler(this.Analog_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 264;
            this.label3.Text = "Current";
            // 
            // textBoxCurrentTemp
            // 
            this.textBoxCurrentTemp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxCurrentTemp.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxCurrentTemp.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCurrentTemp.Location = new System.Drawing.Point(66, 22);
            this.textBoxCurrentTemp.Name = "textBoxCurrentTemp";
            this.textBoxCurrentTemp.ReadOnly = true;
            this.textBoxCurrentTemp.Size = new System.Drawing.Size(72, 27);
            this.textBoxCurrentTemp.TabIndex = 263;
            this.textBoxCurrentTemp.TabStop = false;
            this.textBoxCurrentTemp.Tag = "0";
            this.textBoxCurrentTemp.Text = "0";
            this.textBoxCurrentTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(25, 583);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 274;
            this.label2.Text = "Level low";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(25, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 273;
            this.label1.Text = "Level high";
            // 
            // WaterLevelHighSns
            // 
            this.WaterLevelHighSns.BackColor = System.Drawing.Color.Silver;
            this.WaterLevelHighSns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WaterLevelHighSns.Location = new System.Drawing.Point(110, 169);
            this.WaterLevelHighSns.Name = "WaterLevelHighSns";
            this.WaterLevelHighSns.Size = new System.Drawing.Size(25, 25);
            this.WaterLevelHighSns.TabIndex = 272;
            // 
            // WaterLevelLowSns
            // 
            this.WaterLevelLowSns.BackColor = System.Drawing.Color.Silver;
            this.WaterLevelLowSns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WaterLevelLowSns.Location = new System.Drawing.Point(110, 581);
            this.WaterLevelLowSns.Name = "WaterLevelLowSns";
            this.WaterLevelLowSns.Size = new System.Drawing.Size(25, 25);
            this.WaterLevelLowSns.TabIndex = 271;
            // 
            // Water_Tank
            // 
            this.Water_Tank.BackColor = System.Drawing.Color.Transparent;
            this.Water_Tank.BackgroundImage = global::FluxTool_CleanerSystem_K4_4.Properties.Resources.WaterTank;
            this.Water_Tank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Water_Tank.Controls.Add(this.groupBox2);
            this.Water_Tank.Controls.Add(this.panel1);
            this.Water_Tank.Location = new System.Drawing.Point(12, 35);
            this.Water_Tank.Name = "Water_Tank";
            this.Water_Tank.Size = new System.Drawing.Size(1144, 718);
            this.Water_Tank.TabIndex = 148;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxWaterSupply);
            this.groupBox2.Controls.Add(this.textBoxWaterHeater);
            this.groupBox2.Controls.Add(this.textBoxWaterPump);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(909, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(221, 138);
            this.groupBox2.TabIndex = 332;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Main [Hot]";
            // 
            // textBoxWaterSupply
            // 
            this.textBoxWaterSupply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBoxWaterSupply.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWaterSupply.Location = new System.Drawing.Point(109, 86);
            this.textBoxWaterSupply.Name = "textBoxWaterSupply";
            this.textBoxWaterSupply.ReadOnly = true;
            this.textBoxWaterSupply.Size = new System.Drawing.Size(100, 27);
            this.textBoxWaterSupply.TabIndex = 272;
            this.textBoxWaterSupply.TabStop = false;
            this.textBoxWaterSupply.Tag = "26";
            this.textBoxWaterSupply.Text = "--";
            this.textBoxWaterSupply.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxWaterSupply.Click += new System.EventHandler(this.Digital_Click2);
            // 
            // textBoxWaterHeater
            // 
            this.textBoxWaterHeater.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBoxWaterHeater.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWaterHeater.Location = new System.Drawing.Point(109, 54);
            this.textBoxWaterHeater.Name = "textBoxWaterHeater";
            this.textBoxWaterHeater.ReadOnly = true;
            this.textBoxWaterHeater.Size = new System.Drawing.Size(100, 27);
            this.textBoxWaterHeater.TabIndex = 270;
            this.textBoxWaterHeater.TabStop = false;
            this.textBoxWaterHeater.Tag = "25";
            this.textBoxWaterHeater.Text = "--";
            this.textBoxWaterHeater.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxWaterHeater.Click += new System.EventHandler(this.Digital_Click2);
            // 
            // textBoxWaterPump
            // 
            this.textBoxWaterPump.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBoxWaterPump.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWaterPump.Location = new System.Drawing.Point(109, 22);
            this.textBoxWaterPump.Name = "textBoxWaterPump";
            this.textBoxWaterPump.ReadOnly = true;
            this.textBoxWaterPump.Size = new System.Drawing.Size(100, 27);
            this.textBoxWaterPump.TabIndex = 268;
            this.textBoxWaterPump.TabStop = false;
            this.textBoxWaterPump.Tag = "24";
            this.textBoxWaterPump.Text = "--";
            this.textBoxWaterPump.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxWaterPump.Click += new System.EventHandler(this.Digital_Click2);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 17);
            this.label9.TabIndex = 273;
            this.label9.Text = "Water supply";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 17);
            this.label8.TabIndex = 271;
            this.label8.Text = "Water heater";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 17);
            this.label7.TabIndex = 269;
            this.label7.Text = "Water pump";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::FluxTool_CleanerSystem_K4_4.Properties.Resources.WaterFill;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(144, 179);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 441);
            this.panel1.TabIndex = 332;
            // 
            // WaterTankForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label_Alarm);
            this.Controls.Add(this.WaterLevelLowSns);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.WaterLevelHighSns);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxEventLog);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Water_Tank);
            this.Name = "WaterTankForm";
            this.Size = new System.Drawing.Size(1172, 824);
            this.Load += new System.EventHandler(this.WaterTankForm_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.Water_Tank.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ListBox listBoxEventLog;
        private System.Windows.Forms.Panel Water_Tank;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSettingTemp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCurrentTemp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnHeaterOn;
        private System.Windows.Forms.Button btnHeaterOff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label WaterLevelHighSns;
        private System.Windows.Forms.Label WaterLevelLowSns;
        public System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.Label label_Alarm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxWaterSupply;
        private System.Windows.Forms.TextBox textBoxWaterHeater;
        private System.Windows.Forms.TextBox textBoxWaterPump;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}
