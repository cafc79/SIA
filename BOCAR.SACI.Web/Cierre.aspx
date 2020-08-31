<%@ Page Title="Cierre de Tareas" Language="C#" MasterPageFile="~/RadMasterPage.master"
    AutoEventWireup="true" CodeFile="Cierre.aspx.cs" Inherits="Cierre" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 286px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
        <table style="border-width: thin; border-style: none; width: 100%; vertical-align: top;
            text-align: center; border: none">
            <tr>
                <td style="vertical-align: top; text-align: left; border-right-style: groove; border-right-width: 2px;"
                    width="190px">
                    <asp:Menu ID="menuSolicitud" runat="server" BackColor="#B5C7DE" Font-Names="Verdana"
                        Font-Size="XX-Small" ForeColor="#284E98" StaticSubMenuIndent="10px" Width="148px">
                        <StaticSelectedStyle BackColor="#BBC6BF" BorderColor="#9999FF" />
                        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
                        <DynamicMenuStyle BackColor="#B5C7DE" />
                        <DynamicSelectedStyle BackColor="#507CD1" />
                        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
                    </asp:Menu>
                </td>
                <td>
                    <fieldset>
                        <legend>Folio:<asp:Label ID="lblCurrentFolio" runat="server" ForeColor="#999999"></asp:Label></legend>
                        <table style="width: 100%; vertical-align: top; text-align: left;
                            border-style: none" align="center">
                            <tr>
                                <td style="width: 10%">
                                </td>
                                <td class="style1">
                                    <telerik:RadTextBox ID="txtSrchFolio" runat="server" Skin="WebBlue" Width="280px">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:ImageButton ID="imbSerach" runat="server" ImageUrl="~/Img/btn_search.gif" OnClick="imbSearch_Click" />
                                </td>
                                <td style="width: 10%">
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%; vertical-align: top; text-align: left;
                            border-style: none" align="center">
                            <tr>
                                <td style="width: 10%">
                                </td>
                                <td align="center">
                                    <telerik:RadGrid ID="gridFolio" runat="server" AllowPaging="True" CellSpacing="0" DataSourceID="sqlDS_Folio"
                                        OnItemCommand="gridFolio_ItemCommand" GridLines="None" Skin="WebBlue" AutoGenerateColumns="False">
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>
                                        <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                        <MasterTableView DataSourceID="sqlDS_Folio" DataKeyNames="IdFolio" Width="100%" AllowMultiColumnSorting="True">
                                            <Columns>
                                                <telerik:GridTemplateColumn UniqueName="TemplateColumn" AllowFiltering="false" HeaderText="">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibtnFolio" runat="server" ImageUrl="~/Img/msg-info.png" AlternateText="Folio"
                                                            CommandName="ReviewFolio" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="idFolio" HeaderText="IdFolio" ReadOnly="true"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Folio" HeaderText="Folio" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="CostoReal" HeaderText="Costo Real" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Fecha" HeaderText="Fecha" ReadOnly="true" DataFormatString="{0:d}">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Obs" HeaderText="Observaciones" ReadOnly="true">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Docs" HeaderText="Documentos" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="idLiberacion" HeaderText="IdLiberacion" ReadOnly="true"
                                                    DataFormatString="{0:d}" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                <HeaderStyle Width="20px" />
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                <HeaderStyle Width="20px" />
                                            </ExpandCollapseColumn>
                                            <EditFormSettings>
                                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                </EditColumn>
                                            </EditFormSettings>
                                        </MasterTableView>
                                        <HeaderStyle Font-Names="Verdana" Font-Size="X-Small" />
                                        <ItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                        <FilterMenu EnableImageSprites="False">
                                        </FilterMenu>
                                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                                <td style="width: 10%">
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <br />
                    <fieldset>
                        <table style="width: 100%; vertical-align: top; text-align: left;
                            border-style: none" align="center">
                            <tr>
                                <td style="width: 10%">
                                </td>
                                <td align="center">
                                    <asp:Panel ID="PanelEstatus" runat="server" Visible="false">
                                        <table>
                                            <tr>
                                                <td>
                                                    <label id="Label2">
                                                        Estatus:</label>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox AllowCustomText="true" MarkFirstMatch="true" ID="comboEstatus"
                                                        Skin="Web20" CssClass="Aniv" runat="server" Width="280px" EmptyMessage="Estatus a seleccionar"
                                                        OnSelectedIndexChanged="comboEstatus_SelectedIndexChanged" DataSourceID="sqlDSEstatus"
                                                        DataTextField="fvdescription" DataValueField="fiid_StatusRelease" AutoPostBack="True">
                                                    </telerik:RadComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <label id="Label3">
                                                        .</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label id="lblFechaLiberacion">
                                                        Fecha:</label>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtFecha" runat="server" Skin="WebBlue" Visible="false" Width="280px">
                                                    </telerik:RadTextBox>
                                                    <telerik:RadDatePicker ID="calFecha" runat="server" Visible="false" Width="280px">
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label id="lblObservaciones">
                                                        Observaciones:</label>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtObservacion" runat="server" Skin="WebBlue" Width="280px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label id="lblCostoReal">
                                                        Costo Real:</label>
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="txtCostoReal" runat="server" Skin="WebBlue" Width="280px">
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <telerik:RadButton ID="btnRelease" runat="server" OnClick="btnRelease_Click" Text="Cambiar Estatus"
                                            Skin="WebBlue" />
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <br />
                    <fieldset>
                        <legend>Documentos:</legend>
                        <table style="width: 100%; vertical-align: top; text-align: left;
                            border-style: none" align="center">
                            <tr>
                                <td style="width: 10%">
                                </td>
                                <td align="center">
                                    <asp:Panel ID="PanelDocumentos" runat="server" Visible="false">
                                        <table>
                                            <tr style="visibility:hidden">
                                                <td>
                                                    <label id="lblLiberacion">
                                                        Fecha:</label>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtFechaLiberacion" runat="server" Skin="WebBlue" Width="280px"
                                                        ReadOnly="true">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr style="visibility:hidden">
                                                <td>
                                                    <label id="lblEstatus">
                                                        Estatus:</label>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtEstatus" runat="server" Skin="WebBlue" Width="280px" ReadOnly="true">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label id="documento">
                                                        Etiqueta de Documento:</label>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtDescDocumento" runat="server" Skin="WebBlue" Width="280px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label id="Label1">
                                                        Documentos:</label>
                                                </td>
                                                <td>
                                                    <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" Skin="WebBlue" AutoAddFileInputs="False"
                                                        Width="280px" Culture="es-MX">
                                                    </telerik:RadAsyncUpload>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <telerik:RadButton ID="btnDocumentos" runat="server" OnClick="btnDocumentos_Click"
                                                        Text="Agregar" Skin="WebBlue" />
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <telerik:RadGrid ID="gridReporte" runat="server" AllowPaging="True" CellSpacing="0"
                                            OnItemCommand="gridReporte_ItemCommand" AutoGenerateColumns="False" GridLines="None"
                                            Skin="WebBlue" HorizontalAlign="Left">
                                            <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                            <MasterTableView>
                                                <Columns>
                                                    <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:Panel ID="Panel1" runat="server">
                                                                <asp:ImageButton ID="rbtnSelect" runat="server" AutoPostBack="true" ImageUrl="~/img/msg-refresh.jpg"
                                                                    CommandName="Download" />
                                                            </asp:Panel>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="fvlabel_file" HeaderText="Archivo" ReadOnly="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="fvaddress_file" HeaderText="Ruta" ReadOnly="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                    <HeaderStyle Width="20px" />
                                                </RowIndicatorColumn>
                                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                    <HeaderStyle Width="20px" />
                                                </ExpandCollapseColumn>
                                                <EditFormSettings>
                                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                    </EditColumn>
                                                </EditFormSettings>
                                            </MasterTableView>
                                            <FilterMenu EnableImageSprites="False"></FilterMenu>
                                            <HeaderStyle Font-Names="Verdana" Font-Size="X-Small" />
                                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Vista">
                                            </HeaderContextMenu>
                                        </telerik:RadGrid>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="sqlDS_Folio" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
            SelectCommand="sp_selectReleaseClientExchange" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtSrchFolio" DefaultValue="0" Name="strFolio" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sqlDSEstatus" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
            SelectCommand="SELECT fiid_StatusRelease, fvdescription FROM CATStatusRelease" />
    </telerik:RadAjaxPanel>
</asp:Content>
