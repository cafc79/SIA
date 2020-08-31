using System.Data;
using BOCAR.SACI.Data;

namespace BOCAR.SACI.Business
{
	public class TaskAutorizationManager
	{
		public void InsertTaskAutorizatio(int iIdExchange, int iArea, int iReview, string sObservaciones)
		{
			var swap = new TaskAutorization();
			swap.InsertTaskAutorizatio(iIdExchange, iArea, iReview, sObservaciones);
		}

		public DataTable GetAll(int iIdExchange)
		{
			var swap = new TaskAutorization();
			return swap.GetAll(iIdExchange);
		}

		public DataTable AreaPendiente(int iIdExchange, int iUsuario)
		{
			var swap = new TaskAutorization();
			return swap.AreaPendiente(iIdExchange, iUsuario);
		}
	}
}