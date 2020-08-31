using System;
using System.Data;
using System.Data.SqlClient;

namespace BOCAR.SACI.Data
{
	public class Exchange : IExchange
	{
		private SqlParameter[] param;
		private ClassDB objDB = new ClassDB();

		#region Insert
		public errorCompositeType InsertExchange(ExchangeCompositeType ect, bool bInicial)
		{
			var lstError = new errorCompositeType();
			try
			{
				bool bStatus = true;
				param = new SqlParameter[18];
				param[0] = new SqlParameter("@fvdescription_Exchange", SqlDbType.VarChar) {Value = ect.sDescription};
				param[1] = new SqlParameter("@fvissue_Exchange", SqlDbType.VarChar) {Value = ect.sIssue};
				param[2] = new SqlParameter("@fvmeasure_Exchange", SqlDbType.VarChar) {Value = ect.sMeasure};
				param[3] = new SqlParameter("@fvcontact_Exchange", SqlDbType.VarChar) {Value = ect.sContact};
				param[4] = new SqlParameter("@fvfolio_Exchange", SqlDbType.VarChar) {Value = ect.sFolio};
				param[5] = new SqlParameter("@fvprefolio_Exchange", SqlDbType.VarChar) {Value = ect.sFolioPre};
				param[6] = new SqlParameter("@fvproyect_Exchange", SqlDbType.VarChar) {Value = ect.sProyect};
				param[7] = new SqlParameter("@fdlimit_date_Exchange", SqlDbType.DateTime) {Value = ect.dLimitDate};
				param[8] = new SqlParameter("@fvlast_folio_Exchange", SqlDbType.VarChar) {Value = ect.sLastFolio};
				param[9] = new SqlParameter("@fistatus_Exchange", SqlDbType.Int) {Value = ect.iStatus};
				param[10] = new SqlParameter("@fiid_plant", SqlDbType.Int) {Value = ect.iIdPlant};
				param[11] = new SqlParameter("@fiid_Exchange_type", SqlDbType.Int) {Value = ect.iIdExchangeType};
				param[12] = new SqlParameter("@fiid_client", SqlDbType.Int) {Value = ect.iIdClient};
				param[13] = new SqlParameter("@fvreason_Exchange", SqlDbType.VarChar) {Value = ect.sReason};
				param[14] = new SqlParameter("@fiid_priority", SqlDbType.Int) {Value = ect.iIdPriority};
				param[15] = new SqlParameter("@fiid_serie_proyect", SqlDbType.Int) {Value = ect.iSerie};
				param[16] = new SqlParameter("@fiid_product_engeener", SqlDbType.Int) {Value = ect.iProductEngener};
				param[17] = new SqlParameter("@source", SqlDbType.Bit) { Value = bInicial };
				
				objDB.ExecStoredIUD("sp_insertExchange", param);

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
		public errorCompositeType UpdateExchangeById(ExchangeCompositeType ect, string sDesencadenante)
		{
			var lstError = new errorCompositeType();
			try
			{
				bool bStatus = true;
				param = new SqlParameter[21];
				param[0] = new SqlParameter("@fvdescription_Exchange", SqlDbType.VarChar) {Value = ect.sDescription};
				param[1] = new SqlParameter("@fvissue_Exchange", SqlDbType.VarChar) {Value = ect.sIssue};
				param[2] = new SqlParameter("@fvmeasure_Exchange", SqlDbType.VarChar) {Value = ect.sMeasure};
				param[3] = new SqlParameter("@fvcontact_Exchange", SqlDbType.VarChar) {Value = ect.sContact};
				param[4] = new SqlParameter("@fvfolio_Exchange", SqlDbType.VarChar) {Value = ect.sFolio};
				param[5] = new SqlParameter("@fvprefolio_Exchange", SqlDbType.VarChar) {Value = ect.sFolioPre};
				param[6] = new SqlParameter("@fvproyect_Exchange", SqlDbType.VarChar) {Value = ect.sProyect};
				param[7] = new SqlParameter("@fdlimit_date_Exchange", SqlDbType.DateTime) {Value = ect.dLimitDate};
				param[8] = new SqlParameter("@fvlast_folio_Exchange", SqlDbType.VarChar) {Value = ect.sLastFolio};
				param[9] = new SqlParameter("@fistatus_Exchange", SqlDbType.Int) {Value = ect.iStatus};
				param[10] = new SqlParameter("@fiid_plant", SqlDbType.Int) {Value = ect.iIdPlant};
				param[11] = new SqlParameter("@fiid_Exchange_type", SqlDbType.Int) {Value = ect.iIdExchangeType};
				param[12] = new SqlParameter("@fiid_client", SqlDbType.Int) {Value = ect.iIdClient};
				param[13] = new SqlParameter("@fvreason_Exchange", SqlDbType.VarChar) {Value = ect.sReason};
				param[14] = new SqlParameter("@fiid_priority", SqlDbType.Int) {Value = ect.iIdPriority};
				param[15] = new SqlParameter("@fiid_serie_proyect", SqlDbType.Int) {Value = ect.iSerie};
				param[16] = new SqlParameter("@fiid_product_engeener", SqlDbType.Int) {Value = ect.iProductEngener};
				param[17] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) {Value = ect.iIdExchange};
				param[18] = new SqlParameter("@fi_idreview_logistic", SqlDbType.Int) {Value = ect.iReview};
				param[19] = new SqlParameter("@fi_timing_exchange", SqlDbType.Int) {Value = ect.iTimingExchange};
				param[20] = new SqlParameter("@fv_Desencadenante", SqlDbType.VarChar) {Value = sDesencadenante};

				objDB.ExecStoredIUD("sp_updateExchange", param);

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
		//Add
		public errorCompositeType UpdateExchangeDateById(ExchangeCompositeType ect)
		{
			var lstError = new errorCompositeType();
			try
			{
				bool bStatus = true;
				param = new SqlParameter[21];
				param[0] = new SqlParameter("@fvdescription_Exchange", SqlDbType.VarChar) {Value = ect.sDescription};
				param[1] = new SqlParameter("@fvissue_Exchange", SqlDbType.VarChar) {Value = ect.sIssue};
				param[2] = new SqlParameter("@fvmeasure_Exchange", SqlDbType.VarChar) {Value = ect.sMeasure};
				param[3] = new SqlParameter("@fvcontact_Exchange", SqlDbType.VarChar) {Value = ect.sContact};
				param[4] = new SqlParameter("@fvfolio_Exchange", SqlDbType.VarChar) {Value = ect.sFolio};
				param[5] = new SqlParameter("@fvprefolio_Exchange", SqlDbType.VarChar) {Value = ect.sFolioPre};
				param[6] = new SqlParameter("@fvproyect_Exchange", SqlDbType.VarChar) {Value = ect.sProyect};
				param[7] = new SqlParameter("@fdlimit_date_Exchange", SqlDbType.DateTime) {Value = ect.dLimitDate};
				param[8] = new SqlParameter("@fvlast_folio_Exchange", SqlDbType.VarChar) {Value = ect.sLastFolio};
				param[9] = new SqlParameter("@fistatus_Exchange", SqlDbType.Int) {Value = ect.iStatus};
				param[10] = new SqlParameter("@fiid_plant", SqlDbType.Int) {Value = ect.iIdPlant};
				param[11] = new SqlParameter("@fiid_Exchange_type", SqlDbType.Int) {Value = ect.iIdExchangeType};
				param[12] = new SqlParameter("@fiid_client", SqlDbType.Int) {Value = ect.iIdClient};
				param[13] = new SqlParameter("@fvreason_Exchange", SqlDbType.VarChar) {Value = ect.sReason};
				param[14] = new SqlParameter("@fiid_priority", SqlDbType.Int) {Value = ect.iIdPriority};
				param[15] = new SqlParameter("@fiid_serie_proyect", SqlDbType.Int) {Value = ect.iSerie};
				param[16] = new SqlParameter("@fiid_product_engeener", SqlDbType.Int) {Value = ect.iProductEngener};
				param[17] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) {Value = ect.iIdExchange};
				param[18] = new SqlParameter("@fi_idreview_logistic", SqlDbType.Int) {Value = ect.iReview};
				param[19] = new SqlParameter("@fi_timing_exchange", SqlDbType.Int) {Value = ect.iTimingExchange};
				param[20] = new SqlParameter("@fdaplication_date", SqlDbType.DateTime) {Value = ect.dAplicationDate};

				objDB.ExecStoredIUD("sp_updateExchangeDate", param);

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
		public DataTable GetExchangeByPreFolio(String sPreFolio)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fvprefolio", SqlDbType.VarChar) { Value = sPreFolio };
			return objDB.ExecStore("sp_selectExchange_srch", param);
		}

		public DataTable GetExchangeByFolio(String sPreFolio)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fvFolio", SqlDbType.VarChar) { Value = sPreFolio };
			return objDB.ExecStore("sp_selectExchange_srch_fl", param);
		}

		public int getNumberPreFolio()
		{
			return int.Parse(objDB.Consult("[sp_getPreFolio]").Rows[0].ItemArray[0].ToString());
		}

		public int getNumberFolio()
		{
			return int.Parse(objDB.Consult("[sp_getFolio]").Rows[0].ItemArray[0].ToString());
		}

		public ExchangeCompositeType getExchangeByPreFolioUnique(String sPreFolio)
		{
			var ect = new ExchangeCompositeType();
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fvprefolio_Exchange", SqlDbType.VarChar) { Value = sPreFolio };
			DataTable dt = objDB.ExecStore("sp_selectExchangeByPreFolio", param);
			if (dt.Rows[0].ItemArray[18].ToString() != "")
				ect.dAplicationDate = DateTime.Parse(dt.Rows[0].ItemArray[18].ToString());
			if (dt.Rows[0].ItemArray[8].ToString() != "")
				// ect.dLimitDate = DateTime.Parse(dt.Rows[0].ItemArray[18].ToString()).ToShortDateString();
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
			return ect;
		}

		public DataTable getExchangeById(int iIdExchange)
		{
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) { Value = iIdExchange };
				return objDB.ExecStore("sp_selectExchangeById", param);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable GetRequerimiento(int iIdExchange)
		{
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) { Value = iIdExchange };
				return objDB.ExecStore("sp_selectRequerimiento", param);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable getEmployedByTask(int iIdTarea)
		{
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_task", SqlDbType.Int) { Value = iIdTarea };
				return objDB.ExecStore("sp_selectEmployedByTask", param);
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
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_group", SqlDbType.Int) { Value = iIdGrupo };
				return objDB.ExecStore("sp_selectTaskGroupByIdGroup", param);
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
				return objDB.ExecStore("sp_selectGroup", param);
			}
			catch
			{
				throw new Exception();
			}
		}

		public DataTable GetExchangePDF(string PreFolio, string Folio, string Cliente, object FechaInicial, object FechaFinal)
		{
			try
			{
				param = new SqlParameter[5];
				param[0] = new SqlParameter("@PreFolio", SqlDbType.VarChar) { Value = PreFolio };
				param[1] = new SqlParameter("@Folio", SqlDbType.VarChar) { Value = Folio };
				param[2] = new SqlParameter("@Cliente", SqlDbType.VarChar) { Value = Cliente };
				param[3] = new SqlParameter("@fechaIni", SqlDbType.DateTime) { Value = FechaInicial };
				param[4] = new SqlParameter("@fechaFinal", SqlDbType.DateTime) { Value = FechaFinal };
				return objDB.ExecStore("sp_reportExchangeNotes", param);
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}
		#endregion
	}
}