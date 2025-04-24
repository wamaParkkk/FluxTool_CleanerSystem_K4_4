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
    public partial class OperationForm : Form
    {
        RecipeSelectForm recipeSelectForm;
        ToolCheckInfoForm toolCheckInfoForm;
        ToolInfoRegistForm toolInfoRegistForm;

        private Timer logdisplayTimer = new Timer();

        public OperationForm()
        {            
            InitializeComponent();
        }

        private void OperationForm_Load(object sender, EventArgs e)
        {
            Width = 1172;
            Height = 824;
            Top = 0;
            Left = 0;            

            displayTimer.Enabled = true;

            logdisplayTimer.Interval = 100;
            logdisplayTimer.Elapsed += new ElapsedEventHandler(Eventlog_Display);
            logdisplayTimer.Start();
        }

        private void OperationForm_Activated(object sender, EventArgs e)
        {
            Top = 0;
            Left = 0;

            SetDoubleBuffered(PM1_Door_Close);            
            SetDoubleBuffered(PM2_Door_Close);            
            SetDoubleBuffered(PM3_Door_Close);
            
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

        private void OperationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            displayTimer.Enabled = false;
            logdisplayTimer.Stop();

            Dispose();
        }

        private void displayTimer_Tick(object sender, EventArgs e)
        {
            // CH1 display
            if (Define.bChamberDisable[(byte)MODULE._PM1])
            {
                if (btnPM1Process.Enabled != false)
                    btnPM1Process.Enabled = false;

                if (btnPM1Retry.Enabled != false)
                    btnPM1Retry.Enabled = false;

                if (btnPM1Abort.Enabled != false)
                    btnPM1Abort.Enabled = false;

                if (btnPM1Init.Enabled != false)
                    btnPM1Init.Enabled = false;

                if (btnPM1InitStop.Enabled != false)
                    btnPM1InitStop.Enabled = false;
            }
            else
            {
                if (Define.seqMode[(byte)MODULE._PM1] == Define.MODE_PROCESS)
                {
                    if (Define.seqCtrl[(byte)MODULE._PM1] != Define.CTRL_IDLE)
                    {
                        if (btnPM1Process.Enabled != false)
                            btnPM1Process.Enabled = false;

                        if (Define.seqCtrl[(byte)MODULE._PM1] == Define.CTRL_ALARM)
                        {
                            if (btnPM1Process.BackColor != Color.Red)
                                btnPM1Process.BackColor = Color.Red;
                            else
                                btnPM1Process.BackColor = Color.Transparent;

                            if (!btnPM1Retry.Enabled)
                                btnPM1Retry.Enabled = true;
                        }
                        else
                        {
                            if (btnPM1Process.BackColor != Color.YellowGreen)
                                btnPM1Process.BackColor = Color.YellowGreen;
                            else
                                btnPM1Process.BackColor = Color.Transparent;

                            if (label_PM1Alarm.Text != "--")
                                label_PM1Alarm.Text = "--";

                            if (btnPM1Retry.Enabled != false)
                                btnPM1Retry.Enabled = false;
                        }

                        if (!btnPM1Abort.Enabled)
                            btnPM1Abort.Enabled = true;


                        if (btnPM1Init.Enabled != false)
                            btnPM1Init.Enabled = false;

                        if (btnPM1InitStop.Enabled != false)
                            btnPM1InitStop.Enabled = false;

                        if (btnPM1Init.BackColor != Color.Transparent)
                            btnPM1Init.BackColor = Color.Transparent;

                        if (btnCH1EnaDis.Enabled != false)
                            btnCH1EnaDis.Enabled = false;
                    }
                }
                else if (Define.seqMode[(byte)MODULE._PM1] == Define.MODE_INIT)
                {
                    if (Define.seqCtrl[(byte)MODULE._PM1] != Define.CTRL_IDLE)
                    {
                        if (btnPM1Init.Enabled != false)
                            btnPM1Init.Enabled = false;

                        if (Define.seqCtrl[(byte)MODULE._PM1] == Define.CTRL_ALARM)
                        {
                            if (btnPM1Init.BackColor != Color.Red)
                                btnPM1Init.BackColor = Color.Red;
                            else
                                btnPM1Init.BackColor = Color.Transparent;
                        }
                        else
                        {
                            if (btnPM1Init.BackColor != Color.YellowGreen)
                                btnPM1Init.BackColor = Color.YellowGreen;
                            else
                                btnPM1Init.BackColor = Color.Transparent;

                            if (label_PM1Alarm.Text != "--")
                                label_PM1Alarm.Text = "--";
                        }

                        if (!btnPM1InitStop.Enabled)
                            btnPM1InitStop.Enabled = true;


                        if (btnPM1Process.Enabled != false)
                            btnPM1Process.Enabled = false;

                        if (btnPM1Retry.Enabled != false)
                            btnPM1Retry.Enabled = false;

                        if (btnPM1Abort.Enabled != false)
                            btnPM1Abort.Enabled = false;

                        if (btnPM1Process.BackColor != Color.Transparent)
                            btnPM1Process.BackColor = Color.Transparent;

                        if (btnCH1EnaDis.Enabled != false)
                            btnCH1EnaDis.Enabled = false;
                    }
                }
                else if (Define.seqMode[(byte)MODULE._PM1] == Define.MODE_IDLE)
                {
                    if (!btnPM1Process.Enabled)
                        btnPM1Process.Enabled = true;

                    if (btnPM1Process.BackColor != Color.Transparent)
                        btnPM1Process.BackColor = Color.Transparent;

                    if (btnPM1Retry.Enabled != false)
                        btnPM1Retry.Enabled = false;

                    if (btnPM1Abort.Enabled != false)
                        btnPM1Abort.Enabled = false;

                    if (label_PM1Alarm.Text != "--")
                        label_PM1Alarm.Text = "--";

                    if (!btnPM1Init.Enabled)
                        btnPM1Init.Enabled = true;

                    if (btnPM1InitStop.Enabled != false)
                        btnPM1InitStop.Enabled = false;

                    if (btnPM1Init.BackColor != Color.Transparent)
                        btnPM1Init.BackColor = Color.Transparent;

                    if (!btnCH1EnaDis.Enabled)
                        btnCH1EnaDis.Enabled = true;
                }
            }

            if ((Define.seqMode[(byte)MODULE._PM1] == Define.MODE_PROCESS) && (Define.seqCtrl[(byte)MODULE._PM1] == Define.CTRL_WAIT))
            {
                if (labelCH1ProcessWait.ForeColor == Color.LightGray)
                    labelCH1ProcessWait.ForeColor = Color.Red;
                else
                    labelCH1ProcessWait.ForeColor = Color.LightGray;
            }
            else
            {
                if (labelCH1ProcessWait.ForeColor != Color.LightGray)
                    labelCH1ProcessWait.ForeColor = Color.LightGray;
            }

            if (Global.prcsInfo.prcsRecipeName[(byte)MODULE._PM1] != null)
                textBoxPM1RecipeName.Text = Global.prcsInfo.prcsRecipeName[(byte)MODULE._PM1];

            textBoxPM1StepNum.Text = Global.prcsInfo.prcsCurrentStep[(byte)MODULE._PM1].ToString() + " / " + Global.prcsInfo.prcsTotalStep[(byte)MODULE._PM1];

            if (Global.prcsInfo.prcsStepName[(byte)MODULE._PM1] != null)
                textBoxPM1StepName.Text = Global.prcsInfo.prcsStepName[(byte)MODULE._PM1];

            textBoxPM1ProcessTime.Text = Global.prcsInfo.prcsStepCurrentTime[(byte)MODULE._PM1].ToString("0") + " / " + Global.prcsInfo.prcsStepTotalTime[(byte)MODULE._PM1].ToString();
            textBoxPM1ProcessEndTime.Text = Global.prcsInfo.prcsEndTime[(byte)MODULE._PM1];
            

            if (Global.GetDigValue((int)DigInputList.CH1_Cylinder_Fwd_i) == "Off")                
            {                
                if (PM1CylinderFWDSns.BackColor != Color.Lime)
                    PM1CylinderFWDSns.BackColor = Color.Lime;                
            }
            else
            {
                if (PM1CylinderFWDSns.BackColor != Color.Silver)
                    PM1CylinderFWDSns.BackColor = Color.Silver;
            }

            if (Global.GetDigValue((int)DigInputList.CH1_Cylinder_Bwd_i) == "On")               
            {                                
                if (PM1CylinderBWDSns.BackColor != Color.Lime)
                    PM1CylinderBWDSns.BackColor = Color.Lime;                
            }
            else
            {
                if (PM1CylinderBWDSns.BackColor != Color.Silver)
                    PM1CylinderBWDSns.BackColor = Color.Silver;
            }

            if (Global.GetDigValue((int)DigInputList.CH1_Cylinder_Home_i) == "Off")
            {                
                if (PM1CylinderHomeSns.BackColor != Color.Lime)
                    PM1CylinderHomeSns.BackColor = Color.Lime;
            }
            else
            {                                
                if (PM1CylinderHomeSns.BackColor != Color.Silver)
                    PM1CylinderHomeSns.BackColor = Color.Silver;
            }

            if (Global.GetDigValue((int)DigInputList.CH1_Door_Sensor_i) == "Off")
            {
                textBoxCH1Door.Text = "Open";
                textBoxCH1Door.BackColor = Color.OrangeRed;
            }
            else if (Global.GetDigValue((int)DigInputList.CH1_Door_Sensor_i) == "On")
            {
                textBoxCH1Door.Text = "Close";
                textBoxCH1Door.BackColor = Color.LightSkyBlue;
            }

            if (Global.digSet.curDigSet[(int)DigOutputList.CH1_WaterValve_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.CH1_WaterValve_o] == "On")
                {
                    if (!PM1Water1.Visible)
                        PM1Water1.Visible = true;
                    else
                        PM1Water1.Visible = false;

                    if (!PM1Water2.Visible)
                        PM1Water2.Visible = true;
                    else
                        PM1Water2.Visible = false;
                }
                else
                {
                    if (PM1Water1.Visible != false)
                        PM1Water1.Visible = false;

                    if (PM1Water2.Visible != false)
                        PM1Water2.Visible = false;
                }
            }

            if (Global.digSet.curDigSet[(int)DigOutputList.CH1_Air_Knife_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.CH1_Air_Knife_o] == "On")
                {
                    if (!PM1Airknife.Visible)
                        PM1Airknife.Visible = true;
                    else
                        PM1Airknife.Visible = false;
                }
                else
                {
                    if (PM1Airknife.Visible != false)
                        PM1Airknife.Visible = false;
                }
            }

            if (Global.digSet.curDigSet[(int)DigOutputList.CH1_Curtain_AirValve_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.CH1_Curtain_AirValve_o] == "On")
                {
                    if (!PM1LeftAir.Visible)
                        PM1LeftAir.Visible = true;
                    else
                        PM1LeftAir.Visible = false;

                    if (!PM1RightAir.Visible)
                        PM1RightAir.Visible = true;
                    else
                        PM1RightAir.Visible = false;
                }
                else
                {
                    if (PM1LeftAir.Visible != false)
                        PM1LeftAir.Visible = false;

                    if (PM1RightAir.Visible != false)
                        PM1RightAir.Visible = false;
                }
            }            

            if (Global.digSet.curDigSet[(int)DigOutputList.CH1_Pin_UpDn_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.CH1_Pin_UpDn_o] == "On")
                {
                    if (PM1PinUpSns.BackColor != Color.Lime)
                        PM1PinUpSns.BackColor = Color.Lime;

                    if (PM1PinDownSns.BackColor != Color.Silver)
                        PM1PinDownSns.BackColor = Color.Silver;
                }
                else
                {
                    if (PM1PinUpSns.BackColor != Color.Silver)
                        PM1PinUpSns.BackColor = Color.Silver;

                    if (PM1PinDownSns.BackColor != Color.Lime)
                        PM1PinDownSns.BackColor = Color.Lime;
                }
            }


            // CH2 display
            if (Define.bChamberDisable[(byte)MODULE._PM2])
            {
                if (btnPM2Process.Enabled != false)
                    btnPM2Process.Enabled = false;

                if (btnPM2Retry.Enabled != false)
                    btnPM2Retry.Enabled = false;

                if (btnPM2Abort.Enabled != false)
                    btnPM2Abort.Enabled = false;

                if (btnPM2Init.Enabled != false)
                    btnPM2Init.Enabled = false;

                if (btnPM2InitStop.Enabled != false)
                    btnPM2InitStop.Enabled = false;
            }
            else
            {
                if (Define.seqMode[(byte)MODULE._PM2] == Define.MODE_PROCESS)
                {
                    if (Define.seqCtrl[(byte)MODULE._PM2] != Define.CTRL_IDLE)
                    {
                        if (btnPM2Process.Enabled != false)
                            btnPM2Process.Enabled = false;

                        if (Define.seqCtrl[(byte)MODULE._PM2] == Define.CTRL_ALARM)
                        {
                            if (btnPM2Process.BackColor != Color.Red)
                                btnPM2Process.BackColor = Color.Red;
                            else
                                btnPM2Process.BackColor = Color.Transparent;

                            if (!btnPM2Retry.Enabled)
                                btnPM2Retry.Enabled = true;
                        }
                        else
                        {
                            if (btnPM2Process.BackColor != Color.YellowGreen)
                                btnPM2Process.BackColor = Color.YellowGreen;
                            else
                                btnPM2Process.BackColor = Color.Transparent;

                            if (label_PM2Alarm.Text != "--")
                                label_PM2Alarm.Text = "--";

                            if (btnPM2Retry.Enabled != false)
                                btnPM2Retry.Enabled = false;
                        }

                        if (!btnPM2Abort.Enabled)
                            btnPM2Abort.Enabled = true;


                        if (btnPM2Init.Enabled != false)
                            btnPM2Init.Enabled = false;

                        if (btnPM2InitStop.Enabled != false)
                            btnPM2InitStop.Enabled = false;

                        if (btnPM2Init.BackColor != Color.Transparent)
                            btnPM2Init.BackColor = Color.Transparent;

                        if (btnCH2EnaDis.Enabled != false)
                            btnCH2EnaDis.Enabled = false;
                    }
                }
                else if (Define.seqMode[(byte)MODULE._PM2] == Define.MODE_INIT)
                {
                    if (Define.seqCtrl[(byte)MODULE._PM2] != Define.CTRL_IDLE)
                    {
                        if (btnPM2Init.Enabled != false)
                            btnPM2Init.Enabled = false;

                        if (Define.seqCtrl[(byte)MODULE._PM2] == Define.CTRL_ALARM)
                        {
                            if (btnPM2Init.BackColor != Color.Red)
                                btnPM2Init.BackColor = Color.Red;
                            else
                                btnPM2Init.BackColor = Color.Transparent;
                        }
                        else
                        {
                            if (btnPM2Init.BackColor != Color.YellowGreen)
                                btnPM2Init.BackColor = Color.YellowGreen;
                            else
                                btnPM2Init.BackColor = Color.Transparent;

                            if (label_PM2Alarm.Text != "--")
                                label_PM2Alarm.Text = "--";
                        }

                        if (!btnPM2InitStop.Enabled)
                            btnPM2InitStop.Enabled = true;


                        if (btnPM2Process.Enabled != false)
                            btnPM2Process.Enabled = false;

                        if (btnPM2Retry.Enabled != false)
                            btnPM2Retry.Enabled = false;

                        if (btnPM2Abort.Enabled != false)
                            btnPM2Abort.Enabled = false;

                        if (btnPM2Process.BackColor != Color.Transparent)
                            btnPM2Process.BackColor = Color.Transparent;

                        if (btnCH2EnaDis.Enabled != false)
                            btnCH2EnaDis.Enabled = false;
                    }
                }
                else if (Define.seqMode[(byte)MODULE._PM2] == Define.MODE_IDLE)
                {
                    if (!btnPM2Process.Enabled)
                        btnPM2Process.Enabled = true;

                    if (btnPM2Process.BackColor != Color.Transparent)
                        btnPM2Process.BackColor = Color.Transparent;

                    if (btnPM2Retry.Enabled != false)
                        btnPM2Retry.Enabled = false;

                    if (btnPM2Abort.Enabled != false)
                        btnPM2Abort.Enabled = false;

                    if (label_PM2Alarm.Text != "--")
                        label_PM2Alarm.Text = "--";

                    if (!btnPM2Init.Enabled)
                        btnPM2Init.Enabled = true;

                    if (btnPM2InitStop.Enabled != false)
                        btnPM2InitStop.Enabled = false;

                    if (btnPM2Init.BackColor != Color.Transparent)
                        btnPM2Init.BackColor = Color.Transparent;

                    if (!btnCH2EnaDis.Enabled)
                        btnCH2EnaDis.Enabled = true;
                }
            }

            if ((Define.seqMode[(byte)MODULE._PM2] == Define.MODE_PROCESS) && (Define.seqCtrl[(byte)MODULE._PM2] == Define.CTRL_WAIT))
            {
                if (labelCH2ProcessWait.ForeColor == Color.LightGray)
                    labelCH2ProcessWait.ForeColor = Color.Red;
                else
                    labelCH2ProcessWait.ForeColor = Color.LightGray;
            }
            else
            {
                if (labelCH2ProcessWait.ForeColor != Color.LightGray)
                    labelCH2ProcessWait.ForeColor = Color.LightGray;
            }

            if (Global.prcsInfo.prcsRecipeName[(byte)MODULE._PM2] != null)
                textBoxPM2RecipeName.Text = Global.prcsInfo.prcsRecipeName[(byte)MODULE._PM2];

            textBoxPM2StepNum.Text = Global.prcsInfo.prcsCurrentStep[(byte)MODULE._PM2].ToString() + " / " + Global.prcsInfo.prcsTotalStep[(byte)MODULE._PM2];

            if (Global.prcsInfo.prcsStepName[(byte)MODULE._PM2] != null)
                textBoxPM2StepName.Text = Global.prcsInfo.prcsStepName[(byte)MODULE._PM2];

            textBoxPM2ProcessTime.Text = Global.prcsInfo.prcsStepCurrentTime[(byte)MODULE._PM2].ToString("0") + " / " + Global.prcsInfo.prcsStepTotalTime[(byte)MODULE._PM2].ToString();
            textBoxPM2ProcessEndTime.Text = Global.prcsInfo.prcsEndTime[(byte)MODULE._PM2];


            if (Global.GetDigValue((int)DigInputList.CH2_Cylinder_Fwd_i) == "Off")
            {
                if (PM2CylinderFWDSns.BackColor != Color.Lime)
                    PM2CylinderFWDSns.BackColor = Color.Lime;
            }
            else
            {
                if (PM2CylinderFWDSns.BackColor != Color.Silver)
                    PM2CylinderFWDSns.BackColor = Color.Silver;
            }

            if (Global.GetDigValue((int)DigInputList.CH2_Cylinder_Bwd_i) == "On")
            {
                if (PM2CylinderBWDSns.BackColor != Color.Lime)
                    PM2CylinderBWDSns.BackColor = Color.Lime;
            }
            else
            {
                if (PM2CylinderBWDSns.BackColor != Color.Silver)
                    PM2CylinderBWDSns.BackColor = Color.Silver;
            }

            if (Global.GetDigValue((int)DigInputList.CH2_Cylinder_Home_i) == "Off")
            {
                if (PM2CylinderHomeSns.BackColor != Color.Lime)
                    PM2CylinderHomeSns.BackColor = Color.Lime;
            }
            else
            {
                if (PM2CylinderHomeSns.BackColor != Color.Silver)
                    PM2CylinderHomeSns.BackColor = Color.Silver;
            }

            if (Global.GetDigValue((int)DigInputList.CH2_Door_Sensor_i) == "Off")
            {
                textBoxCH2Door.Text = "Open";
                textBoxCH2Door.BackColor = Color.OrangeRed;
            }
            else if (Global.GetDigValue((int)DigInputList.CH2_Door_Sensor_i) == "On")
            {
                textBoxCH2Door.Text = "Close";
                textBoxCH2Door.BackColor = Color.LightSkyBlue;
            }

            if (Global.digSet.curDigSet[(int)DigOutputList.CH2_WaterValve_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.CH2_WaterValve_o] == "On")
                {
                    if (!PM2Water1.Visible)
                        PM2Water1.Visible = true;
                    else
                        PM2Water1.Visible = false;

                    if (!PM2Water2.Visible)
                        PM2Water2.Visible = true;
                    else
                        PM2Water2.Visible = false;
                }
                else
                {
                    if (PM2Water1.Visible != false)
                        PM2Water1.Visible = false;

                    if (PM2Water2.Visible != false)
                        PM2Water2.Visible = false;
                }
            }

            if (Global.digSet.curDigSet[(int)DigOutputList.CH2_Air_Knife_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.CH2_Air_Knife_o] == "On")
                {
                    if (!PM2Airknife.Visible)
                        PM2Airknife.Visible = true;
                    else
                        PM2Airknife.Visible = false;
                }
                else
                {
                    if (PM2Airknife.Visible != false)
                        PM2Airknife.Visible = false;
                }
            }

            if (Global.digSet.curDigSet[(int)DigOutputList.CH2_Curtain_AirValve_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.CH2_Curtain_AirValve_o] == "On")
                {
                    if (!PM2LeftAir.Visible)
                        PM2LeftAir.Visible = true;
                    else
                        PM2LeftAir.Visible = false;

                    if (!PM2RightAir.Visible)
                        PM2RightAir.Visible = true;
                    else
                        PM2RightAir.Visible = false;
                }
                else
                {
                    if (PM2LeftAir.Visible != false)
                        PM2LeftAir.Visible = false;

                    if (PM2RightAir.Visible != false)
                        PM2RightAir.Visible = false;
                }
            }            

            if (Global.digSet.curDigSet[(int)DigOutputList.CH2_Pin_UpDn_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.CH2_Pin_UpDn_o] == "On")
                {
                    if (PM2PinUpSns.BackColor != Color.Lime)
                        PM2PinUpSns.BackColor = Color.Lime;

                    if (PM2PinDownSns.BackColor != Color.Silver)
                        PM2PinDownSns.BackColor = Color.Silver;
                }
                else
                {
                    if (PM2PinUpSns.BackColor != Color.Silver)
                        PM2PinUpSns.BackColor = Color.Silver;

                    if (PM2PinDownSns.BackColor != Color.Lime)
                        PM2PinDownSns.BackColor = Color.Lime;
                }
            }


            // CH3 display
            if (Define.bChamberDisable[(byte)MODULE._PM3])
            {
                if (btnPM3Process.Enabled != false)
                    btnPM3Process.Enabled = false;

                if (btnPM3Retry.Enabled != false)
                    btnPM3Retry.Enabled = false;

                if (btnPM3Abort.Enabled != false)
                    btnPM3Abort.Enabled = false;

                if (btnPM3Init.Enabled != false)
                    btnPM3Init.Enabled = false;

                if (btnPM3InitStop.Enabled != false)
                    btnPM3InitStop.Enabled = false;
            }
            else
            {
                if (Define.seqMode[(byte)MODULE._PM3] == Define.MODE_PROCESS)
                {
                    if (Define.seqCtrl[(byte)MODULE._PM3] != Define.CTRL_IDLE)
                    {
                        if (btnPM3Process.Enabled != false)
                            btnPM3Process.Enabled = false;

                        if (Define.seqCtrl[(byte)MODULE._PM3] == Define.CTRL_ALARM)
                        {
                            if (btnPM3Process.BackColor != Color.Red)
                                btnPM3Process.BackColor = Color.Red;
                            else
                                btnPM3Process.BackColor = Color.Transparent;

                            if (!btnPM3Retry.Enabled)
                                btnPM3Retry.Enabled = true;
                        }
                        else
                        {
                            if (btnPM3Process.BackColor != Color.YellowGreen)
                                btnPM3Process.BackColor = Color.YellowGreen;
                            else
                                btnPM3Process.BackColor = Color.Transparent;

                            if (label_PM3Alarm.Text != "--")
                                label_PM3Alarm.Text = "--";

                            if (btnPM3Retry.Enabled != false)
                                btnPM3Retry.Enabled = false;
                        }

                        if (!btnPM3Abort.Enabled)
                            btnPM3Abort.Enabled = true;


                        if (btnPM3Init.Enabled != false)
                            btnPM3Init.Enabled = false;

                        if (btnPM3InitStop.Enabled != false)
                            btnPM3InitStop.Enabled = false;

                        if (btnPM3Init.BackColor != Color.Transparent)
                            btnPM3Init.BackColor = Color.Transparent;

                        if (btnCH3EnaDis.Enabled != false)
                            btnCH3EnaDis.Enabled = false;
                    }
                }
                else if (Define.seqMode[(byte)MODULE._PM3] == Define.MODE_INIT)
                {
                    if (Define.seqCtrl[(byte)MODULE._PM3] != Define.CTRL_IDLE)
                    {
                        if (btnPM3Init.Enabled != false)
                            btnPM3Init.Enabled = false;

                        if (Define.seqCtrl[(byte)MODULE._PM3] == Define.CTRL_ALARM)
                        {
                            if (btnPM3Init.BackColor != Color.Red)
                                btnPM3Init.BackColor = Color.Red;
                            else
                                btnPM3Init.BackColor = Color.Transparent;
                        }
                        else
                        {
                            if (btnPM3Init.BackColor != Color.YellowGreen)
                                btnPM3Init.BackColor = Color.YellowGreen;
                            else
                                btnPM3Init.BackColor = Color.Transparent;

                            if (label_PM3Alarm.Text != "--")
                                label_PM3Alarm.Text = "--";
                        }

                        if (!btnPM3InitStop.Enabled)
                            btnPM3InitStop.Enabled = true;


                        if (btnPM3Process.Enabled != false)
                            btnPM3Process.Enabled = false;

                        if (btnPM3Retry.Enabled != false)
                            btnPM3Retry.Enabled = false;

                        if (btnPM3Abort.Enabled != false)
                            btnPM3Abort.Enabled = false;

                        if (btnPM3Process.BackColor != Color.Transparent)
                            btnPM3Process.BackColor = Color.Transparent;

                        if (btnCH3EnaDis.Enabled != false)
                            btnCH3EnaDis.Enabled = false;
                    }
                }
                else if (Define.seqMode[(byte)MODULE._PM3] == Define.MODE_IDLE)
                {
                    if (!btnPM3Process.Enabled)
                        btnPM3Process.Enabled = true;

                    if (btnPM3Process.BackColor != Color.Transparent)
                        btnPM3Process.BackColor = Color.Transparent;

                    if (btnPM3Retry.Enabled != false)
                        btnPM3Retry.Enabled = false;

                    if (btnPM3Abort.Enabled != false)
                        btnPM3Abort.Enabled = false;

                    if (label_PM3Alarm.Text != "--")
                        label_PM3Alarm.Text = "--";

                    if (!btnPM3Init.Enabled)
                        btnPM3Init.Enabled = true;

                    if (btnPM3InitStop.Enabled != false)
                        btnPM3InitStop.Enabled = false;

                    if (btnPM3Init.BackColor != Color.Transparent)
                        btnPM3Init.BackColor = Color.Transparent;

                    if (!btnCH3EnaDis.Enabled)
                        btnCH3EnaDis.Enabled = true;
                }
            }

            if ((Define.seqMode[(byte)MODULE._PM3] == Define.MODE_PROCESS) && (Define.seqCtrl[(byte)MODULE._PM3] == Define.CTRL_WAIT))
            {
                if (labelCH3ProcessWait.ForeColor == Color.LightGray)
                    labelCH3ProcessWait.ForeColor = Color.Red;
                else
                    labelCH3ProcessWait.ForeColor = Color.LightGray;
            }
            else
            {
                if (labelCH3ProcessWait.ForeColor != Color.LightGray)
                    labelCH3ProcessWait.ForeColor = Color.LightGray;
            }

            if (Global.prcsInfo.prcsRecipeName[(byte)MODULE._PM3] != null)
                textBoxPM3RecipeName.Text = Global.prcsInfo.prcsRecipeName[(byte)MODULE._PM3];

            textBoxPM3StepNum.Text = Global.prcsInfo.prcsCurrentStep[(byte)MODULE._PM3].ToString() + " / " + Global.prcsInfo.prcsTotalStep[(byte)MODULE._PM3];

            if (Global.prcsInfo.prcsStepName[(byte)MODULE._PM3] != null)
                textBoxPM3StepName.Text = Global.prcsInfo.prcsStepName[(byte)MODULE._PM3];

            textBoxPM3ProcessTime.Text = Global.prcsInfo.prcsStepCurrentTime[(byte)MODULE._PM3].ToString("0") + " / " + Global.prcsInfo.prcsStepTotalTime[(byte)MODULE._PM3].ToString();
            textBoxPM3ProcessEndTime.Text = Global.prcsInfo.prcsEndTime[(byte)MODULE._PM3];


            if (Global.GetDigValue((int)DigInputList.CH3_Cylinder_Fwd_i) == "Off")
            {
                if (PM3CylinderFWDSns.BackColor != Color.Lime)
                    PM3CylinderFWDSns.BackColor = Color.Lime;
            }
            else
            {
                if (PM3CylinderFWDSns.BackColor != Color.Silver)
                    PM3CylinderFWDSns.BackColor = Color.Silver;
            }

            if (Global.GetDigValue((int)DigInputList.CH3_Cylinder_Bwd_i) == "On")
            {
                if (PM3CylinderBWDSns.BackColor != Color.Lime)
                    PM3CylinderBWDSns.BackColor = Color.Lime;
            }
            else
            {
                if (PM3CylinderBWDSns.BackColor != Color.Silver)
                    PM3CylinderBWDSns.BackColor = Color.Silver;
            }

            if (Global.GetDigValue((int)DigInputList.CH3_Cylinder_Home_i) == "Off")
            {
                if (PM3CylinderHomeSns.BackColor != Color.Lime)
                    PM3CylinderHomeSns.BackColor = Color.Lime;
            }
            else
            {
                if (PM3CylinderHomeSns.BackColor != Color.Silver)
                    PM3CylinderHomeSns.BackColor = Color.Silver;
            }

            if (Global.GetDigValue((int)DigInputList.CH3_Door_Sensor_i) == "Off")
            {
                textBoxCH3Door.Text = "Open";
                textBoxCH3Door.BackColor = Color.OrangeRed;
            }
            else if (Global.GetDigValue((int)DigInputList.CH3_Door_Sensor_i) == "On")
            {
                textBoxCH3Door.Text = "Close";
                textBoxCH3Door.BackColor = Color.LightSkyBlue;
            }

            if (Global.digSet.curDigSet[(int)DigOutputList.CH3_WaterValve_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.CH3_WaterValve_o] == "On")
                {
                    if (!PM3Water1.Visible)
                        PM3Water1.Visible = true;
                    else
                        PM3Water1.Visible = false;

                    if (!PM3Water2.Visible)
                        PM3Water2.Visible = true;
                    else
                        PM3Water2.Visible = false;
                }
                else
                {
                    if (PM3Water1.Visible != false)
                        PM3Water1.Visible = false;

                    if (PM3Water2.Visible != false)
                        PM3Water2.Visible = false;
                }
            }

            if (Global.digSet.curDigSet[(int)DigOutputList.CH3_Air_Knife_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.CH3_Air_Knife_o] == "On")
                {
                    if (!PM3Airknife.Visible)
                        PM3Airknife.Visible = true;
                    else
                        PM3Airknife.Visible = false;
                }
                else
                {
                    if (PM3Airknife.Visible != false)
                        PM3Airknife.Visible = false;
                }
            }

            if (Global.digSet.curDigSet[(int)DigOutputList.CH3_Curtain_AirValve_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.CH3_Curtain_AirValve_o] == "On")
                {
                    if (!PM3LeftAir.Visible)
                        PM3LeftAir.Visible = true;
                    else
                        PM3LeftAir.Visible = false;

                    if (!PM3RightAir.Visible)
                        PM3RightAir.Visible = true;
                    else
                        PM3RightAir.Visible = false;
                }
                else
                {
                    if (PM3LeftAir.Visible != false)
                        PM3LeftAir.Visible = false;

                    if (PM3RightAir.Visible != false)
                        PM3RightAir.Visible = false;
                }
            }
            
            if (Global.digSet.curDigSet[(int)DigOutputList.CH3_Pin_UpDn_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.CH3_Pin_UpDn_o] == "On")
                {
                    if (PM3PinUpSns.BackColor != Color.Lime)
                        PM3PinUpSns.BackColor = Color.Lime;

                    if (PM3PinDownSns.BackColor != Color.Silver)
                        PM3PinDownSns.BackColor = Color.Silver;
                }
                else
                {
                    if (PM3PinUpSns.BackColor != Color.Silver)
                        PM3PinUpSns.BackColor = Color.Silver;

                    if (PM3PinDownSns.BackColor != Color.Lime)
                        PM3PinDownSns.BackColor = Color.Lime;
                }
            }


            // Hot water           
            if (Global.digSet.curDigSet[(int)DigOutputList.Hot_Water_Pump_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.Hot_Water_Pump_o] == "On")
                {
                    textBoxWaterPump.Text = "On";
                }
                else
                {
                    textBoxWaterPump.Text = "Off";
                }
            }

            if (Global.digSet.curDigSet[(int)DigOutputList.Hot_WaterHeater_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.Hot_WaterHeater_o] == "On")
                {
                    textBoxWaterHeater.Text = "On";
                }
                else
                {
                    textBoxWaterHeater.Text = "Off";
                }
            }

            if (Global.digSet.curDigSet[(int)DigOutputList.Main_Water_Supply] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.Main_Water_Supply] == "On")
                {
                    textBoxWaterSupply.Text = "Open";
                }
                else
                {
                    textBoxWaterSupply.Text = "Close";
                }
            }

            textBoxWaterTemp.Text = HanyoungNXClassLibrary.Define.temp_PV.ToString("0.0");


            // Daily count
            textBoxPM1DailyCnt.Text = Define.iPM1DailyCnt.ToString("00");
            textBoxPM2DailyCnt.Text = Define.iPM2DailyCnt.ToString("00");
            textBoxPM3DailyCnt.Text = Define.iPM3DailyCnt.ToString("00");

            // Chamber Enable/Disable
            if (Define.bChamberDisable[(byte)MODULE._PM1])
            {
                btnCH1EnaDis.Text = "Enable";
                btnCH1EnaDis.ForeColor = Color.ForestGreen;
                imgCH1EnaDis.Visible = true;
            }
            else
            {
                btnCH1EnaDis.Text = "Disable";
                btnCH1EnaDis.ForeColor = Color.Red;
                imgCH1EnaDis.Visible = false;
            }

            if (Define.bChamberDisable[(byte)MODULE._PM2])
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

            if (Define.bChamberDisable[(byte)MODULE._PM3])
            {
                btnCH3EnaDis.Text = "Enable";
                btnCH3EnaDis.ForeColor = Color.ForestGreen;
                imgCH3EnaDis.Visible = true;
            }
            else
            {
                btnCH3EnaDis.Text = "Disable";
                btnCH3EnaDis.ForeColor = Color.Red;
                imgCH3EnaDis.Visible = false;
            }
        }

        private void Eventlog_Display(object sender, ElapsedEventArgs e)
        {
            if (Define.bPM1OpAlmEvent)
            {
                Alarmlog_File_Read("PM1");
            }

            if (Define.bPM2OpAlmEvent)
            {
                Alarmlog_File_Read("PM2");
            }

            if (Define.bPM3OpAlmEvent)
            {
                Alarmlog_File_Read("PM3");
            }
        }

        private void Alarmlog_File_Read(string ModuleName)
        {
            if (Define.bPM1OpAlmEvent)
            {
                Define.bPM1OpAlmEvent = false;
            }

            if (Define.bPM2OpAlmEvent)
            {
                Define.bPM2OpAlmEvent = false;
            }

            if (Define.bPM3OpAlmEvent)
            {
                Define.bPM3OpAlmEvent = false;
            }

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
                                    if (ModuleName == "PM1")
                                    {
                                        label_PM1Alarm.Text = sVal;
                                    }
                                    else if (ModuleName == "PM2")
                                    {
                                        label_PM2Alarm.Text = sVal;
                                    }
                                    else if (ModuleName == "PM3")
                                    {
                                        label_PM3Alarm.Text = sVal;
                                    }
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

        private void btnPM1Process_Click(object sender, EventArgs e)
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

                            if (Global.GetDigValue((int)DigInputList.CH1_Door_Sensor_i) == "Off")
                            {
                                MessageBox.Show("Chamber door is opened", "Notification");
                                return;
                            }
                        }

                        if (MessageBox.Show("Do you want to proceed with the process?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {    
                            if (Configure_List.bToolIDSkip)
                            {
                                Define.iSelectRecipeModule = (int)MODULE._PM1;

                                recipeSelectForm = new RecipeSelectForm();

                                if (recipeSelectForm.ShowDialog() == DialogResult.OK)
                                {
                                    Define.seqMode[(byte)MODULE._PM1] = Define.MODE_PROCESS;
                                    Define.seqCtrl[(byte)MODULE._PM1] = Define.CTRL_RUN;
                                    Define.seqSts[(byte)MODULE._PM1] = Define.STS_IDLE;
                                }
                            }
                            else
                            {
                                toolInfoRegistForm = new ToolInfoRegistForm();
                                toolInfoRegistForm.Init((int)MODULE._PM1);
                                if (toolInfoRegistForm.ShowDialog() == DialogResult.OK)
                                {
                                    Define.iSelectRecipeModule = (int)MODULE._PM1;

                                    recipeSelectForm = new RecipeSelectForm();

                                    if (recipeSelectForm.ShowDialog() == DialogResult.OK)
                                    {
                                        Define.seqMode[(byte)MODULE._PM1] = Define.MODE_PROCESS;
                                        Define.seqCtrl[(byte)MODULE._PM1] = Define.CTRL_RUN;
                                        Define.seqSts[(byte)MODULE._PM1] = Define.STS_IDLE;
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
                        }
                        
                        Define.seqCtrl[(byte)MODULE._PM1] = Define.CTRL_RETRY;                        
                    }
                    break;

                case "Stop":
                    {
                        if (MessageBox.Show("Do you want to stop the process?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Define.seqCtrl[(byte)MODULE._PM1] = Define.CTRL_ABORT;
                        }
                    }
                    break;
            }
        }

        private void btnPM2Process_Click(object sender, EventArgs e)
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
                                Define.iSelectRecipeModule = (int)MODULE._PM2;

                                recipeSelectForm = new RecipeSelectForm();

                                if (recipeSelectForm.ShowDialog() == DialogResult.OK)
                                {
                                    Define.seqMode[(byte)MODULE._PM2] = Define.MODE_PROCESS;
                                    Define.seqCtrl[(byte)MODULE._PM2] = Define.CTRL_RUN;
                                    Define.seqSts[(byte)MODULE._PM2] = Define.STS_IDLE;
                                }
                            }
                            else
                            {
                                toolInfoRegistForm = new ToolInfoRegistForm();
                                toolInfoRegistForm.Init((int)MODULE._PM2);
                                if (toolInfoRegistForm.ShowDialog() == DialogResult.OK)
                                {
                                    Define.iSelectRecipeModule = (int)MODULE._PM2;

                                    recipeSelectForm = new RecipeSelectForm();

                                    if (recipeSelectForm.ShowDialog() == DialogResult.OK)
                                    {
                                        Define.seqMode[(byte)MODULE._PM2] = Define.MODE_PROCESS;
                                        Define.seqCtrl[(byte)MODULE._PM2] = Define.CTRL_RUN;
                                        Define.seqSts[(byte)MODULE._PM2] = Define.STS_IDLE;
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
                        }
                        
                        Define.seqCtrl[(byte)MODULE._PM2] = Define.CTRL_RETRY;
                    }
                    break;

                case "Stop":
                    {
                        if (MessageBox.Show("Do you want to stop the process?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Define.seqCtrl[(byte)MODULE._PM2] = Define.CTRL_ABORT;
                        }
                    }
                    break;
            }
        }

        private void btnPM3Process_Click(object sender, EventArgs e)
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

                            if (Global.GetDigValue((int)DigInputList.CH3_Door_Sensor_i) == "Off")
                            {
                                MessageBox.Show("Chamber door is opened", "Notification");
                                return;
                            }
                        }

                        if (MessageBox.Show("Do you want to proceed with the process?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (Configure_List.bToolIDSkip)
                            {
                                Define.iSelectRecipeModule = (int)MODULE._PM3;

                                recipeSelectForm = new RecipeSelectForm();

                                if (recipeSelectForm.ShowDialog() == DialogResult.OK)
                                {
                                    Define.seqMode[(byte)MODULE._PM3] = Define.MODE_PROCESS;
                                    Define.seqCtrl[(byte)MODULE._PM3] = Define.CTRL_RUN;
                                    Define.seqSts[(byte)MODULE._PM3] = Define.STS_IDLE;
                                }
                            }
                            else
                            {
                                toolInfoRegistForm = new ToolInfoRegistForm();
                                toolInfoRegistForm.Init((int)MODULE._PM3);
                                if (toolInfoRegistForm.ShowDialog() == DialogResult.OK)
                                {
                                    Define.iSelectRecipeModule = (int)MODULE._PM3;

                                    recipeSelectForm = new RecipeSelectForm();

                                    if (recipeSelectForm.ShowDialog() == DialogResult.OK)
                                    {
                                        Define.seqMode[(byte)MODULE._PM3] = Define.MODE_PROCESS;
                                        Define.seqCtrl[(byte)MODULE._PM3] = Define.CTRL_RUN;
                                        Define.seqSts[(byte)MODULE._PM3] = Define.STS_IDLE;
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
                        }
                        
                        Define.seqCtrl[(byte)MODULE._PM3] = Define.CTRL_RETRY;
                    }
                    break;

                case "Stop":
                    {
                        if (MessageBox.Show("Do you want to stop the process?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Define.seqCtrl[(byte)MODULE._PM3] = Define.CTRL_ABORT;
                        }
                    }
                    break;
            }
        }

        private void btnPM1Init_Click(object sender, EventArgs e)
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
                        }

                        Define.seqMode[Convert.ToByte(btn.Tag)] = Define.MODE_INIT;
                        Define.seqCtrl[Convert.ToByte(btn.Tag)] = Define.CTRL_RUN;
                        Define.seqSts[Convert.ToByte(btn.Tag)] = Define.STS_IDLE;
                    }
                    break;                

                case "Stop":
                    {
                        Define.seqCtrl[Convert.ToByte(btn.Tag)] = Define.CTRL_ABORT;
                    }
                    break;
            }
        }

        private void btnCH1EnaDis_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (Define.bChamberDisable[Convert.ToByte(btn.Tag)])
                Define.bChamberDisable[Convert.ToByte(btn.Tag)] = false;
            else
                Define.bChamberDisable[Convert.ToByte(btn.Tag)] = true;
        }        
    }
}
