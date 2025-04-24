using MsSqlManagerLibrary;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace FluxTool_CleanerSystem_K4_4.Squence
{
    struct TPrcsRecipe3
    {
        public int TotalStep;           // Process total step
        public int StepNum;             // Process step number

        public string[] StepName;       // Process step name        
        public string[] Water;        
        public string[] AirKnife;
        public string[] Pin;
        public double[] ProcessTime;     // Process time
    }

    struct TCheckFlag3
    {
        public bool AirFlag;        
        public bool WaterFlag;
    }

    class PM3Process : TBaseThread
    {
        Thread thread;
        private new TStep step;
        TPrcsRecipe3 prcsRecipe; // Recipe struct
        TCheckFlag3 checkFlag;
        Alarm_List alarm_List;  // Alarm list

        //double fAlarmTime = 1;
        bool bPinFlag;
        int iPinTimeCnt = 0;
        string sUpDn;
        private bool bWaitSet;

        private string prcsStartTime;

        public PM3Process()
        {
            ModuleName = "PM3";
            module = (byte)MODULE._PM3;

            thread = new Thread(new ThreadStart(Execute));

            prcsRecipe = new TPrcsRecipe3();            
            alarm_List = new Alarm_List();

            prcsRecipe.StepName = new string[Define.RECIPE_MAX_STEP];       // Max 50 step
            prcsRecipe.Water = new string[Define.RECIPE_MAX_STEP];            
            prcsRecipe.AirKnife = new string[Define.RECIPE_MAX_STEP];
            prcsRecipe.Pin = new string[Define.RECIPE_MAX_STEP];
            prcsRecipe.ProcessTime = new double[Define.RECIPE_MAX_STEP];

            thread.Start();
        }

        public void Dispose()
        {
            thread.Abort();
        }

        private void Execute()
        {
            try
            {
                while (true)
                {
                    if (Define.seqCtrl[module] == Define.CTRL_ABORT)
                    {
                        AlarmAction("Abort");
                    }
                    else if (Define.seqCtrl[module] == Define.CTRL_RETRY)
                    {
                        AlarmAction("Retry");
                    }
                    else if (Define.seqCtrl[module] == Define.CTRL_WAIT)
                    {
                        AlarmAction("Wait");
                    }

                    Process_Progress();
                    Init_Progress();

                    Thread.Sleep(10);
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void AlarmAction(string sAction)
        {
            if (sAction == "Retry")
            {
                if (Define.seqSts[module] == Define.STS_PROCESS_ING)
                {
                    // 자재 공정중인 색상(Lime색?)으로 변경
                }

                step.Flag = true;
                step.Times = 1;

                if ((step.Layer >= 4) && (step.Layer <= 7))
                {
                    step.Layer = 4;
                }

                Define.seqCtrl[module] = Define.CTRL_RUNNING;

                Define.seqCylinderMode[module] = Define.MODE_CYLINDER_RUN;
                Define.seqCylinderCtrl[module] = Define.CTRL_RUN;

                Global.EventLog("Resume process current phase : " + sAction, ModuleName, "Event");
            }
            else if (sAction == "Ignore")
            {
                F_INC_STEP();

                Define.seqCtrl[module] = Define.CTRL_RUNNING;

                Global.EventLog("Skip the process current step : " + sAction, ModuleName, "Event");
            }
            else if (sAction == "Abort")
            {
                ActionList();

                Define.seqMode[module] = Define.MODE_IDLE;
                Define.seqCtrl[module] = Define.CTRL_IDLE;
                Define.seqSts[module] = Define.STS_ABORTOK;

                step.Times = 1;
                Global.prcsInfo.prcsStepCurrentTime[module] = 1;

                Global.EventLog("Process has stopped : " + sAction, ModuleName, "Event");
            }
            else if (sAction == "Wait")
            {
                if (!bWaitSet)
                {
                    F_PROCESS_ALL_VALVE_CLOSE();

                    bWaitSet = true;

                    Global.EventLog("Process has stopped : " + sAction, ModuleName, "Event");
                }
            }
        }

        private void ActionList()
        {
            //if (Define.seqMode[module] == Define.MODE_PROCESS)
            //{
                // 자재 프로세스 실패 색상(빨간색)으로 변경

                F_PROCESS_ALL_VALVE_CLOSE();
            //}

            Define.seqCylinderCtrl[module] = Define.CTRL_ABORT;
        }

        private void ShowAlarm(string almId)
        {
            ActionList();

            Define.seqCtrl[module] = Define.CTRL_ALARM;

            // Buzzer IO On.
            Global.SetDigValue((int)DigOutputList.Buzzer_o, (uint)DigitalOffOn.On, ModuleName);

            // Alarm history.
            Define.sAlarmName = "";
            alarm_List.alarm_code = almId;
            Define.sAlarmName = alarm_List.alarm_code;

            Global.EventLog(almId + ":" + Define.sAlarmName, ModuleName, "Alarm");            
        }

        public void F_HOLD_STEP()
        {
            step.Flag = false;
            step.Times = 1;
            Define.seqCtrl[module] = Define.CTRL_HOLD;
        }

        public void F_INC_STEP()
        {
            step.Flag = true;
            step.Layer++;
            step.Times = 1;
        }

        // PROCESS PROGRESS /////////////////////////////////////////////////////////////////
        #region PROCESS_PROGRESS
        private void Process_Progress()
        {
            if ((Define.seqMode[module] == Define.MODE_PROCESS) && (Define.seqCtrl[module] == Define.CTRL_RUN))
            {
                Thread.Sleep(500);
                step.Layer = 1;
                step.Times = 1;
                step.Flag = true;

                prcsRecipe.TotalStep = 0;
                prcsRecipe.StepNum = 0;

                for (int i = 0; i < Define.RECIPE_MAX_STEP; i++)
                {
                    prcsRecipe.StepName[i] = string.Empty;
                    prcsRecipe.Water[i] = string.Empty;                    
                    prcsRecipe.AirKnife[i] = string.Empty;
                    prcsRecipe.Pin[i] = string.Empty;
                    prcsRecipe.ProcessTime[i] = 0;
                }

                Global.prcsInfo.prcsRecipeName[module] = string.Empty;
                Global.prcsInfo.prcsCurrentStep[module] = 0;
                Global.prcsInfo.prcsTotalStep[module] = 0;
                Global.prcsInfo.prcsStepName[module] = string.Empty;
                Global.prcsInfo.prcsStepCurrentTime[module] = 1;
                Global.prcsInfo.prcsStepTotalTime[module] = 0;
                Global.prcsInfo.prcsEndTime[module] = string.Empty;
                prcsStartTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                checkFlag.AirFlag = false;                
                checkFlag.WaterFlag = false;

                bWaitSet = false;

                Define.bProcessEnd[module] = false;

                //fAlarmTime = 1;

                bPinFlag = false;
                iPinTimeCnt = 0;
                sUpDn = "Down";

                Define.seqCtrl[module] = Define.CTRL_RUNNING;
                Define.seqSts[module] = Define.STS_PROCESS_ING;

                Global.EventLog("START THE PROCESS.", ModuleName, "Event");                
            }
            else if ((Define.seqMode[module] == Define.MODE_PROCESS) && (Define.seqCtrl[module] == Define.CTRL_HOLD))
            {
                Define.seqCtrl[module] = Define.CTRL_RUNNING;
            }
            else if ((Define.seqMode[module] == Define.MODE_PROCESS) && (Define.seqCtrl[module] == Define.CTRL_RUNNING))
            {
                switch (step.Layer)
                {
                    case 1:
                        {
                            F_INC_STEP();
                        }
                        break;

                    case 2:
                        {
                            F_INC_STEP();
                        }
                        break;

                    case 3:
                        {
                            P_PROCESS_RecipeLoading(Global.RecipeFilePath + "\\" + Define.sSelectRecipeName[module]);
                        }
                        break;

                    case 4:
                        {
                            F_INC_STEP();
                        }
                        break;

                    case 5:
                        {
                            P_PROCESS_IO_Setting();
                        }
                        break;

                    case 6:
                        {
                            P_Cylinder_FwdBwd_Seq("Run");
                        }
                        break;

                    case 7:
                        {
                            P_PROCESS_ProcessTimeCheck();
                        }
                        break;

                    case 8:
                        {
                            P_PROCESS_EndStepCheck(4);
                        }
                        break;

                    case 9:
                        {
                            P_Cylinder_FwdBwd_Seq("Home");
                        }
                        break;

                    case 10:
                        {
                            F_INC_STEP();
                        }
                        break;

                    case 11:
                        {
                            F_INC_STEP();
                        }
                        break;

                    case 12:
                        {
                            F_INC_STEP();
                        }
                        break;

                    case 13:
                        {
                            P_PROCESS_ProcessEnd();
                        }
                        break;
                }
            }
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////

        // INIT PROGRESS ////////////////////////////////////////////////////////////////////
        #region INIT_PROGRESS
        private void Init_Progress()
        {
            if ((Define.seqMode[module] == Define.MODE_INIT) && (Define.seqCtrl[module] == Define.CTRL_RUN))
            {
                Thread.Sleep(500);
                step.Layer = 1;
                step.Times = 1;
                step.Flag = true;

                Define.seqCtrl[module] = Define.CTRL_RUNNING;
                Define.seqSts[module] = Define.STS_INIT_ING;

                Global.EventLog("START THE INITIALIZE.", ModuleName, "Event");                
            }
            else if ((Define.seqMode[module] == Define.MODE_INIT) && (Define.seqCtrl[module] == Define.CTRL_HOLD))
            {
                Define.seqCtrl[module] = Define.CTRL_RUNNING;
            }
            else if ((Define.seqMode[module] == Define.MODE_INIT) && (Define.seqCtrl[module] == Define.CTRL_RUNNING))
            {
                switch (step.Layer)
                {
                    case 1:
                        {
                            P_INIT_ALLVALVECLOSE();
                        }
                        break;

                    case 2:
                        {
                            F_INC_STEP();
                        }
                        break;

                    case 3:
                        {
                            P_INIT_PIN("Down");
                        }
                        break;

                    case 4:
                        {
                            P_Cylinder_FwdBwd_Seq("Home");
                        }
                        break;

                    case 5:
                        {
                            F_INC_STEP();
                        }
                        break;

                    case 6:
                        {
                            P_INIT_End();
                        }
                        break;
                }
            }
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////

        // FUNCTION /////////////////////////////////////////////////////////////////////////
        #region PROCESS FUNCTION
        private void P_PROCESS_RecipeLoading(string FileName)
        {
            if (step.Flag)
            {
                Global.EventLog("Loading the process recipe file.", ModuleName, "Event");

                F_HOLD_STEP();
            }
            else
            {
                if (File.Exists(FileName))
                {
                    ImportExcelData_Read(FileName);

                    prcsRecipe.StepNum = 1; // Recipe 현재 스탭 초기화

                    Global.EventLog("Recipe file was successfully read.", ModuleName, "Event");

                    Global.prcsInfo.prcsRecipeName[module] = Define.sSelectRecipeName[module];

                    Global.EventLog("Recipe name : " + Global.prcsInfo.prcsRecipeName[module], ModuleName, "Event");                    

                    F_INC_STEP();
                }
                else
                {
                    ShowAlarm("1002");  // "Failed to read recipe file."
                }
            }
        }

        private void ImportExcelData_Read(string fileName)
        {
            uint lineNum = 0;   // Recipe 파일의 item line 총 갯수

            try
            {
                StreamReader sr = new StreamReader(fileName);
                while (!sr.EndOfStream)
                {
                    if (lineNum == 0)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');

                        int iDataCnt = data.Length - 1;
                        prcsRecipe.TotalStep = iDataCnt;    // Process total step count

                        lineNum++;
                    }
                    else if (lineNum == 1)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');

                        for (int i = 0; i < prcsRecipe.TotalStep; i++)
                        {
                            prcsRecipe.StepName[i] = data[i + 1];   // Process step name
                        }

                        lineNum++;
                    }
                    else if (lineNum == 2)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');

                        for (int i = 0; i < prcsRecipe.TotalStep; i++)
                        {
                            prcsRecipe.Water[i] = data[i + 1];   // Water
                        }

                        lineNum++;
                    }                                      
                    else if (lineNum == 3)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');

                        for (int i = 0; i < prcsRecipe.TotalStep; i++)
                        {
                            prcsRecipe.AirKnife[i] = data[i + 1];   // Air knife
                        }

                        lineNum++;
                    }
                    else if (lineNum == 4)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');

                        for (int i = 0; i < prcsRecipe.TotalStep; i++)
                        {
                            prcsRecipe.Pin[i] = data[i + 1];   // Pin UpDn
                        }

                        lineNum++;
                    }
                    else if (lineNum == 5)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');

                        for (int i = 0; i < prcsRecipe.TotalStep; i++)
                        {
                            prcsRecipe.ProcessTime[i] = double.Parse(data[i + 1]);    // Process step time
                        }

                        sr.Close();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }
        }

        private void P_PROCESS_IO_Setting()
        {
            if (step.Flag)
            {
                Global.prcsInfo.prcsCurrentStep[module] = prcsRecipe.StepNum;
                Global.prcsInfo.prcsTotalStep[module] = prcsRecipe.TotalStep;
                Global.prcsInfo.prcsStepName[module] = prcsRecipe.StepName[prcsRecipe.StepNum - 1];
                Global.prcsInfo.prcsStepCurrentTime[module] = 1;
                Global.prcsInfo.prcsStepTotalTime[module] = prcsRecipe.ProcessTime[prcsRecipe.StepNum - 1];

                Global.EventLog("Process Step : " + (prcsRecipe.StepNum).ToString(), ModuleName, "Event");
                
                // Water
                if (prcsRecipe.Water[prcsRecipe.StepNum - 1] == "On")
                {
                    Global.SetDigValue((int)DigOutputList.CH3_WaterValve_o, (uint)DigitalOffOn.On, ModuleName);
                    checkFlag.WaterFlag = true;
                }
                else
                {
                    Global.SetDigValue((int)DigOutputList.CH3_WaterValve_o, (uint)DigitalOffOn.Off, ModuleName);
                    checkFlag.WaterFlag = false;
                }                       

                // Air knife
                if (prcsRecipe.AirKnife[prcsRecipe.StepNum - 1] == "On")
                {
                    Global.SetDigValue((int)DigOutputList.CH3_Air_Knife_o, (uint)DigitalOffOn.On, ModuleName);
                    checkFlag.AirFlag = true;
                }
                else
                {
                    Global.SetDigValue((int)DigOutputList.CH3_Air_Knife_o, (uint)DigitalOffOn.Off, ModuleName);
                    checkFlag.AirFlag = false;
                }

                // Curtain air
                Global.SetDigValue((int)DigOutputList.CH3_Curtain_AirValve_o, (uint)DigitalOffOn.On, ModuleName);

                // Pin up/down 여부
                bPinFlag = false;
                if (prcsRecipe.Pin[prcsRecipe.StepNum - 1] == "Up/Down")
                {
                    bPinFlag = true;
                }
                else if (prcsRecipe.Pin[prcsRecipe.StepNum - 1] == "Up")
                {
                    Global.SetDigValue((int)DigOutputList.CH3_Pin_UpDn_o, (uint)DigitalOffOn.On, ModuleName);
                }
                else if (prcsRecipe.Pin[prcsRecipe.StepNum - 1] == "Down")
                {
                    Global.SetDigValue((int)DigOutputList.CH3_Pin_UpDn_o, (uint)DigitalOffOn.Off, ModuleName);
                }

                F_HOLD_STEP();
            }
            else
            {
                F_INC_STEP();
            }
        }

        private void P_Cylinder_FwdBwd_Seq(string sAct)
        {
            if (step.Flag)
            {
                if (sAct == "Run")
                {
                    if (((Define.seqCylinderMode[module] == Define.MODE_CYLINDER_IDLE) && (Define.seqCylinderCtrl[module] == Define.CTRL_IDLE)) ||
                         (Define.seqCylinderCtrl[module] == Define.CTRL_WAIT))
                    {
                        Define.seqCylinderMode[module] = Define.MODE_CYLINDER_RUN;
                        Define.seqCylinderCtrl[module] = Define.CTRL_RUN;
                        Define.seqCylinderSts[module] = Define.STS_CYLINDER_IDLE;
                    }
                }
                else
                {
                    //Define.seqCylinderCtrl[module] = Define.CTRL_ABORT;

                    //Thread.Sleep(1000);
                    //Task.Delay(1000);

                    Define.seqCylinderMode[module] = Define.MODE_CYLINDER_HOME;
                    Define.seqCylinderCtrl[module] = Define.CTRL_RUN;
                    Define.seqCylinderSts[module] = Define.STS_CYLINDER_IDLE;                    
                }

                F_HOLD_STEP();
            }
            else
            {
                if (sAct == "Run")
                {
                    F_INC_STEP();
                }
                else
                {
                    if (step.Times > 1)
                    {
                        if ((Define.seqCylinderCtrl[module] == Define.CTRL_IDLE) &&
                            (Define.seqCylinderSts[module] == Define.STS_CYLINDER_HOMEEND))
                        {
                            F_INC_STEP();
                        }
                        else
                        {
                            step.INC_TIMES();
                        }
                    }
                    else
                    {
                        step.INC_TIMES();
                    }
                }
            }
        }

        private void P_PROCESS_ProcessTimeCheck()
        {
            if (step.Flag)
            {
                Global.EventLog("Check the process time : " + prcsRecipe.ProcessTime[prcsRecipe.StepNum - 1].ToString() + " sec.", ModuleName, "Event");

                F_HOLD_STEP();
                //step.Times = fAlarmTime;
            }
            else
            {
                if (step.Times >= prcsRecipe.ProcessTime[prcsRecipe.StepNum - 1])
                {                                                            
                    F_INC_STEP();
                }
                else
                {
                    // Pin up/down 여부
                    if (bPinFlag)
                    {
                        // Configure 셋팅 간격으로 Pin up/down
                        if (iPinTimeCnt > Configure_List.Pin_Time_Interval)
                        {
                            F_PIN_UPDN();
                            iPinTimeCnt = 0;
                        }
                        else
                        {
                            iPinTimeCnt++;
                        }
                    }

                    // Wait 후 Running시 (Door open -> close), IO동작 재 셋팅
                    if (bWaitSet)
                        F_WAIT_IO_DESETTING();

                    // Water open 후, 5초 후에 Booster air open
                    if (step.Times >= 5)
                    {
                        if (prcsRecipe.Water[prcsRecipe.StepNum - 1] == "On")
                        {
                            if (Global.digSet.curDigSet[(int)DigOutputList.CH3_Booster_AirValve_o] != "On")
                            {
                                Global.SetDigValue((int)DigOutputList.CH3_Booster_AirValve_o, (uint)DigitalOffOn.On, ModuleName);
                            }                            
                        }
                    }

                    step.INC_TIMES();

                    // Alarm 발생 시 이어서 진행 할 시간 저장
                    //fAlarmTime = step.Times;

                    // Ui에 표시 할 시간
                    Global.prcsInfo.prcsStepCurrentTime[module] = step.Times;
                }
            }
        }

        private void P_PROCESS_EndStepCheck(byte nStep)
        {
            if (step.Flag)
            {
                Global.EventLog("Check the End step.", ModuleName, "Event");

                F_HOLD_STEP();
            }
            else
            {
                if (prcsRecipe.StepNum >= prcsRecipe.TotalStep)
                {
                    F_PROCESS_ALL_VALVE_CLOSE();

                    // Pin down set
                    Global.SetDigValue((int)DigOutputList.CH3_Pin_UpDn_o, (uint)DigitalOffOn.Off, ModuleName);                    

                    F_INC_STEP();                    
                }
                else
                {
                    prcsRecipe.StepNum++;

                    //F_PROCESS_RECIPE_DESETTING();                    

                    iPinTimeCnt = 0;

                    Global.prcsInfo.prcsStepCurrentTime[module] = 1;

                    step.Flag = true;
                    step.Layer = nStep;

                    //fAlarmTime = 1;                    
                }
            }
        }

        private void P_PROCESS_ProcessEnd()
        {
            Global.prcsInfo.prcsEndTime[module] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");            

            Define.seqMode[module] = Define.MODE_IDLE;
            Define.seqCtrl[module] = Define.CTRL_IDLE;
            Define.seqSts[module] = Define.STS_PROCESS_END;

            //Define.bChangeRecipe[module] = false;

            // Process end buzzer
            Global.SetDigValue((int)DigOutputList.Buzzer_o, (uint)DigitalOffOn.On, ModuleName);
            Define.bProcessEnd[module] = true;

            Global.EventLog("PROCESS COMPLETED.", ModuleName, "Event");

            F_DAILY_COUNT();

            F_TOOL_HISTORY();
        }

        private void F_PIN_UPDN()
        {
            /*
            if (Global.digSet.curDigSet[(int)DigOutputList.CH3_Pin_UpDn_o] != null)
            {
                if (Global.digSet.curDigSet[(int)DigOutputList.CH3_Pin_UpDn_o] == "On")
                {
                    Global.SetDigValue((int)DigOutputList.CH3_Pin_UpDn_o, (uint)DigitalOffOn.Off, ModuleName);
                }
                else
                {
                    Global.SetDigValue((int)DigOutputList.CH3_Pin_UpDn_o, (uint)DigitalOffOn.On, ModuleName);
                }
            }
            */
            if (sUpDn == "Up")
            {
                Global.SetDigValue((int)DigOutputList.CH3_Pin_UpDn_o, (uint)DigitalOffOn.Off, ModuleName);
                sUpDn = "Down";
            }
            else
            {
                Global.SetDigValue((int)DigOutputList.CH3_Pin_UpDn_o, (uint)DigitalOffOn.On, ModuleName);
                sUpDn = "Up";
            }
        }

        private void F_PROCESS_ALL_VALVE_CLOSE()
        {
            // Water
            Global.SetDigValue((int)DigOutputList.CH3_WaterValve_o, (uint)DigitalOffOn.Off, ModuleName);

            // Air                     
            Global.SetDigValue((int)DigOutputList.CH3_Air_Knife_o, (uint)DigitalOffOn.Off, ModuleName);
            Global.SetDigValue((int)DigOutputList.CH3_Curtain_AirValve_o, (uint)DigitalOffOn.Off, ModuleName);

            Global.SetDigValue((int)DigOutputList.CH3_Booster_AirValve_o, (uint)DigitalOffOn.Off, ModuleName);
        }

        private void F_PROCESS_RECIPE_DESETTING()
        {
            //
        }

        private void F_WAIT_IO_DESETTING()
        {
            bWaitSet = false;

            if (checkFlag.WaterFlag)
                Global.SetDigValue((int)DigOutputList.CH3_WaterValve_o, (uint)DigitalOffOn.On, ModuleName);

            if (checkFlag.AirFlag)
                Global.SetDigValue((int)DigOutputList.CH3_Air_Knife_o, (uint)DigitalOffOn.On, ModuleName);

            Global.SetDigValue((int)DigOutputList.CH3_Curtain_AirValve_o, (uint)DigitalOffOn.On, ModuleName);
        }

        private void F_DAILY_COUNT()
        {
            Define.iPM3DailyCnt++;
            Global.DailyLog(Define.iPM3DailyCnt, ModuleName);            
        }

        private void F_TOOL_HISTORY()
        {
            string todayDate = DateTime.Now.ToString("yyyy-MM-dd");
            string user = Define.ToolInfoRegist_User[module];
            string lotInfo = Define.ToolInfoRegist_Lot[module];
            string mcInfo = Define.ToolInfoRegist_MC[module];
            string toolID = Define.ToolInfoRegist_ToolID[module];
            string ch = ModuleName;
            string startTime = prcsStartTime;
            string endTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            // CSV 형식으로 문자열 만듬
            string[] data = { todayDate, user, lotInfo, mcInfo, toolID, ch, startTime, endTime };
            /*for (int i = 0; i < data.Length; i++)
            {
                data[i] = $"\"{data[i]}\"";
            }*/
            string csvLine = string.Join(",", data);

            // 파일에 데이터 저장            
            string fileName = string.Format("{0}{1}_{2}.csv", Global.toolHistoryfilePath, toolID, endTime);
            try
            {
                // 파일이 존재하지 않으면 헤더 추가
                if (!File.Exists(fileName))
                {
                    string header = "날짜,사용자,Lot정보,M/C정보,ToolID정보,챔버,공정시작시간,공정종료시간";
                    File.WriteAllText(fileName, header + Environment.NewLine);
                }
                // 파일에 데이터 추가
                File.AppendAllText(fileName, csvLine + Environment.NewLine);

                Global.EventLog("Tool 이력 데이터가 저장되었습니다.", ModuleName, "Event");
            }
            catch (Exception ex)
            {
                Global.EventLog($"Tool 이력 데이터 파일 저장 중 오류가 발생했습니다 : {ex.Message}", ModuleName, "Event");
            }
        }
        #endregion

        #region INIT FUNCTION
        private void P_INIT_ALLVALVECLOSE()
        {
            if (step.Flag)
            {
                F_PROCESS_ALL_VALVE_CLOSE();

                F_HOLD_STEP();
            }
            else
            {
                F_INC_STEP();
            }
        }

        private void P_INIT_PIN(string UpDn)
        {
            if (step.Flag)
            {
                Global.EventLog("Pin : " + UpDn, ModuleName, "Event");

                if (UpDn == "Up")
                {
                    if (Global.digSet.curDigSet[(int)DigOutputList.CH3_Pin_UpDn_o] != null)
                    {
                        Global.SetDigValue((int)DigOutputList.CH3_Pin_UpDn_o, (uint)DigitalOffOn.On, ModuleName);
                    }
                }
                else
                {
                    if (Global.digSet.curDigSet[(int)DigOutputList.CH3_Pin_UpDn_o] != null)
                    {
                        Global.SetDigValue((int)DigOutputList.CH3_Pin_UpDn_o, (uint)DigitalOffOn.Off, ModuleName);
                    }
                }

                F_HOLD_STEP();
            }
            else
            {
                F_INC_STEP();
            }
        }

        private void P_INIT_End()
        {
            Define.seqMode[module] = Define.MODE_IDLE;
            Define.seqCtrl[module] = Define.CTRL_IDLE;
            Define.seqSts[module] = Define.STS_INIT_END;

            Global.EventLog("INIT COMPLETED.", ModuleName, "Event");            
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////
    }
}
