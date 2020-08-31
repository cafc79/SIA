using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DS.SAI.Data
{
	public class LockingType : ILockingType
	{
		private SqlParameter[] param;

		private ClassDB objDB = new ClassDB();
		private List<lockingTypeCompositeType> ls = new List<lockingTypeCompositeType>();

		#region LockingType Methods

		#region Insert

		public errorCompositeType InsertLockingType(String sDescription)
		{
			errorCompositeType lstError = new errorCompositeType();

			try
			{
				bool bStatus = true;
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@fvdescription_locking", SqlDbType.VarChar) {Value = sDescription};
				param[1] = new SqlParameter("@fbstatus_locking", SqlDbType.Bit) {Value = bStatus};
				objDB.ExecStoredIUD("sp_insertLockingType", param);
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

		public errorCompositeType DeleteLockingType(int iIdLockingType)
		{
			errorCompositeType lstError = new errorCompositeType();

			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_locking_type", SqlDbType.Int);
				param[0].Value = iIdLockingType;


				objDB.ExecStoredIUD("sp_deleteLockingType", param);

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

		public errorCompositeType UpdateLockingType(int iIdLockingType, String sDescription)
		{
			errorCompositeType lstError = new errorCompositeType();

			try
			{
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@fiid_locking_type", SqlDbType.Int);
				param[0].Value = iIdLockingType;
				param[1] = new SqlParameter("@fvdescription_locking", SqlDbType.VarChar);
				param[1].Value = sDescription;



				objDB.ExecStore("sp_updateLockingType", param);

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
		public List<lockingTypeCompositeType> getAll()
		{
			List<lockingTypeCompositeType> lst = new List<lockingTypeCompositeType>();
			DataTable dt = objDB.Consult("sp_selectLockingType");
			foreach (DataRow dr in dt.Rows)
			{
				lockingTypeCompositeType et = new lockingTypeCompositeType();
				et.iIdLockingType = int.Parse(dr.ItemArray[0].ToString());
				et.sDescription = dr.ItemArray[1].ToString();
				et.bStatus = bool.Parse(dr.ItemArray[2].ToString());

				lst.Add(et);
			}
			return lst;
		}

		public lockingTypeCompositeType GetLockingTypeById(int iIdLockingType)
		{
			lockingTypeCompositeType et = new lockingTypeCompositeType();
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_locking_type", SqlDbType.Int) { Value = iIdLockingType };
			DataTable dt = objDB.ExecStore("sp_getLockingTypeById", param);
			et.iIdLockingType = int.Parse(dt.Rows[0].ItemArray[0].ToString());
			et.sDescription = dt.Rows[0].ItemArray[1].ToString();
			et.bStatus = bool.Parse(dt.Rows[0].ItemArray[2].ToString());
			return et;
		}

		public int getCountLockingTypeByDescription(String sDescription)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fvdescription_locking", SqlDbType.VarChar) { Value = sDescription };
			DataTable dt = objDB.ExecStore("sp_countLockingTypeByDescription", param);
			return int.Parse(dt.Rows[0].ItemArray[0].ToString());
		}

		public int getCountLockingTypeByDescription(String sDescription, int iIdLockingType)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@fvdescription_locking", SqlDbType.VarChar) {Value = sDescription};
			param[1] = new SqlParameter("@fiid_locking_type", SqlDbType.Int) {Value = iIdLockingType};
			DataTable dt = objDB.ExecStore("sp_countLockingTypeByDescriptionId", param);
			return int.Parse(dt.Rows[0].ItemArray[0].ToString());
		}

		public int getCountLockingTypeDuplicate(int iIdLockingType, String sDescription)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@fiid_locking_type", SqlDbType.Int) {Value = iIdLockingType};
			param[1] = new SqlParameter("@fvdescription_locking", SqlDbType.VarChar) {Value = sDescription};
			DataTable dt = objDB.ExecStore("sp_countLockingTypeDuplicate", param);
			return int.Parse(dt.Rows[0].ItemArray[0].ToString());
		}
		#endregion

		#endregion
	}
}