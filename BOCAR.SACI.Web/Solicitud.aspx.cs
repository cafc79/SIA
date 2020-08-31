using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOCAR.SACI.Data;
using BOCAR.SACI.Business;
using Telerik.Web.UI;

public partial class Solicitud : System.Web.UI.Page
{
	private Utilerias util;
	private ExchangeCompositeType Exchange = new ExchangeCompositeType();

	protected void Page_Load(object sender, EventArgs e)
	{
		util = new Utilerias();
		wndRequerimiento.OpenerElementID = imbRequerimiento.ClientID;
		wndDocumentos.OpenerElementID = imbDocs.ClientID;
		try
		{
			if (!Page.IsPostBack)
			{
				util.LoadMenu(Master.Page.Request.Url.Segments[Master.Page.Request.Url.Segments.Length - 1],
											BOCAR.SACI.Business.SecurityManager.ObtenerUsuario(HttpContext.Current).IdRol, ref menuSolicitud);
				calLimite.SelectedDate = DateTime.Today;
				if (Request.QueryString["mod"] != null && Request.QueryString["ex"] != null)
				{
					selectedExchange(int.Parse(Request.QueryString["ex"]));
					wndRequerimiento.NavigateUrl = "Services/Requerimiento.aspx?ex=" + Request.QueryString["ex"] + "&mod=" + Master.Page.Request.Url.Segments[Master.Page.Request.Url.Segments.Length - 1];
					wndDocumentos.NavigateUrl = "Services/Soporte.aspx?ex=" + Request.QueryString["ex"];
					MenuSelected(Request.QueryString["mod"], int.Parse(Request.QueryString["ex"]));
					gvExchange.DataBind();
				}
				else
					MenuSelected(menuSolicitud.Items[0].Value, 0);
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
	private void UpdateExchange(int iIdExchange)
	{
		try
		{
			var em = new ExchangeManager();
			Exchange = em.getExchangeById(iIdExchange);
		}
		catch (Exception ex)
		{
			throw new Exception();
		}
	}

	protected void menuSolicitud_MenuItemClick(object sender, MenuEventArgs e)
	{
		CleanControls();
		pnSearch.Visible = true;
		BlockControls();
		MenuSelected(util.GetActionMenu(menuSolicitud.SelectedItem.Value, false), int.Parse(lblIdExchange.Text));
	}

	private void MenuSelected(string sAction, int iIdExchange)
	{
		lblIdExchange.Text = iIdExchange.ToString();
		try
		{
			util.GetValidStage(sAction, menuSolicitud);
			UpdateExchange(iIdExchange);
			switch (sAction)
			{
				case "imAddReq":
					Menu_Exchange("Alta de Requerimiento", iIdExchange);
					break;
				case "imPartList":
					Menu_PartList("Lista de Partes", iIdExchange);
					break;
				case "imIngAut":
					Menu_Autorization(sAction, iIdExchange);
					break;
				case "imReviewExchange":
					Menu_Autorization(sAction, iIdExchange);
					break;
				case "imTiming":
					Menu_Timming("Timing Inicial", iIdExchange);
					break;
				case "imSalesAut":
					Menu_Autorization(sAction, iIdExchange);
					break;
				case "imQuote":
					Menu_Quote("Cotización", iIdExchange);
					break;
				case "imAnalize":
					Menu_Analize("Confirmación de Requerimiento", iIdExchange);
					break;
				case "imDocuments":
					Menu_Documents("Documentos de Soporte", iIdExchange);
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
			MultiPage_Solicitud.SelectedIndex = index;
			return true;
		}
		else
		{
			util.ErroDisplay(3, "No se ha Seleccionado Ningún Prefolio", ref lblMessage);
			return false;
		}
	}

	private void Menu_Exchange(string title, int iIdExchange)
	{
		Menu_Generic(title, iIdExchange, 0);
		if (iIdExchange > 0)
			selectedExchange(iIdExchange);
	}

	private void Menu_PartList(string title, int iIdExchange)
	{
		if (iIdExchange > 0)
			Response.Redirect("ListaPartes.aspx?ex=" + iIdExchange);
		else
			util.ErroDisplay(3, "No se ha Seleccionado Ningún Prefolio", ref lblMessage);
	}

	private void Menu_Autorization(string sAction, int iIdExchange)
	{
		if (iIdExchange > 0)
			Response.Redirect("Autorizacion.aspx?ex=" + iIdExchange + "&mod=" + sAction);
		else
			util.ErroDisplay(3, "No se ha Seleccionado Ningún Prefolio", ref lblMessage);
	}

	private void Menu_Timming(string title, int iIdExchange)
	{
		if (iIdExchange > 0)
			Response.Redirect("Timming.aspx?mod=imTiming&ex=" + iIdExchange);
		else
			util.ErroDisplay(3, "No se ha Seleccionado Ningún Prefolio", ref lblMessage);
	}

	private void Menu_Quote(string title, int iIdExchange)
	{
		if (iIdExchange > 0)
			Response.Redirect("Cotizacion.aspx?ex=" + iIdExchange);
		else
			util.ErroDisplay(3, "No se ha Seleccionado Ningún Prefolio", ref lblMessage);
	}

	private void Menu_Analize(string title, int iIdExchange)
	{
		if (Menu_Generic(title, iIdExchange, 6))
		{
			if (string.IsNullOrEmpty(Exchange.sFolio) || Exchange.sFolio == "0")
			{
				pnGenerateFolio.Visible = true;
				pnFolio.Visible = false;
			}
			else
			{
				pnGenerateFolio.Visible = false;
				pnFolio.Visible = true;
				lblFolioGen.Text = Exchange.sFolio;
			}
		}
	}

	private void Menu_Documents(string title, int iIdExchange)
	{
		if (Menu_Generic(title, iIdExchange, 7))
			gvDocuments.DataBind();
	}
	#endregion

	#region Search
	protected void imbSerach_Click(object sender, ImageClickEventArgs e)
	{
		try
		{
			gvExchange.DataBind();
		}
		catch (ArgumentException ae)
		{
			util.ErroDisplay(3, ae.Message, ref lblMessage);
			lblMessage.Focus();
		}
		catch (Exception ex)
		{
			util.ErroDisplay(1, string.Empty, ref lblMessage);
		}
	}

	protected void imbSelectExchange_Click(object sender, ImageClickEventArgs e)
	{
		lblFolioGen.Text = string.Empty;
		int iIdExchange = int.Parse(((ImageButton)sender).CommandArgument.ToString());
		selectedExchange(iIdExchange);
		wndRequerimiento.NavigateUrl = "Services/Requerimiento.aspx?ex=" + iIdExchange + "&mod=" + Master.Page.Request.Url.Segments[Master.Page.Request.Url.Segments.Length - 1];
		wndDocumentos.NavigateUrl = "Services/Soporte.aspx?ex=" + lblIdExchange.Text;
		gvExchange.DataBind();
	}

	private void selectedExchange(int iIdExchange)
	{
		var ex = new ExchangeCompositeType();
		var em = new ExchangeManager();
		lblMessage.Text = string.Empty;
		try
		{
			ex = em.getExchangeById(iIdExchange);
			if (ex != null)
			{
				lblPrefolio.Text = ex.sFolioPre;
				lblIdExchange.Text = ex.iIdExchange.ToString();
				ddlExchange.SelectedValue = ex.iIdExchangeType.ToString();
				ddlPlant.SelectedValue = ex.iIdPlant.ToString();
				ddlPriority.SelectedValue = ex.iIdPriority.ToString();
				ddlClient.SelectedValue = ex.iIdClient.ToString();
				ddlSerie.SelectedValue = ex.iSerie.ToString();
				ddlEngeenerProduct_Asignacion(iIdExchange, ex.iProductEngener);
				txtAction.Text = ex.sMeasure;
				txtContact.Text = ex.sContact;
				txtDescription.Text = ex.sDescription;
				txtIssue.Text = ex.sIssue;
				if (ex.dLimitDate != null)
				calLimite.SelectedDate = (DateTime)ex.dLimitDate;
				txtLastFolio.Text = ex.sLastFolio;
				txtProyectPlataformDescription.Text = ex.sProyect;
				txtReason.Text = ex.sReason;
				BlockControls();
				CleanControls();
				if (ex.sExchangeType.ToString() == "Cambio")
				{
					pnDocuments.Visible = true;
					var adct = new affectationDocumentsCompositeType();
					var adm = new AffectationDocumentsManager();
					adct = adm.GetAffectationDocumentsByIdExchange(iIdExchange);
					chkAMEF.Checked = adct.bAMEF;
					chkCost.Checked = adct.bCost;
					chkDevices.Checked = adct.bDevices;
					chkDrawing.Checked = adct.bDrawing;
					chkEspecification.Checked = adct.bEspecifications;
					chkHOE.Checked = adct.bHOE;
					chkMedia.Checked = adct.bMedia;
					chkMold.Checked = adct.bMold;
					chkOthers.Checked = adct.bOthers;
					chkPlan.Checked = adct.bPlan;
					chkSAP.Checked = adct.bSAP;
					chkSing.Checked = adct.bSingOff;
				}
				else
					pnDocuments.Visible = false;
				lblPrefolio.Text = ex.sFolioPre;
				txtSrchPreFol.Text = ex.sFolioPre;
				lblPrefolio.Visible = true;
				lblPrefolioTitle.Visible = true;
			}
		}
		catch (Exception e)
		{
			throw new Exception(e.Message);
		}
	}

	protected void ddlEngeenerProduct_Asignacion(int iIdExchange, int Ingeniero)
	{
		sqlSPEmployedEP.SelectCommand = "sp_selectEmployedEP";
		sqlSPEmployedEP.DataBind();
		var swap = ddlEngeenerProduct.Items.FindItemByValue(Ingeniero.ToString());
		if (swap == null)
		{
			sqlSPEmployedEP.SelectCommand = "sp_selectEmployed";
			sqlSPEmployedEP.DataBind();
		}
		ddlEngeenerProduct.SelectedValue = Ingeniero.ToString();
	}

	protected void imgPdf_Click(object sender, ImageClickEventArgs e)
	{
		if (lblIdExchange.Text != string.Empty && lblIdExchange.Text != "0")
			Response.Redirect("Services/OnFly.ashx?ex=" + lblIdExchange.Text + "&path=" + Server.MapPath("img"), false);
		else
			util.ErroDisplay(3, "No se ha seleccionado un Prefolio", ref lblMessage);	
	}
	#endregion

	#region Exchange
	private void CamposRequeridos()
	{
		try
		{
			Util.isRequired(ddlExchange.SelectedValue, "Tipo de Cambio");
			Util.isRequired(ddlPriority.SelectedValue, "Prioridad");
			Util.isRequired(ddlSerie.SelectedValue, "Tipo");
			Util.isRequired(ddlPlant.SelectedValue, "Planta");
			Util.isRequired(ddlClient.SelectedValue, "Cliente");
			Util.isRequired(ddlEngeenerProduct.SelectedValue, "Ingeniero de Producto");
			Util.isRequired(txtProyectPlataformDescription.Text.Trim(), "Proyecto/Plataforma");
			Util.isRequired(txtDescription.Text.Trim(), "Descripción");
			Util.isRequired(txtIssue.Text.Trim(), "Problema");
			Util.isRequired(txtReason.Text.Trim(), "Motivo");
			Util.isRequired(txtAction.Text.Trim(), "Acción");
			Util.isRequired(txtContact.Text.Trim(), "Contacto");
		}
		catch (ArgumentException ex)
		{
			throw new ArgumentException(ex.Message);
		}
	}

	private affectationDocumentsCompositeType Afectacion()
	{
		var adct = new affectationDocumentsCompositeType
								{
									bAMEF = chkAMEF.Checked,
									bCost = chkCost.Checked,
									bDevices = chkDevices.Checked,
									bDrawing = chkDrawing.Checked,
									bEspecifications = chkEspecification.Checked,
									bHOE = chkHOE.Checked,
									bMedia = chkMedia.Checked,
									bMold = chkMold.Checked,
									bOthers = chkOthers.Checked,
									bPlan = chkPlan.Checked,
									bSAP = chkSAP.Checked,
									bSingOff = chkSing.Checked,
									iIdExchange = int.Parse(lblIdExchange.Text.ToString())
								};
		return adct;
	}

	private ExchangeCompositeType HeaderReq()
	{
		try
		{
			var ect = new ExchangeCompositeType();
			ect.iIdClient = int.Parse(ddlClient.SelectedValue);
			ect.iIdExchangeType = int.Parse(ddlExchange.SelectedValue);
			ect.iIdPlant = int.Parse(ddlPlant.SelectedValue);
			ect.iIdPriority = int.Parse(ddlPriority.SelectedValue); ;
			ect.iProductEngener = int.Parse(ddlEngeenerProduct.SelectedValue);
			ect.iSerie = int.Parse(ddlSerie.SelectedValue);

			ect.sContact = txtContact.Text.Trim();
			ect.sDescription = txtDescription.Text.Trim();
			ect.sIssue = txtIssue.Text.Trim();
			ect.sMeasure = txtAction.Text.Trim();
			ect.sProyect = txtProyectPlataformDescription.Text.Trim();
			ect.sReason = txtReason.Text.Trim();
			ect.dLimitDate = calLimite.SelectedDate.Value;
			ect.sLastFolio = txtLastFolio.Text.Trim();
			return ect;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	protected void btnGenetate_Click(object sender, EventArgs e)
	{
		try
		{
			util.GetActionMenu(menuSolicitud.SelectedItem.Value);
			lblMessage.Text = "";
			Util.validateDatesHomeEnd(calLimite.SelectedDate.ToString(), "Fecha Limite");
			CamposRequeridos();
			var em = new ExchangeManager();
			var ect = HeaderReq();
			ect.iStatus = 1;
			ect.sFolio = "0";
			ect.sFolioPre = DateTime.Now.Year.ToString() + String.Format("{0:00}", int.Parse(DateTime.Now.Month.ToString())) + String.Format("{0:0000}", em.GetNumberPrefolio());

			em.AddExchange(ect, false);
			var ectNow = em.getExchangeByPreFolioUnique(ect.sFolioPre);
			lblIdExchange.Text = ectNow.iIdExchange.ToString();

			if (ddlExchange.SelectedItem.Text.Contains("Cambio"))
			{
				var adm = new AffectationDocumentsManager();
				adm.AddAffectationDocuments(Afectacion());
			}
			BlockControls();
			btnClean.Visible = true;
			btnGenetate.Visible = false;
			lblPrefolio.Visible = true;
			lblPrefolioTitle.Visible = true;
			btnUpdateExchange_Documents.Visible = false;
			btnExchangeUpdate.Visible = true;
			lblPrefolio.Text = ectNow.sFolioPre;
			txtSrchPreFol.Text = ectNow.sFolioPre;
			gvExchange.DataBind();
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

	protected void btnUpdateExchange_Documents_Click(object sender, EventArgs e)
	{
		try
		{
			lblMessage.Text = "";
			util.GetActionMenu(menuSolicitud.SelectedItem.Value);
			CamposRequeridos();
			var ect = HeaderReq();
			var ectNow = new ExchangeCompositeType();
			var em = new ExchangeManager();
			ect = em.getExchangeById(int.Parse(lblIdExchange.Text.Trim()));
			ect.iStatus = 2;
			em.UpdateExchange(ect, ((RadButton)sender).ID);
			ectNow = em.getExchangeByPreFolioUnique(ect.sFolioPre);
			lblIdExchange.Text = ectNow.iIdExchange.ToString();

			if (ddlExchange.SelectedItem.Text.Contains("Cambio"))
			{
				var adm = new AffectationDocumentsManager();
				if (adm.GetCountAffectationDocumentsByIdExchange(int.Parse(lblIdExchange.Text.ToString())) > 0)
					adm.UpdateAffectationDocuments(Afectacion());
				else
					adm.AddAffectationDocuments(Afectacion());
			}
			BlockControls();
			btnClean.Visible = true;
			btnGenetate.Visible = false;
			lblPrefolio.Visible = true;
			lblPrefolioTitle.Visible = true;
			btnUpdateExchange_Documents.Visible = false;
			btnExchangeUpdate.Visible = true;
			lblPrefolio.Text = ectNow.sFolioPre;
			txtSrchPreFol.Text = ectNow.sFolioPre;
			gvExchange.DataBind();
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

	protected void ddlExchange_SelectedIndExchanged(object sender, EventArgs e)
	{
		pnDocuments.Visible = ddlExchange.SelectedItem.Text.Contains("Cambio");
	}

	private void Requerimiento()
	{
		try
		{
			util.GetValidStage("imAddReq", menuSolicitud);
			MultiPage_Solicitud.SelectedIndex = 0;
			util.GetActionMenu(menuSolicitud.SelectedItem.Value);
			CleanControls();
			EnabledControls();
			CleanControlsExchange();
			pnSearch.Visible = false;
		}
		catch (ArgumentNullException ane)
		{
			Alert.Permisos(this.Page);
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
	}

	private void ControlState(bool state)
	{
		ddlExchange.Enabled = state;
		ddlPriority.Enabled = state;
		ddlSerie.Enabled = state;
		ddlPlant.Enabled = state;
		ddlClient.Enabled = state;
		ddlEngeenerProduct.Enabled = state;

		txtLastFolio.Enabled = state;
		txtProyectPlataformDescription.Enabled = state;
		txtDescription.Enabled = state;
		txtIssue.Enabled = state;
		txtReason.Enabled = state;
		txtAction.Enabled = state;
		txtContact.Enabled = state;
		calLimite.Enabled = state;

		chkAMEF.Enabled = state;
		chkCost.Enabled = state;
		chkDevices.Enabled = state;
		chkDrawing.Enabled = state;
		chkEspecification.Enabled = state;
		chkHOE.Enabled = state;
		chkMedia.Enabled = state;
		chkMold.Enabled = state;
		chkOthers.Enabled = state;
		chkPlan.Enabled = state;
		chkSAP.Enabled = state;
		chkSing.Enabled = state;
	}

	private void BlockControls()
	{
		ControlState(false);
		btnGenetate.Visible = false;
		btnClean.Visible = true;
		btnUpdateExchange_Documents.Visible = false;
		btnExchangeUpdate.Visible = true;
	}

	private void EnabledControls()
	{
		ControlState(true);
	}

	protected void imbEchangeAdd_Click(object sender, ImageClickEventArgs e)
	{
		Requerimiento();
	}

	protected void btnClean_Click(object sender, EventArgs e)
	{
		Requerimiento();
	}

	protected void btnExchangeUpdate_Click(object sender, EventArgs e)
	{
		try
		{
			util.GetActionMenu(menuSolicitud.SelectedItem.Value);
			EnabledControls();
			btnExchangeUpdate.Visible = false;
			btnUpdateExchange_Documents.Visible = true;
			calLimite.Enabled = false;
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
	}
	#endregion

	#region Documentos
	protected void btnGrabar_Click(object sender, EventArgs e)
	{
		try
		{
			var efct = new ExchangeFileCompositeType();
			var em = new ExchangeFileManager();
			if (RadAsyncUpload1.UploadedFiles.Count > 0)
			{
				efct.sLabel = RadAsyncUpload1.UploadedFiles[0].FileName;
				efct.iTiype = 1;
				efct.iExchange = int.Parse(lblIdExchange.Text);
				efct.sURL = ConfigurationManager.AppSettings["URLArchivos"].ToString() + '\\' + efct.iExchange;
				var DIR = new DirectoryInfo(efct.sURL);
				if (!DIR.Exists)
					DIR.Create();
				RadAsyncUpload1.UploadedFiles[0].SaveAs(efct.sURL + "\\" + RadAsyncUpload1.UploadedFiles[0].FileName);
				em.AddExchangeFile(efct);
				util.ErroDisplay(5, string.Empty, ref lblMessage);
				gvDocuments.Rebind();
			}
			else
				Util.isRequired("", "Archivo ");
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

	protected void gvDocuments_ItemCommand(object sender, GridCommandEventArgs e)
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
				if (util.DownloadFile(gvDocuments.Items[item.ItemIndex]["iExchange"].Text, 1, gvDocuments.Items[item.ItemIndex]["sLabel"].Text, ref ruta))
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

	protected void imbDownload_Click(object sender, ImageClickEventArgs e)
	{
		Response.Redirect(((ImageButton)sender).CommandArgument.ToString());
	}
	#endregion

	#region Generar Folio
	protected void btnGenerateFolio_Analize_Click(object sender, EventArgs e)
	{
		try
		{
			util.GetActionMenu(menuSolicitud.SelectedItem.Value);
			UpdateExchange(int.Parse(lblIdExchange.Text));
			var em = new ExchangeManager();
			String sFolio = Exchange.sSerie.ToString().Substring(0, 1) + DateTime.Today.Year.ToString().Substring(2, 2) + Exchange.sExchangeType.ToString().Substring(0, 1) + String.Format("{0:0000}", em.GetNumberFolio());
			Exchange.sFolio = sFolio;
			Exchange.iStatus = 6;
			em.UpdateExchange(Exchange, ((RadButton)sender).ID);
			lblFolioGen.Text = Exchange.sFolio.ToString();
			pnGenerateFolio.Visible = false;
			pnFolio.Visible = true;
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
		catch (Exception ex)
		{
			util.ErroDisplay(1, ex.Message, ref lblMessage);
		}
	}
	#endregion

	#region Utils Solicitud
	private void CleanControls()
	{
		lblMessage.Text = "";
		lblMessage.Visible = false;
		sqlSPEmployedEP.SelectCommand = "sp_selectEmployedEP";
		sqlSPEmployedEP.DataBind();
	}

	private void CleanControlsExchange()
	{
		ddlExchange.DataBind();
		ddlPriority.DataBind();
		ddlSerie.DataBind();
		ddlPlant.DataBind();
		ddlClient.DataBind();
		ddlEngeenerProduct.DataBind();

		txtLastFolio.Text = "";
		txtProyectPlataformDescription.Text = "";
		txtDescription.Text = "";
		txtIssue.Text = "";
		txtReason.Text = "";
		txtAction.Text = "";
		txtContact.Text = "";
		txtSrchPreFol.Text = "";

		lblPrefolioTitle.Visible = false;
		lblPrefolio.Text = "";
		lblIdExchange.Text = "0";


		btnClean.Visible = false;
		btnGenetate.Visible = true;
		btnUpdateExchange_Documents.Visible = false;
		btnExchangeUpdate.Visible = false;

		gvExchange.DataSourceID = "sqlDS";
		gvExchange.DataBind();
	}

	private void CleanControls(Panel contenedor)
	{
		lblMessage.Text = string.Empty;
		for (int i = 0; i <= contenedor.Controls.Count - 1; i++)
		{
			if (contenedor.Controls[i].GetType().Name == "TextBox")
				((TextBox)contenedor.Controls[i]).Text = string.Empty;
		}
	}
	#endregion
	
}