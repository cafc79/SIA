using System;
using BO = DS.SAI.Business;


public partial class Produccion_Control : System.Web.UI.Page
{   
    protected void Page_Load(object sender, EventArgs e)
    {

        wndLabel.OpenerElementID = btnGuardar.ClientID;   
    }
}