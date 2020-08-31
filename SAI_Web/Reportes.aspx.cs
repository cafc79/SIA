using System;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BO = DS.SAI.Business;

public partial class Reportes : System.Web.UI.Page
{
	private Utilerias util;
    private System.Web.UI.WebControls.Menu mpMenu;

	protected void Page_Load(object sender, EventArgs e)
	{
		util = new Utilerias();
        mpMenu = (System.Web.UI.WebControls.Menu)Master.FindControl("ChildrenMenu");
        mpMenu.MenuItemClick += new MenuEventHandler(menuSolicitud_MenuItemClick);
		try
		{	
			MenuSelected(Request.QueryString["mod"]);
			if (ViewState["Comando"] != null)
				if (ViewState["Comando"].ToString() == "repOperArea")
					Datos_v1();
				else
					Datos_v2();
		}
		catch (Exception ex)
		{
			//Response.Redirect("Services/Logout.ashx");
		}
	}

	private void ResetGrid(string sExclusion)
	{
		int j = 0;
		for (int i = 0; i < Page.Controls[0].Controls[3].Controls[7].Controls[23].Controls.Count; i++)
		{
			for (j = 0; j < Page.Controls[0].Controls[3].Controls[7].Controls[23].Controls[i].Controls.Count; j++)
			{
				if (Page.Controls[0].Controls[3].Controls[7].Controls[23].Controls[i].Controls[j].GetType().Name == "RadGrid")
					//if (sExclusion != Page.Controls[0].Controls[3].Controls[7].Controls[23].Controls[i].Controls[j].ID)
					{
						((RadGrid) Page.Controls[0].Controls[3].Controls[7].Controls[23].Controls[i].Controls[j]).DataSource = null;
						((RadGrid) Page.Controls[0].Controls[3].Controls[7].Controls[23].Controls[i].Controls[j]).DataBind();
					}
			}
		}
	}

	protected void menuSolicitud_MenuItemClick(object sender, MenuEventArgs e)
	{   
		if (ViewState["Comando"] != null)
			ResetGrid(ViewState["Comando"].ToString());
		String menu = util.GetActionMenu(mpMenu.SelectedItem.Value, false);
		ViewState["Comando"] = menu;
		MenuSelected(util.GetActionMenu(mpMenu.SelectedItem.Value, false));
	}

	private void MenuSelected(string sAction)
	{
		try
		{
			util.GetValidStage(sAction, mpMenu);
			switch (sAction)
			{
				case "repOperArea":
					rmpBusqueda.SelectedIndex = 0;
					rmpDatos.SelectedIndex = 0;
					break;
				case "repEjecCostos":
					repAuditoria_Bind(false);
					rmpBusqueda.SelectedIndex = 1;
					rmpDatos.SelectedIndex = 1;
					break;
				case "repEjecTiempos":
					repAuditoria_Bind(false);
					rmpBusqueda.SelectedIndex = 1;
					rmpDatos.SelectedIndex = 2;
					break;
				case "repEjecClientes":
					repAuditoria_Bind(false);
					rmpBusqueda.SelectedIndex = 1;
					rmpDatos.SelectedIndex = 3;
					break;
				case "repAudiPinterno":
					repAuditoria_Bind(true);
					rmpBusqueda.SelectedIndex = 1;
					rmpDatos.SelectedIndex = 4;
					break;
				case "repExchangeNote":
					Response.Redirect("Documentos.aspx?mod=" + sAction);
					break;
				case "repDocsReq":
					Response.Redirect("Documentos.aspx?mod=" + sAction);
					break;
			}
		}
		catch (ArgumentNullException ex)
		{
			Alert.Denegado(this.Page);
		}
	}

	private void repAuditoria_Bind(bool bBinder)
	{
		if (!bBinder)
		{
			Label6.Text = "Cliente";
			ddlCliente.DataSourceID = "sqlDSClient";
			ddlCliente.DataTextField = "sDescription";
			ddlCliente.DataValueField = "iIdClient";
		}
		else
		{
			ddlCliente.DataSourceID = "sqlDSPartList";
			Label6.Text = "Número de Parte";
			ddlCliente.DataTextField = "sDescription";
			ddlCliente.DataValueField = "iIdPArt";
			

		}
	}

	protected void Button1_Click(object sender, System.EventArgs e)
	{
		try
		{
			ConfigureExport();
			switch (ViewState["Comando"].ToString())
			{
				case "repOperArea":
					repOperArea.MasterTableView.ExportToExcel();
					break;
				case "repEjecCostos":
					repEjecCostos.MasterTableView.ExportToExcel();
					break;
				case "repEjecTiempos":
					repEjecTiempos.MasterTableView.ExportToExcel();
					break;
				case "repEjecClientes":
					repEjecClientes.MasterTableView.ExportToExcel();
					break;
				case "repAudiPinterno":
					repAudiPinterno.MasterTableView.ExportToExcel();
					break;
			}
		}
		catch { }
	}

	protected void Button2_Click(object sender, System.EventArgs e)
	{
		try
		{
			ConfigureExport();
			switch (ViewState["Comando"].ToString())
			{
				case "repOperArea":
					repOperArea.MasterTableView.ExportToWord();
					break;
				case "repEjecCostos":
					repEjecCostos.MasterTableView.ExportToWord();
					break;
				case "repEjecTiempos":
					repEjecTiempos.MasterTableView.ExportToWord();
					break;
				case "repEjecClientes":
					repEjecClientes.MasterTableView.ExportToWord();
					break;
				case "repAudiPinterno":
					repAudiPinterno.MasterTableView.ExportToWord();
					break;
			}
		}
		catch { }
	}

