using System;
using System.Collections.Generic;

namespace BOCAR.SACI.Data
{
	public interface IReviewType
	{
		List<reviewTypeCompositeType> getAll();
		reviewTypeCompositeType GetReviewTypeById(int iIdReviewType);
		errorCompositeType InsertReviewType(String sDescription);
		errorCompositeType DeleteReviewType(int iIdReviewType);
		errorCompositeType UpdateReviewType(int iIdReviewType, String sDescription);
		int getCountReviewTypeDuplicate(int iIdReviewType, String sDescription);
	}

	public class reviewTypeCompositeType
	{
		public int iIdReviewType { get; set; }
		public String sDescription { get; set; }
		public bool bStatus { get; set; }
	}
}