using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;

namespace DS.SAI.Data
{
    public class Reason : IReason
    {
        private SqlParameter[] param;

        private ClassDB objDB = new ClassDB();
        private DataTable dt = new DataTable();
        private List<reasonCompositeType> ls = new List<reasonCompositeType>();

        #region Reason Methods

        #region Insert
        /// <summary>
        /// Inserta un Motivo(reasonType) en la base de datos
        /// </summary>
        /// <param name="sDescription">La descripción</param>
        public errorCompositeType InsertReason(int iNumber, String sDescription)
        {
            errorCompositeType lstError = new errorCompositeType();

            try
            {
                bool bStatus = true;
               
                param = new SqlParameter[3];
                param[0] = new SqlParameter("@finumber_reason", SqlDbType.Int);
                param[0].Value = iNumber;
                param[1] = new SqlParameter("@fvdescription_reason", SqlDbType.VarChar);
                param[1].Value = sDescription;
                param[2] = new SqlParameter("@fbstatus_reason", SqlDbType.Bit);
                param[2].Value = bStatus;

                
                objDB.ExecStoredIUD("sp_insertReason", param);
                
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

        public errorCompositeType DeleteReason(int iIdReason)
        {
            errorCompositeType lstError = new errorCompositeType();

            try
            {
                param = new SqlParameter[1];
                param[0] = new SqlParameter("@fiid_reason", SqlDbType.Int);
                param[0].Value = iIdReason;

                
                objDB.ExecStoredIUD("sp_deleteReason", param);
                
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

        public errorCompositeType UpdateReason(int iIdReason, int iNumber, String sDescription)
        {
            errorCompositeType lstError = new errorCompositeType();

            try
            {
               
                param = new SqlParameter[3];
                param[0] = new SqlParameter("@fiid_reason", SqlDbType.Int);
                param[0].Value = iIdReason;
                param[1] = new SqlParameter("@finumber_reason", SqlDbType.Int);
                param[1].Value = iNumber;
                param[2] = new SqlParameter("@fvdescription_reason", SqlDbType.VarChar);
                param[2].Value = sDescription;
                

                
                objDB.ExecStore("sp_updateReason", param);
                
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
        public List<reasonCompositeType> getAll()
        {
            List<reasonCompositeType> lst = new List<reasonCompositeType>();


            //try
            //{
                
                DataTable dt = objDB.Consult("sp_selectReason");
                

                foreach (DataRow dr in dt.Rows)
                {
                    reasonCompositeType et = new reasonCompositeType();
                    et.iIdReason = int.Parse(dr.ItemArray[0].ToString());
                    et.iNumber = int.Parse(dr.ItemArray[1].ToString());
                    et.sDescription = dr.ItemArray[2].ToString();
                    et.bStatus = bool.Parse(dr.ItemArray[3].ToString());

                    lst.Add(et);
                }
                return lst;
            //}
            //catch (Exception ex)
            //{
            //    throw ex.Message();
            //}


        }

        public reasonCompositeType GetReasonById(int iIdReason)
        {
            reasonCompositeType et = new reasonCompositeType();

            //try
            //{
            param = new SqlParameter[1];
            param[0] = new SqlParameter("@fiid_reason", SqlDbType.Int);
            param[0].Value = iIdReason;

            
            DataTable dt = objDB.ExecStore("sp_getReasonById", param);
            

            et.iIdReason = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            et.iNumber = int.Parse(dt.Rows[0].ItemArray[1].ToString());
            et.sDescription = dt.Rows[0].ItemArray[2].ToString();
            et.bStatus = bool.Parse(dt.Rows[0].ItemArray[3].ToString());


            return et;
            //}
            //catch (Exception ex)
            //{
            //    throw ex.Message();
            //}


        }

        public int getCountReasonByNumber(int iNumber)
        {
            param = new SqlParameter[1];
            param[0] = new SqlParameter("@finumber_reason", SqlDbType.Int);
            param[0].Value = iNumber;

            
            DataTable dt = objDB.ExecStore("sp_countReasonByNumber", param);
            
            return int.Parse(dt.Rows[0].ItemArray[0].ToString());
        }

        public int getCountReasonDuplicate(int iIdReason, String sDescription, int iNumber)
        {
            param = new SqlParameter[3];
            param[0] = new SqlParameter("@fiid_reason", SqlDbType.Int);
            param[0].Value = iIdReason;
            param[1] = new SqlParameter("@finumber_reason", SqlDbType.Int);
            param[1].Value = iNumber;
            param[2] = new SqlParameter("@fvdescription_reason", SqlDbType.VarChar);
            param[2].Value = sDescription;
            
            
            DataTable dt = objDB.ExecStore("sp_countReasonDuplicate", param);
            
            return int.Parse(dt.Rows[0].ItemArray[0].ToString());
        }

        #endregion
        

        #endregion
    }
}
