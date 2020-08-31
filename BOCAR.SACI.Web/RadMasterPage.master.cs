using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

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
					currentUser.ToolTip = BOCAR.SACI.Business.SecurityManager.ObtenerUsuario(HttpContext.Current).Perfil + " - " +
																BOCAR.SACI.Business.SecurityManager.ObtenerUsuario(HttpContext.Current).Usuario;
					LoadMainMenu(BOCAR.SACI.Business.SecurityManager.ObtenerUsuario(HttpContext.Current).IdRol);
				}
				catch (Exception LoExcepcion)
				{
					throw new ApplicationException(string.Format("Ocurrió el siguiente error: \n{0}", LoExcepcion.Message), LoExcepcion);
				}
			}
		}
	}

	protected void LoadMainMenu(int iRol)
	{
		List<BOCAR.SACI.Data.menuRolCompositeType> menu = null;
		if (Session["MenuH"] == null)
		{
			var swap = new BOCAR.SACI.Business.MenuRolManager();
			Session["MenuH"] = swap.getAllMenuRol(iRol);
		}
		menu = (List<BOCAR.SACI.Data.menuRolCompositeType>)Session["MenuH"];
		if (menu.Count == 0)
		{
			var swap = new BOCAR.SACI.Business.MenuRolManager();
			Session["MenuH"] = swap.getAllMenuRol(iRol);
		}
		foreach (var miNuevo in menu.Select(mt => new MenuItem { NavigateUrl = mt.sModulo, Text = mt.sDescription, Value = mt.iIdMenu.ToString(), Selectable = true }))
		{
			MenuHorizontal.Items.Add(miNuevo);
		}
	}
}