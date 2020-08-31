<%@ Page Title="" Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true"
    CodeFile="Manager.aspx.cs" Inherits="Manager" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2012.1.215.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnablePageHeadUpdate="False">
    </telerik:RadAjaxManager>
    <table style="border-width: thin; border-style: none; width: 100%; vertical-align: top;
        text-align: center;">
        <tr>
            <td height="30px">
                <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="#4B4B4B"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="gvConfigs" runat="server" llowPaging="True" AllowSorting="True"
                    DataSourceID="sqlDSConfiguracion" AutoGenerateColumns="False" CellSpacing="0"
                    GridLines="None" Skin="Transparent" Width="850px" AllowFilteringByColumn="True" AllowPaging="True"
                    ShowGroupPanel="True" OnItemCommand="gvConfigs_ItemCommand">
                    <ClientSettings AllowDragToGroup="True">
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
                                    <asp:ImageButton ID="ibtnDelete" runat="server" AlternateText="" CommandName="deleteId"
                                        ImageUrl="~/Img/rojo.png" Width="21" Height="21" OnClientClick="return confirm('¿Confirma que desea eliminar el registro seleccionado?');" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Configuracion" HeaderText="" ReadOnly="true"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Modulo" HeaderText="Módulo" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Etapa" HeaderText="Etapa" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Area" HeaderText="Área" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Empleado" HeaderText="Empleado" ReadOnly="true">
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
            <td>
                <table align="left" style="width: 100%;">
                    <tr>
                        <td colspan="2" align="left">
                            <fieldset>
                                <legend>Módulo:</legend>
                                <br />
                                <telerik:RadComboBox ID="comboModulo" runat="server" DataSourceID="sqlDSMenu" Skin="Vista"
                                    DataTextField="sDescription" DataValueField="Id" AutoPostBack="True" Width="300px">
                                </telerik:RadComboBox>
                            </fieldset>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            <fieldset>
                                <legend>Etapa:</legend>
                                <br />
                                <telerik:RadGrid ID='gvEtapa' runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Skin="Transparent" Width="350px"
                                    DataSourceID="sqlDSMenuView">
                                    <ClientSettings>
                                        <Selecting AllowRowSelect="True" />
                                    </ClientSettings>
                                    <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                    <MasterTableView DataSourceID="sqlDSMenuView">
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Seleccionar" UniqueName="TemplateColumn">
                                                <ItemStyle HorizontalAlign="Center" Width="50" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="Id" HeaderText="" ReadOnly="true" Visible="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="sDescription" HeaderText="Página" ReadOnly="true">
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
                                <br />
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <fieldset>
                                <legend>Envio de Mensaje por Área:</legend>
                                <br />
                                <telerik:RadGrid ID='gvArea' runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CellSpacing="0" GridLines="None" DataSourceID="sqlDSArea"
                                    Skin="Transparent" Width="350px">
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
                                            <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Seleccionar" UniqueName="TemplateColumn">
                                                <ItemStyle HorizontalAlign="Center" Width="50" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="Id" HeaderText="" ReadOnly="true" Visible="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="sDescription" HeaderText="Área" ReadOnly="true">
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
                                <br />
                            </fieldset>
                        </td>
                        <td align="left">
                            <fieldset>
                                <legend>Envio de Mensaje por Usuario:</legend>
                                <br />
                                <telerik:RadGrid ID='gvUsers' runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Skin="Transparent" DataSourceID="sqlDSUsuarios"
                                    Width="350px">
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
                                            <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Seleccionar" UniqueName="TemplateColumn">
                                                <ItemStyle HorizontalAlign="Center" Width="50" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="fiid_user" HeaderText="" ReadOnly="true" Visible="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Nombre" HeaderText="Nombre de Usuario" ReadOnly="true">
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
                                <br />
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            <telerik:RadButton ID="btnConfigCancel" runat="server" Skin="Vista" Text="Cancelar"
                                OnClick="btnConfigCancel_Click">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btnConfigAceptar" runat="server" Skin="Vista" Text="Aceptar"
                                OnClick="btnConfigAceptar_Click">
                            </telerik:RadButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300" Visible="False"></asp:Label>
                <br />
                <asp:Label ID="lblIdEntity" runat="server" Text="0" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="sqlDSUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectUserAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSArea" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectAreaCatalogo" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSMenu" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectModuloBuzon" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSMenuView" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectEtapaBuzon" runat="server" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="comboModulo" Name="fiMenu" PropertyName="SelectedValue"
                Type="Int16" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSConfiguracion" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectConfigBuzon" runat="server" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
</asp:Content>
