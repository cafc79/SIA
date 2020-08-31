<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EtiquetaFase.aspx.cs" Inherits="Produccion_EtiquetaFase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2012.1.215.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>
<html lang="en">
<head id="Head1" runat="server">
    <title>SAI DS</title>
    <link href="../Styles/main.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Styles/bootstrap.min.css" media="screen" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-1.7.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <table class="table-bordered" style="width: 650px; height: 400px">
            <tr >
                <td colspan="2">
                    No Parte:
                    <asp:Label ID="lblParte" runat="server" Text="Label"></asp:Label>
                    <br />
                    <telerik:RadBinaryImage ID="codePart" runat="server" />
                </td>
            </tr>
            <tr>
                <td rowspan="2" style="width: 30%">
                    <telerik:RadBinaryImage ID="codeStage" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblDescripcion" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLote" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 30%">
                    <telerik:RadBinaryImage ID="codeQuantity" runat="server" />
                    <br/>
                    <asp:Label ID="lblCantidad" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSerie" runat="server" Text="Label"></asp:Label>
                    <br/>
                    <telerik:RadBinaryImage ID="codeSerial" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <asp:SqlDataSource ID="sqlDSPartListExchange" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_SelectPartListExchangeById" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="fiid_Exchange" QueryStringField="ex"
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
