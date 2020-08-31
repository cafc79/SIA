using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DS.SAI.Data
{
	public class Task : ITask
	{
		private SqlParameter[] param;

		private ClassDB objDB = new ClassDB();
		private DataTable dt = new DataTable();
		private List<taskCompositeType> ls = new List<taskCompositeType>();

		#region Task Methods

		#region Insert

		public errorCompositeType InsertTask(String sDescription, int iIdArea)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				bool bStatus = true;
				param = new SqlParameter[3];
				param[0] = new SqlParameter("@fvdescription_task", SqlDbType.VarChar) {Value = sDescription};
				param[1] = new SqlParameter("@fbstatus_task", SqlDbType.Bit) {Value = bStatus};
				param[2] = new SqlParameter("@fiidarea", SqlDbType.Int) {Value = iIdArea};
				objDB.ExecStoredIUD("sp_insertTask", param);
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

		public errorCompositeType DeleteTask(int iIdTask)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_task", SqlDbType.Int) {Value = iIdTask};
				objDB.ExecStoredIUD("sp_deleteTask", param);
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

		public errorCompositeType UpdateTask(int iIdTask, String sDescription, int iIdArea)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[3];
				param[0] = new SqlParameter("@fiid_task", SqlDbType.Int) {Value = iIdTask};
				param[1] = new SqlParameter("@fvdescription_task", SqlDbType.VarChar) {Value = sDescription};
				param[2] = new SqlParameter("@fiidarea", SqlDbType.Int) {Value = iIdArea};
				objDB.ExecStore("sp_updateTask", param);
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
		public List<taskCompositeType> getAll()
		{
			List<taskCompositeType> lst = new List<taskCompositeType>();
			DataTable dt = objDB.Consult("sp_selectTask");
			foreach (DataRow dr in dt.Rows)
			{
				var et = new taskCompositeType
				         	{
				         		iIdTask = int.Parse(dr.ItemArray[0].ToString()),
				         		sDescription = dr.ItemArray[1].ToString(),
				         		bStatus = bool.Parse(dr.ItemArray[2].ToString()),
				         		iIdArea = int.Parse(dr.ItemArray[3].ToString()),
				         		sDescriptionArea = dr.ItemArray[4].ToString()
				         	};
				lst.Add(et);
			}
			return lst;
		}

		public taskCompositeType GetTaskById(int iIdTask)
		{
			taskCompositeType et = new taskCompositeType();
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_task", SqlDbType.Int) {Value = iIdTask};
			DataTable dt = objDB.ExecStore("sp_getTaskById", param);
			et.iIdTask = int.Parse(dt.Rows[0].ItemArray[0].ToString());
			et.sDescription = dt.Rows[0].ItemArray[1].ToString();
			et.bStatus = bool.Parse(dt.Rows[0].ItemArray[2].ToString());
			et.iIdArea = int.Parse(dt.Rows[0].ItemArray[3].ToString());
			et.sDescriptionArea = dt.Rows[0].ItemArray[4].ToString();
			return et;
		}

		/*
			public int getCountTaskByDescription(String sDescription)
			{
					param = new SqlParameter[1];
					param[0] = new SqlParameter("@fvdescription_task", SqlDbType.VarChar);
					param[0].Value = sDescription;

					
					DataTable dt = objDB.ExecStore("sp_countTaskByDescription", param);
					
					return int.Parse(dt.Rows[0].ItemArray[0].ToString());
			}

			
			public int getCountTaskByDescription(String sDescription, int iIdTask)
			{
					param = new SqlParameter[2];
					param[0] = new SqlParameter("@fvdescription_task", SqlDbType.VarChar);
					param[0].Value = sDescription;
					param[1] = new SqlParameter("@fiid_task", SqlDbType.Int);
					param[1].Value = iIdTask;

					
					DataTable dt = objDB.ExecStore("sp_countTaskByDescriptionId", param);
					
					return int.Parse(dt.Rows[0].ItemArray[0].ToString());
			}*/

		public int getCountTaskDuplicate(int iIdTask, String sDescription)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@fiid_task", SqlDbType.Int) {Value = iIdTask};
			param[1] = new SqlParameter("@fvdescription_task", SqlDbType.VarChar) {Value = sDescription};
			DataTable dt = objDB.ExecStore("sp_countTaskDuplicate", param);
			return int.Parse(dt.Rows[0].ItemArray[0].ToString());
		}

		#endregion

		#endregion
	}
}