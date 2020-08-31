<%@ Page Title="" Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true"
    CodeFile="Timming.aspx.cs" Inherits="Timming" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2012.1.215.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnablePageHeadUpdate="False">
        <ajaxsettings>
            <telerik:AjaxSetting AjaxControlID="gvTaskGroup">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvTaskGroup" />
                    <telerik:AjaxUpdatedControl ControlID="sqlDSTask" />
                    <telerik:AjaxUpdatedControl ControlID="ddlTaskTiming_Edit" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="txtTiming_Edit" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="chlTaskNext" />
                    <telerik:AjaxUpdatedControl ControlID="ddlNestTask" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="ddlUsuarioTask_Edit" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlGroup">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="sqlDStaskGroupByGroup" />
                    <telerik:AjaxUpdatedControl ControlID="sqlDSDataTaskbyTaskId" />
                    <telerik:AjaxUpdatedControl ControlID="ddlTaskTiming" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="ddlTaskTiming_Edit" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="ddlUsuarioTask_Edit" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAddTiming">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvTaskGroup" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="ddlNestTask" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="sqlDSExchangeTask" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlTaskTiming_Edit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlUsuarioTask_Edit" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chlTaskNext">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlNestTask" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnEditTimmingSave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvTaskGroup" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="ddlNestTask" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="gvTaskData" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="sqlDSExchangeTask">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvTaskGroup" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="ddlNestTask" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </ajaxsettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <table style="border-width: thin; border-style: none; width: 100%; vertical-align: top;
        text-align: center;">
        <tr>
            <td height="30px">
                <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="#4B4B4B">Timming</asp:Label>
                <br />
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" RenderSelectedPageOnly="True">
                    <telerik:RadPageView ID="RadPageView1" runat="server">
                        <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                            <tr>
                                <td align="center">
                                    <telerik:RadGrid ID="gvTaskGroup" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        AllowSorting="True" CellSpacing="0" GridLines="None" ShowGroupPanel="True" OnItemCommand="gvTaskGroup_ItemCommand"
                                        BorderStyle="None" Skin="Transparent" DataSourceID="sqlDSExchangeTask" Font-Size="XX-Small"
                                        ShowFooter="True">
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
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="" UniqueName="TemplateColumn">
                                                    <ItemStyle HorizontalAlign="Center" Width="50" />
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibtnEdit" runat="server" AlternateText="Folio" CommandName="editId"
                                                            ImageUrl="~/Img/verde.png" Width="21" Height="21" />
                                                        <asp:ImageButton ID="ibtnDelete" runat="server" AlternateText="Folio" CommandName="deleteId"
                                                            ImageUrl="~/Img/rojo.png" OnClientClick="return confirm('¿Confirma que desea eliminar el registro seleccionado?');"
                                                            Width="21" Height="21" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="iIdTaskExchange" HeaderText="iIdTaskExchange"
                                                    ReadOnly="true" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="iTask" HeaderText="" ReadOnly="true" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="iExchange" HeaderText="" ReadOnly="true" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="iEmployed" HeaderText="" ReadOnly="true" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="iArea" HeaderText="" ReadOnly="true" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="sArea" HeaderText="Área" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="sTask" HeaderText="Tarea" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="sEmployed" HeaderText="Empleado" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="80" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="iTiming" HeaderText="Timing (semanas)" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" Width="69px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="sNextTask" HeaderText="Tarea Predecesora" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="iTimingTotal" HeaderText="Timing Total" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" Width="69px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="dTiming" HeaderText="Fecha Final" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
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
                                <td align="center">
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                            <tr>
                                <td style="width: 10%">
                                </td>
                                <td style="width: 200">
                                    <asp:Label ID="Label19" runat="server" Text="Grupo:"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddlGroup" runat="server" Width="300" DataSourceID="sqlDSGroup"
                                        DataTextField="sDescription" DataValueField="iIdGroup" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndExchanged"
                                        Skin="Vista" EnableVirtualScrolling="True">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                            <tr>
                                <td valign="top">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 200">
                                                <asp:Label ID="lblTask" runat="server" Text="Tarea:"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="ddlTaskTiming" runat="server" DataTextField="sDescriptionTask"
                                                    DataValueField="iIdTask" OnSelectedIndexChanged="ddlTaskTiming_SelectedIndExchanged"
                                                    DataSourceID="sqlDStaskGroupByGroup" Skin="Vista" Width="300px">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "iIdTask") %>'
                                                            Checked="true" />
                                                        <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "sDescriptionTask")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:Label ID="lblTiming" runat="server" Text="Timing:"></asp:Label>
                                            </td>
                                            <td align="left" valign="top">
                                                <telerik:RadNumericTextBox Skin="Vista" ID="txtTiming" runat="server" DataType="System.Int16"
                                                    MaxValue="100" MinValue="0" ShowSpinButtons="True" Value="1">
                                                    <NumberFormat DecimalDigits="0" />
                                                </telerik:RadNumericTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="right">
                                                <telerik:RadButton Skin="Windows7" ID="btnCalcelAddExchageTask" runat="server" OnClick="btnCalcelAddExchageTask_Click"
                                                    Text="Cancel" />
                                                <telerik:RadButton Skin="Windows7" ID="btnAddTiming" runat="server" Text="Aceptar"
                                                    OnClick="btnAddTiming_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td valign="top">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 200">
                                                <asp:Label ID="Label15" runat="server" Text="Tarea:"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="ddlTaskTiming_Edit" runat="server" DataTextField="sDescriptionTask"
                                                    DataValueField="iIdTask" DataSourceID="sqlDStaskGroupByGroup" OnSelectedIndexChanged="ddlTaskTiming_SelectedIndExchanged"
                                                    Skin="Vista" Width="300px">
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:Label ID="Label16" runat="server" Text="Timing:"></asp:Label>
                                            </td>
                                            <td align="left" valign="top">
                                                <telerik:RadNumericTextBox ID="txtTiming_Edit" runat="server" DataType="System.Int16"
                                                    MaxValue="100" MinValue="0" ShowSpinButtons="True" Skin="Vista" Value="1">
                                                    <NumberFormat DecimalDigits="0" />
                                                </telerik:RadNumericTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label17" runat="server" Text="Tarea Predecesora:"></asp:Label><asp:CheckBox
                                                    ID="chlTaskNext" runat="server" AutoPostBack="True" OnCheckedChanged="chlTaskNext_CheckedChanged" />
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="ddlNestTask" runat="server" Width="300px" DataTextField="sTask"
                                                    DataValueField="iTask" AutoPostBack="True" Skin="Vista" DataSourceID="sqlDSExchangeTask">
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label18" runat="server" Text="Usuario:"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="ddlUsuarioTask_Edit" runat="server" Width="300px" DataTextField="sCompleteName"
                                                    DataValueField="fiid_employed" DataSourceID="sqlEmployedByTask" Skin="Vista"
                                                    AutoPostBack="True">
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="right">
                                                <telerik:RadButton Skin="Windows7" ID="btnEditCancelTiming" runat="server" OnClick="btnEditCancelTiming_Click"
                                                    Text="Cancel" />
                                                <telerik:RadButton Skin="Windows7" ID="btnEditTimmingSave" runat="server" Text="Aceptar"
                                                    OnClick="btnEditTimmingSave_Click" CommandArgument="0" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                            <tr>
                                <td height="15px">
                                </td>
                                <td align="center" height="30px">
                                    <asp:Label ID="lblTitleRelv" runat="server" Text="Datos Relevantes"></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td width="30%">
                                </td>
                                <td align="center" colspan="2">
                                    <telerik:RadGrid ID="gvTaskData" runat="server" CellPadding="4" AllowPaging="True"
                                        AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" DataKeyNames="iIdTaskData"
                                        DataSourceID="sqlDSDataTaskbyTaskId" GridLines="None" Skin="Transparent">
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
                                                <telerik:GridBoundColumn DataField="iIdTaskData" HeaderText="iIdTaskData" ReadOnly="true"
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="iTask" HeaderText="iTask" ReadOnly="true" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="iData" HeaderText="iData" ReadOnly="true" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="bStatus" HeaderText="bStatus" ReadOnly="true"
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="sTask" HeaderText="sTask" ReadOnly="true" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="sDescription" HeaderText="Dato Relevante" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="sData" HeaderText="Tipo de Dato" ReadOnly="true">
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
                            </tr>
                            <tr>
                                <td height="15px">
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView2" runat="server">
                        <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                            <tr>
                                <td align="center">
                                    <telerik:RadGrid ID="gvTaskGroupA" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        AllowPaging="True" DataSourceID="sqlDSExchangeTask" GridLines="None" Font-Size="XX-Small"
                                        HorizontalAlign="Left" EmptyDataText="No existen datos registrados." AllowSorting="True"
                                        Culture="es-MX" Skin="Transparent" OnItemCommand="gvTaskGroup_ItemCommand" BorderStyle="None"
                                        CellSpacing="0">
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
                                                <telerik:GridBoundColumn DataField="iIdTaskExchange" HeaderText="iIdTaskExchange"
                                                    ReadOnly="true" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="iTask" HeaderText="" ReadOnly="true" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="iExchange" HeaderText="" ReadOnly="true" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="iEmployed" HeaderText="" ReadOnly="true" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="iArea" HeaderText="" ReadOnly="true" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="sArea" HeaderText="Área" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="sTask" HeaderText="Tarea" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="sEmployed" HeaderText="Empleado" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="80" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="iTiming" HeaderText="Timing (semanas)" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="sNextTask" HeaderText="Tarea Predecesora" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="iTimingTotal" HeaderText="Timing Total" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="dTiming" HeaderText="Fecha Final" ReadOnly="true">
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
                        <table style="width: 100%;">
                            <tr align="left">
                                <td style="width: 20%;">
                                    <asp:Label ID="lblBoss" runat="server" Text="Area:"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddlAreaPendiente" runat="server" Width="300px" AutoPostBack="True"
                                        DataTextField="sArea" DataValueField="iArea" EmptyMessage="Su usuario no es el responsable del área involucrada"
                                        EnableVirtualScrolling="True" OnDataBinding="ddlAreaPendiente_DataBinding">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="20%">
                                    <asp:Label ID="lblReviewExchangeReview" runat="server" Text="Evaluación:"></asp:Label>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="ddlReviewExchangeReview" runat="server" DataSourceID="sqlDSReviewType"
                                        DataTextField="sDescription" DataValueField="iIdReviewType" Skin="Vista">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <asp:Label ID="lblReviewExchangeObservation" runat="server" Text="Observación:"></asp:Label>
                                </td>
                                <td align="left">
                                    <telerik:RadTextBox Skin="Transparent" ID="txtReviewExchangeObs" runat="server" Height="60px"
                                        TextMode="MultiLine" Width="90%">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 20%;">
                                </td>
                                <td align="right">
                                    <telerik:RadButton Skin="Windows7" ID="btnAddExchangeReview" runat="server" OnClick="btnAddExchangeReview_Click"
                                        Text="Aceptar" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 20%;">
                                </td>
                                <td align="center">
                                    <telerik:RadGrid ID="gvReviewTask" runat="server" CellPadding="4" AllowPaging="True"
                                        AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" DataKeyNames="iIdTaskData"
                                        DataSourceID="sqlDSTaskAutorization" Skin="Transparent">
                                        <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>
                                        <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                        <MasterTableView DataSourceID="sqlDSTaskAutorization">
                                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                <HeaderStyle Width="20px" />
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                <HeaderStyle Width="20px" />
                                            </ExpandCollapseColumn>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="fiIdTaskAutorization" HeaderText="fiIdTaskAutorization"
                                                    ReadOnly="true" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Area" HeaderText="Area" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Revision" HeaderText="Revisión" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Observaciones" HeaderText="Observaciones" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Fecha" HeaderText="Fecha" ReadOnly="true">
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
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
        <tr>
            <td width="100%">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300" Visible="False"></asp:Label>
                <asp:Label ID="lblIdExchange" runat="server" Text="0" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="sqlDSExchangeTask" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectExchangeTaskByIdExchange" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblIdExchange" DefaultValue="0" Name="fiid_exchange"
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSGroup" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectGroup" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDStaskGroupByGroup" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectTaskGroupByIdGroup" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlGroup" DefaultValue="0" Name="fiid_group" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSTaskAutorization" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectTaskAutorization" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblIdExchange" DefaultValue="0" Name="Exchange"
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSTask" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectTask" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSReviewType" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectReviewType" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSDataTaskbyTaskId" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectDataTaskByTask" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlTaskTiming_edit" DefaultValue="0" Name="fiid_task"
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlEmployedByTask" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectEmployedByTask" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlTaskTiming_Edit" DefaultValue="0" Name="fiid_task"
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSReviewTypeExchange" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectReviewExchangeByIdExchange" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblIdExchange" DefaultValue="0" Name="fiid_exchange"
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
