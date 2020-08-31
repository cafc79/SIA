using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOCAR.SACI.Data;

namespace BOCAR.SACI.Business
{
	public class GroupManager
	{
		public GroupManager()
		{

		}


		public errorCompositeType AddGroup(String description)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				Group et = new Group();
				et.InsertGroup(description);
				lstError.bError = true;
				lstError.sError = "";
				return lstError;
			}
			catch (Exception ex)
			{
				lstError.bError = false;
				lstError.sError = ex.Message;
				return lstError;
			}
		}

		public errorCompositeType DeleteGroup(int iIdGroup)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				Group et = new Group();
				et.DeleteGroup(iIdGroup);
				lstError.bError = true;
				lstError.sError = "";
				return lstError;
			}
			catch (Exception ex)
			{
				lstError.bError = false;
				lstError.sError = ex.Message;
				return lstError;
			}
		}

		public List<GroupCompositeType> getAllGroup()
		{
			List<GroupCompositeType> lst = new List<GroupCompositeType>();
			Group et = new Group();
			lst = et.getAll();
			return lst;
		}

		public GroupCompositeType getGroupById(int iIdGroup)
		{
			GroupCompositeType etct = new GroupCompositeType();
			Group et = new Group();
			etct = et.GetGroupById(iIdGroup);
			return etct;
		}

		public errorCompositeType UpdateGroup(int iIdGroup, String sDescription)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				Group et = new Group();
				et.UpdateGroup(iIdGroup, sDescription);
				lstError.bError = true;
				lstError.sError = "";
				return lstError;
			}
			catch (Exception ex)
			{
				lstError.bError = false;
				lstError.sError = ex.Message;
				return lstError;
			}
		}

		/*
			public bool ExistGroup(String sDescription)
			{
					Group et = new Group();

					if (et.getCountGroupByDescription(sDescription) > 0)
					{
							return true;
					}
					else
					{
							return false;
					}
			}

			public bool ExistGroup(String sDescription, int iIdGroup)
			{
					Group et = new Group();

					if (et.getCountGroupByDescription(sDescription, iIdGroup) > 0)
					{
							return true;
					}
					else
					{
							return false;
					}
			}*/

		public bool ExistGroup(string sDescription)
		{
			var chocorroles = new Group();
			var swap = chocorroles.getAll();
			var qbo = (from s in swap where s.sDescription.Equals(sDescription) select s).Count();
			if (qbo < 1)
				return false;
			else
				return true;
		}

		public bool ExistGroupDuplicate(String sDescription, int iIdArea)
		{
			Group t = new Group();


			if (t.getCountGroupDuplicate(iIdArea, sDescription) > 0)
			{
				return true;
			}
			else
			{
				return false;
			}

		}
	}
}