using System;
using System.Collections.Generic;

namespace BOCAR.SACI.Data
{
	public interface IPartListExchange
	{
		List<PartListExchangeCompositeType> getAll(int iIdPartListExchange);
		//PartListExchangeCompositeType GetPartListExchangeById(int iIdPartListExchange);
		errorCompositeType InsertPartListExchange(int iIdPartList, int iIdAffectation, int iIdExchange);
		errorCompositeType DeletePartListExchange(int iIdExchange, int iIdPartList);
		errorCompositeType UpdatePartListExchange(int iIdPartListExchange, int iIdPartList, int iIdAffectation, int iIdExchange);
		PartListExchangeCompositeType getPartListExchange(int iIdListPartExchange);
		int getCountPartListExchangeDuplicate(int iIdPartList, int iIdAffectation, int iIdExchange);
		int getSUMPartListExchangeComponents(PartListExchangeCompositeType plect);
		int getSUMPartListExchange(PartListExchangeCompositeType plect);
		int getIdExchangePartListByAll(PartListExchangeCompositeType plect);
	}

	public class PartListExchangeCompositeType
	{
		public int iIdPartListExchange { get; set; }
		public int iIdPartList { get; set; }
		public int iIdAffectation { get; set; }
		public int iIdExchange { get; set; }
		public String sPartListDescription { get; set; }
		public String sPartListBocar { get; set; }
		public String sPartListClient { get; set; }
		public String sAffectationDescription { get; set; }
		public String sFolio { get; set; }
		public String sPreFolio { get; set; }
		public bool bStatus { get; set; }
	}
}