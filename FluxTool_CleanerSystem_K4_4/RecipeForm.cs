using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

enum EditMode : byte
{
    NORMAL_MODE = 0,
    VIEW_MODE = 1,
    EDIT_MODE = 2
}

namespace FluxTool_CleanerSystem_K4_4
{
    public partial class RecipeForm : Form
    {
        AnalogDlg AnaDlg;
        DigitalDlg DigDlg;
        KeyboardDlg KeyDlg;

        private byte m_nEditMode;        

        public RecipeForm()
        {
            InitializeComponent();
        }

        private void RecipeForm_Load(object sender, EventArgs e)
        {
            Width = 1172;
            Height = 824;
            Top = 0;
            Left = 0;            

            RECIPE_GRID_INIT();
        }

        private void RecipeForm_Activated(object sender, EventArgs e)
        {
            SetDoubleBuffered(recipeGrid);
        }

        private void RecipeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
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

        private void RECIPE_GRID_INIT()
        {
            recipeGrid.AllowUserToAddRows = false;
            recipeGrid.AllowUserToDeleteRows = false;

            recipeGrid.AutoSize = false;
            recipeGrid.RowHeadersVisible = false;
            recipeGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;            
            recipeGrid.ReadOnly = true;
            recipeGrid.AutoGenerateColumns = false;
            recipeGrid.MultiSelect = false;            

            recipeGrid.ColumnCount = 2;
            recipeGrid.RowCount = 0;

            recipeGrid.Columns[0].Name = "Item/Step";
            recipeGrid.Columns[1].Name = "1";

            recipeGrid.Rows.Add("Step Name");
            recipeGrid.Rows.Add("Water");                     
            recipeGrid.Rows.Add("Air knife");
            recipeGrid.Rows.Add("Pin move");
            recipeGrid.Rows.Add("Time(Sec)");            

            Get_lstRecipeFile();

            nEditMode = (byte)EditMode.NORMAL_MODE;            
        }        

