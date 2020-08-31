using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using BOCAR.SACI.Data;

namespace BOCAR.SACI.Business
{
	public class PDFManager
	{
		private Document pdfFile;
		private iTextSharp.text.Font fontTitulos;
		private iTextSharp.text.Font fontFields;
		private iTextSharp.text.Font fontBase;
		private affectationDocumentsCompositeType adct;
		private ExchangeCompositeType ex;
		private System.Data.DataTable dtAutorization;
		private List<PartListExchangeCompositeType> lPartList;
		private string ServerPath;
		public bool lockClose;

		public PDFManager(int iExchange, string serverPath)
		{
			ServerPath = serverPath;
			ex = new ExchangeCompositeType();
			adct = new affectationDocumentsCompositeType();
			var em = new ExchangeManager();
			ex = em.getExchangeById(iExchange);
			var adm = new AffectationDocumentsManager();
			adct = adm.GetAffectationDocumentsByIdExchange(iExchange);
			var objAutorization = new TaskAutorizationManager();
			dtAutorization = objAutorization.GetAll(iExchange);
			var objPartList = new PartListExchangeManager();
			lPartList = new List<PartListExchangeCompositeType>();
			lPartList = objPartList.getAllPartListExchange(iExchange);
			lockClose = true;
		}

		public byte[] ExchangeNote(string sTitulo)
		{
			var pdfStream = new MemoryStream();
			pdfFile = new Document(iTextSharp.text.PageSize.LETTER);
			PdfWriter writer = PdfWriter.GetInstance(pdfFile, pdfStream);
			writer.SetPdfVersion(PdfWriter.PDF_VERSION_1_7);
			writer.CompressionLevel = PdfStream.BEST_COMPRESSION;
			//writer.SetFullCompression();

			pdfFile.Open();
			//pdfFile.PageSize.BackgroundColor = new BaseColor(255,255,255);
			pdfFile.PageSize.Rotate();
			pdfFile.AddAuthor("DeltaSoft");
			pdfFile.AddCreator("DeltaSoft");
			pdfFile.AddCreationDate();
			pdfFile.AddTitle(sTitulo);
			//pdfFile.AddSubject(subject);
			//pdfFile.AddKeywords(sb.ToString());
			fontBase = new iTextSharp.text.Font(FontFactory.GetFont(FontFactory.COURIER, 9, iTextSharp.text.Font.NORMAL));
			fontTitulos = new iTextSharp.text.Font(FontFactory.GetFont(FontFactory.COURIER, 10, iTextSharp.text.Font.BOLD));
			fontFields = new iTextSharp.text.Font(FontFactory.GetFont(FontFactory.COURIER, 9, iTextSharp.text.Font.BOLD));
			ExchangeNote();
			pdfFile.Close();
			return pdfStream.ToArray();
		}

