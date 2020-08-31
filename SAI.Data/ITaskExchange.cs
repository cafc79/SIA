using System;

namespace DS.SAI.Data
{
	public interface ITaskExchange
	{
		errorCompositeType InsertTaskExchange(TaskExchangeCompositeType tect);
		TaskExchangeCompositeType GetTaskExchangeByIdTaskIdExchange(TaskExchangeCompositeType tect);
	}

	public class TaskExchangeCompositeType
	{
		public int iIdTaskExchange { get; set; }
		public int iTiming { get; set; }
		public int iNextTask { get; set; }
		public int iTask { get; set; }
		public int iExchange { get; set; }
		public int iEmployed { get; set; }
		public DateTime dTiming { get; set; }
		public int iGroup { get; set; }
		public int iArea { get; set; }
		public String sTask { get; set; }
		public String sArea { get; set; }
		public String sNumberArea { get; set; }
		public String sNestTask { get; set; }
		public String sEmployed { get; set; }
		public int iTimingTotal { get; set; }
	}
}