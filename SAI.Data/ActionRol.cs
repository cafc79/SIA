using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DS.SAI.Data;

namespace DS.SAI.Data
{
	public class ActionRol : IActionRol
	{
		private SqlParameter[] param;

		private ClassDB objDB = new ClassDB();

		#region Methods

		#region Insert Rols

		public errorCompositeType InsertActionRol(int iIdAction, int iIdRol, Boolean bStatus)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[3];
				param[0] = new SqlParameter("@fiIdAction", SqlDbType.TinyInt) { Value = iIdAction };
				param[1] = new SqlParameter("@fiRol", SqlDbType.SmallInt) { Value = iIdRol };
				param[2] = new SqlParameter("@fiStatus", SqlDbType.Bit) { Value = bStatus };
				objDB.ExecStoredIUD("sp_insertActionsxRol", param);
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

		public List<actionRolCompositeType> GetActionRolById(int iIdRol)
		{
			var lst = new List<actionRolCompositeType>();
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiRol", SqlDbType.SmallInt) {Value = iIdRol};
			DataTable dt = objDB.ExecStore("sp_selectActionxRol", param);
			foreach (DataRow dr in dt.Rows)
			{
				var ut = new actionRolCompositeType
									{
										iIdAction = int.Parse(dr.ItemArray[0].ToString()),
										sDescription = dr.ItemArray[1].ToString(),
										bStatus = Boolean.Parse(dr.ItemArray[2].ToString())
									};
				lst.Add(ut);
			}
			return lst;
		}
		#endregion

		#endregion
	}
}