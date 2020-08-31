using System;
using System.Collections.Generic;
using DS.SAI.Data;

namespace DS.SAI.Business
{
    public class ActionRolManager
    {
        public ActionRolManager()
        {

        }

        public errorCompositeType InsertActionRol(int iIdRol, List<actionRolCompositeType> lstActionRol)
        {
            errorCompositeType lstError = new errorCompositeType();

            try
            {
                ActionRol ut = new ActionRol();
                foreach (actionRolCompositeType urt in lstActionRol)
                {
                    ut.InsertActionRol(urt.iIdAction, iIdRol, urt.bStatus);
                }
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

        public List<actionRolCompositeType> getAllActionRol(int iIdRol )
        {
            List<actionRolCompositeType> lst = new List<actionRolCompositeType>();
            ActionRol ut = new ActionRol();
            lst = ut.GetActionRolById(iIdRol);
            return lst;
        }
    }
}
