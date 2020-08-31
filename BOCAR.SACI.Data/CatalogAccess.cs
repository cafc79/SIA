using System;
using System.Data;
using System.Data.SqlClient;

namespace BOCAR.SACI.Data
{
	public class CatalogAccess
	{
		private SqlParameter[] param;
		private ClassDB objDB = new ClassDB();

		public void DeleteDescription(string stp, string sParametro, int iId)
		{
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter(sParametro, SqlDbType.Int) { Value = iId };
				objDB.ExecStoredIUD(stp, param);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable GetBoss(int iArea)
		{
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_area", SqlDbType.Int) { Value = iArea };
				return objDB.ExecStore("sp_ddlEmployedbyArea", param);
			}
			catch
			{
				throw new Exception();
			}
		}
	}
}