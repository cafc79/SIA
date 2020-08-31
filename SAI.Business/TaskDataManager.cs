using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DS.SAI.Data;

namespace DS.SAI.Business
{
	public class TaskDataManager
	{
		public TaskDataManager()
		{

		}

		public errorCompositeType AddTaskData(int iIdTask, int iIdGroup, String sDescription)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				TaskData et = new TaskData();
				et.InsertTaskData(iIdGroup, iIdTask, sDescription);
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

		public errorCompositeType DeleteTaskData(int iIdTaskData)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				TaskData et = new TaskData();
				et.DeleteTaskData(iIdTaskData);
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

		public List<TaskDataCompositeType> getAllTaskData()
		{
			List<TaskDataCompositeType> lst = new List<TaskDataCompositeType>();
			TaskData et = new TaskData();
			lst = et.getAll();
			return lst;
		}

		public TaskDataCompositeType getTaskDataById(int iIdTaskData)
		{
			TaskDataCompositeType etct = new TaskDataCompositeType();
			TaskData et = new TaskData();
			etct = et.GetTaskDataById(iIdTaskData);
			return etct;
		}

		public errorCompositeType UpdateTaskData(int iIdTaskData, int iIdTask, int iIdGroup, String sDescription)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				TaskData et = new TaskData();
				et.UpdateTaskData(iIdTaskData, iIdTask, iIdGroup, sDescription);
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

		public bool ExistTaskData(string sDescription, int iTarea, int iGrupo)
		{
			var chocorroles = new TaskData();
			var swap = chocorroles.getAll();
			var qbo = (from s in swap where s.sDescription.Equals(sDescription) && s.iIdTask.Equals(iTarea) && s.iIdData.Equals(iGrupo) select s).Count();
			if (qbo < 1)
				return false;
			else
				return true;
		}

		public bool ExistTaskDataDuplicate(int iIdTask, int iIdGroup, int IdEntity, String sDescription)
		{
			TaskData t = new TaskData();
			if (t.getCountTaskDataDuplicate(iIdTask, iIdGroup, IdEntity, sDescription) > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}