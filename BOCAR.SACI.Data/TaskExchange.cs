using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BOCAR.SACI.Data
{
	public class TaskExchange : ITaskExchange
	{
		private SqlParameter[] param;
		private ClassDB objDB = new ClassDB();
		private List<TaskExchangeCompositeType> ls = new List<TaskExchangeCompositeType>();

		public errorCompositeType DeleteTaskExchange(int iIdTaskExchange)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@iTaskExchange", SqlDbType.Int) { Value = iIdTaskExchange };
				objDB.ExecStoredIUD("sp_deleteTaskExchange", param);
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

		public errorCompositeType InsertTaskExchange(TaskExchangeCompositeType tect)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[8];
				param[0] = new SqlParameter("@fvtiming_task_exchange", SqlDbType.Int) {Value = tect.iTiming};
				param[1] = new SqlParameter("@finext_task", SqlDbType.Int) {Value = tect.iNextTask};
				param[2] = new SqlParameter("@fiid_task", SqlDbType.Int) {Value = tect.iTask};
				param[3] = new SqlParameter("@fiid_exchange", SqlDbType.Int) {Value = tect.iExchange};
				param[4] = new SqlParameter("@fiid_employed", SqlDbType.Int) {Value = tect.iEmployed};
				param[5] = new SqlParameter("@fi_timing_total", SqlDbType.Int) {Value = tect.iTimingTotal};
				param[6] = new SqlParameter("@fvtiming_task_exchange_Date", SqlDbType.DateTime) { Value = tect.dTiming };
				param[7] = new SqlParameter("@fiGroup", SqlDbType.Int) { Value = tect.iGroup };
				objDB.ExecStoredIUD("sp_insertTaskExchange", param);
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

		public errorCompositeType InsertBulkTaskExchange(int iTiming, string lstTask, int iExchange, DateTime dTiming, int iGroup)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[5];
				param[0] = new SqlParameter("@fvtiming_task_exchange", SqlDbType.Int) { Value = iTiming };
				param[1] = new SqlParameter("@fiid_task", SqlDbType.VarChar) { Value = lstTask };
				param[2] = new SqlParameter("@fiid_exchange", SqlDbType.Int) { Value = iExchange };
				param[3] = new SqlParameter("@fvtiming_task_exchange_Date", SqlDbType.DateTime) { Value = dTiming };
				param[4] = new SqlParameter("@fiGroup", SqlDbType.Int) { Value = iGroup };
				objDB.ExecStoredIUD("sp_insertBulkTaskExchange", param);
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

		public errorCompositeType UpdateTaskExchange(TaskExchangeCompositeType tect, string sDesencadenante)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[9];
				param[0] = new SqlParameter("@fvtiming_task_exchange", SqlDbType.Int) {Value = tect.iTiming};
				param[1] = new SqlParameter("@finext_task", SqlDbType.Int) {Value = tect.iNextTask};
				param[2] = new SqlParameter("@fiid_task", SqlDbType.Int) {Value = tect.iTask};
				param[3] = new SqlParameter("@fiid_exchange", SqlDbType.Int) {Value = tect.iExchange};
				param[4] = new SqlParameter("@fiid_employed", SqlDbType.Int) {Value = tect.iEmployed};
				param[5] = new SqlParameter("@fi_timing_total", SqlDbType.Int) {Value = tect.iTimingTotal};
				param[6] = new SqlParameter("@fvtiming_task_exchange_Date", SqlDbType.DateTime) {Value = tect.dTiming};
				param[7] = new SqlParameter("@fiid_task_exchange", SqlDbType.Int) {Value = tect.iIdTaskExchange};
				param[8] = new SqlParameter("@fvDesencadenante", SqlDbType.VarChar) { Value = sDesencadenante };
				objDB.ExecStoredIUD("[sp_updateTaskExchange]", param);
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

		public TaskExchangeCompositeType GetTaskExchangeByIdTaskIdExchange(TaskExchangeCompositeType tect)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@fiid_task", SqlDbType.Int) {Value = tect.iTask};
			param[1] = new SqlParameter("@fiid_exchange", SqlDbType.Int) {Value = tect.iExchange};
			DataTable dt = objDB.ExecStore("sp_selectTskExchangeByIdTaskIdExchange", param);
			//tect.bAlarm = bool.Parse(dt.Rows[0].ItemArray[7].ToString());
			tect.dTiming = DateTime.Parse(dt.Rows[0].ItemArray[6].ToString());
			tect.iArea = int.Parse(dt.Rows[0].ItemArray[8].ToString());
			tect.iEmployed = int.Parse(dt.Rows[0].ItemArray[5].ToString());
			tect.iExchange = int.Parse(dt.Rows[0].ItemArray[4].ToString());
			tect.iIdTaskExchange = int.Parse(dt.Rows[0].ItemArray[0].ToString());
			tect.iNextTask = int.Parse(dt.Rows[0].ItemArray[2].ToString());
			tect.iTask = int.Parse(dt.Rows[0].ItemArray[3].ToString());
			tect.iTiming = int.Parse(dt.Rows[0].ItemArray[1].ToString());
			tect.iTimingTotal = int.Parse(dt.Rows[0].ItemArray[13].ToString());
			tect.sArea = dt.Rows[0].ItemArray[8].ToString();
			tect.sEmployed = dt.Rows[0].ItemArray[12].ToString();
			tect.sNestTask = dt.Rows[0].ItemArray[11].ToString();
			tect.sNumberArea = dt.Rows[0].ItemArray[10].ToString();
			tect.sTask = dt.Rows[0].ItemArray[7].ToString();
			return tect;
		}

		public TaskExchangeCompositeType GetTaskExchangeByIdTaskIdExchangeTaskPre(TaskExchangeCompositeType tect)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@fiid_exchange", SqlDbType.Int) {Value = tect.iExchange};
			param[1] = new SqlParameter("@finext_task", SqlDbType.Int) {Value = tect.iNextTask};
			DataTable dt = objDB.ExecStore("sp_selectTskExchangeByIdTaskIdExchangeIdNextTask", param);
			//tect.bAlarm = bool.Parse(dt.Rows[0].ItemArray[7].ToString());
			tect.dTiming = DateTime.Parse(dt.Rows[0].ItemArray[6].ToString());
			tect.iArea = int.Parse(dt.Rows[0].ItemArray[8].ToString());
			tect.iEmployed = int.Parse(dt.Rows[0].ItemArray[5].ToString());
			tect.iExchange = int.Parse(dt.Rows[0].ItemArray[4].ToString());
			tect.iIdTaskExchange = int.Parse(dt.Rows[0].ItemArray[0].ToString());
			tect.iNextTask = int.Parse(dt.Rows[0].ItemArray[2].ToString());
			tect.iTask = int.Parse(dt.Rows[0].ItemArray[3].ToString());
			tect.iTiming = int.Parse(dt.Rows[0].ItemArray[1].ToString());
			tect.iTimingTotal = int.Parse(dt.Rows[0].ItemArray[13].ToString());
			tect.sArea = dt.Rows[0].ItemArray[8].ToString();
			tect.sEmployed = dt.Rows[0].ItemArray[12].ToString();
			tect.sNestTask = dt.Rows[0].ItemArray[11].ToString();
			tect.sNumberArea = dt.Rows[0].ItemArray[10].ToString();
			tect.sTask = dt.Rows[0].ItemArray[7].ToString();
			return tect;
		}

		public int GetCountTaskExchangeByIdTaskIdExchange(TaskExchangeCompositeType tect)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@fiid_exchange", SqlDbType.Int) {Value = tect.iExchange};
			param[1] = new SqlParameter("@fiid_task", SqlDbType.Int) {Value = tect.iTask};
			DataTable dt = objDB.ExecStore("sp_selectCountTskExchangeByIdTaskIdExchange", param);
			return int.Parse(dt.Rows[0].ItemArray[0].ToString());
		}

		public int GetCountTaskExchangeByIdTaskIdExchangeTaskPre(TaskExchangeCompositeType tect)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@finext_task", SqlDbType.Int) {Value = tect.iNextTask};
			param[1] = new SqlParameter("@fiid_exchange", SqlDbType.Int) {Value = tect.iExchange};
			DataTable dt = objDB.ExecStore("sp_selectCountTskExchangeByIdTaskIdExchangeIdNextTask", param);
			return int.Parse(dt.Rows[0].ItemArray[0].ToString());
		}
		//Add
		public int GetMaxTimingTaskExchangeByIdExchange(ExchangeCompositeType ect)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_exchange", SqlDbType.Int) {Value = ect.iIdExchange};
			DataTable dt = objDB.ExecStore("sp_selectMaxTimingByIdExchange", param);
			return int.Parse(dt.Rows[0].ItemArray[0].ToString());
		}

		public DataTable GetTimming(int iIdExchange)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_exchange", SqlDbType.Int) { Value = iIdExchange };
			return objDB.ExecStore("sp_selectExchangeTaskByIdExchange", param);
		}
	}
}