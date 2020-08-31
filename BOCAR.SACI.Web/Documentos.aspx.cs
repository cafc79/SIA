using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BOCAR.SACI.Business;

public partial class Documentos : System.Web.UI.Page
{
	private Utilerias util;

	protected void Page_Load(object sender, EventArgs e)
	{
		util = new Utilerias();
		try
		{
			if (!Page.IsPostBack)
			{
				util.LoadMenu("Reportes.aspx", BOCAR.SACI.Business.SecurityManager.ObtenerUsuario(HttpContext.Current).IdRol, ref menuReporte);
				wndRequerimiento.NavigateUrl = "Services/Requerimiento.aspx?ex=" + Request.QueryString["ex"] + "&mod=" + Master.Page.Request.Url.Segments[Master.Page.Request.Url.Segments.Length - 1];
				MenuSelected(Request.QueryString["mod"]);
				var ex = new BOCAR.SACI.Business.ExchangeManager();
				gvExchange.DataSource = ex.GetExchangePDF(string.Empty, string.Empty, string.Empty, dtOpR1.SelectedDate, dtOpR2.SelectedDate);
				gvExchange.DataBind();
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

	protected void menuReporte_MenuItemClick(object sender, MenuEventArgs e)
	{
		MenuSelected(util.GetActionMenu(menuReporte.SelectedItem.Value, false));
	}

	private void MenuSelected(string sAction)
	{
		try
		{
			switch (sAction)
			{
				case "repExchangeNote":
					RadMultiPage1.SelectedIndex = 0;
					break;
				case "repDocsReq":
					RadMultiPage1.SelectedIndex = 1;
					break;
				default:
					Response.Redirect("Reportes.aspx?mod=" + sAction, false);
					break;
			}
		}
		catch (ArgumentNullException ex)
		{
			Alert.Denegado(this.Page);
		}
	}

	#region PDF
	protected void imgPdf_Click(object sender, ImageClickEventArgs e)
	{
		string sIdExchange = ((ImageButton)sender).CommandArgument.ToString();
		Response.Redirect("Services/OnFly.ashx?ex=" + sIdExchange + "&path=" + Server.MapPath("img"), false);
	}

	protected void dtOpR1_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
	{
		dtOpR2.MinDate = dtOpR1.SelectedDate.Value;
		dtOpR2.Enabled = true;
	}

	protected void btnBusqueda_v1_Click(object sender, EventArgs e)
	{
		Busqueda();
	}

	private void Busqueda()
	{
		var ex = new BOCAR.SACI.Business.ExchangeManager();
		gvExchange.DataSource = ex.GetExchangePDF(txtOpPreFolio.Text, txtOpFolio.Text, cbActivate.Checked ? ddlClient.SelectedValue : string.Empty, dtOpR1.SelectedDate, dtOpR1.SelectedDate);
		gvExchange.DataBind();
	}

	protected void cbActivate_CheckedChanged(object sender, EventArgs e)
	{
		ddlClient.Enabled = cbActivate.Checked;
	}

	protected void gvExchange_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
	{
		Busqueda();
	}
	#endregion

	protected void gvRequerimientos_ItemCommand(object sender, GridCommandEventArgs e)
	{

	}

	protected void imgDetail_Click(object sender, ImageClickEventArgs e)
	{
		string sIdExchange = ((ImageButton)sender).CommandArgument.ToString();
		var swap = new ReportManager();
		gridReporte.DataSource = swap.GetExchangeDocsOp(int.Parse(sIdExchange));
		gridReporte.DataBind();
	}

	protected void gridReporte_ItemCommand(object source, GridCommandEventArgs e)
	{
		if (e.CommandName == "Download")
		{
			try
			{
				IDictionary itemValues = new Dictionary<object, object>();
				//Se toma el item del row
				var item = (Telerik.Web.UI.GridDataItem)e.Item;
				item.ExtractValues(itemValues);
				string ruta = string.Empty;
				HttpContext contexto = HttpContext.Current;
				if (util.DownloadRepOp(int.Parse(gridReporte.Items[item.ItemIndex]["Exchange"].Text), gridReporte.Items[item.ItemIndex]["Ruta"].Text, ref ruta))
					Response.Redirect(ruta, false);
				else
					Alert.Show("No se encuentra el archivo en la ruta especificada.", this.Page);
			}
			catch (Exception ex)
			{
				Alert.Show("No se encuentra el archivo en la ruta especificada o no hay forma de obtener la informacón asociada al archivo solicitado", this.Page);
			}
		}
	}
	protected void btnDocumentos_Click(object sender, EventArgs e)
	{
		var swap = new ReportManager();
		gvRequerimientos.DataSource = swap.GetExchangeDocsOp(txtPreFolio.Text, txtFolio.Text);
		gvRequerimientos.DataBind();
	}
}