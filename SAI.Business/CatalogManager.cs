using System;
using System.Data;
using DS.SAI.Data;
using DA = DS.SAI.Data;

namespace DS.SAI.Business
{
	public class CatalogManager : IDisposable
	{
		private DA.CatalogAccess datos;
		private errorCompositeType lstError;

		public CatalogManager()
		{
			datos = new DA.CatalogAccess();
		}

		#region Descripcion

		public void DeleteDescription(string dataSource, int id)
		{
			string stp = string.Empty;
			string parameter = string.Empty;
			switch (dataSource)
			{
				case "sqlDSAffectationType":
					stp = "sp_deleteAffectationType";
					parameter = "@fiid_affectation_type";
					break;
				case "sqlDSClient":
					stp = "sp_deleteClient";
					parameter = "@fiid_client";
					break;
				case "sqlDSDataType":
					stp = "sp_deleteDataType";
					parameter = "@fiid_data_type";
					break;
				case "sqlDSGroup":
					stp = "sp_deleteGroup";
					parameter = "@fiid_group";
					break;
				case "sqlDSLockingType":
					stp = "sp_deleteLockingType";
					parameter = "@fiid_locking_type";
					break;
				case "sqlDSPlant":
					stp = "sp_deletePlant";
					parameter = "@fiid_plant";
					break;
				case "sqlDSPriority":
					stp = "sp_deletePriority";
					parameter = "@fiid_priority";
					break;
				case "sqlDSReviewType":
					stp = "sp_deleteReviewType";
					parameter = "@fiid_review_type";
					break;
			}
			datos.DeleteDescription(stp, parameter, id);
		}

		public string AffectationType(int id, string desc, out byte status)
		{
			lstError = new errorCompositeType();
			var tm = new AffectationTypeManager();
			try
			{
				if (tm.ExistAffectation(desc))
				{
					status = 2;
					return string.Empty;
				}
				else
				{
					if (id == 0)
						tm.AddAffectationType(desc);
					else
						tm.UpdateAffectationType(id, desc);
					status = 6;
					return string.Empty;
				}
			}
			catch (Exception ex)
			{
				status = 1;
				return string.Empty;
			}
			status = (byte) 0;
			return null;
		}

		public string Client(int id, string desc, out byte status)
		{
			lstError = new errorCompositeType();
			var tm = new ClientManager();
			try
			{
				if (tm.ExistClient(desc))
				{
					status = 2;
					return string.Empty;
				}
				else
				{
					if (id == 0)
						tm.AddClient(desc);
					else
						tm.UpdateClient(id, desc);
					status = 6;
					return string.Empty;
				}
			}
			catch (Exception ex)
			{
				status = 1;
				return string.Empty;
			}
			status = (byte) 0;
			return null;
		}

		public string DataType(int id, string desc, out byte status)
		{
			lstError = new errorCompositeType();
			var tm = new DataTypeManager();
			try
			{
				if (tm.ExistDataType(desc))
				{
					status = 2;
					return string.Empty;
				}
				else
				{
					if (id == 0)
						tm.AddDataType(desc);
					else
						tm.UpdateDataType(id, desc);
					status = 6;
					return string.Empty;
				}
			}
			catch (Exception ex)
			{
				status = 1;
				return string.Empty;
			}
			status = (byte) 0;
			return null;
		}

		public string Group(int id, string desc, out byte status)
		{
			lstError = new errorCompositeType();
			var tm = new GroupManager();
			try
			{
				if (tm.ExistGroup(desc))
				{
					status = 2;
					return string.Empty;
				}
				else
				{
					if (id == 0)
						tm.AddGroup(desc);
					else
						tm.UpdateGroup(id, desc);
					status = 6;
					return string.Empty;
				}
			}
			catch (Exception ex)
			{
				status = 1;
				return string.Empty;
			}
			status = (byte) 0;
			return null;
		}

		public string LockingType(int id, string desc, out byte status)
		{
			lstError = new errorCompositeType();
			var tm = new LockingTypeManager();
			try
			{
				if (tm.ExistLocking(desc))
				{
					status = 2;
					return string.Empty;
				}
				else
				{
					if (id == 0)
						tm.AddLockingType(desc);
					else
						tm.UpdateLockingType(id, desc);
					status = 6;
					return string.Empty;
				}
			}
			catch (Exception ex)
			{
				status = 1;
				return string.Empty;
			}
			status = (byte) 0;
			return null;
		}

