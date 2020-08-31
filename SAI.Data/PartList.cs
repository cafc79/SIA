using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DS.SAI.Data
{
	public class PartList : IPartList
	{
		private SqlParameter[] param;

		private ClassDB objDB = new ClassDB();
		private List<PartListCompositeType> ls = new List<PartListCompositeType>();

		#region PartList Methods

		#region Insert
		/// <summary>
		/// Inserta un Motivo(PartListType) en la base de datos
		/// </summary>
		/// <param name="sDescription">La descripción</param>
		public errorCompositeType InsertPartList(String iNumber, String sDescription, String iNumberClient)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[4];
				param[0] = new SqlParameter("@finumber_part_list", SqlDbType.VarChar) {Value = iNumber};
				param[1] = new SqlParameter("@fvdescription_part_list", SqlDbType.VarChar) {Value = sDescription};
				param[2] = new SqlParameter("@fbstatus_part_list", SqlDbType.Bit) {Value = true};
				param[3] = new SqlParameter("@finumber_client", SqlDbType.VarChar) {Value = iNumberClient};
				objDB.ExecStoredIUD("sp_insertPartList", param);
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

		public errorCompositeType DeletePartList(int iIdPartList)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_part_list", SqlDbType.Int) {Value = iIdPartList};
				objDB.ExecStoredIUD("sp_deletePartList", param);
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

		public errorCompositeType UpdatePartList(int iIdPartList, String iNumber, String sDescription, String iPartListClient)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[4];
				param[0] = new SqlParameter("@fiid_part_list", SqlDbType.Int) {Value = iIdPartList};
				param[1] = new SqlParameter("@fvnumber_part_DS", SqlDbType.VarChar) {Value = iNumber};
				param[2] = new SqlParameter("@fvaffectation_part", SqlDbType.VarChar) {Value = sDescription};
				param[3] = new SqlParameter("@finumber_part_client", SqlDbType.VarChar) {Value = iPartListClient};
				objDB.ExecStore("sp_updatePartList", param);
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
		public List<PartListCompositeType> getAll()
		{
			var lst = new List<PartListCompositeType>();
			DataTable dt = objDB.Consult("sp_selectPartList");
			foreach (DataRow dr in dt.Rows)
			{
				var et = new PartListCompositeType
				         	{
				         		iIdPart = int.Parse(dr.ItemArray[0].ToString()),
				         		iNumber = dr.ItemArray[1].ToString(),
				         		sDescription = dr.ItemArray[2].ToString(),
				         		bStatus = bool.Parse(dr.ItemArray[4].ToString()),
				         		iNumberClient = dr.ItemArray[3].ToString()
				         	};
				lst.Add(et);
			}
			return lst;
		}

		public PartListCompositeType GetPartListById(int iIdPartList)
		{
			var et = new PartListCompositeType();
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_part_list", SqlDbType.Int) {Value = iIdPartList};
			DataTable dt = objDB.ExecStore("sp_getPartListById", param);
			et.iIdPart = int.Parse(dt.Rows[0].ItemArray[0].ToString());
			et.iNumber = dt.Rows[0].ItemArray[1].ToString();
			et.sDescription = dt.Rows[0].ItemArray[2].ToString();
			et.bStatus = bool.Parse(dt.Rows[0].ItemArray[4].ToString());
			et.iNumberClient = dt.Rows[0].ItemArray[3].ToString();
			return et;
		}

		public int getCountPartListByNumber(int iNumber)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@finumber_part_list", SqlDbType.Int) {Value = iNumber};
			return int.Parse(objDB.ExecStore("sp_countPartListByNumber", param).Rows[0].ItemArray[0].ToString());
		}

		public int getCountPartListDuplicate(int iIdPartList, String sDescription, String iNumber, String iNumberClient)
		{
			param = new SqlParameter[4];
			param[0] = new SqlParameter("@fiid_part_list", SqlDbType.Int) { Value = iIdPartList };
			param[1] = new SqlParameter("@fvnumber_part_DS", SqlDbType.VarChar) {Value = iNumber};
			param[2] = new SqlParameter("@fvAffectation_part", SqlDbType.VarChar) {Value = sDescription};
			param[3] = new SqlParameter("@finumber_part_client", SqlDbType.VarChar) {Value = iNumberClient};
			return int.Parse(objDB.ExecStore("sp_countPartListDuplicate", param).Rows[0].ItemArray[0].ToString());
		}
		#endregion
		#endregion
	}
}