		private void ExchangeNote()
		{
			float[] widths = new float[] { 1f, 2f };

			#region Header: Logo y Aviso

			string aviso = ex.sFolioPre == "0" ? ex.sFolio : ex.sFolioPre + " / " + ex.sFolio;
			pdfFile.Add(HeaderLogo(aviso));
			pdfFile.Add(new Phrase(Environment.NewLine));

			#endregion

			#region Prioridad

			var table = new PdfPTable(1);
			table.AddCell(new PdfPCell(new PdfPCell(new Phrase(ex.sPriority, fontTitulos))) {HorizontalAlignment = 1});
			pdfFile.Add(table);
			pdfFile.Add(new Phrase(Environment.NewLine));

			#endregion

			#region Datos Generales

			pdfFile.Add(SubjectSection("DATOS GENERALES"));
			pdfFile.Add(new Phrase(Environment.NewLine));
			pdfFile.Add(GeneralesR1(ex.sExchangeType, ex.sSerie));
			pdfFile.Add(GeneralesR2(ex.sPlant, ex.sClient, ex.sLastFolio));
			pdfFile.Add(GeneralesR3(ex.dLimitDate, ex.dInitChange));
			var tGenerales = new PdfPTable(2);
			tGenerales.SetWidths(widths);
			var space = new PdfPCell[]
			            	{
			            		new PdfPCell(new Paragraph()) {Border = 0}, new PdfPCell(new Paragraph()) {Border = 0}
			            	};
			tGenerales.Rows.Add(new PdfPRow(space));
			tGenerales.Rows.Add(new PdfPRow(space));
			tGenerales.Rows.Add(RowLC("Proyecto/Plataforma", ex.sProyect));
			tGenerales.Rows.Add(RowLC("Descripción", ex.sDescription));
			tGenerales.Rows.Add(RowLC("Problema", ex.sIssue));
			tGenerales.Rows.Add(RowLC("Motivo", ex.sReason));
			tGenerales.Rows.Add(RowLC("Acción", ex.sMeasure));
			pdfFile.Add(tGenerales);
			pdfFile.Add(new Phrase(Environment.NewLine));
			
			#endregion

			#region Documentos Afectados

			pdfFile.Add(SubjectSection("DOCUMENTOS AFECTADOS"));
			pdfFile.Add(new Phrase(Environment.NewLine));
			//if (ex.sExchangeType.Contains("Cambio"))
			//{
				pdfFile.Add(DocumentosA(new List<bool>
				                       	{
				                       		adct.bDrawing,
				                       		adct.bHOE,
				                       		adct.bMedia,
				                       		adct.bSingOff,
				                       		adct.bEspecifications,
				                       		adct.bAMEF,
				                       		adct.bDevices,
				                       		adct.bMold,
				                       		adct.bCost,
				                       		adct.bSAP,
				                       		adct.bPlan,
				                       		adct.bOthers
				                       	}));
			//}
			pdfFile.Add(new Phrase(Environment.NewLine));
			var tDocumentos2 = new PdfPTable(2);
			tDocumentos2.SetWidths(widths);
			tDocumentos2.Rows.Add(RowLC("Contacto Cliente", ex.sContact));
			tDocumentos2.Rows.Add(RowLC("Ingeniero de Producto", ex.sProductEngener));
			pdfFile.Add(tDocumentos2);
			pdfFile.Add(new Phrase(Environment.NewLine));

			#endregion

			pdfFile.NewPage();

			#region Header: Logo y Aviso

			pdfFile.Add(HeaderLogo(aviso));
			pdfFile.Add(new Phrase(Environment.NewLine));

			#endregion

			#region Prioridad

			pdfFile.Add(table);
			pdfFile.Add(new Phrase(Environment.NewLine));

			#endregion

			#region Aprobaciones

			pdfFile.Add(SubjectSection("APROBACIONES"));
			pdfFile.Add(new Phrase(Environment.NewLine));
			pdfFile.Add(Aprobaciones());
			pdfFile.Add(new Phrase(Environment.NewLine));
			#endregion

			#region Partes Afectadas

			pdfFile.Add(SubjectSection("RELACIÓN DE PARTES AFECTADAS"));
			pdfFile.Add(new Phrase(Environment.NewLine));
			pdfFile.Add(ListaPartes());
			pdfFile.Add(new Phrase(Environment.NewLine));

			#endregion
		}

		#region Header

		private PdfPTable HeaderLogo(string sFolio)
		{
			if (File.Exists(ServerPath + "/logoBocar.png"))
			{
				Image logo = Image.GetInstance(ServerPath + "/logoBocar.png");
				logo.Alignment = Element.ALIGN_CENTER;
				pdfFile.Add(logo);
			}
			//logo.SetAbsolutePosition(72, 72);
			pdfFile.Add(new Phrase(Environment.NewLine));
			var myfont =
				new iTextSharp.text.Font(FontFactory.GetFont(FontFactory.COURIER, 12, iTextSharp.text.Font.BOLD,
				                                             new BaseColor(211, 211, 211)));
			var cell1 = new PdfPCell(new Phrase("Aviso de Cambio", myfont))
			            	{BackgroundColor = new BaseColor(0, 0, 0), Border = PdfPCell.BOX};
			var cell2 = new PdfPCell(new PdfPCell(new Phrase(sFolio, fontBase))) { Border = PdfPCell.BOX };
			var table = new PdfPTable(2);
			table.AddCell(cell1);
			table.AddCell(cell2);
			return table;
		}

		private PdfPTable SubjectSection(string section)
		{
			var table = new PdfPTable(1);
			var myfont = new iTextSharp.text.Font(FontFactory.GetFont(FontFactory.COURIER, 12, iTextSharp.text.Font.BOLD));
			table.AddCell(new PdfPCell(new Phrase(section, myfont))
			              	{BackgroundColor = new BaseColor(211, 211, 211), Border = 0, HorizontalAlignment = 1});
			return table;
		}

		#endregion

		#region Generales

