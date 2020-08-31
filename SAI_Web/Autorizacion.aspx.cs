using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DS.SAI.Business;
using DS.SAI.Data;

public partial class Autorizacion : System.Web.UI.Page
{
	private Utilerias util;
    private System.Web.UI.WebControls.Menu mpMenu;

	protected void Page_Load(object sender, EventArgs e)
	{
		util = new Utilerias();
		wndRequerimiento.OpenerElementID = imbRequerimiento.ClientID;
		wndDocumentos.OpenerElementID = imbDocs.ClientID;
        mpMenu = (System.Web.UI.WebControls.Menu)Master.FindControl("ChildrenMenu");
        mpMenu.MenuItemClick += new MenuEventHandler(menuSolicitud_MenuItemClick);
		try
		{
			if (Request.QueryString["page"] == null)
				ViewState["UrlReference"] = "Solicitud.aspx";
			else
				ViewState["UrlReference"] = "ExchangeNote.aspx";
			if (!Page.IsPostBack)
			{
				lblIdExchange.Text = Request.QueryString["ex"];
				string url = ViewState["UrlReference"].ToString().Substring(0, ViewState["UrlReference"].ToString().IndexOf('.'));
				wndRequerimiento.NavigateUrl = "Mobile/Requerimiento.aspx?ex=" + Request.QueryString["ex"] + "&mod=" + url;
				wndDocumentos.NavigateUrl = "Services/Soporte.aspx?ex=" + Request.QueryString["ex"] + "&mod=" + url;
				MenuSelected(Request.QueryString["mod"], int.Parse(Request.QueryString["ex"]));
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

	protected void imgPdf_Click(object sender, ImageClickEventArgs e)
	{
		if (lblIdExchange.Text != string.Empty && lblIdExchange.Text != "0")
			Response.Redirect("Services/OnFly.ashx?ex=" + lblIdExchange.Text + "&path=" + Server.MapPath("img"), false);
		else
			util.ErroDisplay(3, "No se ha seleccionado un Prefolio", ref lblMessage);
	}

	#region Menu

	protected void menuSolicitud_MenuItemClick(object sender, MenuEventArgs e)
	{
		MenuSelected(util.GetActionMenu(mpMenu.SelectedItem.Value, false), int.Parse(lblIdExchange.Text));
	}

	private void MenuSelected(string sAction, int iIdExchange)
	{
		lblIdExchange.Text = iIdExchange.ToString();
		try
		{
			util.GetValidStage(sAction, mpMenu);
			switch (sAction)
			{
				case "imPartList":
					Menu_PartList("Lista de Partes", iIdExchange);
					break;
				case "imIngAut":
					Menu_EngineerAutorization("Autorización de Ingenieria", iIdExchange);
					break;
				case "imReviewExchange":
					Menu_ReviewExchange("Evaluación de Requerimiento", iIdExchange);
					break;
				case "imTiming":
					Menu_Timming(sAction, iIdExchange);
					break;
				case "imManAut":
					Menu_Timming(sAction, iIdExchange);
					break;
				case "imQuote":
					Menu_Quote(iIdExchange);
					break;
				case "imSalesAut":
					Menu_SalesAutorization("Autorizacion de Ventas", iIdExchange);
					break;
				default:
					Menu_Exchange(sAction, iIdExchange);
					break;
			}
		}
		catch (ArgumentNullException ex)
		{
			Alert.Denegado(this.Page);
		}
	}

	private bool Menu_Generic(string title, int iIdExchange, int index)
	{
		lblTitle.Text = title;
		if (iIdExchange > 0)
		{
			MultiPage_Autorizacion.SelectedIndex = index;
			return true;
		}
		util.ErroDisplay(3, "No se ha Seleccionado Ningún Prefolio", ref lblMessage);
		return false;
	}

	private void Menu_EngineerAutorization(string title, int iIdExchange)
	{
		lblTitle.Text = title;
		if (Menu_Generic(title, iIdExchange, 0))
			AutorizacionIngenieria(iIdExchange);
	}

	private void Menu_ReviewExchange(string title, int iIdExchange)
	{
		lblTitle.Text = title;
		if (Menu_Generic(title, iIdExchange, 1))
			ReviewPartList();
	}

	private void Menu_SalesAutorization(string title, int iIdExchange)
	{
		lblTitle.Text = title;
		if (Menu_Generic(title, iIdExchange, 2))
			SalesAutorization();
	}

	private void Menu_PartList(string title, int iIdExchange)
	{
		if (iIdExchange > 0)
		{
			string page = string.Empty;
			if (Request.QueryString["page"] == "Exchange")
				page = "&page=Exchange";
			Response.Redirect("ListaPartes.aspx?ex=" + iIdExchange + page);
		}
		else
			util.ErroDisplay(3, "No se ha Seleccionado Ningún Prefolio", ref lblMessage);
	}

	private void Menu_Timming(string sAction, int iIdExchange)
	{
		if (iIdExchange > 0)
		{
			string page = string.Empty;
			if (Request.QueryString["page"] == "Exchange")
				page = "&page=Exchange";
			Response.Redirect("Timming.aspx?mod=" + sAction + "&ex=" + iIdExchange + page);
		}
		else
			util.ErroDisplay(3, "No se ha Seleccionado Ningún Prefolio", ref lblMessage);
	}

	private void Menu_Quote(int iIdExchange)
	{
		if (iIdExchange > 0)
			Response.Redirect("Cotizacion.aspx?ex=" + iIdExchange);
		else
			util.ErroDisplay(3, "No se ha Seleccionado Ningún Prefolio", ref lblMessage);
	}

	private void Menu_Exchange(string sAction, int iIdExchange)
	{
		if (iIdExchange > 0)
		{
			string page = string.Empty;
			if (Request.QueryString["page"] == "Exchange")
				page = "&page=Exchange";
			Response.Redirect(ViewState["UrlReference"] + "?mod=" + sAction + "&ex=" + iIdExchange + page);
		}
		else
			util.ErroDisplay(3, "No se ha Seleccionado Ningún Prefolio", ref lblMessage);
	}
	
	#endregion

	#region Autorizacion Ingenieria

	private byte ConfigAutorization(ExchangeAutorizationCompositeType eact)
	{
		//No es Gerente, Ingeniero
		int user = util.GetUserId();
		if (user != eact.iIngeniero && user != eact.iGerente)
		{
			txtObsEngManager.ReadOnly = true;
			txtObsEngProduct.ReadOnly = true;
			return 0;
		}
			//El usuario es el ingeniero y el gerente
		else if (user == eact.iIngeniero && user == eact.iGerente)
		{
			txtObsEngManager.ReadOnly = false;
			ddlAdminAutorization.Enabled = true;
			ddlEngenerAutorization.Enabled = true;
			txtObsEngProduct.ReadOnly = false;
			return 1;
		}
			//El usuario es gerente, pero no es ingeniero 
		else if (user != eact.iIngeniero && user == eact.iGerente)
		{
			txtObsEngManager.ReadOnly = false;
			ddlAdminAutorization.Enabled = true;
			ddlEngenerAutorization.Enabled = false;
			txtObsEngProduct.ReadOnly = true;
			return 2;
		}
			//El usuario es ingeniero pero no gerente
		else if (user == eact.iIngeniero && user != eact.iGerente)
		{
			txtObsEngManager.ReadOnly = true;
			ddlAdminAutorization.Enabled = false;
			ddlEngenerAutorization.Enabled = true;
			txtObsEngProduct.ReadOnly = false;
			return 3;
		}
		return 7;
	}

	private void AutorizacionIngenieria(int iIdExchange)
	{
		var eam = new ExchangeAutorizationManager();
		var infor = eam.GetInforAutorizacionIng(iIdExchange);
		lblGerenteIngenieria.ToolTip = infor[1];
		lblEngenerAutorization.ToolTip = infor[0];
		var eact = eam.getExchangeAutorizationById(iIdExchange);
		if (eact.iIdExchangeAutorization > 0)
		{
			if (ddlAdminAutorization.Items.FindItemByValue(eact.iIdReviewTypeAdm.ToString()) != null)
				ddlAdminAutorization.SelectedValue = eact.iIdReviewTypeAdm.ToString();
			if (ddlEngenerAutorization.Items.FindItemByValue(eact.iIdReviewTypeEng.ToString()) != null)
				ddlEngenerAutorization.SelectedValue = eact.iIdReviewTypeEng.ToString();
			txtObsEngProduct.Text = eact.sEngObsevations;
			txtObsEngManager.Text = eact.sObsevations;
			txtObsEngManager.ReadOnly = true;
			txtObsEngProduct.ReadOnly = true;
			btnExchangeAutorization.Visible = false;
			btnUpdateAutorization.Visible = true;
		}
		else
		{
			ConfigAutorization(eact);
			btnExchangeAutorization.Visible = true;
			btnUpdateAutorization.Visible = false;
		}
	}

	protected void btnExchangeAutorization_Click(object sender, EventArgs e)
	{
		try
		{
			util.GetActionMenu(mpMenu.SelectedItem.Value);
			var eam = new ExchangeAutorizationManager();
			int vUser = util.GetUserId();
			var eact = eam.getExchangeAutorizationById(int.Parse(lblIdExchange.Text));
			int caso = ConfigAutorization(eact);
			switch (caso)
			{
				case 0:
					throw new AccessViolationException();
				case 1:
					if (string.IsNullOrEmpty(txtObsEngManager.Text.Trim()) || string.IsNullOrEmpty(txtObsEngProduct.Text.Trim()))
						throw new ArgumentException("Las observaciones son requeridas.");
					else
					{
						eact.iIdReviewTypeAdm = int.Parse(ddlAdminAutorization.SelectedValue);
						eact.sObsevations = txtObsEngManager.Text.Trim();
						eact.iIngenieroSup = vUser;
						eact.iIdReviewTypeEng = int.Parse(ddlEngenerAutorization.SelectedValue);
						eact.sEngObsevations = txtObsEngProduct.Text.Trim();
						eact.iIngeniero = vUser;
					}
					break;
				case 2:
					Util.isRequired(txtObsEngManager.Text, "Observaciones del Gerente de Ingenieria");
					eact.iIdReviewTypeAdm = int.Parse(ddlAdminAutorization.SelectedValue);
					eact.sObsevations = txtObsEngManager.Text.Trim();
					eact.iIngenieroSup = vUser;
					break;
				case 3:
					Util.isRequired(txtObsEngProduct.Text, "Observaciones del Ingeniero de Producto");
					eact.iIdReviewTypeEng = int.Parse(ddlEngenerAutorization.SelectedValue);
					eact.sEngObsevations = txtObsEngProduct.Text.Trim();
					eact.iIngeniero = vUser;
					break;
			}
			if (eact.iIdExchangeAutorization > 0)
				eam.UpdateExchangeAutorization(eact);
			else
				eam.AddExchangeAutorization(eact);
			btnExchangeAutorization.Visible = false;
			btnUpdateAutorization.Visible = true;
			util.ErroDisplay(5, string.Empty, ref lblMessage);
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

	protected void btnUpdate_Click(object sender, EventArgs e)
	{
		try
		{
			util.GetActionMenu(mpMenu.SelectedItem.Value);
			var eam = new ExchangeAutorizationManager();
			var eact = eam.getExchangeAutorizationById(int.Parse(lblIdExchange.Text));
			ConfigAutorization(eact);
			btnUpdateAutorization.Visible = false;
			btnExchangeAutorization.Visible = true;
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
	}

	#endregion

	#region Revision

	protected void imbSelectReviewExchange_Click(object sender, ImageClickEventArgs e)
	{
		var erm = new ExchangeReviewManager();
		var rect = new ExchangeReviewCompositeType
		           	{
		           		iIdReviewExchange = Int32.Parse(((ImageButton) sender).CommandArgument.ToString()),
		           		iIdUser = util.GetUserId()
		           	};
		pnReviewExchangeAdd.Visible = true;
		ddlReviewExchangeReview.SelectedValue =
			erm.getExchangeReviewByIdReviewExchange(rect.iIdReviewExchange).iIdReviewType.ToString();
		txtReviewExchangeObs.Text = erm.getExchangeReviewByIdReviewExchange(rect.iIdReviewExchange).sDescription.ToString();

		btnUpdateReviewExchange.Visible = true;
		btnAddExchangeReview.Visible = false;
		lblReviewExchange.Text = rect.iIdReviewExchange.ToString();
		txtReviewExchangeObs.Enabled = true;
		ddlReviewExchangeReview.Enabled = true;
	}

	protected void btnUpdateReviewExchange_Click(object sender, EventArgs e)
	{
		try
		{
			util.GetActionMenu(mpMenu.SelectedItem.Value);
			var erm = new ExchangeReviewManager();
			var rect = new ExchangeReviewCompositeType();
			Util.isRequired(ddlReviewExchangeReview.SelectedValue.ToString(), "Evaluación");
			Util.isRequired(txtReviewExchangeObs.Text.Trim().ToString(), "Observación");
			rect.iIdReviewExchange = int.Parse(lblReviewExchange.Text.Trim());
			rect.iIdReviewType = int.Parse(ddlReviewExchangeReview.SelectedValue.ToString());
			rect.sDescription = txtReviewExchangeObs.Text.Trim();

			erm.updateExchangeReview(rect);
			util.ErroDisplay(6, string.Empty, ref lblMessage);
			btnAddExchangeReview.Visible = false;
			btnUpdateReviewExchange.Visible = false;
			ddlReviewExchangeReview.Enabled = false;
			txtReviewExchangeObs.Enabled = false;
			gvExchangeReview.DataSourceID = null;
			gvExchangeReview.DataSource = erm.getExchangeReviewById(int.Parse(lblIdExchange.Text.Trim().ToString()));
			gvExchangeReview.DataBind();
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

	protected void btnAddExchangeReview_Click(object sender, EventArgs e)
	{
		try
		{
			util.GetActionMenu(mpMenu.SelectedItem.Value);
			Util.isRequired(ddlReviewExchangeReview.SelectedValue, "Evaluación");
			Util.isRequired(txtReviewExchangeObs.Text.Trim(), "Observación");
			var erct = new ExchangeReviewCompositeType();
			var erm = new ExchangeReviewManager();

			erct.iIdUser = util.GetUserId();
			erct.iIdExchange = int.Parse(lblIdExchange.Text.Trim().ToString());
			erct.iIdReviewType = int.Parse(ddlReviewExchangeReview.SelectedValue.ToString());
			Util.isRequired(txtReviewExchangeObs.Text.Trim(), "Observaciones");
			erct.sDescription = txtReviewExchangeObs.Text.Trim();
			erm.insertExchangeReview(erct);
			util.ErroDisplay(5, string.Empty, ref lblMessage);
			btnAddExchangeReview.Visible = false;
			ddlReviewExchangeReview.Enabled = false;
			txtReviewExchangeObs.Enabled = false;
			gvExchangeReview.DataSourceID = null;
			gvExchangeReview.DataSource = erm.getExchangeReviewById(int.Parse(lblIdExchange.Text.Trim().ToString()));
			gvExchangeReview.DataBind();
			btnUpdateAutorization.Visible = true;
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

	private void ReviewPartList()
	{
		int iIdUser, iIdExchange;
		var erm = new ExchangeReviewManager();
		iIdUser = util.GetUserId(); // int.Parse(Session["IdUsr"].ToString());
		iIdExchange = int.Parse(lblIdExchange.Text.ToString());
		pnReviewExchangeAdd.Visible = true;
		if (erm.getCountExchangeReviewById(iIdExchange) > 0)
		{
			gvExchangeReview.DataSourceID = null;
			gvExchangeReview.DataSource = erm.getExchangeReviewById(iIdExchange);
			gvExchangeReview.DataBind();
		}
		if (erm.getCountExchangeReviewById(iIdExchange, iIdUser) > 0)
		{
			var erct = erm.getExchangeReviewById(iIdExchange, iIdUser);
			ddlReviewExchangeReview.SelectedValue = erct.iIdReviewType.ToString();
			txtReviewExchangeObs.Text = erct.sDescription.ToString();
			ddlReviewExchangeReview.Enabled = false;
			txtReviewExchangeObs.Enabled = false;
			btnAddExchangeReview.Visible = false;
		}
		else
		{
			ddlReviewExchangeReview.Enabled = true;
			txtReviewExchangeObs.Enabled = true;
			btnAddExchangeReview.Visible = true;
		}
	}

	#endregion

	private void SalesAutorization()
	{
		var sa = new SalesAutorizationManager();
		var registro = sa.GetSalesAutorization(int.Parse(Request.QueryString["ex"]));
		ddlSalesAutorization.SelectedValue = registro.ItemArray[0].ToString();
		txtSalesAutorization.Text = registro.ItemArray[1].ToString();
		if (txtSalesAutorization.Text == string.Empty) return;
		SalesOut();
	}

	private void SalesOut()
	{
		ddlSalesAutorization.Enabled = false;
		txtSalesAutorization.Enabled = false;
		btnSalesAceptar.Enabled = false;
		btnSalesCancelar.Enabled = false;
	}

	protected void btnSalesAceptar_Click(object sender, EventArgs e)
	{
		var sa = new SalesAutorizationManager();
		sa.Insert_SalesAutorization(int.Parse(Request.QueryString["ex"]), util.GetEmpleadoId(), util.GetUserId(), int.Parse(ddlSalesAutorization.SelectedValue), txtSalesAutorization.Text);
		SalesOut();
	}

	protected void btnSalesCancelar_Click(object sender, EventArgs e)
	{
		txtSalesAutorization.Text = string.Empty;
	}
}