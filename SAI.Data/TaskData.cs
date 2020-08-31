using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DS.SAI.Data
{
	public class TaskData : ITaskData
	{
		private SqlParameter[] param;

		private ClassDB objDB = new ClassDB();
		private List<TaskDataCompositeType> ls = new List<TaskDataCompositeType>();

		#region TaskData Methods

		#region Insert

		public errorCompositeType InsertTaskData(int iIdGroup, int iIdTask, String sDescription)
		{
			errorCompositeType lstError = new errorCompositeType();

			try
			{
				bool bStatus = true;
				param = new SqlParameter[4];
				param[0] = new SqlParameter("@fiid_task", SqlDbType.Int);
				param[0].Value = iIdTask;
				param[1] = new SqlParameter("@fbstatus_task", SqlDbType.Bit);
				param[1].Value = bStatus;
				param[2] = new SqlParameter("@fiid_data", SqlDbType.Int);
				param[2].Value = iIdGroup;
				param[3] = new SqlParameter("@fvdescription", SqlDbType.VarChar);
				param[3].Value = sDescription;


				objDB.ExecStoredIUD("sp_insertTaskData", param);

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

		public errorCompositeType DeleteTaskData(int iIdTaskData)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_task_data", SqlDbType.Int) { Value = iIdTaskData };
				objDB.ExecStoredIUD("sp_deleteTaskData", param);
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

		public errorCompositeType UpdateTaskData(int iIdTaskData, int iIdArea, int iIdGroup, String sDescription)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[4];
				param[0] = new SqlParameter("@fiid_task_data", SqlDbType.Int) { Value = iIdTaskData };
				param[1] = new SqlParameter("@fiid_task", SqlDbType.Int) { Value = iIdArea };
				param[2] = new SqlParameter("@fiid_data", SqlDbType.Int) { Value = iIdGroup };
				param[3] = new SqlParameter("@fvdescription", SqlDbType.VarChar) { Value = sDescription };
				objDB.ExecStore("sp_updateTaskData", param);
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
		public List<TaskDataCompositeType> getAll()
		{
			List<TaskDataCompositeType> lst = new List<TaskDataCompositeType>();
			DataTable dt = objDB.Consult("sp_selectTaskData");
			foreach (DataRow dr in dt.Rows)
			{
				var et = new TaskDataCompositeType
				                           	{
				                           		iIdTaskData = int.Parse(dr.ItemArray[0].ToString()),
				                           		iIdTask = int.Parse(dr.ItemArray[1].ToString()),
				                           		iIdData = int.Parse(dr.ItemArray[2].ToString()),
				                           		bStatus = bool.Parse(dr.ItemArray[3].ToString()),
				                           		sDescriptionTask = dr.ItemArray[4].ToString(),
				                           		sDescriptionData = dr.ItemArray[5].ToString(),
				                           		sDescription = dr.ItemArray[6].ToString()
				                           	};
				lst.Add(et);
			}
			return lst;
		}

		public TaskDataCompositeType GetTaskDataById(int iIdTaskData)
		{
			TaskDataCompositeType et = new TaskDataCompositeType();
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_task_data", SqlDbType.Int) {Value = iIdTaskData};
			DataTable dt = objDB.ExecStore("sp_getTaskDataById", param);
			et.iIdTaskData = int.Parse(dt.Rows[0].ItemArray[0].ToString());
			et.iIdTask = int.Parse(dt.Rows[0].ItemArray[1].ToString());
			et.iIdData = int.Parse(dt.Rows[0].ItemArray[2].ToString());
			et.bStatus = bool.Parse(dt.Rows[0].ItemArray[3].ToString());
			et.sDescriptionTask = dt.Rows[0].ItemArray[4].ToString();
			et.sDescriptionData = dt.Rows[0].ItemArray[5].ToString();
			et.sDescription = dt.Rows[0].ItemArray[6].ToString();
			return et;
		}

		public int getCountTaskDataDuplicate(int iIdTask, int iIdGroup, int IdEntity, String sDescription)
		{
			param = new SqlParameter[4];
			param[0] = new SqlParameter("@fiid_task", SqlDbType.Int) {Value = iIdTask};
			param[1] = new SqlParameter("@fiid_data", SqlDbType.Int) {Value = iIdGroup};
			param[2] = new SqlParameter("@fiid_task_data", SqlDbType.Int) {Value = IdEntity};
			param[3] = new SqlParameter("@fvdescription", SqlDbType.VarChar) {Value = sDescription};
			DataTable dt = objDB.ExecStore("sp_countTaskDataDuplicate", param);
			return int.Parse(dt.Rows[0].ItemArray[0].ToString());
		}

		#endregion

		#endregion
	}
}