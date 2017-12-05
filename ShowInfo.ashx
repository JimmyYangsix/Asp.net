<%@ WebHandler Language="C#" Class="ShowInfo" %>

using System;
using System.Web;
using System.IO;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public class ShowInfo : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
        DataTable dt = new DataTable();
        string constr = "Data Source=.;Initial Catalog=yyxm;Integrated Security=True";
        string cmdstr = " select * from [dbo].[user]";
        SqlConnection con = new SqlConnection(constr);
        SqlDataAdapter sda = new SqlDataAdapter(cmdstr,con);
        sda.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            int i = 0;
            string[] className = new string[5] { "active", "success", "info", "warning", "danger" };
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                sb.AppendFormat("<tr class=" + className[i % 5] + "><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td>", dr["id"].ToString(), dr["username"].ToString(), dr["userid"].ToString(), dr["userpwd"].ToString(), dr["userplace"].ToString(), dr["userclass"].ToString());
                i++;
            }
            string filepath = context.Request.MapPath("index.html");
            string fileContent = File.ReadAllText(filepath).Replace(" $AllUserInfo", sb.ToString());
            context.Response.Write(fileContent);
        }
        else
        {
            context.Response.Write("尚未查到用户信息");
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}