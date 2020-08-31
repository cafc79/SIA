using System;
using BOCAR.SACI.Data;

namespace BOCAR.SACI.Business
{
	public class ExchangeFileManager
	{

		public errorCompositeType AddExchangeFile(ExchangeFileCompositeType tect)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				ExchangeFile te = new ExchangeFile();
				te.InsertTaskExchange(tect);
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

		#region comment
		//public errorCompositeType DeleteTaskExchange(int iIdTaskExchange)
		//{
		//    errorCompositeType lstError = new errorCompositeType();
		//    try
		//    {
		//        TaskExchange et = new TaskExchange();
		//        et.DeleteTaskExchange(iIdTaskExchange);
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

		//public List<TaskExchangeCompositeType> getAllTaskExchange()
		//{
		//    List<TaskExchangeCompositeType> lst = new List<TaskExchangeCompositeType>();
		//    TaskExchange et = new TaskExchange();
		//    lst = et.getAll();
		//    return lst;
		//}

		//public TaskExchangeCompositeType getTaskExchangeById(int iIdTaskExchange)
		//{
		//    TaskExchangeCompositeType etct = new TaskExchangeCompositeType();
		//    TaskExchange et = new TaskExchange();
		//    etct = et.GetTaskExchangeById(iIdTaskExchange);
		//    return etct;
		//}

		//public errorCompositeType UpdateTaskExchange(int iIdTaskExchange, int iIdTask, int iIdGroup)
		//{
		//    errorCompositeType lstError = new errorCompositeType();
		//    try
		//    {
		//        TaskExchange et = new TaskExchange();
		//        et.UpdateTaskExchange(iIdTaskExchange, iIdTask, iIdGroup);
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


		//public bool ExistTaskExchangeDuplicate(int iIdTask, int iIdGroup, int IdEntity)
		//{
		//    TaskExchange t = new TaskExchange();


		//    if (t.getCountTaskExchangeDuplicate(iIdTask, iIdGroup, IdEntity) > 0)
		//    {
		//        return true;
		//    }
		//    else
		//    {
		//        return false;
		//    }

		//}
		#endregion
	}
}