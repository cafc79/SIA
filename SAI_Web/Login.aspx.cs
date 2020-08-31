using System;
using System.Web;
using System.Web.Security;
using DS.SAI.Business;

public partial class Login : System.Web.UI.Page
{

    #region Eventos

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FormsAuthentication.SignOut();
            if (System.Web.HttpContext.Current.Session != null)
                System.Web.HttpContext.Current.Session.RemoveAll();
        }   
    }

    protected void cmdAceptarInicio_Click(object sender, EventArgs e)
    {
        this.lblError.Text = string.Empty;
        try
        {
            this.Autenticar();
        }
        catch (Exception ex)
        {
            Alert.Show("Ha ocurrido un error de conexión, favor de intentarlo nuevamente", this.Page);
        }
    }

    protected void cmdCancelarInicio_Click(object sender, EventArgs e)
    {
        this.lblError.Text = string.Empty;
        txtUsuario.Value = string.Empty;
        //txtContrasena.Value = string.Empty;
    }

    #endregion

    #region metodos
    /// <summary>
    /// Autentica a un Usuario para ingresar a una aplicación, validando que el número de intentos sea válido.
    /// Realiza las acciones correspondientes de acuerdo al estado del usuario autenticado.
    /// </summary> 
    public void Autenticar()
    {
        var sm = new SecurityManager();
        var LoUsuario = new DS.SAI.Data.ClassUsuario();
        string LsUsuario = this.txtUsuario.Value.Trim();
        string LsContrasena = this.txtContrasena.Value.Trim();
        string LsContraseñaENC = FormsAuthentication.HashPasswordForStoringInConfigFile(LsContrasena, "sha1");
        try
        {
            LoUsuario = ValidarAcceso(LsUsuario, LsContraseñaENC);
            if (LoUsuario != null && LoUsuario.Autenticacion)
            {
                HttpCookie LoCookie;
                string LsCookie = string.Empty;
                string LsDatos = SecurityManager.GenerarDatos(LoUsuario);

                var LoTicket = new FormsAuthenticationTicket(1, LsUsuario, DateTime.Now,
                                                             DateTime.Now.AddMinutes(60), false, LsDatos);
                Session.Timeout = 120;
                LsCookie = FormsAuthentication.Encrypt(LoTicket);
                LoCookie = new HttpCookie(FormsAuthentication.FormsCookieName, LsCookie);
                Response.Cookies.Add(LoCookie);
                Response.Redirect("~/Portada.aspx", false);
            }
        }
        catch (ApplicationException ae)
        {
            Alert.Show(ae.Message, this.Page);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message, this.Page);
        }
    }

    public DS.SAI.Data.ClassUsuario ValidarAcceso(string PsUsuario, string PsPassword)
    {
        DateTime dDate, dLastMod, dExp;
        int ExpDays, iLogonAttempts;
        Boolean bLock;
        String sPass;
        var loUsuario = new DS.SAI.Data.ClassUsuario();
        var acceso = new SecurityManager();
        var dtUsuarios = acceso.ValidaUsuario(PsUsuario, PsPassword);
        if (dtUsuarios != null)
        {
            loUsuario.Usuario = dtUsuarios["fvuser_name"].ToString();
            loUsuario.IdUsuario = int.Parse(dtUsuarios["fiid_user"].ToString());
            loUsuario.IdArea = int.Parse(dtUsuarios["fiid_area"].ToString());
            loUsuario.IdPlant = int.Parse(dtUsuarios["fiid_plant"].ToString());
            loUsuario.IdEmpleado = int.Parse(dtUsuarios["fiid_employed"].ToString());
            loUsuario.IdRol = int.Parse(dtUsuarios["fiRol"].ToString());
            loUsuario.Perfil = dtUsuarios["fcDescription"].ToString();
            loUsuario.Autenticacion = true;

            dDate = DateTime.Parse(dtUsuarios["fdDate"].ToString());
            dLastMod = DateTime.Parse(dtUsuarios["fdModification_date"].ToString());
            bLock = Boolean.Parse(dtUsuarios["fbLock"].ToString());
            int.TryParse(dtUsuarios["fiLogonAttempts"].ToString(), out iLogonAttempts);
            sPass = dtUsuarios["fvpassword"].ToString();
            if (sPass == PsPassword)
            {
                if (bLock)
                {
                    loUsuario.Autenticacion = false;
                    Alert.Show("El usuario esta bloqueado, favor de ponerse en contacto con el administrador del sistema", this.Page);
                }
                else if (iLogonAttempts > 0)
                    acceso.LogonAttempts(loUsuario.Usuario, false, 0);
            }
            else
            {
                iLogonAttempts += 1;
                if (iLogonAttempts < 3)
                {
                    acceso.LogonAttempts(loUsuario.Usuario, false, iLogonAttempts);
                    Alert.Show("Usuario o contraseña incorrectos", this.Page);
                }
                else
                {
                    acceso.LogonAttempts(loUsuario.Usuario, true, 3);
                    Alert.Show("El usuario " + PsUsuario + " ha sido bloqueado, favor de ponerse encontacto con el administrador del sistema", this.Page);
                }
            }
        }
        else
            Alert.Show("Usuario o contraseña incorrectos", this.Page);
        return loUsuario;
    }
    #endregion
}