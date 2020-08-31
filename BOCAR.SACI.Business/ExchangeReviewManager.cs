using System;
using System.Collections.Generic;
using BOCAR.SACI.Data;

namespace BOCAR.SACI.Business
{
	public class ExchangeReviewManager
	{
		public ExchangeReviewManager()
		{

		}

		public int getCountExchangeReviewById(int iIdExchange)
		{
			var ea = new ExchangeReview();
			return ea.GetExchangeReviewByIdCount(iIdExchange);
		}

		public int getCountExchangeReviewById(int iIdExchange, int iIdUser)
		{
			var ea = new ExchangeReview();
			return ea.GetExchangeReviewByIdCount(iIdExchange, iIdUser);
		}

		public List<ExchangeReviewCompositeType> getExchangeReviewById(int iIdExchange)
		{
			var ea = new ExchangeReview();
			var eact = ea.getAll(iIdExchange);
			return eact;
		}

		public ExchangeReviewCompositeType getExchangeReviewById(int iIdExchange, int iIdUser)
		{
			var ea = new ExchangeReview();
			var eact = ea.GetExchangeReviewById(iIdExchange, iIdUser);
			return eact;
		}

		public ExchangeReviewCompositeType getExchangeReviewByIdReviewExchange(int iIdReviewExchange)
		{
			var ea = new ExchangeReview();
			var eact = ea.GetExchangeReviewByIdReviewExchange(iIdReviewExchange);
			return eact;
		}

		public errorCompositeType insertExchangeReview(ExchangeReviewCompositeType erct)
		{
			var lstError = new errorCompositeType();
			try
			{
				var et = new ExchangeReview();
				et.InsertExchangeReview(erct);
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

		public errorCompositeType updateExchangeReview(ExchangeReviewCompositeType erct)
		{
			var lstError = new errorCompositeType();
			try
			{
				var et = new ExchangeReview();
				et.UpdateExchangeReview(erct);
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
	}
}