using Ajin_IO_driver;
using MsSqlManagerLibrary;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace FluxTool_CleanerSystem_K4_4
{
    public struct TStep
    {
        public bool Flag;
        public byte Layer;
        public double Times;

        public void INC_TIMES()
        {            
            Times++;
            Thread.Sleep(990);
        }

        public void INC_TIMES_10()
        {
            Times += 0.01;
        }

        public void INC_TIMES_100()
        {
            Times += 0.1;
        }
    }

    public class TBaseThread
    {
        public byte module;
        public string ModuleName;

        public TStep step;       
    }

    class Global
    {
        public static string userdataPath = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\UserData.accdb"));
        public static string logfilePath = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\EventLog\"));
        public static string alarmHistoryPath = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\AlarmHistory\"));
        public static string RecipeFilePath = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\Recipes"));
        public static string ConfigurePath = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\Configure\"));
        public static string serialPortInfoPath = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\"));
        public static string dailyCntfilePath = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\DailyCount\"));
        public static string toolHistoryfilePath = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\ToolHistory\"));
        
        public static string hostEquipmentInfo_Log = "K5EE_FluxtoolCleaningSystemLog_K4_4";

        private static Timer timer = new Timer();

        public static TDigSet digSet;
        public static TPrcsInfo prcsInfo;

        private static InterlockDisplayForm interlockDisplayForm;
        private static uint nSeqWaitCnt = 0;               

        #region 이벤트로그 파일 폴더 및 파일 생성       
        public static void EventLog(string Msg, string moduleName, string Mode)
        {
            string sYear = string.Format("{0:yyyy}", DateTime.Now).Trim();
            string sMonth = string.Format("{0:MM}", DateTime.Now).Trim();
            string sDay = string.Format("{0:dd}", DateTime.Now).Trim();
            string sDate = sYear + "-" + sMonth + "-" + sDay;
            string sTime = DateTime.Now.ToString("HH:mm:ss");
            string sDateTime;
            sDateTime = "[" + sDate + ", " + sTime + "] ";

            WriteFile(sDateTime + Msg, moduleName, Mode);

            if (Mode == "Event")
            {
                if (moduleName == "PM1")
                {
                    Define.bPM1Event = true;
                }

                if (moduleName == "PM2")
                {
                    Define.bPM2Event = true;
                }

                if (moduleName == "PM3")
                {
                    Define.bPM3Event = true;
                }

                if (moduleName == "WATERTANK")
                {
                    Define.bWaterTankEvent = true;
                }
            }
            else if (Mode == "Alarm")
            {
                if (moduleName == "PM1")
                {
                    Define.bPM1OpAlmEvent = true;
                    Define.bPM1AlmEvent = true;
                }

                if (moduleName == "PM2")
                {
                    Define.bPM2OpAlmEvent = true;
                    Define.bPM2AlmEvent = true;
                }

                if (moduleName == "PM3")
                {
                    Define.bPM3OpAlmEvent = true;
                    Define.bPM3AlmEvent = true;
                }

                if (moduleName == "WATERTANK")
                {
                    Define.bWaterTankAlmEvent = true;
                }
            }            
        }

        private static void WriteFile(string Msg, string moduleName, string Mode)
        {            
            string sYear = string.Format("{0:yyyy}", DateTime.Now).Trim();
            string sMonth = string.Format("{0:MM}", DateTime.Now).Trim();
            string sDay = string.Format("{0:dd}", DateTime.Now).Trim();
            string FileName = sDay + ".txt";
            string sPath = string.Empty;
            if (Mode == "Event")
            {
                sPath = logfilePath;
            }                
            else if (Mode == "Alarm")
            {
                sPath = alarmHistoryPath;
            }

            try
            {
                if (!Directory.Exists(sPath + moduleName + "\\" + sYear))
                {
                    CreateYearFolder(sPath + moduleName);
                }

                if (!Directory.Exists(sPath + moduleName + "\\" + sYear + "\\" + sMonth))
                {
                    CreateMonthFolder(sPath + moduleName);
                }

                if (File.Exists(sPath + moduleName + "\\" + sYear + "\\" + sMonth + "\\" + FileName))
                {
                    StreamWriter writer;
                    writer = File.AppendText(sPath + moduleName + "\\" + sYear + "\\" + sMonth + "\\" + FileName);
                    writer.WriteLine(Msg);
                    writer.Close();
                }
                else
                {
                    CreateFile(sPath + moduleName, Msg);

                    StreamWriter writer;
                    writer = File.AppendText(sPath + moduleName + "\\" + sYear + "\\" + sMonth + "\\" + FileName);
                    writer.WriteLine(Msg);
                    writer.Close();
                }
            }
            catch (IOException)
            {
                
            }
        }

        private static void CreateYearFolder(string Path)
        {
            string sYear = string.Format("{0:yyyy}", DateTime.Now).Trim();
            string FolderName = sYear;

            Directory.CreateDirectory(Path + "\\" + FolderName);
        }

        private static void CreateMonthFolder(string Path)
        {
            string sYear = string.Format("{0:yyyy}", DateTime.Now).Trim();
            string sMonth = string.Format("{0:MM}", DateTime.Now).Trim();
            string FolderName = sMonth;

            Directory.CreateDirectory(Path + "\\" + sYear + "\\" + FolderName);
        }

        private static void CreateFile(string Path, string Msg)
        {           
            string sYear = string.Format("{0:yyyy}", DateTime.Now).Trim();
            string sMonth = string.Format("{0:MM}", DateTime.Now).Trim();
            string sDay = string.Format("{0:dd}", DateTime.Now).Trim();
            string FileName = sDay + ".txt";

            if (!File.Exists(Path + "\\" + sYear + "\\" + sMonth + "\\" + FileName))
            {
                using (File.Create(Path + "\\" + sYear + "\\" + sMonth + "\\" + FileName)) ;                
            }
        }
        #endregion

        #region Daily count 폴더 및 파일 생성
        public static void DailyLog(int iCnt, string moduleName)
        {
            string sYear = string.Format("{0:yyyy}", DateTime.Now).Trim();
            string sMonth = string.Format("{0:MM}", DateTime.Now).Trim();
            string sDay = string.Format("{0:dd}", DateTime.Now).Trim();
            string FileName = sDay + ".txt";
            string sPath = dailyCntfilePath;

            try
            {
                if (!Directory.Exists(sPath + moduleName + "\\" + sYear))
                {
                    CreateYearFolder(sPath + moduleName);
                }

                if (!Directory.Exists(sPath + moduleName + "\\" + sYear + "\\" + sMonth))
                {
                    CreateMonthFolder(sPath + moduleName);
                }

                if (File.Exists(sPath + moduleName + "\\" + sYear + "\\" + sMonth + "\\" + FileName))
                {
                    StreamWriter writer;
                    //writer = File.AppendText(sPath + moduleName + "\\" + sYear + "\\" + sMonth + "\\" + FileName);                    
                    writer = File.CreateText(sPath + moduleName + "\\" + sYear + "\\" + sMonth + "\\" + FileName);
                    writer.Write(iCnt);
                    writer.Close();
                }
                else
                {
                    CreateFile(sPath + moduleName, "");

                    StreamWriter writer;
                    //writer = File.AppendText(sPath + moduleName + "\\" + sYear + "\\" + sMonth + "\\" + FileName);                    
                    writer = File.CreateText(sPath + moduleName + "\\" + sYear + "\\" + sMonth + "\\" + FileName);
                    writer.Write(iCnt);
                    writer.Close();
                }
            }
            catch (IOException)
            {

            }
        }
        #endregion

        public static void Init()
        {
            digSet.curDigSet = new string[64];
            for (int i = 0; i < 64; i++)
            {
                digSet.curDigSet[i] = DIOClass.doVal.readDigOut[i];
            }

            prcsInfo.prcsRecipeName = new string[Define.MODULE_MAX - 1];
            prcsInfo.prcsCurrentStep = new int[Define.MODULE_MAX - 1];
            prcsInfo.prcsTotalStep = new int[Define.MODULE_MAX - 1];
            prcsInfo.prcsStepName = new string[Define.MODULE_MAX - 1];
            prcsInfo.prcsStepCurrentTime = new double[Define.MODULE_MAX - 1];
            prcsInfo.prcsStepTotalTime = new double[Define.MODULE_MAX - 1];
            prcsInfo.prcsEndTime = new string[Define.MODULE_MAX - 1];

            for (int nModuleCnt = 0; nModuleCnt < Define.MODULE_MAX - 1; nModuleCnt++)
            {
                prcsInfo.prcsRecipeName[nModuleCnt] = string.Empty;
                prcsInfo.prcsCurrentStep[nModuleCnt] = 0;
                prcsInfo.prcsTotalStep[nModuleCnt] = 0;
                prcsInfo.prcsStepName[nModuleCnt] = string.Empty;
                prcsInfo.prcsStepCurrentTime[nModuleCnt] = 1;
                prcsInfo.prcsStepTotalTime[nModuleCnt] = 0;
                prcsInfo.prcsEndTime[nModuleCnt] = string.Empty;
            }

            interlockDisplayForm = new InterlockDisplayForm();            

            timer.Interval = 100;
            timer.Elapsed += new ElapsedEventHandler(VALUE_INTERLOCK_CHECK);
            timer.Start();            

            GetDailyLogCount("PM1");
            GetDailyLogCount("PM2");
            GetDailyLogCount("PM3");

            string strRtn = HostConnection.Connect();
            if (strRtn != "OK")
                MessageBox.Show("EE 서버 접속에 실패했습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void GetDailyLogCount(string moduleName)
        {
            string sTmpData;
            string sYear = string.Format("{0:yyyy}", DateTime.Now).Trim();
            string sMonth = string.Format("{0:MM}", DateTime.Now).Trim();
            string sDay = string.Format("{0:dd}", DateTime.Now).Trim();
            string FileName = string.Format("{0}.txt", sDay);
            string sPath = string.Format("{0}{1}\\{2}\\{3}\\{4}", dailyCntfilePath, moduleName, sYear, sMonth, FileName);

            try
            {
                if (File.Exists(sPath))
                {
                    byte[] bytes;
                    using (var fs = File.Open(sPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        bytes = new byte[fs.Length];
                        fs.Read(bytes, 0, (int)fs.Length);
                        sTmpData = Encoding.Default.GetString(bytes);

                        char sp = ',';
                        string[] spString = sTmpData.Split(sp);
                        for (int i = 0; i < spString.Length; i++)
                        {
                            if (moduleName == "PM1")
                            {
                                Define.iPM1DailyCnt = int.Parse(spString[0]);                                
                            }
                            else if (moduleName == "PM2")
                            {
                                Define.iPM2DailyCnt = int.Parse(spString[0]);                                
                            }
                            else if (moduleName == "PM3")
                            {
                                Define.iPM3DailyCnt = int.Parse(spString[0]);                                
                            }
                        }
                    }
                }                
            }
            catch (Exception)
            {
                
            }            
        }

        public static string GetDigValue(int ioName)
        {
            try
            {
                if ((0 <= ioName) && (15 >= ioName))
                {
                    if (DIOClass.diVal.checkHigh[ioName] != null)
                    {
                        return DIOClass.diVal.checkHigh[ioName];
                    }                        
                    else
                    {
                        return "Off";
                    }                        
                }
                else if ((16 <= ioName) && (32 >= ioName))
                {
                    if (DIOClass.diVal.checkLow[ioName - 16] != null)
                    {
                        return DIOClass.diVal.checkLow[ioName - 16];
                    }                        
                    else
                    {
                        return "Off";
                    }                        
                }
                else
                {
                    return "Off";
                }
            }
            catch (IOException)
            {
                return "Off";
            }
        }        

        public static void SetDigValue(int ioName, uint setValue, string ModuleName)
        {
            try
            {
                string retMsg = string.Empty;

                if (SETPOINT_INTERLOCK_CHECK(ioName, setValue, ModuleName, ref retMsg))
                {
                    if ((0 <= ioName) && (31 >= ioName))
                    {
                        DIOClass.SelectHighIndex(ioName, setValue);
                    }
                    else if ((32 <= ioName) && (63 >= ioName))
                    {
                        DIOClass.SelectHighIndex2(ioName, setValue);
                    }
                    
                    IO_StrToInt.io_code = ioName.ToString();
                    string IO_Name = IO_StrToInt.io_code;
                    if (setValue == 1)
                    {
                        digSet.curDigSet[ioName] = "On";
                        
                        if ((IO_Name == "Tower_Lamp_Red_o") ||
                            (IO_Name == "Tower_Lamp_Yellow_o") ||
                            (IO_Name == "Tower_Lamp_Green_o"))
                        {
                            //
                        }
                        else
                        {
                            EventLog(IO_Name + " : " + " On", ModuleName, "Event");                            
                        }                        
                    }
                    else
                    {
                        digSet.curDigSet[ioName] = "Off";

                        if ((IO_Name == "Tower_Lamp_Red_o") ||
                            (IO_Name == "Tower_Lamp_Yellow_o") ||
                            (IO_Name == "Tower_Lamp_Green_o"))
                        {
                            //
                        }
                        else
                        {
                            EventLog(IO_Name + " : " + " Off", ModuleName, "Event");
                        }
                    }
                }
                else
                {
                    MessageBox.Show(retMsg, "Interlock");
                }
            }
            catch (IOException)
            {
                
            }            
        }

        #region 항시 체크 인터락
        private static void VALUE_INTERLOCK_CHECK(object sender, ElapsedEventArgs e)
        {
            // Interlock이 해제 상태인지 체크
            if (!Define.bInterlockRelease)
            {
                if ((GetDigValue((int)DigInputList.EMO_Front_i) == "Off") ||
                    (GetDigValue((int)DigInputList.EMO_Rear_i) == "Off"))
                {
                    ALL_VALVE_CLOSE();
                    PROCESS_ABORT();

                    SetDigValue((int)DigOutputList.Buzzer_o, (uint)DigitalOffOn.On, "PM1");

                    Define.sInterlockMsg = "Emergency occurrence!";
                    Define.sInterlockChecklist = "Check the emergency switch";

                    DialogResult result = interlockDisplayForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Define.sInterlockMsg = "";
                        Define.sInterlockChecklist = "";
                    }                    
                }                

                if (GetDigValue((int)DigInputList.Front_Door_Sensor_i) == "Off")
                {
                    if (Define.sInterlockMsg == string.Empty)
                    {
                        Define.sInterlockMsg = "Front door is open!";
                        Define.sInterlockChecklist = "Check the front door sensor";

                        DialogResult result = interlockDisplayForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            Define.sInterlockMsg = "";
                            Define.sInterlockChecklist = "";
                        }
                    }

                    // 23'12.11 hspark 요청사항 추가
                    if (Configure_List.bFrontEnable)
                    {
                        PROCESS_ABORT();
                    }
                }                

                if (GetDigValue((int)DigInputList.Left_Door_Sensor_i) == "Off")
                {
                    if (Define.sInterlockMsg == string.Empty)
                    {
                        Define.sInterlockMsg = "Left door is open!";
                        Define.sInterlockChecklist = "Check the left door sensor";

                        DialogResult result = interlockDisplayForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            Define.sInterlockMsg = "";
                            Define.sInterlockChecklist = "";
                        }
                    }

                    // 23'12.11 hspark 요청사항 추가
                    if (Configure_List.bLeftEnable)
                    {
                        PROCESS_ABORT();
                    }
                }                

                if (GetDigValue((int)DigInputList.Right_Door_Sensor_i) == "Off")
                {
                    if (Define.sInterlockMsg == string.Empty)
                    {
                        Define.sInterlockMsg = "Right door is open!";
                        Define.sInterlockChecklist = "Check the right door sensor";

                        DialogResult result = interlockDisplayForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            Define.sInterlockMsg = "";
                            Define.sInterlockChecklist = "";
                        }
                    }

                    // 23'12.11 hspark 요청사항 추가
                    if (Configure_List.bRightEnable)
                    {
                        PROCESS_ABORT();
                    }
                }               

                if (GetDigValue((int)DigInputList.Back_Door_Sensor_i) == "Off")
                {
                    if (Define.sInterlockMsg == string.Empty)
                    {
                        Define.sInterlockMsg = "Back door is open!";
                        Define.sInterlockChecklist = "Check the back door sensor";

                        DialogResult result = interlockDisplayForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            Define.sInterlockMsg = "";
                            Define.sInterlockChecklist = "";
                        }
                    }

                    // 23'12.11 hspark 요청사항 추가
                    if (Configure_List.bBackEnable)
                    {
                        PROCESS_ABORT();
                    }
                }                


                // Water tank level 센서 체크 ////////////////////////////////////////////////////////////////                
                if (GetDigValue((int)DigInputList.Water_Level_High_i) == "Off")
                {
                    if (nSeqWaitCnt >= 30)     // 3초 대기
                    {
                        if (digSet.curDigSet[(int)DigOutputList.Main_Water_Supply] != "On")
                        {
                            SetDigValue((int)DigOutputList.Main_Water_Supply, (uint)DigitalOffOn.On, "PM1");
                        }

                        nSeqWaitCnt = 0;
                    }
                    else
                    {
                        nSeqWaitCnt++;
                    }
                }
                else
                {
                    if (digSet.curDigSet[(int)DigOutputList.Main_Water_Supply] != "Off")
                    {
                        SetDigValue((int)DigOutputList.Main_Water_Supply, (uint)DigitalOffOn.Off, "PM1");
                    }

                    if (nSeqWaitCnt != 0)
                        nSeqWaitCnt = 0;
                }
                
                if (GetDigValue((int)DigInputList.Water_Level_Low_i) == "On")
                {
                    if (digSet.curDigSet[(int)DigOutputList.Hot_WaterHeater_o] != null)
                    {
                        if (digSet.curDigSet[(int)DigOutputList.Hot_WaterHeater_o] != "Off")
                        {
                            SetDigValue((int)DigOutputList.Hot_WaterHeater_o, (uint)DigitalOffOn.Off, "PM1");
                        }
                    }

                    ALL_VALVE_CLOSE();
                    PROCESS_ABORT();

                    SetDigValue((int)DigOutputList.Buzzer_o, (uint)DigitalOffOn.On, "PM1");

                    Define.sInterlockMsg = "There is no water in the tank!";
                    Define.sInterlockChecklist = "Check the water tank sensor and supply valve";

                    DialogResult result = interlockDisplayForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Define.sInterlockMsg = "";
                        Define.sInterlockChecklist = "";
                    }                    
                }
                else
                {                    
                    if (HanyoungNXClassLibrary.Define.temp_PV <= Configure_List.Water_OverTempSet)
                    {
                        if ((GetDigValue((int)DigInputList.EMO_Front_i) == "On") &&
                            (GetDigValue((int)DigInputList.EMO_Rear_i) == "On"))
                        {
                            if (digSet.curDigSet[(int)DigOutputList.Hot_WaterHeater_o] != null)
                            {
                                if (digSet.curDigSet[(int)DigOutputList.Hot_WaterHeater_o] != "On")
                                {
                                    SetDigValue((int)DigOutputList.Hot_WaterHeater_o, (uint)DigitalOffOn.On, "PM1");
                                }
                            }                            
                        }
                    }
                    else
                    {
                        if (digSet.curDigSet[(int)DigOutputList.Hot_WaterHeater_o] != null)
                        {
                            if (digSet.curDigSet[(int)DigOutputList.Hot_WaterHeater_o] != "Off")
                            {
                                SetDigValue((int)DigOutputList.Hot_WaterHeater_o, (uint)DigitalOffOn.Off, "PM1");
                            }
                        }

                        if (Define.sInterlockMsg == string.Empty)
                        {
                            SetDigValue((int)DigOutputList.Buzzer_o, (uint)DigitalOffOn.On, "PM1");

                            Define.sInterlockMsg = "Water temperature is high!";
                            Define.sInterlockChecklist = "Check the water heater";

                            DialogResult result = interlockDisplayForm.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                Define.sInterlockMsg = "";
                                Define.sInterlockChecklist = "";
                            }                            
                        }                        
                    }
                }
                ////////////////////////////////////////////////////////////////////////////////////////////////  


                // 2024.02.19 hspark 추가
                // 공정 중 Cover open시, Buzzer on
                if ((Define.seqCtrl[(byte)MODULE._PM1] != Define.CTRL_IDLE) ||
                    (Define.seqCtrl[(byte)MODULE._PM2] != Define.CTRL_IDLE) ||
                    (Define.seqCtrl[(byte)MODULE._PM3] != Define.CTRL_IDLE))
                {
                    if ((GetDigValue((int)DigInputList.EMO_Front_i) == "On") &&         // 정상 상태
                        (GetDigValue((int)DigInputList.EMO_Rear_i) == "On") &&          // 정상 상태
                        (GetDigValue((int)DigInputList.Water_Level_Low_i) == "Off"))    // 정상 상태
                    {
                        if ((GetDigValue((int)DigInputList.Front_Door_Sensor_i) == "Off") ||
                            (GetDigValue((int)DigInputList.Left_Door_Sensor_i) == "Off") ||
                            (GetDigValue((int)DigInputList.Right_Door_Sensor_i) == "Off") ||
                            (GetDigValue((int)DigInputList.Back_Door_Sensor_i) == "Off"))
                        {
                            if (digSet.curDigSet[(int)DigOutputList.Buzzer_o] != null)
                            {
                                if (digSet.curDigSet[(int)DigOutputList.Buzzer_o] != "On")
                                    SetDigValue((int)DigOutputList.Buzzer_o, (uint)DigitalOffOn.On, "PM1");
                            }
                        }
                    }
                }
                ////////////////////////////////////////////////////////////////////////////////////////////////

                // 공정 중 Door open시, 시퀀스 Wait / 모터 Stop
                _F_DOOR_OPEN_SEQ();                                
            }


            // CH1~3 Water sol valve open 체크
            if ((digSet.curDigSet[(int)DigOutputList.CH1_WaterValve_o] == "On") ||
                (digSet.curDigSet[(int)DigOutputList.CH2_WaterValve_o] == "On") ||
                (digSet.curDigSet[(int)DigOutputList.CH3_WaterValve_o] == "On"))                
            {
                if (digSet.curDigSet[(int)DigOutputList.Hot_Water_Pump_o] != "On")
                {
                    SetDigValue((int)DigOutputList.Hot_Water_Pump_o, (uint)DigitalOffOn.On, "PM1");
                }                
            }
            else
            {
                if ( (Define.seqCtrl[(byte)MODULE._PM1] != Define.CTRL_RUNNING) &&
                     (Define.seqCtrl[(byte)MODULE._PM2] != Define.CTRL_RUNNING) &&
                     (Define.seqCtrl[(byte)MODULE._PM3] != Define.CTRL_RUNNING) )
                {
                    if (digSet.curDigSet[(int)DigOutputList.Hot_Water_Pump_o] != "Off")
                    {
                        SetDigValue((int)DigOutputList.Hot_Water_Pump_o, (uint)DigitalOffOn.Off, "PM1");
                    }
                }                
            }            
        }

        private static void _F_DOOR_OPEN_SEQ()
        {
            // CH1
            if (GetDigValue((int)DigInputList.CH1_Door_Sensor_i) == "Off")
            {
                if ((Define.seqMode[(byte)MODULE._PM1] == Define.MODE_PROCESS) && (Define.seqCtrl[(byte)MODULE._PM1] == Define.CTRL_RUNNING))
                {
                    if (Define.seqCtrl[(byte)MODULE._PM1] != Define.CTRL_WAIT)
                        Define.seqCtrl[(byte)MODULE._PM1] = Define.CTRL_WAIT;
                }

                // 모터는 매뉴얼 동작이라도 멈추게
                if (Define.seqCylinderCtrl[(byte)MODULE._PM1] != Define.CTRL_WAIT)
                    Define.seqCylinderCtrl[(byte)MODULE._PM1] = Define.CTRL_WAIT;
            }
            else
            {
                if ((Define.seqMode[(byte)MODULE._PM1] == Define.MODE_PROCESS) && (Define.seqCtrl[(byte)MODULE._PM1] == Define.CTRL_WAIT))
                {
                    if (Define.seqCtrl[(byte)MODULE._PM1] != Define.CTRL_RUNNING)
                        Define.seqCtrl[(byte)MODULE._PM1] = Define.CTRL_RUNNING;
                }

                if (Define.seqCylinderCtrl[(byte)MODULE._PM1] == Define.CTRL_WAIT)
                {                    
                    if ((Define.seqCylinderMode[(byte)MODULE._PM1] == Define.MODE_CYLINDER_RUN) &&
                        (Define.seqCylinderSts[(byte)MODULE._PM1] == Define.STS_CYLINDER_RUNING))
                    {
                        Define.seqCylinderMode[(byte)MODULE._PM1] = Define.MODE_CYLINDER_RUN;
                        Define.seqCylinderCtrl[(byte)MODULE._PM1] = Define.CTRL_RUN;
                        Define.seqCylinderSts[(byte)MODULE._PM1] = Define.STS_CYLINDER_IDLE;
                    }
                    else if ((Define.seqCylinderMode[(byte)MODULE._PM1] == Define.MODE_CYLINDER_HOME) &&
                             (Define.seqCylinderSts[(byte)MODULE._PM1] == Define.STS_CYLINDER_HOMEING))
                    {
                        Define.seqCylinderMode[(byte)MODULE._PM1] = Define.MODE_CYLINDER_HOME;
                        Define.seqCylinderCtrl[(byte)MODULE._PM1] = Define.CTRL_RUN;
                        Define.seqCylinderSts[(byte)MODULE._PM1] = Define.STS_CYLINDER_IDLE;
                    }
                    else if ((Define.seqCylinderMode[(byte)MODULE._PM1] == Define.MODE_CYLINDER_FWD) &&
                             (Define.seqCylinderSts[(byte)MODULE._PM1] == Define.STS_CYLINDER_FWDING))
                    {
                        Define.seqCylinderMode[(byte)MODULE._PM1] = Define.MODE_CYLINDER_FWD;
                        Define.seqCylinderCtrl[(byte)MODULE._PM1] = Define.CTRL_RUN;
                        Define.seqCylinderSts[(byte)MODULE._PM1] = Define.STS_CYLINDER_IDLE;
                    }
                    else if ((Define.seqCylinderMode[(byte)MODULE._PM1] == Define.MODE_CYLINDER_BWD) &&
                             (Define.seqCylinderSts[(byte)MODULE._PM1] == Define.STS_CYLINDER_BWDING))
                    {
                        Define.seqCylinderMode[(byte)MODULE._PM1] = Define.MODE_CYLINDER_BWD;
                        Define.seqCylinderCtrl[(byte)MODULE._PM1] = Define.CTRL_RUN;
                        Define.seqCylinderSts[(byte)MODULE._PM1] = Define.STS_CYLINDER_IDLE;
                    }
                }                
            }

            // CH2
            if (GetDigValue((int)DigInputList.CH2_Door_Sensor_i) == "Off")
            {
                if ((Define.seqMode[(byte)MODULE._PM2] == Define.MODE_PROCESS) && (Define.seqCtrl[(byte)MODULE._PM2] == Define.CTRL_RUNNING))
                {
                    if (Define.seqCtrl[(byte)MODULE._PM2] != Define.CTRL_WAIT)
                        Define.seqCtrl[(byte)MODULE._PM2] = Define.CTRL_WAIT;
                }

                // 모터는 매뉴얼 동작이라도 멈추게
                if (Define.seqCylinderCtrl[(byte)MODULE._PM2] != Define.CTRL_WAIT)
                    Define.seqCylinderCtrl[(byte)MODULE._PM2] = Define.CTRL_WAIT;
            }
            else
            {
                if ((Define.seqMode[(byte)MODULE._PM2] == Define.MODE_PROCESS) && (Define.seqCtrl[(byte)MODULE._PM2] == Define.CTRL_WAIT))
                {
                    if (Define.seqCtrl[(byte)MODULE._PM2] != Define.CTRL_RUNNING)
                        Define.seqCtrl[(byte)MODULE._PM2] = Define.CTRL_RUNNING;
                }

                if (Define.seqCylinderCtrl[(byte)MODULE._PM2] == Define.CTRL_WAIT)
                {
                    if ((Define.seqCylinderMode[(byte)MODULE._PM2] == Define.MODE_CYLINDER_RUN) &&
                        (Define.seqCylinderSts[(byte)MODULE._PM2] == Define.STS_CYLINDER_RUNING))
                    {
                        Define.seqCylinderMode[(byte)MODULE._PM2] = Define.MODE_CYLINDER_RUN;
                        Define.seqCylinderCtrl[(byte)MODULE._PM2] = Define.CTRL_RUN;
                        Define.seqCylinderSts[(byte)MODULE._PM2] = Define.STS_CYLINDER_IDLE;
                    }
                    else if ((Define.seqCylinderMode[(byte)MODULE._PM2] == Define.MODE_CYLINDER_HOME) &&
                             (Define.seqCylinderSts[(byte)MODULE._PM2] == Define.STS_CYLINDER_HOMEING))
                    {
                        Define.seqCylinderMode[(byte)MODULE._PM2] = Define.MODE_CYLINDER_HOME;
                        Define.seqCylinderCtrl[(byte)MODULE._PM2] = Define.CTRL_RUN;
                        Define.seqCylinderSts[(byte)MODULE._PM2] = Define.STS_CYLINDER_IDLE;
                    }
                    else if ((Define.seqCylinderMode[(byte)MODULE._PM2] == Define.MODE_CYLINDER_FWD) &&
                             (Define.seqCylinderSts[(byte)MODULE._PM2] == Define.STS_CYLINDER_FWDING))
                    {
                        Define.seqCylinderMode[(byte)MODULE._PM2] = Define.MODE_CYLINDER_FWD;
                        Define.seqCylinderCtrl[(byte)MODULE._PM2] = Define.CTRL_RUN;
                        Define.seqCylinderSts[(byte)MODULE._PM2] = Define.STS_CYLINDER_IDLE;
                    }
                    else if ((Define.seqCylinderMode[(byte)MODULE._PM2] == Define.MODE_CYLINDER_BWD) &&
                             (Define.seqCylinderSts[(byte)MODULE._PM2] == Define.STS_CYLINDER_BWDING))
                    {
                        Define.seqCylinderMode[(byte)MODULE._PM2] = Define.MODE_CYLINDER_BWD;
                        Define.seqCylinderCtrl[(byte)MODULE._PM2] = Define.CTRL_RUN;
                        Define.seqCylinderSts[(byte)MODULE._PM2] = Define.STS_CYLINDER_IDLE;
                    }
                }
            }

            // CH3
            if (GetDigValue((int)DigInputList.CH3_Door_Sensor_i) == "Off")
            {
                if ((Define.seqMode[(byte)MODULE._PM3] == Define.MODE_PROCESS) && (Define.seqCtrl[(byte)MODULE._PM3] == Define.CTRL_RUNNING))
                {
                    if (Define.seqCtrl[(byte)MODULE._PM3] != Define.CTRL_WAIT)
                        Define.seqCtrl[(byte)MODULE._PM3] = Define.CTRL_WAIT;
                }

                // 모터는 매뉴얼 동작이라도 멈추게
                if (Define.seqCylinderCtrl[(byte)MODULE._PM3] != Define.CTRL_WAIT)
                    Define.seqCylinderCtrl[(byte)MODULE._PM3] = Define.CTRL_WAIT;
            }
            else
            {
                if ((Define.seqMode[(byte)MODULE._PM3] == Define.MODE_PROCESS) && (Define.seqCtrl[(byte)MODULE._PM3] == Define.CTRL_WAIT))
                {
                    if (Define.seqCtrl[(byte)MODULE._PM3] != Define.CTRL_RUNNING)
                        Define.seqCtrl[(byte)MODULE._PM3] = Define.CTRL_RUNNING;
                }

                if (Define.seqCylinderCtrl[(byte)MODULE._PM3] == Define.CTRL_WAIT)
                {
                    if ((Define.seqCylinderMode[(byte)MODULE._PM3] == Define.MODE_CYLINDER_RUN) &&
                        (Define.seqCylinderSts[(byte)MODULE._PM3] == Define.STS_CYLINDER_RUNING))
                    {
                        Define.seqCylinderMode[(byte)MODULE._PM3] = Define.MODE_CYLINDER_RUN;
                        Define.seqCylinderCtrl[(byte)MODULE._PM3] = Define.CTRL_RUN;
                        Define.seqCylinderSts[(byte)MODULE._PM3] = Define.STS_CYLINDER_IDLE;
                    }
                    else if ((Define.seqCylinderMode[(byte)MODULE._PM3] == Define.MODE_CYLINDER_HOME) &&
                             (Define.seqCylinderSts[(byte)MODULE._PM3] == Define.STS_CYLINDER_HOMEING))
                    {
                        Define.seqCylinderMode[(byte)MODULE._PM3] = Define.MODE_CYLINDER_HOME;
                        Define.seqCylinderCtrl[(byte)MODULE._PM3] = Define.CTRL_RUN;
                        Define.seqCylinderSts[(byte)MODULE._PM3] = Define.STS_CYLINDER_IDLE;
                    }
                    else if ((Define.seqCylinderMode[(byte)MODULE._PM3] == Define.MODE_CYLINDER_FWD) &&
                             (Define.seqCylinderSts[(byte)MODULE._PM3] == Define.STS_CYLINDER_FWDING))
                    {
                        Define.seqCylinderMode[(byte)MODULE._PM3] = Define.MODE_CYLINDER_FWD;
                        Define.seqCylinderCtrl[(byte)MODULE._PM3] = Define.CTRL_RUN;
                        Define.seqCylinderSts[(byte)MODULE._PM3] = Define.STS_CYLINDER_IDLE;
                    }
                    else if ((Define.seqCylinderMode[(byte)MODULE._PM3] == Define.MODE_CYLINDER_BWD) &&
                             (Define.seqCylinderSts[(byte)MODULE._PM3] == Define.STS_CYLINDER_BWDING))
                    {
                        Define.seqCylinderMode[(byte)MODULE._PM3] = Define.MODE_CYLINDER_BWD;
                        Define.seqCylinderCtrl[(byte)MODULE._PM3] = Define.CTRL_RUN;
                        Define.seqCylinderSts[(byte)MODULE._PM3] = Define.STS_CYLINDER_IDLE;
                    }
                }
            }
        }
        #endregion

        #region 동작(IO) 명령 시 인터락
        private static bool SETPOINT_INTERLOCK_CHECK(int ioName, uint setValue, string ModuleName, ref string retMsg)
        {
            // Interlock이 해제 상태인지 체크
            if (Define.bInterlockRelease)
            {
                return true;
            }

            if (ModuleName == "PM1")
            {
                if ((ioName == (int)DigOutputList.CH1_WaterValve_o) ||                    
                    (ioName == (int)DigOutputList.CH1_Air_Knife_o) ||                    
                    (ioName == (int)DigOutputList.CH1_Curtain_AirValve_o))                    
                {
                    if (setValue == (uint)DigitalOffOn.On)
                    {
                        if ((GetDigValue((int)DigInputList.EMO_Front_i) == "On") &&
                            (GetDigValue((int)DigInputList.EMO_Rear_i) == "On") &&
                            (GetDigValue((int)DigInputList.CH1_Door_Sensor_i) == "On"))
                        {
                            return true;
                        }                            
                        else
                        {
                            retMsg = "EMO switch is on or Door is opened";
                            EventLog("[INTERLOCK#1] " + "EMO switch is on or Door is opened", ModuleName, "Event");                            
                            return false;
                        }                            
                    }
                    else
                    {
                        return true;
                    }
                }                

                if (ioName == (int)DigOutputList.CH1_Cylinder_Pwr_o)                    
                {
                    if (setValue == (uint)DigitalOffOn.On)
                    {
                        if ((GetDigValue((int)DigInputList.EMO_Front_i) == "On") &&
                            (GetDigValue((int)DigInputList.EMO_Rear_i) == "On") &&
                            (GetDigValue((int)DigInputList.CH1_Door_Sensor_i) == "On"))
                        {
                            return true;
                        }
                        else
                        {
                            retMsg = "EMO switch is on or Door is opened";
                            EventLog("[INTERLOCK#1] " + "EMO switch is on or Door is opened", ModuleName, "Event");
                            return false;
                        }
                    }
                    else
                    {
                        if ((GetDigValue((int)DigInputList.EMO_Front_i) == "On") &&
                            (GetDigValue((int)DigInputList.EMO_Rear_i) == "On"))
                        {
                            return true;
                        }
                        else
                        {
                            retMsg = "EMO switch is on";
                            EventLog("[INTERLOCK#1] " + "EMO switch is on", ModuleName, "Event");
                            return false;
                        }
                    }
                }
            }

            if (ModuleName == "PM2")
            {
                if ((ioName == (int)DigOutputList.CH2_WaterValve_o) ||
                    (ioName == (int)DigOutputList.CH2_Air_Knife_o) ||
                    (ioName == (int)DigOutputList.CH2_Curtain_AirValve_o))
                {
                    if (setValue == (uint)DigitalOffOn.On)
                    {
                        if ((GetDigValue((int)DigInputList.EMO_Front_i) == "On") &&
                            (GetDigValue((int)DigInputList.EMO_Rear_i) == "On") &&
                            (GetDigValue((int)DigInputList.CH2_Door_Sensor_i) == "On"))
                        {
                            return true;
                        }
                        else
                        {
                            retMsg = "EMO switch is on or Door is opened";
                            EventLog("[INTERLOCK#2] " + "EMO switch is on or Door is opened", ModuleName, "Event");
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
               
                if (ioName == (int)DigOutputList.CH2_Cylinder_Pwr_o)                    
                {
                    if (setValue == (uint)DigitalOffOn.On)
                    {
                        if ((GetDigValue((int)DigInputList.EMO_Front_i) == "On") &&
                            (GetDigValue((int)DigInputList.EMO_Rear_i) == "On") &&
                            (GetDigValue((int)DigInputList.CH2_Door_Sensor_i) == "On"))
                        {
                            return true;
                        }
                        else
                        {
                            retMsg = "EMO switch is on or Door is opened";
                            EventLog("[INTERLOCK#2] " + "EMO switch is on or Door is opened", ModuleName, "Event");
                            return false;
                        }
                    }
                    else
                    {
                        if ((GetDigValue((int)DigInputList.EMO_Front_i) == "On") &&
                            (GetDigValue((int)DigInputList.EMO_Rear_i) == "On"))
                        {
                            return true;
                        }
                        else
                        {
                            retMsg = "EMO switch is on";
                            EventLog("[INTERLOCK#2] " + "EMO switch is on", ModuleName, "Event");
                            return false;
                        }
                    }
                }
            }

            if (ModuleName == "PM3")
            {
                if ((ioName == (int)DigOutputList.CH3_WaterValve_o) ||
                    (ioName == (int)DigOutputList.CH3_Air_Knife_o) ||
                    (ioName == (int)DigOutputList.CH3_Curtain_AirValve_o))
                {
                    if (setValue == (uint)DigitalOffOn.On)
                    {
                        if ((GetDigValue((int)DigInputList.EMO_Front_i) == "On") &&
                            (GetDigValue((int)DigInputList.EMO_Rear_i) == "On") &&
                            (GetDigValue((int)DigInputList.CH3_Door_Sensor_i) == "On"))
                        {
                            return true;
                        }
                        else
                        {
                            retMsg = "EMO switch is on or Door is opened";
                            EventLog("[INTERLOCK#3] " + "EMO switch is on or Door is opened", ModuleName, "Event");
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }                

                if (ioName == (int)DigOutputList.CH3_Cylinder_Pwr_o)                    
                {
                    if (setValue == (uint)DigitalOffOn.On)
                    {
                        if ((GetDigValue((int)DigInputList.EMO_Front_i) == "On") &&
                            (GetDigValue((int)DigInputList.EMO_Rear_i) == "On") &&
                            (GetDigValue((int)DigInputList.CH3_Door_Sensor_i) == "On"))
                        {
                            return true;
                        }
                        else
                        {
                            retMsg = "EMO switch is on or Door is opened";
                            EventLog("[INTERLOCK#3] " + "EMO switch is on or Door is opened", ModuleName, "Event");
                            return false;
                        }
                    }
                    else
                    {
                        if ((GetDigValue((int)DigInputList.EMO_Front_i) == "On") &&
                            (GetDigValue((int)DigInputList.EMO_Rear_i) == "On"))                         
                        {
                            return true;
                        }
                        else
                        {
                            retMsg = "EMO switch is on";
                            EventLog("[INTERLOCK#3] " + "EMO switch is on", ModuleName, "Event");
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private static void ALL_VALVE_CLOSE()
        {
            SetDigValue((int)DigOutputList.CH1_WaterValve_o, (uint)DigitalOffOn.Off, "PM1");            
            SetDigValue((int)DigOutputList.CH1_Air_Knife_o, (uint)DigitalOffOn.Off, "PM1");
            SetDigValue((int)DigOutputList.CH1_Curtain_AirValve_o, (uint)DigitalOffOn.Off, "PM1");
            SetDigValue((int)DigOutputList.CH1_Booster_AirValve_o, (uint)DigitalOffOn.Off, "PM1");

            SetDigValue((int)DigOutputList.CH2_WaterValve_o, (uint)DigitalOffOn.Off, "PM2");            
            SetDigValue((int)DigOutputList.CH2_Air_Knife_o, (uint)DigitalOffOn.Off, "PM2");
            SetDigValue((int)DigOutputList.CH2_Curtain_AirValve_o, (uint)DigitalOffOn.Off, "PM2");
            SetDigValue((int)DigOutputList.CH2_Booster_AirValve_o, (uint)DigitalOffOn.Off, "PM2");

            SetDigValue((int)DigOutputList.CH3_WaterValve_o, (uint)DigitalOffOn.Off, "PM3");            
            SetDigValue((int)DigOutputList.CH3_Air_Knife_o, (uint)DigitalOffOn.Off, "PM3");
            SetDigValue((int)DigOutputList.CH3_Curtain_AirValve_o, (uint)DigitalOffOn.Off, "PM3");
            SetDigValue((int)DigOutputList.CH3_Booster_AirValve_o, (uint)DigitalOffOn.Off, "PM3");

            SetDigValue((int)DigOutputList.Hot_Water_Pump_o, (uint)DigitalOffOn.Off, "PM1");
            SetDigValue((int)DigOutputList.Hot_WaterHeater_o, (uint)DigitalOffOn.Off, "PM1");
            SetDigValue((int)DigOutputList.Main_Water_Supply, (uint)DigitalOffOn.Off, "PM1");
        }

        private static void PROCESS_ABORT()
        {
            if (Define.seqCtrl[(byte)MODULE._PM1] != Define.CTRL_IDLE)                
            {
                Define.seqCtrl[(byte)MODULE._PM1] = Define.CTRL_ABORT;
            }

            if (Define.seqCtrl[(byte)MODULE._PM2] != Define.CTRL_IDLE)
            {
                Define.seqCtrl[(byte)MODULE._PM2] = Define.CTRL_ABORT;
            }

            if (Define.seqCtrl[(byte)MODULE._PM3] != Define.CTRL_IDLE)
            {
                Define.seqCtrl[(byte)MODULE._PM3] = Define.CTRL_ABORT;
            }

            if (Define.seqCtrl[(byte)MODULE._WATERTANK] != Define.CTRL_IDLE)
            {
                Define.seqCtrl[(byte)MODULE._WATERTANK] = Define.CTRL_ABORT;
            }
        }        
        #endregion

        public static bool Value_Check(string[] sValue)
        {
            bool bResult;
            int i;
            bool bRtn = true;
            double dVal = 0.0;

            for (i = 0; i < sValue.Length; i++)
            {
                bResult = double.TryParse(sValue[i], out dVal);
                if (!bResult)
                {
                    bRtn = false;
                    break;
                }
            }

            if (bRtn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