		private PdfPTable GeneralesR1(string sCambio, string sTipo)
		{
			var tGenerales = new PdfPTable(5);
			float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f };
			tGenerales.SetWidths(widths);
			var cells = new PdfPCell[]
			            	{
			            		new PdfPCell(new Phrase("Tipo de Cambio", fontFields)) {Border = 0},new PdfPCell(new Phrase(sCambio, fontBase)) { Border = PdfPCell.BOX}, 
											new PdfPCell(new Phrase("")) {Border = 0},
			            		new PdfPCell(new Phrase("Tipo  ", fontFields)) {Border = 0, HorizontalAlignment = 2}, new PdfPCell(new Phrase(sTipo, fontBase)) { Border = PdfPCell.BOX}
			            	};
			var space = new PdfPCell[]
			            	{
			            		new PdfPCell(new Paragraph()) {Border = 0}, new PdfPCell(new Paragraph()) {Border = 0}, new PdfPCell(new Paragraph()) {Border = 0},
			            		new PdfPCell(new Paragraph()) {Border = 0}, new PdfPCell(new Paragraph()) {Border = 0}
			            	};
			tGenerales.Rows.Add(new PdfPRow(cells));
			tGenerales.Rows.Add(new PdfPRow(space));
			return tGenerales;
		}

		private PdfPTable GeneralesR2(string sPlanta, string sCliente, string sFolioAnt)
		{
			var tGenerales = new PdfPTable(6);
			float[] widths = new float[] { 1.5f, 2.5f, 1.5f, 2.5f, 1.5f, 2f };
			tGenerales.SetWidths(widths);
			var cells = new PdfPCell[]
			            	{
			            		new PdfPCell(new Phrase("Planta", fontFields)) {Border = 0}, 
											new PdfPCell(new Phrase(sPlanta, fontBase)),
			            		new PdfPCell(new Phrase("Cliente", fontFields)) {Border = 0, HorizontalAlignment = 1},
			            		new PdfPCell(new Phrase(sCliente, fontBase)),
			            		new PdfPCell(new Phrase("Folio Anterior", fontFields)) {Border = 0, HorizontalAlignment = 2},
			            		new PdfPCell(new Phrase(sFolioAnt, fontBase))
			            	};
			Boxing(cells);
			var space = new PdfPCell[]
			            	{
			            		new PdfPCell(new Paragraph()) {Border = 0}, new PdfPCell(new Paragraph()) {Border = 0},
			            		new PdfPCell(new Paragraph()) {Border = 0}, new PdfPCell(new Paragraph()) {Border = 0},
			            		new PdfPCell(new Paragraph()) {Border = 0}, new PdfPCell(new Paragraph()) {Border = 0}
			            	};
			tGenerales.Rows.Add(new PdfPRow(cells));
			tGenerales.Rows.Add(new PdfPRow(space));
			return tGenerales;
		}

		private PdfPTable GeneralesR3(object oFLimite, object oFCambio)
		{
			var tGenerales = new PdfPTable(4);
			var widths = new float[] { 4.2f, 1.8f, 4.2f, 1.8f };
			tGenerales.SetWidths(widths);
			var sF1 = string.Empty;
			var sF2 = string.Empty;
			if (oFLimite != null && ((DateTime)oFLimite).ToShortDateString() != "01/01/0001")
				sF1 = ((DateTime)oFLimite).ToShortDateString();
			if (oFCambio != null && ((DateTime)oFCambio).ToShortDateString() != "01/01/0001")
				sF2 = ((DateTime) oFCambio).ToShortDateString();
			var cells = new PdfPCell[]
			            	{
			            		new PdfPCell(new Phrase("Fecha Límite de Cotización", fontTitulos)) {Border = 0},
			            		new PdfPCell(new Phrase(sF1, fontBase)) {HorizontalAlignment = 1},
			            		new PdfPCell(new Phrase("Fecha de Inicio de Cambio", fontTitulos)) {Border = 0, HorizontalAlignment = 2},
			            		new PdfPCell(new Phrase(sF2, fontBase)){HorizontalAlignment = 1}
			            	};
			Boxing(cells);
			var space = new PdfPCell[]
			            	{
			            		new PdfPCell(new Paragraph()) {Border = 0}, new PdfPCell(new Paragraph()) {Border = 0},
			            		new PdfPCell(new Paragraph()) {Border = 0}, new PdfPCell(new Paragraph()) {Border = 0}
			            	};
			tGenerales.Rows.Add(new PdfPRow(cells));
			tGenerales.Rows.Add(new PdfPRow(space));
			return tGenerales;
		}

		#endregion

		#region Shared

		private PdfPRow RowLC(string sLabel, string sContent)
		{
			var cells = new PdfPCell[]
			            	{new PdfPCell(new Phrase(sLabel, fontTitulos)) {Border = 0}, new PdfPCell(new Phrase(sContent, fontBase))};
			Boxing(cells);
			return new PdfPRow(cells);
		}

