using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DS.SAI.Data
{
	public class ReviewExchange : IReviewExchange
	{
		private SqlParameter[] param;

		private ClassDB objDB = new ClassDB();
		private DataTable dt = new DataTable();
		private List<ReviewExchangeCompositeType> ls = new List<ReviewExchangeCompositeType>();

		#region ReviewExchange Methods

		//#region Insert

		//public errorCompositeType InsertReviewExchange(int iIdReview, int iIdAffectation, int iIdExchange)
		//{
		//    errorCompositeType lstError = new errorCompositeType();

		//    try
		//    {
		//        bool bStatus = true;
		//        param = new SqlParameter[3];
		//        param[0] = new SqlParameter("@fiid_part_list", SqlDbType.Int);
		//        param[0].Value = iIdReview;
		//        param[1] = new SqlParameter("@fiid_affectation_type", SqlDbType.Bit);
		//        param[1].Value = iIdAffectation;
		//        param[2] = new SqlParameter("@fiid_Exchange", SqlDbType.Int);
		//        param[2].Value = iIdExchange;

		//        
		//        objDB.ExecStoredIUD("sp_insertReviewExchange", param);
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

		//#region Update

		//public errorCompositeType DeleteReviewExchange(int iIdReviewExchange)
		//{
		//    errorCompositeType lstError = new errorCompositeType();

		//    try
		//    {
		//        param = new SqlParameter[1];
		//        param[0] = new SqlParameter("@fiid_Exchange_part_list", SqlDbType.Int);
		//        param[0].Value = iIdReviewExchange;

		//        
		//        objDB.ExecStoredIUD("sp_deleteReviewExchange", param);
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

		//public errorCompositeType UpdateReviewExchange(int iIdListPartExchange, int iIdReview, int iIdAffectation, int iIdExchange)
		//{
		//    errorCompositeType lstError = new errorCompositeType();

		//    try
		//    {
		//        param = new SqlParameter[4];
		//        param[0] = new SqlParameter("@fiid_part_list", SqlDbType.Int);
		//        param[0].Value = iIdReview;
		//        param[1] = new SqlParameter("@fiid_affectation_type", SqlDbType.Bit);
		//        param[1].Value = iIdAffectation;
		//        param[2] = new SqlParameter("@fiid_Exchange", SqlDbType.Int);
		//        param[2].Value = iIdExchange;
		//        param[3] = new SqlParameter("@fiid_Exchange_part_list", SqlDbType.Int);
		//        param[3].Value = iIdListPartExchange;


		//        
		//        objDB.ExecStore("sp_updateReviewExchange", param);
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

		//public List<ReviewExchangeCompositeType> getAll(int iIdListPartExchange)
		//{
		//    List<ReviewExchangeCompositeType> lst = new List<ReviewExchangeCompositeType>();


		//    //try
		//    //{
		//    param = new SqlParameter[1];
		//    param[0] = new SqlParameter("@fiid_Exchange_part_list", SqlDbType.Int);
		//    param[0].Value = iIdListPartExchange;

		//    
		//    DataTable dt = objDB.Consult("sp_SelectReviewExchangeById");
		//    

		//    foreach (DataRow dr in dt.Rows)
		//    {
		//        ReviewExchangeCompositeType et = new ReviewExchangeCompositeType();
		//        et.iIdReviewExchange = int.Parse(dr.ItemArray[0].ToString());
		//        et.iIdReview = int.Parse(dr.ItemArray[1].ToString());
		//        et.iIdAffectation = int.Parse(dr.ItemArray[2].ToString());
		//        et.iIdExchange = int.Parse(dr.ItemArray[3].ToString());
		//        et.sReviewDS = dr.ItemArray[4].ToString();
		//        et.sReviewDescription = dr.ItemArray[5].ToString();
		//        et.sReviewClient = dr.ItemArray[6].ToString();
		//        et.sAffectationDescription = dr.ItemArray[7].ToString();
		//        et.sFolio = dr.ItemArray[8].ToString();
		//        et.sPreFolio = dr.ItemArray[9].ToString();
		//        lst.Add(et);
		//    }
		//    return lst;
		//    //}
		//    //catch (Exception ex)
		//    //{
		//    //    throw ex.Message();
		//    //}
		//}

		////public ReviewExchangeCompositeType GetReviewExchangeById(int iIdReviewExchange)
		////{
		////    ReviewExchangeCompositeType et = new ReviewExchangeCompositeType();

		////    //try
		////    //{
		////    param = new SqlParameter[1];
		////    param[0] = new SqlParameter("@fiid_Exchange_part_list", SqlDbType.Int);
		////    param[0].Value = iIdReviewExchange;

		////    
		////    DataTable dt = objDB.ExecStore("sp_SelectReviewExchangeById", param);
		////    


		////    et.iIdReviewExchange = int.Parse(dt.Rows[0].ItemArray[0].ToString());
		////    et.iIdReview = int.Parse(dt.Rows[0].ItemArray[1].ToString());
		////    et.iIdAffectation = int.Parse(dt.Rows[0].ItemArray[2].ToString());
		////    et.iIdExchange = int.Parse(dt.Rows[0].ItemArray[3].ToString());
		////    et.sReviewDS = dt.Rows[0].ItemArray[4].ToString();
		////    et.sReviewDescription = dt.Rows[0].ItemArray[5].ToString();
		////    et.sReviewClient = dt.Rows[0].ItemArray[6].ToString();
		////    et.sAffectationDescription = dt.Rows[0].ItemArray[7].ToString();
		////    et.sFolio = dt.Rows[0].ItemArray[8].ToString();
		////    et.sPreFolio = dt.Rows[0].ItemArray[9].ToString();

		////    return et;
		////    //}
		////    //catch (Exception ex)
		////    //{
		////    //    throw ex.Message();
		////    //}
		////}

		//public int getCountReviewExchangeDuplicate(int iIdReview, int iIdAffectation, int iIdExchange)
		//{
		//    param = new SqlParameter[3];
		//    param[0] = new SqlParameter("@fiid_part_list", SqlDbType.Int);
		//    param[0].Value = iIdReview;
		//    param[1] = new SqlParameter("@fiid_Exchange", SqlDbType.Int);
		//    param[1].Value = iIdAffectation;
		//    param[2] = new SqlParameter("@fiid_affectation_type", SqlDbType.Int);
		//    param[2].Value = iIdExchange;

		//    
		//    DataTable dt = objDB.ExecStore("sp_countReviewExchangeDuplicate", param);
		//    
		//    return int.Parse(dt.Rows[0].ItemArray[0].ToString());
		//}

		//#endregion

		#endregion
	}
}