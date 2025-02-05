namespace LiteStarNote
{
    partial class LiteStarNoteForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiteStarNoteForm));
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            label_intention = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            exportTxt = new Button();
            exportExcel = new Button();
            query = new Button();
            save = new Button();
            editType = new Button();
            add = new Button();
            label9 = new Label();
            label_after_day = new Label();
            label_before_day = new Label();
            input_type = new ComboBox();
            query_state = new ComboBox();
            input_content = new RichTextBox();
            query_type = new ComboBox();
            query_date_end = new DateTimePicker();
            input_date = new DateTimePicker();
            query_date_start = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            label4 = new Label();
            query_content = new TextBox();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            num = new DataGridViewTextBoxColumn();
            date = new DataGridViewTextBoxColumn();
            type = new DataGridViewTextBoxColumn();
            content = new DataGridViewTextBoxColumn();
            state = new DataGridViewTextBoxColumn();
            operate = new DataGridViewButtonColumn();
            statistics = new Button();
            label7 = new Label();
            input_num = new NumericUpDown();
            pictureBox2 = new PictureBox();
            langugeChange = new ComboBox();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            openMenuItem = new ToolStripMenuItem();
            exitMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)input_num).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label_intention
            // 
            resources.ApplyResources(label_intention, "label_intention");
            label_intention.Cursor = Cursors.Hand;
            label_intention.Name = "label_intention";
            label_intention.Click += label_intention_Click;
            label_intention.MouseEnter += label_intention_MouseEnter;
            label_intention.MouseLeave += label_intention_MouseLeave;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // exportTxt
            // 
            resources.ApplyResources(exportTxt, "exportTxt");
            exportTxt.BackColor = SystemColors.Desktop;
            exportTxt.ForeColor = SystemColors.Control;
            exportTxt.Name = "exportTxt";
            exportTxt.UseVisualStyleBackColor = false;
            exportTxt.Click += exportTxt_Click;
            // 
            // exportExcel
            // 
            resources.ApplyResources(exportExcel, "exportExcel");
            exportExcel.BackColor = SystemColors.Control;
            exportExcel.ForeColor = SystemColors.ControlText;
            exportExcel.Name = "exportExcel";
            exportExcel.UseVisualStyleBackColor = false;
            exportExcel.Click += exportExcel_Click;
            // 
            // query
            // 
            resources.ApplyResources(query, "query");
            query.Name = "query";
            query.UseVisualStyleBackColor = true;
            query.Click += query_Click;
            // 
            // save
            // 
            resources.ApplyResources(save, "save");
            save.BackColor = SystemColors.Desktop;
            save.ForeColor = SystemColors.Control;
            save.Name = "save";
            save.UseVisualStyleBackColor = false;
            save.Click += save_Click;
            // 
            // editType
            // 
            resources.ApplyResources(editType, "editType");
            editType.Name = "editType";
            editType.UseVisualStyleBackColor = true;
            editType.Click += editType_Click;
            // 
            // add
            // 
            resources.ApplyResources(add, "add");
            add.BackColor = SystemColors.Desktop;
            add.FlatAppearance.BorderColor = SystemColors.Desktop;
            add.ForeColor = SystemColors.Control;
            add.Name = "add";
            add.UseVisualStyleBackColor = false;
            add.Click += add_Click;
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.Name = "label9";
            // 
            // label_after_day
            // 
            resources.ApplyResources(label_after_day, "label_after_day");
            label_after_day.Cursor = Cursors.Hand;
            label_after_day.Name = "label_after_day";
            label_after_day.Click += label_after_day_Click;
            label_after_day.DoubleClick += label_after_day_Click;
            label_after_day.MouseEnter += label_after_MouseEnter;
            label_after_day.MouseLeave += label_after_MouseLeave;
            // 
            // label_before_day
            // 
            resources.ApplyResources(label_before_day, "label_before_day");
            label_before_day.BackColor = SystemColors.Control;
            label_before_day.Cursor = Cursors.Hand;
            label_before_day.ForeColor = SystemColors.ControlText;
            label_before_day.Name = "label_before_day";
            label_before_day.Click += label_before_day_Click;
            label_before_day.DoubleClick += label_before_day_Click;
            label_before_day.MouseEnter += label_before_MouseEnter;
            label_before_day.MouseLeave += label_before_MouseLeave;
            // 
            // input_type
            // 
            resources.ApplyResources(input_type, "input_type");
            input_type.FormattingEnabled = true;
            input_type.Name = "input_type";
            // 
            // query_state
            // 
            resources.ApplyResources(query_state, "query_state");
            query_state.FormattingEnabled = true;
            query_state.Name = "query_state";
            // 
            // input_content
            // 
            resources.ApplyResources(input_content, "input_content");
            input_content.Name = "input_content";
            // 
            // query_type
            // 
            resources.ApplyResources(query_type, "query_type");
            query_type.FormattingEnabled = true;
            query_type.Name = "query_type";
            // 
            // query_date_end
            // 
            resources.ApplyResources(query_date_end, "query_date_end");
            query_date_end.Format = DateTimePickerFormat.Custom;
            query_date_end.Name = "query_date_end";
            // 
            // input_date
            // 
            resources.ApplyResources(input_date, "input_date");
            input_date.Format = DateTimePickerFormat.Custom;
            input_date.Name = "input_date";
            input_date.ValueChanged += input_date_ValueChanged;
            // 
            // query_date_start
            // 
            resources.ApplyResources(query_date_start, "query_date_start");
            query_date_start.Format = DateTimePickerFormat.Custom;
            query_date_start.Name = "query_date_start";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // query_content
            // 
            resources.ApplyResources(query_content, "query_content");
            query_content.Name = "query_content";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // dataGridView1
            // 
            resources.ApplyResources(dataGridView1, "dataGridView1");
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, num, date, type, content, state, operate });
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // id
            // 
            id.DataPropertyName = "id";
            resources.ApplyResources(id, "id");
            id.Name = "id";
            id.ReadOnly = true;
            // 
            // num
            // 
            num.DataPropertyName = "num";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            num.DefaultCellStyle = dataGridViewCellStyle8;
            resources.ApplyResources(num, "num");
            num.Name = "num";
            num.ReadOnly = true;
            // 
            // date
            // 
            date.DataPropertyName = "date";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            date.DefaultCellStyle = dataGridViewCellStyle9;
            resources.ApplyResources(date, "date");
            date.Name = "date";
            date.ReadOnly = true;
            // 
            // type
            // 
            type.DataPropertyName = "type";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            type.DefaultCellStyle = dataGridViewCellStyle10;
            resources.ApplyResources(type, "type");
            type.Name = "type";
            type.ReadOnly = true;
            // 
            // content
            // 
            content.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            content.DataPropertyName = "content";
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            content.DefaultCellStyle = dataGridViewCellStyle11;
            resources.ApplyResources(content, "content");
            content.Name = "content";
            content.ReadOnly = true;
            // 
            // state
            // 
            state.DataPropertyName = "state";
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            state.DefaultCellStyle = dataGridViewCellStyle12;
            resources.ApplyResources(state, "state");
            state.Name = "state";
            state.ReadOnly = true;
            // 
            // operate
            // 
            operate.DataPropertyName = "operate";
            resources.ApplyResources(operate, "operate");
            operate.Name = "operate";
            operate.ReadOnly = true;
            operate.Resizable = DataGridViewTriState.False;
            // 
            // statistics
            // 
            resources.ApplyResources(statistics, "statistics");
            statistics.BackColor = SystemColors.Desktop;
            statistics.ForeColor = SystemColors.Control;
            statistics.Name = "statistics";
            statistics.UseVisualStyleBackColor = false;
            statistics.Click += statistics_Click;
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // input_num
            // 
            resources.ApplyResources(input_num, "input_num");
            input_num.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            input_num.Name = "input_num";
            input_num.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // pictureBox2
            // 
            resources.ApplyResources(pictureBox2, "pictureBox2");
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Name = "pictureBox2";
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // langugeChange
            // 
            resources.ApplyResources(langugeChange, "langugeChange");
            langugeChange.DropDownStyle = ComboBoxStyle.DropDownList;
            langugeChange.FormattingEnabled = true;
            langugeChange.Items.AddRange(new object[] { resources.GetString("langugeChange.Items"), resources.GetString("langugeChange.Items1") });
            langugeChange.Name = "langugeChange";
            langugeChange.SelectedIndexChanged += langugeChange_SelectedIndexChanged;
            // 
            // notifyIcon1
            // 
            resources.ApplyResources(notifyIcon1, "notifyIcon1");
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.MouseDoubleClick += NotifyIcon1_DoubleClick;
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { openMenuItem, exitMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip2";
            // 
            // openMenuItem
            // 
            resources.ApplyResources(openMenuItem, "openMenuItem");
            openMenuItem.Name = "openMenuItem";
            // 
            // exitMenuItem
            // 
            resources.ApplyResources(exitMenuItem, "exitMenuItem");
            exitMenuItem.Name = "exitMenuItem";
            // 
            // LiteStarNoteForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(langugeChange);
            Controls.Add(pictureBox2);
            Controls.Add(input_num);
            Controls.Add(label7);
            Controls.Add(statistics);
            Controls.Add(dataGridView1);
            Controls.Add(query_state);
            Controls.Add(label9);
            Controls.Add(query_type);
            Controls.Add(input_content);
            Controls.Add(label5);
            Controls.Add(label_after_day);
            Controls.Add(pictureBox1);
            Controls.Add(label_before_day);
            Controls.Add(query_content);
            Controls.Add(label1);
            Controls.Add(query_date_end);
            Controls.Add(label_intention);
            Controls.Add(input_type);
            Controls.Add(query_date_start);
            Controls.Add(exportExcel);
            Controls.Add(exportTxt);
            Controls.Add(save);
            Controls.Add(label6);
            Controls.Add(query);
            Controls.Add(input_date);
            Controls.Add(label4);
            Controls.Add(add);
            Controls.Add(editType);
            Controls.Add(label3);
            MaximizeBox = false;
            Name = "LiteStarNoteForm";
            FormClosing += liteStarNoteForm_FormClosing;
            Load += liteStarNoteForm_load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)input_num).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button exportTxt;
        private Button exportExcel;
        private Button query;
        private Button save;
        private Button editType;
        private Button add;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label_intention;
        private DateTimePicker input_date;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private ComboBox input_type;
        private RichTextBox input_content;
        private TextBox query_content;
        private ComboBox query_state;
        private ComboBox query_type;
        private DateTimePicker query_date_end;
        private DateTimePicker query_date_start;
        private Label label9;
        private Label label_after_day;
        private Label label_before_day;
        private DataGridView dataGridView1;
        private Button statistics;
        private Label label7;
        private NumericUpDown input_num;
        private PictureBox pictureBox2;
        private ComboBox langugeChange;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn num;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn type;
        private DataGridViewTextBoxColumn content;
        private DataGridViewTextBoxColumn state;
        private DataGridViewButtonColumn operate;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem openMenuItem;
        private ToolStripMenuItem exitMenuItem;
    }
}
