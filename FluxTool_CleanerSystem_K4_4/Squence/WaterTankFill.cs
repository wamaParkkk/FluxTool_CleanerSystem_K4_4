using HanyoungNXClassLibrary;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FluxTool_CleanerSystem_K4_4.Squence
{
    class WaterTankFill : TBaseThread
    {
        Thread thread;
        private new TStep step;
        Alarm_List alarm_List;  // Alarm list        

        public WaterTankFill()
        {
            ModuleName = "WATERTANK";
            module = (byte)MODULE._WATERTANK;
            
            thread = new Thread(new ThreadStart(Execute));
            
            alarm_List = new Alarm_List();            

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

                    WaterFill_Progress();

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
                step.Flag = true;
                step.Times = 1;
                step.Layer = 2;

                Define.seqCtrl[module] = Define.CTRL_RUNNING;

                Global.EventLog("Water fill and Heating sequence : " + sAction, ModuleName, "Event");                
            }
            else if (sAction == "Abort")
            {
                ActionList();

                Define.seqMode[module] = Define.MODE_IDLE;
                Define.seqCtrl[module] = Define.CTRL_IDLE;
                Define.seqSts[module] = Define.STS_ABORTOK;

                Global.EventLog("Water fill and Heating sequence : " + sAction, ModuleName, "Event");
            }
        }

        private void ActionList()
        {
            Global.SetDigValue((int)DigOutputList.Hot_WaterHeater_o, (uint)DigitalOffOn.Off, ModuleName);            

            Global.SetDigValue((int)DigOutputList.Main_Water_Supply, (uint)DigitalOffOn.Off, ModuleName);            
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

        public void F_INC_STEP()
        {
            step.Flag = true;
            step.Layer++;
            step.Times = 1;
        }

        // WATER FILL PROGRESS //////////////////////////////////////////////////////////////
        #region WATERFILL_PROGRESS
        private void WaterFill_Progress()
        {
            if ((Define.seqMode[module] == Define.MODE_PROCESS) && (Define.seqCtrl[module] == Define.CTRL_RUN))
            {
                step.Layer = 1;
                step.Times = 1;
                step.Flag = true;

                Define.seqCtrl[module] = Define.CTRL_RUNNING;
                Define.seqSts[module] = Define.STS_PROCESS_ING;

                Global.EventLog("START THE WATER FILL AND HEATING.", ModuleName, "Event");
            }
            else if ((Define.seqMode[module] == Define.MODE_PROCESS) && (Define.seqCtrl[module] == Define.CTRL_RUNNING))
            {
                switch (step.Layer)
                {
                    case 1:
                        {
                            P_Chamber_Process_Hold();
                        }
                        break;

                    case 2:
                        {
                            P_WATER_Supply();
                        }
                        break;
                    
                    case 3:
                        {
                            P_WATER_Heating_Check();
                        }
                        break;

                    case 4:
                        {
                            P_Chamber_Process_Run();
                        }
                        break;

                    case 5:
                        {
                            P_WATER_Fill_End();
                        }
                        break;
                }
            }
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////
        ///
        // FUNCTION /////////////////////////////////////////////////////////////////////////
        #region FUNCTION
        private void P_Chamber_Process_Hold()
        {
            if (step.Flag)
            {
                /*
                if (Define.seqCtrl[(byte)MODULE._PM1] == Define.CTRL_RUNNING)
                {
                    Define.seqCtrl[(byte)MODULE._PM1] = Define.CTRL_HOLD;

                    Global.EventLog("Pause the CH1 process", ModuleName, "Event");
                }

                if (Define.seqCtrl[(byte)MODULE._PM2] == Define.CTRL_RUNNING)
                {
                    Define.seqCtrl[(byte)MODULE._PM2] = Define.CTRL_HOLD;

                    Global.EventLog("Pause the CH2 process", ModuleName, "Event");
                }

                if (Define.seqCtrl[(byte)MODULE._PM3] == Define.CTRL_RUNNING)
                {
                    Define.seqCtrl[(byte)MODULE._PM3] = Define.CTRL_HOLD;

                    Global.EventLog("Pause the CH3 process", ModuleName, "Event");
                }
                */
                step.Flag = false;
                step.Times = 1;
            }
            else
            {
                F_INC_STEP();
            }
        }

        private void P_WATER_Supply()
        {
            if (step.Flag)
            {
                // 온도 셋팅                
                HanyoungNXClass.set_Temp(Configure_List.Water_Heating_Temp);
                HanyoungNXClassLibrary.Define.temp_SV = Configure_List.Water_Heating_Temp;

                //Thread.Sleep(500);
                Task.Delay(500);

                // Heater on
                Global.SetDigValue((int)DigOutputList.Hot_WaterHeater_o, (uint)DigitalOffOn.On, ModuleName);                

                // Water supply valve open
                Global.SetDigValue((int)DigOutputList.Main_Water_Supply, (uint)DigitalOffOn.On, ModuleName);

                step.Flag = false;
                step.Times = 1;
            }
            else
            {
                if (Global.GetDigValue((int)DigInputList.Water_Level_High_i) == "On")
                {
                    // Water supply valve close
                    Global.SetDigValue((int)DigOutputList.Main_Water_Supply, (uint)DigitalOffOn.Off, ModuleName);

                    Global.EventLog("Water filling is complete", ModuleName, "Event");

                    F_INC_STEP();
                }
                else
                {
                    if (step.Times >= Configure_List.Water_Fill_Timeout)
                    {
                        ShowAlarm("1008");
                    }
                    else
                    {
                        step.INC_TIMES();
                    }
                }
                
            }
        }

        private void P_WATER_Heating_Check()
        {
            if (step.Flag)
            {
                //Global.EventLog("Check the water temp", ModuleName, "Event");

                step.Flag = false;
                step.Times = 1;
            }
            else
            {
                /*
                if (Define.temp_PV >= Configure_List.Water_Heating_Temp)
                {
                    Global.EventLog("Water heating is complete", ModuleName, "Event");

                    F_INC_STEP();
                }
                else
                {
                    if (step.Times >= Configure_List.Water_Heating_Timeout)
                    {
                        ShowAlarm("1009");
                    }
                    else
                    {
                        step.INC_TIMES();
                    }
                }
                */
                F_INC_STEP();
            }
        }

        private void P_Chamber_Process_Run()
        {
            if (step.Flag)
            {
                /*
                if (Define.seqCtrl[(byte)MODULE._PM1] == Define.CTRL_HOLD)
                {
                    Define.seqCtrl[(byte)MODULE._PM1] = Define.CTRL_RUNNING;

                    Global.EventLog("Resume the CH1 process", ModuleName, "Event");
                }

                if (Define.seqCtrl[(byte)MODULE._PM2] == Define.CTRL_HOLD)
                {
                    Define.seqCtrl[(byte)MODULE._PM2] = Define.CTRL_RUNNING;

                    Global.EventLog("Resume the CH2 process", ModuleName, "Event");
                }

                if (Define.seqCtrl[(byte)MODULE._PM3] == Define.CTRL_HOLD)
                {
                    Define.seqCtrl[(byte)MODULE._PM3] = Define.CTRL_RUNNING;

                    Global.EventLog("Resume the CH3 process", ModuleName, "Event");
                }
                */

                step.Flag = false;
                step.Times = 1;
            }
            else
            {
                F_INC_STEP();
            }
        }

        private void P_WATER_Fill_End()
        {
            Define.seqMode[module] = Define.MODE_IDLE;
            Define.seqCtrl[module] = Define.CTRL_IDLE;
            Define.seqSts[module] = Define.STS_PROCESS_END;

            Global.EventLog("WATER FILLING AND HEATING IS COMPLETE.", ModuleName, "Event");

            step.Layer = 1;
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////
    }
}