		public string Plant(int id, string desc, out byte status)
		{
			lstError = new errorCompositeType();
			var tm = new PlantManager();
			try
			{
				if (tm.ExistPlant(desc))
				{
					status = 2;
					return string.Empty;
				}
				else
				{
					if (id == 0)
						tm.AddPlant(desc);
					else
						tm.UpdatePlant(id, desc);
					status = 6;
					return string.Empty;
				}
			}
			catch (Exception ex)
			{
				status = 1;
				return string.Empty;
			}
			status = (byte) 0;
			return null;
		}

		public string Priority(int id, string desc, out byte status)
		{
			lstError = new errorCompositeType();
			var tm = new PriorityManager();
			try
			{
				if (tm.ExistPriority(desc))
				{
					status = 2;
					return string.Empty;
				}
				if (id == 0)
					tm.AddPriority(desc);
				else
					tm.UpdatePriority(id, desc);
				status = 6;
				return string.Empty;
			}
			catch (Exception ex)
			{
				status = 1;
				return string.Empty;
			}
		}

		public string ReviewType(int id, string desc, out byte status)
		{
			lstError = new errorCompositeType();
			var tm = new ReviewTypeManager();
			try
			{
				if (tm.ExistReview(desc))
				{
					status = 2;
					return string.Empty;
				}
				else
				{
					if (id == 0)
						tm.AddReviewType(desc);
					else
						tm.UpdateReviewType(id, desc);
					status = 6;
					return string.Empty;
				}
			}
			catch (Exception ex)
			{
				status = 1;
				return string.Empty;
			}
			status = (byte) 0;
			return null;
		}

		public string SalesAutorizationType(int id, string desc, out byte status)
		{
			var tm = new SalesAutorizationManager();
			try
			{
				if (tm.ExistSales(0, desc))
				{
					status = 2;
					return string.Empty;
				}
				tm.Insert_SalesAutorization_Type(desc);
				status = 6;
				return string.Empty;
			}
			catch (Exception ex)
			{
				status = 1;
				return string.Empty;
			}
		}

		public string Description(string dataSource, string iId, string desc, out byte status)
		{
			int id = 0;
			if (!string.IsNullOrEmpty(iId))
				id = int.Parse(iId);
			switch (dataSource)
			{
				case "sqlDSAffectationType":
					return AffectationType(id, desc, out status);
					break;
				case "sqlDSClient":
					return Client(id, desc, out status);
					break;
				case "sqlDSDataType":
					return DataType(id, desc, out status);
					break;
				case "sqlDSGroup":
					return Group(id, desc, out status);
					break;
				case "sqlDSLockingType":
					return LockingType(id, desc, out status);
					break;
				case "sqlDSPlant":
					return Plant(id, desc, out status);
					break;
				case "sqlDSPriority":
					return Priority(id, desc, out status);
					break;
				case "sqlDSReviewType":
					return ReviewType(id, desc, out status);
					break;
				case "sqlDSSalesAutorization":
					return SalesAutorizationType(id, desc, out status);
					break;
			}
			status = (byte) 0;
			return null;
		}

		#endregion

		#region KeyValue
		public string ExchangeType(int id, string desc1, string desc2, out byte status)
		{
			lstError = new errorCompositeType();
			var tm = new ExchangeTypeManager();
			try
			{
				if (tm.ExistExchangeType(desc1))
				{
					status = 2;
					return string.Empty;
				}
				else
				{
					if (id == 0)
						tm.AddExchangeType(desc1, desc2);
					else
						tm.UpdateExchangeType(id, desc1, desc2);
					status = 6;
					return string.Empty;
				}
			}
			catch (Exception ex)
			{
				status = 1;
				return string.Empty;
			}
			status = (byte) 0;
			return null;
		}

