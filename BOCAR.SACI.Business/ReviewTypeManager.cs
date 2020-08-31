using System;
using System.Collections.Generic;
using System.Linq;
using BOCAR.SACI.Data;

namespace BOCAR.SACI.Business
{
    public class ReviewTypeManager
    {
        public ReviewTypeManager()
        {

        }


        public errorCompositeType AddReviewType(String description)
        {
            var lstError = new errorCompositeType();
            try
            {
                var et = new ReviewType();
                et.InsertReviewType(description);
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

        public errorCompositeType DeleteReviewType(int iIdReviewType)
        {
            var lstError = new errorCompositeType();
            try
            {
                var et = new ReviewType();
                et.DeleteReviewType(iIdReviewType);
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

        public List<reviewTypeCompositeType> getAllReviewType()
        {
            List<reviewTypeCompositeType> lst = new List<reviewTypeCompositeType>();
            ReviewType et = new ReviewType();
            lst = et.getAll();
            return lst;
        }

        public reviewTypeCompositeType getReviewTypeById(int iIdReviewType)
        {
            reviewTypeCompositeType etct = new reviewTypeCompositeType();
            ReviewType et = new ReviewType();
            etct = et.GetReviewTypeById(iIdReviewType);
            return etct;
        }

        public errorCompositeType UpdateReviewType(int iIdReviewType, String sDescription)
        {
            errorCompositeType lstError = new errorCompositeType();
            try
            {
                ReviewType et = new ReviewType();
                et.UpdateReviewType(iIdReviewType, sDescription);
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

				public bool ExistReview(string sDescription)
				{
					var chocorroles = new ReviewType();
					var swap = chocorroles.getAll();
					var qbo = (from s in swap where s.sDescription.Equals(sDescription) select s).Count();
					return qbo >= 1;
				}

        public bool ExistReviewTypeDuplicate(String sDescription, int iIdArea)
        {
        	var t = new ReviewType();
        	return t.getCountReviewTypeDuplicate(iIdArea, sDescription) > 0;
        }
    }
}
