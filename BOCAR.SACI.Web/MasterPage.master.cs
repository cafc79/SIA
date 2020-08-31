using System;
using System.Web;

public partial class MasterPage : System.Web.UI.MasterPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			if (HttpContext.Current.User.Identity.IsAuthenticated)
			{
				try
				{

				}
				catch (Exception LoExcepcion)
				{
					//Response.Redirect("Services/Logout.ashx");
					throw new ApplicationException(
					string.Format("Ocurrió el siguiente error: \n{0}", LoExcepcion.Message), LoExcepcion);
				}
			}
		}
	}
}