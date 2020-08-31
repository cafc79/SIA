using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using Telerik.Web.UI;

public partial class Services_Soporte : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected void gvDocuments_ItemCommand(object sender, GridCommandEventArgs e)
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
				var util = new Utilerias();
				if (util.DownloadFile(gvDocuments.Items[item.ItemIndex]["iExchange"].Text, 1,
				                      gvDocuments.Items[item.ItemIndex]["sLabel"].Text, ref ruta))
				{
					ruta = ruta.Substring(ruta.IndexOf("/")+1);
					Response.Redirect(ruta, false);
				}
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
}