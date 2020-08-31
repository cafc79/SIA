using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;

namespace DS.SAI.Data
{
    public class TaskGroup : ITaskGroup
    {
        private SqlParameter[] param;

        private ClassDB objDB = new ClassDB();
        private DataTable dt = new DataTable();
        private List<TaskGroupCompositeType> ls = new List<TaskGroupCompositeType>();

        #region TaskGroup Methods

        #region Insert

        public errorCompositeType InsertTaskGroup(int iIdGroup, int iIdTask)
        {
            errorCompositeType lstError = new errorCompositeType();

            try
            {
                bool bStatus = true;
                param = new SqlParameter[3];
                param[0] = new SqlParameter("@fiid_task", SqlDbType.Int);
                param[0].Value = iIdTask;
                param[1] = new SqlParameter("@fbstatus_task_group", SqlDbType.Bit);
                param[1].Value = bStatus;
                param[2] = new SqlParameter("@fiid_group", SqlDbType.Int);
                param[2].Value = iIdGroup;
                
                
                objDB.ExecStoredIUD("sp_insertTaskGroup", param);
                
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

        public errorCompositeType DeleteTaskGroup(int iIdTaskGroup)
        {
            errorCompositeType lstError = new errorCompositeType();

            try
            {
                param = new SqlParameter[1];
                param[0] = new SqlParameter("@fiid_task_group", SqlDbType.Int);
                param[0].Value = iIdTaskGroup;

                
                objDB.ExecStoredIUD("sp_deleteTaskGroup", param);
                
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

        public errorCompositeType UpdateTaskGroup(int iIdTaskGroup, int iIdArea, int iIdGroup)
        {
            errorCompositeType lstError = new errorCompositeType();

            try
            {
                param = new SqlParameter[3];
                param[0] = new SqlParameter("@fiid_task_group", SqlDbType.Int);
                param[0].Value = iIdTaskGroup;
                param[1] = new SqlParameter("@fiid_task", SqlDbType.Int);
                param[1].Value = iIdArea;
                param[2] = new SqlParameter("@fiid_group", SqlDbType.Int);
                param[2].Value = iIdGroup;


                
                objDB.ExecStore("sp_updateTaskGroup", param);
                
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
        public List<TaskGroupCompositeType> getAll()
        {
            List<TaskGroupCompositeType> lst = new List<TaskGroupCompositeType>();


            //try
            //{
            
            DataTable dt = objDB.Consult("sp_selectTaskGroup");
            

            foreach (DataRow dr in dt.Rows)
            {
                TaskGroupCompositeType et = new TaskGroupCompositeType();
                et.iIdTaskGroup = int.Parse(dr.ItemArray[0].ToString());
                et.iIdTask = int.Parse(dr.ItemArray[1].ToString());
                et.iIdGroup = int.Parse(dr.ItemArray[2].ToString());
                et.bStatus = bool.Parse(dr.ItemArray[3].ToString());
                et.sDescriptionTask = dr.ItemArray[4].ToString();
                et.sDescriptionGroup = dr.ItemArray[5].ToString();

                lst.Add(et);
            }
            return lst;
            //}
            //catch (Exception ex)
            //{
            //    throw ex.Message();
            //}


        }

        public TaskGroupCompositeType GetTaskGroupById(int iIdTaskGroup)
        {
            TaskGroupCompositeType et = new TaskGroupCompositeType();

            //try
            //{
            param = new SqlParameter[1];
            param[0] = new SqlParameter("@fiid_task_group", SqlDbType.Int);
            param[0].Value = iIdTaskGroup;

            
            DataTable dt = objDB.ExecStore("sp_getTaskGroupById", param);
            

            et.iIdTaskGroup = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            et.iIdTask = int.Parse(dt.Rows[0].ItemArray[1].ToString());
            et.iIdGroup = int.Parse(dt.Rows[0].ItemArray[2].ToString());
            et.bStatus = bool.Parse(dt.Rows[0].ItemArray[3].ToString());
            et.sDescriptionTask = dt.Rows[0].ItemArray[3].ToString();
            et.sDescriptionGroup = dt.Rows[0].ItemArray[3].ToString();
            
            return et;
            //}
            //catch (Exception ex)
            //{
            //    throw ex.Message();
            //}
        }

        public int getCountTaskGroupDuplicate(int iIdTask, int iIdGroup, int IdEntity)
        {
            param = new SqlParameter[3];
            param[0] = new SqlParameter("@fiid_task", SqlDbType.Int);
            param[0].Value = iIdTask;
            param[1] = new SqlParameter("@fiid_group", SqlDbType.Int);
            param[1].Value = iIdGroup;
            param[2] = new SqlParameter("@fiid_task_group", SqlDbType.Int);
            param[2].Value = IdEntity;

            
            DataTable dt = objDB.ExecStore("sp_countTaskGroupDuplicate", param);
            
            return int.Parse(dt.Rows[0].ItemArray[0].ToString());
        }

        #endregion

        #endregion
    }
}
