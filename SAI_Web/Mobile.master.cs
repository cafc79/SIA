using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class MasterPage : System.Web.UI.MasterPage
{
    private Utilerias util;

	protected void Page_Load(object sender, EventArgs e)
	{
        util = new Utilerias();
		if (!Page.IsPostBack)
		{
			if (HttpContext.Current.User.Identity.IsAuthenticated)
			{
				try
				{
					currentUser.ToolTip = DS.SAI.Business.SecurityManager.ObtenerUsuario(HttpContext.Current).Perfil + " - " +
																DS.SAI.Business.SecurityManager.ObtenerUsuario(HttpContext.Current).Usuario;
					LoadMainMenu(DS.SAI.Business.SecurityManager.ObtenerUsuario(HttpContext.Current).IdRol);
                    
                    util.LoadMenu(Page.Request.Url.Segments[Page.Request.Url.Segments.Length - 1],
                                      DS.SAI.Business.SecurityManager.ObtenerUsuario(HttpContext.Current).IdRol, ref ChildrenMenu);
                    
				}
                catch (ArgumentNullException ex)
                {
                    Alert.Show(ex.Message, this.Page);
                    Alert.Denegado(this.Page);
                }
                catch (Exception LoExcepcion)
                {
                    Alert.Show(LoExcepcion.Message, this.Page);
                    throw new ApplicationException(string.Format("Ocurrió el siguiente error: \n{0}", LoExcepcion.Message), LoExcepcion);
                }
			}
		}
        RadMenuItem currentItem = MenuHorizontal.FindItemByUrl(Request.Url.PathAndQuery);
        if (currentItem != null)
        {
            //Select the current item and his parents
            currentItem.HighlightPath();
            //Update the title of the
            PageTitleLiteral.Text = currentItem.Text;
            //Populate the breadcrumb
            //DataBindBreadCrumbSiteMap(currentItem);
        }
        else
            MenuHorizontal.Items[0].HighlightPath();
	}

    private void DataBindBreadCrumbSiteMap(RadMenuItem currentItem)
    {
        List<RadMenuItem> breadCrumbPath = new List<RadMenuItem>();
        while (currentItem != null)
        {
            breadCrumbPath.Insert(0, currentItem);
            currentItem = currentItem.Owner as RadMenuItem;
        }
        BreadCrumbSiteMap.DataSource = breadCrumbPath;
        BreadCrumbSiteMap.DataBind();
    }

	protected void LoadMainMenu(int iRol)
	{
		List<DS.SAI.Data.menuRolCompositeType> menu = null;
		if (Session["MenuH"] == null)
		{
			var swap = new DS.SAI.Business.MenuRolManager();
			Session["MenuH"] = swap.getAllMenuRol(iRol);
		}
		menu = (List<DS.SAI.Data.menuRolCompositeType>)Session["MenuH"];
		if (menu.Count == 0)
		{
			var swap = new DS.SAI.Business.MenuRolManager();
			Session["MenuH"] = swap.getAllMenuRol(iRol);
		}
        foreach (var miNuevo in menu.Select(mt => new RadMenuItem { NavigateUrl = mt.sModulo, Text = mt.sDescription, Value = mt.iIdMenu.ToString() }))
		{
			MenuHorizontal.Items.Add(miNuevo);
		}
	}
}