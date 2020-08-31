using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BOCAR.SACI.Data
{
	public class ReviewType : IReviewType
	{
		private SqlParameter[] param;
		private ClassDB objDB = new ClassDB();

		#region ReviewType Methods

		#region Insert

		public errorCompositeType InsertReviewType(String sDescription)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				bool bStatus = true;
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@fvdescription_review_type", SqlDbType.VarChar) {Value = sDescription};
				param[1] = new SqlParameter("@fbstatus_review_type", SqlDbType.Bit) {Value = bStatus};
				objDB.ExecStoredIUD("sp_insertReviewType", param);
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

		public errorCompositeType DeleteReviewType(int iIdReviewType)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_review_type", SqlDbType.Int) {Value = iIdReviewType};
				objDB.ExecStoredIUD("sp_deleteReviewType", param);
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

		public errorCompositeType UpdateReviewType(int iIdReviewType, String sDescription)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@fiid_review_type", SqlDbType.Int) {Value = iIdReviewType};
				param[1] = new SqlParameter("@fvdescription_review_type", SqlDbType.VarChar) {Value = sDescription};
				objDB.ExecStore("sp_updateReviewType", param);
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

		/// <summary>
		/// Obtiene todos los Tipos de Cambio
		/// </summary>
		/// <returns></returns>
		public List<reviewTypeCompositeType> getAll()
		{
			var dt = objDB.Consult("sp_selectReviewType");
			return (from DataRow dr in dt.Rows
			        select new reviewTypeCompositeType
			               	{
			               		iIdReviewType = int.Parse(dr.ItemArray[0].ToString()), sDescription = dr.ItemArray[1].ToString(), bStatus = bool.Parse(dr.ItemArray[2].ToString())
			               	}).ToList();
		}

		public reviewTypeCompositeType GetReviewTypeById(int iIdReviewType)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_review_type", SqlDbType.Int) {Value = iIdReviewType};
			DataTable dt = objDB.ExecStore("sp_getReviewTypeById", param);
			var et = new reviewTypeCompositeType
			                             	{
			                             		iIdReviewType = int.Parse(dt.Rows[0].ItemArray[0].ToString()),
			                             		sDescription = dt.Rows[0].ItemArray[1].ToString(),
			                             		bStatus = bool.Parse(dt.Rows[0].ItemArray[2].ToString())
			                             	};
			return et;
		}

		public int getCountReviewTypeDuplicate(int iIdReviewType, String sDescription)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@fiid_review_type", SqlDbType.Int) {Value = iIdReviewType};
			param[1] = new SqlParameter("@fvdescription_review_type", SqlDbType.VarChar) {Value = sDescription};
			return int.Parse(objDB.ExecStore("sp_countReviewTypeDuplicate", param).Rows[0].ItemArray[0].ToString());
		}
		#endregion

		#endregion
	}
}