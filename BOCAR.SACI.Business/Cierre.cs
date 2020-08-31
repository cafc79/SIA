using System;
using System.Data;
using DA = BOCAR.SACI.Data;

namespace BOCAR.SACI.Business
{
	public class Cierre
	{
		private DA.Cierre datos;

		public Cierre()
		{
			datos = new DA.Cierre();
		}

		public DataTable GetFolios(String sFolio)
		{
			try
			{
				return datos.GetFolios(sFolio);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable Get_Release(int iFolio, string fLiberacion, string sObservaciones, int iEstatus, string sEstatus, ref int pendientes,decimal CostoReal)
		{
			try
			{
				var folios = new FolioSeguimiento();
				if (sEstatus == "Cerrado")
				{
					var data = folios.GetTareasByFolios(iFolio, null);
					for (int i = 0; i <= data.Rows.Count - 1; i++)
					{
						if (string.IsNullOrEmpty(data.Rows[i]["FechaTermino"].ToString()))
							pendientes++;
					}
					if (pendientes > 0)
						return null;
					else
						return datos.Get_Release(iFolio, fLiberacion, sObservaciones, iEstatus,CostoReal );
				}
				else
					return datos.Get_Release(iFolio, fLiberacion, sObservaciones, iEstatus, CostoReal );
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable Get_RegFile(int iFolio, int iRelease, string sDescripcion, string sArchivo, string sRutaArchivo)
		{
			try
			{
				return datos.Get_RegFile(iFolio, iRelease, sDescripcion, sArchivo, sRutaArchivo);
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

		public DataTable GetArchivosByCierre(int iRelease)
		{
			try
			{
				return datos.GetArchivosByCierre(iRelease);
			}
			catch
			{
				throw new Exception();
			}
		}
	}
}
