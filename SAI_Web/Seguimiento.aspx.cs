using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BO = DS.SAI.Business;

public partial class Seguimiento : System.Web.UI.Page
{
	private Utilerias util;
	private const string field = "IdFolio";
    private System.Web.UI.WebControls.Menu mpMenu;

	protected void Page_Load(object sender, EventArgs e)
	{
        mpMenu = (System.Web.UI.WebControls.Menu)Master.FindControl("ChildrenMenu");
	}

	protected void btnHideOpSearch_Click(object sender, ImageClickEventArgs e)
	{
		btnDisplayOpSearch.Visible = true;
		btnHideOpSearch.Visible = false;
		rbListOpSearch.Visible = false;
	}

	protected void btnDisplayOpSearch_Click(object sender, ImageClickEventArgs e)
	{
		btnDisplayOpSearch.Visible = false;
		btnHideOpSearch.Visible = true;
		rbListOpSearch.Visible = true;
	}

	private void LoadTareas()
	{
		comboTareas.DataSource = sqlDSTareas;
		comboTareas.DataTextField = "descripcion";
		comboTareas.DataValueField = "id";
		comboTareas.DataBind();
	}

	private void ClearGrid(RadGrid grid)
	{
		grid.DataSource = null;
		grid.DataBind();
		if (grid.ID == "gridFolio")
		{
			ViewState["IdFolio"] = null;
			comboTareas.SelectedIndex = -1;
			ClearGrid(gridTareas);
		}
		if (grid.ID == "gridTareas")
		{
			txtDescDocumento.Enabled = false;
			RadAsyncUpload1.Enabled = false;
			btnGraba.Enabled = false;
			ViewState["IdTarea"] = null;
			ClearGrid(gridReporte);
		}
		if (grid.ID == "gridReporte")
		{
			txtDescDocumento.Text = string.Empty;
			RadAsyncUpload1.UploadedFiles.Clear();
		}
	}

	private void DatosInGrid(RadGrid grid, DataTable tabla)
	{
		ClearGrid(grid);
		grid.DataSource = tabla;
		grid.DataBind();
	}

	#region Folio

	protected void imbSearch_Click(object sender, ImageClickEventArgs e)
	{
		try
		{
			ClearGrid(gridFolio);
			var folios = new BO.FolioSeguimiento();
			lblCurrentFolio.Text = string.Empty;
		    DatosInGrid(gridFolio,
		                string.IsNullOrEmpty(txtSrchFolio.Text.Trim())
		                    ? folios.sqlDS_Folio("0", rbListOpSearch.SelectedValue)
		                    : folios.sqlDS_Folio(txtSrchFolio.Text.Trim(), rbListOpSearch.SelectedValue));
		}
		catch (Exception ex)
		{
			ClearGrid(gridFolio);
		}
	}

	/// <summary>
	/// Este método de evento, se encarga de tomar el IdFolio del registro seleccionado, y en base a ese registro, visualizar
	/// las tareas asociadas
	/// </summary>
	/// <param name="source"></param>
	/// <param name="e"></param>
	protected void gridFolio_ItemCommand(object source, GridCommandEventArgs e)
	{
		var folios = new BO.FolioSeguimiento();
		//Se valida que el comando sea el de revision
		if (e.CommandName == "ReviewFolio")
		{
			try
			{
				IDictionary itemValues = new Dictionary<object, object>();
				//Se toma el item del row
				var item = (Telerik.Web.UI.GridDataItem) e.Item;
				item.ExtractValues(itemValues);
				//Tomando el indice del item y el campo, se pasan los valores a una estructura llave-valor
                itemValues[field] = gridFolio.Items[item.ItemIndex][field].Text;
				//Con el valor del folio, se llama al método para realizar el display de las tareas sociadas al folio
				DatosInGrid(gridTareas, folios.GetTareasByFolios(int.Parse(itemValues[field].ToString()), null));
				//Si hubiesen datos, se borra el grid de documentos
				ClearGrid(gridReporte);
				//El valor del folio, se pone en viewState
				ViewState[field] = itemValues[field];
				//Se guarda el folio, que será pasado al label que funge como indicador del folio acutalmente seleccionado
				lblCurrentFolio.Text = gridFolio.Items[item.ItemIndex]["Folio"].Text;
				//Se carga los datos al combo de tareas
				LoadTareas();
			}
			catch (Exception ex)
			{
				ClearGrid(gridTareas);
			}
		}
		else
		{
            DatosInGrid(gridFolio, folios.sqlDS_Folio(txtSrchFolio.Text.Trim(), rbListOpSearch.SelectedValue));
		}

	}

	#endregion

	#region Tareas

	protected void comboTareas_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
	{
		var folios = new BO.FolioSeguimiento();
		try
		{
			DatosInGrid(gridTareas, folios.GetTareasByFolios(int.Parse(ViewState[field].ToString()), e.Value));
		}
		catch (Exception)
		{
			ClearGrid(gridTareas);
		}
	}

