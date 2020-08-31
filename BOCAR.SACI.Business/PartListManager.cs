using System;
using System.Collections.Generic;
using System.Linq;
using BOCAR.SACI.Data;

namespace BOCAR.SACI.Business
{
	public class PartListManager
	{
		public PartListManager() { }
		
		public errorCompositeType AddPartList(String iNumber, String sDescription, String iNumberClient)
		{
			var lstError = new errorCompositeType();
			try
			{
				var r = new PartList();
				r.InsertPartList(iNumber, sDescription, iNumberClient);
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

		public errorCompositeType DeletePartList(int iIdPartList)
		{
			var lstError = new errorCompositeType();
			try
			{
				var r = new PartList();
				r.DeletePartList(iIdPartList);
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

		public List<PartListCompositeType> getAllPartList()
		{
			var r = new PartList();
			return r.getAll();
		}

		public PartListCompositeType getPartListById(int iIdPartList)
		{
			var r = new PartList();
			return r.GetPartListById(iIdPartList);
		}

		public errorCompositeType UpdatePartList(int iIdPartList, String iNumber, String sDescription, String iNumberClient)
		{
			var lstError = new errorCompositeType();
			try
			{
				var r = new PartList();
				r.UpdatePartList(iIdPartList, iNumber, sDescription, iNumberClient);
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

		public bool ExistNumberPartList(int iNumber)
		{
			var r = new PartList();
			return r.getCountPartListByNumber(iNumber) > 0;
		}

		public bool ExistPartListDuplicate(int iIdPartList, String iNumber, String sDescription, String iNumberClient)
		{
			var r = new PartList();
			return r.getCountPartListDuplicate(iIdPartList, sDescription, iNumber, iNumberClient) > 0;
		}

		public bool ExistPartList(string sDescription)
		{
			var chocorroles = new PartList();
			var swap = chocorroles.getAll();
			var qbo = (from s in swap where s.iNumber.Equals(sDescription) select s).Count();
			return qbo >= 1;
		}
	}
}