using System;
using System.Collections.Generic;
using DS.SAI.Data;

namespace DS.SAI.Business
{
	public class TaskExchangeManager
	{
		private TaskExchange te;

		public TaskExchangeManager()
		{
			te = new TaskExchange();
		}

		public errorCompositeType AddTaskExchange(TaskExchangeCompositeType tect)
		{
			var lstError = new errorCompositeType();
			try
			{
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

		public errorCompositeType InsertBulkTaskExchange(int iTiming, List<string> lstTask, int iExchange, DateTime dTiming, int iGroup)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				var sb = new System.Text.StringBuilder();
				foreach (string task in lstTask)
					sb.AppendFormat("{0}|", task);
				te.InsertBulkTaskExchange(iTiming, sb.ToString(), iExchange, dTiming, iGroup);
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

		public TaskExchangeCompositeType getTaskExchangeByIdTaskIdExchange(TaskExchangeCompositeType tect)
		{
			TaskExchangeCompositeType etct = new TaskExchangeCompositeType();
			etct = te.GetTaskExchangeByIdTaskIdExchange(tect);
			return etct;
		}

		public int getCountTaskExchangeByIdTaskIdExchange(TaskExchangeCompositeType tect)
		{
			int a = te.GetCountTaskExchangeByIdTaskIdExchange(tect);
			return a;
		}

		public int getMaxTimingByIdExchange(ExchangeCompositeType ect)
		{
			int a = te.GetMaxTimingTaskExchangeByIdExchange(ect);
			return a;
		}

		public TaskExchangeCompositeType getTaskExchangeByIdTaskIdExchangeTaskPre(TaskExchangeCompositeType tect)
		{
			TaskExchangeCompositeType etct = new TaskExchangeCompositeType();
			etct = te.GetTaskExchangeByIdTaskIdExchangeTaskPre(tect);
			return etct;
		}

		public int getCountTaskExchangeByIdTaskIdExchangeTaskPre(TaskExchangeCompositeType tect)
		{
			int a = te.GetCountTaskExchangeByIdTaskIdExchangeTaskPre(tect);
			return a;
		}

		public errorCompositeType DeleteTaskExchange(int iIdTaskExchange)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				te = new TaskExchange();
				te.DeleteTaskExchange(iIdTaskExchange);
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
		//

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

		public errorCompositeType UpdateTaskExchange(TaskExchangeCompositeType tect, string sDesencadenante)
		{
			var lstError = new errorCompositeType();
			try
			{
				var et = new TaskExchange();
				et.UpdateTaskExchange(tect, sDesencadenante);

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

		public errorCompositeType updateTaskSerie(TaskExchangeCompositeType tect, int iDiference, string sDesencadenante)
		{
			var lstError = new errorCompositeType();
			try
			{
				var te = new TaskExchange();
				var tect2 = new TaskExchangeCompositeType();
				UpdateTaskExchange(tect, sDesencadenante);
				int iTaskExchangePre = tect.iNextTask;
				tect2.iExchange = tect.iExchange;
				tect2.iNextTask = tect.iTask;
				while (getCountTaskExchangeByIdTaskIdExchangeTaskPre(tect2) > 0)
				{
					tect2 = getTaskExchangeByIdTaskIdExchangeTaskPre(tect2);
					tect2.iTimingTotal = tect2.iTimingTotal - iDiference;
					UpdateTaskExchange(tect2, sDesencadenante);
					tect2.iNextTask = tect2.iTask;
					if (getCountTaskExchangeByIdTaskIdExchangeTaskPre(tect2) > 0)
					{
						tect2 = getTaskExchangeByIdTaskIdExchangeTaskPre(tect2);
					}
					else
					{
						tect2.iNextTask = 0;
						tect2.iExchange = 0;
					}
				}
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

		public void UpdateTime_byGenerate(int iExchange, DateTime dAplicacion, string sDesencadenante)
		{
			var tareas = new TaskExchange();
			var dt = tareas.GetTimming(iExchange);
			for(int i = 0; i < dt.Rows.Count; i++)
			{
				var tectA = new TaskExchangeCompositeType
				            	{
				            		iExchange = iExchange,
				            		iTask = int.Parse(dt.Rows[i].ItemArray[3].ToString())
				            	};
				var tect = tareas.GetTaskExchangeByIdTaskIdExchange(tectA);
				tect.dTiming = dAplicacion.AddDays(tect.iTimingTotal * 7);
				UpdateTaskExchange(tect, sDesencadenante);
			}
		}

		#endregion
	}
}