using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BOCAR.SACI.Data
{
	public class Priority : IPriority
	{
		private SqlParameter[] param;
		private ClassDB objDB = new ClassDB();

		#region Priority Methods

		#region Insert

		public errorCompositeType InsertPriority(String sDescription)
		{
			var lstError = new errorCompositeType();
			try
			{
				bool bStatus = true;
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@fvdescription_priority", SqlDbType.VarChar) {Value = sDescription};
				param[1] = new SqlParameter("@fbstatus_priority", SqlDbType.Bit) {Value = true};
				objDB.ExecStoredIUD("sp_insertPriority", param);
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

		public errorCompositeType DeletePriority(int iIdPriority)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_priority", SqlDbType.Int) {Value = iIdPriority};
				objDB.ExecStoredIUD("sp_deletePriority", param);
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

		public errorCompositeType UpdatePriority(int iIdPriority, String sDescription)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@fiid_priority", SqlDbType.Int) {Value = iIdPriority};
				param[1] = new SqlParameter("@fvdescription_priority", SqlDbType.VarChar) {Value = sDescription};
				objDB.ExecStore("sp_updatePriority", param);
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
		public List<PriorityCompositeType> getAll()
		{
			DataTable dt = objDB.Consult("sp_selectPriority");
			return (from DataRow dr in dt.Rows
			        select new PriorityCompositeType
			               	{
			               		iIdPriority = int.Parse(dr.ItemArray[0].ToString()),
			               		sDescription = dr.ItemArray[1].ToString(),
			               		bStatus = bool.Parse(dr.ItemArray[2].ToString())
			               	}).ToList();
		}

		public PriorityCompositeType GetPriorityById(int iIdPriority)
		{
			
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_priority", SqlDbType.Int) {Value = iIdPriority};
			DataTable dt = objDB.ExecStore("sp_getPriorityById", param);
			var et = new PriorityCompositeType
			         	{
			         		iIdPriority = int.Parse(dt.Rows[0].ItemArray[0].ToString()),
			         		sDescription = dt.Rows[0].ItemArray[1].ToString(),
			         		bStatus = bool.Parse(dt.Rows[0].ItemArray[2].ToString())
			         	};
			return et;
		}

		public int getCountPriorityDuplicate(int iIdPriority, String sDescription)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@fiid_priority", SqlDbType.Int) {Value = iIdPriority};
			param[1] = new SqlParameter("@fvdescription_priority", SqlDbType.VarChar) {Value = sDescription};
			return int.Parse(objDB.ExecStore("sp_countPriorityDuplicate", param).Rows[0].ItemArray[0].ToString());
		}

		#endregion

		#endregion
	}
}