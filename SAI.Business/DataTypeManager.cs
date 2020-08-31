using System;
using System.Collections.Generic;
using System.Linq;
using DS.SAI.Data;

namespace DS.SAI.Business
{
	public class DataTypeManager
	{

		public errorCompositeType AddDataType(String description)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				DataType et = new DataType();
				et.InsertDataType(description);
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

		public errorCompositeType DeleteDataType(int iIdDataType)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				DataType et = new DataType();
				et.DeleteDataType(iIdDataType);
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

		public List<DataTypeCompositeType> getAllDataType()
		{
			List<DataTypeCompositeType> lst = new List<DataTypeCompositeType>();
			DataType et = new DataType();
			lst = et.getAll();
			return lst;
		}

		public DataTypeCompositeType getDataTypeById(int iIdDataType)
		{
			DataTypeCompositeType etct = new DataTypeCompositeType();
			DataType et = new DataType();
			etct = et.GetDataTypeById(iIdDataType);
			return etct;
		}

		public errorCompositeType UpdateDataType(int iIdDataType, String sDescription)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				DataType et = new DataType();
				et.UpdateDataType(iIdDataType, sDescription);
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
			public bool ExistDataType(String sDescription)
			{
					DataType et = new DataType();

					if (et.getCountDataTypeByDescription(sDescription) > 0)
					{
							return true;
					}
					else
					{
							return false;
					}
			}

			public bool ExistDataType(String sDescription, int iIdDataType)
			{
					DataType et = new DataType();

					if (et.getCountDataTypeByDescription(sDescription, iIdDataType) > 0)
					{
							return true;
					}
					else
					{
							return false;
					}
			}*/

		public bool ExistDataType(string sDescription)
		{
			var chocorroles = new DataType();
			var swap = chocorroles.getAll();
			var qbo = (from s in swap where s.sDescription.Equals(sDescription) select s).Count();
			if (qbo < 1)
				return false;
			else
				return true;
		}

		public bool ExistDataTypeDuplicate(String sDescription, int iIdArea)
		{
			var t = new DataType();
			return t.getCountDataTypeDuplicate(iIdArea, sDescription) > 0;
		}
	}
}