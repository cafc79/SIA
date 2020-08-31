using System;
using System.Web;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
			if (!HttpContext.Current.User.Identity.IsAuthenticated)
				Response.Redirect("Services/Logout.ashx");
    }
}
