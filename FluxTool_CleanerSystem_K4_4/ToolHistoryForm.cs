using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Data;
using System.Drawing;

namespace FluxTool_CleanerSystem_K4_4
{
    public partial class ToolHistoryForm : Form
    {        
        public ToolHistoryForm()
        {            
            InitializeComponent();
        }

        private void ToolHistoryForm_Load(object sender, EventArgs e)
        {
            Width = 1172;
            Height = 824;
            Top = 0;
            Left = 0;
        }

        private void ToolHistoryForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void _searchButton_Click(object sender, EventArgs e)
        {            
            DateTime selectedDate = _monthCalendar.SelectionStart;
            string formattedDate = selectedDate.ToString("yyyyMMdd");
            LoadCsvFiles(formattedDate);

            _filterTextBox.Text = string.Empty;
            _filterTextBox.Focus();
        }

        private void LoadCsvFiles(string date)
        {
            // 선택한 날짜 가져오기
            DateTime selectedDate = _monthCalendar.SelectionStart;
            // 파일 이름에 사용할 날짜 형식 지정
            string dateString = selectedDate.ToString("yyyyMMdd");
            // CSV 파일이 저장된 폴더 경로 지정
            string folderPath = Global.toolHistoryfilePath;
            if (!Directory.Exists(folderPath))
            {                
                MessageBox.Show("지정된 폴더가 존재하지 않습니다.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // 날짜를 포함한 CSV 파일 목록 가져오기
                string[] files = Directory.GetFiles(folderPath, $"*{dateString}*.csv");
                // 파일명을 시간 순으로 정렬하기 위해 파일명과 시간을 Dictionary로 저장
                var fileTimeDict = files.Select(file =>
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    // 파일명에서 시간을 추출                    
                    string timeString = fileName.Substring(fileName.Length - 6, 6); // HHmmss 추출
                    DateTime fileDateTime;
                    // 날짜와 시간을 합쳐서 DateTime 객체로 변환
                    if (DateTime.TryParseExact(dateString + "_" + timeString, "yyyyMMdd_HHmmss", null, System.Globalization.DateTimeStyles.None, out fileDateTime))
                    {
                        return new { FileName = Path.GetFileName(file), FileDateTime = fileDateTime };
                    }
                    else
                    {
                        // 파싱 실패 시 현재 시간으로 설정
                        return new { FileName = Path.GetFileName(file), FileDateTime = DateTime.MinValue };
                    }
                })
                .OrderBy(x => x.FileDateTime)   // 시간 순으로 정렬
                .ToList();

                // ListBox 초기화
                _listBox.Items.Clear();

                // 정렬된 파일명을 ListBox에 추가
                foreach (var item in fileTimeDict)
                {
                    _listBox.Items.Add(item.FileName);
                }

                labelToolCount.Text = $"Cleaned tools : {_listBox.Items.Count.ToString()}개";

                // 파일이 없는 경우 메시지 표시
                if (fileTimeDict.Count == 0)
                {
                    labelToolCount.Text = "Cleaned tools : 0개";

                    MessageBox.Show("선택한 날짜의 파일이 없습니다.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {                                
                MessageBox.Show($"CSV 파일 로드 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _clearButton_Click(object sender, EventArgs e)
        {
            if (_listBox.Items == null)
                return;

            _listBox.Items.Clear();
            labelToolCount.Text = "Cleaned tools : 0개";
        }

        private void _filterTextBox_TextChanged(object sender, EventArgs e)
        {
            string filterText = _filterTextBox.Text.ToUpper();
            for (int i = 0; i < _listBox.Items.Count; i++)
            {
                string itemText = _listBox.Items[i].ToString().ToUpper();
                if (!itemText.Contains(filterText))
                {
                    _listBox.Items.RemoveAt(i);
                    i--; // RemoveAt으로 아이템이 제거되면 인덱스 조정 필요
                }
            }
        }

        private void _listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_listBox.SelectedItem == null)
                return;

            string selectedFile = _listBox.SelectedItem.ToString();
            string localFilePath = Path.Combine(Global.toolHistoryfilePath, selectedFile);            
            // CSV 파일 내용을 DataGridView에 로드
            LoadCsvDataToGrid(localFilePath);            
        }

        private void LoadCsvDataToGrid(string filePath)
        {
            try
            {
                var dataTable = new DataTable();
                // 열 제목 추가
                dataTable.Columns.Add("Column1", typeof(string));
                for (int i = 2; i <= 8; i++)
                {
                    dataTable.Columns.Add($"Column{i}", typeof(string));
                }

                // 첫 번째 행 : 제목
                var row1 = dataTable.NewRow();
                row1["Column1"] = "Date";
                row1["Column2"] = "User";
                row1["Column3"] = "Lot#";
                row1["Column4"] = "M/C#";
                row1["Column5"] = "Tool ID";
                row1["Column6"] = "CH#";
                row1["Column7"] = "Cleaning start time";
                row1["Column8"] = "Cleaning end time";
                dataTable.Rows.Add(row1);

                // CSV 파일 내용 읽기
                string[] lines = File.ReadAllLines(filePath);
                // 두 번째 행 : CSV 파일에서 해당 값 가져오기
                var row2 = dataTable.NewRow();
                row2["Column1"] = lines[1].Split(',')[0];
                row2["Column2"] = lines[1].Split(',')[1];
                row2["Column3"] = lines[1].Split(',')[2];
                row2["Column4"] = lines[1].Split(',')[3];
                row2["Column5"] = lines[1].Split(',')[4];
                row2["Column6"] = lines[1].Split(',')[5];
                row2["Column7"] = lines[1].Split(',')[6];
                row2["Column8"] = lines[1].Split(',')[7];
                dataTable.Rows.Add(row2);

                // DataGridView에 데이터 바인딩
                _dataGridView.DataSource = dataTable;

                // DataGridView 설정
                _dataGridView.AllowUserToAddRows = false;
                _dataGridView.AllowUserToDeleteRows = false;                

                _dataGridView.Columns[0].Width = 95;    // Date
                _dataGridView.Columns[1].Width = 100;   // User
                _dataGridView.Columns[2].Width = 180;   // Lot#
                _dataGridView.Columns[3].Width = 180;   // M/C#
                _dataGridView.Columns[4].Width = 200;   // Tool ID
                _dataGridView.Columns[5].Width = 60;    // Chamber
                _dataGridView.Columns[6].Width = 150;   // Cleaning start time
                _dataGridView.Columns[7].Width = 150;   // Cleaning end time

                // DataGridView 열 정렬 비활성화
                foreach (DataGridViewColumn column in _dataGridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;                                       
                }

                // 제목 행의 배경색
                _dataGridView.Rows[0].DefaultCellStyle.BackColor = Color.PaleTurquoise;                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CSV 파일 읽기 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
