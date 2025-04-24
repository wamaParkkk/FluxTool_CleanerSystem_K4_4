using HanyoungNXClassLibrary;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace FluxTool_CleanerSystem_K4_4
{
    public partial class WaterTankForm : UserControl
    {
        private MaintnanceForm m_Parent;
        int module;
        string ModuleName;

        AnalogDlg analogDlg;
        DigitalDlg digitalDlg;        

        private Timer logdisplayTimer = new Timer();

        public WaterTankForm(MaintnanceForm parent)
        {
            m_Parent = parent;

            InitializeComponent();

            module = (int)MODULE._WATERTANK;
            ModuleName = "WATERTANK";
        }

        private void WaterTankForm_Load(object sender, EventArgs e)
        {
            Width = 1172;
            Height = 824;
            Top = 0;
            Left = 0;

            logdisplayTimer.Interval = 500;
            logdisplayTimer.Elapsed += new ElapsedEventHandler(Eventlog_Display);
            logdisplayTimer.Start();            
        }

        private void SetDoubleBuffered(Control control, bool doubleBuffered = true)
        {
            PropertyInfo propertyInfo = typeof(Control).GetProperty
            (
                "DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic
            );
            propertyInfo.SetValue(control, doubleBuffered, null);
        }

        public void Display()
        {
            SetDoubleBuffered(Water_Tank);

            if (Define.seqMode[module] == Define.MODE_PROCESS)
            {
                if (Define.seqCtrl[module] != Define.CTRL_IDLE)
                {
                    if (btnProcess.Enabled != false)
                        btnProcess.Enabled = false;

                    if (Define.seqCtrl[module] == Define.CTRL_ALARM)
                    {
                        if (btnProcess.BackColor != Color.Red)
                            btnProcess.BackColor = Color.Red;
                        else
                            btnProcess.BackColor = Color.Transparent;

                        if (!btnRetry.Enabled)
                            btnRetry.Enabled = true;
                    }
                    else
                    {
                        if (btnProcess.BackColor != Color.YellowGreen)
                            btnProcess.BackColor = Color.YellowGreen;
                        else
                            btnProcess.BackColor = Color.Transparent;

                        if (label_Alarm.Text != "--")
                            label_Alarm.Text = "--";

                        if (btnRetry.Enabled != false)
                            btnRetry.Enabled = false;
                    }

                    if (!btnAbort.Enabled)
                        btnAbort.Enabled = true;                    
                }
            }
            else if (Define.seqMode[module] == Define.MODE_IDLE)
            {
                if (!btnProcess.Enabled)
                    btnProcess.Enabled = true;

                if (btnProcess.BackColor != Color.Transparent)
                    btnProcess.BackColor = Color.Transparent;

                if (btnRetry.Enabled != false)
                    btnRetry.Enabled = false;

                if (btnAbort.Enabled != false)
                    btnAbort.Enabled = false;

                if (label_Alarm.Text != "--")
                    label_Alarm.Text = "--";                
            }


            // Input display
            if (Global.GetDigValue((int)DigInputList.Water_Level_High_i) == "Off")
            {
                if (WaterLevelHighSns.BackColor != Color.Silver)
                    WaterLevelHighSns.BackColor = Color.Silver;
            }
            else
            {
                if (WaterLevelHighSns.BackColor != Color.Lime)
                    WaterLevelHighSns.BackColor = Color.Lime;
            }

            if (Global.GetDigValue((int)DigInputList.Water_Level_Low_i) == "On")
            {
                if (WaterLevelLowSns.BackColor != Color.Silver)
                    WaterLevelLowSns.BackColor = Color.Silver;
            }
            else
            {
                if (WaterLevelLowSns.BackColor != Color.Lime)
                    WaterLevelLowSns.BackColor = Color.Lime;
            }

            textBoxCurrentTemp.Text = HanyoungNXClassLibrary.Define.temp_PV.ToString("0.0");
            textBoxSettingTemp.Text = HanyoungNXClassLibrary.Define.temp_SV.ToString("0.0");


            // Output display
            if (Global.digSet.curDigSet[(int)DigOutputList.Hot_Water_Pump_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.Hot_Water_Pump_o] == "On")
                {
                    textBoxWaterPump.Text = "On";
                    textBoxWaterPump.BackColor = Color.LightSkyBlue;
                }
                else
                {
                    textBoxWaterPump.Text = "Off";
                    textBoxWaterPump.BackColor = Color.WhiteSmoke;
                }
            }

            if (Global.digSet.curDigSet[(int)DigOutputList.Hot_WaterHeater_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.Hot_WaterHeater_o] == "On")
                {
                    textBoxWaterHeater.Text = "On";
                    textBoxWaterHeater.BackColor = Color.LightSkyBlue;
                }
                else
                {
                    textBoxWaterHeater.Text = "Off";
                    textBoxWaterHeater.BackColor = Color.WhiteSmoke;
                }
            }

            if (Global.digSet.curDigSet[(int)DigOutputList.Main_Water_Supply] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.Main_Water_Supply] == "On")
                {
                    textBoxWaterSupply.Text = "Open";
                    textBoxWaterSupply.BackColor = Color.LightSkyBlue;
                }
                else
                {
                    textBoxWaterSupply.Text = "Close";
                    textBoxWaterSupply.BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void Eventlog_Display(object sender, ElapsedEventArgs e)
        {
            if (Define.bWaterTankEvent)
            {
                Eventlog_File_Read();
            }

            if (Define.bWaterTankAlmEvent)
            {
                Alarmlog_File_Read();
            }
        }

        private void Eventlog_File_Read()
        {
            Define.bWaterTankEvent = false;

            try
            {
                string sTmpData;

                string sYear = string.Format("{0:yyyy}", DateTime.Now).Trim();
                string sMonth = string.Format("{0:MM}", DateTime.Now).Trim();
                string sDay = string.Format("{0:dd}", DateTime.Now).Trim();
                string FileName = sDay + ".txt";

                if (File.Exists(Global.logfilePath + ModuleName + "\\" + sYear + "\\" + sMonth + "\\" + FileName))
                {
                    byte[] bytes;
                    using (var fs = File.Open(Global.logfilePath + ModuleName + "\\" + sYear + "\\" + sMonth + "\\" + FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        try
                        {
                            bytes = new byte[fs.Length];
                            fs.Read(bytes, 0, (int)fs.Length);
                            sTmpData = Encoding.Default.GetString(bytes);

                            string[] data = sTmpData.Split('\n');
                            int iLength = data.Length;
                            if (iLength >= 2)
                            {
                                string sVal = data[iLength - 2].ToString();

                                Invoke((Action)(() =>
                                {
                                    listBoxEventLog.Update();

                                    if (listBoxEventLog.Items.Count >= 10)
                                        listBoxEventLog.Items.Clear();

                                    listBoxEventLog.Items.Add(sVal);
                                    listBoxEventLog.SelectedIndex = listBoxEventLog.Items.Count - 1;
                                }));
                            }
                        }
                        catch (ArgumentException)
                        {

                        }
                    }
                }
            }
            catch (IOException)
            {

            }
        }

        private void Alarmlog_File_Read()
        {
            Define.bWaterTankAlmEvent = false;

            try
            {
                string sTmpData;

                string sYear = string.Format("{0:yyyy}", DateTime.Now).Trim();
                string sMonth = string.Format("{0:MM}", DateTime.Now).Trim();
                string sDay = string.Format("{0:dd}", DateTime.Now).Trim();
                string FileName = sDay + ".txt";

                if (File.Exists(Global.alarmHistoryPath + ModuleName + "\\" + sYear + "\\" + sMonth + "\\" + FileName))
                {
                    byte[] bytes;
                    using (var fs = File.Open(Global.alarmHistoryPath + ModuleName + "\\" + sYear + "\\" + sMonth + "\\" + FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        try
                        {
                            bytes = new byte[fs.Length];
                            fs.Read(bytes, 0, (int)fs.Length);
                            sTmpData = Encoding.Default.GetString(bytes);

                            string[] data = sTmpData.Split('\n');
                            int iLength = data.Length;
                            if (iLength >= 2)
                            {
                                string sVal = data[iLength - 2].ToString();

                                Invoke((Action)(() =>
                                {
                                    label_Alarm.Text = sVal;
                                }));
                            }
                        }
                        catch (ArgumentException)
                        {

                        }
                    }
                }
            }
            catch (IOException)
            {

            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string strTmp = btn.Text.ToString();
            switch (strTmp)
            {
                case "Start":
                    {
                        if (MessageBox.Show("Do you want to proceed with water refilling and heating?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Define.seqMode[module] = Define.MODE_PROCESS;
                            Define.seqCtrl[module] = Define.CTRL_RUN;
                            Define.seqSts[module] = Define.STS_IDLE;
                        }
                    }
                    break;

                case "Retry":
                    {
                        Define.seqCtrl[module] = Define.CTRL_RETRY;
                    }
                    break;

                case "Stop":
                    {
                        if (MessageBox.Show("Do you want to stop refilling water and heating?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Define.seqCtrl[module] = Define.CTRL_ABORT;
                        }
                    }
                    break;
            }
        }

        private void Analog_Click(object sender, EventArgs e)
        {
            /*
            if ((Define.seqCtrl[(byte)MODULE._PM1] != Define.CTRL_IDLE) ||
                (Define.seqCylinderCtrl[(byte)MODULE._PM1] != Define.CTRL_IDLE) ||

                (Define.seqCtrl[(byte)MODULE._PM2] != Define.CTRL_IDLE) ||
                (Define.seqCylinderCtrl[(byte)MODULE._PM2] != Define.CTRL_IDLE) ||

                (Define.seqCtrl[(byte)MODULE._PM3] != Define.CTRL_IDLE) ||
                (Define.seqCylinderCtrl[(byte)MODULE._PM3] != Define.CTRL_IDLE) ||

                (Define.seqCtrl[(byte)MODULE._WATERTANK] != Define.CTRL_IDLE))
            {
                MessageBox.Show("CH1/CH2/CH3/Water tank process in progress", "Notification");
                return;
            }
            */

            try
            {
                analogDlg = new AnalogDlg();
                analogDlg.Text = "";                

                if (analogDlg.ShowDialog() == DialogResult.OK)
                {
                    string strVal = analogDlg.m_strResult;
                    bool bResult = double.TryParse(strVal, out double dVal);
                    if (bResult)
                    {
                        HanyoungNXClass.set_Temp(dVal);
                        HanyoungNXClassLibrary.Define.temp_SV = dVal;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Digital_Click(object sender, EventArgs e)
        {
            /*
            if ((Define.seqCtrl[(byte)MODULE._PM1] != Define.CTRL_IDLE) ||
                (Define.seqCylinderCtrl[(byte)MODULE._PM1] != Define.CTRL_IDLE) ||

                (Define.seqCtrl[(byte)MODULE._PM2] != Define.CTRL_IDLE) ||
                (Define.seqCylinderCtrl[(byte)MODULE._PM2] != Define.CTRL_IDLE) ||

                (Define.seqCtrl[(byte)MODULE._PM3] != Define.CTRL_IDLE) ||
                (Define.seqCylinderCtrl[(byte)MODULE._PM3] != Define.CTRL_IDLE) ||

                (Define.seqCtrl[(byte)MODULE._WATERTANK] != Define.CTRL_IDLE))
            {
                MessageBox.Show("CH1/CH2/CH3/Water tank process in progress", "Notification");
                return;
            }
            */

            Button btn = (Button)sender;

            string strTmp = btn.Text.ToString();
            switch (strTmp)
            {
                case "OFF":
                    {
                        Global.SetDigValue((int)DigOutputList.Hot_WaterHeater_o, (uint)DigitalOffOn.Off, ModuleName);                        
                    }
                    break;

                case "ON":
                    {
                        Global.SetDigValue((int)DigOutputList.Hot_WaterHeater_o, (uint)DigitalOffOn.On, ModuleName);                        
                    }
                    break;
            }
        }

        private void Digital_Click2(object sender, EventArgs e)
        {
            /*
            if ((Define.seqCtrl[(byte)MODULE._PM1] != Define.CTRL_IDLE) ||
                (Define.seqCylinderCtrl[(byte)MODULE._PM1] != Define.CTRL_IDLE) ||

                (Define.seqCtrl[(byte)MODULE._PM2] != Define.CTRL_IDLE) ||
                (Define.seqCylinderCtrl[(byte)MODULE._PM2] != Define.CTRL_IDLE) ||

                (Define.seqCtrl[(byte)MODULE._PM3] != Define.CTRL_IDLE) ||
                (Define.seqCylinderCtrl[(byte)MODULE._PM3] != Define.CTRL_IDLE) ||

                (Define.seqCtrl[(byte)MODULE._WATERTANK] != Define.CTRL_IDLE))
            {
                MessageBox.Show("CH1/CH2/CH3/Water tank process in progress", "Notification");
                return;
            }
            */

            TextBox btn = (TextBox)sender;
            digitalDlg = new DigitalDlg();

            string strTmp = btn.Tag.ToString();
            switch (strTmp)
            {                
                case "24":
                    {
                        digitalDlg.Init("Off", "On", "Main Hot Water Pump");
                        if (digitalDlg.ShowDialog() == DialogResult.OK)
                        {
                            if (digitalDlg.m_strResult == "Off")
                            {
                                Global.SetDigValue((int)DigOutputList.Hot_Water_Pump_o, (uint)DigitalOffOn.Off, ModuleName);
                            }
                            else
                            {
                                Global.SetDigValue((int)DigOutputList.Hot_Water_Pump_o, (uint)DigitalOffOn.On, ModuleName);
                            }
                        }
                    }
                    break;

                case "25":
                    {
                        digitalDlg.Init("Off", "On", "Main Hot Water Heater");
                        if (digitalDlg.ShowDialog() == DialogResult.OK)
                        {
                            if (digitalDlg.m_strResult == "Off")
                            {
                                Global.SetDigValue((int)DigOutputList.Hot_WaterHeater_o, (uint)DigitalOffOn.Off, ModuleName);
                            }
                            else
                            {
                                Global.SetDigValue((int)DigOutputList.Hot_WaterHeater_o, (uint)DigitalOffOn.On, ModuleName);
                            }
                        }
                    }
                    break;

                case "26":
                    {
                        digitalDlg.Init("Close", "Open", "Main Hot Water Supply");
                        if (digitalDlg.ShowDialog() == DialogResult.OK)
                        {
                            if (digitalDlg.m_strResult == "Close")
                            {
                                Global.SetDigValue((int)DigOutputList.Main_Water_Supply, (uint)DigitalOffOn.Off, ModuleName);
                            }
                            else
                            {
                                Global.SetDigValue((int)DigOutputList.Main_Water_Supply, (uint)DigitalOffOn.On, ModuleName);
                            }
                        }
                    }
                    break;
            }
        }
    }
}
