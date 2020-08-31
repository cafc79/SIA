using System;
using System.Data;
using System.Data.SqlClient;

namespace BOCAR.SACI.Data
{
	public class AffectationDocuments : IAffectationDocuments
	{
		private SqlParameter[] param;//comentario prueba
		private ClassDB objDB = new ClassDB();

		#region AffectationDocuments Methods

		#region Insert
		public errorCompositeType InsertExchangeAffectationDocuments(affectationDocumentsCompositeType adct)
		{
			var lstError = new errorCompositeType();
			try
			{
				bool bStatus = true;
				param = new SqlParameter[13];
				param[0] = new SqlParameter("@fiid_Exchange_affectation", SqlDbType.Int) { Value = adct.iIdExchange };
				param[1] = new SqlParameter("@dibujo", SqlDbType.Bit) { Value = adct.bDrawing };
				param[2] = new SqlParameter("@especificaciones", SqlDbType.Bit) { Value = adct.bEspecifications };
				param[3] = new SqlParameter("@HOE", SqlDbType.Bit) {Value = adct.bHOE};
				param[4] = new SqlParameter("@AMEF", SqlDbType.Bit) {Value = adct.bAMEF};
				param[5] = new SqlParameter("@Costos", SqlDbType.Bit) {Value = adct.bCost};
				param[6] = new SqlParameter("@SAP", SqlDbType.Bit) {Value = adct.bSAP};
				param[7] = new SqlParameter("@singoff", SqlDbType.Bit) {Value = adct.bSingOff};
				param[8] = new SqlParameter("@mediosproduccion", SqlDbType.Bit) {Value = adct.bMedia};
				param[9] = new SqlParameter("@dispositivoverificacion", SqlDbType.Bit) {Value = adct.bDevices};
				param[10] = new SqlParameter("@plancontrol", SqlDbType.Bit) {Value = adct.bPlan};
				param[11] = new SqlParameter("@molde", SqlDbType.Bit) {Value = adct.bMold};
				param[12] = new SqlParameter("@Otros", SqlDbType.Bit) {Value = adct.bOthers};
				objDB.ExecStoredIUD("sp_insertAfectationDocuments", param);
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
		public errorCompositeType UpdateExchangeAffectationDocuments(affectationDocumentsCompositeType adct)
		{
			var lstError = new errorCompositeType();
			try
			{
				bool bStatus = true;
				param = new SqlParameter[13];
				param[0] = new SqlParameter("@fiid_Exchange_affectation", SqlDbType.Int) {Value = adct.iIdExchange};
				param[1] = new SqlParameter("@dibujo", SqlDbType.Bit) {Value = adct.bDrawing};
				param[2] = new SqlParameter("@especificaciones", SqlDbType.Bit) {Value = adct.bEspecifications};
				param[3] = new SqlParameter("@HOE", SqlDbType.Bit) {Value = adct.bHOE};
				param[4] = new SqlParameter("@AMEF", SqlDbType.Bit) {Value = adct.bAMEF};
				param[5] = new SqlParameter("@Costos", SqlDbType.Bit) {Value = adct.bCost};
				param[6] = new SqlParameter("@SAP", SqlDbType.Bit) {Value = adct.bSAP};
				param[7] = new SqlParameter("@singoff", SqlDbType.Bit) {Value = adct.bSingOff};
				param[8] = new SqlParameter("@mediosproduccion", SqlDbType.Bit) {Value = adct.bMedia};
				param[9] = new SqlParameter("@dispositivoverificacion", SqlDbType.Bit) {Value = adct.bDevices};
				param[10] = new SqlParameter("@plancontrol", SqlDbType.Bit) {Value = adct.bPlan};
				param[11] = new SqlParameter("@molde", SqlDbType.Bit) {Value = adct.bMold};
				param[12] = new SqlParameter("@Otros", SqlDbType.Bit) {Value = adct.bOthers};
				objDB.ExecStoredIUD("sp_updateAffectationDocuments", param);
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
		public int GetCountAffectationDocumetsByExchangeId(int iIdExchange)
		{
			var adct = new affectationDocumentsCompositeType();
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_Exchange_affectation", SqlDbType.Int) {Value = iIdExchange};
			DataTable dt = objDB.ExecStore("sp_selectCountDocumentsAffectationByIdExchange", param);
			return int.Parse(dt.Rows[0].ItemArray[0].ToString());
		}

		public affectationDocumentsCompositeType GetAffectationDocumetsByExchangeId(int iIdExchange)
		{
			var adct = new affectationDocumentsCompositeType();
			//try
			//{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_Exchange_affectation", SqlDbType.Int) {Value = iIdExchange};
			DataTable dt = objDB.ExecStore("sp_selectDocumentsAffectationByIdExchange", param);
			if (dt.Rows.Count > 0)
			{
				adct.iIdExchange = int.Parse(dt.Rows[0].ItemArray[1].ToString());
				adct.bDrawing = bool.Parse(dt.Rows[0].ItemArray[2].ToString());
				adct.bEspecifications = bool.Parse(dt.Rows[0].ItemArray[3].ToString());
				adct.bHOE = bool.Parse(dt.Rows[0].ItemArray[4].ToString());
				adct.bAMEF = bool.Parse(dt.Rows[0].ItemArray[5].ToString());
				adct.bCost = bool.Parse(dt.Rows[0].ItemArray[6].ToString());
				adct.bSAP = bool.Parse(dt.Rows[0].ItemArray[7].ToString());
				adct.bSingOff = bool.Parse(dt.Rows[0].ItemArray[8].ToString());
				adct.bMedia = bool.Parse(dt.Rows[0].ItemArray[9].ToString());
				adct.bDevices = bool.Parse(dt.Rows[0].ItemArray[10].ToString());
				adct.bPlan = bool.Parse(dt.Rows[0].ItemArray[11].ToString());
				adct.bMold = bool.Parse(dt.Rows[0].ItemArray[12].ToString());
				adct.bOthers = bool.Parse(dt.Rows[0].ItemArray[13].ToString());
			}
			return adct;
		}
		#endregion
		
		#endregion //sp_selectAffectationDocumentsByPrefolio
	}
}