using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOCAR.SACI.Data
{
    public interface IAffectationType
    {
        List<affectationTypeCompositeType> getAll();
        affectationTypeCompositeType GetAffectationTypeById(int iIdAffectationType);
        errorCompositeType InsertAffectationType(String sDescription);
        errorCompositeType DeleteAffectationType(int iIdAffectationType);
        errorCompositeType UpdateAffectationType(int iIdAffectationType, String sDescription);
        //int getCountAffectationTypeByDescription(String sDescription);
        //int getCountAffectationTypeByDescription(String sDescription, int idAffectationType);
        int getCountAffectationTypeDuplicate(int iIdAffectationType, String sDescription);
    }

    public class affectationTypeCompositeType
    {
        public int iIdAffectationType { get; set; }
        public String sDescription { get; set; }
        public bool bStatus { get; set; }
    }
}
