using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using Telerik.Web.UI;
using BO = BOCAR.SACI.Business;

public partial class Cierre : System.Web.UI.Page
{
	private Utilerias util;

	protected void Page_Load(object sender, EventArgs e)
	{
		util = new Utilerias();
		try
		{
			if (!Page.IsPostBack)
				util.LoadMenu(Master.Page.Request.Url.Segments[Master.Page.Request.Url.Segments.Length - 1],
				              BOCAR.SACI.Business.SecurityManager.ObtenerUsuario(HttpContext.Current).IdRol, ref menuSolicitud);
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

	#region Folio
	
	private void LoadFolios()
	{
		lblCurrentFolio.Text = string.Empty;
		
		PanelDocumentos.Visible = false;
		PanelEstatus.Visible = false;
	}

	protected void imbSearch_Click(object sender, ImageClickEventArgs e)
	{
		LoadFolios();
	}

	protected void gridFolio_ItemCommand(object source, GridCommandEventArgs e)
	{
		string field = "IdFolio";
		string campo = "idLiberacion";
		if (e.CommandName == "ReviewFolio")
		{
			try
			{
				IDictionary itemValues = new Dictionary<object, object>();
				var item = (Telerik.Web.UI.GridDataItem)e.Item;
				item.ExtractValues(itemValues);
				itemValues[field] = item.OwnerTableView.DataKeyValues[item.ItemIndex][field].ToString();
				ViewState[field] = itemValues[field];
				ViewState[campo] = gridFolio.Items[item.ItemIndex][campo].Text;
				ViewState["Folio"] = gridFolio.Items[item.ItemIndex]["Folio"].Text;
				//Tiene Id de Release y estatus cerrado
				if ((int.Parse(gridFolio.Items[item.ItemIndex][campo].Text) > 0) && (gridFolio.Items[item.ItemIndex]["Estado"].Text == "Cerrado"))
					FolioCerrado(gridFolio.Items[item.ItemIndex]["Fecha"].Text);
				//Tiene Id de release y estatus diferente de cerrado
				else if ((int.Parse(gridFolio.Items[item.ItemIndex][campo].Text) > 0) && (gridFolio.Items[item.ItemIndex]["Estado"].Text != "Cerrado"))
					FolioAbierto();
				else if ((int.Parse(gridFolio.Items[item.ItemIndex][campo].Text) == 0) && (gridFolio.Items[item.ItemIndex]["Estado"].Text != "Cerrado"))
					FolioAbierto();
				lblCurrentFolio.Text = ViewState["Folio"].ToString();
				gridReporte.DataSource = null;
				PanelDocumentos.Visible = true;
				var folios = new BO.Cierre();
				gridReporte.DataSource = folios.GetArchivosByCierre(int.Parse(ViewState[campo].ToString()));
				gridReporte.DataBind();
			}
			catch (Exception ex)
			{
			}
		}
	}
	#endregion

	#region Transicion
	/// <summary>
	/// Este metodo se ocupa cuando el estatus esta cerrado, por lo cual solo se pueden agregar documentos
	/// </summary>
	/// <param name="sFecha">Fecha en la cual se cerro el folio</param>
	private void FolioCerrado(string sFecha)
	{
		PanelEstatus.Visible = false;
		PanelDocumentos.Visible = true;
		txtEstatus.Text = "Cerrado";
		txtFechaLiberacion.Text = sFecha;
	}

	/// <summary>
	/// Este método se ocupa cuando el folio no es cerrado y se cambia de estatus
	/// </summary>
	private void FolioAbierto()
	{
		PanelEstatus.Visible = true;
		PanelDocumentos.Visible = false;
		txtEstatus.Text = string.Empty;
		txtFechaLiberacion.Text = string.Empty;
	}

	/// <summary>
	/// Este método se ocupa cuando el folio no es cerrado y se agregan documentos
	/// </summary>
	/// <param name="sFecha">Fecha del cambio</param>
	/// <param name="sEstatus">Estatus al cual se agregaran documentos que lo respalden</param>
	private void FolioAbierto(string sFecha, string sEstatus)
	{
		PanelEstatus.Visible = false;
		PanelDocumentos.Visible = true;
		txtEstatus.Text = sEstatus;
		txtFechaLiberacion.Text = sFecha;
	}
	#endregion

	#region Estatus
	protected void comboEstatus_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
	{
		if (comboEstatus.Items[comboEstatus.SelectedIndex].Text == "Cerrado")
		{
			txtFecha.Visible = true;
			calFecha.Visible = false;
			txtFecha.Text = System.DateTime.Now.Date.ToShortDateString();
		}
		else
		{
			txtFecha.Visible = false;
			calFecha.Visible = true;
		}
	}

	protected void btnRelease_Click(object sender, EventArgs e)
	{
		try
		{
			util.GetActionMenu(menuSolicitud.SelectedItem.Value);
			//Se valida que exista un folio seleccionado
			if (ViewState["IdFolio"] != null)
			{
				var folios = new BO.Cierre();
				var dt = new DataTable();
        var dtFechaMov = (calFecha.SelectedDate.ToString() == "") ? txtFecha.Text : calFecha.SelectedDate.ToString();
				//SE intenta generar un id de release
				int pendientes = 0;
				dt = folios.Get_Release (int.Parse(ViewState["IdFolio"].ToString()), dtFechaMov, txtObservacion.Text.Trim(), int.Parse(comboEstatus.SelectedValue), comboEstatus.Items[comboEstatus.SelectedIndex].Text, ref pendientes, decimal.Parse(txtCostoReal.Text));
				//Si se genera un id de release, se puede ingresar documentos
				if ((pendientes == 0) && (int.Parse(dt.Rows[0][0].ToString()) != 0))
				{
					ViewState["Release"] = dt.Rows[0][0];
					txtEstatus.Text = gridFolio.Items[0]["Estado"].Text;
					txtFechaLiberacion.Text = gridFolio.Items[0]["Fecha"].Text;
					PanelEstatus.Visible = false;
					PanelDocumentos.Visible = true;
				}
				else if (pendientes != 0)
					lblMsg.Text = "El folio presenta tareas que no han finalizado, no se puede continuar con la operación";
				else if (int.Parse(dt.Rows[0][0].ToString()) == 0)
					lblMsg.Text = "Hay un error a procesar la solicitud.";
				gridFolio.DataBind();
			}
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}		
	}
	#endregion

	#region Documentos
	protected void btnDocumentos_Click(object sender, EventArgs e)
	{
		var folios = new BO.Cierre();
		int registro = 0;
		try
		{
			util.GetActionMenu(menuSolicitud.SelectedItem.Value);
			string pathSave = ConfigurationManager.AppSettings["rutaLiberacion"] + "\\" + ViewState["IdFolio"].ToString();
			var dt = folios.Get_RegFile(int.Parse(ViewState["IdFolio"].ToString()), int.Parse(ViewState["Release"].ToString()), txtDescDocumento.Text, RadAsyncUpload1.UploadedFiles[0].FileName, pathSave);
			registro = int.Parse(dt.Rows[0][0].ToString());
			gridReporte.DataSource = null;
			if (registro > 0)
			{
				util.AccessDocument(pathSave);
				RadAsyncUpload1.UploadedFiles[0].SaveAs(dt.Rows[0][1].ToString());
				gridReporte.DataSource = folios.GetArchivosByCierre(int.Parse(ViewState["Release"].ToString()));
			}
			else
				folios.Del_RegFile(registro);
			gridFolio.DataBind();
			gridReporte.DataBind();
			PanelEstatus.Visible = false;
			PanelDocumentos.Visible = true;
		}
		catch (AccessViolationException ave)
		{
			Alert.Permisos(this.Page);
		}
		catch (Exception ex)
		{
			if (registro > 0)
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
				var item = (Telerik.Web.UI.GridDataItem)e.Item;
				item.ExtractValues(itemValues);
				string ruta = string.Empty;
				HttpContext contexto = HttpContext.Current;
				if (util.DownloadFile(ViewState["IdFolio"].ToString(), 3, gridReporte.Items[item.ItemIndex]["fvaddress_file"].Text, ref ruta))
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
}