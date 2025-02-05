using System;
using System.Text;
using LiteStarNote.bean;

namespace LiteStarNote
{
    public partial class TxtForm : Form
    {
        DataBaseManager dataBaseManager = new DataBaseManager();
        string languge = "中文";
        public TxtForm(string langugeStr, string queryDateStart, string queryDateEnd, string queryType, string queryContent, string queryState)
        {
            InitializeComponent();
            languge = langugeStr;
            showData(queryDateStart, queryDateEnd, queryType, queryContent, queryState);
        }

        public void showData(string queryDateStart, string queryDateEnd, string queryType, string queryContent, string queryState)
        {
            List<WorkListBean> workList = dataBaseManager.queryData(queryDateStart, queryDateEnd, queryType, queryContent, queryState);
            StringBuilder txtSb = new StringBuilder("");
            if (languge == "中文") {
                txtSb.Append("请将以下内容,整理成工作总结:");
                txtSb.Append(Environment.NewLine);
                foreach (WorkListBean work in workList)
                {
                    if (work != null)
                    {
                        // 第1个,新增问题类别,该事项已完成,工作内容: 修改了整理成txt的问题
                        txtSb.Append("第");
                        txtSb.Append(work.Num);
                        txtSb.Append("个,");
                        txtSb.Append(work.Type);
                        txtSb.Append("类别,该事项");
                        txtSb.Append(work.State);
                        txtSb.Append(",工作内容:");
                        string modifiedString = work.Content.Replace("\n", ".");
                        txtSb.Append(modifiedString);
                        txtSb.Append(Environment.NewLine);
                    }
                }
            }

            if (languge == "English")
            {
                txtSb.Append("Please organize the following content into a work summary:");
                txtSb.Append(Environment.NewLine);
                foreach (WorkListBean work in workList)
                {
                    if (work != null)
                    {
                        txtSb.Append(work.Num);
                        txtSb.Append(".Type of '");
                        txtSb.Append(work.Type);
                        txtSb.Append("'.The matter state:'");
                        txtSb.Append(work.State);
                        txtSb.Append("'.Work content:");
                        string modifiedString = work.Content.Replace("\n", ".");
                        txtSb.Append(modifiedString);
                        txtSb.Append(Environment.NewLine);
                    }
                }
            }
            txt_Text.Text = txtSb.ToString();
        }

    }
}
