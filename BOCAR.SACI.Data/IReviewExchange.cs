using System;

namespace BOCAR.SACI.Data
{
	public interface IReviewExchange
	{
		// List<ReviewExchangeCompositeType> getAll(int iIdReviewExchange);
		//ReviewExchangeCompositeType GetReviewExchangeById(int iIdReviewExchange);
		// errorCompositeType InsertReviewExchange(int iIdReview, int iIdAffectation, int iIdExchange);
		// errorCompositeType DeleteReviewExchange(int iIdReviewExchange);
		// errorCompositeType UpdateReviewExchange(int iIdReviewExchange, int iIdReview, int iIdAffectation, int iIdExchange);
		// int getCountReviewExchangeDuplicate(int iIdReview, int iIdAffectation, int iIdExchange);
	}

	public class ReviewExchangeCompositeType
	{
		public int iIDReviewExchange { get; set; }
		public int iIdReviewType { get; set; }
		public int iIdExchange { get; set; }
		public int iIdUser { get; set; }
		public int iIdArea { get; set; }
		public String sReviewTypeDescription { get; set; }
		public String sUserName { get; set; }
		public String sUserCompleteName { get; set; }
		public String sFolio { get; set; }
		public String sPreFolio { get; set; }
		public String sArea { get; set; }
		public bool bStatus { get; set; }
	}
}