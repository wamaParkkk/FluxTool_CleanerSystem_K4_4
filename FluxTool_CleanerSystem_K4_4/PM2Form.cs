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
    public partial class PM2Form : UserControl
    {
        private MaintnanceForm m_Parent;
        int module;
        string ModuleName;

        RecipeSelectForm recipeSelectForm;
        ToolCheckInfoForm toolCheckInfoForm;
        ToolInfoRegistForm toolInfoRegistForm;
        DigitalDlg digitalDlg;

        private Timer logdisplayTimer = new Timer();

        bool bToolSns1 = false;
        bool bToolSns2 = false;

        public PM2Form(MaintnanceForm parent)
        {
            m_Parent = parent;            

            InitializeComponent();

            module = (int)MODULE._PM2;
            ModuleName = "PM2";
        }

        private void PM2Form_Load(object sender, EventArgs e)
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
            SetDoubleBuffered(Door_Close);            

            // Process seq status
            if (Define.bChamberDisable[module])
            {
                if (btnProcess.Enabled != false)                
                    btnProcess.Enabled = false;                                    

                if (btnRetry.Enabled != false)
                    btnRetry.Enabled = false;

                if (btnAbort.Enabled != false)
                    btnAbort.Enabled = false;

                if (btnInit.Enabled != false)
                    btnInit.Enabled = false;

                if (btnInitStop.Enabled != false)
                    btnInitStop.Enabled = false;
            }
            else
            {
                if (Define.seqMode[module] == Define.MODE_PROCESS)
                {
                    if (Define.seqCtrl[module] != Define.CTRL_IDLE)
                    {
                        if (btnProcess.Enabled != false)
                        {
                            btnProcess.Enabled = false;                            
                        }

                        if (Define.seqCtrl[module] == Define.CTRL_ALARM)
                        {
                            if (btnProcess.BackColor != Color.Red)
                                btnProcess.BackColor = Color.Red;
                            else
                                btnProcess.BackColor = Color.Transparent;

                            if (!btnRetry.Enabled)
                            {
                                btnRetry.Enabled = true;                                
                            }
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


                        if (btnInit.Enabled != false)
                            btnInit.Enabled = false;

                        if (btnInitStop.Enabled != false)
                            btnInitStop.Enabled = false;

                        if (btnInit.BackColor != Color.Transparent)
                            btnInit.BackColor = Color.Transparent;
                    }
                }
                else if (Define.seqMode[module] == Define.MODE_INIT)
                {
                    if (Define.seqCtrl[module] != Define.CTRL_IDLE)
                    {
                        if (btnInit.Enabled != false)
                        {
                            btnInit.Enabled = false;                            
                        }

                        if (Define.seqCtrl[(byte)MODULE._PM2] == Define.CTRL_ALARM)
                        {
                            if (btnInit.BackColor != Color.Red)
                                btnInit.BackColor = Color.Red;
                            else
                                btnInit.BackColor = Color.Transparent;
                        }
                        else
                        {
                            if (btnInit.BackColor != Color.YellowGreen)
                                btnInit.BackColor = Color.YellowGreen;
                            else
                                btnInit.BackColor = Color.Transparent;

                            if (label_Alarm.Text != "--")
                                label_Alarm.Text = "--";
                        }

                        if (!btnInitStop.Enabled)
                            btnInitStop.Enabled = true;


                        if (btnProcess.Enabled != false)
                            btnProcess.Enabled = false;

                        if (btnRetry.Enabled != false)
                            btnRetry.Enabled = false;

                        if (btnAbort.Enabled != false)
                            btnAbort.Enabled = false;

                        if (btnProcess.BackColor != Color.Transparent)
                            btnProcess.BackColor = Color.Transparent;
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

                    if (!btnInit.Enabled)
                        btnInit.Enabled = true;

                    if (btnInitStop.Enabled != false)
                        btnInitStop.Enabled = false;

                    if (btnInit.BackColor != Color.Transparent)
                        btnInit.BackColor = Color.Transparent;
                }
            }

            if ((Define.seqMode[module] == Define.MODE_PROCESS) && (Define.seqCtrl[module] == Define.CTRL_WAIT))
            {
                if (labelProcessWait.ForeColor == Color.LightGray)
                    labelProcessWait.ForeColor = Color.Red;
                else
                    labelProcessWait.ForeColor = Color.LightGray;
            }
            else
            {
                if (labelProcessWait.ForeColor != Color.LightGray)
                    labelProcessWait.ForeColor = Color.LightGray;
            }

            // Process recipe 정보
            if (Global.prcsInfo.prcsRecipeName[module] != null)
                textBoxRecipeName.Text = Global.prcsInfo.prcsRecipeName[module];

            textBoxStepNum.Text = Global.prcsInfo.prcsCurrentStep[module].ToString() + " / " + Global.prcsInfo.prcsTotalStep[module];

            if (Global.prcsInfo.prcsStepName[module] != null)
                textBoxStepName.Text = Global.prcsInfo.prcsStepName[module];

            textBoxProcessTime.Text = Global.prcsInfo.prcsStepCurrentTime[module].ToString("0") + " / " + Global.prcsInfo.prcsStepTotalTime[module].ToString();
            textBoxProcessEndTime.Text = Global.prcsInfo.prcsEndTime[module];


            // Input display                       
            if (Global.GetDigValue((int)DigInputList.CH2_Cylinder_Fwd_i) == "Off")
            {
                if (CylinderFWDSns.BackColor != Color.Lime)
                    CylinderFWDSns.BackColor = Color.Lime;
            }
            else
            {
                if (CylinderFWDSns.BackColor != Color.Silver)
                    CylinderFWDSns.BackColor = Color.Silver;
            }

            if (Global.GetDigValue((int)DigInputList.CH2_Cylinder_Bwd_i) == "On")
            {
                if (CylinderBWDSns.BackColor != Color.Lime)
                    CylinderBWDSns.BackColor = Color.Lime;
            }
            else
            {
                if (CylinderBWDSns.BackColor != Color.Silver)
                    CylinderBWDSns.BackColor = Color.Silver;
            }

            if (Global.GetDigValue((int)DigInputList.CH2_Cylinder_Home_i) == "Off")
            {
                if (CylinderHomeSns.BackColor != Color.Lime)
                    CylinderHomeSns.BackColor = Color.Lime;
            }
            else
            {
                if (CylinderHomeSns.BackColor != Color.Silver)
                    CylinderHomeSns.BackColor = Color.Silver;
            }

            if (Global.GetDigValue((int)DigInputList.CH2_Door_Sensor_i) == "Off")
            {
                textBoxDoor.Text = "Open";
                textBoxDoor.BackColor = Color.OrangeRed;
            }
            else if (Global.GetDigValue((int)DigInputList.CH2_Door_Sensor_i) == "On")
            {
                textBoxDoor.Text = "Close";
                textBoxDoor.BackColor = Color.LightSkyBlue;
            }

            // Output display            
            if ((Global.digSet.curDigSet[(int)DigOutputList.CH2_Cylinder_Pwr_o] == "On") &&
                (Global.digSet.curDigSet[(int)DigOutputList.CH2_Cylinder_FwdBwd_o] == "Off"))
            {
                textBoxCylinderFwdBwd.Text = "Forward";
            }
            else if ((Global.digSet.curDigSet[(int)DigOutputList.CH2_Cylinder_Pwr_o] == "On") &&
                     (Global.digSet.curDigSet[(int)DigOutputList.CH2_Cylinder_FwdBwd_o] == "On"))
            {
                textBoxCylinderFwdBwd.Text = "Backward";
            }
            else
            {
                textBoxCylinderFwdBwd.Text = "None";
            }

            if (Global.digSet.curDigSet[(int)DigOutputList.CH2_WaterValve_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.CH2_WaterValve_o] == "On")
                {
                    textBoxWater.Text = "Open";
                    textBoxWater.BackColor = Color.LightSkyBlue;
                    if (!Water1.Visible)
                        Water1.Visible = true;
                    else
                        Water1.Visible = false;

                    if (!Water2.Visible)
                        Water2.Visible = true;
                    else
                        Water2.Visible = false;
                }
                else
                {
                    textBoxWater.Text = "Close";
                    textBoxWater.BackColor = Color.WhiteSmoke;
                    if (Water1.Visible != false)
                        Water1.Visible = false;

                    if (Water2.Visible != false)
                        Water2.Visible = false;
                }
            }

            if (Global.digSet.curDigSet[(int)DigOutputList.CH2_Air_Knife_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.CH2_Air_Knife_o] == "On")
                {
                    textBoxAirknife.Text = "Open";
                    textBoxAirknife.BackColor = Color.LightSkyBlue;
                    if (!Airknife.Visible)
                        Airknife.Visible = true;
                    else
                        Airknife.Visible = false;
                }
                else
                {
                    textBoxAirknife.Text = "Close";
                    textBoxAirknife.BackColor = Color.WhiteSmoke;
                    if (Airknife.Visible != false)
                        Airknife.Visible = false;
                }
            }            

            if (Global.digSet.curDigSet[(int)DigOutputList.CH2_Curtain_AirValve_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.CH2_Curtain_AirValve_o] == "On")
                {
                    textBoxCurtainAir.Text = "Open";
                    textBoxCurtainAir.BackColor = Color.LightSkyBlue;
                    if (!LeftAir.Visible)
                        LeftAir.Visible = true;
                    else
                        LeftAir.Visible = false;

                    if (!RightAir.Visible)
                        RightAir.Visible = true;
                    else
                        RightAir.Visible = false;
                }
                else
                {
                    textBoxCurtainAir.Text = "Close";
                    textBoxCurtainAir.BackColor = Color.WhiteSmoke;
                    if (LeftAir.Visible != false)
                        LeftAir.Visible = false;

                    if (RightAir.Visible != false)
                        RightAir.Visible = false;
                }
            }

            if (Global.digSet.curDigSet[(int)DigOutputList.CH2_Booster_AirValve_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.CH2_Booster_AirValve_o] == "On")
                {
                    textBoxBoosterAir.Text = "Open";
                    textBoxBoosterAir.BackColor = Color.LightSkyBlue;
                }
                else
                {
                    textBoxBoosterAir.Text = "Close";
                    textBoxBoosterAir.BackColor = Color.WhiteSmoke;
                }
            }

            if (Global.digSet.curDigSet[(int)DigOutputList.CH2_Pin_UpDn_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.CH2_Pin_UpDn_o] == "On")
                {
                    textBoxPinUpDn.Text = "Up";
                }
                else
                {
                    textBoxPinUpDn.Text = "Down";
                }
            }

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

            // Daily count
            textBoxDailyCnt.Text = Define.iPM2DailyCnt.ToString("00");            

            // Chamber Enable/Disable
            if (Define.bChamberDisable[module])
            {
                btnCH2EnaDis.Text = "Enable";
                btnCH2EnaDis.ForeColor = Color.ForestGreen;
                imgCH2EnaDis.Visible = true;
            }
            else
            {
                btnCH2EnaDis.Text = "Disable";
                btnCH2EnaDis.ForeColor = Color.Red;
                imgCH2EnaDis.Visible = false;
            }
        }

        private void Eventlog_Display(object sender, ElapsedEventArgs e)
        {
            if (Define.bPM2Event)
            {
                Eventlog_File_Read();
            }

            if (Define.bPM2AlmEvent)
            {
                Alarmlog_File_Read();
            }
        }

        private void Eventlog_File_Read()
        {
            Define.bPM2Event = false;
            
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
            Define.bPM2AlmEvent = false;

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

        private async void Digital_Click(object sender, EventArgs e)
        {
            /*
            if ((Define.seqCtrl[module] != Define.CTRL_IDLE) ||
                (Define.seqCylinderCtrl[module] != Define.CTRL_IDLE))
            {
                MessageBox.Show("Process is in progress", "Notification");
                return;
            }
            */

            if (Define.bChamberDisable[module])
            {
                MessageBox.Show("Chamber unavailable", "Notification");
                return;
            }

            TextBox btn = (TextBox)sender;
            digitalDlg = new DigitalDlg();

            string strTmp = btn.Tag.ToString();
            switch (strTmp)
            {
                case "0":
                    {
                        digitalDlg.Init("Close", "Open", "CH2 Water Valve");
                        if (digitalDlg.ShowDialog() == DialogResult.OK)
                        {
                            if (digitalDlg.m_strResult == "Close")
                            {
                                Global.SetDigValue((int)DigOutputList.CH2_WaterValve_o, (uint)DigitalOffOn.Off, ModuleName);
                            }
                            else
                            {
                                Global.SetDigValue((int)DigOutputList.CH2_WaterValve_o, (uint)DigitalOffOn.On, ModuleName);
                            }
                        }
                    }
                    break;

                case "1":
                    {
                        digitalDlg.Init("Close", "Open", "CH2 Air knife");
                        if (digitalDlg.ShowDialog() == DialogResult.OK)
                        {
                            if (digitalDlg.m_strResult == "Close")
                            {
                                Global.SetDigValue((int)DigOutputList.CH2_Air_Knife_o, (uint)DigitalOffOn.Off, ModuleName);
                            }
                            else
                            {
                                Global.SetDigValue((int)DigOutputList.CH2_Air_Knife_o, (uint)DigitalOffOn.On, ModuleName);
                            }
                        }
                    }
                    break;

                case "2":
                    {
                        digitalDlg.Init("Close", "Open", "CH2 Curtain Air Valve");
                        if (digitalDlg.ShowDialog() == DialogResult.OK)
                        {
                            if (digitalDlg.m_strResult == "Close")
                            {
                                Global.SetDigValue((int)DigOutputList.CH2_Curtain_AirValve_o, (uint)DigitalOffOn.Off, ModuleName);
                            }
                            else
                            {
                                Global.SetDigValue((int)DigOutputList.CH2_Curtain_AirValve_o, (uint)DigitalOffOn.On, ModuleName);
                            }
                        }
                    }
                    break;                

                case "3":
                    {
                        digitalDlg.Init2("Home", "Backward", "Forward", "CH2 Cylinder Fwd/Bwd");
                        if (digitalDlg.ShowDialog() == DialogResult.OK)
                        {
                            if (!Define.bInterlockRelease)
                            {
                                if (Global.GetDigValue((int)DigInputList.CH2_Door_Sensor_i) == "Off")
                                {
                                    MessageBox.Show("Chamber door is opened", "Notification");
                                    return;
                                }
                            }                            

                            if (digitalDlg.m_strResult == "Home")
                            {
                                //Global.SetDigValue((int)DigOutputList.CH2_Cylinder_Pwr_o, (uint)DigitalOffOn.Off, ModuleName);
                                //Global.SetDigValue((int)DigOutputList.CH2_Cylinder_FwdBwd_o, (uint)DigitalOffOn.Off, ModuleName);
                                Define.seqCylinderMode[module] = Define.MODE_CYLINDER_HOME;
                                Define.seqCylinderCtrl[module] = Define.CTRL_RUN;
                                Define.seqCylinderSts[module] = Define.STS_CYLINDER_IDLE;
                            }
                            else if (digitalDlg.m_strResult == "Backward")
                            {
                                /*
                                Global.SetDigValue((int)DigOutputList.CH2_Cylinder_Pwr_o, (uint)DigitalOffOn.Off, ModuleName);
                                Global.SetDigValue((int)DigOutputList.CH2_Cylinder_FwdBwd_o, (uint)DigitalOffOn.Off, ModuleName);
                                await Task.Delay(500);
                                Global.SetDigValue((int)DigOutputList.CH2_Cylinder_FwdBwd_o, (uint)DigitalOffOn.On, ModuleName);
                                await Task.Delay(500);
                                Global.SetDigValue((int)DigOutputList.CH2_Cylinder_Pwr_o, (uint)DigitalOffOn.On, ModuleName);
                                */
                                Define.seqCylinderMode[module] = Define.MODE_CYLINDER_BWD;
                                Define.seqCylinderCtrl[module] = Define.CTRL_RUN;
                                Define.seqCylinderSts[module] = Define.STS_CYLINDER_IDLE;
                            }
                            else if (digitalDlg.m_strResult == "Forward")
                            {
                                /*
                                Global.SetDigValue((int)DigOutputList.CH2_Cylinder_Pwr_o, (uint)DigitalOffOn.Off, ModuleName);
                                Global.SetDigValue((int)DigOutputList.CH2_Cylinder_FwdBwd_o, (uint)DigitalOffOn.Off, ModuleName);
                                await Task.Delay(500);
                                Global.SetDigValue((int)DigOutputList.CH2_Cylinder_FwdBwd_o, (uint)DigitalOffOn.Off, ModuleName);
                                Global.SetDigValue((int)DigOutputList.CH2_Cylinder_Pwr_o, (uint)DigitalOffOn.On, ModuleName);
                                */
                                Define.seqCylinderMode[module] = Define.MODE_CYLINDER_FWD;
                                Define.seqCylinderCtrl[module] = Define.CTRL_RUN;
                                Define.seqCylinderSts[module] = Define.STS_CYLINDER_IDLE;
                            }
                        }
                    }
                    break;

                case "5":
                    {
                        digitalDlg.Init("Close", "Open", "CH2 Booster Air Valve");
                        if (digitalDlg.ShowDialog() == DialogResult.OK)
                        {
                            if (digitalDlg.m_strResult == "Close")
                            {
                                Global.SetDigValue((int)DigOutputList.CH2_Booster_AirValve_o, (uint)DigitalOffOn.Off, ModuleName);
                            }
                            else
                            {
                                Global.SetDigValue((int)DigOutputList.CH2_Booster_AirValve_o, (uint)DigitalOffOn.On, ModuleName);
                            }
                        }
                    }
                    break;

                case "6":
                    {
                        digitalDlg.Init("Down", "Up", "CH2 Pin Up/Down");
                        if (digitalDlg.ShowDialog() == DialogResult.OK)
                        {
                            if (digitalDlg.m_strResult == "Down")
                            {
                                Global.SetDigValue((int)DigOutputList.CH2_Pin_UpDn_o, (uint)DigitalOffOn.Off, ModuleName);
                            }
                            else
                            {
                                Global.SetDigValue((int)DigOutputList.CH2_Pin_UpDn_o, (uint)DigitalOffOn.On, ModuleName);
                            }
                        }
                    }
                    break;

                case "24":
                    {
                        digitalDlg.Init("Off", "On", "Main Hot Water Pump");
                        if (digitalDlg.ShowDialog() == DialogResult.OK)
                        {
                            if (digitalDlg.m_strResult == "Off")
                            {
                                Global.SetDigValue((int)DigOutputList.Hot_Water_Pump_o, (uint)DigitalOffOn.Off, "PM1");
                            }
                            else
                            {
                                Global.SetDigValue((int)DigOutputList.Hot_Water_Pump_o, (uint)DigitalOffOn.On, "PM1");
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
                                Global.SetDigValue((int)DigOutputList.Hot_WaterHeater_o, (uint)DigitalOffOn.Off, "PM1");
                            }
                            else
                            {
                                Global.SetDigValue((int)DigOutputList.Hot_WaterHeater_o, (uint)DigitalOffOn.On, "PM1");
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
                                Global.SetDigValue((int)DigOutputList.Main_Water_Supply, (uint)DigitalOffOn.Off, "PM1");
                            }
                            else
                            {
                                Global.SetDigValue((int)DigOutputList.Main_Water_Supply, (uint)DigitalOffOn.On, "PM1");
                            }
                        }
                    }
                    break;
            }  
        }

        private void btnCylinderStop_Click(object sender, EventArgs e)
        {
            Define.seqCylinderCtrl[module] = Define.CTRL_ABORT;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {            
            Button btn = (Button)sender;
            string strTmp = btn.Text.ToString();
            switch (strTmp)
            {
                case "Start":
                    {
                        if (!Define.bInterlockRelease)
                        {
                            if (Global.GetDigValue((int)DigInputList.Front_Door_Sensor_i) == "Off")
                            {
                                MessageBox.Show("Front door is opened", "Notification");
                                return;
                            }

                            if (Global.GetDigValue((int)DigInputList.Left_Door_Sensor_i) == "Off")
                            {
                                MessageBox.Show("Left door is opened", "Notification");
                                return;
                            }

                            if (Global.GetDigValue((int)DigInputList.Right_Door_Sensor_i) == "Off")
                            {
                                MessageBox.Show("Right door is opened", "Notification");
                                return;
                            }

                            if (Global.GetDigValue((int)DigInputList.Back_Door_Sensor_i) == "Off")
                            {
                                MessageBox.Show("Back door is opened", "Notification");
                                return;
                            }

                            if (Global.GetDigValue((int)DigInputList.CH2_Door_Sensor_i) == "Off")
                            {
                                MessageBox.Show("Chamber door is opened", "Notification");
                                return;
                            }
                        }

                        if (MessageBox.Show("Do you want to proceed with the process?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (Configure_List.bToolIDSkip)
                            {
                                Define.iSelectRecipeModule = module;

                                recipeSelectForm = new RecipeSelectForm();

                                if (recipeSelectForm.ShowDialog() == DialogResult.OK)
                                {
                                    Define.seqMode[module] = Define.MODE_PROCESS;
                                    Define.seqCtrl[module] = Define.CTRL_RUN;
                                    Define.seqSts[module] = Define.STS_IDLE;
                                }
                            }
                            else
                            {
                                toolInfoRegistForm = new ToolInfoRegistForm();
                                toolInfoRegistForm.Init(module);
                                if (toolInfoRegistForm.ShowDialog() == DialogResult.OK)
                                {
                                    Define.iSelectRecipeModule = module;

                                    recipeSelectForm = new RecipeSelectForm();

                                    if (recipeSelectForm.ShowDialog() == DialogResult.OK)
                                    {
                                        Define.seqMode[module] = Define.MODE_PROCESS;
                                        Define.seqCtrl[module] = Define.CTRL_RUN;
                                        Define.seqSts[module] = Define.STS_IDLE;
                                    }
                                }
                            }                            
                        }
                    }
                    break;

                case "Retry":
                    {
                        if (!Define.bInterlockRelease)
                        {
                            if (Global.GetDigValue((int)DigInputList.Front_Door_Sensor_i) == "Off")
                            {
                                MessageBox.Show("Front door is opened", "Notification");
                                return;
                            }

                            if (Global.GetDigValue((int)DigInputList.Left_Door_Sensor_i) == "Off")
                            {
                                MessageBox.Show("Left door is opened", "Notification");
                                return;
                            }

                            if (Global.GetDigValue((int)DigInputList.Right_Door_Sensor_i) == "Off")
                            {
                                MessageBox.Show("Right door is opened", "Notification");
                                return;
                            }

                            if (Global.GetDigValue((int)DigInputList.Back_Door_Sensor_i) == "Off")
                            {
                                MessageBox.Show("Back door is opened", "Notification");
                                return;
                            }

                            if (Global.GetDigValue((int)DigInputList.CH2_Door_Sensor_i) == "Off")
                            {
                                MessageBox.Show("Chamber door is opened", "Notification");
                                return;
                            }
                        }

                        Define.seqCtrl[module] = Define.CTRL_RETRY;
                    }
                    break;

                case "Stop":
                    {
                        if (MessageBox.Show("Do you want to stop the process?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Define.seqCtrl[module] = Define.CTRL_ABORT;
                        }
                    }
                    break;
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string strTmp = btn.Text.ToString();
            switch (strTmp)
            {
                case "Init":
                    {
                        if (!Define.bInterlockRelease)
                        {
                            if (Global.GetDigValue((int)DigInputList.Front_Door_Sensor_i) == "Off")
                            {
                                MessageBox.Show("Front door is opened", "Notification");
                                return;
                            }

                            if (Global.GetDigValue((int)DigInputList.Left_Door_Sensor_i) == "Off")
                            {
                                MessageBox.Show("Left door is opened", "Notification");
                                return;
                            }

                            if (Global.GetDigValue((int)DigInputList.Right_Door_Sensor_i) == "Off")
                            {
                                MessageBox.Show("Right door is opened", "Notification");
                                return;
                            }

                            if (Global.GetDigValue((int)DigInputList.Back_Door_Sensor_i) == "Off")
                            {
                                MessageBox.Show("Back door is opened", "Notification");
                                return;
                            }

                            if (Global.GetDigValue((int)DigInputList.CH2_Door_Sensor_i) == "Off")
                            {
                                MessageBox.Show("Chamber door is opened", "Notification");
                                return;
                            }
                        }

                        Define.seqMode[module] = Define.MODE_INIT;
                        Define.seqCtrl[module] = Define.CTRL_RUN;
                        Define.seqSts[module] = Define.STS_IDLE;
                    }
                    break;

                case "Stop":
                    {
                        Define.seqCtrl[module] = Define.CTRL_ABORT;
                    }
                    break;
            }
        }

        private void btnCH2EnaDis_Click(object sender, EventArgs e)
        {
            if (Define.bChamberDisable[module])
                Define.bChamberDisable[module] = false;
            else
                Define.bChamberDisable[module] = true;
        }        
    }
}
