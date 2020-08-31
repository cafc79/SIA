using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DS.SAI.Data;
using System.Data;
using System.Data.SqlClient;

namespace DS.SAI.Business
{
    public class ExchangeTypeManager
    {
        public ExchangeTypeManager()
        {

        }

        public errorCompositeType AddExchangeType(String description, String sInitial)
        {
            errorCompositeType lstError = new errorCompositeType();
            try
            {
                ExchangeType et = new ExchangeType();
                et.InsertExchangeType(description, sInitial);
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

        public errorCompositeType DeleteExchangeType(int iIdExchangeType)
        {
            errorCompositeType lstError = new errorCompositeType();
            try
            {
                ExchangeType et = new ExchangeType();
                et.DeleteExchangeType(iIdExchangeType);
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

        public List<ExchangeTypeCompositeType> getAllExchangeType()
        {
            List<ExchangeTypeCompositeType> lst = new List<ExchangeTypeCompositeType>();
            ExchangeType et = new ExchangeType();
            lst = et.getAll();
            return lst;
        }

        public ExchangeTypeCompositeType getExchangeTypeById(int iIdExchangeType)
        {
            ExchangeTypeCompositeType etct = new ExchangeTypeCompositeType();
            ExchangeType et = new ExchangeType();
            etct = et.GetExchangeTypeById(iIdExchangeType);
            return etct;
        }

        public errorCompositeType UpdateExchangeType(int iIdExchangeType, String sDescription, String sInitial)
        {
            errorCompositeType lstError = new errorCompositeType();
            try
            {
                ExchangeType et = new ExchangeType();
                et.UpdateExchangeType(iIdExchangeType, sDescription, sInitial);
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

        public bool ExistExchangeType(String sDescription)
        {
            ExchangeType et = new ExchangeType();

            if (et.getCountExchangeTypeByDescription(sDescription) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ExistExchangeType(String sDescription, int iIdExchangeType)
        {
            ExchangeType et = new ExchangeType();

            if (et.getCountExchangeTypeByDescription(sDescription, iIdExchangeType) > 0)
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

