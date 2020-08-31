using System;

public partial class Mobile_Stage : System.Web.UI.Page
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
    }
}