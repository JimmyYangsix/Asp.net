using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class Sqlhelper
    {
        private static readonly string connstr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public static DataTable GetTable(string sql, CommandType type, params SqlParameter[] pars)//返回查询结果
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    if (pars != null)
                    {
                        da.SelectCommand.Parameters.AddRange(pars);
                    }
                    da.SelectCommand.CommandType = type;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public static int ExecuteNonquery(string sql, CommandType type, params SqlParameter[] pars)//返回受影响行数
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    if (pars != null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    cmd.CommandType = type;
                    conn.Open();
                    return cmd.ExecuteNonQuery(); 
                }
            }
        }
    }
}
