namespace ExamCheck
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btCheckAll = new System.Windows.Forms.Button();
            this.tbRootPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTime = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbRoom = new System.Windows.Forms.ComboBox();
            this.btGetStudent = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbExamnNo = new System.Windows.Forms.TextBox();
            this.btStudentQuery = new System.Windows.Forms.Button();
            this.btAbsent = new System.Windows.Forms.Button();
            this.btGetTimeStudent = new System.Windows.Forms.Button();
            this.btTimeCheck = new System.Windows.Forms.Button();
            this.btSubmitQuery = new System.Windows.Forms.Button();
            this.btExport = new System.Windows.Forms.Button();
            this.cbAbsent = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbStudentNo = new System.Windows.Forms.TextBox();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAbsent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAbsent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cheat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 517);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1060, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(68, 17);
            this.statusLabel.Text = "状态：正常";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.StudentNo,
            this.Room,
            this.ExamNo,
            this.Time,
            this.RealName,
            this.Seat,
            this.CAbsent,
            this.PAbsent,
            this.Cheat,
            this.Status});
            this.dataGridView.Location = new System.Drawing.Point(12, 97);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(1036, 402);
            this.dataGridView.TabIndex = 1;
            // 
            // btCheckAll
            // 
            this.btCheckAll.Location = new System.Drawing.Point(262, 14);
            this.btCheckAll.Name = "btCheckAll";
            this.btCheckAll.Size = new System.Drawing.Size(126, 23);
            this.btCheckAll.TabIndex = 2;
            this.btCheckAll.Text = "检查全部文件";
            this.btCheckAll.UseVisualStyleBackColor = true;
            this.btCheckAll.Click += new System.EventHandler(this.btCheckAll_Click);
            // 
            // tbRootPath
            // 
            this.tbRootPath.Location = new System.Drawing.Point(117, 15);
            this.tbRootPath.Name = "tbRootPath";
            this.tbRootPath.Size = new System.Drawing.Size(130, 21);
            this.tbRootPath.TabIndex = 3;
            this.tbRootPath.Text = "c:\\ftp\\";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "考试文件目录：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "考试时间：";
            // 
            // cbTime
            // 
            this.cbTime.FormattingEnabled = true;
            this.cbTime.Location = new System.Drawing.Point(97, 60);
            this.cbTime.Name = "cbTime";
            this.cbTime.Size = new System.Drawing.Size(151, 20);
            this.cbTime.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(554, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "考试地点：";
            // 
            // cbRoom
            // 
            this.cbRoom.FormattingEnabled = true;
            this.cbRoom.Location = new System.Drawing.Point(625, 60);
            this.cbRoom.Name = "cbRoom";
            this.cbRoom.Size = new System.Drawing.Size(105, 20);
            this.cbRoom.TabIndex = 9;
            // 
            // btGetStudent
            // 
            this.btGetStudent.Location = new System.Drawing.Point(761, 59);
            this.btGetStudent.Name = "btGetStudent";
            this.btGetStudent.Size = new System.Drawing.Size(75, 23);
            this.btGetStudent.TabIndex = 10;
            this.btGetStudent.Text = "查看本场";
            this.btGetStudent.UseVisualStyleBackColor = true;
            this.btGetStudent.Click += new System.EventHandler(this.btGetStudent_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(860, 59);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 11;
            this.btSave.Text = "保存数据";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(410, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "准考证号：";
            // 
            // tbExamnNo
            // 
            this.tbExamnNo.Location = new System.Drawing.Point(481, 15);
            this.tbExamnNo.Name = "tbExamnNo";
            this.tbExamnNo.Size = new System.Drawing.Size(105, 21);
            this.tbExamnNo.TabIndex = 13;
            // 
            // btStudentQuery
            // 
            this.btStudentQuery.Location = new System.Drawing.Point(733, 14);
            this.btStudentQuery.Name = "btStudentQuery";
            this.btStudentQuery.Size = new System.Drawing.Size(75, 23);
            this.btStudentQuery.TabIndex = 14;
            this.btStudentQuery.Text = "检索考生";
            this.btStudentQuery.UseVisualStyleBackColor = true;
            this.btStudentQuery.Click += new System.EventHandler(this.btStudentQuery_Click);
            // 
            // btAbsent
            // 
            this.btAbsent.Location = new System.Drawing.Point(965, 14);
            this.btAbsent.Name = "btAbsent";
            this.btAbsent.Size = new System.Drawing.Size(75, 23);
            this.btAbsent.TabIndex = 20;
            this.btAbsent.Text = "查看名单";
            this.btAbsent.UseVisualStyleBackColor = true;
            this.btAbsent.Click += new System.EventHandler(this.btAbsent_Click);
            // 
            // btGetTimeStudent
            // 
            this.btGetTimeStudent.Location = new System.Drawing.Point(276, 59);
            this.btGetTimeStudent.Name = "btGetTimeStudent";
            this.btGetTimeStudent.Size = new System.Drawing.Size(52, 23);
            this.btGetTimeStudent.TabIndex = 21;
            this.btGetTimeStudent.Text = "查看";
            this.btGetTimeStudent.UseVisualStyleBackColor = true;
            this.btGetTimeStudent.Click += new System.EventHandler(this.btGetTimeStudent_Click);
            // 
            // btTimeCheck
            // 
            this.btTimeCheck.Location = new System.Drawing.Point(360, 59);
            this.btTimeCheck.Name = "btTimeCheck";
            this.btTimeCheck.Size = new System.Drawing.Size(56, 23);
            this.btTimeCheck.TabIndex = 22;
            this.btTimeCheck.Text = "检查";
            this.btTimeCheck.UseVisualStyleBackColor = true;
            this.btTimeCheck.Click += new System.EventHandler(this.btTimeCheck_Click);
            // 
            // btSubmitQuery
            // 
            this.btSubmitQuery.Location = new System.Drawing.Point(446, 59);
            this.btSubmitQuery.Name = "btSubmitQuery";
            this.btSubmitQuery.Size = new System.Drawing.Size(59, 23);
            this.btSubmitQuery.TabIndex = 23;
            this.btSubmitQuery.Text = "已交卷";
            this.btSubmitQuery.UseVisualStyleBackColor = true;
            this.btSubmitQuery.Click += new System.EventHandler(this.btSubmitQuery_Click);
            // 
            // btExport
            // 
            this.btExport.Location = new System.Drawing.Point(963, 59);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(75, 23);
            this.btExport.TabIndex = 24;
            this.btExport.Text = "导出缺考";
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // cbAbsent
            // 
            this.cbAbsent.FormattingEnabled = true;
            this.cbAbsent.Items.AddRange(new object[] {
            "上机缺考",
            "全部缺考",
            "一种缺考",
            "理论缺考",
            "作弊"});
            this.cbAbsent.Location = new System.Drawing.Point(886, 15);
            this.cbAbsent.Name = "cbAbsent";
            this.cbAbsent.Size = new System.Drawing.Size(70, 20);
            this.cbAbsent.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(839, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "异常：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(595, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "学号：";
            // 
            // tbStudentNo
            // 
            this.tbStudentNo.Location = new System.Drawing.Point(640, 15);
            this.tbStudentNo.Name = "tbStudentNo";
            this.tbStudentNo.Size = new System.Drawing.Size(75, 21);
            this.tbStudentNo.TabIndex = 28;
            // 
            // Type
            // 
            this.Type.HeaderText = "语种";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // StudentNo
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.StudentNo.DefaultCellStyle = dataGridViewCellStyle1;
            this.StudentNo.HeaderText = "学号";
            this.StudentNo.Name = "StudentNo";
            this.StudentNo.ReadOnly = true;
            this.StudentNo.Width = 75;
            // 
            // Room
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Room.DefaultCellStyle = dataGridViewCellStyle2;
            this.Room.HeaderText = "考试地点";
            this.Room.Name = "Room";
            this.Room.Width = 80;
            // 
            // ExamNo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ExamNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.ExamNo.HeaderText = "准考证号";
            this.ExamNo.Name = "ExamNo";
            this.ExamNo.ReadOnly = true;
            // 
            // Time
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Time.DefaultCellStyle = dataGridViewCellStyle4;
            this.Time.HeaderText = "考试时间";
            this.Time.Name = "Time";
            this.Time.Width = 130;
            // 
            // RealName
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.RealName.DefaultCellStyle = dataGridViewCellStyle5;
            this.RealName.HeaderText = "姓名";
            this.RealName.Name = "RealName";
            this.RealName.ReadOnly = true;
            this.RealName.Width = 70;
            // 
            // Seat
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.Seat.DefaultCellStyle = dataGridViewCellStyle6;
            this.Seat.HeaderText = "座位号";
            this.Seat.Name = "Seat";
            this.Seat.ReadOnly = true;
            this.Seat.Width = 70;
            // 
            // CAbsent
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CAbsent.DefaultCellStyle = dataGridViewCellStyle7;
            this.CAbsent.HeaderText = "上机缺考";
            this.CAbsent.Name = "CAbsent";
            this.CAbsent.Width = 80;
            // 
            // PAbsent
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PAbsent.DefaultCellStyle = dataGridViewCellStyle8;
            this.PAbsent.HeaderText = "理论缺考";
            this.PAbsent.Name = "PAbsent";
            this.PAbsent.Width = 80;
            // 
            // Cheat
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Cheat.DefaultCellStyle = dataGridViewCellStyle9;
            this.Cheat.HeaderText = "作弊";
            this.Cheat.Name = "Cheat";
            // 
            // Status
            // 
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 539);
            this.Controls.Add(this.tbStudentNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbAbsent);
            this.Controls.Add(this.btExport);
            this.Controls.Add(this.btSubmitQuery);
            this.Controls.Add(this.btTimeCheck);
            this.Controls.Add(this.btGetTimeStudent);
            this.Controls.Add(this.btAbsent);
            this.Controls.Add(this.btStudentQuery);
            this.Controls.Add(this.tbExamnNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btGetStudent);
            this.Controls.Add(this.cbRoom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbRootPath);
            this.Controls.Add(this.btCheckAll);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Text = "计算机统考文件核查器";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btCheckAll;
        private System.Windows.Forms.TextBox tbRootPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbRoom;
        private System.Windows.Forms.Button btGetStudent;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbExamnNo;
        private System.Windows.Forms.Button btStudentQuery;
        private System.Windows.Forms.Button btAbsent;
        private System.Windows.Forms.Button btGetTimeStudent;
        private System.Windows.Forms.Button btTimeCheck;
        private System.Windows.Forms.Button btSubmitQuery;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.ComboBox cbAbsent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbStudentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Room;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seat;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAbsent;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAbsent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cheat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}