	protected void Tareas_CheckedChanged(object sender, System.EventArgs e)
	{
		ClearGrid(gridReporte);
		var chkBox = (sender as RadioButton);
		var myPanel = chkBox.Parent as Panel;
		var dataItem = myPanel.NamingContainer as GridDataItem;
		var folios = new BO.FolioSeguimiento();
		try
		{
			ViewState["IdTarea"] = dataItem["IdTarea"].Text;
			ViewState["IdTareaExchange"] = dataItem["fiid_task_exchange"].Text;
			DatosInGrid(gridReporte,
			            folios.GetArchivosByTareas(int.Parse(ViewState["IdTarea"].ToString()),
			                                       int.Parse(ViewState["IdTareaExchange"].ToString())));
			for (int i = 0; i <= gridTareas.Items.Count - 1; i++)
			{
				if (((RadioButton) gridTareas.Items[i].FindControl("rbtnSelect")).Checked)
					((RadioButton) gridTareas.Items[i].FindControl("rbtnSelect")).Checked = false;
			}
			chkBox.Checked = true;
			txtDescDocumento.Enabled = true;
			RadAsyncUpload1.Enabled = true;
			btnGraba.Enabled = true;
		}
		catch (Exception)
		{
			ClearGrid(gridReporte);
		}
	}

	protected void gridTarea_ItemDataBound(object sender, GridItemEventArgs e)
	{
		if (e.Item is GridDataItem)
		{
			var dataBoundItem = e.Item as GridDataItem;
			if (!string.IsNullOrEmpty(dataBoundItem["FechaTermino"].Text.Replace("&nbsp;", string.Empty).Trim()))
			{
				((ImageButton) dataBoundItem["TaskFinished"].FindControl("ibtnFolio")).ImageUrl = "~/Img/user_accept.png";
				((ImageButton) dataBoundItem["TaskFinished"].FindControl("ibtnFolio")).ToolTip = dataBoundItem["FechaTermino"].Text;
				((ImageButton) dataBoundItem["TaskFinished"].FindControl("ibtnFolio")).CommandName = string.Empty;
			}
			if (!string.IsNullOrEmpty(dataBoundItem["EnvioMail"].Text.Replace("&nbsp;", string.Empty).Trim()))
			{
				((ImageButton) dataBoundItem["EnvioMail"].FindControl("EnvioMail")).ToolTip = dataBoundItem["fd_sendDate"].Text;
			}
		}
	}

	protected void gridTarea_ItemCommand(object source, GridCommandEventArgs e)
	{
		string field = "fiid_task_exchange";
		var folios = new BO.FolioSeguimiento();
		//Se valida que el comando sea el de revision
		if (e.CommandName == "FinishTask")
		{
			try
			{
				IDictionary itemValues = new Dictionary<object, object>();
				//Se toma el item del row
				var item = (Telerik.Web.UI.GridDataItem) e.Item;
				item.ExtractValues(itemValues);
				HttpContext contexto = HttpContext.Current;
				folios.Set_FinishTask(BO.SecurityManager.ObtenerUsuario(contexto),
				                      gridTareas.Items[item.ItemIndex]["fiid_employed"].Text,
				                      int.Parse(gridTareas.Items[item.ItemIndex]["fiid_task_exchange"].Text));
				DatosInGrid(gridTareas, folios.GetTareasByFolios(int.Parse(ViewState["IdFolio"].ToString()), null));
			}
			catch (AccessViolationException ave)
			{
				Alert.Permisos(this.Page);
			}
			catch (Exception ex)
			{
				ClearGrid(gridTareas);
			}
		}
	}

	#endregion

	#region Documentos

	protected void btnGrabar_Click(object sender, EventArgs e)
	{
		var folios = new BO.FolioSeguimiento();
		int registro = 0;
		try
		{
            util.GetActionMenu(mpMenu.SelectedItem.Value);
			string pathSave = ConfigurationManager.AppSettings["rutaSeguimiento"] + "\\" + ViewState[field].ToString();
			var dt = folios.Get_RegFile(int.Parse(ViewState[field].ToString()), int.Parse(ViewState["IdTarea"].ToString()),
			                            txtDescDocumento.Text, RadAsyncUpload1.UploadedFiles[0].FileName, pathSave);
			registro = int.Parse(dt.Rows[0][0].ToString());
			if (registro > 0)
			{
				util.AccessDocument(pathSave);
				RadAsyncUpload1.UploadedFiles[0].SaveAs(dt.Rows[0][1].ToString());
				ClearGrid(gridReporte);
				DatosInGrid(gridReporte,
				            folios.GetArchivosByTareas(int.Parse(ViewState["IdTarea"].ToString()),
				                                       int.Parse(ViewState["IdTareaExchange"].ToString())));
				RadAsyncUpload1.UploadedFiles.Clear();
				txtDescDocumento.Text = string.Empty;
			}
			else
			{
				folios.Del_RegFile(registro);
				ClearGrid(gridReporte);
			}
		}
		catch (IOException ioe)
		{
			Alert.Show(ioe.Message, this.Page);	
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
		catch (Exception ex)
		{
			folios.Del_RegFile(registro);
		}
	}

	protected void gridReporte_ItemCommand(object source, GridCommandEventArgs e)
	{
		if (e.CommandName == "Download")
		{
			try
			{
				IDictionary itemValues = new Dictionary<object, object>();
				//Se toma el item del row
				var item = (Telerik.Web.UI.GridDataItem) e.Item;
				item.ExtractValues(itemValues);
				string ruta = string.Empty;
				HttpContext contexto = HttpContext.Current;
				if (util.DownloadFile(ViewState[field].ToString(), 2, gridReporte.Items[item.ItemIndex]["fvaddress_file"].Text,
				                      ref ruta))
					Response.Redirect(ruta, false);
				else
					Alert.Show("No se encuentra el archivo en la ruta especificada.", this.Page);
			}
			catch (Exception ex)
			{
				Alert.Show(
					"No se encuentra el archivo en la ruta especificada o no hay forma de obtener la informacón asociada al archivo solicitado",
					this.Page);
			}
		}
	}

	#endregion
}