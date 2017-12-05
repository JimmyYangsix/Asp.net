<%@ WebHandler Language="C#" Class="showDetail" %>

using System;
using System.Web;

public class showDetail : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
        int id;
        if (int.TryParse(context.Request.QueryString["id"],out id))
        {
            context.Response.Write("Hello World,My have id ="+id);
        }
        else
        {
            context.Response.Write("Sorry! Not Found" );
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}