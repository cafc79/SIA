using System;
using System.Data;
using System.Linq;
using System.Text;
using DS.SAI.Data;

namespace DS.SAI.Business
{
	public class SalesAutorizationManager
	{
		private SalesAutorization sa;

		
		public void Insert_SalesAutorization_Type(String sDescription)
		{
			sa = new SalesAutorization();
			sa.Insert_SalesAutorization_Type(sDescription);
		}

		public void Delete_SalesAutorization_Type(int iSales)
		{
			sa = new SalesAutorization();
			sa.Delete_SalesAutorization_Type(iSales);
		}

		public DataTable GetAll()
		{
			sa = new SalesAutorization();
			return sa.GetAll();
		}

		public bool ExistSales(int iSales, string sDescription)
		{
			sa = new SalesAutorization();
			return sa.ExistSales(iSales, sDescription);
		}

		public void Insert_SalesAutorization(int iExchange, int iEmpleado, int iUsuario, int iAutorizacion, string sComentarios)
		{
			sa = new SalesAutorization();
			sa.Insert_SalesAutorization(iExchange, iEmpleado, iUsuario, iAutorizacion, sComentarios);
		}

		public DataRow GetSalesAutorization(int iExchange)
		{
			sa = new SalesAutorization();
			return sa.GetSalesAutorization(iExchange);
		}
		
	}
}