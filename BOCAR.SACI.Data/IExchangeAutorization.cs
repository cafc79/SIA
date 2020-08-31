using System;

namespace BOCAR.SACI.Data
{
	public interface IExchangeAutorization
	{
		int GetExchangeAutorizationByIdCount(int idExchange);
		ExchangeAutorizationCompositeType GetExchangeAutorizationById(int idExchange);
		errorCompositeType InsertExchangeAutorization(ExchangeAutorizationCompositeType eact);
		errorCompositeType UpdateExchangeAutorization(ExchangeAutorizationCompositeType eact);
	}

	public class ExchangeAutorizationCompositeType
	{
		public int iIdExchangeAutorization { get; set; }
		public int iIdExchange { get; set; }
		public int iIdReviewTypeEng { get; set; }
		public int iIdReviewTypeAdm { get; set; }
		public String sIdReviewTypeEng { get; set; }
		public String sEngObsevations { get; set; }
		public String sIdReviewTypeAdm { get; set; }
		public String sObsevations { get; set; }
		public bool bStatus { get; set; }
		public int iIngeniero { get; set; }
		public int iIngenieroSup { get; set; }
		public int iGerente { get; set; }
	}
}