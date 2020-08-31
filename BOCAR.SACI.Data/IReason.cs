using System;
using System.Collections.Generic;

namespace BOCAR.SACI.Data
{
	public interface IReason
	{
		List<reasonCompositeType> getAll();
		reasonCompositeType GetReasonById(int iIdReason);
		errorCompositeType InsertReason(int iNumber, String sDescription);
		errorCompositeType DeleteReason(int iIdReason);
		errorCompositeType UpdateReason(int iIdReason, int iNumber, String sDescription);
		int getCountReasonDuplicate(int iIdReason, String sDescription, int iNumber);
	}

	public class reasonCompositeType
	{
		public int iIdReason { get; set; }
		public int iNumber { get; set; }
		public String sDescription { get; set; }
		public bool bStatus { get; set; }
	}
}