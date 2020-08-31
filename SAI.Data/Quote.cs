using System;
using System.Data;
using System.Data.SqlClient;

namespace DS.SAI.Data
{
	public class Quote : IQuote
	{
		private SqlParameter[] param;//comentario prueba
		private ClassDB objDB = new ClassDB();

		#region ExchangeFlA Methods

		#region Insert

		public errorCompositeType AddQuote(QuoteCompositeType ect)
		{
			var lstError = new errorCompositeType();
			try
			{
				bool bStatus = true;
				param = new SqlParameter[45];
				param[0] = new SqlParameter("@fiid_exchange", SqlDbType.Int) {Value = ect.iExchange};
				param[1] = new SqlParameter("@fiid_part_list", SqlDbType.Int) {Value = ect.iPartList};
				param[2] = new SqlParameter("@fvSOP", SqlDbType.VarChar) {Value = ect.SOPCliente};
				param[3] = new SqlParameter("@fdIn", SqlDbType.DateTime) {Value = ect.dIn};
				param[4] = new SqlParameter("@fdprom", SqlDbType.DateTime) {Value = ect.dProm};
				param[5] = new SqlParameter("@fdout", SqlDbType.DateTime) {Value = ect.dOut};
				param[6] = new SqlParameter("@fbmold_prot", SqlDbType.Bit) {Value = ect.bMoldProt};
				param[7] = new SqlParameter("@fimold_prot", SqlDbType.Decimal) {Value = ect.iMoldProt};
				param[8] = new SqlParameter("@fbmold_serie", SqlDbType.Bit) {Value = ect.bMoldSerie};
				param[9] = new SqlParameter("@fimold_serie", SqlDbType.Decimal) {Value = ect.iMoldSerie};
				param[10] = new SqlParameter("@fbCF", SqlDbType.Bit) {Value = ect.bCF};
				param[11] = new SqlParameter("@fiCF", SqlDbType.Decimal) {Value = ect.iCF};
				param[12] = new SqlParameter("@fbdevice", SqlDbType.Bit) {Value = ect.bDevice};
				param[13] = new SqlParameter("@fidevice", SqlDbType.Decimal) {Value = ect.iDevice};
				param[14] = new SqlParameter("@fbobsolet", SqlDbType.Bit) {Value = ect.bObsolet};
				param[15] = new SqlParameter("@fiobsolet", SqlDbType.Decimal) {Value = ect.iObsolet};
				param[16] = new SqlParameter("@fbeng_man", SqlDbType.Bit) {Value = ect.bEngMan};
				param[17] = new SqlParameter("@fieng_man", SqlDbType.Decimal) {Value = ect.iEngMan};
				param[18] = new SqlParameter("@fbdesign", SqlDbType.Bit) {Value = ect.bDesign};
				param[19] = new SqlParameter("@fidesign", SqlDbType.Decimal) {Value = ect.iDesign};
				param[20] = new SqlParameter("@fbcomponents", SqlDbType.Bit) {Value = ect.bComponents};
				param[21] = new SqlParameter("@ficomponets", SqlDbType.Decimal) {Value = ect.iComponents};
				param[22] = new SqlParameter("@fbothers", SqlDbType.Decimal) {Value = ect.bOthers};
				param[23] = new SqlParameter("@fvothers", SqlDbType.VarChar) {Value = ect.sOthers};
				param[24] = new SqlParameter("@fiothers", SqlDbType.Decimal) {Value = ect.iOthers};
				param[25] = new SqlParameter("@fbpaint", SqlDbType.Bit) {Value = ect.bPaint};
				param[26] = new SqlParameter("@fipaint", SqlDbType.Decimal) {Value = ect.iPaint};
				param[27] = new SqlParameter("@fbemp", SqlDbType.Bit) {Value = ect.bEmp};
				param[28] = new SqlParameter("@fiemp", SqlDbType.Decimal) {Value = ect.iEmp};
				param[29] = new SqlParameter("@fbbank", SqlDbType.Bit) {Value = ect.bBank};
				param[30] = new SqlParameter("@fibank", SqlDbType.Decimal) {Value = ect.iBank};
				param[31] = new SqlParameter("@fbothersC", SqlDbType.Bit) {Value = ect.bOthersC};
				param[32] = new SqlParameter("@fiothersC", SqlDbType.Decimal) {Value = ect.iOthersC};
				param[33] = new SqlParameter("@fipound", SqlDbType.Decimal) {Value = ect.iPound};
				param[34] = new SqlParameter("@fidelta1", SqlDbType.Int) {Value = ect.iDelta1};
				param[35] = new SqlParameter("@fidelta2", SqlDbType.Int) {Value = ect.iDelta2};
				param[36] = new SqlParameter("@ficost", SqlDbType.Decimal) {Value = ect.iCost};
				param[37] = new SqlParameter("@fimold_p", SqlDbType.Int) {Value = ect.iMoldP};
				param[38] = new SqlParameter("@fimold_prot_p", SqlDbType.Int) {Value = ect.iMoldProtP};
				param[39] = new SqlParameter("@fvobs", SqlDbType.VarChar) {Value = ect.sObservations};
				param[40] = new SqlParameter("@fistart", SqlDbType.Int) {Value = ect.iStart};
				param[41] = new SqlParameter("@fir1", SqlDbType.Decimal) {Value = ect.iFR1};
				param[42] = new SqlParameter("@fir2", SqlDbType.Decimal) {Value = ect.iFR2};
				param[43] = new SqlParameter("@fitotal_inv", SqlDbType.Decimal) {Value = ect.iTotalInv};
				param[44] = new SqlParameter("@fitotal_piece", SqlDbType.Decimal) {Value = ect.iTotalP};
				objDB.ExecStoredIUD("sp_insertQuote", param);
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

		public errorCompositeType UpdateQuote(QuoteCompositeType ect)
		{
			var lstError = new errorCompositeType();
			try
			{
				bool bStatus = true;
				param = new SqlParameter[45];
				param[0] = new SqlParameter("@fiid_exchange", SqlDbType.Int) {Value = ect.iExchange};
				param[1] = new SqlParameter("@fiid_part_list", SqlDbType.Int) {Value = ect.iPartList};
				param[2] = new SqlParameter("@fvSOP", SqlDbType.VarChar) {Value = ect.SOPCliente};
				param[3] = new SqlParameter("@fdIn", SqlDbType.DateTime) {Value = ect.dIn};
				param[4] = new SqlParameter("@fdprom", SqlDbType.DateTime) {Value = ect.dProm};
				param[5] = new SqlParameter("@fdout", SqlDbType.DateTime) {Value = ect.dOut};
				param[6] = new SqlParameter("@fbmold_prot", SqlDbType.Bit) {Value = ect.bMoldProt};
				param[7] = new SqlParameter("@fimold_prot", SqlDbType.Decimal) {Value = ect.iMoldProt};
				param[8] = new SqlParameter("@fbmold_serie", SqlDbType.Bit) {Value = ect.bMoldSerie};
				param[9] = new SqlParameter("@fimold_serie", SqlDbType.Decimal) {Value = ect.iMoldSerie};
				param[10] = new SqlParameter("@fbCF", SqlDbType.Bit) {Value = ect.bCF};
				param[11] = new SqlParameter("@fiCF", SqlDbType.Decimal) {Value = ect.iCF};
				param[12] = new SqlParameter("@fbdevice", SqlDbType.Bit) {Value = ect.bDevice};
				param[13] = new SqlParameter("@fidevice", SqlDbType.Decimal) {Value = ect.iDevice};
				param[14] = new SqlParameter("@fbobsolet", SqlDbType.Bit) {Value = ect.bObsolet};
				param[15] = new SqlParameter("@fiobsolet", SqlDbType.Decimal) {Value = ect.iObsolet};
				param[16] = new SqlParameter("@fbeng_man", SqlDbType.Bit) {Value = ect.bEngMan};
				param[17] = new SqlParameter("@fieng_man", SqlDbType.Decimal) {Value = ect.iEngMan};
				param[18] = new SqlParameter("@fbdesign", SqlDbType.Bit) {Value = ect.bDesign};
				param[19] = new SqlParameter("@fidesign", SqlDbType.Decimal) {Value = ect.iDesign};
				param[20] = new SqlParameter("@fbcomponents", SqlDbType.Bit) {Value = ect.bComponents};
				param[21] = new SqlParameter("@ficomponets", SqlDbType.Decimal) {Value = ect.iComponents};
				param[22] = new SqlParameter("@fbothers", SqlDbType.Decimal) {Value = ect.bOthers};
				param[23] = new SqlParameter("@fvothers", SqlDbType.VarChar) {Value = ect.sOthers};
				param[24] = new SqlParameter("@fiothers", SqlDbType.Decimal) {Value = ect.iOthers};
				param[25] = new SqlParameter("@fbpaint", SqlDbType.Bit) {Value = ect.bPaint};
				param[26] = new SqlParameter("@fipaint", SqlDbType.Decimal) {Value = ect.iPaint};
				param[27] = new SqlParameter("@fbemp", SqlDbType.Bit) {Value = ect.bEmp};
				param[28] = new SqlParameter("@fiemp", SqlDbType.Decimal) {Value = ect.iEmp};
				param[29] = new SqlParameter("@fbbank", SqlDbType.Bit) {Value = ect.bBank};
				param[30] = new SqlParameter("@fibank", SqlDbType.Decimal) {Value = ect.iBank};
				param[31] = new SqlParameter("@fbothersC", SqlDbType.Bit) {Value = ect.bOthersC};
				param[32] = new SqlParameter("@fiothersC", SqlDbType.Decimal) {Value = ect.iOthersC};
				param[33] = new SqlParameter("@fipound", SqlDbType.Decimal) {Value = ect.iPound};
				param[34] = new SqlParameter("@fidelta1", SqlDbType.Int) {Value = ect.iDelta1};
				param[35] = new SqlParameter("@fidelta2", SqlDbType.Int) {Value = ect.iDelta2};
				param[36] = new SqlParameter("@ficost", SqlDbType.Decimal) {Value = ect.iCost};
				param[37] = new SqlParameter("@fimold_p", SqlDbType.Int) {Value = ect.iMoldP};
				param[38] = new SqlParameter("@fimold_prot_p", SqlDbType.Int) {Value = ect.iMoldProtP};
				param[39] = new SqlParameter("@fvobs", SqlDbType.VarChar) {Value = ect.sObservations};
				param[40] = new SqlParameter("@fistart", SqlDbType.Int) {Value = ect.iStart};
				param[41] = new SqlParameter("@fir1", SqlDbType.Decimal) {Value = ect.iFR1};
				param[42] = new SqlParameter("@fir2", SqlDbType.Decimal) {Value = ect.iFR2};
				param[43] = new SqlParameter("@fitotal_inv", SqlDbType.Decimal) {Value = ect.iTotalInv};
				param[44] = new SqlParameter("@fitotal_piece", SqlDbType.Decimal) {Value = ect.iTotalP};
				objDB.ExecStoredIUD("sp_updateQuote", param);
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

		public QuoteCompositeType getQuoteByIdExchangeIdPartList(QuoteCompositeType ect)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@fiid_exchange", SqlDbType.Int) {Value = ect.iExchange};
			param[1] = new SqlParameter("@fiid_part_list", SqlDbType.Int) {Value = ect.iPartList};
			DataTable dt = objDB.ExecStore("sp_selectQuoteByIdExchangeIdPartList", param);
			var qct = new QuoteCompositeType
			          	{
			          		iIdQuote = int.Parse(dt.Rows[0].ItemArray[0].ToString()),
			          		iExchange = int.Parse(dt.Rows[0].ItemArray[1].ToString()),
			          		iPartList = int.Parse(dt.Rows[0].ItemArray[2].ToString()),
			          		sParte = dt.Rows[0].ItemArray[3].ToString(),
			          		sNoPart = dt.Rows[0].ItemArray[4].ToString(),
			          		sClient = dt.Rows[0].ItemArray[5].ToString(),
			          		sDescription = dt.Rows[0].ItemArray[6].ToString(),
			          		sProyect = dt.Rows[0].ItemArray[7].ToString(),
			          		SOPCliente = dt.Rows[0].ItemArray[8].ToString(),
			          		dIn = DateTime.Parse(dt.Rows[0].ItemArray[9].ToString()),
			          		dOut = DateTime.Parse(dt.Rows[0].ItemArray[11].ToString()),
			          		dProm = DateTime.Parse(dt.Rows[0].ItemArray[10].ToString()),
			          		bMoldProt = bool.Parse(dt.Rows[0].ItemArray[12].ToString()),
			          		iMoldProt = decimal.Parse(dt.Rows[0].ItemArray[13].ToString()),
			          		bMoldSerie = bool.Parse(dt.Rows[0].ItemArray[14].ToString()),
			          		iMoldSerie = decimal.Parse(dt.Rows[0].ItemArray[15].ToString()),
			          		bCF = bool.Parse(dt.Rows[0].ItemArray[16].ToString()),
			          		iCF = decimal.Parse(dt.Rows[0].ItemArray[17].ToString()),
			          		bDevice = bool.Parse(dt.Rows[0].ItemArray[18].ToString()),
			          		iDevice = decimal.Parse(dt.Rows[0].ItemArray[19].ToString()),
			          		bObsolet = bool.Parse(dt.Rows[0].ItemArray[20].ToString()),
			          		iObsolet = decimal.Parse(dt.Rows[0].ItemArray[21].ToString()),
			          		bEngMan = bool.Parse(dt.Rows[0].ItemArray[22].ToString()),
			          		iEngMan = decimal.Parse(dt.Rows[0].ItemArray[23].ToString()),
			          		bDesign = bool.Parse(dt.Rows[0].ItemArray[24].ToString()),
			          		iDesign = decimal.Parse(dt.Rows[0].ItemArray[25].ToString()),
			          		bComponents = bool.Parse(dt.Rows[0].ItemArray[26].ToString()),
			          		iComponents = decimal.Parse(dt.Rows[0].ItemArray[27].ToString()),
			          		bOthers = bool.Parse(dt.Rows[0].ItemArray[28].ToString()),
			          		sOthers = dt.Rows[0].ItemArray[29].ToString(),
			          		iOthers = decimal.Parse(dt.Rows[0].ItemArray[30].ToString()),
			          		bPaint = bool.Parse(dt.Rows[0].ItemArray[31].ToString()),
			          		iPaint = decimal.Parse(dt.Rows[0].ItemArray[32].ToString()),
			          		bEmp = bool.Parse(dt.Rows[0].ItemArray[33].ToString()),
			          		iEmp = decimal.Parse(dt.Rows[0].ItemArray[34].ToString()),
			          		bBank = bool.Parse(dt.Rows[0].ItemArray[35].ToString()),
			          		iBank = decimal.Parse(dt.Rows[0].ItemArray[36].ToString()),
			          		bOthersC = bool.Parse(dt.Rows[0].ItemArray[37].ToString()),
			          		iOthersC = decimal.Parse(dt.Rows[0].ItemArray[38].ToString()),
			          		iPound = decimal.Parse(dt.Rows[0].ItemArray[39].ToString()),
			          		iDelta1 = int.Parse(dt.Rows[0].ItemArray[40].ToString()),
			          		iDelta2 = int.Parse(dt.Rows[0].ItemArray[41].ToString()),
			          		iCost = decimal.Parse(dt.Rows[0].ItemArray[42].ToString()),
			          		iMoldP = int.Parse(dt.Rows[0].ItemArray[43].ToString()),
			          		iMoldProtP = int.Parse(dt.Rows[0].ItemArray[44].ToString()),
			          		sObservations = dt.Rows[0].ItemArray[45].ToString(),
			          		iStart = int.Parse(dt.Rows[0].ItemArray[46].ToString()),
			          		iFR1 = decimal.Parse(dt.Rows[0].ItemArray[47].ToString()),
			          		iFR2 = decimal.Parse(dt.Rows[0].ItemArray[48].ToString()),
			          		iTotalInv = decimal.Parse(dt.Rows[0].ItemArray[49].ToString()),
			          		iTotalP = decimal.Parse(dt.Rows[0].ItemArray[50].ToString())
			          	};
			return qct;
		}

		public int getCountQuoteByIdExchangeIdPartList(QuoteCompositeType qct)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@fiid_exchange", SqlDbType.Int) {Value = qct.iExchange};
			param[1] = new SqlParameter("@fiid_part_list", SqlDbType.Int) {Value = qct.iPartList};
			return int.Parse(objDB.ExecStore("sp_selectCountQuoteByIdExchangeIdPartList", param).Rows[0].ItemArray[0].ToString());
		}

		/*
		public int getIdExchangePartListByAll(PartListExchangeCompositeType plect)
		{
			param = new SqlParameter[3];
			param[0] = new SqlParameter("@fiid_part_list", SqlDbType.Int) {Value = plect.iIdPartList};
			param[1] = new SqlParameter("@fiid_affectation_type", SqlDbType.Int) {Value = plect.iIdAffectation};
			param[2] = new SqlParameter("@fiid_exchange", SqlDbType.Int) {Value = plect.iIdExchange};
			DataTable dt = objDB.ExecStore("sp_getIdExchangePartListByAll", param);
			
			return int.Parse(dt.Rows[0].ItemArray[0].ToString());
		}*/

		//public ExchangeFlACompositeType getExchangeFlAByPreFolioUnique(String sPreFolio)
		//{
		//    ExchangeFlACompositeType ect = new ExchangeFlACompositeType();
		//    param = new SqlParameter[1];
		//    param[0] = new SqlParameter("@fvprefolio_ExchangeFlA", SqlDbType.VarChar);
		//    param[0].Value = sPreFolio;

		//    
		//    DataTable dt = objDB.ExecStore("sp_selectExchangeFlAByPreFolio", param);
		//    
		//    if(dt.Rows[0].ItemArray[18].ToString() != "")
		//        ect.dAplicationDate =DateTime.Parse(dt.Rows[0].ItemArray[18].ToString());
		//    if(dt.Rows[0].ItemArray[8].ToString() != "")
		//       // ect.dLimitDate = DateTime.Parse(dt.Rows[0].ItemArray[18].ToString()).ToShortDateString();
		//    ect.iIdClient = int.Parse(dt.Rows[0].ItemArray[13].ToString());
		//    ect.iIdExchangeFlA = int.Parse(dt.Rows[0].ItemArray[0].ToString());
		//    ect.iIdExchangeFlAType =int.Parse(dt.Rows[0].ItemArray[12].ToString());
		//    ect.iIdPlant = int.Parse(dt.Rows[0].ItemArray[11].ToString());
		//    ect.iIdPriority = int.Parse(dt.Rows[0].ItemArray[15].ToString());
		//    ect.iProductEngener = int.Parse(dt.Rows[0].ItemArray[17].ToString());
		//    ect.iSerie = int.Parse(dt.Rows[0].ItemArray[16].ToString());
		//    ect.iStatus = int.Parse(dt.Rows[0].ItemArray[10].ToString());
		//    ect.sClient =dt.Rows[0].ItemArray[19].ToString();
		//    ect.sContact = dt.Rows[0].ItemArray[19].ToString();
		//    ect.sDescription = dt.Rows[0].ItemArray[1].ToString();
		//    ect.sExchangeFlAType = dt.Rows[0].ItemArray[20].ToString();
		//    ect.sFolio = dt.Rows[0].ItemArray[5].ToString();
		//    ect.sFolioPre = dt.Rows[0].ItemArray[6].ToString();
		//    ect.sIssue = dt.Rows[0].ItemArray[2].ToString();
		//    ect.sLastFolio = dt.Rows[0].ItemArray[9].ToString();
		//    ect.sMeasure= dt.Rows[0].ItemArray[3].ToString();
		//    ect.sPlant = dt.Rows[0].ItemArray[21].ToString();
		//    ect.sPriority = dt.Rows[0].ItemArray[22].ToString();
		//    ect.sProductEngener = dt.Rows[0].ItemArray[23].ToString();
		//    ect.sProyect =dt.Rows[0].ItemArray[7].ToString();
		//    ect.sReason = dt.Rows[0].ItemArray[14].ToString();

		//    ect.sSerie = dt.Rows[0].ItemArray[24].ToString();
		//}
		#endregion

		#region Update

		//public errorCompositeType UpdateExchangeFlAById(ExchangeFlACompositeType ect)
		//{
		//    errorCompositeType lstError = new errorCompositeType();

		//    try
		//    {
		//        bool bStatus = true;
		//        param = new SqlParameter[18];

		//        param[0] = new SqlParameter("@fvdescription_ExchangeFlA", SqlDbType.VarChar);
		//        param[0].Value = ect.sDescription;
		//        param[1] = new SqlParameter("@fvissue_ExchangeFlA", SqlDbType.VarChar);
		//        param[1].Value = ect.sIssue;
		//        param[2] = new SqlParameter("@fvmeasure_ExchangeFlA", SqlDbType.VarChar);
		//        param[2].Value = ect.sMeasure;
		//        param[3] = new SqlParameter("@fvcontact_ExchangeFlA", SqlDbType.VarChar);
		//        param[3].Value = ect.sContact;
		//        param[4] = new SqlParameter("@fvfolio_ExchangeFlA", SqlDbType.VarChar);
		//        param[4].Value = ect.sFolio;
		//        param[5] = new SqlParameter("@fvprefolio_ExchangeFlA", SqlDbType.VarChar);
		//        param[5].Value = ect.sFolioPre;
		//        param[6] = new SqlParameter("@fvproyect_ExchangeFlA", SqlDbType.VarChar);
		//        param[6].Value = ect.sProyect;
		//        param[7] = new SqlParameter("@fdlimit_date_ExchangeFlA", SqlDbType.DateTime);
		//        param[7].Value = ect.dLimitDate;
		//        param[8] = new SqlParameter("@fvlast_folio_ExchangeFlA", SqlDbType.VarChar);
		//        param[8].Value = ect.sLastFolio;
		//        param[9] = new SqlParameter("@fistatus_ExchangeFlA", SqlDbType.Int);
		//        param[9].Value = ect.iStatus;
		//        param[10] = new SqlParameter("@fiid_plant", SqlDbType.Int);
		//        param[10].Value = ect.iIdPlant;
		//        param[11] = new SqlParameter("@fiid_ExchangeFlA_type", SqlDbType.Int);
		//        param[11].Value = ect.iIdExchangeFlAType;
		//        param[12] = new SqlParameter("@fiid_client", SqlDbType.Int);
		//        param[12].Value = ect.iIdClient;
		//        param[13] = new SqlParameter("@fvreason_ExchangeFlA", SqlDbType.VarChar);
		//        param[13].Value = ect.sReason;
		//        param[14] = new SqlParameter("@fiid_priority", SqlDbType.Int);
		//        param[14].Value = ect.iIdPriority;
		//        param[15] = new SqlParameter("@fiid_serie_proyect", SqlDbType.Int);
		//        param[15].Value = ect.iSerie;
		//        param[16] = new SqlParameter("@fiid_product_engeener", SqlDbType.Int);
		//        param[16].Value = ect.iProductEngener;
		//        param[17] = new SqlParameter("@fiid_ExchangeFlA", SqlDbType.Int);
		//        param[17].Value = ect.iIdExchangeFlA;
		//        
		//        objDB.ExecStoredIUD("sp_updateExchangeFlA", param);
		//        
		//        lstError.bError = true;
		//        return lstError;
		//    }
		//    catch (Exception ex)
		//    {
		//        lstError.bError = false;
		//        lstError.sError = ex.Message;
		//        return lstError;
		//    }
		//}
		#endregion

		#region Select
		public DataTable GetExchangeFlAByPreFolio(String sPreFolio)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fvPreFolio", SqlDbType.VarChar) {Value = sPreFolio};
			return objDB.ExecStore("sp_selectExchangeFlA_srch", param);
		}

		public int getNumberPreFolio()
		{
			return int.Parse(objDB.Consult("[sp_getPreFolio]").Rows[0].ItemArray[0].ToString());
		}

		public int getNumberFolio()
		{
			return int.Parse(objDB.Consult("[sp_getFolio]").Rows[0].ItemArray[0].ToString());			
		}

		//public ExchangeFlACompositeType getExchangeFlAByPreFolioUnique(String sPreFolio)
		//{
		//    ExchangeFlACompositeType ect = new ExchangeFlACompositeType();
		//    param = new SqlParameter[1];
		//    param[0] = new SqlParameter("@fvprefolio_ExchangeFlA", SqlDbType.VarChar);
		//    param[0].Value = sPreFolio;

		//    
		//    DataTable dt = objDB.ExecStore("sp_selectExchangeFlAByPreFolio", param);
		//    
		//    if(dt.Rows[0].ItemArray[18].ToString() != "")
		//        ect.dAplicationDate =DateTime.Parse(dt.Rows[0].ItemArray[18].ToString());
		//    if(dt.Rows[0].ItemArray[8].ToString() != "")
		//       // ect.dLimitDate = DateTime.Parse(dt.Rows[0].ItemArray[18].ToString()).ToShortDateString();
		//    ect.iIdClient = int.Parse(dt.Rows[0].ItemArray[13].ToString());
		//    ect.iIdExchangeFlA = int.Parse(dt.Rows[0].ItemArray[0].ToString());
		//    ect.iIdExchangeFlAType =int.Parse(dt.Rows[0].ItemArray[12].ToString());
		//    ect.iIdPlant = int.Parse(dt.Rows[0].ItemArray[11].ToString());
		//    ect.iIdPriority = int.Parse(dt.Rows[0].ItemArray[15].ToString());
		//    ect.iProductEngener = int.Parse(dt.Rows[0].ItemArray[17].ToString());
		//    ect.iSerie = int.Parse(dt.Rows[0].ItemArray[16].ToString());
		//    ect.iStatus = int.Parse(dt.Rows[0].ItemArray[10].ToString());
		//    ect.sClient =dt.Rows[0].ItemArray[19].ToString();
		//    ect.sContact = dt.Rows[0].ItemArray[19].ToString();
		//    ect.sDescription = dt.Rows[0].ItemArray[1].ToString();
		//    ect.sExchangeFlAType = dt.Rows[0].ItemArray[20].ToString();
		//    ect.sFolio = dt.Rows[0].ItemArray[5].ToString();
		//    ect.sFolioPre = dt.Rows[0].ItemArray[6].ToString();
		//    ect.sIssue = dt.Rows[0].ItemArray[2].ToString();
		//    ect.sLastFolio = dt.Rows[0].ItemArray[9].ToString();
		//    ect.sMeasure= dt.Rows[0].ItemArray[3].ToString();
		//    ect.sPlant = dt.Rows[0].ItemArray[21].ToString();
		//    ect.sPriority = dt.Rows[0].ItemArray[22].ToString();
		//    ect.sProductEngener = dt.Rows[0].ItemArray[23].ToString();
		//    ect.sProyect =dt.Rows[0].ItemArray[7].ToString();
		//    ect.sReason = dt.Rows[0].ItemArray[14].ToString();
		//    ect.sSerie = dt.Rows[0].ItemArray[24].ToString();

		//    return ect;

		//}

		//public ExchangeFlACompositeType getExchangeFlAById(int iIdExchangeFlA)
		//{
		//    ExchangeFlACompositeType ect = new ExchangeFlACompositeType();
		//    param = new SqlParameter[1];
		//    param[0] = new SqlParameter("@fiid_ExchangeFlA", SqlDbType.Int  );
		//    param[0].Value = iIdExchangeFlA;

		//    
		//    DataTable dt = objDB.ExecStore("sp_selectExchangeFlAById", param);
		//    
		//    if (dt.Rows[0].ItemArray[18].ToString() != "")
		//        ect.dAplicationDate = DateTime.Parse(dt.Rows[0].ItemArray[18].ToString());
		//    if (dt.Rows[0].ItemArray[8].ToString() != "")
		//        ect.dLimitDate = DateTime.Parse(dt.Rows[0].ItemArray[8].ToString());
		//    ect.iIdClient = int.Parse(dt.Rows[0].ItemArray[13].ToString());
		//    ect.iIdExchangeFlA = int.Parse(dt.Rows[0].ItemArray[0].ToString());
		//    ect.iIdExchangeFlAType = int.Parse(dt.Rows[0].ItemArray[12].ToString());
		//    ect.iIdPlant = int.Parse(dt.Rows[0].ItemArray[11].ToString());
		//    ect.iIdPriority = int.Parse(dt.Rows[0].ItemArray[15].ToString());
		//    ect.iProductEngener = int.Parse(dt.Rows[0].ItemArray[17].ToString());
		//    ect.iSerie = int.Parse(dt.Rows[0].ItemArray[16].ToString());
		//    ect.iStatus = int.Parse(dt.Rows[0].ItemArray[10].ToString());
		//    ect.sClient = dt.Rows[0].ItemArray[19].ToString();
		//    ect.sContact = dt.Rows[0].ItemArray[19].ToString();
		//    ect.sDescription = dt.Rows[0].ItemArray[1].ToString();
		//    ect.sExchangeFlAType = dt.Rows[0].ItemArray[20].ToString();
		//    ect.sFolio = dt.Rows[0].ItemArray[5].ToString();
		//    ect.sFolioPre = dt.Rows[0].ItemArray[6].ToString();
		//    ect.sIssue = dt.Rows[0].ItemArray[2].ToString();
		//    ect.sLastFolio = dt.Rows[0].ItemArray[9].ToString();
		//    ect.sMeasure = dt.Rows[0].ItemArray[3].ToString();
		//    ect.sPlant = dt.Rows[0].ItemArray[21].ToString();
		//    ect.sPriority = dt.Rows[0].ItemArray[22].ToString();
		//    ect.sProductEngener = dt.Rows[0].ItemArray[23].ToString();
		//    ect.sProyect = dt.Rows[0].ItemArray[7].ToString();
		//    ect.sReason = dt.Rows[0].ItemArray[14].ToString();
		//    ect.sSerie = dt.Rows[0].ItemArray[24].ToString();

		//    return ect;

		//}
		#endregion
		#endregion //sp_selectExchangeFlAByPrefolio
	}
}