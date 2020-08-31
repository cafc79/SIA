<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Produccion.aspx.cs" Inherits="Mobile_Produccion" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2012.1.215.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/main.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Styles/bootstrap.min.css" media="screen" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-1.7.1.min.js"></script>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <table class="table">
            <tr>
                <td class="style2">
                </td>
                <td align="right" style="width: 29%">
                </td>
                <td>
                </td>
                <td align="left" style="width: 29%">
                </td>
                <td style="width: 25%">
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td align="right">
                    <asp:Label ID="lblReg_Int" runat="server" Text="Registro:"></asp:Label>
                </td>
                <td>
                </td>
                <td align="left">
                    <telerik:RadTextBox ID="txtReg_Int" runat="server" Width="160px">
                    </telerik:RadTextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td align="right">
                    <asp:Label ID="lblLote" runat="server" Text="Lote:"></asp:Label>
                </td>
                <td>
                </td>
                <td align="left">
                    <telerik:RadTextBox ID="txtLote" runat="server" Width="160px">
                    </telerik:RadTextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td align="right">
                    <asp:Label ID="Label1" runat="server" Text="Cantidad Lote:"></asp:Label>
                </td>
                <td>
                </td>
                <td align="left">
                    <telerik:RadTextBox ID="txtCantidadLote" runat="server" Width="160px">
                    </telerik:RadTextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td align="right">
                    <asp:Label ID="lblHolgura" runat="server" Text="Holgura:"></asp:Label>
                </td>
                <td>
                </td>
                <td align="left">
                    <telerik:RadTextBox ID="txtHolgura" runat="server" Width="160px">
                    </telerik:RadTextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td align="right">
                    <asp:Label ID="lblNoParte" runat="server" Text="No. Parte:"></asp:Label>
                </td>
                <td>
                </td>
                <td align="left">
                    <telerik:RadComboBox ID="ddlPartListExchangePartList" runat="server" DataSourceID="sqlDSddlPartList"
                        DataTextField="sDesc1" DataValueField="iIdPart" Width="300px" AutoPostBack="True"
                        EnableVirtualScrolling="True" Skin="Metro" AllowCustomText="True" MarkFirstMatch="True">
                    </telerik:RadComboBox>
                    <asp:SqlDataSource ID="sqlDSddlPartList" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
                        SelectCommand="sp_selectddlPartList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td align="right">
                    <asp:Label ID="lblNoPerdido" runat="server" Text="No. Pedido:"></asp:Label>
                </td>
                <td>
                </td>
                <td align="left">
                    <telerik:RadTextBox ID="txtNoPedido" runat="server" Width="160px">
                    </telerik:RadTextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td align="right">
                    <asp:Label ID="lblCantidadPedido" runat="server" Text="Cantidad Pedido:"></asp:Label>
                </td>
                <td>
                </td>
                <td align="left">
                    <telerik:RadTextBox ID="txtCantidadPedido" runat="server" Width="160px">
                    </telerik:RadTextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Text="Comentarios:"></asp:Label>
                </td>
                <td>
                </td>
                <td align="left">
                    <telerik:RadTextBox ID="txtComments" runat="server" Width="160px" Rows="4" TextMode="MultiLine">
                    </telerik:RadTextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td align="right">
                    <asp:Label ID="Label3" runat="server" Text="Recepcion:"></asp:Label>
                </td>
                <td>
                </td>
                <td align="left">
                    <telerik:RadDateTimePicker ID="dtRecepcion" runat="server" Skin="Metro">
                        <TimeView CellSpacing="-1" Culture="es-MX">
                        </TimeView>
                        <TimePopupButton HoverImageUrl="" ImageUrl="" />
                        <Calendar Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                            ViewSelectorText="x">
                        </Calendar>
                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" EnableSingleInputRendering="True"
                            LabelWidth="64px">
                        </DateInput>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDateTimePicker>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td align="right">
                    <telerik:RadButton ID="btnCancel" runat="server" Skin="Metro" Text="Cancelar">
                    </telerik:RadButton>
                </td>
                <td>
                </td>
                <td align="left">
                    <telerik:RadButton ID="btnGuardar" runat="server" Skin="Metro" Text="Liberar Etapa">
                    </telerik:RadButton>
                </td>
                <td>
                </td>
            </tr>
        </table>
        </form>
    </div>
</body>
</html>
