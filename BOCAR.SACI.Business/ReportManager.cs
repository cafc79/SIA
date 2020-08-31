using System;
using System.Data;
using DA = BOCAR.SACI.Data;

namespace BOCAR.SACI.Business
{
	public class ReportManager
	{
		private DA.ReportAccess datos;

		public ReportManager()
		{
			datos = new DA.ReportAccess();
		}

		public DataTable Get_V1(string sComando, object iIdArea, object sFolio, object sPreFolio, object dFechaIni, object dFechaFin)
		{
			try
			{
				if (sComando == "repOperArea")
				{
						return datos.GetAreaOperativa(iIdArea, sFolio, sPreFolio, dFechaIni, dFechaFin);
				}
				return null;
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable Get_V2(string sComando, int iCliente, object dFechaIni, object dFechaFin)
		{
			try
			{
				switch (sComando)
				{
					case "repEjecCostos":
						return datos.GetComparativaTiempo(iCliente, dFechaIni, dFechaFin);
						break;
					case "repEjecTiempos":
						return datos.GetComparativaCostos(iCliente, dFechaIni, dFechaFin);
						break;
					case "repEjecClientes":
						return datos.GetCambiosCliente(iCliente, dFechaIni, dFechaFin);
						break;
					case "repAudiPinterno":
						return datos.GetAvisosAuditoria(iCliente, dFechaIni, dFechaFin);
						break;
				}
				return null;
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable GetExchangeDocsOp(string sPreFolio, string sFolio)
		{
			return datos.GetExchangeDocsOp(sPreFolio, sFolio);
		}

		public DataTable GetExchangeDocsOp(int iExchange)
		{
			return datos.GetExchangeDocsOp(iExchange);
		}
	}
}
