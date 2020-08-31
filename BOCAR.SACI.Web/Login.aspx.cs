using System;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
			FormsAuthentication.SignOut();
			if (System.Web.HttpContext.Current.Session != null)
				System.Web.HttpContext.Current.Session.RemoveAll();
    }
}
