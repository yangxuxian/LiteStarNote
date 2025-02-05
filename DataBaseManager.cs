using System;
using System.Data.SQLite;
using LiteStarNote.bean;

namespace LiteStarNote
{

    internal class DataBaseManager
    {
        private string connectionString = "Data Source=LiteStarNote.db;Version=3;";

        // 初始化数据库
        public void initTable()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                // 查询 sqlite_master 表,检查 work_list 表是否存在
                string checkTableQuery = "SELECT name FROM sqlite_master WHERE type='table' AND name='work_list';";
                using (SQLiteCommand checkTableCommand = new SQLiteCommand(checkTableQuery, conn))
                {
                    object result = checkTableCommand.ExecuteScalar();
                    if (result == null)
                    {
                        // 如果表不存在，创建 work_list 表
                        string createTableQuery = "CREATE TABLE work_list (Id INTEGER PRIMARY KEY AUTOINCREMENT, num INT, date VARCHAR(20),type VARCHAR(50),content VARCHAR(1000),state VARCHAR(20));";
                        using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, conn))
                        {
                            createTableCommand.ExecuteNonQuery();
                        }
                    }
                }

                string checkWorkTypeQuery = "SELECT name FROM sqlite_master WHERE type='table' AND name='work_type';";
                using (SQLiteCommand checkWorkTypeCommand = new SQLiteCommand(checkWorkTypeQuery, conn))
                {
                    object result = checkWorkTypeCommand.ExecuteScalar();
                    if (result == null)
                    {
                        string createWorkTypeQuery = "CREATE TABLE work_type (Id INTEGER PRIMARY KEY AUTOINCREMENT, type VARCHAR(50));";
                        using (SQLiteCommand createWorkTypeCommand = new SQLiteCommand(createWorkTypeQuery, conn))
                        {
                            createWorkTypeCommand.ExecuteNonQuery();
                        }
                        // 插入初始分类
                        string typeSql = "INSERT INTO work_type (type) VALUES ('新增功能'),('排查问题'),('修复优化'),('功能调试'),('协调沟通'),('数据处理'),('调查研究'),('文档方案'),('会议演示');";
                        using (SQLiteCommand typeCommand = new SQLiteCommand(typeSql, conn))
                        {
                            typeCommand.ExecuteNonQuery();
                        }
                    }
                }

                conn.Close();
            }
        }

        // 加载分类
        public List<WorkTypeBean> loadTypeList()
        {
            List<WorkTypeBean> workTypeList = new List<WorkTypeBean>();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM work_type";
                using (SQLiteCommand command = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            WorkTypeBean item = new WorkTypeBean
                            {
                                Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                Type = reader.IsDBNull(1) ? "" : reader.GetString(1)
                            };
                            workTypeList.Add(item);
                        }
                    }
                }
            }
            return workTypeList;
        }



        // 插入数据
        public void insertData(WorkListBean bean)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO work_list (num,date,type,content,state) VALUES (" + bean.Num
                    + ",'" + bean.Date + "','" + bean.Type + "','" + bean.Content + "','" + bean.State + "');";
                using (SQLiteCommand command = new SQLiteCommand(sql, conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        // 更新数据
        public void updateData(WorkListBean bean)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE work_list SET num = '" + bean.Num + "',date = '" + bean.Date + "', type = '"
                    + bean.Type + "',content = '" + bean.Content + "' WHERE id = " + bean.Id + ";";
                using (SQLiteCommand command = new SQLiteCommand(sql, conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        // 更新状态
        public void updateState(int id, string state)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE work_list SET state = '" + state + "' WHERE id = " + id + ";";
                using (SQLiteCommand command = new SQLiteCommand(sql, conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        // 查询数据
        public List<WorkListBean> queryData(string queryDateStart, string queryDateEnd, string queryType, string queryContent, string queryState)
        {
            List<WorkListBean> workList = new List<WorkListBean>();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                if (queryDateStart == "")
                {
                    queryDateStart = DateTime.Now.ToString("yyyy-MM-dd");
                }
                if (queryDateEnd == "")
                {
                    queryDateEnd = DateTime.Now.ToString("yyyy-MM-dd");
                }
                string sql = "SELECT * FROM work_list where date >= '" + queryDateStart + "' and date <= '" + queryDateEnd + "'";
                if (queryType != "")
                {
                    sql = sql + " and type = '" + queryType + "'";
                }
                if (queryState != "")
                {
                    sql = sql + " and state = '" + queryState + "'";
                }
                if (queryContent != "")
                {
                    sql = sql + " and content like '%" + queryContent + "%'";
                }
                sql = sql + " order by date, num;";
                // MessageBox.Show(sql);
                using (SQLiteCommand command = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            WorkListBean item = new WorkListBean
                            {
                                Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                Num = reader.IsDBNull(1) ? "0" : reader.GetInt32(1).ToString(),
                                Date = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                Type = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                Content = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                State = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                Operate = "删除"
                            };
                            workList.Add(item);
                        }
                    }
                }
            }
            return workList;
        }

        // 删除数据
        public void deleteData(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM work_list WHERE id = " + id + ";";
                using (SQLiteCommand command = new SQLiteCommand(sql, conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        // 删除数据
        public void replaceAllType(string insertSql)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string deleteSql = "DELETE FROM work_type WHERE 1 = 1;";
                using (SQLiteCommand deleteCommand = new SQLiteCommand(deleteSql, conn))
                {
                    deleteCommand.ExecuteNonQuery();
                }
                using (SQLiteCommand insertCommand = new SQLiteCommand(insertSql, conn))
                {
                    insertCommand.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        // 获取当天最大num
        public int getMaxNum(string queryDate)
        {
            int maxNum = 0;
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT max(num) as maxNum FROM work_list where date = '" + queryDate + "';";
                using (SQLiteCommand command = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            maxNum = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        }
                    }
                }
            }
            return maxNum;
        }




    }
}
