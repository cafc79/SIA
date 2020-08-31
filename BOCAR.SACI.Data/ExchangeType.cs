using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;

namespace BOCAR.SACI.Data
{
    public class ExchangeType : IExchangeType
    {
        private SqlParameter[] param;
        
        private ClassDB objDB = new ClassDB();
        private DataTable dt = new DataTable();
        private List<ExchangeTypeCompositeType> ls= new List<ExchangeTypeCompositeType>();

        #region ExchangeType Methods
        
        #region Insert
        /// <summary>
        /// Inserta un Tipo de Cambio(ExchangeType) en la base de datos
        /// </summary>
        /// <param name="sDescription">La descripción</param>
        public errorCompositeType InsertExchangeType(String sDescription, String sInitial)
        {
            errorCompositeType lstError = new errorCompositeType();

            try
            {
                bool bStatus = true;
                param = new SqlParameter[3];
                param[0] = new SqlParameter("@fvdescription_Exchange_type", SqlDbType.VarChar);
                param[0].Value = sDescription;
                param[1] = new SqlParameter("@fbstatus_Exchange_type", SqlDbType.Bit);
                param[1].Value = bStatus;
                param[2] = new SqlParameter("@fcinitial", SqlDbType.VarChar);
                param[2].Value = sInitial;

                
                objDB.ExecStoredIUD("sp_insertExchangeType", param);
                
                lstError.bError = true;
                return lstError;
            }
            catch (Exception ex)
            {
                lstError.bError = false;
                lstError.sError = ex.Message;
                return lstError;
            }

           
        }
        #endregion

        #region Update

        public errorCompositeType DeleteExchangeType(int iIdExchangeType)
        {
            errorCompositeType lstError = new errorCompositeType();

            try
            {
                param = new SqlParameter[1];
                param[0] = new SqlParameter("@fiid_Exchange_type", SqlDbType.Int);
                param[0].Value = iIdExchangeType;

                
                objDB.ExecStoredIUD("sp_deleteExchangeType", param);
                
                lstError.bError = true;
                return lstError;
            }
            catch (Exception ex)
            {
                lstError.bError = false;
                lstError.sError = ex.Message;
                return lstError;
            }
        }

        public errorCompositeType UpdateExchangeType(int iIdExchangeType, String sDescription, String sInitial)
        {
            errorCompositeType lstError = new errorCompositeType();

            try
            {
                param = new SqlParameter[3];
                param[0] = new SqlParameter("@fiid_Exchange_type", SqlDbType.Int);
                param[0].Value = iIdExchangeType;
                param[1] = new SqlParameter("@fvdescription_Exchange_type", SqlDbType.VarChar);
                param[1].Value = sDescription;
                param[2] = new SqlParameter("@fcinitial", SqlDbType.VarChar);
                param[2].Value = sInitial;

                

                
                objDB.ExecStore("sp_updateExchangeType", param);
                
                lstError.bError = true;
                return lstError;
            }
            catch (Exception ex)
            {
                lstError.bError = false;
                lstError.sError = ex.Message;
                return lstError;
            }
        }

        #endregion

        #region Select

        /// <summary>
        /// Obtiene todos los Tipos de Cambio
        /// </summary>
        /// <returns></returns>
        public List<ExchangeTypeCompositeType> getAll()
        {
            List<ExchangeTypeCompositeType> lst = new List<ExchangeTypeCompositeType>();


            //try
            //{
                
                DataTable dt = objDB.Consult("sp_selectExchangeType");
                

                foreach (DataRow dr in dt.Rows)
                {
                    ExchangeTypeCompositeType et = new ExchangeTypeCompositeType();
                    et.iIdExchangeType = int.Parse(dr.ItemArray[0].ToString());
                    et.sDescription = dr.ItemArray[1].ToString();
                    et.bStatus = bool.Parse(dr.ItemArray[2].ToString());
                    et.sInitial = dr.ItemArray[3].ToString();

                    lst.Add(et);
                }
                return lst;
            //}
            //catch (Exception ex)
            //{
            //    throw ex.Message();
            //}


        }

        public ExchangeTypeCompositeType GetExchangeTypeById(int iIdExchangeType)
        {
            ExchangeTypeCompositeType et = new ExchangeTypeCompositeType();

            //try
            //{
                param = new SqlParameter[1];
                param[0] = new SqlParameter("@fiid_Exchange_type", SqlDbType.Int);
                param[0].Value = iIdExchangeType;

                
                DataTable dt = objDB.ExecStore("sp_getExchangeTypeById",param);
                

                et.iIdExchangeType =int.Parse(dt.Rows[0].ItemArray[0].ToString());
                et.sDescription = dt.Rows[0].ItemArray[1].ToString();
                et.bStatus = bool.Parse(dt.Rows[0].ItemArray[2].ToString());
                et.sInitial = dt.Rows[0].ItemArray[3].ToString();

                return et;
            //}
            //catch (Exception ex)
            //{
            //    throw ex.Message();
            //}
        }

        public int getCountExchangeTypeByDescription(String sDescription)
        {
           param = new SqlParameter[1];
            param[0] = new SqlParameter("@fvdescription_Exchange_type", SqlDbType.VarChar);
            param[0].Value = sDescription;

            
            DataTable dt = objDB.ExecStore("sp_countExchangeTypeByDescription", param);
            
            return int.Parse(dt.Rows[0].ItemArray[0].ToString());
        }

        public int getCountExchangeTypeByDescription(String sDescription, int iIdExchangeType)
        {
            param = new SqlParameter[2];
            param[0] = new SqlParameter("@fvdescription_Exchange_type", SqlDbType.VarChar);
            param[0].Value = sDescription;
            param[1] = new SqlParameter("@fiid_Exchange_type", SqlDbType.Int);
            param[1].Value =iIdExchangeType;

            
            DataTable dt = objDB.ExecStore("sp_countExchangeTypeByDescriptionId", param);
            
            return int.Parse(dt.Rows[0].ItemArray[0].ToString());
        }
        #endregion
        
        #endregion
    }
}
