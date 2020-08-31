using System;
using System.Collections.Generic;
using DS.SAI.Data;

namespace DS.SAI.Business
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