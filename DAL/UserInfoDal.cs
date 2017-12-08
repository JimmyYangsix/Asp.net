using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class UserInfoDal
    {
        /// <summary>
        /// 用户数据查询
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetList()
        {
            string sql = "select * from [dbo].[user]";
            DataTable dt = Sqlhelper.GetTable(sql, CommandType.Text);
            List<UserInfo> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<UserInfo>();
                UserInfo uinfo = null;
                foreach (DataRow dr in dt.Rows)
                {
                    uinfo = new UserInfo();
                    LoadEntity(uinfo, dr);
                    list.Add(uinfo);
                }
            }
            return list;
        }
        private void LoadEntity(UserInfo userinfo, DataRow row)//数据查询
        {
            userinfo.UserName = row["username"]!=DBNull.Value?row["username"].ToString() :string.Empty;
            userinfo.UserPass = row["userpwd"] != DBNull.Value ? row["userpwd"].ToString() : string.Empty;
            userinfo.Id = Convert.ToInt32(row["id"]);
            userinfo.Class = row["userclass"] != DBNull.Value ? row["userclass"].ToString() : string.Empty;
            userinfo.Direction = row["userplace"] != DBNull.Value ? row["userplace"].ToString() : string.Empty;
            userinfo.sid=row["userid"]!=DBNull.Value ? row["userid"].ToString() : string.Empty;
        }
        /// <summary>
        /// 用户添加
        /// </summary>
        /// <param name="Allinfo">用户的所有信息</param>
        /// <returns></returns>
        public int AddUser(string[] Allinfo)
        {
            string sql = "insert into  [dbo].[user] (username,userid,userpwd,userplace,userdirection,userclass) values(@Uname,@Uid,@Upwd,@Up,@Ud,@Uc)";
            SqlParameter[] pars = {
                                  new SqlParameter("@Uname",SqlDbType.NVarChar,8),
                                  new SqlParameter("@Uid",SqlDbType.Char,16),
                                  new SqlParameter("@Upwd",SqlDbType.VarChar,16),
                                  new SqlParameter("@Up",SqlDbType.NVarChar,32),
                                  new SqlParameter("@Ud",SqlDbType.NVarChar,16),
                                  new SqlParameter("@Uc",SqlDbType.NVarChar,16)
                                                };
            for (int i = 0; i < Allinfo.Length; i++)
            {
                pars[i].Value = Allinfo[i];
            }
            return Sqlhelper.ExecuteNonquery(sql, CommandType.Text, pars);
        }
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="id">id号码</param>
        /// <returns></returns>
        public int DeleteUserInfo(int id)
        {
            string sql = "delete  [dbo].[user] where id = @uid";
            SqlParameter[] pars = {
                                  new SqlParameter("@uid",SqlDbType.Int)};
            pars[0].Value = id;
            return Sqlhelper.ExecuteNonquery(sql, CommandType.Text, pars);
        }
        public int UpdateInfo(string[] Allinfo)
        {
            string sql = "update [dbo].[user] username=@Name,userid=@ID,userpwd=@PWD,userplace=@UP,userdirection=@UD,userclass=@UC";
            SqlParameter[] pars = { 
                                  new SqlParameter("@Name",SqlDbType.NVarChar,8),
                                  new SqlParameter("@ID",SqlDbType.Char,16),
                                  new SqlParameter("@PWD",SqlDbType.VarChar,16),
                                  new SqlParameter("@UP",SqlDbType.NVarChar,32),
                                  new SqlParameter("@UD",SqlDbType.NVarChar,16),
                                  new SqlParameter("@UC",SqlDbType.NVarChar,16)
                                  };
            for (int i = 0; i < Allinfo.Length; i++)
            {
                pars[i].Value = Allinfo[i];
            }
            return Sqlhelper.ExecuteNonquery(sql, CommandType.Text, pars);
        }
    }
}
