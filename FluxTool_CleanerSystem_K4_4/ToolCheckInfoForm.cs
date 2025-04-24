using System;
using System.Windows.Forms;

namespace FluxTool_CleanerSystem_K4_4
{
    public partial class ToolCheckInfoForm : Form
    {
        public ToolCheckInfoForm()
        {
            InitializeComponent();
        }

        private void ToolCheckInfoForm_Load(object sender, EventArgs e)
        {
            Top = 350;
            Left = 350;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }        
    }
}
