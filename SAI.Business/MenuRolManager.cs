using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DS.SAI.Data;

namespace DS.SAI.Business
{
	public class MenuRolManager
	{
		public MenuRolManager() { }

		public void InsertUserRol(string sRol, int iModulo, List<string> lstMenuRol, string sPermisos)
		{
			try
			{
				var ut = new MenuRol();
				var sb = new System.Text.StringBuilder();
				foreach (string menuV in lstMenuRol)
					sb.AppendFormat("{0}|", menuV);
				ut.InsertUserRol(sRol, iModulo, sb.ToString().Substring(0, sb.ToString().Length-1), sPermisos);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<menuRolCompositeType> getAllMenuRol(int iIdRol)
		{
			var ut = new MenuRol();
			return ut.GetMenuRolById(iIdRol);
		}

		public RolCompositeType GetRolById(int iIdRol)
		{
			var ut = new MenuRol();
			return ut.GetRolById(iIdRol);
		}

		public DataTable GetMenuPagina(short iMenu)
		{
			var r = new MenuRol();
			return r.GetMenuPaginas(iMenu);
		}

		public List<menuCompositeType> GetMenuPagina(int iIdMenu, int iIdRol)
		{
			var r = new MenuRol();
			return r.GetMenuPagina(iIdMenu, iIdRol);
		}

		public bool ExistRol(string sDescription)
		{
			var chocorroles = new MenuRol();
			var swap = chocorroles.getAll();
			var qbo = (from s in swap where s.sDescription.Equals(sDescription) select s).Count();
			return qbo >= 1;
		}

		public void DeleteRol(int iRol, int iModulo, string sPage)
		{
			var r = new MenuRol();
			r.DeleteRol_Schema(iRol, iModulo, sPage);
		}
	}
}