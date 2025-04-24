using Ajin_IO_driver;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace FluxTool_CleanerSystem_K4_4
{
    public partial class IOForm : Form
    {
        private Panel[] m_diBox;
        private CheckBox[] m_doBox;

        public IOForm()
        {
            InitializeComponent();
        }

        private void IOForm_Load(object sender, EventArgs e)
        {
            Width = 1172;
            Height = 824;
            Top = 0;
            Left = 0;

            m_diBox = new Panel[Define.CH_MAX] {
                pnl_DI00, pnl_DI01, pnl_DI02, pnl_DI03, pnl_DI04, pnl_DI05, pnl_DI06, pnl_DI07,
                pnl_DI08, pnl_DI09, pnl_DI10, pnl_DI11, pnl_DI12, pnl_DI13, pnl_DI14, pnl_DI15,
                pnl_DI16, pnl_DI17, pnl_DI18, pnl_DI19, pnl_DI20, pnl_DI21, pnl_DI22, pnl_DI23,
                pnl_DI24, pnl_DI25, pnl_DI26, pnl_DI27, pnl_DI28, pnl_DI29, pnl_DI30, pnl_DI31 };

            m_doBox = new CheckBox[Define.CH_MAX]
            {
                rjToggleButton0, rjToggleButton1, rjToggleButton2, rjToggleButton3, rjToggleButton4, rjToggleButton5, rjToggleButton6, rjToggleButton7,
                rjToggleButton8, rjToggleButton9, rjToggleButton10, rjToggleButton11, rjToggleButton12, rjToggleButton13, rjToggleButton14, rjToggleButton15,
                rjToggleButton16, rjToggleButton17, rjToggleButton18, rjToggleButton19, rjToggleButton20, rjToggleButton21, rjToggleButton22, rjToggleButton23,
                rjToggleButton24, rjToggleButton25, rjToggleButton26, rjToggleButton27, rjToggleButton28, rjToggleButton29, rjToggleButton30, rjToggleButton31
            };            
        }

        private void IOForm_Activated(object sender, EventArgs e)
        {
            SetDoubleBuffered(groupBox1);
            SetDoubleBuffered(groupBox2);
            SetDoubleBuffered(groupBox3);
            SetDoubleBuffered(groupBox4);
        }

        private void IOForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DI_Parsing_timer.Stop();

            Dispose();
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

        private void DI_Parsing_timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Define.CH_MAX; i++)
            {
                if ((i == 7) ||
                    (i == 10) || (i == 12) ||                    
                    (i == 13) || (i == 15) || 
                    (i == 16) || (i == 18))
                {
                    if (Global.GetDigValue(i) == "Off")
                    {
                        m_diBox[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        m_diBox[i].BackColor = Color.DimGray;
                    }
                }
                else
                {
                    if (Global.GetDigValue(i) == "On")
                    {
                        m_diBox[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        m_diBox[i].BackColor = Color.DimGray;
                    }
                }                
            }

            for (int i = 0; i < Define.CH_MAX; i++)
            {
                if (Global.digSet.curDigSet[i] != null)
                {
                    if (Global.digSet.curDigSet[i] == "On")
                    {
                        if (!m_doBox[i].Checked)
                            m_doBox[i].Checked = true;
                    }
                    else
                    {
                        if (m_doBox[i].Checked != false)
                            m_doBox[i].Checked = false;
                    }
                }
            }            
        }

        private void CH1_IO_Click(object sender, EventArgs e)
        {
            /*
            if ((Define.seqCtrl[(byte)MODULE._PM1] != Define.CTRL_IDLE) ||
                (Define.seqCylinderCtrl[(byte)MODULE._PM1] != Define.CTRL_IDLE))
            {
                MessageBox.Show("CH1 process is in progress", "Notification");
                return;
            }
            */

            CheckBox btn = (CheckBox)sender;

            int iName = int.Parse(btn.Tag.ToString());
            if (Global.digSet.curDigSet[iName] == "Off")
            {
                Global.SetDigValue(iName, (uint)DigitalValue.On, "PM1");
            }
            else
            {
                Global.SetDigValue(iName, (uint)DigitalValue.Off, "PM1");
            }
        }

        private void CH2_IO_Click(object sender, EventArgs e)
        {
            /*
            if ((Define.seqCtrl[(byte)MODULE._PM2] != Define.CTRL_IDLE) ||
                (Define.seqCylinderCtrl[(byte)MODULE._PM2] != Define.CTRL_IDLE))
            {
                MessageBox.Show("CH2 process is in progress", "Notification");
                return;
            }
            */

            CheckBox btn = (CheckBox)sender;

            int iName = int.Parse(btn.Tag.ToString());
            if (Global.digSet.curDigSet[iName] == "Off")
            {
                Global.SetDigValue(iName, (uint)DigitalValue.On, "PM2");
            }
            else
            {
                Global.SetDigValue(iName, (uint)DigitalValue.Off, "PM2");
            }
        }

        private void CH3_IO_Click(object sender, EventArgs e)
        {
            /*
            if ((Define.seqCtrl[(byte)MODULE._PM3] != Define.CTRL_IDLE) ||
                (Define.seqCylinderCtrl[(byte)MODULE._PM3] != Define.CTRL_IDLE))
            {
                MessageBox.Show("CH3 process is in progress", "Notification");
                return;
            }
            */

            CheckBox btn = (CheckBox)sender;

            int iName = int.Parse(btn.Tag.ToString());
            if (Global.digSet.curDigSet[iName] == "Off")
            {
                Global.SetDigValue(iName, (uint)DigitalValue.On, "PM3");
            }
            else
            {
                Global.SetDigValue(iName, (uint)DigitalValue.Off, "PM3");
            }
        }

        private void MAIN_IO_Click(object sender, EventArgs e)
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

            CheckBox btn = (CheckBox)sender;

            int iName = int.Parse(btn.Tag.ToString());
            if (Global.digSet.curDigSet[iName] == "Off")
            {
                Global.SetDigValue(iName, (uint)DigitalValue.On, "PM1");
            }
            else
            {
                Global.SetDigValue(iName, (uint)DigitalValue.Off, "PM1");
            }
        }        
    }
}
