using System;
using BO = DS.SAI.Business;


public partial class Produccion_Etapas : System.Web.UI.Page
{   
    protected void Page_Load(object sender, EventArgs e)
    {
        DataProducccion dp = new DataProducccion();
        var dt = dp.Data();
        txtCantidadLote.Text = dt.CantidadLote.ToString();
        txtCantidadPedido.Text = dt.CantidadPedido.ToString();
        txtHolgura.Text = dt.Holgura.ToString();
        txtNoPedido.Text = dt.CantidadPedido.ToString();
        txtReg_Int.Text = dt.Reg_Int;
        txtLote.Text = dt.Lote;
        ddlPartListExchangePartList.SelectedIndex = 21;
        
        switch (Request.QueryString["ex"])
        {
            case "1" :
                RadMultiPage1.SelectedIndex = 0;
                dtRecepcion.SelectedDate = dp.Fase1().Recepcion;
                break;
            case "2":
                RadMultiPage1.SelectedIndex = 1;
                dtRecepcion.SelectedDate = dp.Fase2().Recepcion;
                break;
            case "3":
                RadMultiPage1.SelectedIndex = 2;
                break;
        }
    }
}