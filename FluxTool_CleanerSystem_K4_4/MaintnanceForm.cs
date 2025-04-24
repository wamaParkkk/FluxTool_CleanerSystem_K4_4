using System;
using System.Reflection;
using System.Windows.Forms;

namespace FluxTool_CleanerSystem_K4_4
{
    public partial class MaintnanceForm : Form
    {        
        public PM1Form m_PM1Form;
        public PM2Form m_PM2Form;
        public PM3Form m_PM3Form;
        public WaterTankForm m_waterTankForm;        

        public MaintnanceForm()
        {
            InitializeComponent();            

            m_PM1Form = new PM1Form(this);
            m_PM1Form.Visible = false;
            Controls.Add(m_PM1Form);

            m_PM2Form = new PM2Form(this);
            m_PM2Form.Visible = false;
            Controls.Add(m_PM2Form);

            m_PM3Form = new PM3Form(this);
            m_PM3Form.Visible = false;
            Controls.Add(m_PM3Form);

            m_waterTankForm = new WaterTankForm(this);
            m_waterTankForm.Visible = false;
            Controls.Add(m_waterTankForm);            
        }

        private void MaintnanceForm_Load(object sender, EventArgs e)
        {            
            if (!m_PM1Form.Visible)
                m_PM1Form.Visible = true;

            if (m_PM2Form.Visible != false)
                m_PM2Form.Visible = false;

            if (m_PM3Form.Visible != false)
                m_PM3Form.Visible = false;

            if (m_waterTankForm.Visible != false)
                m_waterTankForm.Visible = false;
        }

        private void MaintnanceForm_Activated(object sender, EventArgs e)
        {
            Top = 0;
            Left = 0;

            SetDoubleBuffered(m_PM1Form);
            SetDoubleBuffered(m_PM2Form);
            SetDoubleBuffered(m_PM3Form);
            SetDoubleBuffered(m_waterTankForm);
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

        private void MaintnanceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_PM1Form.Dispose();
            m_PM2Form.Dispose();
            m_PM3Form.Dispose();
            m_waterTankForm.Dispose();

            Dispose();            
        }

        private void displayTimer_Tick(object sender, EventArgs e)
        {
            m_PM1Form.Display();
            m_PM2Form.Display();
            m_PM3Form.Display();
            m_waterTankForm.Display();            
        }        
    }
}
