﻿<%@ Page Title="" Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true"
    CodeFile="Control.aspx.cs" Inherits="Produccion_Control" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnablePageHeadUpdate="False">
    </telerik:RadAjaxManager>
    <div id="step-holder">
        <div class="step-no">
            1</div>
        <div class="step-dark-left">
            <a href="Control.aspx">Inicio de Producción</a></div>
        <div class="step-dark-right">
            &nbsp;</div>
        <div class="step-no-off">
            2</div>
        <div class="step-light-left">
            <a href="Etapas.aspx?ex=1">Proceso Productivo</a></div>
        <div class="step-light-right">
            &nbsp;</div>
        <div class="step-no-off">
            3</div>
        <div class="step-light-left">
            <a href="../Auditoria/Calidad.aspx">Calidad y Embarque</a></div>
        <div class="step-light-round">
            &nbsp;</div>
        <div class="clear">
        </div>
    </div>
    <table style="border-width: thin; border-style: none; width: 100%; vertical-align: top;
        text-align: center;">
        <tr>
            <td height="30px">
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td style="width: 15%">
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
                        <td>
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
                        <td>
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
                        <td>
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
                        <td>
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
                        <td>
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
                        <td>
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
                        <td>
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
                        <td>
                        </td>
                        <td align="right">
                            <br />
                        </td>
                        <td>
                        </td>
                        <td align="left">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="right">
                            <telerik:RadButton ID="btnCancel" runat="server" Skin="Vista" Text="Cancelar">
                            </telerik:RadButton>
                        </td>
                        <td>
                        </td>
                        <td align="left">
                            <telerik:RadButton ID="btnGuardar" runat="server" Skin="Vista" Text="Guardar">
                            </telerik:RadButton>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300" Visible="False"></asp:Label>
                <telerik:RadWindowManager ID="owManager" runat="server" Skin="Telerik">
                    <Windows>
                        <telerik:RadWindow runat="server" ID="wndLabel" Skin="Metro" Modal="true" VisibleOnPageLoad="False"
                            Behaviors="Resize, Close" Height="400px" Width="650px" EnableEmbeddedScripts="True"
                            RegisterWithScriptManager="True" ShowContentDuringLoad="False" NavigateUrl="EtiquetaFase.aspx?ex=5"
                            VisibleStatusbar="False" Animation="FlyIn" EnableShadow="True">
                        </telerik:RadWindow>
                    </Windows>
                </telerik:RadWindowManager>
                <br />
                <asp:Label ID="lblIdEntity" runat="server" Text="0" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $('#<%=btnGuardar.ClientID%>').click(function (e) {
            //window.open('EtiquetaFase.aspx?id=1', 'Etiqueta', 'with=500px, height=300px');
            //e.preventDefault();
            $('#<%=txtReg_Int.ClientID%>').val('');
            $('#<%=txtLote.ClientID%>').val('');
            $('#<%=txtCantidadLote.ClientID%>').val('');
            $('#<%=txtHolgura.ClientID%>').val('');
            $('#<%=txtNoPedido.ClientID%>').val('');
            $('#<%=txtCantidadPedido.ClientID%>').val('');
            return false;
        });

        //        function abrirEtiqueta() {
        //            window.open('EtiquetaFase.aspx?id=1', 'Etiqueta', 'with=600px;height=400px;');
        //            return false;
        //        }
        
    </script>
</asp:Content>
