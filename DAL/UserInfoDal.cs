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
        private void LoadEntity(UserInfo userinfo, DataRow row)
        {
            userinfo.UserName = row["username"]!=DBNull.Value?row["username"].ToString() :string.Empty;
            userinfo.UserPass = row["userpwd"] != DBNull.Value ? row["userpwd"].ToString() : string.Empty;
            userinfo.Id = Convert.ToInt32(row["id"]);
            userinfo.Class = row["userclass"] != DBNull.Value ? row["userclass"].ToString() : string.Empty;
            userinfo.Direction = row["userplace"] != DBNull.Value ? row["userplace"].ToString() : string.Empty;
            userinfo.sid=row["userid"]!=DBNull.Value ? row["userid"].ToString() : string.Empty;
        }
    }
}
