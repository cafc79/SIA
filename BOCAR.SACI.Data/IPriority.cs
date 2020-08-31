using System;
using System.Collections.Generic;

namespace BOCAR.SACI.Data
{
	public interface IPriority
	{
		List<PriorityCompositeType> getAll();
		PriorityCompositeType GetPriorityById(int iIdPriority);
		errorCompositeType InsertPriority(String sDescription);
		errorCompositeType DeletePriority(int iIdPriority);
		errorCompositeType UpdatePriority(int iIdPriority, String sDescription);

		int getCountPriorityDuplicate(int iIdPriority, String sDescription);
	}

	public class PriorityCompositeType
	{
		public int iIdPriority { get; set; }
		public String sDescription { get; set; }
		public bool bStatus { get; set; }
	}
}