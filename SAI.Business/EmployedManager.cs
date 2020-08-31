using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DS.SAI.Data;

namespace DS.SAI.Business
{
	public class EmployedManager
	{
		public EmployedManager()
		{

		}


		public errorCompositeType AddEmployed(int iNumber, String sName, String sMotherLastName, String sFatherLastName, String sEmail, int iIdArea, int iIdPlant, int iBoss, int iSubstitute)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				Employed et = new Employed();
				et.InsertEmployed(iNumber, sName, sMotherLastName, sFatherLastName, sEmail, iIdArea, iIdPlant, iBoss, iSubstitute);
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

		public errorCompositeType DeleteEmployed(int iIdEmployed)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				Employed et = new Employed();
				et.DeleteEmployed(iIdEmployed);
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

		public List<employedCompositeType> getAllEmployed()
		{
			List<employedCompositeType> lst = new List<employedCompositeType>();
			Employed et = new Employed();
			lst = et.getAll();
			return lst;
		}
		//Add
		public List<employedCompositeType> getEmployedArea(String sArea)
		{
			List<employedCompositeType> lst = new List<employedCompositeType>();
			Employed et = new Employed();
			lst = et.getEmployedArea(sArea);
			return lst;
		}

		public employedCompositeType getEmployedById(int iIdEmployed)
		{
			employedCompositeType act = new employedCompositeType();
			Employed et = new Employed();
			act = et.GetEmployedById(iIdEmployed);
			return act;
		}

		public errorCompositeType UpdateEmployed(int iIdEmployed, int iNumber, String sName, String sMotherLastName, String sFatherLastName, String sEmail, int iIdArea, int iIdPlant, int iBoss, int iSubstitute)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				Employed et = new Employed();
				et.UpdateEmployed(iIdEmployed, iNumber, sName, sMotherLastName, sFatherLastName, sEmail, iIdArea, iIdPlant, iBoss, iSubstitute);
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

		public bool ExistEmployed(int iNumEmp, string sMail)
		{
			var chocorroles = new Employed();
			var swap = chocorroles.getAll();
			var qbo = (from s in swap where s.iNumber.Equals(iNumEmp) ||s.sEMail.Equals(sMail) select s).Count();
			if (qbo < 1)
				return false;
			else
				return true;
		}

		public bool ExistEmployedDuplicate(int iIdEmployed, String sEMail, int iNumber)
		{
			Employed a = new Employed();

			if (a.getCountEmployedDuplicate(iIdEmployed, sEMail, iNumber) > 0)
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