using System;
using System.Data;
using System.Data.SqlClient;

namespace DS.SAI.Data
{
	public class Cierre
	{
		private SqlParameter[] param;
		private ClassDB objDB = new ClassDB();

		public DataTable GetFolios(String sFolio)
		{
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@strFolio", SqlDbType.VarChar) {Value = sFolio};
				return objDB.ExecStore("sp_selectReleaseClientExchange", param);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable Get_Release(int iFolio, string fLiberacion, string sObservaciones, int iEstatus, decimal iCostoReal)
		{
			try
			{
				param = new SqlParameter[5];
				param[0] = new SqlParameter("@idFolio", SqlDbType.Int) {Value = iFolio};
				param[1] = new SqlParameter("@dtFechaLiberacion", SqlDbType.DateTime) {Value = fLiberacion};
				param[2] = new SqlParameter("@strObs", SqlDbType.VarChar) {Value = sObservaciones};
				param[3] = new SqlParameter("@intStNew", SqlDbType.Int) {Value = iEstatus};
        param[4] = new SqlParameter("@fi_CostoReal", SqlDbType.Decimal) { Value = iCostoReal };
				return objDB.ExecStore("sp_insertReleaseClientExchange", param);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable Get_RegFile(int iFolio, int iRelease, string sDescripcion, string sArchivo, string sRutaArchivo)
		{
			try
			{
				param = new SqlParameter[5];
				param[0] = new SqlParameter("@idFolio", SqlDbType.Int) {Value = iFolio};
				param[1] = new SqlParameter("@idRelease", SqlDbType.Int) {Value = iRelease};
				param[2] = new SqlParameter("@labelFile", SqlDbType.VarChar) {Value = sDescripcion};
				param[3] = new SqlParameter("@nameFile", SqlDbType.VarChar) {Value = sArchivo};
				param[4] = new SqlParameter("@addressFile", SqlDbType.VarChar) {Value = sRutaArchivo};
				return objDB.ExecStore("sp_insertFileRelease", param);
			}
			catch
			{
				throw new Exception();
			}
		}

		public void Del_RegFile(int iFile)
		{
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@idFile", SqlDbType.Int) {Value = iFile};
				objDB.ExecStoredIUD("sp_deleteFileRelease", param);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable GetArchivosByCierre(int iRelease)
		{
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@idRelease", SqlDbType.Int) {Value = iRelease};
				return objDB.ExecStore("sp_selectFileRelease", param);
			}
			catch
			{
				throw new Exception();
			}
		}
	}
}