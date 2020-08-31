using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using DS.SAI.Business;
using DS.SAI.Data;
using Telerik.Web.UI;

public partial class Timming : System.Web.UI.Page
{
	private Utilerias util;
    private System.Web.UI.WebControls.Menu mpMenu;

	protected void Page_Load(object sender, EventArgs e)
	{
		util = new Utilerias();
		try
		{
            mpMenu = (System.Web.UI.WebControls.Menu)Master.FindControl("ChildrenMenu");
            mpMenu.MenuItemClick += new MenuEventHandler(menuSolicitud_MenuItemClick);
			if (!Page.IsPostBack)
			{
				if (Request.QueryString["page"] == null)
					ViewState["UrlReference"] = "Solicitud.aspx";
				else
					ViewState["UrlReference"] = "ExchangeNote.aspx";
			}
			if (Request.QueryString["ex"] != null)
			{
				if (!Page.IsPostBack)
				{
					lblIdExchange.Text = Request.QueryString["ex"];
					if ((Request.QueryString["mod"] != null) && (Request.QueryString["mod"] == "imTiming"))
					{
						chlTaskNext.Checked = false;
						ddlNestTask.Enabled = chlTaskNext.Checked;
						TaskExchange();

						RadMultiPage1.SelectedIndex = 0;
					}
					if ((Request.QueryString["mod"] != null) && (Request.QueryString["mod"] == "imManAut"))
					{
						lblTitle.Text = "Autorización de Gerencia";
						LoadAutorizacion();
						RadMultiPage1.SelectedIndex = 1;
					}
				}
			}
			else
				Response.Redirect(ViewState["UrlReference"].ToString() + "?mod=imAddReq");
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
		if (util.GetActionMenu(mpMenu.SelectedItem.Value, false) == "imQuote")
			Response.Redirect("Cotizacion.aspx?ex=" + lblIdExchange.Text);
		else if (util.GetActionMenu(mpMenu.SelectedItem.Value, false) != "imTiming")
			sqlDSExchangeTask.SelectCommand = "sp_selectExchangeTaskByIdExchange";
		else if (util.GetActionMenu(mpMenu.SelectedItem.Value, false) != "imManAut")
			sqlDSExchangeTask.SelectCommand = "sp_selectExchangeTaskByIdExchange_Faltante";
		sqlDSExchangeTask.DataBind();
		if (util.GetActionMenu(mpMenu.SelectedItem.Value, false) != "imQuote")
			Response.Redirect(ViewState["UrlReference"].ToString() + "?ex=" + Request.QueryString["ex"] + "&mod=" + util.GetActionMenu(mpMenu.SelectedItem.Value, false));
	}
	#endregion

	#region Timming
	private void TaskExchange()
	{
		gvTaskGroup.Columns[0].Visible = true;
		ddlGroup.DataBind();
		ddlTaskTiming.DataBind();
		ddlTaskTiming_Edit.DataBind();
		//sqlDSDataTaskbyTaskId.DataBind();
		ddlUsuarioTask_Edit.DataBind();
		TaskLoad_Update();
		gvTaskGroup.DataBind();
		//ddlTaskTiming_Edit.DataTextField = "sDescriptionTask";
		//ddlTaskTiming_Edit.DataSourceID = "sqlDStaskGroupByGroup";
	}

	private void TaskLoad_Update()
	{
		ddlNestTask.DataBind();
		gvTaskData.DataBind();
	}

	protected void btnAddTiming_Click(object sender, EventArgs e)
	{
		try
		{
			util.GetActionMenu(mpMenu.SelectedItem.Value);
			Util.isRequired(ddlTaskTiming.SelectedValue, "Tarea");
			Util.isRequired(txtTiming.Text.Trim(), "Timing");
			var te = new TaskExchangeManager();
			var swap = new List<string>();
			var tect = new TaskExchangeCompositeType { iExchange = int.Parse(lblIdExchange.Text.Trim()) };
			foreach (RadComboBoxItem item in ddlTaskTiming.Items)
			{
				var cb = (CheckBox)item.Controls[1];
				if (cb.Checked)
				{
					swap.Add(item.Value);
					tect.iTask = int.Parse(item.Value);
					if (te.getCountTaskExchangeByIdTaskIdExchange(tect) > 0)
					{
						throw new ArgumentException("La tarea " + item.Text + " ya ha sido cargada");
					}
				}
			}
			te.InsertBulkTaskExchange(int.Parse(txtTiming.Text), swap, int.Parse(lblIdExchange.Text.Trim()), DateTime.Now.AddDays(int.Parse(txtTiming.Text) * 7), int.Parse(ddlGroup.SelectedValue));
			
			util.ErroDisplay(5, string.Empty, ref lblMessage);
			lblMessage.Focus();
			Response.Redirect("Timming.aspx?ex=" + Request.QueryString["ex"] + "&mod=" + Request.QueryString["mod"]);
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

	protected void btnCalcelAddExchageTask_Click(object sender, EventArgs e)
	{
		TaskExchange();
	}

	protected void chlTaskNext_CheckedChanged(object sender, EventArgs e)
	{
		ddlNestTask.Enabled = chlTaskNext.Checked;
	}

	protected void btnEditTimmingSave_Click(object sender, EventArgs e)
	{
		try
		{
			bool flag = true;
			util.GetActionMenu(mpMenu.SelectedItem.Value);
			Util.isRequired(ddlTaskTiming_Edit.SelectedValue, "Tarea");
			Util.isRequired(txtTiming_Edit.Text.Trim(), "Timing");
			if (chlTaskNext.Checked)
				Util.isRequired(ddlNestTask.SelectedValue.ToString(), "Tarea predecesora, si esta marcado,");
			Util.isRequired(ddlUsuarioTask_Edit.SelectedValue.ToString(), "Usuario");
			var te = new TaskExchangeManager();
			var tect = new TaskExchangeCompositeType
			           	{
			           		iEmployed = int.Parse(ddlUsuarioTask_Edit.SelectedValue.ToString()),
			           		iExchange = int.Parse(lblIdExchange.Text.Trim()),
			           		iTask = int.Parse(ddlTaskTiming_Edit.SelectedValue.ToString()),
			           		iTiming = int.Parse(txtTiming_Edit.Text.Trim())
			           	};
			if (chlTaskNext.Checked)
			{
				var tectPre = new TaskExchangeCompositeType
				{
					iTask = int.Parse(ddlNestTask.SelectedValue),
					iExchange = tect.iExchange
				};
				if (te.getCountTaskExchangeByIdTaskIdExchange(tectPre) > 0)
				{
					tect.iNextTask = int.Parse(ddlNestTask.SelectedValue);
					tect.iTimingTotal = int.Parse(te.getTaskExchangeByIdTaskIdExchange(tectPre).iTimingTotal.ToString()) + tect.iTiming;
				}
				else
					throw new ArgumentException("La tarea predecesora: " + ddlNestTask.SelectedItem.Text + " no ha sido cargada");
			}
			else
			{
				tect.iNextTask = 0;
				tect.iTimingTotal = tect.iTiming;
			}
			tect.dTiming = DateTime.Now.AddDays(tect.iTimingTotal * 7);
			tect.iGroup = int.Parse(ddlGroup.SelectedValue);
			var btn = (RadButton)sender;
			if (btn.CommandArgument == "0")
			{
				if (te.getCountTaskExchangeByIdTaskIdExchange(tect) > 0)
					throw new ArgumentException("La tarea " + ddlTaskTiming_Edit.SelectedItem.Text + " ya ha sido cargada");
				te.AddTaskExchange(tect);
			}
			else
			{
				tect.iIdTaskExchange = int.Parse(btnEditTimmingSave.CommandArgument);
				te.UpdateTaskExchange(tect, ((RadButton)sender).ID);
			}
			//TaskExchange();
			util.ErroDisplay(5, string.Empty, ref lblMessage);
			lblMessage.Focus();
			btnEditTimmingSave.CommandArgument = "0";
			Response.Redirect("Timming.aspx?ex=" + Request.QueryString["ex"] + "&mod=" + Request.QueryString["mod"], false);
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

	protected void btnEditCancelTiming_Click(object sender, EventArgs e)
	{
		TaskExchange();
	}

	protected void gvTaskGroup_ItemCommand(object sender, GridCommandEventArgs e)
	{
		lblMessage.Text = string.Empty;
		switch (e.CommandName)
		{
			case "deleteId":
				var tem = new TaskExchangeManager();
				var item1 = (Telerik.Web.UI.GridDataItem)e.Item;
				tem.DeleteTaskExchange(int.Parse(gvTaskGroup.Items[item1.ItemIndex]["iIdTaskExchange"].Text));
				gvTaskGroup.Rebind();
				TaskLoad_Update();
				break;
			case "editId":
				ddlTaskTiming_Edit.DataTextField = "sDescription";
				ddlTaskTiming_Edit.DataSourceID = "sqlDSTask";
				ddlTaskTiming_Edit.DataBind();
				var item2 = (Telerik.Web.UI.GridDataItem)e.Item;
				ddlTaskTiming_Edit.SelectedValue = gvTaskGroup.Items[item2.ItemIndex]["iTask"].Text;
				//ddlTaskTiming_Edit.Items[util.IndexCombo(ddlTaskTiming_Edit, gvTaskGroup.Items[item2.ItemIndex]["iTask"].Text)].Selected = true;
				ddlUsuarioTask_Edit.DataBind();
				ddlUsuarioTask_Edit.Items[util.IndexCombo(ddlUsuarioTask_Edit, gvTaskGroup.Items[item2.ItemIndex]["iEmployed"].Text)].Selected = true;
				btnEditTimmingSave.CommandArgument = gvTaskGroup.Items[item2.ItemIndex]["iIdTaskExchange"].Text;
				txtTiming_Edit.Text = gvTaskGroup.Items[item2.ItemIndex]["iTiming"].Text;
				break;
		}
	}

	protected void ddlGroup_SelectedIndExchanged(object sender, EventArgs e)
	{
		sqlDStaskGroupByGroup.DataBind();
		//Actualizando combos Grupo-Tarea
		//ddlTaskTiming.DataBind();
		ddlTaskTiming_Edit.DataBind();
		//Empleado Asociado a la Tarea
		ddlUsuarioTask_Edit.DataBind();
		ddlUsuarioTask_Edit.DataSourceID = "sqlEmployedByTask";
		ddlUsuarioTask_Edit.DataBind();
	}

	protected void ddlTaskTiming_SelectedIndExchanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
	{
		ddlUsuarioTask_Edit.DataSourceID = null;
		ddlUsuarioTask_Edit.DataBind();
		ddlUsuarioTask_Edit.DataSourceID = "sqlEmployedByTask";
		ddlUsuarioTask_Edit.DataBind();
	}
	#endregion

	#region Autorizacion de Gerencia
	private void LoadAutorizacion()
	{
		sqlDSExchangeTask.SelectCommand = "sp_selectExchangeTaskByIdExchange_Faltante";
		sqlDSExchangeTask.DataBind();
		var swap = new TaskAutorizationManager();
		ddlAreaPendiente.DataSource = swap.AreaPendiente(int.Parse(Request.QueryString["ex"]), DS.SAI.Business.SecurityManager.ObtenerUsuario(HttpContext.Current).IdEmpleado);
		ddlAreaPendiente.DataBind();
		ddlAreaPendiente.Enabled = ddlAreaPendiente.Items.Count > 1;
		if (ddlAreaPendiente.Items.Count == 0) btnAddExchangeReview.Visible = false;
	}

	protected void ddlAreaPendiente_DataBinding(object sender, EventArgs e)
	{
		ddlAreaPendiente.Enabled = ddlAreaPendiente.Items.Count > 1;
	}

	protected void btnAddExchangeReview_Click(object sender, EventArgs e)
	{
		try
		{
			util.GetActionMenu(mpMenu.SelectedItem.Value);
			Util.isRequired(txtReviewExchangeObs.Text.Trim().ToString(), "Observación");
			var swap = new TaskAutorizationManager();
			swap.InsertTaskAutorizatio(int.Parse(Request.QueryString["ex"]), int.Parse(ddlAreaPendiente.SelectedValue), int.Parse(ddlReviewExchangeReview.SelectedValue), txtReviewExchangeObs.Text);
			Response.Redirect("Timming.aspx?ex=" + Request.QueryString["ex"] + "&page=ExchangeNote&mod=imManAut");
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
			util.ErroDisplay(5, "", ref lblMessage);
		}
	}
	#endregion
}