using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BO = BOCAR.SACI.Business;

public partial class Security : System.Web.UI.Page
{
	private Utilerias util;

	protected void Page_Load(object sender, EventArgs e)
	{
		util = new Utilerias();
		try
		{
			if (!Page.IsPostBack)
			{
				util.LoadMenu(Master.Page.Request.Url.Segments[Master.Page.Request.Url.Segments.Length - 1],
				              BOCAR.SACI.Business.SecurityManager.ObtenerUsuario(HttpContext.Current).IdRol, ref menuSecurity);
				if (Request.QueryString["mod"] != null)
					menuSelected(Request.QueryString["mod"]);
			}
		}
		catch (ArgumentNullException ex)
		{
			Alert.Denegado(this.Page);
		}
		catch (Exception ex)
		{
			//Response.Redirect("Services/Logout.ashx");
		}
	}

	#region Menu
	protected void menuSecurity_MenuItemClick(object sender, MenuEventArgs e)
	{
		menuSelected(util.GetActionMenu(menuSecurity.SelectedItem.Value, false));
	}

	private void menuSelected(string action)
	{
		switch (action)
		{
			case "imRol":
				lblTitle.Text = "Rol";
				MultiPage_Seguridad.SelectedIndex = 0;
				LoadRoles();
				break;
			case "imUsers":
				lblTitle.Text = "Usuarios";
				MultiPage_Seguridad.SelectedIndex = 1;
				LoadUsuarios();
				break;
			case "imManMess":
				Response.Redirect("Manager.aspx", false);
				break;
		}
	}

	#endregion

	#region User
	private void LoadUsuarios()
	{
		//var bo = new BO.UserManager();
		//gvUsers.DataSource = bo.GetUsers();
		gvUsers.Rebind();
		var bo1 = new BO.CatalogManager();
		comboEmpleado.DataSource = bo1.GetBoss(0);
		comboEmpleado.DataBind();
	}

	protected void gvUsers_ItemCommand(object sender, GridCommandEventArgs e)
	{
		try
		{
			lblMessage.Text = string.Empty;
			var item = (Telerik.Web.UI.GridDataItem)e.Item;
			int id = int.Parse(gvUsers.Items[item.ItemIndex]["fiid_user"].Text);
			if (e.CommandName == "editId")
			{
				ViewState["IdUsuario"] = id;
				gvUsers.Items[item.ItemIndex].Selected = true;
				txtNameUser.Text = gvUsers.Items[item.ItemIndex]["fvuser_name"].Text;
				txtPassword.Text = string.Empty;
				comboEmpleado.SelectedValue = gvUsers.Items[item.ItemIndex]["fiid_employed"].Text;
				comboEmpleado.Items[util.IndexCombo(comboEmpleado, gvUsers.Items[item.ItemIndex]["fiid_employed"].Text)].Selected = true;
				comboRol.SelectedValue = gvUsers.Items[item.ItemIndex]["fiRol"].Text;
				comboRol.Items[util.IndexCombo(comboRol, gvUsers.Items[item.ItemIndex]["fiRol"].Text)].Selected = true;
			}
			if (e.CommandName == "deleteId")
			{
				var bo = new BO.UserManager();
				bo.DeleteUser(id);
				LoadUsuarios();
			}
		}
		catch (Exception ex)
		{
			util.ErroDisplay(1, ex.Message, ref lblMessage);
		}
	}

	protected void btnAddUserCancel_Click(object sender, EventArgs e)
	{
		Usuario();
	}

	private void Usuario()
	{
		txtNameUser.Text = string.Empty;
		txtPassword.Text = string.Empty;
		chkStatus.Checked = false;
		ViewState["IdUsuario"] = null;
	}


