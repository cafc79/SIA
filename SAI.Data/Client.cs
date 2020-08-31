using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DS.SAI.Data
{
    public class Client : IClient
    {
        private SqlParameter[] param;

        private ClassDB objDB = new ClassDB();
        private DataTable dt = new DataTable();
        private List<clientCompositeType> ls = new List<clientCompositeType>();

        #region Client Methods

        #region Insert
        /// <summary>
        /// Inserta un Tipo de Cambio(Client) en la base de datos
        /// </summary>
        /// <param name="sDescription">La descripción</param>
        public errorCompositeType InsertClient(String sDescription)
        {
            errorCompositeType lstError = new errorCompositeType();

            try
            {
                bool bStatus = true;
                param = new SqlParameter[2];
                param[0] = new SqlParameter("@fvdescription_client", SqlDbType.VarChar);
                param[0].Value = sDescription;
                param[1] = new SqlParameter("@fbstatus_client", SqlDbType.Bit);
                param[1].Value = bStatus;
                objDB.ExecStoredIUD("sp_insertClient", param);
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

        public errorCompositeType DeleteClient(int iIdClient)
        {
            errorCompositeType lstError = new errorCompositeType();

            try
            {
                param = new SqlParameter[1];
                param[0] = new SqlParameter("@fiid_client", SqlDbType.Int);
                param[0].Value = iIdClient;

                
                objDB.ExecStoredIUD("sp_deleteClient", param);
                
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

        public errorCompositeType UpdateClient(int iIdClient, String sDescription)
        {
            errorCompositeType lstError = new errorCompositeType();

            try
            {
                param = new SqlParameter[2];
                param[0] = new SqlParameter("@fiid_client", SqlDbType.Int);
                param[0].Value = iIdClient;
                param[1] = new SqlParameter("@fvdescription_client", SqlDbType.VarChar);
                param[1].Value = sDescription;


                
                objDB.ExecStore("sp_updateClient", param);
                
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
        public List<clientCompositeType> getAll()
        {
            List<clientCompositeType> lst = new List<clientCompositeType>();


            //try
            //{
            
            DataTable dt = objDB.Consult("sp_selectClient");
            

            foreach (DataRow dr in dt.Rows)
            {
                clientCompositeType et = new clientCompositeType();
                et.iIdClient = int.Parse(dr.ItemArray[0].ToString());
                et.sDescription = dr.ItemArray[1].ToString();
                et.bStatus = bool.Parse(dr.ItemArray[2].ToString());

                lst.Add(et);
            }
            return lst;
            //}
            //catch (Exception ex)
            //{
            //    throw ex.Message();
            //}


        }

        public clientCompositeType GetClientById(int iIdClient)
        {
            clientCompositeType et = new clientCompositeType();

            //try
            //{
            param = new SqlParameter[1];
            param[0] = new SqlParameter("@fiid_client", SqlDbType.Int);
            param[0].Value = iIdClient;

            
            DataTable dt = objDB.ExecStore("sp_getClientById", param);
            

            et.iIdClient = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            et.sDescription = dt.Rows[0].ItemArray[1].ToString();
            et.bStatus = bool.Parse(dt.Rows[0].ItemArray[2].ToString());


            return et;
            //}
            //catch (Exception ex)
            //{
            //    throw ex.Message();
            //}
        }

			/*
        public int getCountClientByDescription(String sDescription)
        {
            param = new SqlParameter[1];
            param[0] = new SqlParameter("@fvdescription_client", SqlDbType.VarChar);
            param[0].Value = sDescription;

            
            DataTable dt = objDB.ExecStore("sp_countClientByDescription", param);
            
            return int.Parse(dt.Rows[0].ItemArray[0].ToString());
        }

        public int getCountClientByDescription(String sDescription, int iIdClient)
        {
            param = new SqlParameter[2];
            param[0] = new SqlParameter("@fvdescription_client", SqlDbType.VarChar);
            param[0].Value = sDescription;
            param[1] = new SqlParameter("@fiid_client", SqlDbType.Int);
            param[1].Value = iIdClient;

            
            DataTable dt = objDB.ExecStore("sp_countClientByDescriptionId", param);
            
            return int.Parse(dt.Rows[0].ItemArray[0].ToString());
        }*/

        public int getCountClientDuplicate(int iIdClient, String sDescription)
        {
            param = new SqlParameter[2];
            param[0] = new SqlParameter("@fiid_client", SqlDbType.Int);
            param[0].Value = iIdClient;
            param[1] = new SqlParameter("@fvdescription_client", SqlDbType.VarChar);
            param[1].Value = sDescription;

            
            DataTable dt = objDB.ExecStore("sp_countClientDuplicate", param);
            
            return int.Parse(dt.Rows[0].ItemArray[0].ToString());
        }
        #endregion

        #endregion
    }
}
