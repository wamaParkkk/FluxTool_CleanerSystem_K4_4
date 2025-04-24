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
    public partial class KeyboardDlg : Form
    {
        private bool m_bShift = false;
        private bool m_bCapsLock = false;
        private bool m_bCtrl = false;
        private bool m_bAlt = false;

        public string m_strResult = "";

        public KeyboardDlg()
        {
            InitializeComponent();
        }

        private void KeyboardDlg_Load(object sender, EventArgs e)
        {
            Top = 300;
            Left = 300;

            m_bShift = false;
            m_bCapsLock = false;
            m_bCtrl = false;
            m_bAlt = false;
        }

        private void m_Key_SignTo_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += "~";
            }
            else
            {
                m_strResult += "`";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_1_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += "!";
            }
            else
            {
                m_strResult += "1";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_2_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += "@";
            }
            else
            {
                m_strResult += "2";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_3_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += "#";
            }
            else
            {
                m_strResult += "3";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_4_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += "$";
            }
            else
            {
                m_strResult += "4";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_5_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += "%";
            }
            else
            {
                m_strResult += "5";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_6_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += "^";
            }
            else
            {
                m_strResult += "6";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_7_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += "&";
            }
            else
            {
                m_strResult += "7";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_8_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += "*";
            }
            else
            {
                m_strResult += "8";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_9_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += "(";
            }
            else
            {
                m_strResult += "9";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_0_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += ")";
            }
            else
            {
                m_strResult += "0";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_Minus_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += "_";
            }
            else
            {
                m_strResult += "-";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_Plus_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += "+";
            }
            else
            {
                m_strResult += "=";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_BackSpace_Click(object sender, EventArgs e)
        {
            if (m_strResult.Length <= 1)
            {
                m_strResult = "";
            }
            else
            {
                m_strResult = m_strResult.Remove(m_strResult.Length - 1);
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_Tab_Click(object sender, EventArgs e)
        {
            if (m_strResult.Length > 0)
            {
                m_strResult += "    ";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_Q_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "q";
                }
                else
                {
                    m_strResult += "Q";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "Q";
                }
                else
                {
                    m_strResult += "q";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_W_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "w";
                }
                else
                {
                    m_strResult += "W";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "W";
                }
                else
                {
                    m_strResult += "w";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_E_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "e";
                }
                else
                {
                    m_strResult += "E";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "E";
                }
                else
                {
                    m_strResult += "e";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_R_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "r";
                }
                else
                {
                    m_strResult += "R";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "R";
                }
                else
                {
                    m_strResult += "r";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_T_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "t";
                }
                else
                {
                    m_strResult += "T";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "T";
                }
                else
                {
                    m_strResult += "t";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_Y_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "y";
                }
                else
                {
                    m_strResult += "Y";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "Y";
                }
                else
                {
                    m_strResult += "y";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_U_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "u";
                }
                else
                {
                    m_strResult += "U";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "U";
                }
                else
                {
                    m_strResult += "u";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_I_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "i";
                }
                else
                {
                    m_strResult += "I";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "I";
                }
                else
                {
                    m_strResult += "i";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_O_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "o";
                }
                else
                {
                    m_strResult += "O";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "O";
                }
                else
                {
                    m_strResult += "o";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_P_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "p";
                }
                else
                {
                    m_strResult += "P";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "P";
                }
                else
                {
                    m_strResult += "p";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_LBracket_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += "{";
            }
            else
            {
                m_strResult += "[";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_RBracket_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += "}";
            }
            else
            {
                m_strResult += "]";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_BackSlash_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += "|";
            }
            else
            {
                m_strResult += "\\";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_Caps_Click(object sender, EventArgs e)
        {
            m_bCapsLock = !m_bCapsLock;
        }

        private void m_Key_A_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "a";
                }
                else
                {
                    m_strResult += "A";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "A";
                }
                else
                {
                    m_strResult += "a";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_S_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "s";
                }
                else
                {
                    m_strResult += "S";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "S";
                }
                else
                {
                    m_strResult += "s";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_D_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "d";
                }
                else
                {
                    m_strResult += "D";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "D";
                }
                else
                {
                    m_strResult += "d";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_F_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "f";
                }
                else
                {
                    m_strResult += "F";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "F";
                }
                else
                {
                    m_strResult += "f";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_G_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "g";
                }
                else
                {
                    m_strResult += "G";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "G";
                }
                else
                {
                    m_strResult += "g";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_H_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "h";
                }
                else
                {
                    m_strResult += "H";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "H";
                }
                else
                {
                    m_strResult += "h";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_J_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "j";
                }
                else
                {
                    m_strResult += "J";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "J";
                }
                else
                {
                    m_strResult += "j";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_K_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "k";
                }
                else
                {
                    m_strResult += "K";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "K";
                }
                else
                {
                    m_strResult += "k";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_L_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "l";
                }
                else
                {
                    m_strResult += "L";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "L";
                }
                else
                {
                    m_strResult += "l";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_Colon_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += ":";
            }
            else
            {
                m_strResult += ";";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_Quotation_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += "\"";
            }
            else
            {
                m_strResult += "'";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_Enter_Click(object sender, EventArgs e)
        {
            m_txtResult.Text = m_strResult;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_Key_LShift_Click(object sender, EventArgs e)
        {
            m_bShift = !m_bShift;
        }

        private void m_Key_Z_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "z";
                }
                else
                {
                    m_strResult += "Z";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "Z";
                }
                else
                {
                    m_strResult += "z";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_X_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "x";
                }
                else
                {
                    m_strResult += "X";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "X";
                }
                else
                {
                    m_strResult += "x";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_C_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "c";
                }
                else
                {
                    m_strResult += "C";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "C";
                }
                else
                {
                    m_strResult += "c";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_V_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "v";
                }
                else
                {
                    m_strResult += "V";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "V";
                }
                else
                {
                    m_strResult += "v";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_B_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "b";
                }
                else
                {
                    m_strResult += "B";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "B";
                }
                else
                {
                    m_strResult += "b";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_N_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "n";
                }
                else
                {
                    m_strResult += "N";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "N";
                }
                else
                {
                    m_strResult += "n";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_M_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                if (m_bShift)
                {
                    m_strResult += "m";
                }
                else
                {
                    m_strResult += "M";
                }
            }
            else
            {
                if (m_bShift)
                {
                    m_strResult += "M";
                }
                else
                {
                    m_strResult += "m";
                }
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_Comma_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += "<";
            }
            else
            {
                m_strResult += ",";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_Period_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += ">";
            }
            else
            {
                m_strResult += ".";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_Slash_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_strResult += "?";
            }
            else
            {
                m_strResult += "/";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_RShift_Click(object sender, EventArgs e)
        {
            m_bShift = !m_bShift;
        }

        private void m_Key_LCtrl_Click(object sender, EventArgs e)
        {
            m_bCtrl = !m_bCtrl;
        }

        private void m_Key_LAlt_Click(object sender, EventArgs e)
        {
            m_bAlt = !m_bAlt;
        }

        private void m_Key_Space_Click(object sender, EventArgs e)
        {
            if (m_strResult.Length > 0)
            {
                m_strResult += " ";
            }
            m_txtResult.Text = m_strResult;
        }

        private void m_Key_RAlt_Click(object sender, EventArgs e)
        {
            m_bAlt = !m_bAlt;
        }

        private void m_Key_RCtrl_Click(object sender, EventArgs e)
        {
            m_bCtrl = !m_bCtrl;
        }

        private void m_Key_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_Key_Cancel_Click(object sender, EventArgs e)
        {
            m_strResult = "";
            m_txtResult.Text = m_strResult;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void m_txtResult_TextChanged(object sender, EventArgs e)
        {
            m_strResult = m_txtResult.Text;
            m_txtResult.Focus();
            m_txtResult.Select(m_txtResult.TextLength, 0);
        }

        private void m_txtResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public void Set_Password(bool bPass)
        {
            if (bPass)
            {
                m_txtResult.PasswordChar = '●';
            }
            else
            {
                m_txtResult.PasswordChar = '\0';
            }
        }        
    }
}
