<%@ WebHandler Language="C#" Class="OnFly" %>

using System.Web;
using BOCAR.SACI.Business;

public class OnFly : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
    	if (context.Request.QueryString["ex"] == null || context.Request.QueryString["ex"] == "0") return;
    	var swap = new PDFManager(int.Parse(context.Request.QueryString["ex"]), context.Request.QueryString["path"]);
    	var buffer = swap.ExchangeNote("Aviso de Cambio");
    	context.Response.Clear();
    	context.Response.ClearContent();
    	context.Response.ClearHeaders();
    	context.Response.AppendHeader("content-disposition", "attachment; filename=AvisoDeCambio.pdf");
    	context.Response.AppendHeader("content-length", buffer.Length.ToString());
    	context.Response.ContentType = "application/octet-stream";
    	context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
    	context.Response.BinaryWrite(buffer);
    	context.Response.Flush();
    	context.Response.Close();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}