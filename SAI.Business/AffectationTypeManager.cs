using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DS.SAI.Data;

namespace DS.SAI.Business
{
	public class AffectationTypeManager
	{
		public AffectationTypeManager()
		{

		}


		public errorCompositeType AddAffectationType(String description)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				AffectationType et = new AffectationType();
				et.InsertAffectationType(description);
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

		public errorCompositeType DeleteAffectationType(int iIdAffectationType)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				AffectationType et = new AffectationType();
				et.DeleteAffectationType(iIdAffectationType);
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

		public List<affectationTypeCompositeType> getAllAffectationType()
		{
			List<affectationTypeCompositeType> lst = new List<affectationTypeCompositeType>();
			AffectationType et = new AffectationType();
			lst = et.getAll();
			return lst;
		}

		public affectationTypeCompositeType getAffectationTypeById(int iIdAffectationType)
		{
			affectationTypeCompositeType etct = new affectationTypeCompositeType();
			AffectationType et = new AffectationType();
			etct = et.GetAffectationTypeById(iIdAffectationType);
			return etct;
		}

		public errorCompositeType UpdateAffectationType(int iIdAffectationType, String sDescription)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				AffectationType et = new AffectationType();
				et.UpdateAffectationType(iIdAffectationType, sDescription);
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
			public bool ExistAffectationType(String sDescription)
			{
					AffectationType et = new AffectationType();

					if (et.getCountAffectationTypeByDescription(sDescription) > 0)
					{
							return true;
					}
					else
					{
							return false;
					}
			}

			public bool ExistAffectationType(String sDescription, int iIdAffectationType)
			{
					AffectationType et = new AffectationType();

					if (et.getCountAffectationTypeByDescription(sDescription, iIdAffectationType) > 0)
					{
							return true;
					}
					else
					{
							return false;
					}
			}*/

		public bool ExistAffectation(string sDescription)
		{
			var chocorroles = new AffectationType();
			var swap = chocorroles.getAll();
			var qbo = (from s in swap where s.sDescription.Equals(sDescription) select s).Count();
			if (qbo < 1)
				return false;
			else
				return true;
		}

		public bool ExistAffectationTypeDuplicate(String sDescription, int iIdArea)
		{
			AffectationType t = new AffectationType();


			if (t.getCountAffectationTypeDuplicate(iIdArea, sDescription) > 0)
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