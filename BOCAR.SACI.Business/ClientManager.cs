using System;
using System.Collections.Generic;
using System.Linq;
using BOCAR.SACI.Data;

namespace BOCAR.SACI.Business
{
	public class ClientManager
	{
		public ClientManager()
		{

		}


		public errorCompositeType AddClient(String description)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				Client et = new Client();
				et.InsertClient(description);
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

		public errorCompositeType DeleteClient(int iIdClient)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				Client et = new Client();
				et.DeleteClient(iIdClient);
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

		public List<clientCompositeType> getAllClient()
		{
			List<clientCompositeType> lst = new List<clientCompositeType>();
			Client et = new Client();
			lst = et.getAll();
			return lst;
		}

		public clientCompositeType getClientById(int iIdClient)
		{
			clientCompositeType etct = new clientCompositeType();
			Client et = new Client();
			etct = et.GetClientById(iIdClient);
			return etct;
		}

		public errorCompositeType UpdateClient(int iIdClient, String sDescription)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				Client et = new Client();
				et.UpdateClient(iIdClient, sDescription);
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
			public bool ExistClient(String sDescription)
			{
					Client et = new Client();

					if (et.getCountClientByDescription(sDescription) > 0)
					{
							return true;
					}
					else
					{
							return false;
					}
			}

			public bool ExistClient(String sDescription, int iIdClient)
			{
					Client et = new Client();

					if (et.getCountClientByDescription(sDescription, iIdClient) > 0)
					{
							return true;
					}
					else
					{
							return false;
					}
			}*/

		public bool ExistClient(string sDescription)
		{
			var chocorroles = new Client();
			var swap = chocorroles.getAll();
			var qbo = (from s in swap where s.sDescription.Equals(sDescription) select s).Count();
			if (qbo < 1)
				return false;
			else
				return true;
		}

		public bool ExistClientDuplicate(String sDescription, int iIdArea)
		{
			var t = new Client();
			return t.getCountClientDuplicate(iIdArea, sDescription) > 0;
		}
	}
}