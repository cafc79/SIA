using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using DS.SAI.Data;
using Telerik.Web.UI;
using BO = DS.SAI.Business;

public partial class Catalogos : System.Web.UI.Page
{
	private BO.CatalogManager BO;
	private Utilerias util;
    private System.Web.UI.WebControls.Menu mpMenu;

	protected void Page_Load(object sender, EventArgs e)
	{
		util = new Utilerias();
        BO = new BO.CatalogManager();
        mpMenu = (System.Web.UI.WebControls.Menu)Master.FindControl("ChildrenMenu");
        mpMenu.MenuItemClick += new MenuEventHandler(menuCatalog_MenuItemClick);
	}

	protected void menuCatalog_MenuItemClick(object sender, MenuEventArgs e)
	{
		cleanEv();
        switch (util.GetActionMenu(mpMenu.SelectedItem.Value, false))
		{
			#region GridDescripcion
			case "imAffectationType":
				Space("Tipo de Afectación", 0, "sqlDSAffectationType");
				break;
			case "imClient":
				Space("Cliente", 0, "sqlDSClient");
				break;
			case "imDataType":
				Space("Tipo de Datos", 0, "sqlDSDataType");
				break;
			case "imGroup":
				Space("Grupo", 0, "sqlDSGroup");
				break;
			case "imLockingType":
				Space("Tipo de Cierre", 0, "sqlDSLockingType");
				break;
			case "imPlant":
				Space("Planta", 0, "sqlDSPlant");
				break;
			case "imPriority":
				Space("Prioridad", 0, "sqlDSPriority");
				break;
			case "imReviewType":
				Space("Tipo de Revisión", 0, "sqlDSReviewType");
				break;
			case "imSalesAutType":
				Space("Tipos de Autorizacion de Ventas", 0, "sqlDSSalesAutorization");
				break;
			#endregion

			#region Grid 2
			case "imExchangeType":
				Space("Tipo de Cambio", 1, "sqlDSExchangeType");
				SetKVOption1();
				break;
			case "imGroupTask":
				Space("Grupo Tarea", 1, "sqlDSTaskGroup");
				SetKVOption2();
				break;
			case "imTask":
				Space("Tarea", 1, "sqlDSTask");
				SetKVOption3();
				break;
			#endregion

			#region Grid 3
			case "imPartList":
				Space("Lista de Partes", 2, "sqlDSPartList");
				SetPartList();
				break;
			case "imTaskData":
				Space("Tarea Dato", 2, "sqlDSTaskData");
				SetTaskData();
				break;
			case "imArea":
				Space("Area", 2, "sqlDSArea");
				SetArea();
				break;
			#endregion

			#region Grid empleados
			case "imEmployed":
				lblTitle.Text = "Empleados";
				RadMultiPage1.SelectedIndex = 3;
				gridEmpleado.DataSourceID = "sqlDSEmployed";
				sqlDSArea.DataBind();
				sqlDSPlant.DataBind();
				ddlArea.DataBind();
				ddlPlant.DataBind();
				break;
			#endregion
		}
	}

	#region Configuraciones
	private void Space(string title, byte index, string ds)
	{
		lblTitle.Text = title;
		RadMultiPage1.SelectedIndex = index;
		if (index == 0)
			gridDescripcion.DataSourceID = ds;
		else if (index == 1)
			gridDescValue.DataSourceID = ds;
		else if (index == 2)
			gridTriara.DataSourceID = ds;
	}

	private void SetPartList()
	{
		lblNumberPartList.Text = "No. Parte DS:";
		lblNumberPartListClient.Text = "No. Parte Cliente:";
		txtNumberPartList.Visible = true;
		txtNumberPartListClient.Visible = true;
		ddl_Triara1.Visible = false;
		ddl_Triara2.Visible = false;
		ddl_Triara3.Visible = false;
	}

	private void SetTaskData()
	{
		lblNumberPartList.Text = "Tarea:";
		lblNumberPartListClient.Text = "Tipo de Dato:";
		txtNumberPartList.Visible = false;
		txtNumberPartListClient.Visible = false;
		ddl_Triara1.Visible = true;
		ddl_Triara2.Visible = true;
		ddl_Triara3.Visible = false;
	}

