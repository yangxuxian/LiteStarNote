using System;
using System.Text;
using LiteStarNote.bean;

namespace LiteStarNote
{
    public partial class EditTypeForm : Form
    {
        DataBaseManager dataBaseManager = new DataBaseManager();
        string languge = "中文";
        public EditTypeForm(string langugeStr)
        {
            InitializeComponent();
            languge = langugeStr;
            loadType();
        }

        private void loadType()
        {
            List<WorkTypeBean> workTypeList = dataBaseManager.loadTypeList();
            string editTypeText = "";
            List<string> typeList = new List<string>();
            foreach (WorkTypeBean item in workTypeList)
            {
                typeList.Add(item.Type);
                editTypeText = editTypeText + item.Type + Environment.NewLine;
            }
            edit_type_text.Text = editTypeText;
        }

        private void typeSave_Click(object sender, EventArgs e)
        {
            if (edit_type_text.Text.Trim().Length == 0)
            {
                string tipTitle = "";
                string tipMsg = "";
                if (languge == "中文")
                {
                    tipTitle = "错误";
                    tipMsg = "分类不能为空";
                }
                if (languge == "English")
                {
                    tipTitle = "Error";
                    tipMsg = "Types cannot be empty";
                }
                MessageBox.Show(tipMsg, tipTitle);
                return;
            }
            string[] lines = edit_type_text.Lines;
            StringBuilder insertSqlSb = new StringBuilder("INSERT INTO work_type (type) VALUES ");
            foreach (string line in lines)
            {
                if (line.Trim() != "")
                {
                    insertSqlSb.Append("('");
                    insertSqlSb.Append(line.Trim());
                    insertSqlSb.Append("'),");
                }
            }
            insertSqlSb.Remove(insertSqlSb.Length - 1, 1);
            string insertSql = insertSqlSb.ToString();
            dataBaseManager.replaceAllType(insertSql);
            this.Close();
        }

        private void editTypeForm_load(object sender, EventArgs e)
        {
            string title = "编辑分类,每一条分一行,保存时全部删除,再重新插入";
            if (languge == "English")
            {
                title = "Edit Type--One item one line.The logic is delete then reinsert";
            }
            this.Text = title;
        }
    }


}
