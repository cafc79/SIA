using System;
using System.Collections.Generic;

namespace DS.SAI.Data
{
	public interface ITaskGroup
	{
		List<TaskGroupCompositeType> getAll();
		TaskGroupCompositeType GetTaskGroupById(int iIdTaskGroup);
		errorCompositeType InsertTaskGroup(int iIdGroup, int iIdArea);
		errorCompositeType DeleteTaskGroup(int iIdTaskGroup);
		errorCompositeType UpdateTaskGroup(int iIdTaskGroup, int iIdGroup, int iIdTask);

		int getCountTaskGroupDuplicate(int iIdTaskGroup, int iIdGroup, int IdEntity);
	}

	public class TaskGroupCompositeType
	{
		public int iIdTaskGroup { get; set; }
		public int iIdTask { get; set; }
		public bool bStatus { get; set; }
		public int iIdGroup { get; set; }
		public String sDescriptionTask { get; set; }
		public String sDescriptionGroup { get; set; }
	}
}