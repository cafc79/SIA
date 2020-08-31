using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BOCAR.SACI.Data
{
	public class Group : IGroup
	{
		private SqlParameter[] param;

		private ClassDB objDB = new ClassDB();
		private DataTable dt = new DataTable();
		private List<GroupCompositeType> ls = new List<GroupCompositeType>();

		#region Group Methods

		#region Insert

		public errorCompositeType InsertGroup(String sDescription)
		{
			errorCompositeType lstError = new errorCompositeType();

			try
			{
				bool bStatus = true;
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@fvdescription_group", SqlDbType.VarChar) {Value = sDescription};
				param[1] = new SqlParameter("@fbstatus_group", SqlDbType.Bit) {Value = bStatus};
				objDB.ExecStoredIUD("sp_insertGroup", param);
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

		public errorCompositeType DeleteGroup(int iIdGroup)
		{
			errorCompositeType lstError = new errorCompositeType();

			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_group", SqlDbType.Int);
				param[0].Value = iIdGroup;


				objDB.ExecStoredIUD("sp_deleteGroup", param);

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

		public errorCompositeType UpdateGroup(int iIdGroup, String sDescription)
		{
			errorCompositeType lstError = new errorCompositeType();

			try
			{
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@fiid_group", SqlDbType.Int);
				param[0].Value = iIdGroup;
				param[1] = new SqlParameter("@fvdescription_group", SqlDbType.VarChar);
				param[1].Value = sDescription;



				objDB.ExecStore("sp_updateGroup", param);

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
		public List<GroupCompositeType> getAll()
		{
			List<GroupCompositeType> lst = new List<GroupCompositeType>();
			DataTable dt = objDB.Consult("sp_selectGroup");
			foreach (DataRow dr in dt.Rows)
			{
				GroupCompositeType et = new GroupCompositeType();
				et.iIdGroup = int.Parse(dr.ItemArray[0].ToString());
				et.sDescription = dr.ItemArray[1].ToString();
				et.bStatus = bool.Parse(dr.ItemArray[2].ToString());
				lst.Add(et);
			}
			return lst;
		}

		public GroupCompositeType GetGroupById(int iIdGroup)
		{
			GroupCompositeType et = new GroupCompositeType();
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_group", SqlDbType.Int) { Value = iIdGroup };
			DataTable dt = objDB.ExecStore("sp_getGroupById", param);
			et.iIdGroup = int.Parse(dt.Rows[0].ItemArray[0].ToString());
			et.sDescription = dt.Rows[0].ItemArray[1].ToString();
			et.bStatus = bool.Parse(dt.Rows[0].ItemArray[2].ToString());
			return et;
		}

		/*
			public int getCountGroupByDescription(String sDescription)
			{
					param = new SqlParameter[1];
					param[0] = new SqlParameter("@fvdescription_group", SqlDbType.VarChar);
					param[0].Value = sDescription;

            
					DataTable dt = objDB.ExecStore("sp_countGroupByDescription", param);
            
					return int.Parse(dt.Rows[0].ItemArray[0].ToString());
			}

			public int getCountGroupByDescription(String sDescription, int iIdGroup)
			{
					param = new SqlParameter[2];
					param[0] = new SqlParameter("@fvdescription_group", SqlDbType.VarChar);
					param[0].Value = sDescription;
					param[1] = new SqlParameter("@fiid_group", SqlDbType.Int);
					param[1].Value = iIdGroup;

            
					DataTable dt = objDB.ExecStore("sp_countGroupByDescriptionId", param);
            
					return int.Parse(dt.Rows[0].ItemArray[0].ToString());
			}*/

		public int getCountGroupDuplicate(int iIdGroup, String sDescription)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@fiid_group", SqlDbType.Int) {Value = iIdGroup};
			param[1] = new SqlParameter("@fvdescription_group", SqlDbType.VarChar) {Value = sDescription};
			DataTable dt = objDB.ExecStore("sp_countGroupDuplicate", param);
			return int.Parse(dt.Rows[0].ItemArray[0].ToString());
		}

		#endregion

		#endregion
	}
}