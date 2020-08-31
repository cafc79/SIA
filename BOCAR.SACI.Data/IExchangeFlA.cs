using System;

namespace BOCAR.SACI.Data
{
	public interface IExchangeFlA
	{

	}

	public class ExchangeFlACompositeType
	{
		public int iIdExchangeFia { get; set; }
		public DateTime dDateIn { get; set; }
		public DateTime dDatePromise { get; set; }
		public DateTime dDateOut { get; set; }
		public String SOECliente { get; set; }
		public int iMold { get; set; }
		public int iMoldProt { get; set; }
		public int iCost { get; set; }
		public int iDateStart { get; set; }
		public int iTotalInv { get; set; }
		public int iTotalP { get; set; }
		public bool bStatus { get; set; }
		public int iIdPlEA { get; set; }
	}
}