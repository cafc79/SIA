using System;
using System.Data;
using BOCAR.SACI.Data;

namespace BOCAR.SACI.Business
{
	public class ExchangeManager
	{
		public ExchangeManager() { }

		public errorCompositeType AddExchange(ExchangeCompositeType ectExchange, bool bInicial)
		{
			var lstError = new errorCompositeType();
			try
			{
				var et = new Exchange();
				et.InsertExchange(ectExchange, bInicial);
				//var mail = new BuzonManager();
				//Action asyncMail = mail.SendMail_SMTP(swap, "Mensaje de prueba", "Prueba de envio");
				//mail.SendMail_SMTP(null, "Test", "Test");
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

		public errorCompositeType UpdateExchange(ExchangeCompositeType ectExchange, string sDesencadenante)
		{
			var lstError = new errorCompositeType();
			try
			{
				var et = new Exchange();
				et.UpdateExchangeById(ectExchange, sDesencadenante);
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

		//Add
		public errorCompositeType UpdateExchangeDate(ExchangeCompositeType ectExchange)
		{
			var lstError = new errorCompositeType();
			try
			{
				var et = new Exchange();
				et.UpdateExchangeDateById(ectExchange);
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

		public int GetNumberPrefolio()
		{
			var et = new Exchange();
			return et.getNumberPreFolio();
		}

		public int GetNumberFolio()
		{
			var et = new Exchange();
			return et.getNumberFolio();
		}

		public ExchangeCompositeType getExchangeByPreFolioUnique(String sPrefolio)
		{
			var ect = new ExchangeCompositeType();
			var e = new Exchange();
			ect = e.getExchangeByPreFolioUnique(sPrefolio);
			return ect;
		}

		public ExchangeCompositeType getExchangeById(int iIdExchange)
		{
			try
			{
				var e = new Exchange();
				var ect = Data2Exchange(e.getExchangeById(iIdExchange));
				return ect;
			}
			catch
			{
				return null;
			}
		}

		public DataRow GetRequerimiento(int iIdExchange)
		{
			try
			{
				var ex = new Exchange();
				var swap = ex.GetRequerimiento(iIdExchange);
				return swap.Rows.Count > 0 ? swap.Rows[0] : null;
			}
			catch
			{
				return null;
			}
		}

		public DataTable getExchangeByPreFolio(String sPrefolio)
		{
			var e = new Exchange();
			var dt = new DataTable();
			dt = e.GetExchangeByPreFolio(sPrefolio);
			return dt;
		}

		public DataTable getExchangeByFolio(String sfolio)
		{
			var e = new Exchange();
			var dt = new DataTable();
			dt = e.GetExchangeByFolio(sfolio);
			return dt;
		}

		private ExchangeCompositeType Data2Exchange(DataTable dt)
		{
			var ect = new ExchangeCompositeType();
			try
			{
				if (dt.Rows[0].ItemArray[18].ToString() != "")
					ect.dAplicationDate = DateTime.Parse(dt.Rows[0].ItemArray[18].ToString());
				if (dt.Rows[0].ItemArray[8].ToString() != "")
					ect.dLimitDate = DateTime.Parse(dt.Rows[0].ItemArray[8].ToString());
				if (dt.Rows[0].ItemArray[27].ToString() != "")
					ect.dInitChange = DateTime.Parse(dt.Rows[0].ItemArray[27].ToString());
				ect.iIdClient = int.Parse(dt.Rows[0].ItemArray[13].ToString());
				ect.iIdExchange = int.Parse(dt.Rows[0].ItemArray[0].ToString());
				ect.iIdExchangeType = int.Parse(dt.Rows[0].ItemArray[12].ToString());
				ect.iIdPlant = int.Parse(dt.Rows[0].ItemArray[11].ToString());
				ect.iIdPriority = int.Parse(dt.Rows[0].ItemArray[15].ToString());
				ect.iProductEngener = int.Parse(dt.Rows[0].ItemArray[17].ToString());
				ect.iSerie = int.Parse(dt.Rows[0].ItemArray[16].ToString());
				ect.iStatus = int.Parse(dt.Rows[0].ItemArray[10].ToString());
				ect.sClient = dt.Rows[0].ItemArray[19].ToString();
				ect.sContact = dt.Rows[0].ItemArray[4].ToString();
				ect.sDescription = dt.Rows[0].ItemArray[1].ToString();
				ect.sExchangeType = dt.Rows[0].ItemArray[20].ToString();
				ect.sFolio = dt.Rows[0].ItemArray[5].ToString();
				ect.sFolioPre = dt.Rows[0].ItemArray[6].ToString();
				ect.sIssue = dt.Rows[0].ItemArray[2].ToString();
				ect.sLastFolio = dt.Rows[0].ItemArray[9].ToString();
				ect.sMeasure = dt.Rows[0].ItemArray[3].ToString();
				ect.sPlant = dt.Rows[0].ItemArray[21].ToString();
				ect.sPriority = dt.Rows[0].ItemArray[22].ToString();
				ect.sProductEngener = dt.Rows[0].ItemArray[23].ToString();
				ect.sProyect = dt.Rows[0].ItemArray[7].ToString();
				ect.sReason = dt.Rows[0].ItemArray[14].ToString();
				ect.sSerie = dt.Rows[0].ItemArray[24].ToString();
				if (dt.Rows[0].ItemArray[25].ToString() != "0" && dt.Rows[0].ItemArray[25].ToString() != null &&
						dt.Rows[0].ItemArray[25].ToString() != "")
				{
					ect.iReview = int.Parse(dt.Rows[0].ItemArray[25].ToString());
					ect.iTimingExchange = int.Parse(dt.Rows[0].ItemArray[26].ToString());
				}
				else
				{
					ect.iReview = 0;
					ect.iTimingExchange = 0;
				}
				return ect;
			}
			catch
			{
				return null;
			}
		}

		public DataTable getEmployedByTask(int iIdTarea)
		{
			try
			{
				var e = new Exchange();
				return e.getEmployedByTask(iIdTarea);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable getNestTask(int iIdGrupo)
		{
			try
			{
				var e = new Exchange();
				return e.getEmployedByTask(iIdGrupo);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable getGroup()
		{
			try
			{
				var e = new Exchange();
				return e.getGroup();
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable GetExchangePDF(string PreFolio, string Folio, string Cliente, object FechaInicial, object FechaFinal)
		{
			var ex = new Exchange();
			return ex.GetExchangePDF(PreFolio, Folio, Cliente, FechaInicial, FechaFinal);
		}

	}
}