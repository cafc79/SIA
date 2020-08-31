using System;
using System.Collections.Generic;

namespace BOCAR.SACI.Data
{
	public interface ITaskData
	{
		List<TaskDataCompositeType> getAll();
		TaskDataCompositeType GetTaskDataById(int iIdTaskData);
		errorCompositeType InsertTaskData(int iIdGroup, int iIdArea, String sDescription);
		errorCompositeType DeleteTaskData(int iIdTaskData);
		errorCompositeType UpdateTaskData(int iIdTaskData, int iIdGroup, int iIdTask, String sDescription);
		int getCountTaskDataDuplicate(int iIdTaskData, int iIdGroup, int IdEntity, String sDescription);
	}

	public class TaskDataCompositeType
	{
		public int iIdTaskData { get; set; }
		public int iIdTask { get; set; }
		public bool bStatus { get; set; }
		public int iIdData { get; set; }
		public String sDescriptionTask { get; set; }
		public String sDescriptionData { get; set; }
		public String sDescription { get; set; }
	}
}