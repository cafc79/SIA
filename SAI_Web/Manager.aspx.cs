using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BO = DS.SAI.Business;

public partial class Manager : System.Web.UI.Page
{
	private Utilerias util;
    private Menu mpMenu;

	protected void Page_Load(object sender, EventArgs e)
	{
		util = new Utilerias();
        mpMenu = (System.Web.UI.WebControls.Menu)Master.FindControl("ChildrenMenu");
        mpMenu.MenuItemClick += new MenuEventHandler(menuSecurity_MenuItemClick);
	}

	#region Menu
	protected void menuSecurity_MenuItemClick(object sender, MenuEventArgs e)
	{   
		string action = util.GetActionMenu(mpMenu.SelectedItem.Value, false);
		if (action == "imRol" || action == "imUsers")
				Response.Redirect("Security.aspx?mod=" + action, false);
	}
	#endregion

	protected void btnConfigCancel_Click(object sender, EventArgs e)
	{
		gvEtapa.Rebind();
		gvArea.Rebind();
		gvUsers.Rebind();
	}

	protected void btnConfigAceptar_Click(object sender, EventArgs e)
	{
		var Etapas = new List<string>();
		var Areas = new List<byte>();
		var Usuarios = new List<byte>();
		try
		{
			for (int i = 0; i < gvEtapa.Items.Count; i++)
			{
				var cb = (CheckBox)gvEtapa.Items[i].Controls[2].Controls[1];
				if (cb.Checked)
					Etapas.Add(gvEtapa.Items[i]["Id"].Text);
			}
			for (int i = 0; i < gvArea.Items.Count; i++)
			{
				var cb = (CheckBox)gvArea.Items[i].Controls[2].Controls[1];
				if (cb.Checked)
					Areas.Add(byte.Parse(gvArea.Items[i]["Id"].Text));
			}
			for (int i = 0; i < gvUsers.Items.Count; i++)
			{
				var cb = (CheckBox)gvUsers.Items[i].Controls[2].Controls[1];
				if (cb.Checked)
					Usuarios.Add(byte.Parse(gvUsers.Items[i]["fiid_user"].Text));
			}
			if ((Etapas.Count > 0) && ((Areas.Count > 0) || (Usuarios.Count > 0)))
			{
				var bo = new BO.BuzonManager();
				bo.InsertConfigBuzon(int.Parse(comboModulo.SelectedValue), Etapas, Areas, Usuarios);
				gvConfigs.Rebind();
				gvEtapa.Rebind();
				gvArea.Rebind();
				gvUsers.Rebind();
			}
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
		catch (ArgumentException ae)
		{
			util.ErroDisplay(3, ae.Message, ref lblMessage);
		}
		catch (Exception ex)
		{
			util.ErroDisplay(1, ex.Message, ref lblMessage);
		}
	}

	protected void gvConfigs_ItemCommand(object sender, GridCommandEventArgs e)
	{
		try {
		lblMessage.Text = string.Empty;
		var item = (Telerik.Web.UI.GridDataItem)e.Item;
		int id = int.Parse(gvConfigs.Items[item.ItemIndex]["Configuracion"].Text);
		if (e.CommandName == "deleteId")
			{
				var bo = new BO.BuzonManager();
				bo.DeleteConfigBuzon(id);
				gvConfigs.Rebind();
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = "Error al guardar el registro, comuniquese con el administrador: " + ex.Message.ToString();
		}
	}
}