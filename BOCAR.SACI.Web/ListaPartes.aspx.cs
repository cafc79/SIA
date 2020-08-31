using System;
using System.Web;
using System.Web.UI.WebControls;
using BOCAR.SACI.Data;
using BOCAR.SACI.Business;

public partial class ListaPartes : System.Web.UI.Page
{
	private Utilerias util;

	protected void Page_Load(object sender, EventArgs e)
	{
		util = new Utilerias();
		try
		{
			if (Request.QueryString["page"] == null)
					ViewState["UrlReference"] = "Solicitud.aspx";
				else
					ViewState["UrlReference"] = "ExchangeNote.aspx";
			if (Request.QueryString["ex"] == null)
				Response.Redirect(ViewState["UrlReference"].ToString() + "?mod=imAddReq");
			else
			{
				if (!Page.IsPostBack)
				{
					lblIdExchange.Text = Request.QueryString["ex"];
					util.LoadMenu(ViewState["UrlReference"].ToString(),
					              BOCAR.SACI.Business.SecurityManager.ObtenerUsuario(HttpContext.Current).IdRol,
					              ref menuSolicitud);
				}
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
	protected void menuSolicitud_MenuItemClick(object sender, MenuEventArgs e)
	{
		menuSelected();
	}

	private void menuSelected()
	{
		string destiny = string.Empty;
		if ((ViewState["UrlReference"] != null) && (ViewState["UrlReference"].ToString() == "ExchangeNote.aspx"))
			destiny = "&page=ExchangeNote";
		string sAction = util.GetActionMenu(menuSolicitud.SelectedItem.Value, false);
		if ((sAction == "imTiming") || (sAction == "imManAut"))
			Response.Redirect("Timming.aspx?ex=" + Request.QueryString["ex"] + "&mod=" + sAction + destiny);
		else if (sAction == "imQuote")
			Response.Redirect("Cotizacion.aspx?ex=" + lblIdExchange.Text);
		else if (sAction != "imPartList")
			Response.Redirect(ViewState["UrlReference"].ToString() + "?ex=" + Request.QueryString["ex"] + "&mod=" + sAction);
	}
	#endregion

	#region PartListExchange

	protected void btnCancelExchangePartList_Click(object sender, EventArgs e)
	{
		CleanControls();
	}

	protected void btnAddPartList_Click(object sender, EventArgs e)
	{
		var lstError = new errorCompositeType();
		try
		{
			util.GetActionMenu(menuSolicitud.SelectedItem.Value);
			String sDescription = txtDescriptionPartList.Text.Trim();
			String iNumber = txtNumberPartList.Text.Trim();
			string iNumberClient = txtNumberPartListClient.Text.Trim();
			Util.isRequired(sDescription, "Descripción");
			Util.isRequired(iNumber, "Numero");
			Util.isRequired(iNumberClient, "Numero");
			Util.validatePartList(iNumber, "No. de Parte");
			Util.validatePartList(iNumberClient, "No. de Parte Cliente");

			var rm = new PartListManager();
			const string iIdEntity = "0";
			if (rm.ExistPartListDuplicate(int.Parse(iIdEntity), iNumber, sDescription, iNumberClient))
			{
				util.ErroDisplay(3, "La Descripción o Número ya existe, no es posible duplicar registros.", ref lblMessage);
			}
			else
			{
				rm.AddPartList(iNumber, sDescription, iNumberClient);
				CleanControls();
				util.ErroDisplay(5, string.Empty, ref lblMessage);
				ddlPartListExchangePartList.DataBind();
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
			util.ErroDisplay(1, string.Empty, ref lblMessage);
		}
	}

	protected void btnAddPartList_Panel_Click(object sender, EventArgs e)
	{
		try
		{
			util.GetActionMenu(menuSolicitud.SelectedItem.Value);
			btnAddListPart.Visible = true;
			pnPartListAdd.Visible = true;
			txtDescriptionPartList.Focus();
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
	}

	protected void btnAddCancelPartList_Click(object sender, EventArgs e)
	{
		CleanControls();
	}

	protected void btnAddListPartExchange_Click(object sender, EventArgs e)
	{
		try
		{
			util.GetActionMenu(menuSolicitud.SelectedItem.Value);
			Util.isRequired(ddlPartListExchangeAffectation.SelectedValue, "Afectación");
			Util.isRequired(ddlPartListExchangePartList.SelectedValue, "Parte");

			var ple = new PartListExchangeCompositeType();
			var plem = new PartListExchangeManager();

			ple.iIdAffectation = int.Parse(ddlPartListExchangeAffectation.SelectedValue);
			ple.iIdPartList = int.Parse(ddlPartListExchangePartList.SelectedValue);
			ple.iIdExchange = int.Parse(lblIdExchange.Text);
			if (ple.iIdExchange == 0)
				util.ErroDisplay(3, "No ha elegido ningún folio.", ref lblMessage);
			else
			{
				if (plem.ExistPartListExchangeDuplicate(ple.iIdPartList, ple.iIdAffectation, ple.iIdExchange))
					util.ErroDisplay(3, "Ya existe la relación, no es posible duplicar.", ref lblMessage);
				else
				{
					if (ViewState["PartList"] == null)
						plem.AddPartListExchange(ple.iIdPartList, ple.iIdAffectation, ple.iIdExchange);
					else
					{
						int IdPartList = int.Parse(ViewState["PartList"].ToString());
						//plem.DeletePartListExchange(ple.iIdExchange, IdPartList);
						plem.UpdatePartListExchange(IdPartList, ple.iIdPartList, ple.iIdAffectation, ple.iIdExchange);
						ViewState["PartList"] = null;
					}
					gvPartListExchange.DataBind();
					util.ErroDisplay(5, string.Empty, ref lblMessage);
					CleanControls();
				}
			}
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
		catch (Exception ex)
		{
			util.ErroDisplay(1, string.Empty, ref lblMessage);
		}
	}

	protected void genericPartListExchange_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
	{
		if (e.CommandName == "deleteId")
		{
			var item = (Telerik.Web.UI.GridDataItem)e.Item;
			var plem = new PartListExchangeManager();
			int iIdExchange = int.Parse(gvPartListExchange.Items[item.ItemIndex]["iIdExchange"].Text);
			plem.DeletePartListExchange(iIdExchange, int.Parse(gvPartListExchange.Items[item.ItemIndex]["iIdPartList"].Text));
			gvPartListExchange.DataBind();
		}
		if (e.CommandName == "editId")
		{
			var item = (Telerik.Web.UI.GridDataItem)e.Item;
			gvPartListExchange.Items[item.ItemIndex].Selected = true;
			ddlPartListExchangePartList.Items[util.IndexCombo(ddlPartListExchangePartList, gvPartListExchange.Items[item.ItemIndex]["iIdPartList"].Text)].Selected = true;
			ddlPartListExchangeAffectation.Items[util.IndexCombo(ddlPartListExchangeAffectation, gvPartListExchange.Items[item.ItemIndex]["iIdAffectation"].Text)].Selected = true;
			ViewState["PartList"] = gvPartListExchange.Items[item.ItemIndex]["iIdPartListExchange"].Text;
		}
	}
	#endregion

	private void CleanControls()
	{
		lblMessage.Text = "";
		lblMessage.Visible = false;

		////TextBox
		txtDescriptionPartList.Text = "";
		txtNumberPartList.Text = "";
		txtNumberPartListClient.Text = "";
		////Botones
		btnAddListPart.Visible = false;
		//paneles add
		pnPartListAdd.Visible = false;
		////ddl
		ddlPartListExchangeAffectation.DataBind();
		ddlPartListExchangePartList.DataBind();
	}

	protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
	{

		ddlPartListExchangePartList.DataTextField = "sDesc" + ((RadioButtonList)sender).SelectedValue;
		ddlPartListExchangePartList.DataBind();
	}
}