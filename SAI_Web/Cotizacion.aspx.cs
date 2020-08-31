using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DS.SAI.Business;

public partial class Cotizacion : Page
{
	private Utilerias util;
	private string UrlReference = "Solicitud.aspx";
    private System.Web.UI.WebControls.Menu mpMenu;

	protected void Page_Load(object sender, EventArgs e)
	{
		util = new Utilerias();
        mpMenu = (System.Web.UI.WebControls.Menu)Master.FindControl("ChildrenMenu");
        mpMenu.MenuItemClick += new MenuEventHandler(menuSolicitud_MenuItemClick);
		try
		{
			if (Request.QueryString["ex"] != null)
			{
				if (!Page.IsPostBack)
				{
					lblIdExchange.Text = Request.QueryString["ex"];
					var swap = new PartListExchangeManager();
					ddlPartListC.DataSource = swap.GetPartListC(Request.QueryString["ex"]);
					ddlPartListC.DataBind();
					Quote();
				}
			}
			else
				Response.Redirect(UrlReference + "?mod=imAddReq");
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
		int iIdExchange = int.Parse(lblIdExchange.Text.ToString());
		if ((util.GetActionMenu(mpMenu.SelectedItem.Value, false) != "imTiming") && (util.GetActionMenu(mpMenu.SelectedItem.Value, false) != "imQuote"))
			Response.Redirect(UrlReference + "?ex=" + Request.QueryString["ex"] + "&mod=" + util.GetActionMenu(mpMenu.SelectedItem.Value, false));
		else if (util.GetActionMenu(mpMenu.SelectedItem.Value, false) == "imTiming")
			Response.Redirect("Timming.aspx?mod=imTiming&ex=" + lblIdExchange.Text);
	}
	#endregion

	#region Buttons
	protected void btnUpdateQuote_Click(object sender, EventArgs e)
	{
		try
		{
			lblMessage.Text = string.Empty;
			util.GetActionMenu(mpMenu.SelectedItem.Value);
			for (int i = 0; i <= pnQuoteA.Controls.Count - 1; i++)
			{
				if (pnQuoteA.Controls[i].GetType().Name == "TextBox")
					((TextBox) pnQuoteA.Controls[i]).Enabled = true;
				if (pnQuoteA.Controls[i].GetType().Name == "CheckBox")
					((CheckBox) pnQuoteA.Controls[i]).Enabled = true;
			}
			setVisibleChecked();
			btnUpdateQuote.Visible = false;
			btnUpdateQuoteGuardar.Visible = true;
			btnAddQuote.Visible = false;
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
	}

	private DS.SAI.Data.QuoteCompositeType HeaderReq()
	{
		try
		{
			var qct = new DS.SAI.Data.QuoteCompositeType();
			Util.isRequired(txtDateIn.Text.Trim(), "Fecha Entrada");
			Util.validateDatesHomeEnd(txtDateIn.Text.Trim(), "Fecha Entrada");
			Util.isRequired(txtDateProm.Text.Trim(), "Fecha Promesa");
			Util.validateDatesHomeEnd(txtDateIn.Text.Trim(), "Fecha Promesa");
			Util.isRequired(txtDateIn.Text.Trim(), "Fecha Entrega");
			Util.validateDatesHomeEnd(txtDateOut.Text.Trim(), "Fecha Entrega");
			Util.isRequired(txtSOPClientC.Text.Trim(), "SOP Cliente");
			qct.dIn = DateTime.Parse(txtDateIn.Text.Trim());
			qct.dProm = DateTime.Parse(txtDateProm.Text.Trim());
			qct.dOut = DateTime.Parse(txtDateOut.Text.Trim());
			qct.SOPCliente = txtSOPClientC.Text.Trim();
			qct.iExchange = int.Parse(lblIdExchange.Text.Trim());
			qct.iPartList = int.Parse(ddlPartListC.SelectedValue.ToString());
			return qct;
		}
		catch (ArgumentException ae)
		{
			throw new Exception(ae.Message);
		}
	}

	private void SaveQuote(bool bUpdate)
	{
		lblMessage.Text = "";
		try
		{
			var qm = new QuoteManager();
			if (bUpdate)
				qm.UpdateQuote(calculate(HeaderReq()));
			else
				qm.AddQuote(calculate(HeaderReq()));
			util.ErroDisplay(5, string.Empty, ref lblMessage);
			BlockQuote();
			btnUpdateQuote.Visible = true;
			btnUpdateQuoteGuardar.Visible = false;
			btnAddQuote.Visible = false;
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

	protected void btnUpdateQuoteGuardar_Click(object sender, EventArgs e)
	{
		try
		{
			util.GetActionMenu(mpMenu.SelectedItem.Value);
			SaveQuote(true);
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
	}

	protected void btnAddQuote_Click(object sender, EventArgs e)
	{
		try
		{
			util.GetActionMenu(mpMenu.SelectedItem.Value);
			SaveQuote(false);
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
	}
	#endregion

	private DS.SAI.Data.QuoteCompositeType calculate(DS.SAI.Data.QuoteCompositeType qct)
	{
		decimal iSum = 0;
		decimal iSum2 = 0;
		if (chkMoldC.Checked)
		{
			Util.isRequired(txtMoldC.Text.Trim(), "Molde Prototipo");
			Util.isNumeric(txtMoldC.Text.Trim(), "Molde Prototipo");
			qct.iMoldProt = decimal.Parse(txtMoldC.Text.Trim());
			qct.bMoldProt = true;
			iSum += decimal.Parse(txtMoldC.Text.Trim());
		}
		else
		{
			qct.iMoldProt = 0;
			qct.bMoldProt = false;
		}
		if (chkMoldSC.Checked)
		{
			Util.isRequired(txtMoldSC.Text.Trim(), "Molde Serie");
			Util.isNumeric(txtMoldSC.Text.Trim(), "Molde Serie");
			qct.iMoldSerie = decimal.Parse(txtMoldSC.Text.Trim());
			qct.bMoldSerie = true;
			iSum = iSum + decimal.Parse(txtMoldSC.Text.Trim());
		}
		else
		{
			qct.iMoldSerie = 0;
			qct.bMoldSerie = false;
		}
		if (chkCFC.Checked)
		{
			Util.isRequired(txtCFC.Text.Trim(), "C/F");
			Util.isNumeric(txtCFC.Text.Trim(), "C/F");
			qct.iCF = decimal.Parse(txtCFC.Text.Trim());
			qct.bCF = true;
			iSum = iSum + decimal.Parse(txtCFC.Text.Trim());
		}
		else
		{
			qct.iCF = 0;
			qct.bCF = false;
		}
		if (chkDeviceC.Checked)
		{
			Util.isRequired(txtDeviceC.Text.Trim(), "Dispositivo ensamble");
			Util.isNumeric(txtDeviceC.Text.Trim(), "Dispositivo ensamble");
			qct.iDevice = decimal.Parse(txtDeviceC.Text.Trim());
			qct.bDevice = true;
			iSum = iSum + decimal.Parse(txtDeviceC.Text.Trim());
		}
		else
		{
			qct.iDevice = 0;
			qct.bDevice = false;
		}
		if (chkObsoletC.Checked)
		{
			Util.isRequired(txtObsoletC.Text.Trim(), "Obsoletos");
			Util.isNumeric(txtObsoletC.Text.Trim(), "Obsoletos");
			qct.iObsolet = decimal.Parse(txtObsoletC.Text.Trim());
			qct.bObsolet = true;
			iSum = iSum + decimal.Parse(txtObsoletC.Text.Trim());
		}
		else
		{
			qct.iObsolet = 0;
			qct.bObsolet = false;
		}
		if (chkManEngC.Checked)
		{
			Util.isRequired(txtManEngC.Text.Trim(), "Admon. Ingeniería");
			Util.isNumeric(txtManEngC.Text.Trim(), "Admon. Ingeniería");
			qct.iEngMan = decimal.Parse(txtManEngC.Text.Trim());
			qct.bEngMan = true;
			iSum = iSum + decimal.Parse(txtManEngC.Text.Trim());
		}
		else
		{
			qct.iEngMan = 0;
			qct.bEngMan = false;
		}
		if (chkDesingC.Checked)
		{
			Util.isRequired(txtDesignC.Text.Trim(), "Diseño");
			Util.isNumeric(txtDesignC.Text.Trim(), "Diseño");
			qct.iDesign = decimal.Parse(txtDesignC.Text.Trim());
			qct.bDesign = true;
			iSum = iSum + decimal.Parse(txtDesignC.Text.Trim());
		}
		else
		{
			qct.iDesign = 0;
			qct.bDesign = false;
		}
		if (chkComponetsC.Checked)
		{
			Util.isRequired(txtComponentsC.Text.Trim(), "Componentes");
			Util.isNumeric(txtComponentsC.Text.Trim(), "Componentes");
			qct.iComponents = decimal.Parse(txtComponentsC.Text.Trim());
			qct.bComponents = true;
			//iSum = iSum +int.Parse(txtComponentsC.Text.Trim());
			iSum2 = iSum2 + decimal.Parse(txtComponentsC.Text.Trim());
		}
		else
		{
			qct.iComponents = 0;
			qct.bComponents = false;
		}
		if (chkOthersWC.Checked)
		{
			Util.isRequired(txtOthersTitleWC.Text.Trim(), "Descripcion Otros");
			Util.isRequired(txtOthersWC.Text.Trim(), "Otros");
			Util.isNumeric(txtOthersWC.Text.Trim(), "Otros");
			qct.sOthers = txtOthersTitleWC.Text.Trim();
			qct.iOthers = decimal.Parse(txtOthersWC.Text.Trim());
			qct.bOthers = true;
			//iSum = iSum + decimal.Parse(txtOthersWC.Text.Trim());
		}
		else
		{
			qct.bOthers = false;
			qct.iOthers = 0;
			qct.sOthers = "";
		}
		if (chkPaintC.Checked)
		{
			Util.isRequired(txtPaintC.Text.Trim(), "Pintura");
			Util.isNumeric(txtPaintC.Text.Trim(), "Pintura");
			qct.iPaint = decimal.Parse(txtPaintC.Text.Trim());
			qct.bPaint = true;
			iSum = iSum + decimal.Parse(txtPaintC.Text.Trim());
		}
		else
		{
			qct.bPaint = false;
			qct.iPaint = 0;
		}
		if (chkEmpC.Checked)
		{
			Util.isRequired(txtEmpC.Text.Trim(), "Empaque");
			Util.isNumeric(txtEmpC.Text.Trim(), "Empaque");
			qct.iEmp = decimal.Parse(txtEmpC.Text.Trim());
			qct.bEmp = true;
			iSum = iSum + decimal.Parse(txtEmpC.Text.Trim());
		}
		else
		{
			qct.iEmp = 0;
			qct.bEmp = false;
		}
		if (chkBankC.Checked)
		{
			Util.isRequired(txtBankC.Text.Trim(), "Banco");
			Util.isNumeric(txtBankC.Text.Trim(), "Banco");
			qct.iBank = decimal.Parse(txtBankC.Text.Trim());
			qct.bBank = true;
			iSum = iSum + decimal.Parse(txtBankC.Text.Trim());
		}
		else
		{
			qct.iBank = 0;
			qct.bBank = false;
		}
		Util.isRequired(txtPoundC.Text.Trim(), "Peso Actual");
		Util.isNumeric(txtPoundC.Text.Trim(), "Peso Actual");
		qct.iPound = decimal.Parse(txtPoundC.Text.Trim());
		Util.isRequired(txtDelta1.Text.Trim(), "Delta 1");
		Util.isNumeric(txtDelta1.Text.Trim(), "Delta 1");
		qct.iDelta1 = int.Parse(txtDelta1.Text.Trim());
		Util.isNumeric(txtDelta2.Text.Trim(), "Delta 2");
		qct.iDelta2 = int.Parse(txtDelta2.Text.Trim());

		Util.isRequired(txtPrue.Text.Trim(), "Otros");
		Util.isNumeric(txtPrue.Text.Trim(), "Otros");
		qct.iOthersC = int.Parse(txtDelta1.Text.Trim());

		iSum = iSum + decimal.Parse(txtPrue.Text.Trim());
		Util.isRequired(txtMoldPlazoC.Text.Trim(), "Molde");
		Util.isNumeric(txtMoldPlazoC.Text.Trim(), "Molde");
		qct.iMoldP = int.Parse(txtMoldPlazoC.Text.Trim());
		Util.isRequired(txtMoldProtC.Text.Trim(), "Molde");
		Util.isNumeric(txtMoldProtC.Text.Trim(), "Molde");
		qct.iMoldProt = int.Parse(txtMoldProtC.Text.Trim());
		Util.isRequired(txtDateStart.Text.Trim(), "Fecha inicio de cambio");
		Util.isNumeric(txtDateStart.Text.Trim(), "Fecha inicio de cambio");
		qct.iStart = int.Parse(txtDateStart.Text.Trim());
		Util.isRequired(txtObsC.Text.Trim(), "observaciones");
		qct.sObservations = txtObsC.Text.Trim();
		Util.isRequired(txtR1.Text.Trim(), "R1");
		Util.isNumeric(txtR1.Text.Trim(), "R1");
		qct.iFR1 = decimal.Parse(txtR1.Text.Trim());
		Util.isRequired(txtR2.Text.Trim(), "R2");
		Util.isNumeric(txtR2.Text.Trim(), "R2");
		qct.iFR2 = decimal.Parse(txtR2.Text.Trim());

		lblINVTotal.Text = iSum.ToString();
		qct.iTotalInv = iSum / 1000;
		//txtCost.Text = ((qct.iDelta1 * qct.iFR1) + (qct.iDelta2 * qct.iFR2)).ToString();
		qct.iCost = decimal.Parse(txtCost.Text.Trim());

		lblTotalPieceTotal.Text = (qct.iCost + iSum2).ToString();
		qct.iTotalP = decimal.Parse(lblTotalPieceTotal.Text.Trim());

		return qct;
	}

	private void Quote()
	{
		if (ddlPartListC.Items.Count > 0)
		{
			pnQuoteA.Visible = true;
			pnQuoteNon.Visible = false;

			var plct = new DS.SAI.Data.PartListCompositeType();
			var plm = new PartListManager();

			var ect = new DS.SAI.Data.ExchangeCompositeType();
			var em = new ExchangeManager();

			var qct = new DS.SAI.Data.QuoteCompositeType();
			var qm = new QuoteManager();

			qct.iExchange = int.Parse(lblIdExchange.Text.ToString());
			qct.iPartList = int.Parse(ddlPartListC.SelectedValue.ToString());
			plct = plm.getPartListById(int.Parse(ddlPartListC.SelectedValue.ToString()));
			ect = em.getExchangeById(int.Parse(lblIdExchange.Text));

			lblNoParC.Text = plct.iNumber.ToString();
			lblClientC.Text = ect.sClient.ToString();
			lblProyectC.Text = ect.sProyect.ToString();
			lblDescriptionC.Text = ect.sDescription.ToString();

			if (qm.ExistQuoteDuplicate(qct))
			{
				qct = qm.getQuoteById(qct);

				txtDateIn.Text = qct.dIn.ToShortDateString();
				txtDateProm.Text = qct.dProm.ToShortDateString();
				txtDateOut.Text = qct.dOut.ToShortDateString();
				txtSOPClientC.Text = qct.SOPCliente;
				txtMoldC.Text = qct.iMoldProt.ToString();
				txtMoldSC.Text = qct.iMoldSerie.ToString();
				txtCFC.Text = qct.iCF.ToString();
				txtDeviceC.Text = qct.iDevice.ToString();
				txtObsoletC.Text = qct.iObsolet.ToString();
				txtManEngC.Text = qct.iEngMan.ToString();
				txtDesignC.Text = qct.iDesign.ToString();
				txtComponentsC.Text = qct.iComponents.ToString();
				txtOthersTitleWC.Text = qct.sOthers.ToString();
				txtOthersWC.Text = qct.iOthers.ToString();
				txtPaintC.Text = qct.iPaint.ToString();
				txtEmpC.Text = qct.iEmp.ToString();
				txtBankC.Text = qct.iBank.ToString();
				txtPrue.Text = qct.iOthersC.ToString();
				txtPoundC.Text = qct.iPound.ToString();
				txtDelta1.Text = qct.iDelta1.ToString();
				txtDelta2.Text = qct.iDelta2.ToString();
				txtCost.Text = qct.iCost.ToString();
				txtR1.Text = qct.iFR1.ToString();
				txtR2.Text = qct.iFR2.ToString();
				txtMoldPlazoC.Text = qct.iMoldP.ToString();
				txtMoldProtC.Text = qct.iMoldProtP.ToString();
				txtDateStart.Text = qct.iStart.ToString();
				txtObsC.Text = qct.sDescription.ToString();
				lblINVTotal.Text = qct.iTotalInv.ToString();
				lblTotalPieceTotal.Text = qct.iTotalP.ToString();
				chkMoldC.Checked = qct.bMoldProt;
				chkMoldSC.Checked = qct.bMoldSerie;
				chkCFC.Checked = qct.bCF;
				chkDeviceC.Checked = qct.bDevice;
				chkObsoletC.Checked = qct.bObsolet;
				chkManEngC.Checked = qct.bEngMan;
				chkDesingC.Checked = qct.bDesign;
				chkComponetsC.Checked = qct.bComponents;
				chkOthersWC.Checked = qct.bOthers;
				chkPaintC.Checked = qct.bPaint;
				chkEmpC.Checked = qct.bEmp;
				chkBankC.Checked = qct.bBank;
				setVisibleChecked();
				BlockQuote();
				btnUpdateQuote.Visible = true;
				btnUpdateQuoteGuardar.Visible = false;
				btnAddQuote.Visible = false;
			}
			else
			{
				clearControlsQuote();
				UnblockQuote();
			}
		}
		else
		{
			pnQuoteA.Visible = false;
			pnQuoteNon.Visible = true;
		}
	}

	#region Calendatios
	protected void imbDateIn_Click(object sender, ImageClickEventArgs e)
	{
		cCalendarCot.Visible = true;
		lblCalendar.Text = "IN";
		imbDateIn.Enabled = false;
		imbDateOut.Enabled = false;
		imbDateProm.Enabled = false;
	}

	protected void imbDateProm_Click(object sender, ImageClickEventArgs e)
	{
		cCalendarCot.Visible = true;
		lblCalendar.Text = "PROM";
		imbDateIn.Enabled = false;
		imbDateOut.Enabled = false;
		imbDateProm.Enabled = false;
	}

	protected void imbDateOut_Click(object sender, ImageClickEventArgs e)
	{
		cCalendarCot.Visible = true;
		lblCalendar.Text = "OUT";
		imbDateIn.Enabled = false;
		imbDateOut.Enabled = false;
		imbDateProm.Enabled = false;
	}

	protected void cCalendarCot_SelectionChanged(object sender, EventArgs e)
	{
		imbDateIn.Enabled = true;
		imbDateOut.Enabled = true;
		imbDateProm.Enabled = true;
		String calendar = lblCalendar.Text.Trim();
		switch (calendar)
		{
			case "IN":
				txtDateIn.Text = cCalendarCot.SelectedDate.ToShortDateString();
				break;
			case "OUT":
				txtDateOut.Text = cCalendarCot.SelectedDate.ToShortDateString();
				break;
			case "PROM":
				txtDateProm.Text = cCalendarCot.SelectedDate.ToShortDateString();
				break;
		}
		cCalendarCot.Visible = false;
	}
	#endregion

	#region Combos
	protected void ddlPartListC_SelectedIndexChanged(object sender, EventArgs e)
	{
		Quote();
	}

	protected void ddlNoPartCot_SelectedIndExchanged(object sender, EventArgs e)
	{
		Quote();
	}
	#endregion
	
	#region costo
	protected void txtCalculoCosto_TextChanged(object sender, EventArgs e)
	{
		Costo();
	}

	private void Costo()
	{
		var x = float.Parse(txtDelta1.Text) * float.Parse(txtR1.Text);
		var y = float.Parse(txtDelta2.Text) * float.Parse(txtR2.Text);
		var z = (x + y) / 1000;
		txtCost.Text = z.ToString();
	}
	#endregion

	#region Controles
	private void BlockQuote()
	{
		lblMessage.Text = string.Empty;
		for (int i = 0; i <= pnQuoteA.Controls.Count - 1; i++)
		{
			if (pnQuoteA.Controls[i].GetType().Name == "TextBox")
				((TextBox)pnQuoteA.Controls[i]).Enabled = false;
			if (pnQuoteA.Controls[i].GetType().Name == "CheckBox")
				((CheckBox)pnQuoteA.Controls[i]).Enabled = false;
		}
		btnAddQuote.Visible = false;
		btnUpdateQuoteGuardar.Visible = false;
		btnUpdateQuote.Visible = true;
	}

	private void clearControlsQuote()
	{
		txtDateIn.Text = DateTime.Today.AddDays(1).ToShortDateString().ToString();
		txtDateOut.Text = DateTime.Today.AddDays(1).ToShortDateString().ToString();
		txtDateProm.Text = DateTime.Today.AddDays(1).ToShortDateString().ToString();
		txtSOPClientC.Text = "";
		txtMoldC.Text = "0";
		txtMoldSC.Text = "0";
		txtCFC.Text = "0";
		txtDeviceC.Text = "0";
		txtObsoletC.Text = "0";
		txtManEngC.Text = "0";
		txtDesignC.Text = "0";
		txtComponentsC.Text = "0";
		txtPaintC.Text = "0";
		txtEmpC.Text = "0";
		txtBankC.Text = "0";
		txtPrue.Text = "0";
		txtPoundC.Text = "0";
		txtDelta1.Text = "0";
		txtDelta2.Text = "0";
		txtCost.Text = "0";
		txtR1.Text = "0";
		txtR2.Text = "0";
		txtMoldPlazoC.Text = "0";
		txtMoldProtC.Text = "0";
		txtDateStart.Text = "0";
		txtObsC.Text = "";
		txtMoldC.Text = "";
		lblINVTotal.Text = "";
		txtOthersTitleWC.Text = "";
		lblTotalPieceTotal.Text = "0";
		lblTotalPieceTotal.Text = "0";
	}

	private void UnblockQuote()
	{
		lblMessage.Text = string.Empty;
		for (int i = 0; i <= pnQuoteA.Controls.Count - 1; i++)
		{
			if (pnQuoteA.Controls[i].GetType().Name == "TextBox")
				((TextBox)pnQuoteA.Controls[i]).Enabled = true;
			if (pnQuoteA.Controls[i].GetType().Name == "CheckBox")
			{
				((CheckBox)pnQuoteA.Controls[i]).Enabled = true;
				((CheckBox)pnQuoteA.Controls[i]).Checked = false;
			}
		}
		btnAddQuote.Visible = true;
		btnUpdateQuote.Visible = false;
		btnUpdateQuoteGuardar.Visible = false;
		//setVisibleChecked();
	}

	private void setVisibleChecked()
	{
		txtMoldC.Visible = chkMoldC.Checked;
		txtMoldSC.Visible = chkMoldSC.Checked;
		txtCFC.Visible = chkCFC.Checked;
		txtDeviceC.Visible = chkDeviceC.Checked;
		txtObsoletC.Visible = chkObsoletC.Checked;
		txtManEngC.Visible = chkManEngC.Checked;
		txtDesignC.Visible = chkDesingC.Checked;
		txtComponentsC.Visible = chkComponetsC.Checked;
		txtPaintC.Visible = chkPaintC.Checked;
		txtEmpC.Visible = chkEmpC.Checked;
		txtBankC.Visible = chkBankC.Checked;
		txtOthersWC.Visible = chkOthersWC.Checked;
	}

	protected void CheckCotizacion_CheckedChanged(object sender, EventArgs e)
	{
		setVisibleChecked();
	}
	#endregion
}