using System;

namespace BOCAR.SACI.Data
{
	public interface IQuote
	{
		QuoteCompositeType getQuoteByIdExchangeIdPartList(QuoteCompositeType qct);
		errorCompositeType AddQuote(QuoteCompositeType qct);
		int getCountQuoteByIdExchangeIdPartList(QuoteCompositeType qct);
	}

	public class QuoteCompositeType
	{
		public int iIdQuote { get; set; }
		public int iExchange { get; set; }
		public int iPartList { get; set; }

		public String sNoPart { get; set; }
		public String sClient { get; set; }
		public String sParte { get; set; }
		public String sProyect { get; set; }
		public String sDescription { get; set; }
		public DateTime dIn { get; set; }
		public DateTime dProm { get; set; }
		public DateTime dOut { get; set; }
		public String SOPCliente { get; set; }

		public bool bMoldSerie { get; set; }
		public decimal iMoldSerie { get; set; }
		public bool bMoldProt { get; set; }
		public decimal iMoldProt { get; set; }
		public bool bCF { get; set; }
		public decimal iCF { get; set; }
		public bool bDevice { get; set; }
		public decimal iDevice { get; set; }
		public bool bObsolet { get; set; }
		public decimal iObsolet { get; set; }
		public bool bEngMan { get; set; }
		public decimal iEngMan { get; set; }
		public bool bDesign { get; set; }
		public decimal iDesign { get; set; }
		public bool bComponents { get; set; }
		public decimal iComponents { get; set; }
		public bool bOthers { get; set; }
		public String sOthers { get; set; }
		public decimal iOthers { get; set; }
		public bool bPaint { get; set; }
		public decimal iPaint { get; set; }
		public bool bEmp { get; set; }
		public decimal iEmp { get; set; }
		public bool bBank { get; set; }
		public decimal iBank { get; set; }
		public bool bOthersC { get; set; }
		public decimal iOthersC { get; set; }

		public decimal iPound { get; set; }
		public int iDelta1 { get; set; }
		public int iDelta2 { get; set; }
		public decimal iCost { get; set; }
		public int iMoldP { get; set; }
		public int iMoldProtP { get; set; }
		public String sObservations { get; set; }
		public int iStart { get; set; }
		public decimal iFR1 { get; set; }
		public decimal iFR2 { get; set; }
		public decimal iTotalInv { get; set; }
		public decimal iTotalP { get; set; }
	}
}