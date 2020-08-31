using System;
using System.Data;
using System.Web.Security;
using DS.SAI.Data;

namespace DS.SAI.Business
{
	public class UserManager
	{
		public UserManager() { }

		public DataTable GetUsers()
		{
			var swap = new UserManager();
			return swap.GetUsuarios();
		}

		public string Usuario(string iIdUser, int iIdEmployed, String sUserName, String sPassword, Boolean bStatus, int iUserRol, out byte status)
		{
			int id = 0;
			if (!string.IsNullOrEmpty(iIdUser))
				id = int.Parse(iIdUser);
			if (id == 0)
			{
				if (ExistuserDuplicate(iIdEmployed, sUserName))
				{
					status = 3;
					return "El nombre de usuario ya ha sido asignado o el empleado ya tienen usuario en el sistema";
				}
				else
				{
					AddUser(iIdEmployed, sUserName, sPassword, iUserRol);
				}
				status = 5;
				return string.Empty;
			}
			else
			{
				UpdateUser(id, iIdEmployed, sUserName, sPassword, bStatus, iUserRol);
				status = 6;
				return string.Empty;
			}
			status = (byte)0;
			return null;
		}

		public void AddUser(int iIdEmployed, String sUserName, String sPassword, int iUserRol)
		{
			try
			{
				var ut = new User();
				ut.InsertUser(iIdEmployed, sUserName, FormsAuthentication.HashPasswordForStoringInConfigFile(sPassword, "sha1"), iUserRol);
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public void DeleteUser(int iIdUser)
		{
			try
			{
				var ut = new User();
				ut.DeleteUser(iIdUser);
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public DataTable GetUsuarios()
		{
			var ut = new User();
			return ut.GetUsuarios();
		}
		
		public void UpdateUser(int iIdUser, int iIdEmployed, String sUserName, String sPassword, Boolean bStatus, int iUserRol)
		{
			try
			{
				var et = new User();
				et.UpdateUser(iIdUser, iIdEmployed, sUserName, FormsAuthentication.HashPasswordForStoringInConfigFile(sPassword, "sha1"), bStatus, iUserRol);
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public bool ExistuserDuplicate(int iIdEmployed, String sUserName)
		{
			var a = new User();
			if (a.getCountUserDuplicate(iIdEmployed, sUserName) > 0)
				return true;
			else
				return false;
		}

		public bool ExistEmployedFormat(String sTextEmployed)
		{
			var et = new employedCompositeType();
			var em = new EmployedManager();
			int iIdEmployed = Util.SeparaID_AutoComplete(sTextEmployed);
			et = iIdEmployed > 0 ? em.getEmployedById(iIdEmployed) : null;
			bool exist = et != null;
			return exist;
		}
	}
}