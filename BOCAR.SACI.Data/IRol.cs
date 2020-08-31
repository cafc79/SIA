using System;
using System.Collections.Generic;

namespace BOCAR.SACI.Data
{
	public interface IRol
	{
		List<RolCompositeType> getAll();
		RolCompositeType GetRolById(int iIdRol);
		errorCompositeType InsertRol(String sDescription);
		errorCompositeType DeleteRol(int iIdRol);
		errorCompositeType UpdateRol(int iIdRol, String sDescription);
		int getCountRolDuplicate(int iIdRol, String sDescription);
	}

	public class RolCompositeType
	{
		public int iIdRol { get; set; }
		public DateTime dRegistry { get; set; }
		public String sDescription { get; set; }
		public bool bStatus { get; set; }
	}
}