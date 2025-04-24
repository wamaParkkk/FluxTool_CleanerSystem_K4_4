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
    public partial class AnalogDlg : Form
    {
        TANA ana;

        public string m_strResult = "0";
        public float m_fResult = 0;        

        public bool b_FlagE = false;
        public bool b_FlagDot = false;
        public bool b_FlagMinus = false;

        public AnalogDlg()
        {
            InitializeComponent();

            ana.min = 0;
            ana.max = 9999999;
        }

        private void AnalogDlg_Load(object sender, EventArgs e)
        {
            Top = 300;
            Left = 500;

            txtResult.Text = "0";

            ActiveControl = txtResult;
            txtResult.Focus();
        }

        public void Init()
        {
            //
        }

        private void ana_Key_1_Click(object sender, EventArgs e)
        {
            string strTemp;
            string strTagNum;

            strTemp = txtResult.Text;
            strTemp = strTemp.Remove(0, strTemp.Length - 1);

            if (strTemp == "E")
            {
                MessageBox.Show("Invalid input", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            strTagNum = (sender as Button).Tag.ToString();

            if (m_strResult == "0")
            {
                m_strResult = strTagNum;
            }
            else
            {
                m_strResult += strTagNum;
            }

            txtResult.Text = m_strResult;
        }

        private void ana_Key_Dot_Click(object sender, EventArgs e)
        {
            string strTemp;

            strTemp = txtResult.Text;
            strTemp = strTemp.Remove(0, strTemp.Length - 1);

            if (strTemp == "E" || strTemp == "-")
            {
                MessageBox.Show("Invalid input", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!b_FlagDot)
            {
                if (m_strResult == "0")
                {
                    m_strResult = "0.";
                }
                else
                {
                    m_strResult += ".";
                }

                b_FlagDot = true;
            }
            else
            {
                MessageBox.Show("Invalid input", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            txtResult.Text = m_strResult;
        }

        private void ana_Key_Minus_Click(object sender, EventArgs e)
        {
            string strTemp;

            strTemp = txtResult.Text;
            strTemp = strTemp.Remove(0, strTemp.Length - 1);

            if (strTemp == "E")
            {
                m_strResult += "-";
                b_FlagMinus = true;
            }
            else if (strTemp == "0")
            {
                m_strResult = "-";
                b_FlagMinus = true;
            }
            else
            {
                MessageBox.Show("Invalid input", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            txtResult.Text = m_strResult;
        }

        private void ana_Key_E_Click(object sender, EventArgs e)
        {
            string strTemp;

            strTemp = txtResult.Text;
            strTemp = strTemp.Remove(0, strTemp.Length - 1);

            if (strTemp == ".")
            {
                MessageBox.Show("Invalid input", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!b_FlagE)
            {
                if (m_strResult == "0")
                {
                    return;
                }
                else
                {
                    m_strResult += "E";
                }

                b_FlagE = true;
            }
            else
            {
                MessageBox.Show("Invalid input", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            txtResult.Text = m_strResult;
        }

        private void m_Key_Del_Click(object sender, EventArgs e)
        {
            string strTemp;

            strTemp = txtResult.Text;
            strTemp = strTemp.Remove(0, strTemp.Length - 1);

            if (strTemp == "E")
            {
                b_FlagE = false;
            }
            else if (strTemp == ".")
            {
                b_FlagDot = false;
            }
            else if (strTemp == "-")
            {
                b_FlagMinus = false;
            }

            if (m_strResult.Length == 1)
            {
                m_strResult = "0";
            }
            else
            {
                m_strResult = m_strResult.Remove(m_strResult.Length - 1, 1);
            }
            txtResult.Text = m_strResult;
        }

        private void m_Key_Clear_Click(object sender, EventArgs e)
        {
            m_strResult = "0";
            txtResult.Text = m_strResult;

            b_FlagE = false;
            b_FlagDot = false;
            b_FlagMinus = false;
        }

        private void ana_Key_Cancel_Click(object sender, EventArgs e)
        {
            m_strResult = "0";
            m_fResult = 0;
            txtResult.Text = m_strResult;

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ana_Key_OK_Click(object sender, EventArgs e)
        {
            RESULT_VALUE();            
        }

        private void RESULT_VALUE()
        {
            try
            {
                string strEnd = m_strResult.Remove(0, m_strResult.Length - 1);

                if (strEnd == "-" || strEnd == ".")
                {
                    MessageBox.Show("Invalid input", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double i = Convert.ToDouble(m_strResult);

                if (ana.min > i)
                {
                    MessageBox.Show("Less than the range", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ana.max < i)
                {
                    MessageBox.Show("Out of range", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                m_fResult = (float)Convert.ToDouble(m_strResult);

                m_strResult = FloatToString(m_fResult, ana.dec);
            }
            catch
            {
                MessageBox.Show("Invalid data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public static string FloatToString(float fval, int nDec)
        {
            string strVal = "";

            if (nDec == 0)
            {
                strVal = (int)fval + "";
            }
            else if (0 < nDec && nDec < 9)
            {
                string strdec = "#0.";
                for (int i = 0; i < nDec; i++)
                {
                    strdec += "0";
                }

                strVal = fval.ToString(strdec);
            }
            else if (nDec == 9)
            {
                strVal = DoubleToExponent(1, fval);
            }
            else if (nDec == 10)
            {
                strVal = DoubleToExponent(2, fval);
            }

            return strVal;
        }

        public static string DoubleToExponent(int nDec, double fVal)
        {
            string strTemp = "";

            if (fVal == 0.0)
            {
                strTemp = "0.0";
                return strTemp;
            }

            if (nDec == 1)
            {
                strTemp = fVal.ToString("0.0E+0");
            }
            else if (nDec == 2)
            {
                strTemp = fVal.ToString("0.00E+0");
            }
            return strTemp;
        }

        private void txtResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RESULT_VALUE();
            }
        }
        private void s_txtResult_TextChanged(object sender, EventArgs e)
        {
            m_strResult = txtResult.Text;
            txtResult.Focus();
            txtResult.Select(txtResult.TextLength, 0);
        }        
    }
}
