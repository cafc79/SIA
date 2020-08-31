using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DeltaCore.DBConnect;

namespace DS.SAI.Data
{
	public class FolioSeguimiento : IFolioSeguimiento
	{
		private SqlParameter[] param;
		private ClassDB objDB = new ClassDB();

		public DataTable GetFolios(String sFolio, int iOption)
		{
			try
			{
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@strFolio", SqlDbType.VarChar) {Value = sFolio};
				param[1] = new SqlParameter("@intType", SqlDbType.Int) {Value = iOption};
				return objDB.ExecStore("sp_selectFolio", param);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable GetTareasByFolios(int iFolio, int iTarea)
		{
			try
			{
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@IdFolio", SqlDbType.Int) {Value = iFolio};
				param[1] = new SqlParameter("@idTask", SqlDbType.Int) {Value = iTarea};
				return objDB.ExecStore("sp_selectTaskFolio", param);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable GetArchivosByTareas(int iTarea, int iTaskExchange)
		{
			try
			{
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@idTask", SqlDbType.Int) {Value = iTarea};
				param[1] = new SqlParameter("@idFolioTask", SqlDbType.Int) {Value = iTaskExchange};
				return objDB.ExecStore("sp_selectFileTask", param);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable Get_RegFile(int iFolio, int iTarea, string sDocumento, string sArchivo, string sRutaArchivo)
		{
			try
			{
				param = new SqlParameter[5];
				param[0] = new SqlParameter("@idFolio", SqlDbType.Int) {Value = iFolio};
				param[1] = new SqlParameter("@idTask", SqlDbType.Int) {Value = iTarea};
				param[2] = new SqlParameter("@labelFile", SqlDbType.VarChar) {Value = sDocumento};
				param[3] = new SqlParameter("@nameFile", SqlDbType.VarChar) {Value = sArchivo};
				param[4] = new SqlParameter("@addressFile", SqlDbType.VarChar) {Value = sRutaArchivo};
				return objDB.ExecStore("sp_insertFileTask", param);
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
				objDB.ExecStore("sp_deleteFileTask", param);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable Get_CatTipoDocumentos()
		{
			try
			{
				return objDB.ExecStore("sp_deleteFileTask", null);
			}
			catch
			{
				throw new Exception();
			}
		}

		public object Set_FinishTask(int iTaskExchange)
		{
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@idFolioTask", SqlDbType.Int) {Value = iTaskExchange};
				return objDB.ExecStore("sp_insertFinishedTask", param);
			}
			catch
			{
				throw new Exception();
			}
		}

        public DataTable sqlDS_Folio(Dictionary<string, object> pDictionary)
        {
            var cnx = new SqlConexion(ConfigurationManager.ConnectionStrings["SAIConnectionString"].ConnectionString);

            try
            {
                return cnx.ExecStp("sp_selectFolio", pDictionary);
            }
            catch
            {
                throw new Exception();
            }
        }
	}
}