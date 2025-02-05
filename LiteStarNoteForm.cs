using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
//using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using LiteStarNote.bean;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LiteStarNote
{
    public partial class LiteStarNoteForm : Form
    {
        DataBaseManager dataBaseManager = new DataBaseManager();
        // 0��ʾ����,��ֵ��ʾ�༭
        int editId = 0;
        // ״̬����,��Ҫע��˳��,��1��ʹ����ɫ��ʾ,��2��ʹ�ú�ɫ,��3��ʹ����ɫ
        string[] stateArr = new string[] { "�����", "δ���", "�ƻ���" };
        string[] stateArrEn = new string[] { "done", "doing", "todo" };

        public LiteStarNoteForm()
        {
            InitializeComponent();
            // ��ʼ�����ݿ�
            dataBaseManager.initTable();
        }

        private void liteStarNoteForm_load(object sender, EventArgs e)
        {
            langugeChange.Text = "����";
            DateTime currentDate = DateTime.Now;
            DateTime previousDate = currentDate.AddDays(-1);
            query_date_start.Value = previousDate;
            query_date_start.Refresh();

            openMenuItem.Click += OpenMenuItem_Click;
            exitMenuItem.Click += ExitMenuItem_Click;
            // ���ط���
            loadType();
            addFun();
            this.notifyIcon1.Visible = true;
        }

        // ����
        private void add_Click(object sender, EventArgs e)
        {
            loadType();
            addFun();
        }

        private void loadType()
        {
            query_state.Items.Clear();
            if (langugeChange.Text == "����")
            {
                query_state.Items.AddRange(stateArr);
            }
            if (langugeChange.Text == "English")
            {
                query_state.Items.AddRange(stateArrEn);
            }
            List<WorkTypeBean> workTypeList = dataBaseManager.loadTypeList();
            if (workTypeList != null && workTypeList.Count > 0)
            {
                List<string> typeList = new List<string>();
                foreach (WorkTypeBean item in workTypeList)
                {
                    typeList.Add(item.Type);
                }
                input_type.Items.Clear();
                input_type.Items.AddRange(typeList.ToArray());
                input_type.SelectedIndex = 0;

                query_type.Items.Clear();
                query_type.Items.AddRange(typeList.ToArray());
            }
        }

        private void addFun()
        {
            editId = 0;
            DateTime nowDate = DateTime.Now;
            input_date.Value = nowDate;
            input_content.Text = "";
            // ��ѯ�������������
            string queryDate = DateTime.Now.ToString("yyyy-MM-dd");
            int maxNum = dataBaseManager.getMaxNum(queryDate);
            maxNum = maxNum + 1;
            input_num.Value = maxNum;

            loadData();
        }


        // ����
        private void save_Click(object sender, EventArgs e)
        {
            if (input_content.Text.Trim() == "")
            {
                return;
            }
            WorkListBean bean = new WorkListBean();
            bean.Num = input_num.Value.ToString();
            bean.Date = input_date.Text;
            bean.Type = input_type.Text;
            bean.Content = input_content.Text;

            if (editId == 0)
            {
                if (langugeChange.Text == "����")
                {
                    bean.State = stateArr[0];
                }
                if (langugeChange.Text == "English")
                {
                    bean.State = stateArrEn[0];
                }
                dataBaseManager.insertData(bean);
            }
            else
            {
                bean.Id = editId;
                dataBaseManager.updateData(bean);
            }
            addFun();
        }

        // ��ѯ
        private void query_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            // ���ò�ѯ����
            DateTime startTime = query_date_start.Value;
            string queryDateStart = startTime.ToString("yyyy-MM-dd");
            string queryDateEnd = query_date_end.Text;
            string queryType = query_type.Text;
            string queryContent = query_content.Text;
            string queryState = query_state.Text;
            if (queryType == "��ѡ�����" || queryType == "Please choose a type")
            {
                queryType = "";
            }
            if (queryState == "��ѡ��״̬" || queryState == "Please choose a state")
            {
                queryState = "";
            }

            List<WorkListBean> workList = dataBaseManager.queryData(queryDateStart, queryDateEnd, queryType, queryContent, queryState);
            dataGridView1.DataSource = workList;
            // todo δ��Ч
            // input_content.Focus();
        }


        private void input_date_ValueChanged(object sender, EventArgs e)
        {
            string queryDate = input_date.Text;
            int maxNum = dataBaseManager.getMaxNum(queryDate);
            maxNum = maxNum + 1;
            input_num.Value = maxNum;
        }

        // �༭����
        private void editType_Click(object sender, EventArgs e)
        {
            EditTypeForm editTypeForm = new EditTypeForm(langugeChange.Text);
            // ���õ�������ʼλ��Ϊ����������ڵ�λ��
            editTypeForm.StartPosition = FormStartPosition.Manual;
            Point mainFormLocation = this.Location;
            // ���õ�������������ڵ�λ��ƫ����
            int offsetX = 300;
            int offsetY = 65;
            // ���㵯����λ��
            editTypeForm.Location = new System.Drawing.Point(mainFormLocation.X + offsetX, mainFormLocation.Y + offsetY);
            editTypeForm.ShowDialog();
        }

        // ��ǰһ��
        private void label_before_day_Click(object sender, EventArgs e)
        {
            DateTime currentDate = query_date_start.Value;
            DateTime previousDate = currentDate.AddDays(-1);
            query_date_start.Value = previousDate;

        }

        // ���һ��
        private void label_after_day_Click(object sender, EventArgs e)
        {
            DateTime currentDate = query_date_end.Value;
            DateTime previousDate = currentDate.AddDays(1);
            query_date_end.Value = previousDate;
        }

        private void label_before_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BorderStyle = BorderStyle.FixedSingle;
            if (langugeChange.Text == "����")
            {
                label.Text = "��ǰһ��";
            }
            if (langugeChange.Text == "English")
            {
                label.Text = "1 Day Ahead";
            }
        }

        private void label_before_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BorderStyle = BorderStyle.None;
            label.ForeColor = SystemColors.ControlText;
            if (langugeChange.Text == "����")
            {
                label.Text = "��ʼ����";
            }
            if (langugeChange.Text == "English")
            {
                label.Text = "Start Date";
            }
        }

        private void label_after_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BorderStyle = BorderStyle.FixedSingle;
            if (langugeChange.Text == "����")
            {
                label.Text = "���һ��";
            }
            if (langugeChange.Text == "English")
            {
                label.Text = "1 Day Later";
            }
        }

        private void label_after_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BorderStyle = BorderStyle.None;
            label.ForeColor = SystemColors.ControlText;
            if (langugeChange.Text == "����")
            {
                label.Text = "��������";
            }
            if (langugeChange.Text == "English")
            {
                label.Text = "End Date";
            }
        }

        // ˫���༭
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // ���˫�����Ƿ��������У������Ǳ�ͷ����������
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                // ��ȡ�󶨵�����Դ����
                var dataItem = row.DataBoundItem;
                if (dataItem is WorkListBean work)
                {
                    editId = work.Id;
                    try
                    {
                        DateTime inputDate = DateTime.Parse(work.Date);
                        input_date.Value = inputDate;
                    }
                    catch (FormatException)
                    {
                        input_date.Value = DateTime.Now;
                    }
                    // �����޸����ֵ
                    input_num.Value = int.Parse(work.Num);
                    input_type.Text = work.Type;
                    input_content.Text = work.Content;
                }
            }
        }

        // ������
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // ���״̬��ʱ�л�״̬
            if (e.ColumnIndex == dataGridView1.Columns["state"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                var dataItem = row.DataBoundItem;
                if (dataItem is WorkListBean work)
                {
                    int id = work.Id;
                    string state = work.State;
                    string newState = state;
                    string[] stateArrCurr = stateArr;
                    if (langugeChange.Text == "English")
                    {
                        stateArrCurr = stateArrEn;
                    }
                    int len = stateArrCurr.Length;
                    for (int i = 0; i < len; i++)
                    {
                        if (stateArr[i] == state)
                        {
                            if (i == len - 1)
                            {
                                newState = stateArr[0];
                            }
                            else
                            {
                                newState = stateArr[i + 1];
                            }
                        }
                    }
                    dataBaseManager.updateState(id, newState);
                    dataGridView1.Rows[e.RowIndex].Cells[5].Value = newState;
                    // loadData();
                }
            }
            // ���ɾ����
            if (e.ColumnIndex == dataGridView1.Columns["operate"].Index && e.RowIndex >= 0)
            {
                // ���������ɾ��������������Чʱ
                string tipTitle = "";
                string tipMsg = "";
                if (langugeChange.Text == "����")
                {
                    tipTitle = "ȷ��ɾ��";
                    tipMsg = "�Ƿ�ȷ��ɾ��������?";
                }
                if (langugeChange.Text == "English")
                {
                    tipTitle = "Confirm Delete";
                    tipMsg = "Are you sure to delete this data?";
                }
                DialogResult result = MessageBox.Show(tipMsg, tipTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    var dataItem = row.DataBoundItem;
                    if (dataItem is WorkListBean work)
                    {
                        int id = work.Id;
                        dataBaseManager.deleteData(id);
                    }
                    loadData();
                }
            }

        }

        // ʹ�ò�ͬ��ɫ��ʾ״̬
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["state"].Index)
            {
                string state = e.Value == null ? "" : e.Value.ToString();
                int len = stateArr.Length;
                if (len > 0 && state == stateArr[0])
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else if (len > 1 && state == stateArr[1])
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else if (len > 2 && state == stateArr[2])
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }
            }
        }

        // �����ı�
        private void exportTxt_Click(object sender, EventArgs e)
        {
            string queryDateStart = query_date_start.Text;
            string queryDateEnd = query_date_end.Text;
            string queryType = query_type.Text;
            string queryContent = query_content.Text;
            string queryState = query_state.Text;
            if (queryType == "��ѡ�����" || queryType == "Please choose a type")
            {
                queryType = "";
            }
            if (queryState == "��ѡ��״̬" || queryState == "Please choose a state")
            {
                queryState = "";
            }

            TxtForm txtForm = new TxtForm(langugeChange.Text, queryDateStart, queryDateEnd, queryType, queryContent, queryState);
            txtForm.StartPosition = FormStartPosition.Manual;
            Point mainFormLocation = this.Location;
            int offsetX = 50;
            int offsetY = 20;
            txtForm.Location = new System.Drawing.Point(mainFormLocation.X + offsetX, mainFormLocation.Y + offsetY);
            txtForm.ShowDialog();
        }

        // ͳ��
        private void statistics_Click(object sender, EventArgs e)
        {
            string queryDateStart = query_date_start.Text;
            string queryDateEnd = query_date_end.Text;
            string queryType = query_type.Text;
            string queryContent = query_content.Text;
            string queryState = query_state.Text;
            if (queryType == "��ѡ�����" || queryType == "Please choose a type")
            {
                queryType = "";
            }
            if (queryState == "��ѡ��״̬" || queryState == "Please choose a state")
            {
                queryState = "";
            }

            ChartForm chartForm = new ChartForm(langugeChange.Text, queryDateStart, queryDateEnd, queryType, queryContent, queryState);
            chartForm.StartPosition = FormStartPosition.Manual;
            Point mainFormLocation = this.Location;
            int offsetX = 50;
            int offsetY = 20;
            chartForm.Location = new System.Drawing.Point(mainFormLocation.X + offsetX, mainFormLocation.Y + offsetY);
            chartForm.ShowDialog();
        }

        // ��������
        private void label_intention_Click(object sender, EventArgs e)
        {
            IntentionForm intentionForm = new IntentionForm();
            intentionForm.StartPosition = FormStartPosition.Manual;
            Point mainFormLocation = this.Location;
            int offsetX = 200;
            int offsetY = 30;
            intentionForm.Location = new System.Drawing.Point(mainFormLocation.X + offsetX, mainFormLocation.Y + offsetY);
            intentionForm.ShowDialog();
        }

        private void label_intention_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BorderStyle = BorderStyle.FixedSingle;
            label.ForeColor = Color.DarkGreen;
        }

        private void label_intention_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BorderStyle = BorderStyle.None;
            label.ForeColor = SystemColors.ControlText;
        }

        // ��ά��ͼƬ
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
        }

        // ����Excel
        private void exportExcel_Click(object sender, EventArgs e)
        {
            DataGridViewColumnCollection columns = dataGridView1.Columns;
            DataGridViewRowCollection rows = dataGridView1.Rows;
            if (rows.Count > 0)
            {
                ExportToExcel(columns, rows);
            }
        }
        private void ExportToExcel(DataGridViewColumnCollection columns, DataGridViewRowCollection rows)
        {
            string title = "������¼";
            if (langugeChange.Text == "English")
            {
                title = "work record";
            }
            using (ExcelPackage package = new ExcelPackage())
            {
                // ����������
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(title);

                // д���ͷ
                for (int i = 1; i < columns.Count - 1; i++)
                {
                    worksheet.Cells[1, i].Value = columns[i].HeaderText;
                    worksheet.Cells[1, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[1, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    worksheet.Cells[1, i].Style.Font.Bold = true;
                }
                // д������
                for (int i = 0; i < rows.Count; i++)
                {
                    for (int j = 1; j < columns.Count - 1; j++)
                    {
                        worksheet.Cells[i + 2, j].Value = rows[i].Cells[j].Value.ToString();
                        worksheet.Cells[i + 2, j].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells[i + 2, j].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        worksheet.Column(j).Width = 12;
                        if (columns[j].Index == 4)
                        {
                            worksheet.Column(j).Width = 50;
                            worksheet.Cells[i + 2, j].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        }
                    }
                }
                // �����ļ�
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel�ļ�|*.xlsx";
                saveFileDialog.FileName = title + ".xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                    package.SaveAs(fileInfo);
                }
            }
        }

        // �л�����
        private void langugeChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (langugeChange.Text == "����")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh");
                ApplyResource();
            }
            if (langugeChange.Text == "English")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");
                ApplyResource();
            }
            loadType();
            dataGridResource();
        }

        private void ApplyResource()
        {
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(LiteStarNoteForm));
            foreach (Control ctl in Controls)
            {
                if (ctl is GroupBox)
                {
                    res.ApplyResources(ctl, ctl.Name);
                    GroupBox g = ctl as GroupBox;
                    foreach (Control item in g.Controls)
                    {
                        res.ApplyResources(item, item.Name);
                    }
                }
                else
                {
                    res.ApplyResources(ctl, ctl.Name);
                }
            }
            this.ResumeLayout(false);
            this.PerformLayout();
            res.ApplyResources(this, "$this");
        }
        private void dataGridResource()
        {
            if (langugeChange.Text == "����")
            {
                dataGridView1.Columns[1].HeaderCell.Value = "���";
                dataGridView1.Columns[2].HeaderCell.Value = "����";
                dataGridView1.Columns[3].HeaderCell.Value = "����";
                dataGridView1.Columns[4].HeaderCell.Value = "����";
                dataGridView1.Columns[5].HeaderCell.Value = "״̬";
                dataGridView1.Columns[6].HeaderCell.Value = "����";
                openMenuItem.Text = "��";
                exitMenuItem.Text = "�˳�";
            }
            if (langugeChange.Text == "English")
            {
                dataGridView1.Columns[1].HeaderCell.Value = "Num";
                dataGridView1.Columns[2].HeaderCell.Value = "Date";
                dataGridView1.Columns[3].HeaderCell.Value = "Type";
                dataGridView1.Columns[4].HeaderCell.Value = "Content";
                dataGridView1.Columns[5].HeaderCell.Value = "State";
                dataGridView1.Columns[6].HeaderCell.Value = "Operate";
                openMenuItem.Text = "Open";
                exitMenuItem.Text = "Exit";
            }
        }

        // �ر�ʱ����������
        private void liteStarNoteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ע���жϹر��¼�reason��Դ�ڴ��尴ť�������ò˵��˳�ʱ�޷��˳�!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                //ʹ�ر�ʱ���������½���С��Ч��
                this.WindowState = FormWindowState.Minimized;
                this.notifyIcon1.Visible = true;
                this.Hide();
                return;
            }
        }

        private void NotifyIcon1_DoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
            {
                this.WindowState = FormWindowState.Minimized;
                // this.notifyIcon1.Visible = true;
                this.Hide();
            }
            else
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }
        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.WindowState = FormWindowState.Minimized;
                // this.notifyIcon1.Visible = true;
                this.Hide();
            }
            else
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = false;
            // Application.Exit();
            this.Close();
            this.Dispose();
            System.Environment.Exit(System.Environment.ExitCode);
        }


        // todo ����Ӣ�Ľ���ʱ,360��ȫ��ʿ��ʾ��һ��ľ��,����û��������

        // todo ����ɵ����ļ�

        // todo ͼ����ɫ�е�ǳ,�����ټ��±��Ͷ�

        // todo ����һ��ʱ���,������ͼ�궪ʧ,����˰�ɫ���½��ļ���ͼ��

        // todo 5000������������3��,�۲��ڴ�ռ�����

    }



}
