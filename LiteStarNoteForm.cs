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
        // 0表示新增,有值表示编辑
        int editId = 0;
        // 状态配置,需要注意顺序,第1个使用绿色表示,第2个使用红色,第3个使用蓝色
        string[] stateArr = new string[] { "已完成", "未完成", "计划中" };
        string[] stateArrEn = new string[] { "done", "doing", "todo" };

        public LiteStarNoteForm()
        {
            InitializeComponent();
            // 初始化数据库
            dataBaseManager.initTable();
        }

        private void liteStarNoteForm_load(object sender, EventArgs e)
        {
            langugeChange.Text = "中文";
            DateTime currentDate = DateTime.Now;
            DateTime previousDate = currentDate.AddDays(-1);
            query_date_start.Value = previousDate;
            query_date_start.Refresh();

            openMenuItem.Click += OpenMenuItem_Click;
            exitMenuItem.Click += ExitMenuItem_Click;
            // 加载分类
            loadType();
            addFun();
            this.notifyIcon1.Visible = true;
        }

        // 新增
        private void add_Click(object sender, EventArgs e)
        {
            loadType();
            addFun();
        }

        private void loadType()
        {
            query_state.Items.Clear();
            if (langugeChange.Text == "中文")
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
            // 查询出当天的最大序号
            string queryDate = DateTime.Now.ToString("yyyy-MM-dd");
            int maxNum = dataBaseManager.getMaxNum(queryDate);
            maxNum = maxNum + 1;
            input_num.Value = maxNum;

            loadData();
        }


        // 保存
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
                if (langugeChange.Text == "中文")
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

        // 查询
        private void query_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            // 设置查询条件
            DateTime startTime = query_date_start.Value;
            string queryDateStart = startTime.ToString("yyyy-MM-dd");
            string queryDateEnd = query_date_end.Text;
            string queryType = query_type.Text;
            string queryContent = query_content.Text;
            string queryState = query_state.Text;
            if (queryType == "请选择分类" || queryType == "Please choose a type")
            {
                queryType = "";
            }
            if (queryState == "请选择状态" || queryState == "Please choose a state")
            {
                queryState = "";
            }

            List<WorkListBean> workList = dataBaseManager.queryData(queryDateStart, queryDateEnd, queryType, queryContent, queryState);
            dataGridView1.DataSource = workList;
            // todo 未生效
            // input_content.Focus();
        }


        private void input_date_ValueChanged(object sender, EventArgs e)
        {
            string queryDate = input_date.Text;
            int maxNum = dataBaseManager.getMaxNum(queryDate);
            maxNum = maxNum + 1;
            input_num.Value = maxNum;
        }

        // 编辑分类
        private void editType_Click(object sender, EventArgs e)
        {
            EditTypeForm editTypeForm = new EditTypeForm(langugeChange.Text);
            // 设置弹窗的起始位置为相对于主窗口的位置
            editTypeForm.StartPosition = FormStartPosition.Manual;
            Point mainFormLocation = this.Location;
            // 设置弹窗相对于主窗口的位置偏移量
            int offsetX = 300;
            int offsetY = 65;
            // 计算弹窗的位置
            editTypeForm.Location = new System.Drawing.Point(mainFormLocation.X + offsetX, mainFormLocation.Y + offsetY);
            editTypeForm.ShowDialog();
        }

        // 向前一天
        private void label_before_day_Click(object sender, EventArgs e)
        {
            DateTime currentDate = query_date_start.Value;
            DateTime previousDate = currentDate.AddDays(-1);
            query_date_start.Value = previousDate;

        }

        // 向后一天
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
            if (langugeChange.Text == "中文")
            {
                label.Text = "向前一天";
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
            if (langugeChange.Text == "中文")
            {
                label.Text = "开始日期";
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
            if (langugeChange.Text == "中文")
            {
                label.Text = "向后一天";
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
            if (langugeChange.Text == "中文")
            {
                label.Text = "结束日期";
            }
            if (langugeChange.Text == "English")
            {
                label.Text = "End Date";
            }
        }

        // 双击编辑
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 检查双击的是否是数据行，而不是表头或其他部分
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                // 获取绑定的数据源对象
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
                    // 重新修改序号值
                    input_num.Value = int.Parse(work.Num);
                    input_type.Text = work.Type;
                    input_content.Text = work.Content;
                }
            }
        }

        // 点击表格
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 点击状态列时切换状态
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
            // 点击删除列
            if (e.ColumnIndex == dataGridView1.Columns["operate"].Index && e.RowIndex >= 0)
            {
                // 当点击的是删除列且行索引有效时
                string tipTitle = "";
                string tipMsg = "";
                if (langugeChange.Text == "中文")
                {
                    tipTitle = "确认删除";
                    tipMsg = "是否确认删除该数据?";
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

        // 使用不同颜色表示状态
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

        // 导出文本
        private void exportTxt_Click(object sender, EventArgs e)
        {
            string queryDateStart = query_date_start.Text;
            string queryDateEnd = query_date_end.Text;
            string queryType = query_type.Text;
            string queryContent = query_content.Text;
            string queryState = query_state.Text;
            if (queryType == "请选择分类" || queryType == "Please choose a type")
            {
                queryType = "";
            }
            if (queryState == "请选择状态" || queryState == "Please choose a state")
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

        // 统计
        private void statistics_Click(object sender, EventArgs e)
        {
            string queryDateStart = query_date_start.Text;
            string queryDateEnd = query_date_end.Text;
            string queryType = query_type.Text;
            string queryContent = query_content.Text;
            string queryState = query_state.Text;
            if (queryType == "请选择分类" || queryType == "Please choose a type")
            {
                queryType = "";
            }
            if (queryState == "请选择状态" || queryState == "Please choose a state")
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

        // 开发初衷
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

        // 二维码图片
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
        }

        // 导出Excel
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
            string title = "工作记录";
            if (langugeChange.Text == "English")
            {
                title = "work record";
            }
            using (ExcelPackage package = new ExcelPackage())
            {
                // 创建工作表
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(title);

                // 写入表头
                for (int i = 1; i < columns.Count - 1; i++)
                {
                    worksheet.Cells[1, i].Value = columns[i].HeaderText;
                    worksheet.Cells[1, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[1, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    worksheet.Cells[1, i].Style.Font.Bold = true;
                }
                // 写入数据
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
                // 保存文件
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel文件|*.xlsx";
                saveFileDialog.FileName = title + ".xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                    package.SaveAs(fileInfo);
                }
            }
        }

        // 切换语言
        private void langugeChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (langugeChange.Text == "中文")
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
            if (langugeChange.Text == "中文")
            {
                dataGridView1.Columns[1].HeaderCell.Value = "序号";
                dataGridView1.Columns[2].HeaderCell.Value = "日期";
                dataGridView1.Columns[3].HeaderCell.Value = "分类";
                dataGridView1.Columns[4].HeaderCell.Value = "内容";
                dataGridView1.Columns[5].HeaderCell.Value = "状态";
                dataGridView1.Columns[6].HeaderCell.Value = "操作";
                openMenuItem.Text = "打开";
                exitMenuItem.Text = "退出";
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

        // 关闭时进入任务栏
        private void liteStarNoteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 注意判断关闭事件reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                //使关闭时窗口向右下角缩小的效果
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


        // todo 开发英文界面时,360安全卫士提示了一次木马,后续没有再遇到

        // todo 打包成单个文件

        // todo 图标颜色有点浅,可以再加下饱和度

        // todo 运行一段时间后,任务栏图标丢失,变成了白色的新建文件的图标

        // todo 5000条数据连续用3天,观察内存占用情况

    }



}
