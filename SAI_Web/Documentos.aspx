<%@ Page Title="" Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true"
    CodeFile="Documentos.aspx.cs" Inherits="Documentos" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2012.1.215.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadMultiPage ID="RadMultiPage1" runat="server">
        <telerik:RadPageView ID="pageExchange" runat="server">
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                <table style="vertical-align: top; text-align: center; border-style: none" width="100%">
                    <tr>
                        <td width="80%">
                            <table style="vertical-align: top; border-style: none" width="100%">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label2" runat="server" Text="PreFolio"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <telerik:RadTextBox ID="txtOpPreFolio" runat="server" Width="160px">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" Text="Folio"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <telerik:RadTextBox ID="txtOpFolio" runat="server" Width="160px">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblClient" runat="server" Text="Cliente:"></asp:Label>
                                    </td>
                                    <td>
                                        <table style="vertical-align: top; text-align: center; border-style: none" width="100%">
                                            <tr>
                                                <td width="160px">
                                                    <telerik:RadComboBox ID="ddlClient" runat="server" DataSourceID="sqlDSClient" DataTextField="sDescription"
                                                        DataValueField="iIdClient" Enabled="false" Skin="Vista" Width="160px">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td align="left">
                                                    <asp:CheckBox ID="cbActivate" runat="server" AutoPostBack="true" OnCheckedChanged="cbActivate_CheckedChanged" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label4" runat="server" Text="Fecha Inicial"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <telerik:RadDatePicker ID="dtOpR1" runat="server" OnSelectedDateChanged="dtOpR1_SelectedDateChanged"
                                            Skin="Web20">
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
                                        <telerik:RadDatePicker ID="dtOpR2" runat="server" Enabled="False" Skin="Web20">
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
                        </td>
                    </tr>
                    <tr>
                        <td width="80%">
                            <telerik:RadGrid ID="gvExchange" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CellPadding="4" CellSpacing="0" DataKeyNames="fiid_Exchange"
                                Font-Size="XX-Small" GridLines="None" OnPageIndexChanged="gvExchange_PageIndexChanged"
                                Skin="Transparent">
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                <MasterTableView>
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imbSelectExchange" runat="server" CausesValidation="false" CommandArgument='<%# Bind("fiid_Exchange") %>'
                                                    ImageUrl="~/Img/Acrobat.png" OnClick="imgPdf_Click" Width="24" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="fiid_Exchange" ReadOnly="true" Visible="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fiid_client" ReadOnly="true" Visible="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fiid_plant" ReadOnly="true" Visible="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fvprefolio_exchange" HeaderText="PreFolio" ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fvfolio_exchange" HeaderText="Folio" ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fvdescription_Exchange" HeaderText="Descripción"
                                            ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fvdescription_client" HeaderText="Cliente" ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fvdescription_plant" HeaderText="Planta" ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
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
                        </td>
                    </tr>
                </table>
            </telerik:RadAjaxPanel>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView1" runat="server">
            <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server">
                <table style="vertical-align: top; text-align: center; border-style: none" width="100%">
                    <tr>
                        <td>
                            <table style="vertical-align: top; border-style: none" width="100%">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label3" runat="server" Text="PreFolio"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <telerik:RadTextBox ID="txtPreFolio" runat="server" Width="160px">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label6" runat="server" Text="Folio"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <telerik:RadTextBox ID="txtFolio" runat="server" Width="160px">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <telerik:RadWindowManager ID="owManager" runat="server" Skin="Telerik">
                                            <Windows>
                                                <telerik:RadWindow ID="wndRequerimiento" runat="server" Animation="FlyIn" Behaviors="Resize, Close"
                                                    EnableEmbeddedScripts="True" EnableShadow="True" Height="510px" Modal="true"
                                                    RegisterWithScriptManager="True" ShowContentDuringLoad="False" Skin="Web20" VisibleOnPageLoad="False"
                                                    VisibleStatusbar="False" Width="680px">
                                                </telerik:RadWindow>
                                            </Windows>
                                        </telerik:RadWindowManager>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <telerik:RadButton ID="btnDocumentos" runat="server" Skin="Web20" Text="Busqueda"
                                            OnClick="btnDocumentos_Click">
                                        </telerik:RadButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadGrid ID="gvRequerimientos" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CellPadding="4" CellSpacing="0" DataKeyNames="fiid_Exchange"
                                Font-Size="XX-Small" GridLines="None" Skin="Transparent" OnItemCommand="gvRequerimientos_ItemCommand">
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                <MasterTableView>
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imbSelectExchange" runat="server" CausesValidation="false" CommandArgument='<%# Bind("fiid_Exchange") %>'
                                                    ImageUrl="~/Img/msg-info.png" OnClick="imgDetail_Click" Width="24" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="fiid_Exchange" ReadOnly="true" Visible="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fiid_client" ReadOnly="true" Visible="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fiid_plant" ReadOnly="true" Visible="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fvprefolio_exchange" HeaderText="PreFolio" ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fvfolio_exchange" HeaderText="Folio" ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fvdescription_client" HeaderText="Cliente" ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fvdescription_plant" HeaderText="Planta" ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fvdescription_Exchange" HeaderText="Descripción"
                                            ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
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
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadGrid ID="gridReporte" runat="server" AllowPaging="True" CellSpacing="0"
                                OnItemCommand="gridReporte_ItemCommand" AutoGenerateColumns="False" GridLines="None"
                                Skin="Transparent" HorizontalAlign="Left">
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
                                        <telerik:GridBoundColumn DataField="Exchange" HeaderText="" ReadOnly="true" Visible="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Etiqueta" HeaderText="Etiqueta" ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Ruta" HeaderText="Ruta" ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
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
                                <ItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                                <HeaderStyle Font-Names="Verdana" Font-Size="X-Small" />
                                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Vista">
                                </HeaderContextMenu>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </telerik:RadAjaxPanel>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
    <asp:SqlDataSource ID="sqlDSClient" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectClient" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSExchange" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectExchange_RepDocumentos" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtPreFolio" Name="fvPrefolio" PropertyName="Text"
                Type="string" />
            <asp:ControlParameter ControlID="txtFolio" Name="fvFolio" PropertyName="Text" Type="string" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
