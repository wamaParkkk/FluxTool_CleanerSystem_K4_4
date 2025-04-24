using System;
using System.Windows.Forms;

namespace FluxTool_CleanerSystem_K4_4
{
    public partial class ToolInfoRegistForm : Form
    {
        private int iCH;

        public ToolInfoRegistForm()
        {
            InitializeComponent();
        }

        private void ToolInfoRegistForm_Load(object sender, EventArgs e)
        {
            Top = 350;
            Left = 350;            
        }

        private void ToolInfoRegistForm_Activated(object sender, EventArgs e)
        {
            textBox_User.Focus();
        }

        public void Init(int iModule)
        {
            iCH = iModule;
            
            Define.ToolInfoRegist_User[iModule] = string.Empty;
            Define.ToolInfoRegist_Lot[iModule] = string.Empty;
            Define.ToolInfoRegist_MC[iModule] = string.Empty;
            Define.ToolInfoRegist_ToolID[iModule] = string.Empty;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_User.Text) ||
                string.IsNullOrWhiteSpace(textBox_LotNo.Text) ||
                string.IsNullOrWhiteSpace(textBox_MC.Text) ||
                string.IsNullOrWhiteSpace(textBox_ToolID.Text))
            {
                MessageBox.Show($"Tool 정보를 입력해 주세요", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string sInputText = textBox_User.Text.ToString();
                if (sInputText.Length >= 5 && sInputText.Length <= 6)
                {
                    Define.ToolInfoRegist_User[iCH] = textBox_User.Text.ToString();
                }
                else
                {
                    MessageBox.Show($"User 정보가 잘못 입력되었습니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                sInputText = textBox_LotNo.Text.ToString();
                if (sInputText.EndsWith(";"))
                {
                    Define.ToolInfoRegist_Lot[iCH] = textBox_LotNo.Text.ToString();
                }
                else
                {
                    MessageBox.Show($"Lot# 정보가 잘못 입력되었습니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                sInputText = textBox_MC.Text.ToString();
                if (sInputText.Length >= 2 && sInputText.Contains("-"))
                {
                    Define.ToolInfoRegist_MC[iCH] = textBox_MC.Text.ToString();
                }
                else
                {
                    MessageBox.Show($"M/C# 정보가 잘못 입력되었습니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                sInputText = textBox_ToolID.Text.ToString();
                if ((sInputText.Length >= 5 && sInputText.Contains("-")) ||
                     (sInputText.Length >= 5 && sInputText.Contains(";")))
                {
                    Define.ToolInfoRegist_ToolID[iCH] = textBox_ToolID.Text.ToString();
                }
                else
                {
                    MessageBox.Show($"Tool ID 정보가 잘못 입력되었습니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult = DialogResult.OK;

                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox_User_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox_LotNo.Focus();
            }
        }

        private void textBox_LotNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox_MC.Focus();
            }
        }

        private void textBox_MC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox_ToolID.Focus();
            }
        }
    }
}
