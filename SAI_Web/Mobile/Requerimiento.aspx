<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Requerimiento.aspx.cs"
    Inherits="Mobile_Requerimiento" %>

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
<body style="margin-top: auto">
    <div class="container">
        <form id="form1" runat="server" style="margin-top: auto">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <table width="100%" style="vertical-align: top; text-align: left; border-style: none">
            <tr>
                <td width="90px">
                    <asp:Label ID="lblExchangeType" runat="server" Text="Tipo de Cambio:" Font-Bold="True"
                        Font-Size="X-Small"></asp:Label>
                </td>
                <td width="180px">
                    <telerik:RadTextBox ID="ddlExchange" runat="server" Width="160px" Font-Size="X-Small">
                    </telerik:RadTextBox>
                </td>
                <td width="10">
                </td>
                <td width="90px">
                    <asp:Label ID="lblPriority" runat="server" Text="Prioridad:" Font-Bold="True" Font-Size="X-Small"></asp:Label>
                </td>
                <td width="180px">
                    <telerik:RadTextBox ID="ddlPriority" runat="server" Width="160px" Font-Size="X-Small">
                    </telerik:RadTextBox>
                </td>
                <td width="10px">
                </td>
                <td width="90px">
                    <asp:Label ID="lblSerie" runat="server" Text="Tipo:" Font-Bold="True" Font-Size="X-Small"></asp:Label>
                </td>
                <td width="180">
                    <telerik:RadTextBox ID="ddlSerie" runat="server" Width="160px" Font-Size="X-Small">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPlant" runat="server" Text="Planta:" Font-Bold="True" Font-Size="X-Small"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="ddlPlant" runat="server" Width="160px" Font-Size="X-Small">
                    </telerik:RadTextBox>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblClient" runat="server" Text="Cliente:" Font-Bold="True" Font-Size="X-Small"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="ddlClient" runat="server" Width="160px" Font-Size="X-Small">
                    </telerik:RadTextBox>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblLastFolio" runat="server" Text="Folio Anterior:" Font-Bold="True"
                        Font-Size="X-Small"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtLastFolio" runat="server" MaxLength="20" Width="150px"
                        ReadOnly="true" Font-Size="X-Small">
                    </telerik:RadTextBox>
                </td>
            </tr>
        </table>
        <table class="table">
            <tr valign="top">
                <td width="90px">
                    <asp:Label ID="lblLimitDate" runat="server" Text="Fecha Limite Cotización:" Font-Bold="True"
                        Font-Size="X-Small"></asp:Label>
                </td>
                <td width="390px">
                    <telerik:RadTextBox ID="txtLimitDate" runat="server" Enabled="False" MaxLength="10"
                        Width="150px" ReadOnly="true">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProyectPlatDes" runat="server" Text="Proyecto/Plataforma" Font-Bold="True"
                        Font-Size="X-Small"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtProyectPlataformDescription" runat="server" MaxLength="50"
                        Width="90%" ReadOnly="true">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr valign="top">
                <td>
                    <asp:Label ID="lblDescription" runat="server" Text="Descripción:" Font-Bold="True"
                        Font-Size="X-Small"></asp:Label>
                </td>
                <td valign="top">
                    <telerik:RadTextBox ID="txtDescription" runat="server" MaxLength="250" TextMode="MultiLine"
                        Width="90%" ReadOnly="true" Skin="Web20">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr valign="top">
                <td>
                    <asp:Label ID="lblIssue" runat="server" Text="Problema" Font-Bold="True" Font-Size="X-Small"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtIssue" runat="server" MaxLength="250" TextMode="MultiLine"
                        Width="90%" ReadOnly="true" Skin="Web20">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr valign="top">
                <td>
                    <asp:Label ID="lblReason" runat="server" Text="Motivo" Font-Bold="True" Font-Size="X-Small"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtReason" runat="server" MaxLength="250" TextMode="MultiLine"
                        Width="90%" ReadOnly="true" Skin="Web20">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr valign="top">
                <td>
                    <asp:Label ID="lblAction" runat="server" Text="Acción:" Font-Bold="True" Font-Size="X-Small"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtAction" runat="server" MaxLength="250" TextMode="MultiLine"
                        Width="90%" ReadOnly="true" Skin="Web20">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr valign="top" style="height: 26px">
                <td>
                    <asp:Label ID="lblEngeneer" runat="server" Text="Ingeniero de producto" Font-Bold="True"
                        Font-Size="X-Small"></asp:Label>
                </td>
                <td valign="top">
                    <telerik:RadTextBox ID="ddlEngeenerProduct" runat="server" Width="90%" Skin="Web20">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr valign="top">
                <td>
                    <asp:Label ID="lblContact" runat="server" Text="Contacto del Cliente" Font-Bold="True"
                        Font-Size="X-Small"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtContact" runat="server" Width="90%" ReadOnly="true" Skin="Web20">
                    </telerik:RadTextBox>
                </td>
            </tr>
        </table>
        </form>
    </div>
</body>
</html>
