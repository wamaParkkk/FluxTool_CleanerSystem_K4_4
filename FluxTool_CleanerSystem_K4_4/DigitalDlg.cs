using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FluxTool_CleanerSystem_K4_4
{
    public partial class DigitalDlg : Form
    {
        public string m_strResult = "";

        public DigitalDlg()
        {
            InitializeComponent();
        }

        private void DigitalDlg_Load(object sender, EventArgs e)
        {
            Top = 350;
            Left = 500;
        }

        public void Init(string sVal1, string sVal2, string ioName)
        {
            m_strResult = string.Empty;
            labelIOName.Text = ioName;
            m_lstState.Items.Add(sVal1);
            m_lstState.Items.Add(sVal2);
        }

        public void Init2(string sVal1, string sVal2, string sVal3, string ioName)
        {
            m_strResult = string.Empty;
            labelIOName.Text = ioName;
            m_lstState.Items.Add(sVal1);
            m_lstState.Items.Add(sVal2);
            m_lstState.Items.Add(sVal3);
        }

        private void m_Key_OK_Click(object sender, EventArgs e)
        {
            string sSel = "";
            if (m_lstState.Items.Count > 0)
            {
                if (m_lstState.SelectedIndex != -1)
                {
                    sSel = m_lstState.SelectedItem.ToString();
                    m_strResult = sSel;
                    DialogResult = DialogResult.OK;
                }                
            }

            Close();
        }

        private void m_lstState_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string sSel = "";
            if (m_lstState.Items.Count > 0)
            {
                if (m_lstState.SelectedIndex != -1)
                {
                    sSel = m_lstState.SelectedItem.ToString();
                    m_strResult = sSel;
                    DialogResult = DialogResult.OK;
                }                    
            }
            
            Close();
        }

        private void m_Key_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }     
    }
}
