using System;
using System.Data;
using System.Data.SqlClient;

namespace DS.SAI.Data
{
	public class BuzonAccess
	{
		private SqlParameter[] param;
		private ClassDB objDB;
			
		public BuzonAccess() {
			objDB = new ClassDB();
		}

		public DataTable GetMessages(int iUsuario)
		{
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@iUsuario", SqlDbType.Int) { Value = iUsuario };
				return objDB.ExecStore("sp_selectGetMessages", param);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataView GetMessagesActive(int iUsuario)
		{
			try
			{
				var dt = GetMessages(iUsuario);
				var results = from myRow in dt.AsEnumerable()
											where myRow.Field<bool>("fbStatus") == true
											select myRow;
				return results.AsDataView();
			}
			catch
			{
				throw new Exception();
			}
		}

		public void ReviewMessages(int iUsuario, int iMessage)
		{
			try
			{
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@iMensaje", SqlDbType.Int) { Value = iMessage };
				param[1] = new SqlParameter("@iUsuario", SqlDbType.Int) { Value = iUsuario };
				objDB.ExecStoredIUD("sp_deleteMessage", param);
			}
			catch
			{
				throw new Exception();
			}
		}

		public void DeleteConfigBuzon(int iConfiguracion)
		{
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@Configuracion", SqlDbType.Int) { Value = iConfiguracion };
				objDB.ExecStore("sp_deleteConfigBuzon", param);
			}
			catch
			{
				throw new Exception();
			}
		}
		
		public void InsertConfigBuzon(int iModulo, string sPages, string sArea, string sUsuario)
		{
			try
			{
				param = new SqlParameter[4];
				param[0] = new SqlParameter("@Modulo", SqlDbType.Int) { Value = iModulo };
				param[1] = new SqlParameter("@Stage", SqlDbType.VarChar) { Value = sPages };
				param[2] = new SqlParameter("@Area", SqlDbType.VarChar) { Value = sArea };
				param[3] = new SqlParameter("@Usuario", SqlDbType.VarChar) { Value = sUsuario };
				objDB.ExecStore("sp_InsertConfigBuzon", param);
			}
			catch
			{
				throw new Exception();
			}
		}
	}
}
