using System;
using System.Collections.Generic;
using System.Linq;
using DS.SAI.Data;

namespace DS.SAI.Business
{
	public class TaskManager
	{
		public TaskManager()
		{

		}

		public errorCompositeType AddTask(String description, int iIdArea)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				Task et = new Task();
				et.InsertTask(description, iIdArea);
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

		public errorCompositeType DeleteTask(int iIdTask)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				Task et = new Task();
				et.DeleteTask(iIdTask);
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

		public List<taskCompositeType> getAllTask()
		{
			List<taskCompositeType> lst = new List<taskCompositeType>();
			Task et = new Task();
			lst = et.getAll();
			return lst;
		}

		public taskCompositeType getTaskById(int iIdTask)
		{
			taskCompositeType etct = new taskCompositeType();
			Task et = new Task();
			etct = et.GetTaskById(iIdTask);
			return etct;
		}

		public errorCompositeType UpdateTask(int iIdTask, String sDescription, int iIdArea)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				Task et = new Task();
				et.UpdateTask(iIdTask, sDescription, iIdArea);
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

		/*
			public bool ExistTask(String sDescription)
			{ 
					Task et = new Task();

					if (et.getCountTaskByDescription(sDescription) > 0)
					{
							return true;
					}
					else
					{ 
							return false; 
					}
			}

			public bool ExistTask(String sDescription, int iIdTask)
			{
					Task et = new Task();

					if (et.getCountTaskByDescription(sDescription,iIdTask) > 0)
					{
							return true;
					}
					else
					{
							return false;
					}
			}*/

		public bool ExistTask(string sDescription)
		{
			var chocorroles = new Task();
			var swap = chocorroles.getAll();
			var qbo = (from s in swap where s.sDescription.Equals(sDescription) select s).Count();
			if (qbo < 1)
				return false;
			else
				return true;
		}

		public bool ExistTaskDuplicate(String sDescription, int iIdArea)
		{
			Task t = new Task();
			if (t.getCountTaskDuplicate(iIdArea, sDescription) > 0)
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