	protected void btnAddUserAdd_Click(object sender, EventArgs e)
	{
		int iNumber;
		try
		{
			Util.isRequired(txtNameUser.Text.Trim(), "Nombre Usuario");
			Util.isRequired(txtPassword.Text.Trim(), "Contraseña");
			var bo = new BO.UserManager();
			byte status = 0;
			string strUser = ViewState["IdUsuario"] == null ? "0" : ViewState["IdUsuario"].ToString();
			string msg = bo.Usuario(strUser, int.Parse(util.DefaultCombo(comboEmpleado, "Empleado")), txtNameUser.Text.Trim(), txtPassword.Text.Trim(),
									 chkStatus.Checked, int.Parse(util.DefaultCombo(comboRol, "Rol")), out status);
			util.ErroDisplay(status, msg, ref lblMessage);
			LoadUsuarios();
			Usuario();
		}
		catch (ArgumentException ae)
		{
			util.ErroDisplay(3, ae.Message, ref lblMessage);
		}
		catch (Exception ex)
		{
			util.ErroDisplay(1, string.Empty, ref lblMessage);
		}
	}
	#endregion
	
	#region Perfil de Usuario
	private void LoadRoles()
	{
		var bo = new BO.MenuRolManager();
		comboModulo.DataBind();
		GridPages();
	}

	protected void gvRol_ItemCommand(object sender, GridCommandEventArgs e)
	{
		try
		{
			lblMessage.Text = string.Empty;
			txtRol.Text = string.Empty;
			util.GetActionMenu(menuSecurity.SelectedItem.Value);
			var item = (Telerik.Web.UI.GridDataItem) e.Item;
			int id = int.Parse(gvRol.Items[item.ItemIndex]["Id"].Text);
			ViewState["rol"] = item.ItemIndex;
			gvRol.Items[item.ItemIndex].Selected = true;
			var bo = new BO.MenuRolManager();
			switch (e.CommandName)
			{
				case "editId":
					txtRol.Text = gvRol.Items[item.ItemIndex]["sDescription"].Text;
					GridPages();
					RolDetail1.SetPerfil(id);
					break;
				case "deleteId":
					bo.DeleteRol(id, 0, string.Empty);
					gvRol.Rebind();
					ViewState["rol"] = null;
					util.ErroDisplay(7, string.Empty, ref lblMessage);
					break;
				case "detailId":
					RolDetail1.SetPerfil(id);
					break;
			}
		}
		catch (ArgumentNullException ex)
		{
			Alert.Denegado(this.Page);
		}
		catch (Exception ex)
		{
			util.ErroDisplay(1, ex.Message, ref lblMessage);
		}
	}

	private void ConfigPerfil()
	{
		var bo = new BO.MenuRolManager();
		var swap = new List<string>();
		try
		{
			Util.isRequired(txtRol.Text, "Descripción");
			for (int i = 0; i < gvPagina.Items.Count; i++)
			{
				var cb = (CheckBox)gvPagina.Items[i].Controls[2].Controls[1];
				if (cb.Checked)
					swap.Add(gvPagina.Items[i]["Id"].Text);
			}
			if (swap.Count > 0)
			{
				bo.InsertUserRol(txtRol.Text, int.Parse(comboModulo.SelectedValue), swap, btnPermisos.SelectedValue);
				gvRol.Rebind();
			}
			util.ErroDisplay(5, string.Empty, ref lblMessage);
			ViewState["Modulo"] = comboModulo.SelectedValue;
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

	private void GridPages()
	{
		var bo = new BO.MenuRolManager();
		gvPagina.DataSource = bo.GetMenuPagina(short.Parse(comboModulo.SelectedValue));
		gvPagina.DataBind();
	}

	protected void comboMenuH_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
	{
		GridPages();
	}

	protected void btnCancelDesc_Click(object sender, EventArgs e)
	{
		txtRol.Text = string.Empty;
	}

	protected void btnAddDesc_Click(object sender, EventArgs e)
	{
		ConfigPerfil();
		Response.Redirect("Security.aspx?mod=imRol", false);
	}

	#endregion

	protected void gvRol_PageIndexChanged(object sender, GridPageChangedEventArgs e)
	{
		GridPages();
	}
}