using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BOCAR.SACI.Data
{
	public class ReportAccess
	{
		private SqlParameter[] param;
		private ClassDB objDB;

		public ReportAccess()
		{
			objDB = new ClassDB();
		}

		public DataTable GetAreaOperativa(object iIdArea, object sFolio, object sPreFolio, object dFechaIni, object dFechaFin)
		{
			try
			{
				param = new SqlParameter[5];
				param[0] = new SqlParameter("@idArea", SqlDbType.Int) { Value = iIdArea };
				param[1] = new SqlParameter("@strFolio", SqlDbType.VarChar) { Value = sFolio };
				param[2] = new SqlParameter("@strPreFolio", SqlDbType.VarChar) { Value = sPreFolio };
				param[3] = new SqlParameter("@fechaIni", SqlDbType.DateTime) { Value = dFechaIni };
				param[4] = new SqlParameter("@fechaFinal", SqlDbType.DateTime) { Value = dFechaFin };
				return objDB.ExecStore("sp_reportOperativeArea", param);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable GetComparativaTiempo(int iCliente, object dFechaIni, object dFechaFin)
		{
			try
			{
				param = new SqlParameter[3];
				param[0] = new SqlParameter("@idCliente", SqlDbType.Int) { Value = iCliente };
				param[1] = new SqlParameter("@fechaIni", SqlDbType.DateTime) { Value = dFechaIni };
				param[2] = new SqlParameter("@fechaFinal", SqlDbType.DateTime) { Value = dFechaFin };
				return objDB.ExecStore("sp_reportExecutiveTiming", param);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable GetComparativaCostos(object iCliente, object dFechaIni, object dFechaFin)
		{
			try
			{
				param = new SqlParameter[3];
				param[0] = new SqlParameter("@idCliente", SqlDbType.Int) { Value = iCliente };
				param[1] = new SqlParameter("@fechaIni", SqlDbType.DateTime) { Value = dFechaIni };
				param[2] = new SqlParameter("@fechaFinal", SqlDbType.DateTime) { Value = dFechaFin };
				return objDB.ExecStore("sp_reportExecutiveCost", param);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable GetCambiosCliente(object iCliente, object dFechaIni, object dFechaFin)
		{
			try
			{
				param = new SqlParameter[3];
				param[0] = new SqlParameter("@idCliente", SqlDbType.Int) { Value = iCliente };
				param[1] = new SqlParameter("@fechaIni", SqlDbType.DateTime) { Value = dFechaIni };
				param[2] = new SqlParameter("@fechaFinal", SqlDbType.DateTime) { Value = dFechaFin };
				return objDB.ExecStore("sp_reportExecutiveExchangeClient", param);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable GetAvisosAuditoria(object iNumParte, object dFechaIni, object dFechaFin)
		{
			try
			{
				param = new SqlParameter[3];
				param[0] = new SqlParameter("@intNumParte", SqlDbType.Int) { Value = iNumParte };
				param[1] = new SqlParameter("@fechaIni", SqlDbType.DateTime) { Value = dFechaIni };
				param[2] = new SqlParameter("@fechaFinal", SqlDbType.DateTime) { Value = dFechaFin };
				return objDB.ExecStore("sp_reportAudit", param);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable GetExchangeDocsOp(string sPreFolio, string sFolio)
		{
			try
			{
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@fvPrefolio", SqlDbType.VarChar) { Value = sPreFolio };
				param[1] = new SqlParameter("@fvFolio", SqlDbType.VarChar) { Value = sFolio };
				return objDB.ExecStore("sp_selectExchange_RepDocumentos", param);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable GetExchangeDocsOp(int iExchange)
		{
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@Exchange", SqlDbType.VarChar) { Value = iExchange };
				return objDB.ExecStore("sp_selectDocuments_byExchange", param);
			}
			catch
			{
				throw new Exception();
			}
		}
	}
}