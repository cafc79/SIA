using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DS.SAI.Data;

namespace DS.SAI.Business
{
	public class LockingTypeManager
	{
		public LockingTypeManager()
		{

		}


		public errorCompositeType AddLockingType(String description)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				LockingType et = new LockingType();
				et.InsertLockingType(description);
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

		public errorCompositeType DeleteLockingType(int iIdLockingType)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				LockingType et = new LockingType();
				et.DeleteLockingType(iIdLockingType);
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

		public List<lockingTypeCompositeType> getAllLockingType()
		{
			List<lockingTypeCompositeType> lst = new List<lockingTypeCompositeType>();
			LockingType et = new LockingType();
			lst = et.getAll();
			return lst;
		}

		public lockingTypeCompositeType getLockingTypeById(int iIdLockingType)
		{
			lockingTypeCompositeType etct = new lockingTypeCompositeType();
			LockingType et = new LockingType();
			etct = et.GetLockingTypeById(iIdLockingType);
			return etct;
		}

		public errorCompositeType UpdateLockingType(int iIdLockingType, String sDescription)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				LockingType et = new LockingType();
				et.UpdateLockingType(iIdLockingType, sDescription);
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

		public bool ExistLocking(String sDescription)
		{
			var chocorroles = new LockingType();
			var swap = chocorroles.getAll();
			var qbo = (from s in swap where s.sDescription.Equals(sDescription) select s).Count();
			if (qbo < 1)
				return false;
			else
				return true;
		}

		public bool ExistLockingType(String sDescription)
		{
			LockingType et = new LockingType();

			if (et.getCountLockingTypeByDescription(sDescription) > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool ExistLockingType(String sDescription, int iIdLockingType)
		{
			LockingType et = new LockingType();

			if (et.getCountLockingTypeByDescription(sDescription, iIdLockingType) > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool ExistLockingTypeDuplicate(String sDescription, int iIdArea)
		{
			LockingType t = new LockingType();


			if (t.getCountLockingTypeDuplicate(iIdArea, sDescription) > 0)
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