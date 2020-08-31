using System;
using System.Collections.Generic;
using BOCAR.SACI.Data;

namespace BOCAR.SACI.Business
{
	public class ExchangeAutorizationManager
	{
		public ExchangeAutorizationManager() {}

		public errorCompositeType AddExchangeAutorization(ExchangeAutorizationCompositeType eact)
		{
			var lstError = new errorCompositeType();
			try
			{
				var et = new ExchangeAutorization();
				et.InsertExchangeAutorization(eact);
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

		public errorCompositeType UpdateExchangeAutorization(ExchangeAutorizationCompositeType eact)
		{
			var lstError = new errorCompositeType();
			try
			{
				var et = new ExchangeAutorization();
				et.UpdateExchangeAutorization(eact);
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

		//public errorCompositeType DeleteExchangeAutorization(int iIdExchangeAutorization)
		//{
		//    errorCompositeType lstError = new errorCompositeType();
		//    try
		//    {
		//        ExchangeAutorization et = new ExchangeAutorization();
		//        et.DeleteExchangeAutorization(iIdExchangeAutorization);
		//        lstError.bError = true;
		//        lstError.sError = "";
		//        return lstError;
		//    }
		//    catch (Exception ex)
		//    {
		//        lstError.bError = false;
		//        lstError.sError = ex.Message;
		//        return lstError;
		//    }
		//}

		//public  List<ExchangeAutorizationCompositeType> getAllExchangeAutorization(int iIdExchangeAutorization)
		//{
		//    List<ExchangeAutorizationCompositeType> lst = new List<ExchangeAutorizationCompositeType>();
		//    ExchangeAutorization et = new ExchangeAutorization();
		//    lst = et.getAll(iIdExchangeAutorization);
		//    return lst;
		//}

		public ExchangeAutorizationCompositeType getExchangeAutorizationById(int iIdExchange)
		{
			var ea = new ExchangeAutorization();
			return ea.GetExchangeAutorizationById(iIdExchange);
		}

		public List<string> GetInforAutorizacionIng(int iIdExchange)
		{
			var ea = new ExchangeAutorization();
			return ea.GetInforAutorizacionIng(iIdExchange);
		}

		//public errorCompositeType UpdateExchangeAutorization(int iIdListPartExchange, int iIdPartList, int iIdAffectation, int iIdExchange)
		//{
		//    errorCompositeType lstError = new errorCompositeType();
		//    try
		//    {
		//        ExchangeAutorization et = new ExchangeAutorization();
		//        et.UpdateExchangeAutorization(iIdListPartExchange, iIdPartList, iIdAffectation, iIdExchange);
		//        lstError.bError = true;
		//        lstError.sError = "";
		//        return lstError;
		//    }
		//    catch (Exception ex)
		//    {
		//        lstError.bError = false;
		//        lstError.sError = ex.Message;
		//        return lstError;
		//    }
		//}
		
		public bool ExistExchangeAutorization(int iIdExchange)
		{
			var ea = new ExchangeAutorization();
			return (ea.GetExchangeAutorizationByIdCount(iIdExchange)) > 0;
		}
	}
}