using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Configuration;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Web;
using DA = DS.SAI.Data;

namespace DS.SAI.Business
{
	public class BuzonManager
	{
		private DA.BuzonAccess datos;
		private static string SmtpIp { get; set; }
		private static int ServerPort { get; set; }
		private static string UserMail { get; set; }
		private static string PasswordMail { get; set; }
		private static string Sender { get; set; }
		
		public BuzonManager()
		{
			datos = new DA.BuzonAccess();
			//SmtpIp = ConfigurationSettings.AppSettings["smtpServer"];
			//ServerPort = int.Parse(ConfigurationSettings.AppSettings["smtpPort"]);
			//UserMail = ConfigurationSettings.AppSettings["smtpUser"];
			//PasswordMail = ConfigurationSettings.AppSettings["smtpPassword"];
			//Sender = ConfigurationSettings.AppSettings["smtpFrom"].Trim();
		}

		public DataTable GetMessages()
		{
			try
			{				
				HttpContext contexto = HttpContext.Current;
				return datos.GetMessages(SecurityManager.ObtenerUsuario(contexto).IdUsuario);
			}
			catch
			{
				throw new Exception();
			}
		}

		public void ReviewMessage(int iMensaje, int iUsuario)
		{
			try
			{				
				HttpContext contexto = HttpContext.Current;
				datos.ReviewMessages(SecurityManager.ObtenerUsuario(contexto).IdUsuario, iMensaje);
			}
			catch
			{
				throw new Exception();
			}
		}

		public void SendMail_SMTP(List<string> sendTo, string mensaje, string asunto)
		{
			var client = new SmtpClient(SmtpIp);
            var message = new MailMessage(Sender, Sender) { Body = mensaje, Subject = asunto };
			foreach (var cc in sendTo)
				message.CC.Add(cc);
			client.Credentials = new System.Net.NetworkCredential(UserMail, PasswordMail);
			//client.EnableSsl = true;
			//client.Timeout = 100;
			if (ServerPort != 0)
				client.Port = ServerPort;
			ServicePointManager.ServerCertificateValidationCallback =
					delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
			try
			{
				client.Send(message);
			}
			catch (SmtpException se)
			{
				throw new Exception(se.StatusCode + " " + se.Message + "; SendMail_SMTP - No se puede enviar el mail", se);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message + "; SendMail_SMTP - No se puede enviar el mail", ex);
			}
		}

		public void DeleteConfigBuzon(int iConfiguracion)
		{
			datos.DeleteConfigBuzon(iConfiguracion);
		}

		public void InsertConfigBuzon(int iModulo, List<string> lstEtapas, List<byte> lstAreas, List<byte> lstUsuarios)
		{
			string sEtapas = lstEtapas.Aggregate(string.Empty, (current, s) => s + "|" + current);
			string sAreas = lstAreas.Aggregate(string.Empty, (current, s) => s + "|" + current);
			string sUsuarios = lstUsuarios.Aggregate(string.Empty, (current, s) => s + "|" + current);
			datos.InsertConfigBuzon(iModulo, sEtapas, sAreas, sUsuarios);
		}
	}
}