	private void SetArea()
	{
		sqlDSEmployed.DataBind();
		lblNumberPartList.Text = "Número:";
		lblNumberPartListClient.Text = "Responsable de Área:";
		txtNumberPartList.Visible = true;
		txtNumberPartListClient.Visible = false;
		ddl_Triara1.Visible = false;
		ddl_Triara2.Visible = false;
		ddl_Triara3.Visible = true;
	}

	private void SetKVOption1()
	{
		lblDescriptionArea.Text = "Descripción";
		lblNumberArea.Text = "Inicial";
		txtDescriptionKV.Visible = true;
		txtValueKV.Visible = true;
		ddlTaskTaskGroup.Visible = false;
		ddlAreaTask.Visible = false;
		ddlGroupTaskGroup.Visible = false;
	}

	private void SetKVOption2()
	{
		sqlDSTaskGroup.DataBind();
		ddlGroupTaskGroup.DataBind();
		sqlDSTask.DataBind();
		ddlTaskTaskGroup.DataBind();
		lblDescriptionArea.Text = "Tarea";
		lblNumberArea.Text = "Grupo";
		ddlTaskTaskGroup.Visible = true;
		ddlGroupTaskGroup.Visible = true;
		txtDescriptionKV.Visible = false;
		txtValueKV.Visible = false;
		ddlAreaTask.Visible = false;
	}

	private void SetKVOption3()
	{
		lblDescriptionArea.Text = "Descripción";
		lblNumberArea.Text = "Área de la Tarea";
		txtDescriptionKV.Visible = true;
		ddlAreaTask.Visible = true;
		ddlTaskTaskGroup.Visible = false;
		txtValueKV.Visible = false;
		ddlGroupTaskGroup.Visible = false;
	}
	#endregion

