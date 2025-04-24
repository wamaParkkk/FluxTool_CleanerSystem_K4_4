using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace FluxTool_CleanerSystem_K4_4
{
    public partial class UserRegistForm : Form
    {
        MainForm mainForm;

        string[] grp = new string[3] { "Master", "Maintnance", "User" };
        //string UserLevel;

        // 사용자 수정 시 사용 할 변수.
        string sChangeBakId = "";
        string sChangeId = "";
        string sChangeName = "";
        string sChangeLevel = "";
        string sChangePassword = "";

        public UserRegistForm()
        {            
            InitializeComponent();
        }

        private void UserRegistForm_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'userDataDataSet.UserTable' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.userTableTableAdapter.Fill(this.userDataDataSet.UserTable);

            Width = 1172;
            Height = 824;
            Top = 0;
            Left = 0;

            // Windows Forms DataGridView 컨트롤에서 행 추가 및 삭제 방지.
            MakeReadOnly();

            FormInitial();

            comboBoxLevel.Items.AddRange(grp);

            UserDataUpdate();            
        }

        private void UserRegistForm_Activated(object sender, EventArgs e)
        {
            // DataGridView 버벅임 방지.
            SetDoubleBuffered(dataGridViewUserRegist);
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

        private void UserRegistForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        private void MakeReadOnly()
        {
            dataGridViewUserRegist.AllowUserToAddRows = false;
            dataGridViewUserRegist.AllowUserToDeleteRows = false;
            dataGridViewUserRegist.ReadOnly = true;
        }

        private void FormInitial()
        {
            btnChange.Enabled = true;
            btnCancel.Enabled = false;
            btnChangeComplete.Enabled = false;

            labelPassword.Visible = false;
            textBoxChangePassword.Visible = false;

            btnDelete.Enabled = true;
        }

        private void UserDataUpdate()
        {
            try
            {
                // 데이터를 'userDataDataSet.UserTable' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거 가능.
                this.userTableTableAdapter.Fill(this.userDataDataSet.UserTable);

                // Fill 전달 전에 DataSet객체 생성
                DataSet ds = new DataSet();

                // DataAdapter는 자동으로 Connection을 핸들링함. conn.Open() 불필요.                
                string connStr = Global.userdataPath;
                OleDbConnection conn = new OleDbConnection(connStr);

                string sql = "SELECT * FROM UserTable";
                OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
                adp.Fill(ds);

                // 가져온 데이타를 DataGridView 컨트롤에 바인딩.
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    dataGridViewUserRegist.DataSource = ds.Tables[i];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sID = "";
            string sName = "";
            string sLevel = "";            
            string sPassword = "";
            
            string connStr = Global.userdataPath;
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                try
                {
                    string sql = "CREATE TABLE UserTable (ID nvarchar(20), Name_ nvarchar(20), Level nvarchar(20), Password nvarchar(20))";
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    //cmd.ExecuteNonQuery();

                    sID = textBoxId.Text;
                    sName = textBoxName.Text;
                    sLevel = comboBoxLevel.Text;
                    sPassword = textBoxPassword.Text;

                    if ((sID != "") && (sID != null))
                    {
                        if ((sName != "") && (sName != null))
                        {
                            if ((sLevel == "Master") || (sLevel == "Maintnance") || (sLevel == "User"))
                            {
                                if ((sPassword != "") && (sPassword != null))
                                {
                                    sql = "INSERT INTO UserTable VALUES('" + sID + "' , '" + sName + "' , '" + sLevel + "' , '" + sPassword + "')";
                                    cmd.CommandText = sql;
                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("User registration completed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    textBoxId.Text = "";
                                    comboBoxLevel.Text = "";
                                    textBoxPassword.Text = "";
                                }
                                else
                                {
                                    MessageBox.Show("Please enter your password", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please select user privileges", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter your username", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter your employee number", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Notification");
                    return;
                }
                finally
                {
                    conn.Close();
                }

                UserDataUpdate();
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {            
            if (textBoxChangeId.Text == "")
            {
                MessageBox.Show("Please select user to edit", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if ((Define.UserId != textBoxChangeId.Text) && (textBoxDeleteLevel.Text == "Master"))
            {
                MessageBox.Show("Cannot be modified by users with master privileges", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            sChangeBakId = textBoxChangeId.Text;

            if (dataGridViewUserRegist.Enabled)
            {
                dataGridViewUserRegist.Enabled = false;
            }

            if (boxUserRegist.Enabled)
            {
                boxUserRegist.Enabled = false;
            }            

            if (!textBoxChangeId.Enabled)
            {
                textBoxChangeId.Enabled = true;
            }

            if (!textBoxChangeName.Enabled)
            {
                textBoxChangeName.Enabled = true;
            }

            if (!comboBoxChangeLevel.Enabled)
            {
                comboBoxChangeLevel.Enabled = true;
            }

            textBoxChangePassword.Text = "";

            textBoxChangeId.BackColor = Color.White;
            textBoxChangeName.BackColor = Color.White;

            comboBoxChangeLevel.Items.Clear();
            comboBoxChangeLevel.Items.AddRange(grp);
            comboBoxChangeLevel.DropDownStyle = ComboBoxStyle.DropDown;

            if (!labelPassword.Visible)
            {
                labelPassword.Visible = true;
            }

            if (!textBoxChangePassword.Visible)
            {
                textBoxChangePassword.Visible = true;
            }

            if (btnChange.Enabled)
            {
                btnChange.Enabled = false;
            }

            if (!btnCancel.Enabled)
            {
                btnCancel.Enabled = true;
            }

            if (!btnChangeComplete.Enabled)
            {
                btnChangeComplete.Enabled = true;
            }

            if (btnDelete.Enabled)
            {
                btnDelete.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!dataGridViewUserRegist.Enabled)
            {
                dataGridViewUserRegist.Enabled = true;
            }

            if (!boxUserRegist.Enabled)
            {
                boxUserRegist.Enabled = true;
            }

            if (!boxUserDel.Enabled)
            {
                boxUserDel.Enabled = true;
            }

            if (textBoxChangeId.Enabled)
            {
                textBoxChangeId.Enabled = false;
            }

            if (textBoxChangeName.Enabled)
            {
                textBoxChangeName.Enabled = false;
            }

            textBoxChangeId.Text = "";

            if (comboBoxChangeLevel.Enabled)
            {
                comboBoxChangeLevel.Enabled = false;
            }

            textBoxChangePassword.Text = "";

            textBoxChangeId.BackColor = Color.Silver;
            textBoxChangeName.BackColor = Color.Silver;

            comboBoxChangeLevel.DropDownStyle = ComboBoxStyle.DropDownList;

            if (labelPassword.Visible)
            {
                labelPassword.Visible = false;
            }

            if (textBoxChangePassword.Visible)
            {
                textBoxChangePassword.Visible = false;
            }

            if (!btnChange.Enabled)
            {
                btnChange.Enabled = true;
            }

            if (btnCancel.Enabled)
            {
                btnCancel.Enabled = false;
            }

            if (btnChangeComplete.Enabled)
            {
                btnChangeComplete.Enabled = false;
            }

            if (!btnDelete.Enabled)
            {
                btnDelete.Enabled = true;
            }
        }

        private void btnChangeComplete_Click(object sender, EventArgs e)
        {
            sChangeId = textBoxChangeId.Text;
            sChangeName = textBoxChangeName.Text;
            sChangeLevel = comboBoxChangeLevel.Text;
            sChangePassword = textBoxChangePassword.Text;
            
            string connStr = Global.userdataPath;
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                try
                {
                    if ((sChangeId != "") && (sChangeId != null))
                    {
                        if ( (sChangeLevel != "") && (sChangeLevel != null) && ((sChangeLevel == "Master") || (sChangeLevel == "Maintnance") || (sChangeLevel == "User")) )
                        {
                            if ((sChangePassword != "") && (sChangePassword != null))
                            {                                
                                string sql = "UPDATE UserTable SET [ID] = @ID, [Name_] = @Name_, [Level] = @Level, [Password] = @Password WHERE [ID] = '" + sChangeBakId + "'";
                                OleDbCommand cmd = new OleDbCommand(sql, conn);
                                cmd.Parameters.AddWithValue("@ID", sChangeId);
                                cmd.Parameters.AddWithValue("@Name_", sChangeName);
                                cmd.Parameters.AddWithValue("@Level", sChangeLevel);
                                cmd.Parameters.AddWithValue("@Password", sChangePassword);
                                cmd.CommandText = sql;
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("User editing completed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Please enter your password", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select user privileges", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter your employee number", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Notification");
                    return;
                }
                finally
                {
                    conn.Close();
                }

                if (!dataGridViewUserRegist.Enabled)
                {
                    dataGridViewUserRegist.Enabled = true;
                }

                if (!boxUserRegist.Enabled)
                {
                    boxUserRegist.Enabled = true;
                }

                if (textBoxChangeId.Enabled)
                {
                    textBoxChangeId.Enabled = false;
                }

                if (textBoxChangeName.Enabled)
                {
                    textBoxChangeName.Enabled = false;
                }

                if (comboBoxChangeLevel.Enabled)
                {
                    comboBoxChangeLevel.Enabled = false;
                }

                textBoxChangePassword.Text = "";

                comboBoxChangeLevel.DropDownStyle = ComboBoxStyle.DropDownList;

                if (labelPassword.Visible)
                {
                    labelPassword.Visible = false;
                }

                if (textBoxChangePassword.Visible)
                {
                    textBoxChangePassword.Visible = false;
                }

                if (!btnChange.Enabled)
                {
                    btnChange.Enabled = true;
                }

                if (btnCancel.Enabled)
                {
                    btnCancel.Enabled = false;
                }

                if (btnChangeComplete.Enabled)
                {
                    btnChangeComplete.Enabled = false;
                }

                if (!btnDelete.Enabled)
                {
                    btnDelete.Enabled = true;
                }

                UserDataUpdate();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (textBoxDeleteId.Text == "")
            {
                MessageBox.Show("Please select the user to delete", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string connStr = Global.userdataPath;
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                try
                {                    
                    if (textBoxDeleteLevel.Text == "Master")
                    {
                        MessageBox.Show("Master permissions cannot be removed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        string sql = "DELETE FROM UserTable WHERE ID = '" + textBoxDeleteId.Text.ToString() + "' ";
                        OleDbCommand cmd = new OleDbCommand(sql, conn);
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("User deletion completed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Notification");
                    return;
                }
                finally
                {
                    conn.Close();
                }

                UserDataUpdate();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (e.Value != null)
                {
                    e.Value = new string('●', e.Value.ToString().Length);
                }
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewUserRegist.CurrentCell != null)
                {
                    if (dataGridViewUserRegist.CurrentCell.ColumnIndex == 1)
                    {
                        textBoxDeleteId.Text = dataGridViewUserRegist[dataGridViewUserRegist.CurrentCell.ColumnIndex - dataGridViewUserRegist.CurrentCell.ColumnIndex, dataGridViewUserRegist.CurrentRow.Index].Value.ToString();
                        textBoxDeleteLevel.Text = dataGridViewUserRegist[dataGridViewUserRegist.CurrentCell.ColumnIndex + 1, dataGridViewUserRegist.CurrentRow.Index].Value.ToString();

                        textBoxChangeId.Text = dataGridViewUserRegist[dataGridViewUserRegist.CurrentCell.ColumnIndex - dataGridViewUserRegist.CurrentCell.ColumnIndex, dataGridViewUserRegist.CurrentRow.Index].Value.ToString();
                        textBoxChangeName.Text = dataGridViewUserRegist[dataGridViewUserRegist.CurrentCell.ColumnIndex, dataGridViewUserRegist.CurrentRow.Index].Value.ToString();
                    }
                    else if (dataGridViewUserRegist.CurrentCell.ColumnIndex == 2)
                    {
                        textBoxDeleteId.Text = dataGridViewUserRegist[dataGridViewUserRegist.CurrentCell.ColumnIndex - dataGridViewUserRegist.CurrentCell.ColumnIndex, dataGridViewUserRegist.CurrentRow.Index].Value.ToString();
                        textBoxDeleteLevel.Text = dataGridViewUserRegist[dataGridViewUserRegist.CurrentCell.ColumnIndex, dataGridViewUserRegist.CurrentRow.Index].Value.ToString();

                        textBoxChangeId.Text = dataGridViewUserRegist[dataGridViewUserRegist.CurrentCell.ColumnIndex - dataGridViewUserRegist.CurrentCell.ColumnIndex, dataGridViewUserRegist.CurrentRow.Index].Value.ToString();
                        textBoxChangeName.Text = dataGridViewUserRegist[dataGridViewUserRegist.CurrentCell.ColumnIndex - 1, dataGridViewUserRegist.CurrentRow.Index].Value.ToString();
                    }
                    else if (dataGridViewUserRegist.CurrentCell.ColumnIndex == 3)
                    {
                        textBoxDeleteId.Text = dataGridViewUserRegist[dataGridViewUserRegist.CurrentCell.ColumnIndex - dataGridViewUserRegist.CurrentCell.ColumnIndex, dataGridViewUserRegist.CurrentRow.Index].Value.ToString();
                        textBoxDeleteLevel.Text = dataGridViewUserRegist[dataGridViewUserRegist.CurrentCell.ColumnIndex - 1, dataGridViewUserRegist.CurrentRow.Index].Value.ToString();

                        textBoxChangeId.Text = dataGridViewUserRegist[dataGridViewUserRegist.CurrentCell.ColumnIndex - dataGridViewUserRegist.CurrentCell.ColumnIndex, dataGridViewUserRegist.CurrentRow.Index].Value.ToString();
                        textBoxChangeName.Text = dataGridViewUserRegist[dataGridViewUserRegist.CurrentCell.ColumnIndex - 2, dataGridViewUserRegist.CurrentRow.Index].Value.ToString();
                    }
                    else
                    {
                        textBoxDeleteId.Text = dataGridViewUserRegist[dataGridViewUserRegist.CurrentCell.ColumnIndex, dataGridViewUserRegist.CurrentRow.Index].Value.ToString();
                        textBoxDeleteLevel.Text = dataGridViewUserRegist[dataGridViewUserRegist.CurrentCell.ColumnIndex + 2, dataGridViewUserRegist.CurrentRow.Index].Value.ToString();

                        textBoxChangeId.Text = dataGridViewUserRegist[dataGridViewUserRegist.CurrentCell.ColumnIndex, dataGridViewUserRegist.CurrentRow.Index].Value.ToString();
                        textBoxChangeName.Text = dataGridViewUserRegist[dataGridViewUserRegist.CurrentCell.ColumnIndex + 1, dataGridViewUserRegist.CurrentRow.Index].Value.ToString();
                    }
                }                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }    
    }
}
