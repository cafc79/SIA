using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BOCAR.SACI.Data
{
	public class DataType : IDataType
	{
		private ClassDB objDB = new ClassDB();
		private List<DataTypeCompositeType> ls = new List<DataTypeCompositeType>();

		#region DataType Methods

		#region Insert
		public errorCompositeType InsertDataType(String sDescription)
		{
			var lstError = new errorCompositeType();
			try
			{
				bool bStatus = true;
				var param = new SqlParameter[2];
				param[0] = new SqlParameter("@fvdescription_data_type", SqlDbType.VarChar) {Value = sDescription};
				param[1] = new SqlParameter("@fbstatus_data_type", SqlDbType.Bit) {Value = bStatus};
				objDB.ExecStoredIUD("sp_insertDataType", param);
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

		public errorCompositeType DeleteDataType(int iIdDataType)
		{
			errorCompositeType lstError = new errorCompositeType();

			try
			{
				var param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_data_type", SqlDbType.Int);
				param[0].Value = iIdDataType;

				
				objDB.ExecStoredIUD("sp_deleteDataType", param);
				
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

		public errorCompositeType UpdateDataType(int iIdDataType, String sDescription)
		{
			errorCompositeType lstError = new errorCompositeType();

			try
			{
				var param = new SqlParameter[2];
				param[0] = new SqlParameter("@fiid_data_type", SqlDbType.Int);
				param[0].Value = iIdDataType;
				param[1] = new SqlParameter("@fvdescription_data_type", SqlDbType.VarChar);
				param[1].Value = sDescription;


				
				objDB.ExecStore("sp_updateDataType", param);
				
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
		public List<DataTypeCompositeType> getAll()
		{
			var lst = new List<DataTypeCompositeType>();
			try
			{
				DataTable dt = objDB.Consult("sp_selectDataType");
				foreach (DataRow dr in dt.Rows)
				{
					var swap = new DataTypeCompositeType
					           	{
					           		iIdDataType = int.Parse(dr.ItemArray[0].ToString()),
					           		sDescription = dr.ItemArray[1].ToString(),
					           		bStatus = bool.Parse(dr.ItemArray[2].ToString())
					           	};
					lst.Add(swap);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public DataTypeCompositeType GetDataTypeById(int iIdDataType)
		{
			var et = new DataTypeCompositeType();
			try
			{
				var param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_data_type", SqlDbType.Int) {Value = iIdDataType};
				DataTable dt = objDB.ExecStore("sp_getDataTypeById", param);
				et.iIdDataType = int.Parse(dt.Rows[0].ItemArray[0].ToString());
				et.sDescription = dt.Rows[0].ItemArray[1].ToString();
				et.bStatus = bool.Parse(dt.Rows[0].ItemArray[2].ToString());

				return et;
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		/*
			public int getCountDataTypeByDescription(String sDescription)
			{
					param = new SqlParameter[1];
					param[0] = new SqlParameter("@fvdescription_data_type", SqlDbType.VarChar);
					param[0].Value = sDescription;

					
					DataTable dt = objDB.ExecStore("sp_countDataTypeByDescription", param);
					
					return int.Parse(dt.Rows[0].ItemArray[0].ToString());
			}

			public int getCountDataTypeByDescription(String sDescription, int iIdDataType)
			{
					param = new SqlParameter[2];
					param[0] = new SqlParameter("@fvdescription_data_type", SqlDbType.VarChar);
					param[0].Value = sDescription;
					param[1] = new SqlParameter("@fiid_data_type", SqlDbType.Int);
					param[1].Value = iIdDataType;

					
					DataTable dt = objDB.ExecStore("sp_countDataTypeByDescriptionId", param);
					
					return int.Parse(dt.Rows[0].ItemArray[0].ToString());
			}*/

		public int getCountDataTypeDuplicate(int iIdDataType, String sDescription)
		{
			try
			{
				var param = new SqlParameter[2];
				param[0] = new SqlParameter("@fiid_data_type", SqlDbType.Int) {Value = iIdDataType};
				param[1] = new SqlParameter("@fvdescription_data_type", SqlDbType.VarChar) {Value = sDescription};
				DataTable dt = objDB.ExecStore("sp_countDataTypeDuplicate", param);
				return int.Parse(dt.Rows[0].ItemArray[0].ToString());
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}
		#endregion

		#endregion
	}
}