	#region Grid Descripción
	protected void gridDescripcion_ItemCommand(object sender, GridCommandEventArgs e)
	{
		try
		{
			lblMessage.Text = string.Empty;
			IDictionary itemValues = new Dictionary<object, object>();
			var item = (Telerik.Web.UI.GridDataItem)e.Item;
			int id = int.Parse(gridDescripcion.Items[item.ItemIndex]["Id"].Text);
			if (e.CommandName == "editId")
			{
				lblIdEntity.Text = gridDescripcion.Items[item.ItemIndex]["Id"].Text;
				txtDescription.Text = gridDescripcion.Items[item.ItemIndex]["sDescription"].Text;
			}
			if (e.CommandName == "deleteId")
			{
				util.GetActionMenu(mpMenu.SelectedItem.Value);
				BO.DeleteDescription(gridDescripcion.DataSourceID, id);
				gridDescripcion.Rebind();
			}
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
		catch (Exception ex)
		{

		}
	}

	protected void btnCancelDesc_Click(object sender, EventArgs e)
	{
		cleanEv();
		util.CleanControls(pnDescription);
	}

	protected void btnAddDesc_Click(object sender, EventArgs e)
	{
		try
		{
			byte status = 0;
			util.GetActionMenu(mpMenu.SelectedItem.Value);
			string msg = string.Empty;
			lblMessage.Text = string.Empty;
			if (!string.IsNullOrEmpty(txtDescription.Text.Trim()))
				msg = BO.Description(gridDescripcion.DataSourceID, lblIdEntity.Text, txtDescription.Text.Trim(), out status);
			else
				status = 8;
			cleanEv();
			util.CleanControls(pnDescription);
			util.ErroDisplay(status, msg, ref lblMessage);
			gridDescripcion.Rebind();
			txtDescription.Text = string.Empty;
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
	}
	#endregion

	#region Grid KeyValue
	protected void gridDescValue_DataBinding(object sender, EventArgs e)
	{
		switch (gridDescValue.DataSourceID)
		{
			case "sqlDSExchangeType":
				gridDescValue.Columns[3].HeaderText = "Inicial";
				break;
			case "sqlDSTaskGroup":
				gridDescValue.Columns[3].HeaderText = "Grupo";
				break;
			case "sqlDSTask":
				gridDescValue.Columns[3].HeaderText = "Área de Tarea";
				break;
		}
	}

	protected void gridDescValue_ItemCommand(object sender, GridCommandEventArgs e)
	{
		try
		{
			lblMessage.Text = string.Empty;
			IDictionary itemValues = new Dictionary<object, object>();
			var item = (Telerik.Web.UI.GridDataItem)e.Item;
			int id = int.Parse(gridDescValue.Items[item.ItemIndex]["Id"].Text);
			if (e.CommandName == "editId")
			{
				lblIdEntity.Text = gridDescValue.Items[item.ItemIndex]["Id"].Text;
				txtDescriptionKV.Text = gridDescValue.Items[item.ItemIndex]["sDesc1"].Text;
				txtValueKV.Text = gridDescValue.Items[item.ItemIndex]["sDesc2"].Text;
			}
			if (e.CommandName == "deleteId")
			{
				util.GetActionMenu(mpMenu.SelectedItem.Value);
				BO.DeleteKeyValue(gridDescValue.DataSourceID, id);
				gridDescValue.Rebind();
			}
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
		catch (Exception ex)
		{

		}
	}

	protected void btnCancelKV_Click(object sender, EventArgs e)
	{
		cleanEv();
		util.CleanControls(pnKeyValue);
	}

	protected void btnAddKV_Click(object sender, EventArgs e)
	{
		byte status = 0;
		string msg = string.Empty;
		lblMessage.Text = string.Empty;
		try
		{
			util.GetActionMenu(mpMenu.SelectedItem.Value);
			switch (gridDescValue.DataSourceID)
			{
				case "sqlDSExchangeType":
					if (txtValueKV.Text.Trim().Length > 3)
						msg = BO.KeyValue(gridDescValue.DataSourceID, lblIdEntity.Text, txtDescriptionKV.Text.Trim(),
					                  txtValueKV.Text.Trim().Substring(0, 3), out status);
					else
						msg = BO.KeyValue(gridDescValue.DataSourceID, lblIdEntity.Text, txtDescriptionKV.Text.Trim(),
														txtValueKV.Text.Trim(), out status);
					break;
				case "sqlDSTask":
					string desc = txtDescriptionKV.Text.Trim();
					if (txtDescriptionKV.Text.Trim().Length > 500)
						msg = BO.KeyValue(gridDescValue.DataSourceID, lblIdEntity.Text, txtDescriptionKV.Text.Trim().Substring(0, 500),
														util.DefaultCombo(ddlAreaTask, "Tarea - Area"), out status);
					else
						msg = BO.KeyValue(gridDescValue.DataSourceID, lblIdEntity.Text, txtDescriptionKV.Text.Trim(),
														util.DefaultCombo(ddlAreaTask, "Tarea - Area"), out status);
					break;
				case "sqlDSTaskGroup":
					msg = BO.KeyValue(gridDescValue.DataSourceID, lblIdEntity.Text, util.DefaultCombo(ddlTaskTaskGroup, "Grupo Tarea"),
														util.DefaultCombo(ddlGroupTaskGroup, "Grupo Tarea"), out status);
					break;
			}
			cleanEv();
			util.CleanControls(pnKeyValue);
			util.ErroDisplay(status, msg, ref lblMessage);
			gridDescValue.Rebind();
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

	#region Grid Triara
	protected void gridTriara_DataBinding(object sender, EventArgs e)
	{
		switch (gridTriara.DataSourceID)
		{
			case "sqlDSPartList":
				gridTriara.Columns[3].HeaderText = "No. Parte DS";
				gridTriara.Columns[4].HeaderText = "No. Parte Cliente";
				break;
			case "sqlDSArea":
				gridTriara.Columns[3].HeaderText = "Número";
				gridTriara.Columns[4].HeaderText = "Responsable de Área";
				break;
			case "sqlDSTaskData":
				gridTriara.Columns[3].HeaderText = "Tarea";
				gridTriara.Columns[4].HeaderText = "Tipo de Dato";
				break;
		}
	}

	protected void gridTriara_ItemCommand(object sender, GridCommandEventArgs e)
	{
		try
		{
			lblMessage.Text = string.Empty;
			IDictionary itemValues = new Dictionary<object, object>();
			var item = (Telerik.Web.UI.GridDataItem)e.Item;
			int id = int.Parse(gridTriara.Items[item.ItemIndex]["Id"].Text);
			if (e.CommandName == "editId")
			{
				lblIdEntity.Text = gridTriara.Items[item.ItemIndex]["Id"].Text;
				txtDescriptionTriara.Text = gridTriara.Items[item.ItemIndex]["sDesc1"].Text;
				txtNumberPartList.Text = gridTriara.Items[item.ItemIndex]["sDesc2"].Text;
				txtNumberPartListClient.Text = gridTriara.Items[item.ItemIndex]["sDesc3"].Text;
			}
			if (e.CommandName == "deleteId")
			{
				util.GetActionMenu(mpMenu.SelectedItem.Value);
				BO.DeleteTriara(gridTriara.DataSourceID, id);
				gridTriara.Rebind();
			}
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
		catch (Exception ex)
		{

		}
	}

	protected void btnCancelTriara_Click(object sender, EventArgs e)
	{
		cleanEv();
		util.CleanControls(pnTriara);
	}

	protected void btnAddTriara_Click(object sender, EventArgs e)
	{
		byte status = 0;
		string msg = string.Empty;
		lblMessage.Text = string.Empty;
		try
		{
			util.GetActionMenu(mpMenu.SelectedItem.Value);
			switch (gridTriara.DataSourceID)
			{
				case "sqlDSPartList":
					if ((string.IsNullOrEmpty(txtDescriptionTriara.Text.Trim())) ||
					    (string.IsNullOrEmpty(txtNumberPartList.Text.Trim())) ||
					    (string.IsNullOrEmpty(txtNumberPartListClient.Text.Trim())))
						status = 8;
					else
						msg = BO.Triara(gridTriara.DataSourceID, lblIdEntity.Text, txtDescriptionTriara.Text.Trim(),
						                txtNumberPartList.Text.Trim(), txtNumberPartListClient.Text, out status);
					break;
				case "sqlDSArea":
					Util.isNumeric(txtNumberPartList.Text.Trim(), "Número de Area");
					msg = BO.Triara(gridTriara.DataSourceID, lblIdEntity.Text, txtDescriptionTriara.Text.Trim(), txtNumberPartList.Text.Trim(),
														util.DefaultCombo(ddl_Triara3, "Responsable de Area"), out status);
					break;
				case "sqlDSTaskData":
					if ((string.IsNullOrEmpty(txtDescriptionTriara.Text.Trim())) ||
							(string.IsNullOrEmpty(util.DefaultCombo(ddl_Triara1, "Tarea Dato").Trim())) ||
							(string.IsNullOrEmpty(util.DefaultCombo(ddl_Triara2, "Tarea Dato").Trim())))
						status = 8;
					else
						msg = BO.Triara(gridTriara.DataSourceID, lblIdEntity.Text, txtDescriptionTriara.Text,
														util.DefaultCombo(ddl_Triara1, "Tarea Dato"),
														util.DefaultCombo(ddl_Triara2, "Tarea Dato"), out status);
					break;
			}
			cleanEv();
			util.CleanControls(pnTriara);
			util.ErroDisplay(status, msg, ref lblMessage);
			gridTriara.Rebind();
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
		catch (ArgumentException ae)
		{
			util.ErroDisplay(3, ae.Message, ref lblMessage);
		}
	}
	#endregion

	#region Eventos Empleados
	protected void gridEmpleado_ItemCommand(object sender, GridCommandEventArgs e)
	{
		try
		{
			lblMessage.Text = string.Empty;
			IDictionary itemValues = new Dictionary<object, object>();
			var item = (Telerik.Web.UI.GridDataItem)e.Item;
			int id = int.Parse(gridEmpleado.Items[item.ItemIndex]["Id"].Text);
			if (e.CommandName == "editId")
			{
				lblIdEntity.Text = gridEmpleado.Items[item.ItemIndex]["Id"].Text;
				txtNumberEmployed.Text = gridEmpleado.Items[item.ItemIndex]["iNumber"].Text;
				txtNameEmployed.Text = gridEmpleado.Items[item.ItemIndex]["sName"].Text;
				txtFatherLastName.Text = gridEmpleado.Items[item.ItemIndex]["sFLastName"].Text;
				txtMotherLastName.Text = gridEmpleado.Items[item.ItemIndex]["sMLastName"].Text;
				txtEmail.Text = gridEmpleado.Items[item.ItemIndex]["sEMail"].Text;
				ddlArea.SelectedValue = gridEmpleado.Items[item.ItemIndex]["iIdArea"].Text;
				ddlPlant.SelectedValue = gridEmpleado.Items[item.ItemIndex]["iIdPlant"].Text;
				
			}
			if (e.CommandName == "deleteId")
			{
				util.GetActionMenu(mpMenu.SelectedItem.Value);
				BO.DeleteEmployed(gridEmpleado.DataSourceID, id);
				gridEmpleado.Rebind();
			}
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
		catch (Exception ex)
		{

		}
	}

	protected void ddlArea_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
	{
		Combo(ddlSubstitute, int.Parse(ddlArea.SelectedValue));
		Combo(ddlBoss, int.Parse(ddlArea.SelectedValue));
	}

	protected void btnAddEmployed_Click(object sender, EventArgs e)
	{
		byte status = 0;
		string msg = string.Empty;
		lblMessage.Text = string.Empty;
		try
		{
			util.GetActionMenu(mpMenu.SelectedItem.Value);
			Util.validateEmail(txtEmail.Text.Trim());
			Util.isRequired(txtNumberEmployed.Text.Trim(), "Número de Empleado");
			Util.isRequired(txtNameEmployed.Text.Trim(), "Nombre de Empleado");
			Util.isRequired(txtMotherLastName.Text.Trim(), "Apellido Materno");
			Util.isRequired(txtFatherLastName.Text.Trim(), "Apellido Paterno");
			Util.isRequired(txtEmail.Text.Trim(), "eMail");
			msg = BO.Employed(lblIdEntity.Text,int.Parse(txtNumberEmployed.Text),txtNameEmployed.Text.Trim(),
						txtMotherLastName.Text.Trim(),txtFatherLastName.Text.Trim(),txtEmail.Text.Trim(),
						int.Parse(util.DefaultCombo(ddlArea, "Área")), int.Parse(util.DefaultCombo(ddlPlant, "Planta")), int.Parse(util.DefaultCombo(ddlBoss, "Jefe Asignado")), int.Parse(util.DefaultCombo(ddlSubstitute, "Sustituto Asignado")), out status);
			util.ErroDisplay(status, msg, ref lblMessage);
			gridEmpleado.Rebind();
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

	protected void btnCancelEmployed_Click(object sender, EventArgs e)
	{
		cleanEv();
		util.CleanControls(pnEmployed);
	}

	private employedCompositeType Empleado()
	{
		var ect = new employedCompositeType();
		try
		{
			Util.isRequired(ect.sName.Trim(), "Nombre");
			Util.isRequired(ect.sFLastName.Trim(), "Apellido Paterno");
			Util.isRequired(ect.sMLastName.Trim(), "Apellido Materno");
			Util.isRequired(ect.sEMail.Trim(), "E-mail");
			Util.validateEmail(ect.sEMail);

			Util.isRequired(txtNumberEmployed.Text.Trim(), "Número");
			Util.isNumeric(txtNumberEmployed.Text.Trim(), "Número");

			Util.isRequired(ddlArea.SelectedValue.ToString(), "Area");
			Util.isRequired(ddlPlant.SelectedValue.ToString(), "Planta");

			ect.iIdEmployed = int.Parse(lblIdEntity.Text.ToString());
			ect.sName = txtNameEmployed.Text.Trim();
			ect.sFLastName = txtFatherLastName.Text.Trim();
			ect.sMLastName = txtMotherLastName.Text.Trim();
			ect.sEMail = txtEmail.Text.Trim();
			ect.iIdArea = int.Parse(ddlArea.SelectedValue.ToString());
			ect.iIdPlant = int.Parse(ddlPlant.SelectedValue.ToString());
			ect.iNumber = int.Parse(txtNumberEmployed.Text.Trim());
			return ect;
		}
		catch (ArgumentException ae)
		{
			util.ErroDisplay(3, ae.Message, ref lblMessage);
			return null;
		}
		catch (Exception ex)
		{
			util.ErroDisplay(1, string.Empty, ref lblMessage);
			return null;
		}
	}
	#endregion

	private void cleanEv()
	{
		lblIdEntity.Text = string.Empty;
		lblMessage.Text = string.Empty;
	}

	private void Combo(RadComboBox combo, int area)
	{
		combo.Items.Clear();
		combo.DataSource = BO.GetBoss(area);
		combo.DataBind();
	}
}