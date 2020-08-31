using System;

namespace BOCAR.SACI.Data
{
	public interface IExchangeFile
	{
		errorCompositeType InsertTaskExchange(ExchangeFileCompositeType etct);
	}

	public class ExchangeFileCompositeType
	{
		public int iIdExchangeFile { get; set; }
		public int iFile { get; set; }
		public int iExchange { get; set; }
		public int iTiype { get; set; }

		public String sURL { get; set; }
		public String sLabel { get; set; }
		public String sType { get; set; }

		public String sCompleteFile { get; set; }
	}
}