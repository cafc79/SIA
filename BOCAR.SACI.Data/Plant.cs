using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace BOCAR.SACI.Data
{
	public class Plant : IPlant
	{
		private SqlParameter[] param;

		private ClassDB objDB = new ClassDB();
		private List<PlantCompositeType> ls = new List<PlantCompositeType>();

		#region Plant Methods

		#region Insert

		public errorCompositeType InsertPlant(String sDescription)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@fvdescription_plant", SqlDbType.VarChar) {Value = sDescription};
				param[1] = new SqlParameter("@fbstatus_plant", SqlDbType.Bit) {Value = true};
				objDB.ExecStoredIUD("sp_insertPlant", param);
				lstError.bError = true;
				return lstError;
			}
			catch (Exception ex)
			{
				lstError.bError = false;
				lstError.sError = ex.Message;
				return lstError;
			}
		}
		#endregion

		#region Update

		public errorCompositeType DeletePlant(int iIdPlant)
		{
			errorCompositeType lstError = new errorCompositeType();

			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_plant", SqlDbType.Int);
				param[0].Value = iIdPlant;

				
				objDB.ExecStoredIUD("sp_deletePlant", param);
				
				lstError.bError = true;
				return lstError;
			}
			catch (Exception ex)
			{
				lstError.bError = false;
				lstError.sError = ex.Message;
				return lstError;
			}
		}

		public errorCompositeType UpdatePlant(int iIdPlant, String sDescription)
		{
			errorCompositeType lstError = new errorCompositeType();

			try
			{
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@fiid_plant", SqlDbType.Int);
				param[0].Value = iIdPlant;
				param[1] = new SqlParameter("@fvdescription_plant", SqlDbType.VarChar);
				param[1].Value = sDescription;


				
				objDB.ExecStore("sp_updatePlant", param);
				
				lstError.bError = true;
				return lstError;
			}
			catch (Exception ex)
			{
				lstError.bError = false;
				lstError.sError = ex.Message;
				return lstError;
			}
		}

		#endregion

		#region Select
		/// <summary>
		/// Obtiene todos los Tipos de Cambio
		/// </summary>
		/// <returns></returns>
		public List<PlantCompositeType> getAll()
		{
			var lst = new List<PlantCompositeType>();
			DataTable dt = objDB.Consult("sp_selectPlant");
			foreach (DataRow dr in dt.Rows)
			{
				var et = new PlantCompositeType
				                        	{
				                        		iIdPlant = int.Parse(dr.ItemArray[0].ToString()),
				                        		sDescription = dr.ItemArray[1].ToString(),
				                        		bStatus = bool.Parse(dr.ItemArray[2].ToString())
				                        	};
				lst.Add(et);
			}
			return lst;
		}

		public PlantCompositeType GetPlantById(int iIdPlant)
		{
			var et = new PlantCompositeType();
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_plant", SqlDbType.Int) {Value = iIdPlant};
			DataTable dt = objDB.ExecStore("sp_getPlantById", param);
			et.iIdPlant = int.Parse(dt.Rows[0].ItemArray[0].ToString());
			et.sDescription = dt.Rows[0].ItemArray[1].ToString();
			et.bStatus = bool.Parse(dt.Rows[0].ItemArray[2].ToString());
			return et;
		}

		public bool ExistRol(string sDescription)
		{
			var chocorroles = new MenuRol();
			var swap = chocorroles.getAll();
			var qbo = (from s in swap where s.sDescription.Equals(sDescription) select s).Count();
			if (qbo < 1)
				return false;
			else
				return true;
		}

		public int getCountPlantDuplicate(int iIdPlant, String sDescription)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@fiid_plant", SqlDbType.Int) {Value = iIdPlant};
			param[1] = new SqlParameter("@fvdescription_plant", SqlDbType.VarChar) {Value = sDescription};
			DataTable dt = objDB.ExecStore("sp_countPlantDuplicate", param);
			return int.Parse(dt.Rows[0].ItemArray[0].ToString());
		}
		#endregion

		#endregion
	}
}