		private PdfPRow RowContent(string[] content, byte section)
		{
			var swap = new PdfPCell[content.Length];
			switch (section)
			{
				case 1:
					
					for (int i = 0; i < content.Length; i++)
						swap[i] = new PdfPCell(new Phrase(content[i], fontFields))
						          	{BackgroundColor = new BaseColor(211, 211, 211), Border = 0};
					break;
				case 2:
					for (int i = 0; i < content.Length; i++)
						swap[i] = new PdfPCell(new Phrase(content[i], fontBase))
						          	{BackgroundColor = new BaseColor(255, 255, 255), Border = 0};
					break;
				case 3:
					for (int i = 0; i < content.Length; i++)
						swap[i] = new PdfPCell(new Phrase(content[i], fontBase))
						          	{BackgroundColor = new BaseColor(175, 238, 238), Border = 0};
					break;
			}
			return new PdfPRow(swap);
		}

		private void Boxing(PdfPCell[] cells)
		{
			for (int i = 0; i < cells.Length; i++)
			{
				if (i%2 > 0)
					cells[i].Border = PdfPCell.BOX;
			}
		}

		#endregion

		#region Documentos

		private PdfPTable DocumentosA(List<bool> bAfectados)
		{
			var swap = new List<string>()
			           	{
			           		"Dibujo",
			           		"HOE",
			           		"Medios de Producción",
			           		"Sing Off",
			           		"Especificaciones",
			           		"AMEFF",
			           		"Dispositivos de Verificación",
			           		"Molde",
			           		"Costos",
			           		"SAP",
			           		"Plan de Control",
			           		"Otros"
			           	};
			var cells = new List<PdfPCell>();
			for (var i = 0; i < swap.Count; i++)
			{
				cells.Add(bAfectados[i] ? new PdfPCell(new Phrase("X", fontBase)) { Border = PdfPCell.BOX, HorizontalAlignment = 1 } : new PdfPCell(new Phrase()) { Border = PdfPCell.BOX });
				var myfont = new iTextSharp.text.Font(FontFactory.GetFont(FontFactory.COURIER, 10, iTextSharp.text.Font.NORMAL));
				cells.Add(new PdfPCell(new Phrase(swap[i], myfont)) { Border = 0 });
			}
			var tDocumentos = new PdfPTable(4);
			float[] widths = new float[] { 30f, 200f, 30f, 200f };
			tDocumentos.SetWidths(widths);
			foreach (var pdfPCell in cells)
			{
				tDocumentos.AddCell(pdfPCell);
			}
			return tDocumentos;
		}

		#endregion

		#region Tablas Informativas

		private PdfPTable Aprobaciones()
		{
			var table = new PdfPTable(3);
			float[] widths = new float[] { 4f, 2f, 4f };
			table.SetWidths(widths);
			table.Rows.Add(RowContent(new string[] {"Nombre de Gerente", "Área", "Día y Hora de Aprobación"}, 1));
			
			for (int i = 0; i < dtAutorization.Rows.Count; i++)
			{
				table.Rows.Add(i%2 > 0
				               	? RowContent(
				               		new string[]
				               			{
				               				dtAutorization.Rows[i].ItemArray[5].ToString(), dtAutorization.Rows[i].ItemArray[1].ToString(),
				               				dtAutorization.Rows[i].ItemArray[4].ToString()
				               			}, 3)
				               	: RowContent(
				               		new string[]
				               			{
				               				dtAutorization.Rows[i].ItemArray[5].ToString(), dtAutorization.Rows[i].ItemArray[1].ToString(),
				               				dtAutorization.Rows[i].ItemArray[4].ToString()
				               			}, 2));
			}
			return table;
		}

		private PdfPTable ListaPartes()
		{
			var table = new PdfPTable(4);
			float[] widths = new float[] { 1.5f, 1.5f, 2.5f, 1f };
			table.SetWidths(widths);
			table.Rows.Add(RowContent(new string[] {"No Parte BOCAR", "No. Parte CLIENTE", "Descripción", "Afectación"}, 1));
			for (int i = 0; i < lPartList.Count; i++)
			{
				table.Rows.Add(i%2 > 0
				               	? RowContent(
				               		new string[]
				               			{
				               				lPartList[i].sPartListBocar, lPartList[i].sPartListClient, lPartList[i].sPartListDescription,
				               				lPartList[i].sAffectationDescription
				               			}, 3)
				               	: RowContent(
				               		new string[]
				               			{
				               				lPartList[i].sPartListBocar, lPartList[i].sPartListClient, lPartList[i].sPartListDescription,
				               				lPartList[i].sAffectationDescription
				               			}, 2));
			}
			return table;
		}

		#endregion
	}
}