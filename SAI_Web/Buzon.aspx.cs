using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BO = DS.SAI.Business;

public partial class Buzon : System.Web.UI.Page
{
	private Utilerias util;
    private System.Web.UI.WebControls.Menu mpMenu;

	protected void Page_Load(object sender, EventArgs e)
	{
		util = new Utilerias();
		try
		{
			Usuario.Value = BO.SecurityManager.ObtenerUsuario(HttpContext.Current).IdUsuario.ToString();
			gridMessage.DataBind();
			gridMessage.Rebind();
            mpMenu = (System.Web.UI.WebControls.Menu)Master.FindControl("ChildrenMenu");
		}
		catch (Exception ex)
		{
			//Response.Redirect("Services/Logout.ashx");
		}
	}

	protected void imbSearch_Click(object sender, ImageClickEventArgs e)
	{
		var chkBox = (sender as ImageButton);
		Panel myPanel = chkBox.Parent as Panel;
		GridDataItem dataItem = myPanel.NamingContainer as GridDataItem;
		Response.Redirect(dataItem["Pagina"].Text + "?ex=" + dataItem["IdFolio"].Text + "&mod=" + dataItem["IdEtapa"].Text);
	}

	protected void imbDelete_Click(object sender, ImageClickEventArgs e)
	{
		try
		{
			util.GetActionMenu(mpMenu.SelectedItem.Value);
			var chkBox = (sender as ImageButton);
			var myPanel = chkBox.Parent as Panel;
			var dataItem = myPanel.NamingContainer as GridDataItem;
			var bo = new BO.BuzonManager();
			if (dataItem != null) bo.ReviewMessage(int.Parse(dataItem["IdMensaje"].Text), int.Parse(dataItem["IdUsuario"].Text));
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
		catch (Exception ex)
		{
			util.ErroDisplay(3, ex.Message, ref lblMessage);
		}
	}
}