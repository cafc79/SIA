<%@ Page Title="Buzón" Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="Buzon.aspx.cs" Inherits="Buzon" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1">
    </telerik:RadScriptManager>
    <asp:HiddenField ID="Usuario" Value="1" runat="server" />
    <table style="border-width: thin; border-style: none; width: 100%; vertical-align: top;
        text-align: center;">
        <tr>
            <td style="vertical-align: top; text-align: left; border-right-style: groove; border-right-width: 2px;"
                width="190px">
                <asp:Menu ID="menuSolicitud" runat="server" BackColor="#B5C7DE" Font-Names="Verdana"
                    Font-Size="XX-Small" ForeColor="#284E98" StaticSubMenuIndent="10px" Width="148px"
                    Enabled="False">
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
                <div class="deneb">
                    <fieldset>
                        <legend>Folio:</legend>
                        <div id="search">
                            <table>
                                <tr>
                                    <td>
                                        <telerik:RadTextBox ID="txtSrchFolio" runat="server" Skin="WebBlue" Width="280px">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="imbSerach" runat="server" ImageUrl="~/Img/btn_search.gif" ToolTip="Ejecutar Búsqueda" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnDisplayOpSearch" runat="server" ImageUrl="~/Img/FlechaDer.jpg"
                                            Height="24px" ToolTip="Mostrar opciones de búsqueda" />
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rbListOpSearch" runat="server" AutoPostBack="True" Font-Size="X-Small"
                                            RepeatDirection="Horizontal" Visible="False">
                                            <asp:ListItem Value="1" Selected="True">Ambos</asp:ListItem>
                                            <asp:ListItem Value="2">Mensajes Pendientes</asp:ListItem>
                                            <asp:ListItem Value="3">Mensajes del Mes</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnHideOpSearch" runat="server" ImageUrl="~/Img/Flechaizq.jpg"
                                            Height="24px" ToolTip="Ocultar opciones de búsqueda" Visible="False" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />
                        <div>
                            <telerik:RadGrid ID="gridMessage" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CellSpacing="0" GridLines="None" ShowGroupPanel="True"
                                Skin="WebBlue" DataSourceID="sqlDSMessages">
                                <ClientSettings AllowDragToGroup="True">
                                    <Selecting AllowRowSelect="True" />
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
                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="" DataField="IdMensaje"
                                            UniqueName="TemplateColumn">
                                            <ItemStyle HorizontalAlign="Center" Width="50" />
                                            <ItemTemplate>
                                                <asp:Panel ID="Panel1" runat="server">
                                                    <asp:ImageButton ID="ibtnEdit" runat="server" AlternateText="" OnClick="imbDelete_Click"
                                                        Height="22" ImageUrl="~/Img/Mail_Closed.png" Width="22" />
                                                    <asp:ImageButton ID="ibtnDelete" runat="server" AlternateText="" 
                                                        Height="22" ImageUrl="~/Img/remove.png" Width="22" OnClick="imbSearch_Click" />
                                                </asp:Panel>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn ReadOnly="true" Visible="false" DataField="IdMensaje"></telerik:GridBoundColumn>
																				<telerik:GridBoundColumn ReadOnly="true" Visible="false" DataField="IdFolio"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn ReadOnly="true" Visible="false" DataField="IdEtapa"></telerik:GridBoundColumn>
																				<telerik:GridBoundColumn ReadOnly="true" Visible="false" DataField="IdUsuario"></telerik:GridBoundColumn>
																				<telerik:GridBoundColumn ReadOnly="true" Visible="false" DataField="Pagina"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Folio" HeaderText="Folio" ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PreFolio" HeaderText="PreFolio" ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Descripcion" HeaderText="Descripción" ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Area" HeaderText="Area" ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Etapa" HeaderText="Estatus" ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="fvuser_name" HeaderText="Usuario" ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Hito" HeaderText="In" ReadOnly="true">
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
                        </div>
                        <br />
                    </fieldset>
                </div>
            </td>
        </tr>
    </table>
		<asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300" Visible="False"></asp:Label>
    <asp:SqlDataSource ID="sqlDSMessages" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectGetMessages" runat="server" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="Usuario" Name="iUsuario" PropertyName="Value" Type="Int32"
                DefaultValue="1" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
