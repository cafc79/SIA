<%@ WebHandler Language="C#" Class="Downloader" %>

using System.IO;
using System.Configuration;
using System.Web;

public class Downloader : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        if (context.Request.QueryString["path"] != null && context.Request.QueryString["ex"] != null && context.Request.QueryString["doc"] != null)
        {
        	string pathArchivo = string.Empty;
            switch (context.Request.QueryString["path"])
            {
                case "1":
            		pathArchivo = ConfigurationManager.AppSettings["URLArchivos"] + "\\" + context.Request.QueryString["ex"] +
            		              "\\" + context.Request.QueryString["doc"];
            		break;
                case "2":
                    pathArchivo = ConfigurationManager.AppSettings["rutaSeguimiento"] + "\\" + context.Request.QueryString["ex"] +
            		              "\\" + context.Request.QueryString["doc"];
            		break;
                case "3":
                    pathArchivo = ConfigurationManager.AppSettings["rutaLiberacion"] + "\\" + context.Request.QueryString["ex"] +
                          "\\" + context.Request.QueryString["doc"];
                    break;
                case "4":
                    pathArchivo = context.Request.QueryString["doc"];
                    break;
            }
            if (File.Exists(pathArchivo))
            {
                var sourceFile = new FileStream(pathArchivo, FileMode.Open);
                long FileSize = sourceFile.Length;
                var getContent = new byte[(int)FileSize];
                sourceFile.Read(getContent, 0, (int)sourceFile.Length);
                sourceFile.Close();
                context.Response.Clear();
                context.Response.ClearContent();
                context.Response.ClearHeaders();
                context.Response.AppendHeader("content-disposition", "attachment; filename=" + context.Request.QueryString["doc"]);
                context.Response.AppendHeader("content-length", FileSize.ToString());
                context.Response.ContentType = "application/octet-stream";
                context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                context.Response.BinaryWrite(getContent);
                context.Response.Flush();
                context.Response.Close();	
            }
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}