	protected void Button3_Click(object sender, System.EventArgs e)
	{
		try
		{
			ConfigureExport();
			switch (ViewState["Comando"].ToString())
			{
				case "repOperArea":
					repOperArea.MasterTableView.ExportToCSV();
					break;
				case "repEjecCostos":
					repEjecCostos.MasterTableView.ExportToCSV();
					break;
				case "repEjecTiempos":
					repEjecTiempos.MasterTableView.ExportToCSV();
					break;
				case "repEjecClientes":
					repEjecClientes.MasterTableView.ExportToCSV();
					break;
				case "repAudiPinterno":
					repAudiPinterno.MasterTableView.ExportToCSV();
					break;
			}
		}
		catch {}
	}

	protected void Button4_Click(object sender, System.EventArgs e)
	{
		try
		{
			ConfigureExport();
			switch (ViewState["Comando"].ToString())
			{
				case "repOperArea":
					repOperArea.MasterTableView.ExportToPdf();
					break;
				case "repEjecCostos":
					repEjecCostos.MasterTableView.ExportToPdf();
					break;
				case "repEjecTiempos":
					repEjecTiempos.MasterTableView.ExportToPdf();
					break;
				case "repEjecClientes":
					repEjecClientes.MasterTableView.ExportToPdf();
					break;
				case "repAudiPinterno":
					repAudiPinterno.MasterTableView.ExportToPdf();
					break;
			}
		}
		catch {}
	}

	protected void grid_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
	{
		if (e.CommandName == RadGrid.ExportToExcelCommandName ||
				e.CommandName == RadGrid.ExportToWordCommandName ||
				e.CommandName == RadGrid.ExportToCsvCommandName ||
				e.CommandName == RadGrid.ExportToPdfCommandName)
		{
			ConfigureExport();
		}
	}

	private void ConfigureExport()
	{
		switch (ViewState["Comando"].ToString())
		{
			case "repOperArea":
				repOperArea.ExportSettings.ExportOnlyData = CheckBox1.Checked;
				repOperArea.ExportSettings.IgnorePaging = CheckBox2.Checked;
				repOperArea.ExportSettings.OpenInNewWindow = false;
				break;
			case "repEjecCostos":
				repEjecCostos.ExportSettings.ExportOnlyData = CheckBox1.Checked;
				repEjecCostos.ExportSettings.IgnorePaging = CheckBox2.Checked;
				repEjecCostos.ExportSettings.OpenInNewWindow = false;
				break;
			case "repEjecTiempos":
				repEjecTiempos.ExportSettings.ExportOnlyData = CheckBox1.Checked;
				repEjecTiempos.ExportSettings.IgnorePaging = CheckBox2.Checked;
				repEjecTiempos.ExportSettings.OpenInNewWindow = false;
				break;
			case "repEjecClientes":
				repEjecClientes.ExportSettings.ExportOnlyData = CheckBox1.Checked;
				repEjecClientes.ExportSettings.IgnorePaging = CheckBox2.Checked;
				repEjecClientes.ExportSettings.OpenInNewWindow = false;
				break;
			case "repAudiPinterno":
				repAudiPinterno.ExportSettings.ExportOnlyData = CheckBox1.Checked;
				repAudiPinterno.ExportSettings.IgnorePaging = CheckBox2.Checked;
				repAudiPinterno.ExportSettings.OpenInNewWindow = false;
				break;
		}
	}

	protected void btnBusqueda_v1_Click(object sender, EventArgs e)
	{
		Datos_v1();
	}

	protected void btnBusqueda_v2_Click(object sender, EventArgs e)
	{
		Datos_v2();
	}

	private void Datos_v1()
	{
		try
		{
			var bo = new BO.ReportManager();
			repOperArea.DataSource = bo.Get_V1(ViewState["Comando"].ToString(), ddlOpArea.SelectedValue, txtOpFolio.Text,
																		txtOpPrefolio.Text, dtOpR1.SelectedDate,
																		dtOpR2.SelectedDate);
			repOperArea.DataBind();
		}
		catch (Exception ex)
		{
			util.ErroDisplay(3, "No hay datos disponibles para efectuar la busqueda", ref lblMessage);
		}
	}

	private void Datos_v2()
	{
		try
		{
			var bo = new BO.ReportManager();
			var swap = bo.Get_V2(ViewState["Comando"].ToString(), int.Parse(util.DefaultCombo(ddlCliente, "Cliente")), dtOpR1.SelectedDate,
													 dtOpR2.SelectedDate);
			switch (ViewState["Comando"].ToString())
			{
				case "repEjecCostos":
					repEjecCostos.DataSource = swap;
					repEjecCostos.DataBind();
					break;
				case "repEjecTiempos":
					repEjecTiempos.DataSource = swap;
					repEjecTiempos.DataBind();
					break;
				case "repEjecClientes":
					repEjecClientes.DataSource = swap;
					repEjecClientes.DataBind();
					break;
				case "repAudiPinterno":
					repAudiPinterno.DataSource = swap;
					repAudiPinterno.DataBind();
					break;
			}
		}
		catch (Exception ex)
		{
			util.ErroDisplay(3, "No hay datos disponibles para efectuar la busqueda", ref lblMessage);
		}
	}
}