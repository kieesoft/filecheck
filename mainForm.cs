using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace ExamCheck
{
    public partial class mainForm : Form
    {
        private string connStr;
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        public mainForm()
        {
            InitializeComponent();
            //载入下拉菜单
            //从数据库读取
            connStr = ConfigurationManager.ConnectionStrings["SQLServerconnStr"].ConnectionString;
            sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select distinct [上机考试开始时间] as time from student order by [上机考试开始时间]";
            sqlDataReader = sqlCommand.ExecuteReader();
            cbTime.Items.Clear();
            while (sqlDataReader.Read())
            {
                cbTime.Items.Add(sqlDataReader["time"].ToString());
            }
            cbTime.SelectedIndex = 0;
            sqlDataReader.Close();
            sqlCommand.CommandText = "select distinct [上机考试地址] as room from student order by [上机考试地址]";
            sqlDataReader = sqlCommand.ExecuteReader();
            cbRoom.Items.Clear();
            while (sqlDataReader.Read())
            {
                cbRoom.Items.Add(sqlDataReader["room"].ToString());
            }
            cbRoom.SelectedIndex = 0;
            cbAbsent.SelectedIndex = 0;
            sqlDataReader.Close();
        }

        private void btCheckThis_Click(object sender, EventArgs e)
        {
            string rootPath = tbRootPath.Text;
            if (!Directory.Exists(rootPath))
            {
                MessageBox.Show(rootPath + "目录不存在!");
            }
            else
            {
                string searchTime = cbTime.SelectedItem.ToString();
                string searchRoom = cbRoom.SelectedItem.ToString();
                int count = 0;
                int fileCount = 0;
                int fileZero = 0;
                int fileAbsent = 0;
                int fileMiss = 0;
                int absentCount = 0;
                sqlCommand.CommandText = "select *  from student where [上机考试开始时间]='" + searchTime + "' and [上机考试地址]='" + searchRoom + "' order by [准考证号]";
                sqlDataReader = sqlCommand.ExecuteReader();
                dataGridView.Rows.Clear();
                while (sqlDataReader.Read())
                {

                    string type = sqlDataReader["语种"].ToString();
                    string studentno = sqlDataReader["学号"].ToString();
                    string name = sqlDataReader["姓名"].ToString();
                    string examno = sqlDataReader["准考证号"].ToString();
                    string time = sqlDataReader["上机考试开始时间"].ToString();
                    string room = sqlDataReader["上机考试地址"].ToString();
                    int seat = int.Parse(sqlDataReader["上机座位号"].ToString());
                    string absent = sqlDataReader["上机缺考"].ToString();
                    string pAbsent = sqlDataReader["理论缺考"].ToString();
                    string cheat = sqlDataReader["作弊"].ToString();
                    if (absent == "1")
                    {
                        absentCount++;
                    }
                    string fileName = rootPath + examno + ".rar";
                    if (File.Exists(fileName))
                    {
                        fileCount++;
                        FileInfo info = new FileInfo(fileName);
                        if (info.Length <= 10000)
                        {
                            dataGridView.Rows.Add(type, studentno, room, examno, time, name, seat, absent, pAbsent, cheat, "RAR文件小于10K");
                            fileZero++;
                        }
                        if (absent == "1" || cheat == "1" || pAbsent == "1")
                        {
                            dataGridView.Rows.Add(type, studentno, room, examno, time, name, seat, absent, pAbsent, cheat, "作弊或缺考但是有文件");
                            fileAbsent++;
                        }
                    }
                    else
                    {
                        if (absent == "0")
                        {
                            dataGridView.Rows.Add(type, studentno, room, examno, time, name, seat, absent, pAbsent, cheat, "缺少文件");
                            fileMiss++;
                        }
                    }

                    count++;
                }
                sqlDataReader.Close();
                statusLabel.Text = "本考场应有" + count + "人，缺考" + absentCount + "人,收到文件" + fileCount + "个";
            }

        }
        /// <summary>
        /// 查看本考场本场次学生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btGetStudent_Click(object sender, EventArgs e)
        {
            string searchTime = cbTime.SelectedItem.ToString();
            string searchRoom = cbRoom.SelectedItem.ToString();
            int count = 0;
            sqlCommand.CommandText = "select *  from student where [上机考试开始时间]='" + searchTime + "' and [上机考试地址]='" + searchRoom + "' order by [准考证号]";
            sqlDataReader = sqlCommand.ExecuteReader();
            dataGridView.Rows.Clear();
            while (sqlDataReader.Read())
            {
                string type = sqlDataReader["语种"].ToString();
                string studentno = sqlDataReader["学号"].ToString();
                string name = sqlDataReader["姓名"].ToString();
                string examno = sqlDataReader["准考证号"].ToString();
                string time = sqlDataReader["上机考试开始时间"].ToString();
                string room = sqlDataReader["上机考试地址"].ToString();
                int seat = int.Parse(sqlDataReader["上机座位号"].ToString());
                string absent = sqlDataReader["上机缺考"].ToString();
                string pAbsent = sqlDataReader["理论缺考"].ToString();
                string cheat = sqlDataReader["作弊"].ToString();
                dataGridView.Rows.Add(type, studentno, room, examno, time, name, seat, absent, pAbsent, cheat);
                count++;
            }
            sqlDataReader.Close();
            statusLabel.Text = "本考场共有" + count + "人";

        }
        /// <summary>
        /// 保存数据结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSave_Click(object sender, EventArgs e)
        {
            int rowCount = dataGridView.Rows.Count;
            int effectRow = 0;
            for (int i = 0; i < rowCount - 1; i++)
            {
                string cAbsent = dataGridView.Rows[i].Cells[7].Value.ToString();
                string pAbsent = dataGridView.Rows[i].Cells[8].Value.ToString();
                string cheat = dataGridView.Rows[i].Cells[9].Value.ToString();
                string examno = dataGridView.Rows[i].Cells[3].Value.ToString();
                string time = dataGridView.Rows[i].Cells[4].Value.ToString();
                string room = dataGridView.Rows[i].Cells[2].Value.ToString();
                sqlCommand.CommandText = "update student set [上机缺考]=" + cAbsent + ",[理论缺考]=" + pAbsent + ",[作弊]=" + cheat + ",[上机考试开始时间]='" + time + "',[上机考试地址]='" + room + "' where [准考证号]='" + examno + "'";
                effectRow += sqlCommand.ExecuteNonQuery();
            }
            MessageBox.Show(effectRow + "行数据已保存。");
        }
        /// <summary>
        /// 核查本次考试收卷情况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCheckAll_Click(object sender, EventArgs e)
        {
            string rootPath = tbRootPath.Text;
            if (!Directory.Exists(rootPath))
            {
                MessageBox.Show(rootPath + "目录不存在!");
            }
            else
            {
                int count = 0;
                int fileCount = 0;
                int fileZero = 0;
                int fileAbsent = 0;
                int fileMiss = 0;
                int absentCount = 0;
                sqlCommand.CommandText = "select *  from student  order by [准考证号]";
                sqlDataReader = sqlCommand.ExecuteReader();
                dataGridView.Rows.Clear();
                while (sqlDataReader.Read())
                {

                    string type = sqlDataReader["语种"].ToString();
                    string studentno = sqlDataReader["学号"].ToString();
                    string name = sqlDataReader["姓名"].ToString();
                    string examno = sqlDataReader["准考证号"].ToString();
                    string time = sqlDataReader["上机考试开始时间"].ToString();
                    string room = sqlDataReader["上机考试地址"].ToString();
                    int seat = int.Parse(sqlDataReader["上机座位号"].ToString());
                    string absent = sqlDataReader["上机缺考"].ToString();
                    string pAbsent = sqlDataReader["理论缺考"].ToString();
                    string cheat = sqlDataReader["作弊"].ToString();
                    if (absent == "1")
                    {
                        absentCount++;
                    }
                    string fileName = rootPath + examno + ".rar";
                    if (File.Exists(fileName))
                    {
                        fileCount++;
                        FileInfo info = new FileInfo(fileName);
                        if (info.Length <= 10000)
                        {
                            dataGridView.Rows.Add(type, studentno, room, examno, time, name, seat, absent, pAbsent, cheat, "RAR文件小于10K");
                            fileZero++;
                        }
                        if (absent == "1" || cheat == "1" || pAbsent == "1")
                        {
                            dataGridView.Rows.Add(type, studentno, room, examno, time, name, seat, absent, pAbsent, cheat, "作弊或缺考但是有文件");
                            fileAbsent++;
                        }
                    }
                    else
                    {
                        if (absent == "0")
                        {
                            dataGridView.Rows.Add(type, studentno, room, examno, time, name, seat, absent, pAbsent, cheat, "缺少文件");
                            fileMiss++;
                        }
                    }

                    count++;
                }
                sqlDataReader.Close();
                statusLabel.Text = "本次考试应有" + count + "人，缺考" + absentCount + "人,收到文件" + fileCount + "个";
            }
        }
        /// <summary>
        /// 根据准考证号和学号检索考生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btStudentQuery_Click(object sender, EventArgs e)
        {
            string searchExamNo = tbExamnNo.Text;
            string searchStudentNo= tbStudentNo.Text;
            int count = 0;
            sqlCommand.CommandText = "select *  from student where [准考证号] like '%" + searchExamNo + "%' and [学号] like  '%"+searchStudentNo+"%' order by [准考证号]";
            sqlDataReader = sqlCommand.ExecuteReader();
            dataGridView.Rows.Clear();
            while (sqlDataReader.Read())
            {
                string type = sqlDataReader["语种"].ToString();
                string studentno = sqlDataReader["学号"].ToString();
                string name = sqlDataReader["姓名"].ToString();
                string examno = sqlDataReader["准考证号"].ToString();
                string time = sqlDataReader["上机考试开始时间"].ToString();
                string room = sqlDataReader["上机考试地址"].ToString();
                int seat = int.Parse(sqlDataReader["上机座位号"].ToString());
                string absent = sqlDataReader["上机缺考"].ToString();
                string pAbsent = sqlDataReader["理论缺考"].ToString();
                string cheat = sqlDataReader["作弊"].ToString();
                dataGridView.Rows.Add(type, studentno, room, examno, time, name, seat, absent, pAbsent, cheat);
                count++;
            }
            sqlDataReader.Close();
            statusLabel.Text = "检索到符合条件的有" + count + "人";
        }

        /// <summary>
        /// 检索异常情况名单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAbsent_Click(object sender, EventArgs e)
        {

            int count = 0;
            string condition = "";
            string exception = cbAbsent.SelectedItem.ToString();
            switch (cbAbsent.SelectedIndex)
            {
                case 0:
                    condition = "[上机缺考]=1";
                    break;
                case 1:
                    condition = "[上机缺考]=1 and [理论缺考]=1 ";
                    break;
                case 2:
                    condition = "[上机缺考]=1 or [理论缺考]=1 ";
                    break;
                case 3:
                    condition = "[理论缺考]=1";
                    break;
                case 4:
                    condition = "[作弊]=1";
                    break;
                default:
                    condition = "[上机缺考]=1 or [理论缺考]=1";
                    break;
            }
            sqlCommand.CommandText = "select *  from student where " + condition + "  order by [准考证号]";
            sqlDataReader = sqlCommand.ExecuteReader();
            dataGridView.Rows.Clear();
            while (sqlDataReader.Read())
            {
                string type = sqlDataReader["语种"].ToString();
                string studentno = sqlDataReader["学号"].ToString();
                string name = sqlDataReader["姓名"].ToString();
                string examno = sqlDataReader["准考证号"].ToString();
                string time = sqlDataReader["上机考试开始时间"].ToString();
                string room = sqlDataReader["上机考试地址"].ToString();
                int seat = int.Parse(sqlDataReader["上机座位号"].ToString());
                string absent = sqlDataReader["上机缺考"].ToString();
                string pAbsent = sqlDataReader["理论缺考"].ToString();
                string cheat = sqlDataReader["作弊"].ToString();
                dataGridView.Rows.Add(type, studentno, room, examno, time, name, seat, absent, pAbsent, cheat);
                count++;
            }
            sqlDataReader.Close();

            sqlCommand.CommandText = "SELECT 语种,count(*) 人数 FROM [student] where "+condition+" group by 语种";
            sqlDataReader = sqlCommand.ExecuteReader();
            string message = "";
            while (sqlDataReader.Read())
            {
                string type = sqlDataReader["语种"].ToString();
                string amount = sqlDataReader["人数"].ToString();
                message += type+"有"+amount+"人。";
            }
            message = message == "" ? "" : "其中" + message;
            sqlDataReader.Close();
            statusLabel.Text = exception+"的共有" + count + "人。"+message;
        }
        /// <summary>
        /// 查看本场次考生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btGetTimeStudent_Click(object sender, EventArgs e)
        {
            string searchTime = cbTime.SelectedItem.ToString();
            int count = 0;
            sqlCommand.CommandText = "select *  from student where [上机考试开始时间]='" + searchTime + "' order by [准考证号]";
            sqlDataReader = sqlCommand.ExecuteReader();
            dataGridView.Rows.Clear();
            while (sqlDataReader.Read())
            {
                string type = sqlDataReader["语种"].ToString();
                string studentno = sqlDataReader["学号"].ToString();
                string name = sqlDataReader["姓名"].ToString();
                string examno = sqlDataReader["准考证号"].ToString();
                string time = sqlDataReader["上机考试开始时间"].ToString();
                string room = sqlDataReader["上机考试地址"].ToString();
                int seat = int.Parse(sqlDataReader["上机座位号"].ToString());
                string absent = sqlDataReader["上机缺考"].ToString();
                string pAbsent = sqlDataReader["理论缺考"].ToString();
                string cheat = sqlDataReader["作弊"].ToString();
                dataGridView.Rows.Add(type, studentno, room, examno, time, name, seat, absent, pAbsent, cheat);
                count++;
            }
            sqlDataReader.Close();
            statusLabel.Text = "本场次共有" + count + "人";
        }
        /// <summary>
        /// 检查本场次试卷包情况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btTimeCheck_Click(object sender, EventArgs e)
        {
            string rootPath = tbRootPath.Text;
            if (!Directory.Exists(rootPath))
            {
                MessageBox.Show(rootPath + "目录不存在!");
            }
            else
            {
                string searchTime = cbTime.SelectedItem.ToString();
                int count = 0;
                int fileCount = 0;
                int fileZero = 0;
                int fileAbsent = 0;
                int fileMiss = 0;
                int absentCount = 0;
                sqlCommand.CommandText = "select *  from student where [上机考试开始时间]='" + searchTime + "' order by [准考证号]";
                sqlDataReader = sqlCommand.ExecuteReader();
                dataGridView.Rows.Clear();
                while (sqlDataReader.Read())
                {

                    string type = sqlDataReader["语种"].ToString();
                    string studentno = sqlDataReader["学号"].ToString();
                    string name = sqlDataReader["姓名"].ToString();
                    string examno = sqlDataReader["准考证号"].ToString();
                    string time = sqlDataReader["上机考试开始时间"].ToString();
                    string room = sqlDataReader["上机考试地址"].ToString();
                    int seat = int.Parse(sqlDataReader["上机座位号"].ToString());
                    string absent = sqlDataReader["上机缺考"].ToString();
                    string pAbsent = sqlDataReader["理论缺考"].ToString();
                    string cheat = sqlDataReader["作弊"].ToString();
                    if (absent == "1")
                    {
                        absentCount++;
                    }
                    string fileName = rootPath + examno + ".rar";
                    if (File.Exists(fileName))
                    {
                        fileCount++;
                        FileInfo info = new FileInfo(fileName);
                        if (info.Length <= 10000)
                        {
                            dataGridView.Rows.Add(type, studentno, room, examno, time, name, seat, absent, pAbsent, cheat, "RAR文件小于10K");
                            fileZero++;
                        }
                        if (absent == "1" || cheat == "1" || pAbsent == "1")
                        {
                            dataGridView.Rows.Add(type, studentno, room, examno, time, name, seat, absent, pAbsent, cheat, "作弊或缺考但是有文件");
                            fileAbsent++;
                        }
                    }
                    else
                    {
                        if (absent == "0")
                        {
                            dataGridView.Rows.Add(type, studentno, room, examno, time, name, seat, absent, pAbsent, cheat, "缺少文件");
                            fileMiss++;
                        }
                    }

                    count++;
                }
                sqlDataReader.Close();
                statusLabel.Text = "本场次应有" + count + "人，缺考" + absentCount + "人,收到文件" + fileCount + "个";
            }
        }
      
        /// <summary>
        /// 查看已交卷情况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSubmitQuery_Click(object sender, EventArgs e)
        {
            string rootPath = tbRootPath.Text;
            if (!Directory.Exists(rootPath))
            {
                MessageBox.Show(rootPath + "目录不存在!");
            }
            else
            {
                string searchTime = cbTime.SelectedItem.ToString();
                int count = 0;
                int fileCount = 0;
                int fileZero = 0;
                int absentCount = 0;
                sqlCommand.CommandText = "select *  from student where [上机考试开始时间]='" + searchTime + "' order by [准考证号]";
                sqlDataReader = sqlCommand.ExecuteReader();
                dataGridView.Rows.Clear();
                while (sqlDataReader.Read())
                {

                    string type = sqlDataReader["语种"].ToString();
                    string studentno = sqlDataReader["学号"].ToString();
                    string name = sqlDataReader["姓名"].ToString();
                    string examno = sqlDataReader["准考证号"].ToString();
                    string time = sqlDataReader["上机考试开始时间"].ToString();
                    string room = sqlDataReader["上机考试地址"].ToString();
                    int seat = int.Parse(sqlDataReader["上机座位号"].ToString());
                    string absent = sqlDataReader["上机缺考"].ToString();
                    string pAbsent = sqlDataReader["理论缺考"].ToString();
                    string cheat = sqlDataReader["作弊"].ToString();
                    if (absent == "1")
                    {
                        absentCount++;
                    }
                    string fileName = rootPath + examno + ".rar";
                    if (File.Exists(fileName))
                    {
                        fileCount++;
                        FileInfo info = new FileInfo(fileName);
                        double fileSize = Math.Ceiling(info.Length*0.1 / 1024);
                        if (fileSize <= 10)
                        {
                            dataGridView.Rows.Add(type, studentno, room, examno, time, name, seat, absent, pAbsent, cheat, fileSize.ToString() + "K,文件小于10K");
                            fileZero++;
                        }
                        else
                        {

                            dataGridView.Rows.Add(type, studentno, room, examno, time, name, seat, absent, pAbsent, cheat, fileSize.ToString() + "K");
                        }
                    }

                    count++;
                }
                sqlDataReader.Close();
                statusLabel.Text = "本场次应有" + count + "人，缺考" + absentCount + "人,收到文件" + fileCount + "个," + fileZero + "个大小不正常";
            }
        }

        /// <summary>
        /// 导出缺考名单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btExport_Click(object sender, EventArgs e)
        {
            string title = "缺考名单";
            string fileName = "";//保存的excel文件名
            bool isShowExcel = false;//是否显示Excel
            if (dataGridView.Rows.Count == 0)
                return;
            /*保存对话框*/
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "导出Excel(*.xls)|*.xls";
            sfd.FileName = title + DateTime.Now.ToString("yyyyMMddhhmmss");

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fileName = sfd.FileName;
                /*建立Excel对象*/
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                if (excel == null)
                {
                    MessageBox.Show("无法创建Excel对象,可能您的计算机未安装Excel!");
                    return;
                }
                try
                {
                    excel.Application.Workbooks.Add(true);
                    excel.Visible = isShowExcel;
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
                    worksheet.Cells[1, 1] = "ZKZH";
                    worksheet.Cells[1, 2] = "XM";
                    worksheet.Cells[1, 3] = "XB";
                    worksheet.Cells[1, 4] = "LLQK";
                    worksheet.Cells[1, 5] = "SJQK";

                    sqlCommand.CommandText = "select *  from student where [上机缺考]=1 or [理论缺考]=1 order by [准考证号]";
                    sqlDataReader = sqlCommand.ExecuteReader();
                    dataGridView.Rows.Clear();
                    int rowIndex = 2;
                    while (sqlDataReader.Read())
                    {
                        string type = sqlDataReader["语种"].ToString();
                        string name = sqlDataReader["姓名"].ToString();
                        string examno = sqlDataReader["准考证号"].ToString();
                        string absent = sqlDataReader["上机缺考"].ToString();
                        string pAbsent = sqlDataReader["理论缺考"].ToString();
                        string cheat = sqlDataReader["作弊"].ToString();
                        string sex = sqlDataReader["性别"].ToString();
                        string llqk="" ;
                            if(pAbsent=="0"){
                                if (type.IndexOf("一级") >= 0)
                                    llqk = "";
                                else
                                    llqk = "F";
                            }
                            else
                            {
                                llqk = "T";
                            }
                        string sjqk = absent == "1" ? "T" : "F";
                        string xb = sex == "F" ? "女" : "男";
                        worksheet.Cells[rowIndex, 1] ="'"+examno;
                        worksheet.Cells[rowIndex, 2] = name;
                        worksheet.Cells[rowIndex, 3] = xb;
                        worksheet.Cells[rowIndex, 4] = llqk;
                        worksheet.Cells[rowIndex, 5] = sjqk;
                        rowIndex++;
                    }
                    sqlDataReader.Close();
                    worksheet.SaveAs(fileName,56);//56为兼容模式，不加参数默认为当前xlsx格式。
                    MessageBox.Show("成功导出Excel");
                }
                catch { }
                finally
                {
                    excel.Quit();
                    excel = null;
                    GC.Collect();
                }
            }
            //KillProcess("Excel");
            return;
        }
    }
}
