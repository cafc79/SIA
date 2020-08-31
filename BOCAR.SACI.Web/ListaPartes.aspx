<%@ Page Title="" Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true"
    CodeFile="ListaPartes.aspx.cs" Inherits="ListaPartes" EnableEventValidation="false" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadScriptManager ID="ScriptManager1" runat="server" EnableTheming="True">
    </telerik:RadScriptManager>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
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
                                <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="#4B4B4B">Lista de Partes</asp:Label>
                                <br />
                                <hr />
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
                                <table style="width: 100%; vertical-align: top; text-align: left; border-style: none"
                                    align="center">
                                    <tr>
                                        <td width="10%">
                                        </td>
                                        <td align="center">
                                            <telerik:RadGrid ID="gvPartListExchange" runat="server" AllowPaging="True" AllowSorting="True"
                                                CellSpacing="0" DataSourceID="sqlDSPartListExchange" GridLines="None" OnItemCommand="genericPartListExchange_ItemCommand"
                                                Skin="WebBlue" AutoGenerateColumns="False">
                                                <ClientSettings>
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                                <MasterTableView DataSourceID="sqlDSPartListExchange">
                                                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                        <HeaderStyle Width="20px"></HeaderStyle>
                                                    </RowIndicatorColumn>
                                                    <Columns>
                                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="" UniqueName="TemplateColumn">
                                                            <ItemStyle HorizontalAlign="Center" Width="50" />
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ibtnEdit" runat="server" AlternateText="" CommandName="editId"
                                                                    ImageUrl="~/Img/verde.png" Width="21" Height="21" />
                                                                <asp:ImageButton ID="ibtnDelete" runat="server" AlternateText="Folio" CommandName="deleteId"
                                                                    ImageUrl="~/Img/rojo.png" OnClientClick="return confirm('¿Confirma que desea eliminar el registro indicado?');"
                                                                    Width="21" Height="21" />
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridBoundColumn DataField="iIdPartListExchange" HeaderText="iIdPartListExchange"
                                                            ReadOnly="true" Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="iIdExchange" HeaderText="iIdExchange" ReadOnly="true"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="iIdPartList" HeaderText="iIdPartList" ReadOnly="true"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="iIdAffectation" HeaderText="iIdPartList" ReadOnly="true"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="sFolion" HeaderText="sFolio" ReadOnly="true"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="sPreFolio" HeaderText="sPreFolio" ReadOnly="true"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="sPartListDescription" HeaderText="Parte" ReadOnly="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="sPartListBocar" HeaderText="No. Parte Bocar"
                                                            ReadOnly="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="sPartListClient" HeaderText="No. Parte Cliente"
                                                            ReadOnly="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="sAffectationDescription" HeaderText="Afectación"
                                                            ReadOnly="true">
                                                        </telerik:GridBoundColumn>
                                                    </Columns>
                                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                        <HeaderStyle Width="20px"></HeaderStyle>
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
                                        <td width="10%">
                                        </td>
                                    </tr>
                                </table>
                                <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                                    <tr>
                                        <td width="25%">
                                        </td>
                                        <td>
                                            <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                                                <tr>
                                                    <td>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td width="120px">
                                                                    <asp:Label ID="lblPartListExchangePart" runat="server" Text="Parte:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadComboBox ID="ddlPartListExchangePartList" runat="server" DataSourceID="sqlDSddlPartList"
                                                                        DataTextField="sDescription" DataValueField="iIdPart" Width="300px" AutoPostBack="True"
                                                                        EnableVirtualScrolling="True" Skin="Vista" OpenDropDownOnLoad="True" 
                                                                        AllowCustomText="True" MarkFirstMatch="True">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblPartListExchangeAffectation" runat="server" Text="Afectación:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadComboBox ID="ddlPartListExchangeAffectation" runat="server" DataSourceID="sqlDSAffectationType"
                                                                        DataTextField="sDescription" DataValueField="iIdAffectationType" Width="300px"
                                                                        Skin="Vista">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td align="right">
                                                                    <telerik:RadButton Skin="Windows7" ID="btnAddPartList_Panel" runat="server" Text="Agregar Lista Parte"
                                                                        OnClick="btnAddPartList_Panel_Click">
                                                                    </telerik:RadButton>
                                                                    <telerik:RadButton Skin="Windows7" ID="btnCancelExchangePartList" runat="server"
                                                                        OnClick="btnCancelExchangePartList_Click" Text="Cancel">
                                                                    </telerik:RadButton>
                                                                    <telerik:RadButton Skin="Windows7" ID="btnAddListPartExchange" runat="server" OnClick="btnAddListPartExchange_Click"
                                                                        Text="Agregar">
                                                                    </telerik:RadButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="15px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="pnPartListAdd" runat="server" Visible="False">
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td width="100px">
                                                                        <asp:Label ID="lblDescriptionPartList" runat="server" Text="Descripción:"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadTextBox Skin="WebBlue" ID="txtDescriptionPartList" runat="server" MaxLength="50"
                                                                            Width="90%">
                                                                        </telerik:RadTextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblNumberPartList" runat="server" Text="No. Parte Bocar:"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadTextBox Skin="WebBlue" ID="txtNumberPartList" runat="server" MaxLength="20"
                                                                            Width="200px">
                                                                        </telerik:RadTextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblNumberPartListClient" runat="server" Text="No. Parte Cliente:"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadTextBox Skin="WebBlue" ID="txtNumberPartListClient" runat="server" MaxLength="20"
                                                                            Width="200px">
                                                                        </telerik:RadTextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td align="right">
                                                                        <telerik:RadButton Skin="Windows7" ID="btnAddCancelPartList" runat="server" OnClick="btnAddCancelPartList_Click"
                                                                            Text="Cancelar" />
                                                                        <telerik:RadButton Skin="Windows7" ID="btnAddListPart" runat="server" OnClick="btnAddPartList_Click"
                                                                            Text="Agregar" Visible="False" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="25%">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%">
                                <asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300" Visible="False"></asp:Label>
                                <asp:Label ID="lblPartList" runat="server" Text="0" Visible="False"></asp:Label>
                                <asp:Label ID="lblIdExchange" runat="server" Text="0" Visible="False"></asp:Label>
                                <asp:Label ID="lblReviewExchange" runat="server" Text="0" Visible="False"></asp:Label>
                                <asp:Label ID="lblIdTaskT" runat="server" Text="0" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </telerik:RadAjaxPanel>
    <asp:SqlDataSource ID="sqlDSPartListExchange" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_SelectPartListExchangeById" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="fiid_Exchange" QueryStringField="ex"
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSddlPartList" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectddlPartList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSReviewTypeExchange" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectReviewExchangeByIdExchange" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblIdExchange" DefaultValue="0" Name="fiid_Exchange"
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSExchangeTask" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectExchangeTaskByIdExchange" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblIdExchange" DefaultValue="0" Name="fiid_Exchange"
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSAPartListExchangeC" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_SelectDiscPartListExchangeById" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblIdExchange" DefaultValue="0" Name="fiid_Exchange"
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSAffectationType" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectAffectationType" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
</asp:Content>
