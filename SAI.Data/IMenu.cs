using System;
using System.Collections.Generic;

namespace DS.SAI.Data
{
	public interface IMenu
	{
		List<menuCompositeType> getAll();
	}

	public class menuCompositeType
	{
		public String sDescription { get; set; }
		public String sURL { get; set; }
		public String sPermission { get; set; }
		public String sPermisos  { get; set; }
	}
}