using System;
using System.Collections.Generic;

namespace BOCAR.SACI.Data
{
	public interface ITask
	{
		List<taskCompositeType> getAll();
		taskCompositeType GetTaskById(int iIdTask);
		errorCompositeType InsertTask(String sDescription, int iIdArea);
		errorCompositeType DeleteTask(int iIdTask);
		errorCompositeType UpdateTask(int iIdTask, String sDescription, int iIdArea);
		int getCountTaskDuplicate(int iIdTask, String sDescription);
	}

	public class taskCompositeType
	{
		public int iIdTask { get; set; }
		public String sDescription { get; set; }
		public bool bStatus { get; set; }
		public int iIdArea { get; set; }
		public String sDescriptionArea { get; set; }
	}
}