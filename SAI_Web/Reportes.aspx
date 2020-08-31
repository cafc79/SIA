<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true"
    CodeFile="Reportes.aspx.cs" Inherits="Reportes" EnableEventValidation="false" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2012.1.215.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function onRequestStart(sender, args) {
            if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToWordButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToCsvButton") >= 0) {
                args.set_enableAjax(false);
            }
            if (args.get_eventTarget().indexOf("DownloadPDF") > 0)
                args.set_enableAjax(false);
        }       
    </script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <clientevents onrequeststart="onRequestStart" />
        <ajaxsettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </ajaxsettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" AnimationDuration="10"
        EnableEmbeddedScripts="False" Skin="Web20" Transparency="25">
    </telerik:RadAjaxLoadingPanel>
    <div class="deneb">
        <fieldset>
            <legend>Exportar Datos:</legend>
            <div id="bmx" class="deneb">
                <table>
                    <tr>
                        <td colspan="4">
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="Exportar solo datos" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:CheckBox ID="CheckBox2" runat="server" Text="Exportar todas las paginas" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <table>
                                <tr>
                                    <td>
                                        <img alt="" src="Img/format_xlsx.png" />
                                        <telerik:RadButton ID="RadButton1" runat="server" ButtonType="ToggleButton" EnableBrowserButtonStyle="True"
                                            OnClick="Button1_Click" Skin="Sitefinity" Text="Exportar a Excel" Width="120px">
                                        </telerik:RadButton>
                                    </td>
                                    <tr>
                                        <td>
                                            <img alt="" src="Img/format_docx_mac.png" />
                                            <telerik:RadButton ID="RadButton2" runat="server" ButtonType="ToggleButton" OnClick="Button2_Click"
                                                Skin="Default" Text="Exportar a Word" Width="120px">
                                            </telerik:RadButton>
                                        </td>
                                        <tr>
                                            <td>
                                                <img alt="" src="Img/format_text.png" />
                                                <telerik:RadButton ID="RadButton3" runat="server" ButtonType="ToggleButton" OnClick="Button3_Click"
                                                    Skin="Default" Text="Exportar a CSV" Width="120px">
                                                </telerik:RadButton>
                                            </td>
                                            <tr>
                                                <td>
                                                    <img alt="" src="Img/format_pdf.png" />
                                                    <telerik:RadButton ID="RadButton4" runat="server" ButtonType="ToggleButton" OnClick="Button4_Click"
                                                        Skin="Default" Text="Exportar a PDF" Width="120px">
                                                    </telerik:RadButton>
                                                </td>
                                            </tr>
                                        </tr>
                                    </tr>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>
    <div class="deneb">
        <telerik:RadMultiPage ID="rmpBusqueda" runat="server" RenderSelectedPageOnly="True"
            Width="600">
            <telerik:RadPageView ID="Pageview1" runat="server">
                <div id="box">
                    <table style="vertical-align: top; border-style: none" width="100%">
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" Text="Área"></asp:Label>
                            </td>
                            <td align="left">
                                <telerik:RadComboBox ID="ddlOpArea" runat="server" DataSourceID="sqlDSArea" DataTextField="sDescription"
                                    DataValueField="iIdArea" Skin="Web20">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" Text="Folio"></asp:Label>
                            </td>
                            <td align="left">
                                <telerik:RadTextBox ID="txtOpFolio" runat="server" Width="160px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" Text="PreFolio"></asp:Label>
                            </td>
                            <td align="left">
                                <telerik:RadTextBox ID="txtOpPrefolio" runat="server" Width="160px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" Text="Fecha Inicial"></asp:Label>
                            </td>
                            <td align="left">
                                <telerik:RadDatePicker ID="dtOpR1" runat="server" Skin="Web20">
                                    <Calendar Skin="Web20" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy">
                                    </DateInput>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label5" runat="server" Text="Fecha Final"></asp:Label>
                            </td>
                            <td align="left">
                                <telerik:RadDatePicker ID="dtOpR2" runat="server" Skin="Web20">
                                    <Calendar Skin="Web20" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy">
                                    </DateInput>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <telerik:RadButton ID="btnBusqueda_v1" runat="server" OnClick="btnBusqueda_v1_Click"
                                    Skin="Web20" Text="Busqueda">
                                </telerik:RadButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="Pageview2" runat="server">
                <div>
                    <table style="vertical-align: top; border-style: none" width="100%">
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label6" runat="server" Text="Cliente"></asp:Label>
                            </td>
                            <td align="left">
                                <telerik:RadComboBox ID="ddlCliente" runat="server" DataSourceID="sqlDSClient" DataTextField="sDescription"
                                    DataValueField="iIdClient" Skin="Web20" Width="300">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label9" runat="server" Text="Fecha Inicial"></asp:Label>
                            </td>
                            <td align="left">
                                <telerik:RadDatePicker ID="RadDatePicker1" runat="server" Skin="Web20">
                                    <Calendar Skin="Web20" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy">
                                    </DateInput>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label10" runat="server" Text="Fecha Final"></asp:Label>
                            </td>
                            <td align="left">
                                <telerik:RadDatePicker ID="RadDatePicker2" runat="server" Skin="Web20">
                                    <Calendar Skin="Web20" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy">
                                    </DateInput>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <telerik:RadButton ID="btnBusqueda_v2" runat="server" OnClick="btnBusqueda_v2_Click"
                                    Skin="Web20" Text="Busqueda">
                                </telerik:RadButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
    <br />
    <div class="deneb">
        <telerik:RadMultiPage ID="rmpDatos" runat="server" RenderSelectedPageOnly="True">
            <telerik:RadPageView ID="RadPageView1" runat="server">
                <telerik:RadGrid ID="repOperArea" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnItemCommand="grid_ItemCommand"
                    ShowGroupPanel="True" Skin="Transparent">
                    <ClientSettings AllowDragToGroup="True">
                    </ClientSettings>
                    <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="IdTarea" HeaderText="Id" ReadOnly="true" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="IdArea" HeaderText="Id" ReadOnly="true" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Tarea" HeaderText="Tarea" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Folio" HeaderText="Folio" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PreFolio" HeaderText="PreFolio" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Area" HeaderText="Area" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Timing" HeaderText="Timming" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Dato" HeaderText="Dato" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FechaOperativa" HeaderText="Fecha Operativa"
                                ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                        </Columns>
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
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView2" runat="server">
                <telerik:RadGrid ID="repEjecCostos" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnItemCommand="grid_ItemCommand"
                    ShowGroupPanel="True" Skin="Transparent">
                    <ClientSettings AllowDragToGroup="True">
                    </ClientSettings>
                    <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="IdFolio" HeaderText="Id" ReadOnly="true" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="IdTareaExchange" HeaderText="Id" ReadOnly="true"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Folio" HeaderText="Folio" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PreFolio" HeaderText="PreFolio" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Tarea" HeaderText="Tarea" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="fvtiming_task_Exchange" HeaderText="Timming"
                                ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SumaTiming" HeaderText="Timming Acumulado" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Porcentaje" HeaderText="Porcentaje" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FechaVencimiento" HeaderText="Fecha Vencimiento"
                                ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FechaTermino" HeaderText="Fecha de Termino" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                        </Columns>
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
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView3" runat="server">
                <telerik:RadGrid ID="repEjecTiempos" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnItemCommand="grid_ItemCommand"
                    ShowGroupPanel="True" Skin="Transparent">
                    <ClientSettings AllowDragToGroup="True">
                    </ClientSettings>
                    <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="IdFolio" HeaderText="Id" ReadOnly="true" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="IdTareaExchange" HeaderText="Id" ReadOnly="true"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FechaOperativa" HeaderText="Fecha Operativa"
                                ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="fvnumber_part_DS" HeaderText="Num Parte" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="fvnumber_part_client" HeaderText="Num Parte Cliente"
                                ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="fvaffectation_part" HeaderText="Afectacion" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="MoldePrototip" HeaderText="Molde Prototip" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="MoldeSerie" HeaderText="Molde Serie" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CF" HeaderText="CF" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DispositivoEnsamble" HeaderText="Dispositivo Ensamble"
                                ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Obsoletos" HeaderText="Obsoletos" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="AdmIng" HeaderText="Ingeniero Admon" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Diseno" HeaderText="Diseño" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Componentes" HeaderText="Componentes" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="OtrosCap" HeaderText="Otros" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Pintura" HeaderText="Pintura" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Empaque" HeaderText="Empaque" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Banco" HeaderText="Banco" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="OtrosCat" HeaderText="Otros Catalogos" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Delta1" HeaderText="Delta 1" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Delta2" HeaderText="Delta 2" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SUMA" HeaderText="Suma" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CostoReal" HeaderText="Costo Real" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TOTALFact" HeaderText="Total" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                        </Columns>
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
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView4" runat="server">
                <telerik:RadGrid ID="repEjecClientes" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnItemCommand="grid_ItemCommand"
                    ShowGroupPanel="True" Skin="Transparent">
                    <ClientSettings AllowDragToGroup="True">
                    </ClientSettings>
                    <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="fiid_client" HeaderText="Id" ReadOnly="true"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NumAvisosDeCambios" HeaderText="Avisos de Cambio"
                                ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Porcentaje" HeaderText="Porcentaje" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                        </Columns>
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
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView5" runat="server">
                <telerik:RadGrid ID="repAudiPinterno" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnItemCommand="grid_ItemCommand"
                    ShowGroupPanel="True" Skin="Transparent">
                    <ClientSettings AllowDragToGroup="True">
                    </ClientSettings>
                    <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="IdFolio" HeaderText="Id" ReadOnly="true" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="IdRevisionIng" HeaderText="Id" ReadOnly="true"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Folio" HeaderText="Folio" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PreFolio" HeaderText="PreFolio" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="numParteInterna" HeaderText="Num Parte" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="numParteCliente" HeaderText="Num Parte Cliente"
                                ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DescAltaAviso" HeaderText="Descripción" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Problema" HeaderText="Problema" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Motivo" HeaderText="Motivo" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Accion" HeaderText="Acción" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Contacto" HeaderText="Contacto" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RevisionIng" HeaderText="Revisión" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FechaOperativa" HeaderText="Fecha Operativa"
                                ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                        </Columns>
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
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    <asp:SqlDataSource ID="sqlDSArea" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectArea" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSClient" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectClient" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSPartList" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectPartList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
