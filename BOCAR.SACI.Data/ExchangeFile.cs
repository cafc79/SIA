using System;
using System.Data;
using System.Data.SqlClient;

namespace BOCAR.SACI.Data
{
	public class ExchangeFile : IExchangeFile
	{
		private ClassDB objDB = new ClassDB();

		#region Insert

		public errorCompositeType InsertTaskExchange(ExchangeFileCompositeType etct)
		{
			var lstError = new errorCompositeType();
			try
			{
				var param = new SqlParameter[4];
				param[0] = new SqlParameter("@fvlabel_file", SqlDbType.VarChar) {Value = etct.sLabel};
				param[1] = new SqlParameter("@fvaddress_file", SqlDbType.VarChar) {Value = etct.sURL};
				param[2] = new SqlParameter("@fiid_file_type", SqlDbType.Int) {Value = etct.iTiype};
				param[3] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) {Value = etct.iExchange};
				objDB.ExecStoredIUD("sp_insertFileExchange", param);
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
	}
}