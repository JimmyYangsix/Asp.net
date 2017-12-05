using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Model;
using System.IO;
namespace UI
{
    /// <summary>
    /// index 的摘要说明
    /// </summary>
    public class index : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            BLL.UserInfoBll ubll = new BLL.UserInfoBll();
            List<UserInfo> list =ubll.GetList();
            StringBuilder sb= new StringBuilder();
            int i = 0;
            string[] className = new string[5] { "active", "success", "info", "warning", "danger" };
            foreach(UserInfo  user in list){
                sb.AppendFormat("<tr class=" + className[i % 5] + "><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td><a href='showDetail.ashx?id={0}'>详细信息</a></td>", user.Id,user.UserName,user.sid,user.UserPass,user.Direction,user.Class);
                i++;
            }
            string filepath = context.Request.MapPath("UserInfo.html");
            string fileContent = File.ReadAllText(filepath).Replace("$AllUserInfo", sb.ToString());
            context.Response.Write(fileContent);
        }
            
        public bool IsReusable
        {   
            get
            {
                return false;
            }
        }
    }
}