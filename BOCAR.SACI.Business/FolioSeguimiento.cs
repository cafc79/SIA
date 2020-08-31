using System;
using System.Data;
using DA = BOCAR.SACI.Data;

namespace BOCAR.SACI.Business
{
	public class FolioSeguimiento
	{
		private DA.FolioSeguimiento datos;

		public FolioSeguimiento()
		{
			datos = new DA.FolioSeguimiento();
		}

		public DataTable GetFolios(String sFolio, string sOption)
		{
			try
			{
				int i = 0;
				int.TryParse(sOption, out i);
				return datos.GetFolios(sFolio, i);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable GetTareasByFolios(int iFolio, object oTarea)
		{
			try
			{
				int tarea = 0;
				if (oTarea != null)
					tarea = (int)oTarea;
				return datos.GetTareasByFolios(iFolio, tarea);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable GetArchivosByTareas(int iTarea, int iTaskExchange)
		{
			try
			{
				return datos.GetArchivosByTareas(iTarea, iTaskExchange);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable Get_RegFile(int iFolio, int iTarea, string sDocumento, string sArchivo, string sRutaArchivo)
		{
			try
			{
				var dt = GetTareasByFolios(iFolio, iTarea);
				if (dt.Rows[0]["FechaTermino"].ToString() != string.Empty)
					return datos.Get_RegFile(iFolio, iTarea, sDocumento, sArchivo, sRutaArchivo);
				else
				{
					dt.Rows[0][0] = 0;
					return dt;
				}
			}
			catch
			{
				throw new Exception();
			}
		}

		public void Del_RegFile(int iFile)
		{
			try
			{
				datos.Del_RegFile(iFile);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable Get_CatTipoDocumentos()
		{
			try
			{
				return datos.Get_CatTipoDocumentos();
			}
			catch
			{
				throw new Exception();
			}
		}

		public object Set_FinishTask(DA.ClassUsuario usuario, string sReponsable, int iTaskExchange)
		{
			try
			{
				if (usuario.IdEmpleado == int.Parse(sReponsable) || usuario.IdRol == 1)
					return datos.Set_FinishTask(iTaskExchange);
				else
					throw new AccessViolationException();
			}
			catch (AccessViolationException aex)
			{
				throw new AccessViolationException(aex.Message);
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}