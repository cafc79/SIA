using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BOCAR.SACI.Data
{
	public class Menu : IMenu
	{
		private ClassDB objDB = new ClassDB();

		#region User Methods
		public List<menuCompositeType> getAll()
		{
			try
			{
				DataTable dt = objDB.Consult("sp_selectMenu");
				return (from DataRow dr in dt.Rows
				        select new menuCompositeType
				               	{
				               		sDescription = dr.ItemArray[1].ToString(),
				               		sURL = dr.ItemArray[3].ToString()
				               	}).ToList();
			}
			catch(Exception ex)
			{
				throw new Exception();
			}
		}
		#endregion
	}
}