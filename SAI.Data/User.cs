using System;
using System.Data;
using System.Data.SqlClient;

namespace DS.SAI.Data
{
	public class User
	{
		private SqlParameter[] param;
		private ClassDB objDB;

		public User()
		{
			objDB = new ClassDB();
		}

		public void InsertUser(int iIdEmployed, String sUserName, String sPassword, int iUserRol)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[4];
				param[0] = new SqlParameter("@fiid_employed", SqlDbType.Int) { Value = iIdEmployed };
				param[1] = new SqlParameter("@fvuser_name", SqlDbType.VarChar) { Value = sUserName };
				param[2] = new SqlParameter("@fvpassword", SqlDbType.VarChar) { Value = sPassword };
				param[3] = new SqlParameter("@fiRol", SqlDbType.Int) { Value = iUserRol };
				objDB.ExecStoredIUD("sp_insertUser", param);
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
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_User", SqlDbType.Int) {Value = iIdUser};
				objDB.ExecStoredIUD("sp_deleteUser", param);
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public void UpdateUser(int iIdUser, int iIdEmployed, String sUserName, String sPassword, Boolean bStatus, int iUserRol)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[6];
				param[0] = new SqlParameter("@fiid_user", SqlDbType.Int) { Value = iIdUser };
				param[1] = new SqlParameter("@fiid_employed", SqlDbType.Int) { Value = iIdEmployed };
				param[2] = new SqlParameter("@fvuser_name", SqlDbType.VarChar) { Value = sUserName };
				param[3] = new SqlParameter("@fvpassword", SqlDbType.VarChar) { Value = sPassword };
				param[4] = new SqlParameter("@fbLock", SqlDbType.Bit) { Value = bStatus };
				param[5] = new SqlParameter("@fiRol", SqlDbType.Int) { Value = iUserRol };
				objDB.ExecStoredIUD("sp_updateUser", param);
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public DataTable GetUsuarios()
		{
			try
			{
				return objDB.ExecStore("sp_selectUserAll", null);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataRow GetUserById(int iIdUser)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@piid_User", SqlDbType.Int) {Value = iIdUser};
			return objDB.ExecStore("sp_getUserById", param).Rows[0];
		}

		public int getCountUserDuplicate(int iIdEmployed, String sUserName)
		{
			try
			{
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@fiid_employed", SqlDbType.Int) {Value = iIdEmployed};
				param[1] = new SqlParameter("@fvuser_name", SqlDbType.VarChar) {Value = sUserName};
				var dt = objDB.ExecStore("sp_countUserDuplicate", param);
				return int.Parse(dt.Rows[0].ItemArray[0].ToString());
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public DataRow ValidarAcceso(string PsUsuario, string PsPassword)
		{
			try
			{
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@fv_UserName", SqlDbType.VarChar) {Value = PsUsuario};
				param[1] = new SqlParameter("@fv_Password", SqlDbType.VarChar) {Value = PsPassword};
				var dt = objDB.ExecStore("sp_selectTAUser", param);
				if (dt.Rows.Count == 0)
					throw new ApplicationException("El usuario no existe o esta deshabilitado");
				else
					return dt.Rows[0];
			}
			catch (ApplicationException ae)
			{
				throw new ApplicationException(ae.Message);
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public void LogonAttempts(string sUserName, Boolean bLock, int iLogonAttempts)
		{
			try
			{
				param = new SqlParameter[3];
				param[0] = new SqlParameter("@fvuser_name", SqlDbType.VarChar) {Value = sUserName};
				param[1] = new SqlParameter("@fbLock", SqlDbType.Bit) {Value = bLock};
				param[2] = new SqlParameter("@piLongonAttempts", SqlDbType.TinyInt) {Value = iLogonAttempts};
				objDB.ExecStoredIUD("sp_updateUserLogonAttempts", param);
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}
	}
}