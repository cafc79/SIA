<%@ Page Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="Solicitud.aspx.cs" Inherits="Solicitud"
    Title="Solicitud" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadScriptManager ID="ScriptManager1" runat="server" EnableTheming="True">
    </telerik:RadScriptManager>
    <table style="border-width: thin; border-style: none; width: 100%; vertical-align: top;
        text-align: center;">
        <tr>
            <td style="vertical-align: top; text-align: left; border-right-style: groove; border-right-width: 2px;"
                width="190px">
                <asp:Menu ID="menuSolicitud" runat="server" BackColor="#B5C7DE" Font-Names="Verdana"
                    Font-Size="XX-Small" ForeColor="#284E98" OnMenuItemClick="menuSolicitud_MenuItemClick"
                    StaticSubMenuIndent="10px" Width="148px">
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
                <table style="border-width: thin; border-style: none; width: 100%; vertical-align: top;
                    text-align: center;">
                    <tr>
                        <td height="30px">
                            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="#4B4B4B">Alta Requerimiento</asp:Label>
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
                                            <asp:Label ID="lblFolio" runat="server" Text="PreFolio: "></asp:Label>
                                        </td>
                                        <td width="260px">
                                            <telerik:RadTextBox Skin="WebBlue" ID="txtSrchPreFol" runat="server" Width="250px"
                                                EmptyMessage="Prefolio">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td align="left">
                                            <asp:ImageButton ID="imbSerach" runat="server" ImageUrl="~/Img/btn_search.gif" OnClick="imbSerach_Click" />
                                        </td>
                                        <td width="30%">
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" style="vertical-align: top; text-align: center; border-style: none">
                                    <tr>
                                        <td width="80%" align="center">
                                            <telerik:RadGrid ID="gvExchange" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                DataKeyNames="fiid_exchange" DataSourceID="sqlDS" EmptyDataText="No existen datos registrados."
                                                Font-Size="XX-Small" GridLines="None" HorizontalAlign="Center" AllowPaging="True"
                                                AllowSorting="True" CellSpacing="0" Skin="WebBlue" Culture="es-MX">
                                                <GroupingSettings UnGroupButtonTooltip="Click aqui para desagrupar" UnGroupTooltip="Arrastrar fuera de l barra para desagrupar" />
                                                <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                                                    <Selecting AllowRowSelect="True" />
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                                <GroupPanel Text="Arrastrar el encabezado de la columna y soltar aqui para agrupar">
                                                </GroupPanel>
                                                <MasterTableView Width="100%" AllowMultiColumnSorting="True">
                                                    <Columns>
                                                        <telerik:GridTemplateColumn HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imbSelectExchange" runat="server" CausesValidation="false" CommandArgument='<%# Bind("fiid_exchange") %>'
                                                                    ImageUrl="~/Img/select.png" OnClick="imbSelectExchange_Click" Text="Botón" ToolTip="Modificar registro" />
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
                                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
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
                                                <HeaderStyle Font-Size="X-Small" Font-Names="Verdana" />
                                                <ItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                                <FilterMenu EnableImageSprites="False">
                                                </FilterMenu>
                                                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                                </HeaderContextMenu>
                                            </telerik:RadGrid>
                                        </td>
                                        <td width="20%">
                                            <asp:ImageButton ID="imbEchangeAdd" runat="server" OnClick="imbEchangeAdd_Click"
                                                ImageUrl="~/Img/add.png" />
                                        </td>
                                    </tr>
                                </table>
                                <div id="NavigateUrlZone">
                                </div>
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
                            <asp:Label ID="lblPrefolioTitle" runat="server" Text="Prefolio: " Visible="False"
                                ForeColor="#FF3300"></asp:Label>
                            <asp:Label ID="lblPrefolio" runat="server" Visible="False" ForeColor="#CC0000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadMultiPage ID="MultiPage_Solicitud" runat="server" RenderSelectedPageOnly="True">
                                <telerik:RadPageView ID="pnExchange" runat="server">
                                    <table width="100%" style="vertical-align: top; text-align: left; border-style: none">
                                        <tr>
                                            <td width="110px">
                                                <asp:Label ID="lblExchangeType" runat="server" Text="Tipo de Cambio:"></asp:Label>
                                            </td>
                                            <td width="180px">
                                                <telerik:RadComboBox ID="ddlExchange" runat="server" DataSourceID="sqlDSExchangeType"
                                                    DataTextField="sDescription" DataValueField="iIdExchangeType" Width="160px" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlExchange_SelectedIndExchanged" Skin="Vista">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td width="10">
                                            </td>
                                            <td width="100px">
                                                <asp:Label ID="lblPriority" runat="server" Text="Prioridad:"></asp:Label>
                                            </td>
                                            <td width="180px">
                                                <telerik:RadComboBox ID="ddlPriority" runat="server" DataSourceID="sqlDSPriority"
                                                    DataTextField="sDescription" DataValueField="iIdPriority" Width="160px" Skin="Vista">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td width="10px">
                                            </td>
                                            <td width="100px">
                                                <asp:Label ID="lblSerie" runat="server" Text="Tipo:"></asp:Label>
                                            </td>
                                            <td width="180">
                                                <telerik:RadComboBox ID="ddlSerie" runat="server" DataSourceID="sqlDSSerieProyect"
                                                    DataTextField="fvdescription" DataValueField="fiid_serie_proyect" Width="160px"
                                                    Skin="Vista">
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPlant" runat="server" Text="Planta:"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="ddlPlant" runat="server" DataSourceID="sqlDSPlant" DataTextField="sDescription"
                                                    DataValueField="iIdPlant" Width="160px" Skin="Vista">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblClient" runat="server" Text="Cliente:"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="ddlClient" runat="server" DataSourceID="sqlDSClient" DataTextField="sDescription"
                                                    DataValueField="iIdClient" Width="160px" Skin="Vista">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblLastFolio" runat="server" Text="Folio Anterior:"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox Skin="WebBlue" ID="txtLastFolio" runat="server" MaxLength="20"
                                                    Width="150px" EmptyMessage="# de desviación">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" style="line-height: 10px; vertical-align: top; text-align: left;
                                        border-style: none">
                                        <tr valign="top">
                                            <td>
                                                <asp:Label ID="lblLimitDate" runat="server" Text="Fecha Limite Cotización:"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="calLimite" runat="server">
                                                </telerik:RadDatePicker>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td width="180px">
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblProyectPlatDes" runat="server" Text="Proyecto/Plataforma"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox Skin="WebBlue" ID="txtProyectPlataformDescription" runat="server"
                                                    MaxLength="50" Width="250px" EmptyMessage="F25, X11, JC$9, L42">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td>
                                                <asp:Label ID="lblDescription" runat="server" Text="Descripción del Producto:"></asp:Label>
                                            </td>
                                            <td valign="top">
                                                <telerik:RadTextBox Skin="WebBlue" ID="txtDescription" runat="server" MaxLength="250"
                                                    TextMode="MultiLine" Width="90%">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td>
                                                <asp:Label ID="lblIssue" runat="server" Text="Problema"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox Skin="WebBlue" ID="txtIssue" runat="server" MaxLength="250" TextMode="MultiLine"
                                                    Width="90%">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td>
                                                <asp:Label ID="lblReason" runat="server" Text="Motivo"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox Skin="WebBlue" ID="txtReason" runat="server" MaxLength="250"
                                                    TextMode="MultiLine" Width="90%">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td>
                                                <asp:Label ID="lblAction" runat="server" Text="Acción:"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox Skin="WebBlue" ID="txtAction" runat="server" MaxLength="250"
                                                    TextMode="MultiLine" Width="90%">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td>
                                                <asp:Label ID="lblEngeneer" runat="server" Text="Ingeniero de producto"></asp:Label>
                                            </td>
                                            <td valign="top">
                                                <telerik:RadComboBox ID="ddlEngeenerProduct" runat="server" DataSourceID="sqlSPEmployedEP"
                                                    DataTextField="sCompleteName" DataValueField="iIdEmployed" Width="60%">
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td>
                                                <asp:Label ID="lblContact" runat="server" Text="Contacto del Cliente"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox Skin="WebBlue" ID="txtContact" runat="server" Width="90%">
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
                                    <telerik:RadButton Skin="Windows7" ID="btnGenetate" runat="server" Text="Prefolio"
                                        OnClick="btnGenetate_Click" Style="height: 26px">
                                    </telerik:RadButton>
                                    <telerik:RadButton Skin="Windows7" ID="btnClean" runat="server" OnClick="btnClean_Click"
                                        Text="Nuevo" Visible="False">
                                    </telerik:RadButton>
                                    <telerik:RadButton Skin="Windows7" ID="btnExchangeUpdate" runat="server" OnClick="btnExchangeUpdate_Click"
                                        Text="Modificar">
                                    </telerik:RadButton>
                                    <telerik:RadButton Skin="Windows7" ID="btnUpdateExchange_Documents" runat="server"
                                        OnClick="btnUpdateExchange_Documents_Click" Text="Guardar">
                                    </telerik:RadButton>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="pnAnalize" runat="server">
                                    <asp:Panel ID="pnGenerateFolio" runat="server">
                                        <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
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
                                                <td height="200px" align="center">
                                                    <telerik:RadButton Skin="Windows7" ID="btnGenerateFolio_Analize" runat="server" Height="50px"
                                                        Text="Generar Folio" Width="200px" OnClick="btnGenerateFolio_Analize_Click" />
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
                                                <td height="200px" bgcolor="#336699" align="center">
                                                    <div>
                                                        <asp:Label ID="lblFolioTitle" runat="server" Text="No. de Folio Generado:" ForeColor="#FFFFCC"></asp:Label></div>
                                                    <div>
                                                        <asp:Label ID="lblFolioGen" runat="server" Text="0" ForeColor="#FFFFCC"></asp:Label></div>
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
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="pnDocumentsSupport" runat="server">
                                    <table style="width: 100%; vertical-align: top; text-align: left; border-style: none"
                                        align="center">
                                        <tr>
                                            <td width="30%">
                                            </td>
                                            <td height="15px">
                                            </td>
                                            <td width="30%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <telerik:RadGrid ID="gvDocuments" runat="server" CellPadding="4" AllowPaging="True"
                                                    AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" DataKeyNames="iIdExchangeFile"
                                                    DataSourceID="sqlDSExchangeFile" GridLines="None" Skin="WebBlue" OnItemCommand="gvDocuments_ItemCommand">
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
                                                            <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:Panel ID="Panel1" runat="server">
                                                                        <asp:ImageButton ID="rbtnSelect" runat="server" AutoPostBack="true" ImageUrl="~/img/msg-refresh.jpg"
                                                                            Width="21" Height="21" CommandName="Download" />
                                                                    </asp:Panel>
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
                                                    <FilterMenu EnableImageSprites="False">
                                                    </FilterMenu>
                                                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                                    </HeaderContextMenu>
                                                </telerik:RadGrid>
                                            </td>
                                            <td>
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
                                                            <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" Skin="WebBlue" AutoAddFileInputs="False"
                                                                Width="280px" Culture="es-MX">
                                                            </telerik:RadAsyncUpload>
                                                        </td>
                                                        <td width="15%">
                                                            <telerik:RadButton Skin="Windows7" ID="btnGraba" runat="server" OnClick="btnGrabar_Click"
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
                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
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
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="sqlDSddlPartList" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectddlPartList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSAffectationType" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectAffectationType" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSReviewTypeExchange" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectReviewExchangeByIdExchange" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblIdExchange" DefaultValue="0" Name="fiid_exchange"
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSReviewType" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectReviewType" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSSerieProyect" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectSerieProyect" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSPriority" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectPriority" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSEmployedArea" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectEmployedByNameArea" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="'Ingenieria de producto'" Name="area" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSExchangeType" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectExchangeType" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSPlant" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectPlant" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSDataType" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectDataType" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDS" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectExchange_srch" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtSrchPreFol" DefaultValue="0" Name="fvprefolio"
                PropertyName="Text" Type="string" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSExchangeFile" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectFileEechangeByExchange" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblIdExchange" DefaultValue="0" Name="fiid_exchange"
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSClient" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectClient" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSAPartListExchangeC" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_SelectDiscPartListExchangeById" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblIdExchange" DefaultValue="0" Name="fiid_exchange"
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlSPEmployedEP" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSProyectPlataform" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectPryectPlataform" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDataSourceAf" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_SelectAffectationPartListExchange" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblPartList" DefaultValue="0" Name="fiid_part_list"
                PropertyName="Text" Type="Int32" />
            <asp:ControlParameter ControlID="lblIdExchange" DefaultValue="0" Name="fiid_exchange"
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSPArtLisExCost" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_SelectPartListExchangeCost" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblPartList" DefaultValue="0" Name="fiid_part_list"
                PropertyName="Text" Type="Int32" />
            <asp:ControlParameter ControlID="lblIdExchange" DefaultValue="0" Name="fiid_exchange"
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
