using System;
using BOCAR.SACI.Business;

namespace Services
{
	public partial class Requerimiento : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (Request.QueryString["ex"] != null)
					selectedExchange(int.Parse(Request.QueryString["ex"]));
			}
			catch(Exception ex)
			{
			
			}
		}

		private void selectedExchange(int iIdExchange)
		{
			var em = new ExchangeManager();
			var ex = em.GetRequerimiento(iIdExchange);
			if (ex != null)
			{
				ddlExchange.Text = ex.ItemArray[2].ToString();
				if (!bool.Parse(ex.ItemArray[3].ToString())) ddlExchange.Attributes.Add("style", "color:#FF0000");
				ddlPriority.Text = ex.ItemArray[4].ToString();
				if (!bool.Parse(ex.ItemArray[5].ToString())) ddlPriority.Attributes.Add("style", "color:#FF0000");
				ddlSerie.Text = ex.ItemArray[6].ToString();
				if (!bool.Parse(ex.ItemArray[7].ToString())) ddlSerie.Attributes.Add("style", "color:#FF0000");
				ddlPlant.Text = ex.ItemArray[8].ToString();
				if (!bool.Parse(ex.ItemArray[9].ToString())) ddlPlant.Attributes.Add("style", "color:#FF0000");
				ddlClient.Text = ex.ItemArray[10].ToString();
				if (!bool.Parse(ex.ItemArray[11].ToString())) ddlExchange.Attributes.Add("style", "color:#FF0000");
				txtLastFolio.Text = ex.ItemArray[12].ToString();
				if (Request.QueryString["mod"] != null && Request.QueryString["mod"] == "ExchangeNote")
				{
					lblLimitDate.Text = "Fecha de Inicio de Cambio";
					if (ex.ItemArray[14].ToString() != string.Empty)
						txtLimitDate.Text = DateTime.Parse(ex.ItemArray[14].ToString()).ToShortDateString().ToString();
				}
				else
				{
					lblLimitDate.Text = "Fecha de Limite de Cotización";
					if (ex.ItemArray[13].ToString() != string.Empty)
						txtLimitDate.Text = DateTime.Parse(ex.ItemArray[13].ToString()).ToShortDateString().ToString();	
				}
				txtProyectPlataformDescription.Text = ex.ItemArray[15].ToString();
				txtDescription.Text = ex.ItemArray[16].ToString();
				txtIssue.Text = ex.ItemArray[17].ToString();
				txtReason.Text = ex.ItemArray[18].ToString();
				txtAction.Text = ex.ItemArray[19].ToString();
				ddlEngeenerProduct.Text = ex.ItemArray[21].ToString();
				if (ex.ItemArray[22].ToString() == "0") ddlExchange.Attributes.Add("style", "color:#FF0000");
				lblEngeneer.ToolTip = ex.ItemArray[23].ToString();
				txtContact.Text = ex.ItemArray[20].ToString();
			}		
		}
	}
}