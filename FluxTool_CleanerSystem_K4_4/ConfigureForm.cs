using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace FluxTool_CleanerSystem_K4_4
{
    public partial class ConfigureForm : Form
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        AnalogDlg AnaDlg;

        public ConfigureForm()
        {            
            InitializeComponent();
        }

        private void ConfigureForm_Load(object sender, EventArgs e)
        {
            Width = 1172;
            Height = 824;
            Top = 0;
            Left = 0;

            PARAMETER_LOAD();
            TEMP_PARAMETER_LOAD();

            COVER_DOOR_OPTION_LOAD();
            TOOL_ID_SKIP_LOAD();
        }

        private void ConfigureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        private void PARAMETER_LOAD()
        {
            string sTmpData;
            string FileName = "Configure.txt";

            if (File.Exists(Global.ConfigurePath + FileName))
            {
                byte[] bytes;
                using (var fs = File.Open(Global.ConfigurePath + FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, (int)fs.Length);
                    sTmpData = Encoding.Default.GetString(bytes);

                    char sp = ',';
                    string[] spString = sTmpData.Split(sp);
                    for (int i = 0; i < spString.Length; i++)
                    {
                        Configure_List.Door_OpCl_Timeout = int.Parse(spString[0]);
                        Configure_List.Cylinder_FwdBwd_Timeout = int.Parse(spString[1]);                        
                        Configure_List.Water_Heating_Timeout = int.Parse(spString[2]);
                        Configure_List.Water_Fill_Timeout = int.Parse(spString[3]);
                        Configure_List.Pin_Time_Interval = int.Parse(spString[4]);
                        Configure_List.End_Buzzer_Time = int.Parse(spString[5]);

                        txtBoxDoorOpenCloseTimeout.Text = (Configure_List.Door_OpCl_Timeout).ToString();
                        txtBoxCylinderFwdBwdTimeout.Text = (Configure_List.Cylinder_FwdBwd_Timeout).ToString();                        
                        txtBoxWaterHeatingTimeout.Text = (Configure_List.Water_Heating_Timeout).ToString();
                        txtBoxWaterFillTimeout.Text = (Configure_List.Water_Fill_Timeout).ToString();
                        txtBoxPinTimeInterval.Text = (Configure_List.Pin_Time_Interval).ToString();
                        txtBoxProcessEndBuzzerTime.Text = (Configure_List.End_Buzzer_Time).ToString();
                    }
                }
            }
        }

        private void TEMP_PARAMETER_LOAD()
        {
            string sTmpData;
            string FileName = "HeatingTemp.txt";

            if (File.Exists(Global.ConfigurePath + FileName))
            {
                byte[] bytes;
                using (var fs = File.Open(Global.ConfigurePath + FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, (int)fs.Length);
                    sTmpData = Encoding.Default.GetString(bytes);

                    char sp = ',';
                    string[] spString = sTmpData.Split(sp);
                    for (int i = 0; i < spString.Length; i++)
                    {
                        Configure_List.Water_Heating_Temp = double.Parse(spString[0]);
                        Configure_List.Water_OverTempSet = double.Parse(spString[1]);

                        txtBoxHeatingTemp.Text = (Configure_List.Water_Heating_Temp).ToString();
                        txtBoxWaterOverTempSet.Text = (Configure_List.Water_OverTempSet).ToString();
                    }
                }
            }
        }

        private void COVER_DOOR_OPTION_LOAD()
        {
            try
            {                
                // Ini file read
                StringBuilder sbFront = new StringBuilder();
                StringBuilder sbLeft = new StringBuilder();
                StringBuilder sbBack = new StringBuilder();
                StringBuilder sbRight = new StringBuilder();

                GetPrivateProfileString("Front", "Enable", "", sbFront, sbFront.Capacity, string.Format("{0}{1}", Global.ConfigurePath, "CoverDoor.ini"));
                GetPrivateProfileString("Left", "Enable", "", sbLeft, sbLeft.Capacity, string.Format("{0}{1}", Global.ConfigurePath, "CoverDoor.ini"));
                GetPrivateProfileString("Back", "Enable", "", sbBack, sbBack.Capacity, string.Format("{0}{1}", Global.ConfigurePath, "CoverDoor.ini"));
                GetPrivateProfileString("Right", "Enable", "", sbRight, sbRight.Capacity, string.Format("{0}{1}", Global.ConfigurePath, "CoverDoor.ini"));

                Configure_List.bFrontEnable = Convert.ToBoolean(sbFront.ToString().Trim());
                Configure_List.bLeftEnable = Convert.ToBoolean(sbLeft.ToString().Trim());
                Configure_List.bBackEnable = Convert.ToBoolean(sbBack.ToString().Trim());
                Configure_List.bRightEnable = Convert.ToBoolean(sbRight.ToString().Trim());

                checkBoxFront.Checked = Configure_List.bFrontEnable;
                checkBoxLeft.Checked = Configure_List.bLeftEnable;
                checkBoxBack.Checked = Configure_List.bBackEnable;
                checkBoxRight.Checked = Configure_List.bRightEnable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void TOOL_ID_SKIP_LOAD()
        {
            try
            {
                // Ini file read
                StringBuilder sbToolIDSkip = new StringBuilder();
                GetPrivateProfileString("Skip", "Enable", "", sbToolIDSkip, sbToolIDSkip.Capacity, string.Format("{0}{1}", Global.ConfigurePath, "ToolIDSkip.ini"));
                Configure_List.bToolIDSkip = Convert.ToBoolean(sbToolIDSkip.ToString().Trim());
                checkBoxToolIDSkip.Checked = Configure_List.bToolIDSkip;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBoxDoorOpenCloseTimeout_Click(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            AnaDlg = new AnalogDlg();
            AnaDlg.Init();
            if (AnaDlg.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = AnaDlg.m_strResult;

                string[] sVal = new string[1];
                string sTemp = textBox.Text.ToString().Trim();
                sVal[0] = sTemp;
                if (!Global.Value_Check(sVal))
                {
                    MessageBox.Show("Invalid input", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox.Text = "0";
                }
            }
        }

        private void btnParameterSave_Click(object sender, EventArgs e)
        {
            string sDoorOpClTimeout = txtBoxDoorOpenCloseTimeout.Text.ToString().Trim();
            string sCylinderFwdBwdTimeout = txtBoxCylinderFwdBwdTimeout.Text.ToString().Trim();            
            string sWaterHeatingTimeout = txtBoxWaterHeatingTimeout.Text.ToString().Trim();
            string sWaterFillTimeout = txtBoxWaterFillTimeout.Text.ToString().Trim();
            string sPinTimeInterval = txtBoxPinTimeInterval.Text.ToString().Trim();
            string sEndBuzzerTime = txtBoxProcessEndBuzzerTime.Text.ToString().Trim();

            if (Parameter_WriteFile(sDoorOpClTimeout, sCylinderFwdBwdTimeout, sWaterHeatingTimeout, sWaterFillTimeout, sPinTimeInterval, sEndBuzzerTime))
            {
                Configure_List.Door_OpCl_Timeout = int.Parse(sDoorOpClTimeout);
                Configure_List.Cylinder_FwdBwd_Timeout = int.Parse(sCylinderFwdBwdTimeout);                
                Configure_List.Water_Heating_Timeout = int.Parse(sWaterHeatingTimeout);
                Configure_List.Water_Fill_Timeout = int.Parse(sWaterFillTimeout);
                Configure_List.Pin_Time_Interval = int.Parse(sPinTimeInterval);
                Configure_List.End_Buzzer_Time = int.Parse(sEndBuzzerTime);

                MessageBox.Show("Configure values has been saved", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Configure values has not been saved", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool Parameter_WriteFile(string param1, string param2, string param3, string param4, string param5, string param6)
        {
            string FileName = "Configure.txt";

            try
            {                
                File.WriteAllText(Global.ConfigurePath + FileName, param1 + "," + param2 + "," + param3 + "," + param4 + "," + param5 + "," + param6, Encoding.Default);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
                return false;
            }
        }

        private void btnHeatingTempSave_Click(object sender, EventArgs e)
        {
            string sHeatingTemp = txtBoxHeatingTemp.Text.ToString().Trim();
            string sWaterOverTempSet = txtBoxWaterOverTempSet.Text.ToString().Trim();

            if (Temp_Parameter_WriteFile(sHeatingTemp, sWaterOverTempSet))
            {
                Configure_List.Water_Heating_Temp = double.Parse(sHeatingTemp);
                Configure_List.Water_OverTempSet = double.Parse(sWaterOverTempSet);

                MessageBox.Show("Configure values has been saved", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Configure values has not been saved", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool Temp_Parameter_WriteFile(string param1, string param2)
        {
            string FileName = "HeatingTemp.txt";

            try
            {
                File.WriteAllText(Global.ConfigurePath + FileName, param1 + "," + param2, Encoding.Default);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
                return false;
            }
        }

        private void checkBoxFront_Click(object sender, EventArgs e)
        {
            if (Define.UserLevel == "Master")
            {
                try
                {
                    CheckBox btn = (CheckBox)sender;
                    string strText = btn.Text.Trim();
                    switch (strText)
                    {
                        case "Front":
                            {
                                Configure_List.bFrontEnable = btn.Checked;
                                if (Configure_List.bFrontEnable)
                                    WritePrivateProfileString("Front", "Enable", "True", string.Format("{0}{1}", Global.ConfigurePath, "CoverDoor.ini"));
                                else
                                    WritePrivateProfileString("Front", "Enable", "False", string.Format("{0}{1}", Global.ConfigurePath, "CoverDoor.ini"));
                            }
                            break;

                        case "Left":
                            {
                                Configure_List.bLeftEnable = btn.Checked;
                                if (Configure_List.bLeftEnable)
                                    WritePrivateProfileString("Left", "Enable", "True", string.Format("{0}{1}", Global.ConfigurePath, "CoverDoor.ini"));
                                else
                                    WritePrivateProfileString("Left", "Enable", "False", string.Format("{0}{1}", Global.ConfigurePath, "CoverDoor.ini"));
                            }
                            break;

                        case "Back":
                            {
                                Configure_List.bBackEnable = btn.Checked;
                                if (Configure_List.bBackEnable)
                                    WritePrivateProfileString("Back", "Enable", "True", string.Format("{0}{1}", Global.ConfigurePath, "CoverDoor.ini"));
                                else
                                    WritePrivateProfileString("Back", "Enable", "False", string.Format("{0}{1}", Global.ConfigurePath, "CoverDoor.ini"));
                            }
                            break;

                        case "Right":
                            {
                                Configure_List.bRightEnable = btn.Checked;
                                if (Configure_List.bRightEnable)
                                    WritePrivateProfileString("Right", "Enable", "True", string.Format("{0}{1}", Global.ConfigurePath, "CoverDoor.ini"));
                                else
                                    WritePrivateProfileString("Right", "Enable", "False", string.Format("{0}{1}", Global.ConfigurePath, "CoverDoor.ini"));
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
            else
            {
                MessageBox.Show("Only master level can be set", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                COVER_DOOR_OPTION_LOAD();
            }                              
        }

        private void checkBoxToolIDSkip_Click(object sender, EventArgs e)
        {
            if (Define.UserLevel == "Master")
            {
                try
                {
                    CheckBox btn = (CheckBox)sender;
                    Configure_List.bToolIDSkip = btn.Checked;
                    if (Configure_List.bToolIDSkip)
                        WritePrivateProfileString("Skip", "Enable", "True", string.Format("{0}{1}", Global.ConfigurePath, "ToolIDSkip.ini"));
                    else
                        WritePrivateProfileString("Skip", "Enable", "False", string.Format("{0}{1}", Global.ConfigurePath, "ToolIDSkip.ini"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Only master level can be set", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TOOL_ID_SKIP_LOAD();
            }
        }
    }
}
