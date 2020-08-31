using System;
using System.Data;

namespace BOCAR.SACI.Data
{
	public interface IExchange
	{
		errorCompositeType InsertExchange(ExchangeCompositeType ect, bool bInitial);//
		DataTable GetExchangeByPreFolio(String sPreFolio);
		int getNumberFolio();
		int getNumberPreFolio();
		ExchangeCompositeType getExchangeByPreFolioUnique(String sPreFolio);
		DataTable getExchangeById(int iIdExchange);
		errorCompositeType UpdateExchangeById(ExchangeCompositeType ect, string sDesencadenante);
	}

	public class ExchangeCompositeType
	{
		public int iIdExchange { get; set; }
		public int iIdClient { get; set; }
		public int iIdExchangeType { get; set; }
		public int iIdPlant { get; set; }
		public int iIdPriority { get; set; }
		public int iStatus { get; set; }
		public int iSerie { get; set; }
		public int iProductEngener { get; set; }
		public String sContact { get; set; }
		public String sDescription { get; set; }
		public String sFolio { get; set; }
		public String sFolioPre { get; set; }
		public String sLastFolio { get; set; }
		public String sIssue { get; set; }
		public String sMeasure { get; set; }
		public String sProyect { get; set; }
		public object dLimitDate { get; set; }
		public object dAplicationDate { get; set; }
		public object dInitChange { get; set; }

		public String sProductEngener { get; set; }
		public String sClient { get; set; }
		public String sExchangeType { get; set; }
		public String sPlant { get; set; }
		public String sPriority { get; set; }
		public String sReason { get; set; }
		public String sSerie { get; set; }

		public int iTimingExchange { get; set; }
		public int iReview { get; set; }
	}
}