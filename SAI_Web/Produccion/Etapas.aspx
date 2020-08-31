<%@ Page Title="" Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true"
    CodeFile="Etapas.aspx.cs" Inherits="Produccion_Etapas" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2
    {
        width: 15%;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnablePageHeadUpdate="False">
    </telerik:RadAjaxManager>
    <telerik:RadMultiPage ID="RadMultiPage1" runat="server">
        <telerik:RadPageView ID="RadPageView1" runat="server">
            <div id="step-holder">
        <div id="step1" class="step-no">1</div>
        <div class="step-dark-left"><a href="Etapas.aspx?ex=1">Corte y Doblado</a></div><div class="step-dark-right">&nbsp;</div>
        <div id="step2" class="step-no-off">2</div>
        <div class="step-light-left"><a href="Etapas.aspx?ex=2">Acabado</a></div><div class="step-light-right">&nbsp;</div>
        <div id="step3" class="step-no-off">3</div>
        <div class="step-light-left"><a href="Etapas.aspx?ex=3">Calidad</a></div><div class="step-light-round">&nbsp;</div>
        <div class="clear"></div>
    </div>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView2" runat="server">
            <div id="Div1">
            <div id="Div2" class="step-no-off">1</div>
            <div class="step-light-left"><a href="Etapas.aspx?ex=1">Corte y Doblado</a></div><div class="step-dark-right">&nbsp;</div>
            <div id="Div4" class="step-no">2</div>
            <div class="step-dark-left"><a href="Etapas.aspx?ex=2">Acabado</a></div><div class="step-light-right">&nbsp;</div>
            <div id="Div5" class="step-no-off">3</div>
            <div class="step-light-left"><a href="Etapas.aspx?ex=3">Calidad</a></div><div class="step-light-round">&nbsp;</div>
            <div class="clear"></div>
            </div>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView3" runat="server">
            <div id="Div3">
            <div id="Div6" class="step-no-off">1</div>
            <div class="step-light-left"><a href="Etapas.aspx?ex=1">Corte y Doblado</a></div><div class="step-dark-right">&nbsp;</div>
            <div id="Div7" class="step-no-off">2</div>
            <div class="step-light-left"><a href="Etapas.aspx?ex=2">Acabado</a></div><div class="step-light-right">&nbsp;</div>
            <div id="Div8" class="step-no">3</div>
            <div class="step-dark-left"><a href="Etapas.aspx?ex=3">Calidad</a></div><div class="step-light-round">&nbsp;</div>
            <div class="clear"></div>
            </div>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
    <!--  end step-holder -->
    <table style="border-width: thin; border-style: none; width: 100%; vertical-align: top;
        text-align: center;">
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
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
                            <telerik:RadTextBox ID="txtComments" runat="server" Width="160px" Rows="4" 
                                TextMode="MultiLine">
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
                                    
                            <telerik:RadDateTimePicker ID="dtRecepcion" Runat="server" Skin="Metro">
                                <TimeView CellSpacing="-1" Culture="es-MX">
                                </TimeView>
                                <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                <Calendar Skin="Metro" UseColumnHeadersAsSelectors="False" 
                                    UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" 
                                    EnableSingleInputRendering="True" LabelWidth="64px">
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
            </td>
        </tr>
        <tr>
            <td width="100%">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300" Visible="False"></asp:Label>
                <br />
                <asp:Label ID="lblIdEntity" runat="server" Text="" Visible="False"></asp:Label>
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
    </script>
</asp:Content>