		public string Reason(int id, string desc1, string desc2, out byte status)
		{
			lstError = new errorCompositeType();
			var tm = new ReasonManager();
			try
			{
				if (tm.ExistNumberReason(int.Parse(desc2)))
				{
					status = 2;
					return string.Empty;
				}
				else
				{
					if (id == 0)
						tm.AddReason(int.Parse(desc2), desc1);
					else
						tm.UpdateReason(id, int.Parse(desc2), desc1);
					status = 6;
					return string.Empty;
				}
			}
			catch (Exception ex)
			{
				status = 1;
				return string.Empty;
			}
			status = (byte) 0;
			return null;
		}

		public string Task(int id, string desc1, string desc2, out byte status)
		{
			lstError = new errorCompositeType();
			var tm = new TaskManager();
			try
			{
				if (tm.ExistTask(desc1))
				{
					status = 2;
					return string.Empty;
				}
				else
				{
					if (id == 0)
						tm.AddTask(desc1, int.Parse(desc2));
					else
						tm.UpdateTask(id, desc1, int.Parse(desc2));
					status = 6;
					return string.Empty;
				}
			}
			catch (Exception ex)
			{
				status = 1;
				return string.Empty;
			}
			status = (byte) 0;
			return null;
		}

		public string TaskGroup(int id, string desc1, string desc2, out byte status)
		{
			lstError = new errorCompositeType();
			var tm = new TaskGroupManager();
			try
			{
				if (tm.ExistTaskGroup(int.Parse(desc1), int.Parse(desc2)))
				{
					status = 2;
					return string.Empty;
				}
				else
				{
					if (id == 0)
						tm.AddTaskGroup(int.Parse(desc1), int.Parse(desc2));
					else
						tm.UpdateTaskGroup(id, int.Parse(desc1), int.Parse(desc2));
					status = 6;
					return string.Empty;
				}
			}
			catch (Exception ex)
			{
				status = 1;
				return string.Empty;
			}
			status = (byte) 0;
			return null;
		}

		public string KeyValue(string dataSource, string iId, string desc1, string desc2, out byte status)
		{
			int id = 0;
			if ((string.IsNullOrEmpty(desc1.Trim())) || (string.IsNullOrEmpty(desc2.Trim())))
			{
				status = 8;
				return null;
			}
			else
			{
				if (!string.IsNullOrEmpty(iId))
					id = int.Parse(iId);
				switch (dataSource)
				{
					case "sqlDSExchangeType":
						return ExchangeType(id, desc1, desc2, out status);
						break;
					case "sqlDSReason":
						return Reason(id, desc1, desc2, out status);
						break;
					case "sqlDSTask":
						return Task(id, desc1, desc2, out status);
						break;
					case "sqlDSTaskGroup":
						return TaskGroup(id, desc1, desc2, out status);
						break;
				}
			}
			status = (byte) 0;
			return null;
		}

		public void DeleteKeyValue(string dataSource, int id)
		{
			string stp = string.Empty;
			string parameter = string.Empty;
			switch (dataSource)
			{
				case "sqlDSArea":
					stp = "sp_deleteArea";
					parameter = "@fiid_area";
					break;
				case "sqlDSExchangeType":
					stp = "sp_deleteExchangeType";
					parameter = "@fiid_exchange_type";
					break;
				case "sqlDSReason":
					stp = "sp_deleteReason";
					parameter = "@fiid_reason";
					break;
				case "sqlDSTask":
					stp = "sp_deleteTask";
					parameter = "@fiid_task";
					break;
				case "sqlDSTaskGroup":
					stp = "sp_deleteTaskGroup";
					parameter = "@fiid_task_group";
					break;
			}
			datos.DeleteDescription(stp, parameter, id);
		}

		#endregion

		#region Triara
		public string Area(int id, string desc1, string desc2, string desc3, out byte status)
		{
			lstError = new errorCompositeType();
			var tm = new AreaManager();
			try
			{
				if (id == 0)
				{
					if (tm.ExistArea(int.Parse(desc2)) || tm.ExistArea(desc1))
					{
						status = 2;
						return string.Empty;
					}
					tm.AddArea(desc1, int.Parse(desc2), int.Parse(desc3));
				}
				else
				{
					if (tm.ExisteArea(id, int.Parse(desc2)) || tm.ExisteArea(id, desc1))
					{
						status = 2;
						return string.Empty;
					}
					tm.UpdateArea(id, desc1, int.Parse(desc2), int.Parse(desc3));
				}
				status = 6;
				return string.Empty;

			}
			catch (Exception ex)
			{
				status = 1;
				return string.Empty;
			}
			status = (byte) 0;
			return null;
		}


