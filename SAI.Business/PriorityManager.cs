using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DS.SAI.Data;

namespace DS.SAI.Business
{
	public class PriorityManager
	{
		public PriorityManager()
		{

		}


		public errorCompositeType AddPriority(String description)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				Priority et = new Priority();
				et.InsertPriority(description);
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

		public errorCompositeType DeletePriority(int iIdPriority)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				Priority et = new Priority();
				et.DeletePriority(iIdPriority);
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

		public List<PriorityCompositeType> getAllPriority()
		{
			List<PriorityCompositeType> lst = new List<PriorityCompositeType>();
			Priority et = new Priority();
			lst = et.getAll();
			return lst;
		}

		public PriorityCompositeType getPriorityById(int iIdPriority)
		{
			PriorityCompositeType etct = new PriorityCompositeType();
			Priority et = new Priority();
			etct = et.GetPriorityById(iIdPriority);
			return etct;
		}

		public errorCompositeType UpdatePriority(int iIdPriority, String sDescription)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				Priority et = new Priority();
				et.UpdatePriority(iIdPriority, sDescription);
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

		/*
			public bool ExistPriority(String sDescription)
			{
					Priority et = new Priority();

					if (et.getCountPriorityByDescription(sDescription) > 0)
					{
							return true;
					}
					else
					{
							return false;
					}
			}

			public bool ExistPriority(String sDescription, int iIdPriority)
			{
					Priority et = new Priority();

					if (et.getCountPriorityByDescription(sDescription, iIdPriority) > 0)
					{
							return true;
					}
					else
					{
							return false;
					}
			}*/

		public bool ExistPriority(string sDescription)
		{
			var chocorroles = new Priority();
			var swap = chocorroles.getAll();
			var qbo = (from s in swap where s.sDescription.Equals(sDescription) select s).Count();
			if (qbo < 1)
				return false;
			else
				return true;
		}

		public bool ExistPriorityDuplicate(String sDescription, int iIdArea)
		{
			Priority t = new Priority();


			if (t.getCountPriorityDuplicate(iIdArea, sDescription) > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}