using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DS.SAI.Data
{
	public class SalesAutorization
	{
		private SqlParameter[] param;

		private ClassDB objDB = new ClassDB();
		
		#region Sales Autorization_Type

		public void Insert_SalesAutorization_Type(String sDescription)
		{
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@iSales", SqlDbType.Int) { Value = 0 };
				param[1] = new SqlParameter("@vSalesDesc", SqlDbType.VarChar) { Value = sDescription };
				objDB.ExecStoredIUD("sp_insertSalesAutorization_Type", param);
		}
		
		public void Delete_SalesAutorization_Type(int iSales)
		{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@iSales", SqlDbType.Int) { Value = iSales };
				objDB.ExecStoredIUD("sp_deleteSalesAutorization_Type", param);
		}

		public DataTable GetAll()
		{
			return objDB.Consult("sp_selectSalesAutorization_Type");
		}

		public bool ExistSales(int iSales, string sDescription)
		{
			var dt = GetAll();
			var swap = dt.Rows.Cast<DataRow>().ToDictionary(dr => int.Parse(dr.ItemArray[0].ToString()), dr => dr.ItemArray[1].ToString());
			return swap.ContainsValue(sDescription);
		}

		#endregion

		#region Sales Autorization

		public void Insert_SalesAutorization(int iExchange, int iEmpleado, int iUsuario, int iAutorizacion, string sComentarios)
		{
			param = new SqlParameter[5];
			param[0] = new SqlParameter("@iExchange", SqlDbType.Int) { Value = iExchange };
			param[1] = new SqlParameter("@iEmpleado", SqlDbType.Int) { Value = iEmpleado };
			param[2] = new SqlParameter("@iUsuario", SqlDbType.Int) { Value = iUsuario };
			param[3] = new SqlParameter("@iAutorizacion", SqlDbType.Int) { Value = iAutorizacion };
			param[4] = new SqlParameter("@vComentarios", SqlDbType.VarChar) { Value = sComentarios };
			objDB.ExecStoredIUD("sp_insertSalesAutorization", param);
		}

		public DataRow GetSalesAutorization(int iExchange)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@iExchange", SqlDbType.Int) { Value = iExchange };
			return objDB.ExecStore("sp_selectSalesAutorization", param).Rows[0];
		}
		#endregion
	}
}