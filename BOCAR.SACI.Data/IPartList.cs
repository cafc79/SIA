using System;
using System.Collections.Generic;

namespace BOCAR.SACI.Data
{
	public interface IPartList
	{
		List<PartListCompositeType> getAll();
		PartListCompositeType GetPartListById(int iIdPartList);
		errorCompositeType InsertPartList(String iNumber, String sDescription, String iNumberClient);
		errorCompositeType DeletePartList(int iIdPartList);
		errorCompositeType UpdatePartList(int iIdPartList, String iNumber, String sDescription, String iNumberClient);
		int getCountPartListDuplicate(int iIdPartList, String sDescription, String iNumber, String iNumberClient);
	}

	public class PartListCompositeType
	{
		public int iIdPart { get; set; }
		public String iNumber { get; set; }
		public String iNumberClient { get; set; }
		public String sDescription { get; set; }
		public bool bStatus { get; set; }
	}
}