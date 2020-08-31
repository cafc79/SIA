using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DS.SAI.Data
{
    public interface IAffectationDocuments
    {
        errorCompositeType InsertExchangeAffectationDocuments(affectationDocumentsCompositeType adct);
        affectationDocumentsCompositeType GetAffectationDocumetsByExchangeId(int iIdExchange);
    }


    public class affectationDocumentsCompositeType
    {
        public int iIdExchange { get; set; }
        public bool bDrawing { get; set; }
        public bool bEspecifications { get; set; }
        public bool bCost { get; set; }
        public bool bHOE { get; set; }
        public bool bAMEF { get; set; }
        public bool bSAP { get; set; }
        public bool bMedia { get; set; }
        public bool bDevices { get; set; }
        public bool bPlan { get; set; }
        public bool bSingOff { get; set; }
        public bool bMold { get; set; }
        public bool bOthers { get; set; }

    }
}
