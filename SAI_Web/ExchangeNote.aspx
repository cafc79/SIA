<%@ Page Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true"
    CodeFile="ExchangeNote.aspx.cs" Inherits="ExchangeNote" Title="Aviso de Cambio" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2012.1.215.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="border-width: thin; border-style: none; width: 100%; vertical-align: top;
        text-align: center;">
        <tr>
            <td height="30px">
                <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="#4B4B4B">Aviso de Cambio</asp:Label>
                <br />
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnSearch" runat="server">
                    <table width="100%" style="vertical-align: top; text-align: center; border-style: none">
                        <tr>
                            <td height="15px">
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblTitleSerch" runat="server" Text="Búsqueda:"></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td width="30%">
                            </td>
                            <td align="right">
                                <asp:Label ID="lblFolio" runat="server" Text="Folio: "></asp:Label>
                            </td>
                            <td width="260px">
                                <telerik:RadTextBox Skin="Transparent" ID="txtSrchPreFol" runat="server" Width="250px">
                                </telerik:RadTextBox>
                            </td>
                            <td align="left">
                                <asp:ImageButton ID="imbSerach" runat="server" ImageUrl="~/Img/btn_search.gif" OnClick="imbSerach_Click" />
                            </td>
                            <td width="30%" align="left">
                                <asp:ImageButton ID="imbEchangeAdd" runat="server" OnClick="imbEchangeAdd_Click"
                                    ImageUrl="~/Img/add.png" />
                            </td>
                        </tr>
                    </table>
                    <table width="100%" style="vertical-align: top; text-align: center; border-style: none">
                        <tr>
                            <td width="80%" align="center">
                                <telerik:RadGrid ID="gvExchange" runat="server" CellPadding="4" AllowPaging="True"
                                    DataSourceID="sqlDS" AllowSorting="True" AutoGenerateColumns="False" Font-Size="XX-Small"
                                    CellSpacing="0" GridLines="None" Skin="Transparent">
                                    <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
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
                                                        ImageUrl="~/Img/select.png" OnClick="imbSelectExchange_Click" ToolTip="Modificar registro" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn ReadOnly="true" Visible="false" DataField="fiid_Exchange">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn ReadOnly="true" Visible="false" DataField="fiid_client">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn ReadOnly="true" Visible="false" DataField="fiid_plant">
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
                    <telerik:RadWindowManager ID="owManager" runat="server" Skin="Telerik">
                        <Windows>
                            <telerik:RadWindow runat="server" ID="wndRequerimiento" Skin="Web20" Modal="true"
                                VisibleOnPageLoad="False" Behaviors="Resize, Close" Height="510px" Width="680px"
                                EnableEmbeddedScripts="True" RegisterWithScriptManager="True" ShowContentDuringLoad="False"
                                VisibleStatusbar="False" Animation="FlyIn" EnableShadow="True">
                            </telerik:RadWindow>
                            <telerik:RadWindow runat="server" ID="wndDocumentos" Skin="Web20" Modal="true" VisibleOnPageLoad="False"
                                Behaviors="Resize, Close" Height="510px" Width="680px" EnableEmbeddedScripts="True"
                                RegisterWithScriptManager="True" ShowContentDuringLoad="False" VisibleStatusbar="False"
                                Animation="FlyIn" EnableShadow="True">
                            </telerik:RadWindow>
                        </Windows>
                    </telerik:RadWindowManager>
                    <asp:ImageButton ID="imbRequerimiento" runat="server" ImageUrl="~/Img/remove.png"
                        ToolTip="Ver Requerimiento" />
                    <asp:ImageButton ID="imgPdf" runat="server" ImageUrl="~/Img/Acrobat.png" Height="32"
                        Width="32" ToolTip="Ver Requerimiento en PDF" OnClick="imgPdf_Click" />
                    <asp:ImageButton ID="imbDocs" runat="server" ImageUrl="~/Img/documents.png" Height="32"
                        Width="32" ToolTip="Ver Documentos Asociados" />
                    <hr />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPrefolioTitle" runat="server" Text="Folio: " Visible="False" ForeColor="#FF3300"></asp:Label>
                <asp:Label ID="lblPrefolio" runat="server" Visible="False" ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="upExchange" runat="server">
                    <ContentTemplate>
                        <telerik:RadMultiPage ID="MultiPage_Aviso" runat="server" RenderSelectedPageOnly="True">
                            <telerik:RadPageView ID="pnExchange" runat="server">
                                <table style="vertical-align: top; text-align: left; border-style: none" width="100%">
                                    <tr>
                                        <td width="110px">
                                            <asp:Label ID="lblExchangeType" runat="server" Text="Tipo de Cambio:"></asp:Label>
                                        </td>
                                        <td width="180px">
                                            <telerik:RadComboBox ID="ddlExchange" runat="server" AutoPostBack="True" DataSourceID="sqlDSExchangeType"
                                                DataTextField="sDescription" DataValueField="iIdExchangeType" OnSelectedIndexChanged="ddlExchange_SelectedIndExchanged"
                                                Skin="Vista" Width="160px">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td width="10">
                                        </td>
                                        <td width="100px">
                                            <asp:Label ID="lblPriority" runat="server" Text="Prioridad:"></asp:Label>
                                        </td>
                                        <td width="180px">
                                            <telerik:RadComboBox ID="ddlPriority" runat="server" DataSourceID="sqlDSPriority"
                                                DataTextField="sDescription" DataValueField="iIdPriority" Skin="Vista" Width="160px">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td width="10px">
                                        </td>
                                        <td width="100px">
                                            <asp:Label ID="lblSerie" runat="server" Text="Tipo:"></asp:Label>
                                        </td>
                                        <td style="margin-left: 40px" width="180">
                                            <telerik:RadComboBox ID="ddlSerie" runat="server" DataSourceID="sqlDSSerieProyect"
                                                DataTextField="fvdescription" DataValueField="fiid_serie_proyect" Skin="Vista"
                                                Width="160px">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPlant" runat="server" Text="Planta:"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="ddlPlant" runat="server" DataSourceID="sqlDSPlant" DataTextField="sDescription"
                                                DataValueField="iIdPlant" Skin="Vista" Width="160px">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblClient" runat="server" Text="Cliente:"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="ddlClient" runat="server" DataSourceID="sqlDSClient" DataTextField="sDescription"
                                                DataValueField="iIdClient" EmptyMessage="No hay datos asociados" ErrorMessage="No hay datos asociados"
                                                Skin="Vista" Width="160px">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLastFolio" runat="server" Text="Folio Anterior:"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtLastFolio" runat="server" MaxLength="20" Skin="Transparent"
                                                Width="150px">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table style="line-height: 10px; vertical-align: top; text-align: left; border-style: none"
                                    width="100%">
                                    <tr valign="top">
                                        <td>
                                            <asp:Label ID="lblLimitDate" runat="server" Text="Fecha Inicio de Cambio:"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="calLimitDate" runat="server">
                                            </telerik:RadDatePicker>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td width="180px">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblProyectPlatDes" runat="server" Text="Proyecto/Plataforma"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtProyectPlataformDescription" runat="server" EmptyMessage="F25, X11, JC$9, L42"
                                                MaxLength="50" Skin="Transparent" Width="250px">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td>
                                            <asp:Label ID="lblDescription" runat="server" Text="Descripción de la parte:"></asp:Label>
                                        </td>
                                        <td valign="top">
                                            <telerik:RadTextBox ID="txtDescription" runat="server" EmptyMessage="Nombre de pieza"
                                                MaxLength="250" Skin="Transparent" TextMode="MultiLine" Width="90%">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td>
                                            <asp:Label ID="lblIssue" runat="server" Text="Problema"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtIssue" runat="server" MaxLength="250" Skin="Transparent" TextMode="MultiLine"
                                                Width="90%">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td>
                                            <asp:Label ID="lblReason" runat="server" Text="Motivo"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtReason" runat="server" MaxLength="250" Skin="Transparent"
                                                TextMode="MultiLine" Width="90%">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td>
                                            <asp:Label ID="lblAction" runat="server" Text="Acción:"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtAction" runat="server" MaxLength="250" Skin="Transparent"
                                                TextMode="MultiLine" Width="90%">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr style="height: 30">
                                        <td>
                                            <asp:Label ID="lblEngeneer" runat="server" Text="Ingeniero de producto"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="ddlEngeenerProduct" runat="server" DataSourceID="sqlSPEmployedEP"
                                                DataTextField="sCompleteName" DataValueField="iIdEmployed" Skin="Vista" Width="60%">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td>
                                            <asp:Label ID="lblContact" runat="server" Text="Contacto del Cliente"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtContact" runat="server" Skin="Transparent" Width="90%">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5px">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Panel ID="pnDocuments" runat="server">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td height="5px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:CheckBox ID="chkDrawing" runat="server" Text="Dibujo" />
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="chkHOE" runat="server" Text="HOE" />
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="chkMedia" runat="server" Text="Medios de Producción" />
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="chkSing" runat="server" Text="Sign off" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:CheckBox ID="chkEspecification" runat="server" Text="Especificaciones" />
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="chkAMEF" runat="server" Text="AMEF" />
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="chkDevices" runat="server" Text="Dispositivos de verificación" />
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="chkMold" runat="server" Text="Molde" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:CheckBox ID="chkCost" runat="server" Text="Costos" />
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="chkSAP" runat="server" Text="SAP" />
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="chkPlan" runat="server" Text="Plan de control" />
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="chkOthers" runat="server" Text="Otros" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <telerik:RadButton Skin="Windows7" ID="btnGenetate" runat="server" Text="Folio" OnClick="btnGenetate_Click"
                                    Style="height: 26px" />
                                <telerik:RadButton Skin="Windows7" ID="btnClean" runat="server" OnClick="btnClean_Click"
                                    Text="Nuevo" Visible="False" />
                                <telerik:RadButton Skin="Windows7" ID="btnExchangeUpdate" runat="server" OnClick="btnExchangeUpdate_Click"
                                    Text="Modificar" />
                                <telerik:RadButton Skin="Windows7" ID="btnUpdateExchangeOk" runat="server" OnClick="btnUpdateExchangeOk_Click"
                                    Text="Guardar" />
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="pnTimingFinal" runat="server">
                                <table align="center" style="width: 100%; vertical-align: top; text-align: left;
                                    border-style: none">
                                    <tr>
                                        <td height="35px">
                                        </td>
                                        <td align="center">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                        </td>
                                        <td align="center">
                                            <telerik:RadGrid ID="gvTimming" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" CellPadding="4" CellSpacing="0" DataSourceID="sqlDSExchangeTask"
                                                Font-Size="XX-Small" GridLines="None" Skin="Transparent">
                                                <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
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
                                                        <telerik:GridTemplateColumn HeaderText="iIdTaskExchange" SortExpression="iIdTaskExchange"
                                                            Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("iIdTaskExchange") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="iTask" SortExpression="iTask" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("iTask") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="iExchange" SortExpression="iExchange" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("iExchange") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="iEmployed" SortExpression="iEmployed" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("iEmployed") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="iArea" SortExpression="iArea" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("iArea") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="sArea" SortExpression="sArea" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label10" runat="server" Text='<%# Bind("sArea") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="sNumberArea" SortExpression="sNumberArea"
                                                            Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("sNumberArea") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Tarea" SortExpression="sTask">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("sTask") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Empleado" SortExpression="sEmployed">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label13" runat="server" Text='<%# Bind("sEmployed") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Timing(semanas)" SortExpression="iTiming">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("iTiming") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Tarea Predecesora" SortExpression="sNextTask">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label12" runat="server" Text='<%# Bind("sNextTask") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Timing Total" SortExpression="iTimingTotal">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("iTimingTotal") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Fecha Final" SortExpression="dTiming">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("dTiming") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imbSelectReviewExchange" runat="server" CausesValidation="false"
                                                                    CommandArgument='<%# Bind("iTask") %>' CommandName="" ImageUrl="~/Img/select.png"
                                                                    OnClick="imbSelectReviewExchange_Click1" Style="height: 16px" ToolTip="Modificar registro" />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </telerik:GridTemplateColumn>
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
                                        <td width="10%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10px">
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Panel ID="pnTimingEndUpdate" runat="server" Visible="False">
                                    <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                                        <tr>
                                            <td width="30%">
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left" height="10px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="Label41" runat="server" Text="Tarea:"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTaskNow" runat="server" Text="Tarea:"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="Label42" runat="server" Text="Timing:"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <telerik:RadTextBox ID="txtTimingEnd" runat="server" Skin="Transparent">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="right">
                                                            <telerik:RadButton ID="Button2" runat="server" OnClick="Button2_Click" Skin="Windows7"
                                                                Text="Cancel" />
                                                            <telerik:RadButton ID="btnTimmingEndUpdate" runat="server" OnClick="btnTimmingEndUpdate_Click"
                                                                Skin="Windows7" Text="Aceptar" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="10px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="30%">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                &nbsp;&nbsp;&nbsp;
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="pnQuote" runat="server">
                                <asp:Panel ID="pnQuoteA" runat="server">
                                    <table style="width: 75%; vertical-align: top; text-align: left; border-style: none">
                                        <tr>
                                            <td width="20%">
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td width="120px">
                                                            <asp:Label ID="Label13" runat="server" Text="Descripción:"></asp:Label>
                                                        </td>
                                                        <td width="220px">
                                                            <telerik:RadComboBox ID="ddlNoPartCot" runat="server" AutoPostBack="True" DataSourceID="sqlDSAPartListExchangeC"
                                                                DataTextField="sPartListDescription" DataValueField="iIdPartList" OnSelectedIndexChanged="ddlNoPartCot_SelectedIndexChanged"
                                                                Skin="Vista">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td width="140px">
                                                            <asp:Label ID="Label23" runat="server" Text="Peso"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="txtPound" runat="server" Skin="Transparent">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label24" runat="server" Text="No. Parte:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNoPartC" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label25" runat="server" Text="Delta:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="txtDelta" runat="server" Skin="Transparent">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label26" runat="server" Text="No.Cliente:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNoPartClientC" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label27" runat="server" Text="Costo"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="txtCostC" runat="server" Skin="Transparent">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label28" runat="server" Text="Proyecto"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblProyectc" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label29" runat="server" Text="SOP Cliente:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="txtSOP" runat="server" ForeColor="Red" Skin="Transparent">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label30" runat="server" Text="Costo Material:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="txtCostM" runat="server" Skin="Transparent">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label38" runat="server" Text="Molde:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="txtMoldC" runat="server" Skin="Transparent">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label39" runat="server" Text="Prototipo:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="txtProt" runat="server" Skin="Transparent">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="20%">
                                            </td>
                                        </tr>
                                    </table>
                                    <hr />
                                    <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                                        <tr>
                                            <td height="15px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" bgcolor="#666699" height="30px">
                                                <asp:Label ID="lblDescriptionC" runat="server" ForeColor="White" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="15px">
                                            </td>
                                        </tr>
                                    </table>
                                    <hr />
                                    <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                                        <tr>
                                            <td width="27%">
                                            </td>
                                            <td valign="top">
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label31" runat="server" Text="Entrada:">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadDatePicker ID="calDateIn" runat="server">
                                                            </telerik:RadDatePicker>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label32" runat="server" Text="Promesa::">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadDatePicker ID="calDateProm" runat="server">
                                                            </telerik:RadDatePicker>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblDateOut" runat="server" Text="Entrega:">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadDatePicker ID="calDateOut" runat="server">
                                                            </telerik:RadDatePicker>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label34" runat="server" Text="Fecha Inicio"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="txtDateStart" runat="server" Skin="Transparent">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                            <td align="center">
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Img/add.png" OnClick="ImageButton1_Click1" />
                                                <telerik:RadGrid ID="gvCost" runat="server" AllowPaging="True" AllowSorting="True"
                                                    AutoGenerateColumns="False" CellPadding="4" CellSpacing="0" DataSourceID="sqlDSPArtLisExCost"
                                                    GridLines="None" Skin="Transparent">
                                                    <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                                                        <Selecting AllowRowSelect="True" />
                                                    </ClientSettings>
                                                    <MasterTableView>
                                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                            <HeaderStyle Width="20px" />
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                            <HeaderStyle Width="20px" />
                                                        </ExpandCollapseColumn>
                                                        <Columns>
                                                            <telerik:GridTemplateColumn HeaderText="Afectación" SortExpression="sAffectationDescription">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("sAffectationDescription") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Costo" SortExpression="sCost">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("sCost") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
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
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                                        <tr>
                                            <td width="30%">
                                            </td>
                                            <td>
                                                <asp:Panel ID="AffectationPartList" runat="server" Visible="False">
                                                    <table width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label35" runat="server" Text="Afectacion"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="ddlAfectationCot" runat="server" DataSourceID="sqlDataSourceAf"
                                                                    DataTextField="sAffectationDescription" DataValueField="iIdAffectation">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label36" runat="server" Text="Costo:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <telerik:RadTextBox ID="txtCostAdd" runat="server" Skin="Transparent">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <telerik:RadButton ID="btnCancelC" runat="server" OnClick="btnCancelC_Click" Skin="Windows7"
                                                                    Text="Cancel" />
                                                                <telerik:RadButton ID="btnAddListPartCot" runat="server" Skin="Windows7" Text="Agregar" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                            <td width="30%">
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                                        <tr>
                                            <td>
                                            </td>
                                            <td height="15px">
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="30%">
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td bgcolor="Red">
                                                            <asp:Label ID="Label33" runat="server" ForeColor="White" Text="Total Inv:"></asp:Label>
                                                        </td>
                                                        <td align="right" bgcolor="Red">
                                                            <asp:Label ID="lblTotalInvC" runat="server" ForeColor="White"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td bgcolor="Red">
                                                            <asp:Label ID="Label37" runat="server" ForeColor="White" Text="Total Pieza"></asp:Label>
                                                        </td>
                                                        <td align="right" bgcolor="Red">
                                                            <asp:Label ID="lblTotalC" runat="server" ForeColor="White" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="right">
                                                            <telerik:RadButton ID="btnUpdateQuoteOk" runat="server" Skin="Windows7" Text="Guardar"
                                                                Visible="False" />
                                                            <telerik:RadButton ID="btnUpdateQuote" runat="server" Skin="Windows7" Text="Modificar"
                                                                Visible="False" />
                                                            <telerik:RadButton ID="btnAddCot" runat="server" OnClick="btnAddCot_Click" Skin="Windows7"
                                                                Text="Agregar" />
                                                            <telerik:RadButton ID="btnCalculate" runat="server" OnClick="btnCalculate_Click"
                                                                Skin="Windows7" Text="Calcular" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="30%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnQuoteNon" runat="server" Visible="False">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td height="200px">
                                                <asp:Label ID="Label12" runat="server" Text="No se han Introducido numeros de parte"
                                                    Visible="true"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                &nbsp;&nbsp;&nbsp;
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="pnAnalize" runat="server">
                                <asp:Panel ID="pnGenerateFolio" runat="server">
                                    <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                                        <tr>
                                            <td>
                                            </td>
                                            <td width="200px">
                                            </td>
                                            <td width="220px">
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="Label40" runat="server" Text="Fecha de Aplicación"></asp:Label>
                                            </td>
                                            <td align="left" valign="top">
                                                <telerik:RadDatePicker ID="calAplicationDate" runat="server">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                &#160;
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="btnGenerateFolio" runat="server" Height="30px" OnClick="btnGenerateFolio_Click"
                                                    Skin="Windows7" Text="Aplicar" Width="200px" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnFolio" runat="server" Visible="false">
                                    <table style="width: 100%; border-style: none">
                                        <tr>
                                            <td width="30%">
                                            </td>
                                            <td height="30px">
                                            </td>
                                            <td width="30%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="center" bgcolor="#336699" height="200px">
                                                <div>
                                                    <asp:Label ID="lblFolioTitle" runat="server" ForeColor="#FFFFCC" Text="Fecha Aplicación"></asp:Label>
                                                </div>
                                                <div>
                                                    <asp:Label ID="lblFolioGen" runat="server" ForeColor="#FFFFCC" Text="0"></asp:Label>
                                                </div>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="30%">
                                            </td>
                                            <td height="30px">
                                            </td>
                                            <td width="30%">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                &nbsp;&nbsp;&nbsp;
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="pnDocumentsSupport" runat="server">
                                <table align="center" style="width: 100%; vertical-align: top; text-align: left;
                                    border-style: none">
                                    <tr>
                                        <td width="30%">
                                        </td>
                                        <td height="15px">
                                        </td>
                                        <td width="30%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="center">
                                            <telerik:RadGrid ID="gvDocuments" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" CellPadding="4" CellSpacing="0" DataSourceID="sqlDSExchangeFile"
                                                GridLines="None" OnItemCommand="gvDocuments_ItemCommand" 
                                                Skin="Transparent">
                                                <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
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
                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="TemplateColumn">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="rbtnSelect" runat="server" CommandName="Download" Height="23"
                                                                    ImageUrl="~/img/msg-refresh.jpg" Width="23" />
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridBoundColumn DataField="iIdExchangeFile" HeaderText="" ReadOnly="true"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="iFile" HeaderText="" ReadOnly="true" Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="iExchange" HeaderText="" ReadOnly="true" Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="sURL" HeaderText="" ReadOnly="true" Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="iTiype" HeaderText="" ReadOnly="true" Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="sType" HeaderText="" ReadOnly="true" Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="sLabel" HeaderText="Archivo" ReadOnly="true">
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
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td height="15px">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                                    <tr>
                                        <td width="30%">
                                        </td>
                                        <td height="15px">
                                        </td>
                                        <td width="30%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td height="15px">
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td height="15px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                    </td>
                                                    <td width="20%">
                                                        <label id="ruta">
                                                            Seleccione Ruta:</label>
                                                    </td>
                                                    <td width="50%">
                                                        <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" AutoAddFileInputs="False"
                                                            Culture="es-MX" Skin="Transparent" Width="280px">
                                                        </telerik:RadAsyncUpload>
                                                    </td>
                                                    <td width="15%">
                                                        <telerik:RadButton ID="btnGraba" runat="server" OnClick="btnGrabar_Click" Skin="Windows7"
                                                            Text="Agregar" />
                                                    </td>
                                                    <td width="10%">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="15px">
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td height="15px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td height="15px">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                                &nbsp;&nbsp;&nbsp;
                            </telerik:RadPageView>
                        </telerik:RadMultiPage>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="100%">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300" Visible="False"></asp:Label>
                <asp:Label ID="lblPartList" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:Label ID="lblIdExchange" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:Label ID="lblCalendar" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:Label ID="lblCost" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:Label ID="lblReviewExchange" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:Label ID="lblIdTaskT" runat="server" Text="0" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="sqlDSPartListExchange" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_SelectPartListExchangeById" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="fiid_Exchange" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSddlPartList" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectddlPartList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSAffectationType" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectAffectationType" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSReviewTypeExchange" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectReviewExchangeByIdExchange" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblIdExchange" DefaultValue="0" Name="fiid_Exchange"
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSReviewType" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectReviewType" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSSerieProyect" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectSerieProyect" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSPriority" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectPriority" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSEmployedArea" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectEmployedByNameArea" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="'Ingenieria de producto'" Name="area" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSExchangeType" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectExchangeType" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSPlant" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectPlant" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSDataType" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectDataType" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSExchangeTask" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectExchangeTaskByIdExchange" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblIdExchange" DefaultValue="0" Name="fiid_Exchange"
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDS" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectExchange_srch_fl" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtSrchPreFol" DefaultValue="0" Name="fvfolio" PropertyName="Text"
                Type="string" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSExchangeFile" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectFileEechangeByExchange" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblIdExchange" DefaultValue="0" Name="fiid_Exchange"
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSClient" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectClient" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSAPartListExchangeC" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_SelectDiscPartListExchangeById" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblIdExchange" DefaultValue="0" Name="fiid_Exchange"
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlSPEmployedEP" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSProyectPlataform" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectPryectPlataform" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDataSourceAf" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_SelectAffectationPartListExchange" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblPartList" DefaultValue="0" Name="fiid_part_list"
                PropertyName="Text" Type="Int32" />
            <asp:ControlParameter ControlID="lblIdExchange" DefaultValue="0" Name="fiid_Exchange"
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSPArtLisExCost" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_SelectPartListExchangeCost" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblPartList" DefaultValue="0" Name="fiid_part_list"
                PropertyName="Text" Type="Int32" />
            <asp:ControlParameter ControlID="lblIdExchange" DefaultValue="0" Name="fiid_Exchange"
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
