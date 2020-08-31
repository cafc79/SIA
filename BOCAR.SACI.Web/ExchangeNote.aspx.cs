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

public partial class ExchangeNote : System.Web.UI.Page
{
	private Utilerias util;

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
				calLimitDate.SelectedDate = DateTime.Today;
				calAplicationDate.SelectedDate = DateTime.Today;
				if (Request.QueryString["mod"] != null && Request.QueryString["ex"] != null)
				{
					wndRequerimiento.NavigateUrl = "Services/Requerimiento.aspx?ex=" + Request.QueryString["ex"] + "&mod=ExchangeNote";
					wndDocumentos.NavigateUrl = "Services/Soporte.aspx?ex=" + Request.QueryString["ex"];
					selectedExchange(int.Parse(Request.QueryString["ex"]));
					MenuSelected(Request.QueryString["mod"], int.Parse(Request.QueryString["ex"]));
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
	protected void menuSolicitud_MenuItemClick(object sender, MenuEventArgs e)
	{
		CleanControls();
		int iIdExchange = int.Parse(lblIdExchange.Text.ToString());
		BlockControls();
		MenuSelected(util.GetActionMenu(menuSolicitud.SelectedItem.Value, false), iIdExchange);
	}

	private void MenuSelected(string sAction, int iIdExchange)
	{
		try
		{
			util.GetValidStage(sAction, menuSolicitud);
			switch (sAction)
			{
				case "imAddReq":
					Menu_Alta("Alta de Cambio", iIdExchange);
					break;
				case "imPartList":
					Menu_PartList("Lista de Partes", iIdExchange);
					break;
				case "imIngAut":
					Menu_Autorization(sAction, "Autorización de Ingenieria", iIdExchange);
					break;
				case "imReviewExchange":
					Menu_Autorization(sAction, "Evaluación de Requerimiento", iIdExchange);
					break;
				case "imTiming":
					Menu_Timming("Timing Inicial", iIdExchange, "imTiming");
					break;
				case "imManAut":
					Menu_Timming("Autorización de Gerencias", iIdExchange, "imManAut");
					break;
				case "imTimingFinal":
					Menu_TimmingFinal("Timing Final", iIdExchange);
					break;
				case "imDocuments":
					Menu_Documentos("Documentos", iIdExchange);
					break;
				case "imAnalize":
					Menu_Confirmacion("Confirmación", iIdExchange);
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
			MultiPage_Aviso.SelectedIndex = index;
			return true;
		}
		util.ErroDisplay(3, "No se ha Seleccionado Ningún Prefolio", ref lblMessage);
		return false;
	}

	private void Menu_Alta(string title, int iIdExchange)
	{
		Menu_Generic(title, iIdExchange, 0);
		if (iIdExchange > 0)
			selectedExchange(iIdExchange);
	}

	private void Menu_PartList(string title, int iIdExchange)
	{
		if (Menu_Generic(title, iIdExchange, 1))
			Response.Redirect("ListaPartes.aspx?ex=" + iIdExchange + "&page=ExchangeNote");
	}

	private void Menu_Autorization(string sAction, string sTitle, int iIdExchange)
	{
		if (iIdExchange > 0)
			Response.Redirect("Autorizacion.aspx?ex=" + iIdExchange + "&mod=" + sAction + "&page=Exchange");
		else
			util.ErroDisplay(3, "No se ha Seleccionado Ningún Prefolio", ref lblMessage);
	}

	private void Menu_Timming(string title, int iIdExchange, string modulo)
	{
		if (iIdExchange > 0)
			Response.Redirect("Timming.aspx?ex=" + iIdExchange + "&page=ExchangeNote&mod=" + modulo);
		else
			Menu_Generic(title, iIdExchange, 4);
	}

	private void Menu_TimmingFinal(string title, int iIdExchange)
	{
		if (Menu_Generic(title, iIdExchange, 5))
		{
			//var em = new ExchangeManager();
			//var ex = em.getExchangeById(iIdExchange);
			gvTimming.DataBind();
			pnTimingFinal.Visible = true;
		}
	}

	private void Menu_Quote(string title, int iIdExchange)
	{
		ddlNoPartCot.DataBind();
		if (Menu_Generic(title, iIdExchange, 0))
			Quote();
	}

	private void Menu_Confirmacion(string title, int iIdExchange)
	{
		if (Menu_Generic(title, iIdExchange, 7))
		{
			var ect = new ExchangeCompositeType();
			var em = new ExchangeManager();
			pnAnalize.Visible = true;
			calAplicationDate.MinDate = DateTime.Now;
			calAplicationDate.SelectedDate = DateTime.Now;
			ect = em.getExchangeById(int.Parse(lblIdExchange.Text.ToString()));
			if (ect.dAplicationDate == null || ect.dAplicationDate.ToString() == "" || ect.dAplicationDate.ToString() == "0" || ect.dAplicationDate.ToString().Substring(0, 10) == "01/01/0001")
			{
				pnGenerateFolio.Visible = true;
				pnFolio.Visible = false;
			}
			else
			{
				pnGenerateFolio.Visible = false;
				pnFolio.Visible = true;
				lblFolioGen.Text = ((DateTime)ect.dAplicationDate).ToShortDateString();
			}
		}
	}

	private void Menu_Documentos(string title, int iIdExchange)
	{
		Menu_Generic(title, iIdExchange, 8);
	}

	private void Quote()
	{
		if (ddlNoPartCot.Items.Count > 0)
		{
			pnQuote.Visible = true;
			pnQuoteNon.Visible = false;

			var plct = new PartListCompositeType();
			var plm = new PartListManager();

			var ect = new ExchangeCompositeType();
			var em = new ExchangeManager();

			plct = plm.getPartListById(int.Parse(ddlNoPartCot.SelectedValue.ToString()));
			ect = em.getExchangeById(int.Parse(lblIdExchange.Text));

			lblNoPartC.Text = plct.iNumber.ToString();
			lblNoPartClientC.Text = plct.iNumberClient.ToString();

			lblProyectc.Text = ect.sProyect.ToString();
			lblPartList.Text = plct.iIdPart.ToString();
			lblDescriptionC.Text = "Descripcion del Cambio: " + ect.sDescription.ToString();
			ddlAfectationCot.DataBind();
			calculate();
		}
		else
		{
			pnQuote.Visible = false;
			pnQuoteNon.Visible = true;
		}
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
		}
		catch (Exception ex)
		{
			util.ErroDisplay(1, ex.Message, ref lblMessage);
		}
	}

	protected void imbSelectExchange_Click(object sender, ImageClickEventArgs e)
	{
		lblFolioGen.Text = string.Empty;
		int iIdExchange = int.Parse(((ImageButton)sender).CommandArgument.ToString());
		selectedExchange(iIdExchange);
		wndRequerimiento.NavigateUrl = "Services/Requerimiento.aspx?ex=" + iIdExchange.ToString() + "&mod=ExchangeNote";
		wndDocumentos.NavigateUrl = "Services/Soporte.aspx?ex=" + iIdExchange.ToString();
		gvExchange.DataBind();
	}

	private void selectedExchange(int iIdExchange)
	{
		var ex = new ExchangeCompositeType();
		var em = new ExchangeManager();
		ViewState["Exchange"] = iIdExchange;
		ex = em.getExchangeById(iIdExchange);
		if (ex != null)
		{
			lblPrefolio.Text = ex.sFolio;
			lblIdExchange.Text = ex.iIdExchange.ToString();

			try
			{
				ddlExchange.SelectedValue = ex.iIdExchangeType.ToString();
				ddlPlant.SelectedValue = ex.iIdPlant.ToString();
				ddlPriority.SelectedValue = ex.iIdPriority.ToString();
				ddlClient.SelectedValue = ex.iIdClient.ToString();
				ddlSerie.SelectedValue = ex.iSerie.ToString();
				ddlEngeenerProduct_Asignacion(iIdExchange, ex.iProductEngener);
			}
			catch(Exception e)
			{
				Response.Redirect("/Error/PageError.aspx?ex=" + iIdExchange + "er=ddl", true);
			}
			txtAction.Text = ex.sMeasure;
			txtContact.Text = ex.sContact;
			txtDescription.Text = ex.sDescription;
			txtIssue.Text = ex.sIssue;
			try
			{
				calLimitDate.SelectedDate = ex.dInitChange as DateTime?;
			}
			catch (Exception e)
			{
				calLimitDate.SelectedDate = null;
			}
			txtLastFolio.Text = ex.sLastFolio;
			txtProyectPlataformDescription.Text = ex.sProyect;
			txtReason.Text = ex.sReason;

			BlockControls();

			CleanControls();

			if (ex.sExchangeType.Contains("Cambio"))
			{
				pnDocuments.Visible = true;
				var adm = new AffectationDocumentsManager();
				var adct = adm.GetAffectationDocumentsByIdExchange(iIdExchange);
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
			lblPrefolio.Text = ex.sFolio;
			txtSrchPreFol.Text = ex.sFolio;
			lblPrefolio.Visible = true;
			lblPrefolioTitle.Visible = true;
		}
		else
			CleanControlsExchange();
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
			util.ErroDisplay(3, "No se ha seleccionado un Folio", ref lblMessage);	
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

		for (int i = 0; i <= Page.Controls[0].Controls[3].Controls[7].Controls[13].Controls[0].Controls.Count - 1; i++)
		{
			if (Page.Controls[0].Controls[3].Controls[7].Controls[13].Controls[0].Controls[i].GetType().Name == "RadTextBox")
				((RadTextBox)Page.Controls[0].Controls[3].Controls[7].Controls[13].Controls[0].Controls[i]).Text = string.Empty;
		}
		for (int i = 0; i <= Page.Controls[0].Controls[3].Controls[7].Controls[13].Controls[0].Controls[61].Controls.Count - 1; i++)
		{
			if (Page.Controls[0].Controls[3].Controls[7].Controls[13].Controls[0].Controls[61].Controls[i].GetType().Name == "CheckBox")
				((CheckBox)Page.Controls[0].Controls[3].Controls[7].Controls[13].Controls[0].Controls[61].Controls[i]).Checked = false;
		}
		
		lblPrefolioTitle.Visible = false;
		lblPrefolio.Text = "";
		lblIdExchange.Text = "0";

		btnClean.Visible = false;
		btnGenetate.Visible = true;

		btnUpdateExchangeOk.Visible = false;
		btnExchangeUpdate.Visible = false;
		gvExchange.DataBind();
	}
	#endregion

	#region Alta de Requerimiento
	private void CamposRequeridos()
	{
		try
		{
			Util.isRequired(ddlExchange.SelectedValue, "Tipo de Cambio");
			Util.isRequired(ddlPriority.SelectedValue, "Prioridad");
			Util.isRequired(ddlSerie.SelectedValue, "Tipo");
			Util.isRequired(ddlPlant.SelectedValue, "Planta");
			Util.isRequired(ddlClient.SelectedValue, "Cliente");
			Util.isRequired(txtProyectPlataformDescription.Text.Trim(), "Proyecto/Plataforma");
			Util.isRequired(txtDescription.Text.Trim(), "Descripción");
			Util.isRequired(txtIssue.Text.Trim(), "Problema");
			Util.isRequired(txtReason.Text.Trim(), "Motivo");
			Util.isRequired(txtAction.Text.Trim(), "Acción");
			Util.isRequired(ddlEngeenerProduct.SelectedValue, "Ingeniero de Producto");
			Util.isRequired(txtContact.Text.Trim(), "Contacto");
		}
		catch (ArgumentException ex)
		{
			throw new ArgumentException(ex.Message);
		}
	}

	private void AddDocumentosAfectados()
	{
		if (ddlExchange.SelectedItem.Text.Contains("Cambio"))
		{
			var adct = new affectationDocumentsCompositeType();
			var adm = new AffectationDocumentsManager();
			adct.bAMEF = chkAMEF.Checked;
			adct.bCost = chkCost.Checked;
			adct.bDevices = chkDevices.Checked;
			adct.bDrawing = chkDrawing.Checked;
			adct.bEspecifications = chkEspecification.Checked;
			adct.bHOE = chkHOE.Checked;
			adct.bMedia = chkMedia.Checked;
			adct.bMold = chkMold.Checked;
			adct.bOthers = chkOthers.Checked;
			adct.bPlan = chkPlan.Checked;
			adct.bSAP = chkSAP.Checked;
			adct.bSingOff = chkSing.Checked;
			adct.iIdExchange = int.Parse(lblIdExchange.Text.ToString());
			try
			{
				if (adm.GetCountAffectationDocumentsByIdExchange(adct.iIdExchange) > 0)
					adm.UpdateAffectationDocuments(adct);
				else
					adm.AddAffectationDocuments(adct);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}

	private void HeaderReq(ref ExchangeCompositeType ect, bool bGenerate)
	{
		try
		{
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
			ect.dLimitDate = calLimitDate.SelectedDate.Value;
			ect.sLastFolio = txtLastFolio.Text.Trim();

			if (bGenerate)
			{
				ect.iStatus = 6;
				var em = new ExchangeManager();
				//SITI - CAFC 24102011 Corrección para generar el folio acorde a la letra inicial
				String sFolio = ddlSerie.SelectedItem.Text.Substring(0, 1) + DateTime.Today.Year.ToString().Substring(2, 2) +
												ddlExchange.SelectedItem.Text.Substring(0, 1) + String.Format("{0:0000}", em.GetNumberFolio());
				ect.sFolio = sFolio;
				ect.sFolioPre = "0";
			}
			else
				ect.iStatus = 2;
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
			Util.validateDatesHomeEnd(calLimitDate.SelectedDate.ToString(), "Fecha Limite");
			CamposRequeridos();
			var em = new ExchangeManager();
			var ect = new ExchangeCompositeType();
			HeaderReq(ref ect, true);
			em.AddExchange(ect, true);
			var ectNow = em.getExchangeByPreFolioUnique(0.ToString());
			lblIdExchange.Text = ectNow.iIdExchange.ToString();
			AddDocumentosAfectados();

			BlockControls();
			btnClean.Visible = true;
			btnGenetate.Visible = false;
			lblPrefolio.Visible = true;
			lblPrefolioTitle.Visible = true;
			btnUpdateExchangeOk.Visible = false;
			btnExchangeUpdate.Visible = true;
			lblPrefolio.Text = ectNow.sFolio; //Add
			txtSrchPreFol.Text = ectNow.sFolio; //Add
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

	protected void btnUpdateExchangeOk_Click(object sender, EventArgs e)
	{
		try
		{
			lblMessage.Text = "";
			util.GetActionMenu(menuSolicitud.SelectedItem.Value);
			var em = new ExchangeManager();
			ExchangeCompositeType ect = em.getExchangeById(int.Parse(lblIdExchange.Text));
			HeaderReq(ref ect, false);
			em.UpdateExchange(ect, ((RadButton)sender).ID);
			ExchangeCompositeType ectNow = em.getExchangeByPreFolioUnique(ect.sFolioPre);
			lblIdExchange.Text = ectNow.iIdExchange.ToString();
			AddDocumentosAfectados();
			BlockControls();
			btnClean.Visible = true;
			btnGenetate.Visible = false;
			lblPrefolio.Visible = true;
			lblPrefolioTitle.Visible = true;

			btnUpdateExchangeOk.Visible = false;
			btnExchangeUpdate.Visible = true;
			lblPrefolio.Text = ectNow.sFolio;
			txtSrchPreFol.Text = ectNow.sFolio;
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
			util.ErroDisplay(1, ex.Message.ToString(), ref lblMessage);
		}
	}

	protected void btnExchangeUpdate_Click(object sender, EventArgs e)
	{
		try
		{
			util.GetActionMenu(menuSolicitud.SelectedItem.Value);
			EnabledControls();
			btnExchangeUpdate.Visible = false;
			btnUpdateExchangeOk.Visible = true;
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
	}

	private void ControlState(bool state)
	{
		//Exchange
		ddlExchange.Enabled = state;
		ddlPriority.Enabled = state;
		ddlSerie.Enabled = state;
		ddlPlant.Enabled = state;
		ddlClient.Enabled = state;
		ddlEngeenerProduct.Enabled = state;
		
		for (int i = 0; i <= Page.Controls[0].Controls[3].Controls[7].Controls[13].Controls[0].Controls.Count - 1; i++)
		{
			if (Page.Controls[0].Controls[3].Controls[7].Controls[13].Controls[0].Controls[i].GetType().Name == "RadTextBox")
				((RadTextBox)Page.Controls[0].Controls[3].Controls[7].Controls[13].Controls[0].Controls[i]).Enabled = state;
		}
		for (int i = 0; i <= Page.Controls[0].Controls[3].Controls[7].Controls[13].Controls[0].Controls[61].Controls.Count - 1; i++)
		{
			if (Page.Controls[0].Controls[3].Controls[7].Controls[13].Controls[0].Controls[61].Controls[i].GetType().Name == "CheckBox")
				((CheckBox)Page.Controls[0].Controls[3].Controls[7].Controls[13].Controls[0].Controls[61].Controls[i]).Enabled = state;
		}
	}

	private void BlockControls()
	{
		ControlState(false);

		btnGenetate.Visible = false;
		btnClean.Visible = true;
		btnUpdateExchangeOk.Visible = false;
		btnExchangeUpdate.Visible = true;
	}

	private void EnabledControls()
	{
		ControlState(true);
	}

	protected void ddlExchange_SelectedIndExchanged(object sender, EventArgs e)
	{
		pnDocuments.Visible = ddlExchange.SelectedItem.Text.Contains("Cambio");
	}

	protected void btnClean_Click(object sender, EventArgs e)
	{
		Requerimiento();
	}

	protected void imbEchangeAdd_Click(object sender, ImageClickEventArgs e)
	{
		Requerimiento();
	}

	private void Requerimiento()
	{
		try
		{
			util.GetValidStage("imAddReq", menuSolicitud);
			MultiPage_Aviso.SelectedIndex = 0;
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
	#endregion

	#region Timming Final
	protected void Button2_Click(object sender, EventArgs e)
	{
		lblTaskNow.Text = "";
		pnTimingEndUpdate.Visible = false;
		txtTimingEnd.Text = "";
	}
	protected void btnTimmingEndUpdate_Click(object sender, EventArgs e)
	{
		try
		{
			var tect = new TaskExchangeCompositeType();
			var tem = new TaskExchangeManager();

			tect.iTask = int.Parse(lblIdTaskT.Text.Trim());
			tect.iExchange = int.Parse(lblIdExchange.Text.Trim());
			tect = tem.getTaskExchangeByIdTaskIdExchange(tect);
			int iTmDif = tect.iTiming - int.Parse(txtTimingEnd.Text.Trim());

			tect.iTiming = int.Parse(txtTimingEnd.Text.Trim());
			tect.iTimingTotal = tect.iTimingTotal - iTmDif;
			tect.dTiming = DateTime.Now.AddDays(tect.iTimingTotal * 7);

			tem.updateTaskSerie(tect, iTmDif, "imTimingFinal");
			gvTimming.DataBind();
			pnTimingEndUpdate.Visible = false;
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
	}

	protected void imbSelectReviewExchange_Click1(object sender, ImageClickEventArgs e)
	{
		var tect = new TaskExchangeCompositeType();
		var tem = new TaskExchangeManager();

		pnTimingEndUpdate.Visible = true;
		int iIdTask = int.Parse(((ImageButton)sender).CommandArgument.ToString());
		lblIdTaskT.Text = iIdTask.ToString();

		tect.iTask = iIdTask;
		tect.iExchange = int.Parse(lblIdExchange.Text);
		tect = tem.getTaskExchangeByIdTaskIdExchange(tect);
		lblTaskNow.Text = tect.sTask;
		txtTimingEnd.Text = tect.iTiming.ToString();
	}
	#endregion

	#region pnAnalize
	protected void btnGenerateFolio_Click(object sender, EventArgs e)
	{
		try
		{
			util.GetActionMenu(menuSolicitud.SelectedItem.Value);
			var ect = new ExchangeCompositeType();
			var em = new ExchangeManager();
			var tem = new TaskExchangeManager(); //Add
			
			ect = em.getExchangeById(int.Parse(lblIdExchange.Text));
			int iMax = tem.getMaxTimingByIdExchange(ect); //Add
			DateTime dAplication = calAplicationDate.SelectedDate.Value;
			dAplication.AddDays(iMax * 7); //Add
			tem.UpdateTime_byGenerate(int.Parse(lblIdExchange.Text), calAplicationDate.SelectedDate.Value, ((RadButton)sender).ID);
			//Add DateTime dAplication = DateTime.Parse(txtAplicationDate.Text);
			ect.dAplicationDate = dAplication;
			ect.iStatus = 12;
			//Add em.UpdateExchange(ect);
			em.UpdateExchangeDate(ect);
			lblFolioGen.Text = ((DateTime)ect.dAplicationDate).ToShortDateString().ToString();
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

	#region Documentos
	protected void btnGrabar_Click(object sender, EventArgs e)
	{
		try
		{
			util.GetActionMenu(menuSolicitud.SelectedItem.Value);
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
	#endregion

	#region Subordinados
	protected void ddlNoPartCot_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
	{
		Quote();
	}

	protected void btnCalculate_Click(object sender, EventArgs e)
	{
		try
		{
			calculate();
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

	private void calculate()
	{
		Util.isRequired(txtCostM.Text.Trim(), "Costo Material");
		var plect = new PartListExchangeCompositeType();
		var plem = new PartListExchangeManager();
		plect.iIdExchange = int.Parse(lblIdExchange.Text.Trim());
		plect.iIdPartList = int.Parse(ddlNoPartCot.SelectedValue.ToString());
		lblTotalInvC.Text = plem.getSUMPartListExchange(plect).ToString();
		lblTotalC.Text = (plem.getSUMPartListExchangeComponents(plect) + int.Parse(txtCostM.Text.Trim())).ToString();
	}

	protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
	{
		AffectationPartList.Visible = true;
	}

	protected void btnCancelC_Click(object sender, EventArgs e)
	{
		txtCostAdd.Text = "";
		AffectationPartList.Visible = false;
	}

	protected void btnAddCot_Click(object sender, EventArgs e)
	{
		try
		{
			Util.isRequired(txtPound.Text.Trim(), "Peso");
			Util.isNumeric(txtPound.Text.Trim(), "Peso");
			Util.isRequired(txtDelta.Text.Trim(), "delta");
			Util.isNumeric(txtDelta.Text.Trim(), "delta");
			Util.isRequired(txtCostC.Text.Trim(), "Costo");
			Util.isNumeric(txtCostC.Text.Trim(), "Costo");
			Util.isRequired(txtSOP.Text.Trim(), "SOP");
			Util.isRequired(txtCostM.Text.Trim(), "Costo Material");
			Util.isNumeric(txtCostM.Text.Trim(), "Costo Material");
			Util.isRequired(txtMoldC.Text.Trim(), "Molde");
			Util.isNumeric(txtMoldC.Text.Trim(), "Molde");
			Util.isRequired(txtProt.Text.Trim(), "Prototipo");
			Util.isNumeric(txtProt.Text.Trim(), "Prototipo");

			var plect = new PartListExchangeCompositeType();
			var plem = new PartListExchangeManager();

			var EFlACT = new ExchangeFlACompositeType();
			var EFlAM = new ExchangeFlAManager();

			plect.iIdPartList = int.Parse(lblPartList.Text.Trim());
			plect.iIdAffectation = int.Parse(ddlAfectationCot.SelectedValue.ToString());
			plect.iIdExchange = int.Parse(lblIdExchange.Text);
			//plect.cos = int.Parse(lblCost.Text);

			EFlACT.bStatus = true;
			EFlACT.dDateIn = calDateIn.SelectedDate.Value;
			EFlACT.dDateOut = calDateOut.SelectedDate.Value;
			EFlACT.dDatePromise = calDateProm.SelectedDate.Value;
			EFlACT.iCost = int.Parse(txtCostC.Text.Trim());
			EFlACT.iDateStart = int.Parse(txtDateStart.Text.Trim());
			EFlACT.iIdPlEA = plem.getIdPlEA(plect);
			EFlACT.iMold = int.Parse(txtMoldC.Text.Trim());
			EFlACT.iMoldProt = int.Parse(txtProt.Text.Trim());
			EFlACT.iTotalInv = int.Parse(lblTotalInvC.Text.Trim());
			EFlACT.iTotalP = int.Parse(lblTotalC.Text.Trim());
			EFlACT.SOECliente = txtSOP.Text.Trim();
			EFlAM.AddExchangeFlA(EFlACT);
		}
		catch (Exception ex)
		{
			util.ErroDisplay(1, ex.Message, ref lblMessage);
		}
	}
	#endregion
}