		public string PartList(int id, string desc1, string desc2, string desc3, out byte status)
		{
			lstError = new errorCompositeType();
			var tm = new PartListManager();
			try
			{
				if (tm.ExistPartList(desc2))
				{
					status = 2;
					return string.Empty;
				}
				else
				{
					if (id == 0)
						tm.AddPartList(desc2, desc1, desc3);
					else
						tm.UpdatePartList(id, desc2, desc1, desc3);
					status = 6;
					return string.Empty;
				}
			}
			catch (Exception ex)
			{
				status = 1;
				return string.Empty;
			}
			status = (byte) 0;
			return null;
		}

		public string TaskData(int id, string desc1, string desc2, string desc3, out byte status)
		{
			lstError = new errorCompositeType();
			var tm = new TaskDataManager();
			try
			{
				if (tm.ExistTaskData(desc1, int.Parse(desc2), int.Parse(desc3)))
				{
					status = 2;
					return string.Empty;
				}
				else
				{
					if (id == 0)
						tm.AddTaskData(int.Parse(desc2), int.Parse(desc3), desc1);
					else
						tm.UpdateTaskData(id, int.Parse(desc2), int.Parse(desc3), desc1);
					status = 6;
					return string.Empty;
				}
			}
			catch (Exception ex)
			{
				status = 1;
				return string.Empty;
			}
			status = (byte) 0;
			return null;
		}

		public void DeleteTriara(string dataSource, int id)
		{
			string stp = string.Empty;
			string parameter = string.Empty;
			switch (dataSource)
			{
				case "sqlDSPartList":
					stp = "sp_deletePartList";
					parameter = "@fiid_part_list";
					break;
				case "sqlDSTaskData":
					stp = "sp_deleteTaskData";
					parameter = "@fiid_Task_data";
					break;
			}
			datos.DeleteDescription(stp, parameter, id);
		}

		public string Triara(string dataSource, string iId, string desc1, string desc2, string desc3, out byte status)
		{
			int id = 0;
			if (!string.IsNullOrEmpty(iId))
				id = int.Parse(iId);
			switch (dataSource)
			{
				case "sqlDSPartList":
					return PartList(id, desc1, desc2, desc3, out status);
					break;
				case "sqlDSTaskData":
					return TaskData(id, desc1, desc2, desc3, out status);
					break;
				case "sqlDSArea":
					return Area(id, desc1, desc2, desc3, out status);
					break;
			}
			status = (byte) 0;
			return null;
		}

		#endregion

		#region Empleados

		public void DeleteEmployed(string dataSource, int id)
		{
			datos.DeleteDescription("sp_deleteEmployed", "@fiid_employed", id);
		}

		public string Employed(string iIdEmployed, int iNumber, string sName, string sMLastName, string sFLastName,
		                       string sEMail, int iIdArea, int iIdPlant, int iBoss, int iSubstitute, out byte status)
		{
			int id = 0;
			if (!string.IsNullOrEmpty(iIdEmployed))
				id = int.Parse(iIdEmployed);
			var em = new EmployedManager();
			if (id == 0)
			{
				if (em.ExistEmployed(iNumber, sEMail))
				{
					status = 3;
					return "El correo o número de empleado ya existe, no es posible duplicar registros.";
				}
				else
				{
					em.AddEmployed(iNumber, sName, sMLastName, sFLastName, sEMail, iIdArea, iIdPlant,
					               iBoss, iSubstitute);
				}
				status = 5;
				return string.Empty;
			}
			else
			{
				em.UpdateEmployed(id, iNumber, sName, sMLastName, sFLastName, sEMail, iIdArea,
				                  iIdPlant, iBoss, iSubstitute);
				status = 6;
				return string.Empty;
			}
			status = (byte) 0;
			return null;
		}

		public DataTable GetBoss(int iArea)
		{
			var dt = datos.GetBoss(iArea);
			if (dt.Rows.Count > 0)
				return dt;
			else
				return datos.GetBoss(0);
		}

		#endregion

		public void Dispose()
		{
			Dispose();
			GC.SuppressFinalize(this);
		}
	}
}