        private void Get_lstRecipeFile()
        {
            try
            {                
                listBox_RecipeName.Items.Clear();
                
                if (Directory.Exists(Global.RecipeFilePath))
                {
                    string[] FileList = Directory.GetFiles(Global.RecipeFilePath, "*.csv");
                    string[] strSplit = new string[1];
                    strSplit[0] = "\\";

                    for (int i = 0; i < FileList.Length; i++)
                    {
                        string[] FileSplit = FileList[i].Split(strSplit, StringSplitOptions.RemoveEmptyEntries);
                        listBox_RecipeName.Items.Add(FileSplit[FileSplit.Length - 1]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }
        }

        private void listBox_RecipeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_RecipeName.SelectedItem != null)
            {
                string strFileName = listBox_RecipeName.SelectedItem.ToString();
                txt_RecipeFileName.Text = strFileName;

                Recipe_Open(strFileName);
            }
        }

        private void Recipe_Open(string strFileName)
        {
            strFileName = Global.RecipeFilePath + "\\" + strFileName;
            Process_Recipe_Load(strFileName);

            nEditMode = (byte)EditMode.VIEW_MODE;
        }

        private void Process_Recipe_Load(string FileName)
        {                  
            try
            {
                string rowValue;
                string[] cellValue;                
                recipeGrid.Rows.Clear();
                recipeGrid.Columns.Clear();

                if (File.Exists(FileName))
                {
                    StreamReader streamReader = new StreamReader(FileName);
                    rowValue = streamReader.ReadLine();
                    cellValue = rowValue.Split(',');
                    
                    for (int i = 0; i <= cellValue.Count() - 1; i++)
                    {
                        DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                        column.Name = cellValue[i];
                        column.HeaderText = cellValue[i];
                        recipeGrid.Columns.Add(column);                        
                    }

                    while (streamReader.Peek() != -1)
                    {
                        rowValue = streamReader.ReadLine();
                        cellValue = rowValue.Split(',');
                        recipeGrid.Rows.Add(cellValue);
                    }
                    streamReader.Close();

                    Grid_NotSortable();
                }
                else
                {
                    MessageBox.Show("Recipe file not selected", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }
        }

        private void recipeGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView view = sender as DataGridView;
                
                if (e.RowIndex >= 0 && recipeGrid.Rows.Count - 1 >= e.RowIndex && e.ColumnIndex > 0)
                {
                    DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)recipeGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    txt_CurStep.Text = e.ColumnIndex.ToString();
                    txt_Step.Text = e.ColumnIndex.ToString() + " / " + (recipeGrid.Columns.Count - 1);

                    if (m_nEditMode == (byte)EditMode.EDIT_MODE)
                    {
                        if (e.RowIndex == 0)
                        {
                            KeyDlg = new KeyboardDlg();
                            KeyDlg.Set_Password(false);
                            if (KeyDlg.ShowDialog() == DialogResult.OK)
                            {
                                cell.Value = KeyDlg.m_strResult;
                            }
                        }
                        else if ((e.RowIndex >= 1) && (e.RowIndex <= 2))
                        {                            
                            DigDlg = new DigitalDlg();
                            DigDlg.Init("Off", "On", "--");
                            if (DigDlg.ShowDialog() == DialogResult.OK)
                            {
                                cell.Value = DigDlg.m_strResult;
                                if (cell.Value.ToString() == "On")
                                {
                                    view.CurrentCell.Style.BackColor = Color.SkyBlue;
                                }
                                else if (cell.Value.ToString() == "Off")
                                {                                    
                                    view.CurrentCell.Style.BackColor = Color.White;
                                }
                                else
                                {
                                    cell.Value = "Off";
                                    view.CurrentCell.Style.BackColor = Color.White;
                                }
                            }                            
                        }
                        else if (e.RowIndex == 3)
                        {
                            DigDlg = new DigitalDlg();
                            DigDlg.Init2("Up", "Down", "Up/Down", "--");
                            if (DigDlg.ShowDialog() == DialogResult.OK)
                            {
                                cell.Value = DigDlg.m_strResult;
                                if (cell.Value.ToString() == "Up")
                                {
                                    view.CurrentCell.Style.BackColor = Color.SkyBlue;
                                }
                                else if (cell.Value.ToString() == "Down")
                                {
                                    view.CurrentCell.Style.BackColor = Color.SkyBlue;
                                }
                                else if (cell.Value.ToString() == "Up/Down")
                                {
                                    view.CurrentCell.Style.BackColor = Color.SkyBlue;
                                }
                                else
                                {
                                    cell.Value = "Up";
                                    view.CurrentCell.Style.BackColor = Color.SkyBlue;
                                }
                            }
                        }
                        else if (e.RowIndex >= 4)
                        {
                            AnaDlg = new AnalogDlg();
                            AnaDlg.Init();
                            if (AnaDlg.ShowDialog() == DialogResult.OK)
                            {
                                cell.Value = AnaDlg.m_strResult;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }            
        }

        private void btn_RecipeFile_New_Click(object sender, EventArgs e)
        {
            try
            {
                KeyDlg = new KeyboardDlg();
                KeyDlg.Set_Password(false);
                if (KeyDlg.ShowDialog() == DialogResult.OK)
                {
                    txt_RecipeFileName.Text = KeyDlg.m_strResult;
                    if (txt_RecipeFileName.Text.IndexOf(".csv") < 0)
                    {
                        txt_RecipeFileName.Text += ".csv";
                    }
                    txt_Step.Text = "0 / 0";
                    txt_CurStep.Text = "0";

                    string RecipePath = Global.RecipeFilePath + "\\";                    
                    if (File.Exists(RecipePath + txt_RecipeFileName.Text))
                    {
                        MessageBox.Show("A file with the same name already exists", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;                        
                    }
                    else
                    {
                        RECIPE_GRID_INIT();

                        nEditMode = (byte)EditMode.EDIT_MODE;
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }
        }

        private void btn_RecipeFile_Edit_Click(object sender, EventArgs e)
        {
            nEditMode = (byte)EditMode.EDIT_MODE;            
        }

        private void btn_RecipeFile_Copy_Click(object sender, EventArgs e)
        {            
            try
            {
                if (listBox_RecipeName.Items.Count > 0)
                {
                    if (0 <= listBox_RecipeName.SelectedIndex && listBox_RecipeName.SelectedIndex < listBox_RecipeName.Items.Count)
                    {
                        string strFileName = listBox_RecipeName.SelectedItem.ToString();
                        string strCopyName = "";
                        string RecipePath = "";

                        KeyDlg = new KeyboardDlg();
                        KeyDlg.Set_Password(false);

                        if (KeyDlg.ShowDialog() == DialogResult.OK)
                        {
                            strCopyName = KeyDlg.m_strResult;
                            if (strCopyName.IndexOf(".csv") < 0)
                            {
                                strCopyName += ".csv";
                            }

                            RecipePath = Global.RecipeFilePath + "\\";

                            strFileName = RecipePath + strFileName;
                            strCopyName = RecipePath + strCopyName;

                            if (File.Exists(strFileName))
                            {
                                if (File.Exists(strCopyName))
                                {
                                    MessageBox.Show("A file with the same name already exists", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                    File.Copy(strFileName, strCopyName, true);
                                }
                            }
                        }
                    }
                }

                Get_lstRecipeFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }
        }

        private void btn_RecipeFile_Save_Click(object sender, EventArgs e)
        {            
            ExportToCSV();
        }

        private void ExportToCSV()
        {
            try
            {
                int columnCount = recipeGrid.Columns.Count - 1;                

                for (int i = 1; i <= 3; i++)
                {
                    for (int j = 1; j <= columnCount; j++)
                    {
                        if ((recipeGrid.Rows[i].Cells[j].Value == null) || (recipeGrid.Rows[i].Cells[j].Value.ToString() == ""))
                        {
                            recipeGrid.Rows[i].Cells[j].Value = "Off";
                        }
                    }
                }

                for (int j = 1; j <= columnCount; j++)
                {
                    if ((recipeGrid.Rows[4].Cells[j].Value == null) || (recipeGrid.Rows[4].Cells[j].Value.ToString() == ""))
                    {
                        recipeGrid.Rows[4].Cells[j].Value = "0";
                    }
                }
                
                string RecipePath = "";
                RecipePath = Global.RecipeFilePath + "\\";
                RecipePath += txt_RecipeFileName.Text;

                Save_csv(RecipePath, recipeGrid, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }
        }
        
        private void Save_csv(string fileName, DataGridView dgView, bool header)
        {
            try
            {
                string delimiter = ",";
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter csvExport = new StreamWriter(fs, Encoding.UTF8);

                if (dgView.Rows.Count == 0)
                {
                    return;
                }

                if (header)
                {
                    for (int i = 0; i < dgView.Columns.Count; i++)
                    {
                        csvExport.Write(dgView.Columns[i].HeaderText);
                        if (i != dgView.Columns.Count - 1)
                        {
                            csvExport.Write(delimiter);
                        }
                    }
                }

                csvExport.Write(csvExport.NewLine);

                foreach (DataGridViewRow row in dgView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        for (int i = 0; i < dgView.Columns.Count; i++)
                        {
                            csvExport.Write(row.Cells[i].Value);
                            if (i != dgView.Columns.Count - 1)
                            {
                                csvExport.Write(delimiter);
                            }
                        }
                        csvExport.Write(csvExport.NewLine);
                    }
                }

                csvExport.Flush();
                csvExport.Close();
                fs.Close();

                MessageBox.Show("Recipe file has been saved", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                nEditMode = (int)EditMode.NORMAL_MODE;
                Get_lstRecipeFile();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }            
        }        

        private void btn_RecipeFile_Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox_RecipeName.Items.Count > 0)
                {
                    if (0 <= listBox_RecipeName.SelectedIndex && listBox_RecipeName.SelectedIndex < listBox_RecipeName.Items.Count)
                    {
                        string RecipePath = "";
                        string strFileName = listBox_RecipeName.SelectedItem.ToString();
                        RecipePath = Global.RecipeFilePath + "\\";
                        strFileName = RecipePath + strFileName;

                        if (File.Exists(strFileName))
                        {
                            if (MessageBox.Show("Are you sure you want to delete the recipe file?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                File.Delete(strFileName);
                            }
                        }
                    }
                }

                txt_RecipeFileName.Text = "";                
                nEditMode = (byte)EditMode.NORMAL_MODE;
                Get_lstRecipeFile();
                RECIPE_GRID_INIT();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }
        }        

        private void btn_RecipeFile_Cancel_Click(object sender, EventArgs e)
        {
            if (listBox_RecipeName.Items.Count != 0)
                listBox_RecipeName.SelectedIndex = 0;

            Get_lstRecipeFile();            
            Recipe_Open(txt_RecipeFileName.Text.ToString());
        }

        private void btn_RecipeStep_Add_Click(object sender, EventArgs e)
        {            
            Recipe_Step_Grid_Add();
        }

        private void Recipe_Step_Grid_Add()
        {            
            try
            {                                               
                recipeGrid.Columns.Add(recipeGrid.Columns.Count.ToString(), recipeGrid.Columns.Count.ToString());

                //Grid_NotSortable();
                CurrentCol_Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }
        }

        private void btn_RecipeStep_Insert_Click(object sender, EventArgs e)
        {            
            Recipe_Step_Grid_Insert();
        }

        private void Recipe_Step_Grid_Insert()
        {
            try
            {
                DataGridViewTextBoxColumn InsertCol = new DataGridViewTextBoxColumn();

                int nInsertCol = Convert.ToInt16(txt_CurStep.Text);
                if (nInsertCol <= 0)
                {
                    nInsertCol++;
                }

                recipeGrid.Columns.Insert(nInsertCol, InsertCol);

                for (int i = 1; i < recipeGrid.Columns.Count; i++)
                {
                    recipeGrid.Columns[i].Name = i.ToString();
                    recipeGrid.Columns[i].HeaderText = i.ToString();
                }

                CurrentCol_Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }
        }

        private void btn_RecipeStep_Del_Click(object sender, EventArgs e)
        {
            Recipe_Step_Grid_Delete();
        }

        private void Recipe_Step_Grid_Delete()
        {
            try
            {
                if (recipeGrid.Columns.Count > 2)
                {
                    int nDelCol = Convert.ToInt16(txt_CurStep.Text);
                    if (nDelCol > 0)
                    {
                        recipeGrid.Columns.RemoveAt(nDelCol);
                    }

                    for (int i = 1; i < recipeGrid.Columns.Count; i++)
                    {
                        recipeGrid.Columns[i].Name = i.ToString();
                        recipeGrid.Columns[i].HeaderText = i.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("At least one item is required", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                CurrentCol_Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }
        }

        private void recipeGrid_SelectionChanged(object sender, EventArgs e)
        {
            CurrentCol_Update();
        }

        private void CurrentCol_Update()
        {
            try
            {
                Point CurrentCell = recipeGrid.CurrentCellAddress;
                txt_CurStep.Text = CurrentCell.X.ToString();
                txt_Step.Text = CurrentCell.X.ToString() + " / " + (recipeGrid.Columns.Count - 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }            
        }        

        private void Grid_NotSortable()
        {
            foreach (DataGridViewColumn item in recipeGrid.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private byte nEditMode
        {
            get
            {
                return m_nEditMode;
            }
            set
            {
                m_nEditMode = value;
                switch (value)
                {
                    case (byte)EditMode.NORMAL_MODE:
                        {
                            txt_Mode.Text = "VIEW";
                            btn_RecipeFile_New.Enabled = true;
                            btn_RecipeFile_Edit.Enabled = false;
                            btn_RecipeFile_Copy.Enabled = false;
                            btn_RecipeFile_Save.Enabled = false;
                            btn_RecipeFile_Del.Enabled = false;
                            btn_RecipeFile_Cancel.Enabled = false;

                            btn_RecipeStep_Add.Enabled = false;
                            btn_RecipeStep_Insert.Enabled = false;
                            btn_RecipeStep_Del.Enabled = false;
                        }
                        break;

                    case (byte)EditMode.VIEW_MODE:
                        {
                            txt_Mode.Text = "VIEW";
                            btn_RecipeFile_New.Enabled = true;
                            btn_RecipeFile_Edit.Enabled = true;
                            btn_RecipeFile_Copy.Enabled = true;
                            btn_RecipeFile_Save.Enabled = false;
                            btn_RecipeFile_Del.Enabled = true;
                            btn_RecipeFile_Cancel.Enabled = false;

                            btn_RecipeStep_Add.Enabled = false;
                            btn_RecipeStep_Insert.Enabled = false;
                            btn_RecipeStep_Del.Enabled = false;
                        }
                        break;

                    case (byte)EditMode.EDIT_MODE:
                        {
                            txt_Mode.Text = "EDIT";
                            btn_RecipeFile_New.Enabled = false;
                            btn_RecipeFile_Edit.Enabled = false;
                            btn_RecipeFile_Copy.Enabled = false;
                            btn_RecipeFile_Save.Enabled = true;
                            btn_RecipeFile_Del.Enabled = false;
                            btn_RecipeFile_Cancel.Enabled = true;

                            btn_RecipeStep_Add.Enabled = true;
                            btn_RecipeStep_Insert.Enabled = true;
                            btn_RecipeStep_Del.Enabled = true;
                        }
                        break;
                }
            }
        }
    }
}
