using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Security;
using BOCAR.SACI.Data;

namespace BOCAR.SACI.Business
{
	public class SecurityManager: IDisposable
	{
		public DataRow ValidaUsuario(string PsUsuario, string PsPassword)
		{
			try
			{
				var user = new User();
				return user.ValidarAcceso(PsUsuario, PsPassword);
			}
			catch (ApplicationException ae)
			{
				throw new ApplicationException(ae.Message);
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public List<menuRolCompositeType> GetMenuByUser(int iRol)
		{
			var swap = new MenuRolManager();
			return swap.getAllMenuRol(iRol);
		}

		public void LogonAttempts(string sUserName, Boolean bLock, int iLogonAttempts)
		{
			try
			{
				var user = new User();
				user.LogonAttempts(sUserName, bLock, iLogonAttempts);
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		/// <summary>
		/// Función que obtiene un objeto de tipo classUsuario a partir
		/// de los datos del Contexto del usuario que ha sido autenticado
		/// </summary>
		/// <param name="PoContext">Objeto de tipo HttpContext</param>
		/// <returns>Objeto de tipo classUsuario</returns>
		public static ClassUsuario ObtenerUsuario(HttpContext PoContext)
		{
			FormsAuthenticationTicket loTicketAutenticacion = null;
			string lsCookieName = FormsAuthentication.FormsCookieName;
			HttpCookie loCookieAutenticacion = PoContext.Request.Cookies[lsCookieName];
			if (loCookieAutenticacion == null)
				return null;
			try
			{
				loTicketAutenticacion = FormsAuthentication.Decrypt(loCookieAutenticacion.Value);
				if (loTicketAutenticacion == null)
					return null;
				string[] lsDatosUsuario = loTicketAutenticacion.UserData.Split('|');
				if (lsDatosUsuario.Length > 0)
				{
					var loUsuario = new ClassUsuario
														{
															Usuario = lsDatosUsuario[0],
															Perfil = lsDatosUsuario[1],
															Autenticacion = true,
															IdUsuario = int.Parse(lsDatosUsuario[3]),
															IdEmpleado = int.Parse(lsDatosUsuario[4]),
															IdRol = int.Parse(lsDatosUsuario[5]),
															IdPlant = int.Parse(lsDatosUsuario[6]),
															IdArea = int.Parse(lsDatosUsuario[7])
														};
					return loUsuario;
				}
			}
			catch (Exception)
			{
				return null;
			}
			return null;
		}

		/// <summary>
		/// Función que genera una cadena con la información de un usuario autenticado en el
		/// sistema. La información es obtenida en un objeto de tipo classUsuario
		/// y transformada a una cadena de valores separa por el caracter "I" y que es almacenada
		/// en el ticket de autenticación de los usuarios que entran al sistema.
		/// </summary>
		/// <param name="PoUsuario">Objeto de tipo classUsuario</param>
		/// <returns>Cadena con los valores del usuario separado por el caracter "|"</returns>
		public static string GenerarDatos(ClassUsuario PoUsuario)
		{
			var lsDatos = new StringBuilder();
			if (PoUsuario != null)
			{
				lsDatos.Append(PoUsuario.Usuario);
				lsDatos.Append("|");
				lsDatos.Append(PoUsuario.Perfil);
				lsDatos.Append("|");
				lsDatos.Append(PoUsuario.Autenticacion);
				lsDatos.Append("|");
				lsDatos.Append(PoUsuario.IdUsuario);
				lsDatos.Append("|");
				lsDatos.Append(PoUsuario.IdEmpleado);
				lsDatos.Append("|");
				lsDatos.Append(PoUsuario.IdRol);
				lsDatos.Append("|");
				lsDatos.Append(PoUsuario.IdPlant);
				lsDatos.Append("|");
				lsDatos.Append(PoUsuario.IdArea);
			}
			return lsDatos.ToString();
		}

		public void Dispose()
		{
			Dispose();
			GC.SuppressFinalize(this);
		}
	}
}