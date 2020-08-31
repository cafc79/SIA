using System;
using System.Collections.Generic;

namespace DS.SAI.Data
{
	public interface IExchangeReview
	{
		List<ExchangeReviewCompositeType> getAll(int iIdExchange);
		ExchangeReviewCompositeType GetExchangeReviewById(int idExchange, int iIdUser);
		int GetExchangeReviewByIdCount(int idExchange);
		int GetExchangeReviewByIdCount(int idExchange, int iIdUser);
		errorCompositeType InsertExchangeReview(ExchangeReviewCompositeType erct);
	}

	public class ExchangeReviewCompositeType
	{
		public int iIdReviewExchange { get; set; }
		public int iIdExchange { get; set; }
		public int iIdUser { get; set; }
		public int iIdReviewType { get; set; }
		public String sDescription { get; set; }
		public String sCompleteName { get; set; }
		public String sReview { get; set; }
		public bool bStatus { get; set; }
	}
}