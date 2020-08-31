using System;
using System.Collections.Generic;
using BOCAR.SACI.Data;

namespace BOCAR.SACI.Business
{
	public class MenuManager
	{
		public List<menuCompositeType> getAllMenu()
		{
			var lst = new List<menuCompositeType>();
			var ut = new Menu();
			lst = ut.getAll();
			return lst;
		}
	}
}