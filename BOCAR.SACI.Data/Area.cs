using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BOCAR.SACI.Data //prueba con Mileydis....yhoda
{
	public class Area : IArea
	{
		private SqlParameter[] param;

		private ClassDB objDB = new ClassDB();

		#region Area Methods

		#region Insert

		/// <summary>
		/// Inserta un Tipo de Cambio(area) en la base de datos
		/// </summary>
		/// <param name="sDescription">La descripción</param>
		public errorCompositeType InsertArea(String sDescription, int iNumber, int iResponsable)
		{
			errorCompositeType lstError = new errorCompositeType();

			try
			{
				bool bStatus = true;
				param = new SqlParameter[3];
				param[0] = new SqlParameter("@fvdescription_area", SqlDbType.VarChar) {Value = sDescription};
				param[1] = new SqlParameter("@finumber_area", SqlDbType.Int) {Value = iNumber};
				param[2] = new SqlParameter("@fiManager", SqlDbType.Int) {Value = iResponsable};
				objDB.ExecStoredIUD("sp_insertArea", param);
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

		/// <summary>
		/// Hace el borrado logico de un area a cero.
		/// </summary>
		/// <param name="iIdArea">id del area a eliminar</param>
		/// <returns></returns>
		public errorCompositeType DeleteArea(int iIdArea)
		{
			errorCompositeType lstError = new errorCompositeType();

			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_area", SqlDbType.Int);
				param[0].Value = iIdArea;
				objDB.ExecStoredIUD("sp_deleteArea", param);
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

		public errorCompositeType UpdateArea(int iIdArea, String sDescription, int iNumber, int iResponsable)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[4];
				param[0] = new SqlParameter("@fiid_area", SqlDbType.Int) {Value = iIdArea};
				param[1] = new SqlParameter("@fvdescription_area", SqlDbType.VarChar) {Value = sDescription};
				param[2] = new SqlParameter("@finumber_area", SqlDbType.Int) {Value = iNumber};
				param[3] = new SqlParameter("@fiManager", SqlDbType.Int) { Value = iResponsable };
				objDB.ExecStore("sp_updateArea", param);
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
		public List<areaCompositeType> getAll()
		{
			List<areaCompositeType> lst = new List<areaCompositeType>();
			DataTable dt = objDB.Consult("sp_selectArea");
			foreach (DataRow dr in dt.Rows)
			{
				areaCompositeType et = new areaCompositeType();
				et.iIdArea = int.Parse(dr.ItemArray[0].ToString());
				et.sDescription = dr.ItemArray[1].ToString();
				et.iNumber = int.Parse(dr.ItemArray[2].ToString());
				et.bStatus = bool.Parse(dr.ItemArray[3].ToString());

				lst.Add(et);
			}
			return lst;
		}

		public areaCompositeType GetAreaById(int iIdArea)
		{
			areaCompositeType et = new areaCompositeType();
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_area", SqlDbType.Int);
			param[0].Value = iIdArea;
			DataTable dt = objDB.ExecStore("sp_getAreaById", param);
			et.iIdArea = int.Parse(dt.Rows[0].ItemArray[0].ToString());
			et.sDescription = dt.Rows[0].ItemArray[1].ToString();
			et.iNumber = int.Parse(dt.Rows[0].ItemArray[2].ToString());
			et.bStatus = bool.Parse(dt.Rows[0].ItemArray[3].ToString());
			return et;
		}

		public int getCountArea(String sDescription)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fvdescription_area", SqlDbType.VarChar);
			param[0].Value = sDescription;
			DataTable dt = objDB.ExecStore("sp_countAreaByDescription", param);
			return int.Parse(dt.Rows[0].ItemArray[0].ToString());
		}

		public int getCountArea(int iNumber)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@finumber_area", SqlDbType.Int);
			param[0].Value = iNumber;
			DataTable dt = objDB.ExecStore("sp_countAreaByNumber", param);
			return int.Parse(dt.Rows[0].ItemArray[0].ToString());
		}

		public int getCountArea(int iNumber, String sDescription, int iIdArea)
		{
			param = new SqlParameter[3];
			param[0] = new SqlParameter("@finumber_area", SqlDbType.Int);
			param[0].Value = iNumber;
			param[1] = new SqlParameter("@fiid_area", SqlDbType.Int);
			param[1].Value = iIdArea;
			param[2] = new SqlParameter("@fvdescription_area", SqlDbType.VarChar);
			param[2].Value = sDescription;
			DataTable dt = objDB.ExecStore("sp_countAreaByDescriptionNumerId", param);

			return int.Parse(dt.Rows[0].ItemArray[0].ToString());
		}

		public int getCountAreaDuplicate(int iIdArea, String sDescription, int iNumber)
		{
			param = new SqlParameter[3];
			param[0] = new SqlParameter("@finumber_area", SqlDbType.Int) {Value = iNumber};
			param[1] = new SqlParameter("@fiid_area", SqlDbType.Int) {Value = iIdArea};
			param[2] = new SqlParameter("@fvdescription_area", SqlDbType.VarChar) {Value = sDescription};
			DataTable dt = objDB.ExecStore("sp_countAreaDuplicate", param);

			return int.Parse(dt.Rows[0].ItemArray[0].ToString());
		}

		#endregion

		#endregion

	}
}