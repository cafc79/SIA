using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BOCAR.SACI.Data
{
	public class AffectationType : IAffectationType
	{
		private SqlParameter[] param;
		private ClassDB objDB = new ClassDB();
		private List<affectationTypeCompositeType> ls = new List<affectationTypeCompositeType>();

		#region AffectationType Methods

		#region Insert

		public errorCompositeType InsertAffectationType(String sDescription)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@fvdescription_affectation_type", SqlDbType.VarChar) {Value = sDescription};
				param[1] = new SqlParameter("@fbstatus_affectation_type", SqlDbType.Bit) {Value = true};
				objDB.ExecStoredIUD("sp_insertAffectationType", param);
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

		public errorCompositeType DeleteAffectationType(int iIdAffectationType)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_affectation_type", SqlDbType.Int) {Value = iIdAffectationType};
				objDB.ExecStoredIUD("sp_deleteAffectationType", param);
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

		public errorCompositeType UpdateAffectationType(int iIdAffectationType, String sDescription)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@fiid_affectation_type", SqlDbType.Int) {Value = iIdAffectationType};
				param[1] = new SqlParameter("@fvdescription_affectation_type", SqlDbType.VarChar) {Value = sDescription};
				objDB.ExecStore("sp_updateAffectationType", param);
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
		public List<affectationTypeCompositeType> getAll()
		{
			var lst = new List<affectationTypeCompositeType>();
			DataTable dt = objDB.Consult("sp_selectAffectationType");
			foreach (DataRow dr in dt.Rows)
			{
				var et = new affectationTypeCompositeType
				         	{
				         		iIdAffectationType = int.Parse(dr.ItemArray[0].ToString()),
				         		sDescription = dr.ItemArray[1].ToString(),
				         		bStatus = bool.Parse(dr.ItemArray[2].ToString())
				         	};
				lst.Add(et);
			}
			return lst;
		}

		public affectationTypeCompositeType GetAffectationTypeById(int iIdAffectationType)
		{
			var et = new affectationTypeCompositeType();
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_affectation_type", SqlDbType.Int) {Value = iIdAffectationType};
			DataTable dt = objDB.ExecStore("sp_getAffectationTypeById", param);
			et.iIdAffectationType = int.Parse(dt.Rows[0].ItemArray[0].ToString());
			et.sDescription = dt.Rows[0].ItemArray[1].ToString();
			et.bStatus = bool.Parse(dt.Rows[0].ItemArray[2].ToString());
			return et;
		}

		/*
			public int getCountAffectationTypeByDescription(String sDescription)
			{
					param = new SqlParameter[1];
					param[0] = new SqlParameter("@fvdescription_affectation_type", SqlDbType.VarChar);
					param[0].Value = sDescription;

					
					DataTable dt = objDB.ExecStore("sp_countAffectationTypeByDescription", param);
					
					return int.Parse(dt.Rows[0].ItemArray[0].ToString());
			}

			public int getCountAffectationTypeByDescription(String sDescription, int iIdAffectationType)
			{
					param = new SqlParameter[2];
					param[0] = new SqlParameter("@fvdescription_affectation_type", SqlDbType.VarChar);
					param[0].Value = sDescription;
					param[1] = new SqlParameter("@fiid_affectation_type", SqlDbType.Int);
					param[1].Value = iIdAffectationType;

					
					DataTable dt = objDB.ExecStore("sp_countAffectationTypeByDescriptionId", param);
					
					return int.Parse(dt.Rows[0].ItemArray[0].ToString());
			}
		*/

		public int getCountAffectationTypeDuplicate(int iIdAffectationType, String sDescription)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@fiid_affectation_type", SqlDbType.Int) {Value = iIdAffectationType};
			param[1] = new SqlParameter("@fvdescription_affectation_type", SqlDbType.VarChar) {Value = sDescription};
			return int.Parse(objDB.ExecStore("sp_countAffectationTypeDuplicate", param).Rows[0].ItemArray[0].ToString());
		}

		#endregion

		#endregion
	}
}