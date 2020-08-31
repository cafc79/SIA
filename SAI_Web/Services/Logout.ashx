<%@ WebHandler Language="C#" Class="Logout" %>

using System;
using System.Web;
using System.Web.Security;

public class Logout : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        FormsAuthentication.SignOut();
        if (System.Web.HttpContext.Current.Session != null)
            System.Web.HttpContext.Current.Session.RemoveAll();
        context.Response.Redirect("~/Login.aspx?logOut=true");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}