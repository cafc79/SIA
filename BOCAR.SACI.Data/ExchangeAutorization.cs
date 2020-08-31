using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BOCAR.SACI.Data
{
	public class ExchangeAutorization : IExchangeAutorization
	{
		private SqlParameter[] param;

		private ClassDB objDB = new ClassDB();
		private List<ExchangeAutorizationCompositeType> ls = new List<ExchangeAutorizationCompositeType>();

		#region ExchangeAutorization Methods

		#region Insert

		public errorCompositeType InsertExchangeAutorization(ExchangeAutorizationCompositeType eact)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[5];
				param[0] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) {Value = eact.iIdExchange};
				param[1] = new SqlParameter("@fiid_review_type_eng", SqlDbType.Int) {Value = eact.iIdReviewTypeEng};
				param[2] = new SqlParameter("@fvEngObservation", SqlDbType.VarChar) { Value = eact.sEngObsevations };
				param[3] = new SqlParameter("@fiid_review_type_adm", SqlDbType.Int) {Value = eact.iIdReviewTypeAdm};
				param[4] = new SqlParameter("@fvobservation", SqlDbType.VarChar) {Value = eact.sObsevations};
				objDB.ExecStoredIUD("sp_insertExchangeAutorization", param);
				lstError.bError = true;
				return lstError;
			}
			catch (Exception ex)
			{
				lstError.bError = false;
				lstError.sError = ex.Message;
				return lstError;
			}
		}

		#endregion

		#region update

		public errorCompositeType UpdateExchangeAutorization(ExchangeAutorizationCompositeType eact)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[5];
				param[0] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) { Value = eact.iIdExchange };
				param[1] = new SqlParameter("@fiid_review_type_eng", SqlDbType.Int) { Value = eact.iIdReviewTypeEng };
				param[2] = new SqlParameter("@fvEngObservation", SqlDbType.VarChar) { Value = eact.sEngObsevations };
				param[3] = new SqlParameter("@fiid_review_type_adm", SqlDbType.Int) { Value = eact.iIdReviewTypeAdm };
				param[4] = new SqlParameter("@fvobservation", SqlDbType.VarChar) { Value = eact.sObsevations };
				objDB.ExecStoredIUD("sp_updateExchangeAutorization", param);
				lstError.bError = true;
				return lstError;
			}
			catch (Exception ex)
			{
				lstError.bError = false;
				lstError.sError = ex.Message;
				return lstError;
			}
		}

		#endregion

		#region Select

		public int GetExchangeAutorizationByIdCount(int idExchange)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) {Value = idExchange};
			return int.Parse(objDB.ExecStore("sp_selectCountExchangeAutorizationByIdExchange", param).Rows[0].ItemArray[0].ToString());
		}

		public ExchangeAutorizationCompositeType GetExchangeAutorizationById(int idExchange)
		{
			try
			{
				var et = new ExchangeAutorizationCompositeType();
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) {Value = idExchange};
				DataTable dt = objDB.ExecStore("sp_selectExchangeAutorizationByIdExchange", param);
				if (dt.Rows.Count > 0)
				{
					et.iIdExchangeAutorization = int.Parse(dt.Rows[0].ItemArray[0].ToString());
					et.iIdExchange = int.Parse(dt.Rows[0].ItemArray[1].ToString());
					et.iIdReviewTypeAdm = int.Parse(dt.Rows[0].ItemArray[3].ToString());
					et.iIdReviewTypeEng = int.Parse(dt.Rows[0].ItemArray[2].ToString());
					et.bStatus = bool.Parse(dt.Rows[0].ItemArray[4].ToString());
					et.sIdReviewTypeEng = dt.Rows[0].ItemArray[5].ToString();
					et.sEngObsevations = dt.Rows[0].ItemArray[6].ToString();
					et.sIdReviewTypeAdm = dt.Rows[0].ItemArray[7].ToString();
					et.sObsevations = dt.Rows[0].ItemArray[8].ToString();
					et.iIngeniero = int.Parse(dt.Rows[0].ItemArray[9].ToString());
					et.iIngenieroSup = int.Parse(dt.Rows[0].ItemArray[10].ToString());
					et.iGerente = int.Parse(dt.Rows[0].ItemArray[11].ToString());
					return et;
				}
				else
					return null;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<string> GetInforAutorizacionIng(int iIdExchange)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) { Value = iIdExchange };
			var data = objDB.ExecStore("sp_InforAutorizacionIngenieria", param);
			return data.Rows.Count == 1 ? new List<string> { data.Rows[0].ItemArray[0].ToString(), data.Rows[0].ItemArray[1].ToString() } : null;
		}
		#endregion

		#endregion
	}
}