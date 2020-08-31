<%@ Page Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true"
    CodeFile="Security.aspx.cs" Inherits="Security" Title="Seguridad" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="UsrCtrls/RolDetail.ascx" TagName="RolDetail" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnablePageHeadUpdate="False">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="comboModulo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvPagina" 
                        LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="gvUsers">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvUsers" />
                    <telerik:AjaxUpdatedControl ControlID="txtNameUser" />
                    <telerik:AjaxUpdatedControl ControlID="txtPassword" />
                    <telerik:AjaxUpdatedControl ControlID="comboEmpleado" />
                    <telerik:AjaxUpdatedControl ControlID="comboRol" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnUserAceptar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvUsers" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="txtNameUser" />
                    <telerik:AjaxUpdatedControl ControlID="txtPassword" />
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <table style="border-width: thin; border-style: none; width: 100%; vertical-align: top;
        text-align: center;">
        <tr>
            <td style="vertical-align: top; text-align: left; border-right-style: groove; border-right-width: 2px;"
                width="270px">
                <asp:Menu ID="menuSecurity" runat="server" BackColor="#B5C7DE" Font-Names="Verdana"
                    Font-Size="XX-Small" ForeColor="#284E98" OnMenuItemClick="menuSecurity_MenuItemClick"
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
            <td style="vertical-align: top">
                <table style="border-width: thin; border-style: none; width: 100%; vertical-align: top;
                    text-align: center;">
                    <tr>
                        <td height="30px">
                            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="#4B4B4B"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadMultiPage ID="MultiPage_Seguridad" runat="server" RenderSelectedPageOnly="True">
                                <telerik:RadPageView ID="pnRol" runat="server">
                                    <table width="100%" style="vertical-align: top; text-align: center; border-style: none">
                                        <tr>
                                            <td align="center">
                                                <table align="left" style="width: 100%;">
                                                    <tr>
                                                        <td width="50%" align="center">
                                                            <telerik:RadGrid ID='gvRol' runat="server" AllowPaging="True" AllowSorting="True"
                                                                AutoGenerateColumns="False" CellSpacing="0" GridLines="None" 
                                                                Skin="WebBlue" DataSourceID="sqlDSRol"
                                                                OnItemCommand="gvRol_ItemCommand" Width="350px" 
                                                                onpageindexchanged="gvRol_PageIndexChanged">
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
                                                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="" UniqueName="TemplateColumn">
                                                                            <ItemStyle HorizontalAlign="Center" Width="80" />
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ibtnFolio" runat="server" AlternateText="" CommandName="detailId"
                                                                                    ImageUrl="~/Img/msg-info.png" Width="21" Height="21" />
                                                                                <asp:ImageButton ID="ibtnEdit" runat="server" AlternateText="" CommandName="editId"
                                                                                    ImageUrl="~/Img/verde.png" Width="21" Height="21" />
                                                                                <asp:ImageButton ID="ibtnDelete" runat="server" AlternateText="" CommandName="deleteId"
                                                                                    ImageUrl="~/Img/rojo.png" Width="21" Height="21" OnClientClick="return confirm('¿Confirma que desea eliminar el registro seleccionado?');" />
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridBoundColumn DataField="Id" HeaderText="" ReadOnly="true" Visible="false">
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="sDescription" HeaderText="Perfil de Usuario"
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
                                                        </td>
                                                        <td width="50%" align="left">
                                                            <uc1:RolDetail ID="RolDetail1" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <table align="left" style="width: 100%;">
                                                    <tr>
                                                        <td width="20%" align="left">
                                                            <asp:Label ID="Label20" runat="server" Text="Descripción:"></asp:Label>
                                                        </td>
                                                        <td width="80%" align="left">
                                                            <asp:TextBox ID="txtRol" runat="server" MaxLength="50" Width="90%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%" align="left">
                                                            <asp:Label ID="Label1" runat="server" Text="Menu:"></asp:Label>
                                                        </td>
                                                        <td width="80%" align="left">
                                                            <div align="left" style="width: 100%;">
                                                                <div style="width: 20%" align="left">
                                                                    <telerik:RadComboBox ID="comboModulo" runat="server" DataSourceID="sqlDSMenu" Skin="Vista"
                                                                        DataTextField="sDescription" DataValueField="Id" AutoPostBack="True" Width="300px"
                                                                        OnSelectedIndexChanged="comboMenuH_SelectedIndexChanged">
                                                                    </telerik:RadComboBox>
                                                                </div>
                                                                <div>
                                                                    <telerik:RadGrid ID="gvPagina" runat="server" AllowPaging="True" AllowSorting="True"
                                                                        AutoGenerateColumns="False" CellSpacing="0" GridLines="Horizontal" Skin="WebBlue"
                                                                        Culture="es-MX" Width="400px" PageSize="15">
                                                                        <ClientSettings>
                                                                            <Selecting AllowRowSelect="True" />
                                                                            <Selecting AllowRowSelect="True"></Selecting>
                                                                        </ClientSettings>
                                                                        <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                                                        <MasterTableView>
                                                                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                                                <HeaderStyle Width="20px"></HeaderStyle>
                                                                            </RowIndicatorColumn>
                                                                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                                                <HeaderStyle Width="20px"></HeaderStyle>
                                                                            </ExpandCollapseColumn>
                                                                            <Columns>
                                                                                <telerik:GridTemplateColumn DataField="Id" AllowFiltering="false" HeaderText="" UniqueName="TemplateColumn">
                                                                                    <ItemStyle HorizontalAlign="Center" Width="50" />
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="CheckBox1" runat="server" /></ItemTemplate>
                                                                                </telerik:GridTemplateColumn>
                                                                                <telerik:GridBoundColumn DataField="Id" HeaderText="" ReadOnly="true" Visible="false">
                                                                                </telerik:GridBoundColumn>
                                                                                <telerik:GridBoundColumn DataField="sDescription" HeaderText="Pagina" ReadOnly="true">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                </telerik:GridBoundColumn>
                                                                            </Columns>
                                                                            <EditFormSettings>
                                                                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                                                </EditColumn>
                                                                            </EditFormSettings>
                                                                        </MasterTableView><HeaderStyle Font-Names="Verdana" Font-Size="X-Small" HorizontalAlign="Left" />
                                                                        <ItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                                                        <FilterMenu EnableImageSprites="False" Skin="Web20">
                                                                        </FilterMenu>
                                                                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                                                        </HeaderContextMenu>
                                                                    </telerik:RadGrid>
                                                                </div>
                                                                <div style="width: 20%" align="left">
                                                                    <asp:RadioButtonList ID="btnPermisos" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="100" Selected="True">Lectura</asp:ListItem>
                                                                        <asp:ListItem Value="110">Escritura</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &#160;&nbsp;
                                                        </td>
                                                        <td align="right">
                                                            <telerik:RadButton ID="btnCancelDesc" runat="server" Text="Cancelar" OnClick="btnCancelDesc_Click"
                                                                Skin="WebBlue">
                                                            </telerik:RadButton>
                                                            <telerik:RadButton ID="btnAddDesc" runat="server" Text="Guardar" OnClick="btnAddDesc_Click"
                                                                Skin="WebBlue">
                                                            </telerik:RadButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="pnUser" runat="server">
                                    <telerik:RadGrid ID="gvUsers" runat="server" AllowFilteringByColumn="True" AllowPaging="True"
                                        AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" GridLines="None"
                                        ShowGroupPanel="True" Skin="WebBlue" OnItemCommand="gvUsers_ItemCommand" Style="margin-top: 0px"
                                        DataSourceID="sqlDSUsuarios" PageSize="5">
                                        <ClientSettings AllowDragToGroup="True">
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>
                                        <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                        <MasterTableView DataSourceID="sqlDSUsuarios">
                                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                <HeaderStyle Width="20px" />
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                <HeaderStyle Width="20px" />
                                            </ExpandCollapseColumn>
                                            <Columns>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="" UniqueName="TemplateColumn">
                                                    <ItemStyle HorizontalAlign="Center" Width="60" />
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibtnEdit" runat="server" AlternateText="" CommandName="editId"
                                                            ImageUrl="~/Img/verde.png" Width="21" Height="21" />
                                                        <asp:ImageButton ID="ibtnDelete" runat="server" AlternateText="" CommandName="deleteId"
                                                            ImageUrl="~/Img/rojo.png" Width="21" Height="21" OnClientClick="return confirm('¿Confirma que desea eliminar el registro seleccionado?');" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="fiid_user" HeaderText="" ReadOnly="true" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="fiid_employed" HeaderText="" ReadOnly="true"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="fiRol" HeaderText="" ReadOnly="true" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="fvuser_name" HeaderText="Nombre de Usuario" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Nombre" HeaderText="Empleado" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="emailEmpleado" HeaderText="eMail Empleado" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="RolDesc" HeaderText="Rol Asignado" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Area" HeaderText="Area" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="VigenteEmpleado" HeaderText="Empleado Vigente"
                                                    ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FechaRegEmp" HeaderText="Fecha de Reg Empleado"
                                                    ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FechaRegUser" HeaderText="Fecha de Registro"
                                                    ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FechaUltMod" HeaderText="Fecha de Modificacion"
                                                    ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Bloqueado" HeaderText="Bloqueado" ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                </EditColumn>
                                            </EditFormSettings>
                                        </MasterTableView><HeaderStyle Font-Size="X-Small" Font-Names="Verdana" />
                                        <ItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                        <FilterMenu EnableImageSprites="False">
                                        </FilterMenu>
                                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid><asp:Panel ID="pnUserAdd" runat="server" Width="100%">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td align="right" style="width: 120">
                                                    <asp:Label ID="lblNameUser" runat="server" Text="Usuario:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadTextBox ID="txtNameUser" runat="server" MaxLength="30" Width="300px"
                                                        EmptyMessage="Nombre de Usuario" Skin="Windows7">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 120">
                                                    <asp:Label ID="lblPassword" runat="server" Text="Contraseña:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadTextBox ID="txtPassword" runat="server" MaxLength="40" Width="300px"
                                                        EmptyMessage="Contraseña" Skin="Windows7">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 120">
                                                    <asp:Label ID="lblEmployed" runat="server" Text="Empleado:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadComboBox ID="comboEmpleado" runat="server" Skin="Windows7" DataTextField="sNameComplete"
                                                        DataValueField="fiid_employed" AutoPostBack="True" EmptyMessage="Usuario Asignado"
                                                        EnableVirtualScrolling="True">
                                                    </telerik:RadComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 120">
                                                    <asp:Label ID="lblStatus" runat="server" Text="Estado:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:CheckBox ID="chkStatus" Text="Bloqueado" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 120px">
                                                    <asp:Label ID="Label8" runat="server" Text="Rol:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadComboBox ID="comboRol" runat="server" Skin="Windows7" DataSourceID="sqlDSRol"
                                                        DataTextField="sDescription" DataValueField="Id">
                                                    </telerik:RadComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &#160;&nbsp;
                                                </td>
                                                <td align="left">
                                                    <telerik:RadButton ID="btnUserCancel" runat="server" OnClick="btnAddUserCancel_Click"
                                                        Skin="Vista" Text="Cancelar">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnUserAceptar" runat="server" OnClick="btnAddUserAdd_Click"
                                                        Skin="Vista" Text="Aceptar">
                                                    </telerik:RadButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
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
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="sqlDSUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectUserAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSRol" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectRol" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSArea" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectArea" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSMenu" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectMenu" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
