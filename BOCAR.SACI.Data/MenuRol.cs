using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BOCAR.SACI.Data
{
	public class MenuRol
	{
		private SqlParameter[] param;
		private ClassDB objDB = new ClassDB();


		public void InsertUserRol(string sRol, int iModulo, string lstMenuRol, string sPermisos)
		{
			try
			{
				param = new SqlParameter[4];
				param[0] = new SqlParameter("@sRol", SqlDbType.VarChar) {Value = sRol};
				param[1] = new SqlParameter("@iModulo", SqlDbType.Int) { Value = iModulo };
				param[2] = new SqlParameter("@lstMenuRol", SqlDbType.VarChar) { Value = lstMenuRol };
				param[3] = new SqlParameter("@sPermisos", SqlDbType.VarChar) { Value = sPermisos };
				objDB.ExecStoredIUD("sp_insertMenuxRol", param);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<menuRolCompositeType> GetMenuRolById(int iRol)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiRol", SqlDbType.SmallInt) {Value = iRol};
			DataTable dt = objDB.ExecStore("sp_selectMenuRol", param);
			return (from DataRow dr in dt.Rows
			        select new menuRolCompositeType
			               	{
			               		iIdMenu = int.Parse(dr.ItemArray[0].ToString()), 
												sDescription = dr.ItemArray[1].ToString(), 
												sModulo = dr.ItemArray[2].ToString()
			               	}).ToList();
		}

		public List<menuCompositeType> GetMenuPagina(int iIdMenu, int iIdRol)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@fiMenu", SqlDbType.SmallInt) { Value = iIdMenu };
			param[1] = new SqlParameter("@fiRol", SqlDbType.SmallInt) { Value = iIdRol };
			DataTable dt = objDB.ExecStore("sp_selectMenuPaginaRol", param);
			return (from DataRow dr in dt.Rows
							select new menuCompositeType
							{
								sURL = dr.ItemArray[0].ToString(),
								sDescription = dr.ItemArray[1].ToString(),
								sPermission = dr.ItemArray[2].ToString(),
								sPermisos = dr.ItemArray[3].ToString()
							}).ToList();
		}

		public void DeleteRol_Schema(int iRol, int iModulo, string sPagina)
		{
			try
			{
				param = new SqlParameter[3];
				param[0] = new SqlParameter("@rol", SqlDbType.Int) { Value = iRol };
				param[1] = new SqlParameter("@module", SqlDbType.Int) { Value = iModulo };
				param[2] = new SqlParameter("@page", SqlDbType.VarChar) { Value = sPagina };
				objDB.ExecStoredIUD("sp_deleteRolModulePage", param);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		#region Select
		public List<RolCompositeType> getAll()
		{
			var lst = new List<RolCompositeType>();
			DataTable dt = objDB.Consult("sp_selectRol");
			foreach (DataRow dr in dt.Rows)
			{
				var et = new RolCompositeType
																{
																	iIdRol = int.Parse(dr.ItemArray[0].ToString()),
																	dRegistry = DateTime.Parse(dr.ItemArray[2].ToString()),
																	sDescription = dr.ItemArray[1].ToString(),
																	bStatus = bool.Parse(dr.ItemArray[3].ToString())
																};
				lst.Add(et);
			}
			return lst;
		}

		public DataTable GetMenuPaginas(short iMenu)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiMenu", SqlDbType.Int) { Value = iMenu };
			return objDB.ExecStore("sp_selectMenuPagina", param);
		}

		public RolCompositeType GetRolById(int iIdRol)
		{
			var et = new RolCompositeType();
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiRol", SqlDbType.Int) { Value = iIdRol };
			var dt = objDB.ExecStore("sp_getRolById", param);
			et.iIdRol = int.Parse(dt.Rows[0].ItemArray[0].ToString());
			et.sDescription = dt.Rows[0].ItemArray[1].ToString();
			return et;
		}

		public int getCountRolDuplicate(int iIdRol, String sDescription)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@fiRol", SqlDbType.Int) { Value = iIdRol };
			param[1] = new SqlParameter("@fvdescription", SqlDbType.VarChar) { Value = sDescription };
			DataTable dt = objDB.ExecStore("sp_countRolDuplicate", param);
			return int.Parse(dt.Rows[0].ItemArray[0].ToString());
		}
		#endregion
	}

	public class menuRolCompositeType
	{
		public int iIdMenu { get; set; }
		public int iIdRol { get; set; }
		public Boolean bStatus { get; set; }
		public string sDescription { get; set; }
		public string sModulo { get; set; }
	}
}