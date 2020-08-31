using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DS.SAI.Data;

namespace DS.SAI.Business
{
	public class TaskGroupManager
	{
		public TaskGroupManager()
		{

		}


		public errorCompositeType AddTaskGroup(int iIdTask, int iIdGroup)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				TaskGroup et = new TaskGroup();
				et.InsertTaskGroup(iIdGroup, iIdTask);
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

		public errorCompositeType DeleteTaskGroup(int iIdTaskGroup)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				TaskGroup et = new TaskGroup();
				et.DeleteTaskGroup(iIdTaskGroup);
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

		public List<TaskGroupCompositeType> getAllTaskGroup()
		{
			List<TaskGroupCompositeType> lst = new List<TaskGroupCompositeType>();
			TaskGroup et = new TaskGroup();
			lst = et.getAll();
			return lst;
		}

		public TaskGroupCompositeType getTaskGroupById(int iIdTaskGroup)
		{
			TaskGroupCompositeType etct = new TaskGroupCompositeType();
			TaskGroup et = new TaskGroup();
			etct = et.GetTaskGroupById(iIdTaskGroup);
			return etct;
		}

		public errorCompositeType UpdateTaskGroup(int iIdTaskGroup, int iIdTask, int iIdGroup)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				TaskGroup et = new TaskGroup();
				et.UpdateTaskGroup(iIdTaskGroup, iIdTask, iIdGroup);
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

		public bool ExistTaskGroup(int sDesc1, int sDesc2)
		{
			var chocorroles = new TaskGroup();
			var swap = chocorroles.getAll();
			var qbo = (from s in swap where s.iIdTask.Equals(sDesc1) && s.iIdGroup.Equals(sDesc2) select s).Count();
			if (qbo < 1)
				return false;
			else
				return true;
		}

		public bool ExistTaskGroupDuplicate(int iIdTask, int iIdGroup, int IdEntity)
		{
			TaskGroup t = new TaskGroup();


			if (t.getCountTaskGroupDuplicate(iIdTask, iIdGroup, IdEntity) > 0)
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