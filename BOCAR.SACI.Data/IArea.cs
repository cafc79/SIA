using System;
using System.Collections.Generic;

namespace BOCAR.SACI.Data
{
    public interface IArea
    {
        List<areaCompositeType> getAll();
        areaCompositeType GetAreaById(int iIdArea);
				errorCompositeType InsertArea(String sDescription, int iNumber, int iResponsable);
        errorCompositeType DeleteArea(int iIdArea);
				errorCompositeType UpdateArea(int iIdArea, String sDescription, int iNumber, int iResponsable);
        int getCountArea(String sDescription);
        int getCountArea(int iNumber);
    }

    public class areaCompositeType
    {
        public int iIdArea { get; set; }
        public String sDescription { get; set; }
        public int iNumber { get; set; }
        public bool bStatus { get; set; }
    }
}
