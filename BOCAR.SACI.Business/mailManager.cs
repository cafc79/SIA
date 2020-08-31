using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOCAR.SACI.Business;
using BOCAR.SACI.Data;
using System.Net.Mail;

public class mailManager
{
    public mailManager()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
        
    /// <summary>
    /// Envia un e-mail
    /// </summary>
    /// <param name="subject">Titulo del E-Mail.</param>
    /// <param name="body">Contenido del E-Mail.</param>
    /// <param name="listaCorreos">Lista de correos a quien se enviara el E-Mail.</param>
    public bool sendMail(MailMessage message, string sIPAddress, int iPort)
    {
        try
        {
            SmtpClient client = new SmtpClient(sIPAddress, iPort);
            client.Send(message); //<---- REACTIVAR PARA PRODUCCIÓN
            return true;
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return false;
        }
        finally
        {
            message = null;
        }
    }

    public MailMessage CreateMail(ExchangeCompositeType ect, string sIPAddress, int iPort, String sType, String sText)
    {
            string body;
            string subject = "SACI - Notificación Instrucción.";
            
            MailMessage eMail;

            body = "<HTML><HEAD><META http-equiv=Content-Type content=text/html; charset=UTF-8>"
                 + "</HEAD><BODY><DIV><p><FONT face=Arial color=#000000 size=2>"
                 //+ "Correo Prueba Desarrollo"
                 + "<table width='391' border='0' cellspacing='5' >"
                 + "  <tr>"
                 + "    <td width='12'><b></td>"
                 + "    <td width='101'></td>"
                 + "    <td width='255'><B>Estimado usuario: </td>"
                 + "    <td width='5'>&nbsp;</td>"
                 + "  </tr>"
                 + " <tr>"
                 + "    <td>&nbsp;</td>"
                 + "    <td><B></td>"
                 + "    <td><B> Sele informa que el: " + sType + "</td>"
                 + "    <td>&nbsp;</td>"
                 + " </tr>"
                 + "  <tr>"
                 + "    <td>&nbsp;</td>"
                 + "    <td>Descripción: </td>"
                 + "    <td><B>" + ect.sDescription + "</td>"
                 + "    <td>&nbsp;</td>"
                 + "  </tr>"
                 + "  <tr>"
                 + "    <td>&nbsp;</td>"
                 + "    <td>Proyecto: </td>"
                 + "    <td>" + ect.sProyect + "</td>"
                 + "    <td>&nbsp;</td>"
                 + "  </tr>"
                + "  <tr>"
                + "    <td>&nbsp;</td>"
                + "    <td><B>Ha Sido: </td>"
                + "    <td><B>" + sText + "</td>"
                + "    <td>&nbsp;</td>"
                + "  </tr>"
                + "</table></FONT></DIV></body></html>";
       String mail = System.Configuration.ConfigurationSettings.AppSettings["mailAddres"].ToString();
       eMail = MakeMail(mail, subject, body);
       return eMail;
    }
        
    public static MailMessage MakeMail(string sRemitente, string sAsunto, string sCuerpo)
    {
         try
         {
                //Establece los datos principales del correo
                MailMessage message = new MailMessage();
                message.From = new MailAddress(sRemitente);
                //Quita caracteres de retorno de carro y linea nueva
                sAsunto = sAsunto.Replace('\n', ' ');
                sAsunto = sAsunto.Replace('\r', ' ');
                message.Subject = sAsunto;
                sCuerpo = sCuerpo.Replace('\n', ' ');
                sCuerpo = sCuerpo.Replace('\r', ' ');
                message.Body = sCuerpo;
                message.IsBodyHtml = true;
                return message;
         }
         catch (Exception ex)
         {
                Console.Write(ex.Message);
                return null;
         }
    }

    public MailMessage AddEmailAdrees(MailMessage message, string sDestinatario)
    {
        message.To.Add(new MailAddress(sDestinatario));
        return message;
    }
}

