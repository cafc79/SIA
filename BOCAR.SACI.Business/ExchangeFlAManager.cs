using System;
using BOCAR.SACI.Data;

namespace BOCAR.SACI.Business
{
	public class ExchangeFlAManager
	{

		public errorCompositeType AddExchangeFlA(ExchangeFlACompositeType ectExchangeFlA)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				ExchangeFlA et = new ExchangeFlA();
				et.InsertExchangeFlA(ectExchangeFlA);
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

		//    public errorCompositeType UpdateExchangeFlA(ExchangeFlACompositeType ectExchangeFlA)
		//    {
		//        errorCompositeType lstError = new errorCompositeType();
		//        try
		//        {
		//            ExchangeFlA et = new ExchangeFlA();
		//            et.UpdateExchangeFlAById(ectExchangeFlA);
		//            lstError.bError = true;
		//            lstError.sError = "";
		//            return lstError;
		//        }
		//        catch (Exception ex)
		//        {
		//            lstError.bError = false;
		//            lstError.sError = ex.Message;
		//            return lstError;
		//        }
		//    }

		//   public int GetNumberPrefolio()
		//    {
		//        int iPrefolio;

		//            ExchangeFlA et = new ExchangeFlA();
		//            iPrefolio = et.getNumberPreFolio();
		//            return iPrefolio;
		//   }

		//   public int GetNumberFolio()
		//   {
		//       int Folio;

		//       ExchangeFlA et = new ExchangeFlA();
		//       Folio = et.getNumberFolio();
		//       return Folio;
		//   }


		//    public ExchangeFlACompositeType getExchangeFlAByPreFolioUnique(String sPrefolio)
		//    {
		//        ExchangeFlACompositeType ect = new ExchangeFlACompositeType();
		//        ExchangeFlA e = new ExchangeFlA();
		//        ect = e.getExchangeFlAByPreFolioUnique(sPrefolio);
		//        return ect;

		//    }

		//    public ExchangeFlACompositeType getExchangeFlAById(int iIdExchangeFlA)
		//    {
		//        ExchangeFlACompositeType ect = new ExchangeFlACompositeType();
		//        ExchangeFlA e = new ExchangeFlA();
		//        ect = e.getExchangeFlAById(iIdExchangeFlA);
		//        return ect;

		//    }

		//    public DataTable getExchangeFlAByPreFolio(String sPrefolio)
		//    {
		//        ExchangeFlA e = new ExchangeFlA();
		//        DataTable dt = new DataTable();
		//        dt = e.GetExchangeFlAByPreFolio(sPrefolio);
		//        return dt;

		//    }
	}
}