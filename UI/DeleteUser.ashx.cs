using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI
{
    /// <summary>
    /// DeleteUser 的摘要说明
    /// </summary>
    public class DeleteUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id;
            if (int.TryParse(context.Request.QueryString["id"],out id))
            {
                BLL.UserInfoBll userinfobll = new BLL.UserInfoBll();
                if (userinfobll.DeleteUserInfo(id))
                {
                    context.Response.Redirect("index.ashx");
                }
                else
                {
                    context.Response.Redirect("Error.html");
                }
            }
            else
            {
                context.Response.Write("参数错误");
            }
            context.Response.Write("Hello World");
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