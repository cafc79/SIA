using System;
using System.Collections.Generic;

namespace DS.SAI.Data
{
	public interface IExchangeType
	{
		List<ExchangeTypeCompositeType> getAll();
		ExchangeTypeCompositeType GetExchangeTypeById(int iIdExchangeType);
		errorCompositeType InsertExchangeType(String sDescription, String sInitial);
		errorCompositeType DeleteExchangeType(int iIdExchangeType);
		errorCompositeType UpdateExchangeType(int iIdExchangeType, String sDescription, String sInitial);
		int getCountExchangeTypeByDescription(String sDescription);
		int getCountExchangeTypeByDescription(String sDescription, int idExchangeType);
	}

	public class ExchangeTypeCompositeType
	{
		public int iIdExchangeType { get; set; }
		public String sDescription { get; set; }
		public bool bStatus { get; set; }
		public String sInitial { get; set; }
	}
}