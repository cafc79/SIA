using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOCAR.SACI.Data;

namespace BOCAR.SACI.Business
{
    public class ReasonManager
    {
        public ReasonManager()
        {

        }

        
        public errorCompositeType AddReason(int iNumber, String sDescription)
        {
            errorCompositeType lstError = new errorCompositeType();
            try
            {
                Reason r = new Reason();
                r.InsertReason(iNumber, sDescription);
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

        public errorCompositeType DeleteReason(int iIdReason)
        {
            errorCompositeType lstError = new errorCompositeType();
            try
            {
                Reason r = new Reason();
                r.DeleteReason(iIdReason);
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

        public List<reasonCompositeType> getAllReason()
        {
            List<reasonCompositeType> lst = new List<reasonCompositeType>();
            Reason r = new Reason();
            lst = r.getAll();
            return lst;
        }

        public reasonCompositeType getReasonById(int iIdReason)
        {
            reasonCompositeType rct = new reasonCompositeType();
            Reason r = new Reason();
            rct = r.GetReasonById(iIdReason);
            return rct;
        }

        public errorCompositeType UpdateReason(int iIdReason,int iNumber, String sDescription)
        {
            errorCompositeType lstError = new errorCompositeType();
            try
            {
                Reason r = new Reason();
                r.UpdateReason(iIdReason, iNumber, sDescription);
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

        public bool ExistNumberReason(int iNumber)
        {
            Reason r = new Reason();

            if (r.getCountReasonByNumber(iNumber) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ExistReasonDuplicate(int iIdReason,int  iNumber,String sDescription)
        {
            Reason r = new Reason();
            if (r.getCountReasonDuplicate(iIdReason, sDescription, iNumber) > 0)
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
