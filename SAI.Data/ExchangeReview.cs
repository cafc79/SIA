using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DS.SAI.Data
{
	public class ExchangeReview : IExchangeReview
	{
		private SqlParameter[] param;
		private ClassDB objDB = new ClassDB();

		#region ExchangeReview Methods

		#region Insert

		public errorCompositeType InsertExchangeReview(ExchangeReviewCompositeType erct)
		{
			var lstError = new errorCompositeType();
			try
			{
				bool bStatus = true;
				param = new SqlParameter[4];
				param[0] = new SqlParameter("@fvobservation_review_Exchange", SqlDbType.VarChar) {Value = erct.sDescription};
				param[1] = new SqlParameter("@fiid_review_type", SqlDbType.Int) {Value = erct.iIdReviewType};
				param[2] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) {Value = erct.iIdExchange};
				param[3] = new SqlParameter("@fiid_user", SqlDbType.Int) {Value = erct.iIdUser};
				objDB.ExecStoredIUD("sp_insertReviewExchange", param);
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

		#region Update

		public errorCompositeType UpdateExchangeReview(ExchangeReviewCompositeType erct)
		{
			var lstError = new errorCompositeType();
			try
			{
				bool bStatus = true;
				param = new SqlParameter[3];
				param[0] = new SqlParameter("@fvobservation_review_Exchange", SqlDbType.VarChar) {Value = erct.sDescription};
				param[1] = new SqlParameter("@fiid_review_type", SqlDbType.Int) {Value = erct.iIdReviewType};
				param[2] = new SqlParameter("@fiid_review_exchange", SqlDbType.Int) {Value = erct.iIdReviewExchange};
				objDB.ExecStoredIUD("sp_updateReviewExchange", param);
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

		public List<ExchangeReviewCompositeType> getAll(int iIdExchange)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) {Value = iIdExchange};
			var dt = objDB.ExecStore("sp_selectReviewExchangeByIdExchange", param);
			return (from DataRow dr in dt.Rows
			        select new ExchangeReviewCompositeType
			               	{
			               		iIdReviewExchange = int.Parse(dr.ItemArray[0].ToString()), sDescription = dr.ItemArray[1].ToString(), iIdReviewType = int.Parse(dr.ItemArray[2].ToString()), iIdExchange = int.Parse(dr.ItemArray[3].ToString()), iIdUser = int.Parse(dr.ItemArray[4].ToString()), bStatus = bool.Parse(dr.ItemArray[5].ToString()), sReview = dr.ItemArray[6].ToString(), sCompleteName = dr.ItemArray[7].ToString()
			               	}).ToList();
		}

		public int GetExchangeReviewByIdCount(int idExchange)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) {Value = idExchange};
			return int.Parse(objDB.ExecStore("sp_selectCountReviewExchangeByIdExchange", param).Rows[0].ItemArray[0].ToString());
		}

		public int GetExchangeReviewByIdCount(int idExchange, int iIdUser)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) {Value = idExchange};
			param[1] = new SqlParameter("@fiid_user", SqlDbType.Int) {Value = iIdUser};
			return int.Parse(objDB.ExecStore("sp_selectCountReviewExchangeByIdExchangeIdUser", param).Rows[0].ItemArray[0].ToString());
		}

		public ExchangeReviewCompositeType GetExchangeReviewById(int idExchange, int iIdUser)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) {Value = idExchange};
			param[1] = new SqlParameter("@fiid_user", SqlDbType.Int) {Value = iIdUser};
			var dt = objDB.ExecStore("sp_selectReviewExchangeByIdExchangeIdUser", param);
			var erct = new ExchangeReviewCompositeType
			           	{
			           		iIdReviewExchange = int.Parse(dt.Rows[0].ItemArray[0].ToString()),
			           		sDescription = dt.Rows[0].ItemArray[1].ToString(),
			           		iIdReviewType = int.Parse(dt.Rows[0].ItemArray[2].ToString()),
			           		iIdExchange = int.Parse(dt.Rows[0].ItemArray[3].ToString()),
			           		iIdUser = int.Parse(dt.Rows[0].ItemArray[4].ToString()),
			           		bStatus = bool.Parse(dt.Rows[0].ItemArray[5].ToString()),
			           		sReview = dt.Rows[0].ItemArray[6].ToString(),
			           		sCompleteName = dt.Rows[0].ItemArray[7].ToString()
			           	};
			return erct;
		}

		public ExchangeReviewCompositeType GetExchangeReviewByIdReviewExchange(int idReviewExchange)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_review_exchange", SqlDbType.Int) {Value = idReviewExchange};
			DataTable dt = objDB.ExecStore("sp_selectReviewExchangeByIdReviewExchange", param);
			var erct = new ExchangeReviewCompositeType
			           	{
			           		iIdReviewExchange = int.Parse(dt.Rows[0].ItemArray[0].ToString()),
			           		sDescription = dt.Rows[0].ItemArray[1].ToString(),
			           		iIdReviewType = int.Parse(dt.Rows[0].ItemArray[2].ToString()),
			           		iIdExchange = int.Parse(dt.Rows[0].ItemArray[3].ToString()),
			           		iIdUser = int.Parse(dt.Rows[0].ItemArray[4].ToString()),
			           		bStatus = bool.Parse(dt.Rows[0].ItemArray[5].ToString()),
			           		sReview = dt.Rows[0].ItemArray[6].ToString(),
			           		sCompleteName = dt.Rows[0].ItemArray[7].ToString()
			           	};
			return erct;
		}
		#endregion

		#endregion
	}
}