using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BOCAR.SACI.Data
{
	public class TaskAutorization
	{
		private SqlParameter[] param;
		private ClassDB objDB = new ClassDB();
		private List<ExchangeReviewCompositeType> ls = new List<ExchangeReviewCompositeType>();

		#region Insert

		public void InsertTaskAutorizatio(int iIdExchange, int iArea, int iReview, string sObservaciones)
		{
			param = new SqlParameter[4];
			param[0] = new SqlParameter("@Exchange", SqlDbType.Int) { Value = iIdExchange };
			param[1] = new SqlParameter("@TasksArea", SqlDbType.Int) { Value = iArea };
			param[2] = new SqlParameter("@Review", SqlDbType.Int) { Value = iReview };
			param[3] = new SqlParameter("@Observaciones", SqlDbType.VarChar) { Value = sObservaciones };
			objDB.ExecStore("sp_insertTaskAutorization", param);
		}

		#endregion

		#region Select
		public DataTable GetAll(int iIdExchange)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@Exchange", SqlDbType.Int) { Value = iIdExchange };
			return objDB.ExecStore("sp_selectTaskAutorization", param);
		}

		public DataTable AreaPendiente(int iIdExchange, int iUsuario)
		{
			try
			{
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@exchange", SqlDbType.Int) { Value = iIdExchange };
				param[1] = new SqlParameter("@responsable", SqlDbType.Int) { Value = iUsuario };
				return objDB.ExecStore("sp_ddlAreaAutorizacionFaltante", param);
			}
			catch
			{
				throw new Exception();
			}
		}
		#endregion
	}
}
