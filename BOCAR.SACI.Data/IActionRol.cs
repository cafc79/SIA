using System;
using System.Collections.Generic;

namespace BOCAR.SACI.Data
{
	public interface IActionRol
	{
		errorCompositeType InsertActionRol(int iIdAction, int iIdRol, Boolean bStatus);
		List<actionRolCompositeType> GetActionRolById(int iIdRol);
	}

	public class actionRolCompositeType
	{
		public int iIdAction { get; set; }
		public int iIdRol { get; set; }
		public Boolean bStatus { get; set; }
		public string sDescription { get; set; }
	}
}
