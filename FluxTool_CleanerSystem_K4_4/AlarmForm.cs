using System;
using System.IO;
using System.Windows.Forms;

namespace FluxTool_CleanerSystem_K4_4
{
    public partial class AlarmForm : Form
    {
        public AlarmForm()
        {
            InitializeComponent();
        }

        private void AlarmForm_Load(object sender, EventArgs e)
        {            
            Width = 1172;
            Height = 824;
            Top = 0;
            Left = 0;

            LoadDirectory(Global.alarmHistoryPath);
        }

        private void AlarmForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        public void LoadDirectory(string Dir)
        {
            DirectoryInfo di = new DirectoryInfo(Dir);
            TreeNode tn = treeView.Nodes.Add(di.Name);
            tn.Tag = di.FullName;
            LoadFiles(Dir, tn);
            LoadSubDirectories(Dir, tn);
            //treeView.ExpandAll();
            if (di.Name == "AlarmHistory")
                tn.Expand();
        }

        private void LoadFiles(string dir, TreeNode td)
        {
            string[] Files = Directory.GetFiles(dir, "*.*");

            foreach (string file in Files)
            {
                FileInfo fi = new FileInfo(file);
                TreeNode tn = td.Nodes.Add(fi.Name);
                tn.Tag = fi.FullName;
                tn.ImageIndex = 1;
                tn.SelectedImageIndex = 1;
            }
        }

        private void LoadSubDirectories(string dir, TreeNode td)
        {
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            foreach (string subdirectory in subdirectoryEntries)
            {
                DirectoryInfo di = new DirectoryInfo(subdirectory);
                TreeNode tn = td.Nodes.Add(di.Name);
                tn.ImageIndex = 0;
                tn.SelectedImageIndex = 0;
                tn.Tag = di.FullName;
                LoadFiles(subdirectory, tn);
                LoadSubDirectories(subdirectory, tn);
            }
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            richTextBox.Clear();

            if (e.Node.Text.Contains(".txt"))
            {
                string sBasePath = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\"));
                string sNodePath = e.Node.FullPath;
                string sFullPath = sBasePath + sNodePath;

                richTextBox.LoadFile(sFullPath, RichTextBoxStreamType.PlainText);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();

            LoadDirectory(Global.alarmHistoryPath);            
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richTextBox.Font = fd.Font;
            }
        }
    }
}
