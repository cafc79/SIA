using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DS.SAI.Data
{
    public class ExchangeFlA : IExchangeFlA
    {
        private SqlParameter[] param;//comentario prueba

        private ClassDB objDB = new ClassDB();
        private DataTable dt = new DataTable();
        
        #region ExchangeFlA Methods

        //#region Insert

        public errorCompositeType InsertExchangeFlA(ExchangeFlACompositeType ect)
        {
            errorCompositeType lstError = new errorCompositeType();

            try
            {
                bool bStatus = true;
                param = new SqlParameter[12];


                param[0] = new SqlParameter("@fdDateIn", SqlDbType.DateTime);
                param[0].Value = ect.dDateIn;
                param[1] = new SqlParameter("@fdDatePromese", SqlDbType.DateTime);
                param[1].Value = ect.dDatePromise;
                param[2] = new SqlParameter("@fdDateOut", SqlDbType.DateTime);
                param[2].Value = ect.dDateOut;
                param[3] = new SqlParameter("@fvSOP", SqlDbType.VarChar);
                param[3].Value = ect.SOECliente;
                param[4] = new SqlParameter("@fiMold", SqlDbType.Int);
                param[4].Value = ect.iMold;
                param[5] = new SqlParameter("@fiMoldProt", SqlDbType.Int);
                param[5].Value = ect.iMoldProt;
                param[6] = new SqlParameter("@fiCostMa", SqlDbType.Int);
                param[6].Value = ect.iCost;
                param[7] = new SqlParameter("@fiDateStart", SqlDbType.Int);
                param[7].Value = ect.iDateStart;
                param[8] = new SqlParameter("@fiTotal", SqlDbType.Int);
                param[8].Value = ect.iTotalInv;
                param[9] = new SqlParameter("@fiTotalP", SqlDbType.Int);
                param[9].Value = ect.iTotalP;
                param[10] = new SqlParameter("@fbStatus", SqlDbType.Bit);
                param[10].Value = ect.bStatus;
                param[11] = new SqlParameter("@fiidEPL", SqlDbType.Int);
                param[11].Value = ect.iIdPlEA;

                
                objDB.ExecStoredIUD("sp_insertTAAfectationExchangePartList", param);
                
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


        
        //#endregion

        //#region Update

        //public errorCompositeType UpdateExchangeFlAById(ExchangeFlACompositeType ect)
        //{
        //    errorCompositeType lstError = new errorCompositeType();

        //    try
        //    {
        //        bool bStatus = true;
        //        param = new SqlParameter[18];

        //        param[0] = new SqlParameter("@fvdescription_ExchangeFlA", SqlDbType.VarChar);
        //        param[0].Value = ect.sDescription;
        //        param[1] = new SqlParameter("@fvissue_ExchangeFlA", SqlDbType.VarChar);
        //        param[1].Value = ect.sIssue;
        //        param[2] = new SqlParameter("@fvmeasure_ExchangeFlA", SqlDbType.VarChar);
        //        param[2].Value = ect.sMeasure;
        //        param[3] = new SqlParameter("@fvcontact_ExchangeFlA", SqlDbType.VarChar);
        //        param[3].Value = ect.sContact;
        //        param[4] = new SqlParameter("@fvfolio_ExchangeFlA", SqlDbType.VarChar);
        //        param[4].Value = ect.sFolio;
        //        param[5] = new SqlParameter("@fvprefolio_ExchangeFlA", SqlDbType.VarChar);
        //        param[5].Value = ect.sFolioPre;
        //        param[6] = new SqlParameter("@fvproyect_ExchangeFlA", SqlDbType.VarChar);
        //        param[6].Value = ect.sProyect;
        //        param[7] = new SqlParameter("@fdlimit_date_ExchangeFlA", SqlDbType.DateTime);
        //        param[7].Value = ect.dLimitDate;
        //        param[8] = new SqlParameter("@fvlast_folio_ExchangeFlA", SqlDbType.VarChar);
        //        param[8].Value = ect.sLastFolio;
        //        param[9] = new SqlParameter("@fistatus_ExchangeFlA", SqlDbType.Int);
        //        param[9].Value = ect.iStatus;
        //        param[10] = new SqlParameter("@fiid_plant", SqlDbType.Int);
        //        param[10].Value = ect.iIdPlant;
        //        param[11] = new SqlParameter("@fiid_ExchangeFlA_type", SqlDbType.Int);
        //        param[11].Value = ect.iIdExchangeFlAType;
        //        param[12] = new SqlParameter("@fiid_client", SqlDbType.Int);
        //        param[12].Value = ect.iIdClient;
        //        param[13] = new SqlParameter("@fvreason_ExchangeFlA", SqlDbType.VarChar);
        //        param[13].Value = ect.sReason;
        //        param[14] = new SqlParameter("@fiid_priority", SqlDbType.Int);
        //        param[14].Value = ect.iIdPriority;
        //        param[15] = new SqlParameter("@fiid_serie_proyect", SqlDbType.Int);
        //        param[15].Value = ect.iSerie;
        //        param[16] = new SqlParameter("@fiid_product_engeener", SqlDbType.Int);
        //        param[16].Value = ect.iProductEngener;
        //        param[17] = new SqlParameter("@fiid_ExchangeFlA", SqlDbType.Int);
        //        param[17].Value = ect.iIdExchangeFlA;



        //        
        //        objDB.ExecStoredIUD("sp_updateExchangeFlA", param);
        //        
        //        lstError.bError = true;
        //        return lstError;
        //    }
        //    catch (Exception ex)
        //    {
        //        lstError.bError = false;
        //        lstError.sError = ex.Message;
        //        return lstError;
        //    }


           

        //}


        //#endregion

        //#region Select
        //public DataTable GetExchangeFlAByPreFolio(String sPreFolio)
        //{

        //    param = new SqlParameter[1];
        //    param[0] = new SqlParameter("@fvPreFolio", SqlDbType.VarChar);
        //    param[0].Value = sPreFolio;

        //    
        //    DataTable dt = objDB.ExecStore("sp_selectExchangeFlA_srch", param);
        //    



        //    return dt;

        //}

        //public int getNumberPreFolio()
        //{
        //    int iFolio;


            
        //    

        //    DataTable dt = objDB.Consult("[sp_getPreFolio]");
        //    


        //    iFolio = int.Parse(dt.Rows[0].ItemArray[0].ToString());
        //    return iFolio;
        //}


        //public int getNumberFolio()
        //{
        //    int iFolio;



        //    

        //    DataTable dt = objDB.Consult("[sp_getFolio]");
        //    


        //    iFolio = int.Parse(dt.Rows[0].ItemArray[0].ToString());
        //    return iFolio;
        //}

        //public ExchangeFlACompositeType getExchangeFlAByPreFolioUnique(String sPreFolio)
        //{
        //    ExchangeFlACompositeType ect = new ExchangeFlACompositeType();
        //    param = new SqlParameter[1];
        //    param[0] = new SqlParameter("@fvprefolio_ExchangeFlA", SqlDbType.VarChar);
        //    param[0].Value = sPreFolio;

        //    
        //    DataTable dt = objDB.ExecStore("sp_selectExchangeFlAByPreFolio", param);
        //    
        //    if(dt.Rows[0].ItemArray[18].ToString() != "")
        //        ect.dAplicationDate =DateTime.Parse(dt.Rows[0].ItemArray[18].ToString());
        //    if(dt.Rows[0].ItemArray[8].ToString() != "")
        //       // ect.dLimitDate = DateTime.Parse(dt.Rows[0].ItemArray[18].ToString()).ToShortDateString();
        //    ect.iIdClient = int.Parse(dt.Rows[0].ItemArray[13].ToString());
        //    ect.iIdExchangeFlA = int.Parse(dt.Rows[0].ItemArray[0].ToString());
        //    ect.iIdExchangeFlAType =int.Parse(dt.Rows[0].ItemArray[12].ToString());
        //    ect.iIdPlant = int.Parse(dt.Rows[0].ItemArray[11].ToString());
        //    ect.iIdPriority = int.Parse(dt.Rows[0].ItemArray[15].ToString());
        //    ect.iProductEngener = int.Parse(dt.Rows[0].ItemArray[17].ToString());
        //    ect.iSerie = int.Parse(dt.Rows[0].ItemArray[16].ToString());
        //    ect.iStatus = int.Parse(dt.Rows[0].ItemArray[10].ToString());
        //    ect.sClient =dt.Rows[0].ItemArray[19].ToString();
        //    ect.sContact = dt.Rows[0].ItemArray[19].ToString();
        //    ect.sDescription = dt.Rows[0].ItemArray[1].ToString();
        //    ect.sExchangeFlAType = dt.Rows[0].ItemArray[20].ToString();
        //    ect.sFolio = dt.Rows[0].ItemArray[5].ToString();
        //    ect.sFolioPre = dt.Rows[0].ItemArray[6].ToString();
        //    ect.sIssue = dt.Rows[0].ItemArray[2].ToString();
        //    ect.sLastFolio = dt.Rows[0].ItemArray[9].ToString();
        //    ect.sMeasure= dt.Rows[0].ItemArray[3].ToString();
        //    ect.sPlant = dt.Rows[0].ItemArray[21].ToString();
        //    ect.sPriority = dt.Rows[0].ItemArray[22].ToString();
        //    ect.sProductEngener = dt.Rows[0].ItemArray[23].ToString();
        //    ect.sProyect =dt.Rows[0].ItemArray[7].ToString();
        //    ect.sReason = dt.Rows[0].ItemArray[14].ToString();
        //    ect.sSerie = dt.Rows[0].ItemArray[24].ToString();
            
        //    return ect;
        
        //}

        //public ExchangeFlACompositeType getExchangeFlAById(int iIdExchangeFlA)
        //{
        //    ExchangeFlACompositeType ect = new ExchangeFlACompositeType();
        //    param = new SqlParameter[1];
        //    param[0] = new SqlParameter("@fiid_ExchangeFlA", SqlDbType.Int  );
        //    param[0].Value = iIdExchangeFlA;

        //    
        //    DataTable dt = objDB.ExecStore("sp_selectExchangeFlAById", param);
        //    
        //    if (dt.Rows[0].ItemArray[18].ToString() != "")
        //        ect.dAplicationDate = DateTime.Parse(dt.Rows[0].ItemArray[18].ToString());
        //    if (dt.Rows[0].ItemArray[8].ToString() != "")
        //        ect.dLimitDate = DateTime.Parse(dt.Rows[0].ItemArray[8].ToString());
        //    ect.iIdClient = int.Parse(dt.Rows[0].ItemArray[13].ToString());
        //    ect.iIdExchangeFlA = int.Parse(dt.Rows[0].ItemArray[0].ToString());
        //    ect.iIdExchangeFlAType = int.Parse(dt.Rows[0].ItemArray[12].ToString());
        //    ect.iIdPlant = int.Parse(dt.Rows[0].ItemArray[11].ToString());
        //    ect.iIdPriority = int.Parse(dt.Rows[0].ItemArray[15].ToString());
        //    ect.iProductEngener = int.Parse(dt.Rows[0].ItemArray[17].ToString());
        //    ect.iSerie = int.Parse(dt.Rows[0].ItemArray[16].ToString());
        //    ect.iStatus = int.Parse(dt.Rows[0].ItemArray[10].ToString());
        //    ect.sClient = dt.Rows[0].ItemArray[19].ToString();
        //    ect.sContact = dt.Rows[0].ItemArray[19].ToString();
        //    ect.sDescription = dt.Rows[0].ItemArray[1].ToString();
        //    ect.sExchangeFlAType = dt.Rows[0].ItemArray[20].ToString();
        //    ect.sFolio = dt.Rows[0].ItemArray[5].ToString();
        //    ect.sFolioPre = dt.Rows[0].ItemArray[6].ToString();
        //    ect.sIssue = dt.Rows[0].ItemArray[2].ToString();
        //    ect.sLastFolio = dt.Rows[0].ItemArray[9].ToString();
        //    ect.sMeasure = dt.Rows[0].ItemArray[3].ToString();
        //    ect.sPlant = dt.Rows[0].ItemArray[21].ToString();
        //    ect.sPriority = dt.Rows[0].ItemArray[22].ToString();
        //    ect.sProductEngener = dt.Rows[0].ItemArray[23].ToString();
        //    ect.sProyect = dt.Rows[0].ItemArray[7].ToString();
        //    ect.sReason = dt.Rows[0].ItemArray[14].ToString();
        //    ect.sSerie = dt.Rows[0].ItemArray[24].ToString();

        //    return ect;

        //}

     
        
        //#endregion


        #endregion //sp_selectExchangeFlAByPrefolio
    }
}
