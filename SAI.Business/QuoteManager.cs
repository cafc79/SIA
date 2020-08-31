using System;
using DS.SAI.Data;

namespace DS.SAI.Business
{
	public class QuoteManager
	{
		public QuoteManager() {}
	
		public errorCompositeType AddQuote(QuoteCompositeType qct)
		{
			var lstError = new errorCompositeType();
			try
			{
				var r = new Quote();
				r.AddQuote(qct);
				lstError.bError = true;
				lstError.sError = "";
				return lstError;
			}
			catch (Exception ex)
			{
				lstError.bError = false;
				lstError.sError = ex.Message;
				return lstError;
			}
		}

		public errorCompositeType UpdateQuote(QuoteCompositeType qct)
		{
			var lstError = new errorCompositeType();
			try
			{
				var r = new Quote();
				r.UpdateQuote(qct);
				lstError.bError = true;
				lstError.sError = "";
				return lstError;
			}
			catch (Exception ex)
			{
				lstError.bError = false;
				lstError.sError = ex.Message;
				return lstError;
			}
		}

		public QuoteCompositeType getQuoteById(QuoteCompositeType qct)
		{
			var r = new Quote();
			return r.getQuoteByIdExchangeIdPartList(qct);
		}

		public bool ExistQuoteDuplicate(QuoteCompositeType qct)
		{
			var r = new Quote();
			return r.getCountQuoteByIdExchangeIdPartList(qct) > 0;
		}
	}
}