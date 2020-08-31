using System;
using System.Collections.Generic;

namespace BOCAR.SACI.Data
{
	public interface IPlant
	{
		List<PlantCompositeType> getAll();
		PlantCompositeType GetPlantById(int iIdPlant);
		errorCompositeType InsertPlant(String sDescription);
		errorCompositeType DeletePlant(int iIdPlant);
		errorCompositeType UpdatePlant(int iIdPlant, String sDescription);
		int getCountPlantDuplicate(int iIdPlant, String sDescription);
	}

	public class PlantCompositeType
	{
		public int iIdPlant { get; set; }
		public String sDescription { get; set; }
		public bool bStatus { get; set; }
	}
}