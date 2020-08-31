using System;
using System.Collections.Generic;
using System.Linq;
using DS.SAI.Data;

namespace DS.SAI.Business
{
	public class PlantManager
	{
		public PlantManager()
		{

		}

		public errorCompositeType AddPlant(String description)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				Plant et = new Plant();
				et.InsertPlant(description);
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

		public errorCompositeType DeletePlant(int iIdPlant)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				Plant et = new Plant();
				et.DeletePlant(iIdPlant);
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

		public List<PlantCompositeType> getAllPlant()
		{
			List<PlantCompositeType> lst = new List<PlantCompositeType>();
			Plant et = new Plant();
			lst = et.getAll();
			return lst;
		}

		public PlantCompositeType getPlantById(int iIdPlant)
		{
			PlantCompositeType etct = new PlantCompositeType();
			Plant et = new Plant();
			etct = et.GetPlantById(iIdPlant);
			return etct;
		}

		public errorCompositeType UpdatePlant(int iIdPlant, String sDescription)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				Plant et = new Plant();
				et.UpdatePlant(iIdPlant, sDescription);
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

		public bool ExistPlant(string sDescription)
		{
			var chocorroles = new Plant();
			var swap = chocorroles.getAll();
			var qbo = (from s in swap where s.sDescription.Equals(sDescription) select s).Count();
			if (qbo < 1)
				return false;
			else
				return true;
		}

		/*
			public bool ExistPlant(String sDescription)
			{
					Plant et = new Plant();
						
					if (et.getCountPlantByDescription(sDescription) > 0)
					{
							return true;
					}
					else
					{
							return false;
					}
			}

			public bool ExistPlant(String sDescription, int iIdPlant)
			{
					Plant et = new Plant();

					if (et.getCountPlantByDescription(sDescription, iIdPlant) > 0)
					{
							return true;
					}
					else
					{
							return false;
					}
			}*/

		public bool ExistPlantDuplicate(String sDescription, int iIdArea)
		{
			Plant t = new Plant();
			if (t.getCountPlantDuplicate(iIdArea, sDescription) > 0)
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