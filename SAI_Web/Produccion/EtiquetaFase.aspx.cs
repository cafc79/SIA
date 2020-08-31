using System;
using DS.SAI.Business;

public partial class Produccion_EtiquetaFase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Encoded();
    }

    private void Encoded ()
    {
        BarcodeManager hm = new BarcodeManager();
        DeltaCore.WorkFlow.SecurityManager sm = new DeltaCore.WorkFlow.SecurityManager();
        var datos = new PartListExchangeManager();
        var data = datos.sqlDSPartListExchange(Request.QueryString["ex"]);
        if (data != null && data.Rows.Count > 0)
        {
            var buffer = hm.imageToByteArray(hm.QREncode(Request.Url.AbsolutePath, "M"));
            codeStage.DataValue = buffer;
            lblParte.Text = data.Rows[0]["sPartListBocar"].ToString();
            lblDescripcion.Text = data.Rows[0]["sPartListDescription"].ToString() + " \n " + data.Rows[0]["fvmeasure_exchange"].ToString();
            codePart.DataValue = hm.imageToByteArray(hm.Barcode128(data.Rows[0]["sPartListBocar"].ToString(), 1));
            lblCantidad.Text = data.Rows[0]["iIdPartList"].ToString();
            codeQuantity.DataValue = hm.imageToByteArray(hm.Barcode128(data.Rows[0]["iIdPartList"].ToString(), 1));
            if (string.IsNullOrEmpty(data.Rows[0]["sFolio"].ToString()) || data.Rows[0]["sFolio"].ToString() == "0")
            {
                codeSerial.DataValue = hm.imageToByteArray(hm.Barcode128(data.Rows[0]["sFolio"].ToString(), 1));
                lblSerie.Text = data.Rows[0]["sFolio"].ToString();
            }   
            else
            {
                lblSerie.Text = data.Rows[0]["sPreFolio"].ToString();
                codeSerial.DataValue = hm.imageToByteArray(hm.Barcode128(data.Rows[0]["sPreFolio"].ToString(), 1));
            }   
        }
    }
}