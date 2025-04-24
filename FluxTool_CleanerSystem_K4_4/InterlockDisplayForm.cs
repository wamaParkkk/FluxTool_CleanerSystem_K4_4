using System;
using System.Windows.Forms;

namespace FluxTool_CleanerSystem_K4_4
{
    public partial class InterlockDisplayForm : Form
    {
        public InterlockDisplayForm()
        {
            InitializeComponent();
        }

        private void InterlockDisplayForm_Load(object sender, EventArgs e)
        {
            Top = 350;
            Left = 350;

            labelMessage.Text = Define.sInterlockMsg;
            labelChecklist.Text = Define.sInterlockChecklist;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {            
            DialogResult = DialogResult.OK;            
            
            Close();
        }
    }
}
