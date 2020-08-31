using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DS.SAI.Data;

namespace DS.SAI.Business
{
	public class AffectationDocumentsManager
	{
		public AffectationDocumentsManager()
		{

		}

		public int GetCountAffectationDocumentsByIdExchange(int iIdExchange)
		{
			affectationDocumentsCompositeType adct = new affectationDocumentsCompositeType();
			AffectationDocuments ad = new AffectationDocuments();
			return ad.GetCountAffectationDocumetsByExchangeId(iIdExchange);
		}

		public errorCompositeType AddAffectationDocuments(affectationDocumentsCompositeType adct)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				AffectationDocuments et = new AffectationDocuments();
				et.InsertExchangeAffectationDocuments(adct);
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

		public errorCompositeType UpdateAffectationDocuments(affectationDocumentsCompositeType adct)
		{
			errorCompositeType lstError = new errorCompositeType();
			try
			{
				AffectationDocuments et = new AffectationDocuments();
				et.UpdateExchangeAffectationDocuments(adct);
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

		public affectationDocumentsCompositeType GetAffectationDocumentsByIdExchange(int iIdExchange)
		{
			affectationDocumentsCompositeType adct = new affectationDocumentsCompositeType();
			AffectationDocuments ad = new AffectationDocuments();

			adct = ad.GetAffectationDocumetsByExchangeId(iIdExchange);
			return adct;
		}
	}
}