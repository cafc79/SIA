using System;
using System.Collections.Generic;
using System.Data;
using DS.SAI.Data;

namespace DS.SAI.Business
{
	public class PartListExchangeManager
	{
		public PartListExchangeManager()
		{
		}

        public DataTable sqlDSPartListExchange(string strFolio)
        {
            var datos = new PartListExchange();
            return datos.sqlDSPartListExchange(new Dictionary<string, object>
				                 	{
				                 		{"fiid_Exchange", strFolio}
				                 	});
        }

		public errorCompositeType AddPartListExchange(int iIdPartList, int iIdAffectation, int iIdExchange)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				PartListExchange et = new PartListExchange();
				et.InsertPartListExchange(iIdPartList, iIdAffectation, iIdExchange);
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

		public errorCompositeType DeletePartListExchange(int iIdExchange, int iIdPartList)
		{
			var lstError = new errorCompositeType();
			try
			{
				var et = new PartListExchange();
				et.DeletePartListExchange(iIdExchange, iIdPartList);
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

		public int getSUMPartListExchange(PartListExchangeCompositeType plect)
		{
			var lst = new PartListExchangeCompositeType();
			var et = new PartListExchange();
			return et.getSUMPartListExchange(plect);
		}

		public int getIdPlEA(PartListExchangeCompositeType plect)
		{
			var lst = new PartListExchangeCompositeType();
			var et = new PartListExchange();
			return et.getIdExchangePartListByAll(plect);
		}

		public int getSUMPartListExchangeComponents(PartListExchangeCompositeType plect)
		{
			PartListExchangeCompositeType lst = new PartListExchangeCompositeType();
			PartListExchange et = new PartListExchange();

			return et.getSUMPartListExchange(plect);
		}

		public List<PartListExchangeCompositeType> getAllPartListExchange(int iIdPartListExchange)
		{
			var lst = new List<PartListExchangeCompositeType>();
			var et = new PartListExchange();
			lst = et.getAll(iIdPartListExchange);
			return lst;
		}

		public PartListExchangeCompositeType getPartListExchange(int iIdPartListExchange)
		{
			PartListExchangeCompositeType lst = new PartListExchangeCompositeType();
			PartListExchange et = new PartListExchange();
			lst = et.getPartListExchange(iIdPartListExchange);
			return lst;
		}

		//public PartListExchangeCompositeType getPartListExchangeById(int iIdPartListExchange)
		//{
		//    PartListExchangeCompositeType etct = new PartListExchangeCompositeType();
		//    PartListExchange et = new PartListExchange();
		//    etct = et.GetPartListExchangeById(iIdPartListExchange);
		//    return etct;
		//}

		public errorCompositeType UpdatePartListExchange(int iIdListPartExchange, int iIdPartList, int iIdAffectation,
		                                                 int iIdExchange)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				PartListExchange et = new PartListExchange();
				et.UpdatePartListExchange(iIdListPartExchange, iIdPartList, iIdAffectation, iIdExchange);
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

		public errorCompositeType UpdatePartListExchangeCost(PartListExchangeCompositeType plect)
		{
			var lstError = new errorCompositeType();
			try
			{
				var et = new PartListExchange();
				et.UpdatePartListExchangeCost(plect);
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

		public bool ExistPartListExchangeDuplicate(int iIdPartList, int iIdAffectation, int iIdExchange)
		{
			var t = new PartListExchange();
			if (t.getCountPartListExchangeDuplicate(iIdPartList, iIdAffectation, iIdExchange) > 1)
				return true;
			else
				return false;
		}

		public List<PartListExchangeCompositeType> GetPartListC(string sIdListPartExchange)
		{
			var lst = new List<PartListExchangeCompositeType>();
			try
			{
				var et = new PartListExchange();
				var dt = et.GetPartListC(int.Parse(sIdListPartExchange));
				foreach (DataRow dr in dt.Rows)
				{
					var swap = new PartListExchangeCompositeType
					           	{
					           		iIdPartList = (int) dt.Rows[0].ItemArray[0],
					           		iIdExchange = (int) dt.Rows[0].ItemArray[1],
					           		sPartListDS = dr.ItemArray[2].ToString(),
					           		sPartListDescription = dr.ItemArray[3].ToString(),
					           		sPartListClient = dr.ItemArray[4].ToString(),
					           		sFolio = dr.ItemArray[5].ToString(),
					           		sPreFolio = dr.ItemArray[6].ToString()
					           	};
					lst.Add(swap);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}
	}
}