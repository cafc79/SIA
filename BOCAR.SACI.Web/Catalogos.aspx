<%@ Page Title="Catalogos del Sistema" Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true" EnableEventValidation="false"
	CodeFile="Catalogos.aspx.cs" Inherits="Catalogos" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnablePageHeadUpdate="False">
		<AjaxSettings>
			<telerik:AjaxSetting AjaxControlID="menuCatalog">
				<UpdatedControls>
					<telerik:AjaxUpdatedControl ControlID="lblTitle" LoadingPanelID="RadAjaxLoadingPanel1" />
					<telerik:AjaxUpdatedControl ControlID="RadMultiPage1" LoadingPanelID="RadAjaxLoadingPanel1" />
					<telerik:AjaxUpdatedControl ControlID="lblMessage" />
				</UpdatedControls>
			</telerik:AjaxSetting>
			<telerik:AjaxSetting AjaxControlID="gridDescripcion">
				<UpdatedControls>
					<telerik:AjaxUpdatedControl ControlID="gridDescripcion" LoadingPanelID="RadAjaxLoadingPanel1" />
					<telerik:AjaxUpdatedControl ControlID="pnDescription" />
					<telerik:AjaxUpdatedControl ControlID="lblMessage" />
				</UpdatedControls>
			</telerik:AjaxSetting>
			<telerik:AjaxSetting AjaxControlID="btnAddDesc">
				<UpdatedControls>
					<telerik:AjaxUpdatedControl ControlID="gridDescripcion" LoadingPanelID="RadAjaxLoadingPanel1" />
					<telerik:AjaxUpdatedControl ControlID="pnDescription" />
					<telerik:AjaxUpdatedControl ControlID="lblMessage" />
				</UpdatedControls>
			</telerik:AjaxSetting>
			<telerik:AjaxSetting AjaxControlID="gridDescValue">
				<UpdatedControls>
					<telerik:AjaxUpdatedControl ControlID="gridDescValue" LoadingPanelID="RadAjaxLoadingPanel1" />
					<telerik:AjaxUpdatedControl ControlID="pnKeyValue" />
					<telerik:AjaxUpdatedControl ControlID="lblMessage" />
				</UpdatedControls>
			</telerik:AjaxSetting>
			<telerik:AjaxSetting AjaxControlID="btnAddKV">
				<UpdatedControls>
					<telerik:AjaxUpdatedControl ControlID="gridDescValue" 
						LoadingPanelID="RadAjaxLoadingPanel1" />
					<telerik:AjaxUpdatedControl ControlID="pnKeyValue" />
					<telerik:AjaxUpdatedControl ControlID="lblMessage" />
				</UpdatedControls>
			</telerik:AjaxSetting>
			<telerik:AjaxSetting AjaxControlID="gridTriara">
				<UpdatedControls>
					<telerik:AjaxUpdatedControl ControlID="gridTriara" LoadingPanelID="RadAjaxLoadingPanel1" />
					<telerik:AjaxUpdatedControl ControlID="pnTriara" LoadingPanelID="RadAjaxLoadingPanel1" />
					<telerik:AjaxUpdatedControl ControlID="lblMessage" />
				</UpdatedControls>
			</telerik:AjaxSetting>
			<telerik:AjaxSetting AjaxControlID="btnAddTriara">
				<UpdatedControls>
					<telerik:AjaxUpdatedControl ControlID="gridTriara" LoadingPanelID="RadAjaxLoadingPanel1" /> 
                    <telerik:AjaxUpdatedControl ControlID="pnTriara" LoadingPanelID="RadAjaxLoadingPanel1" />
					<telerik:AjaxUpdatedControl ControlID="lblMessage"/>
				</UpdatedControls>
			</telerik:AjaxSetting>
			<telerik:AjaxSetting AjaxControlID="gridEmpleado">
				<UpdatedControls>
					<telerik:AjaxUpdatedControl ControlID="gridEmpleado" 
						LoadingPanelID="RadAjaxLoadingPanel1" />
					<telerik:AjaxUpdatedControl ControlID="pnEmployed" />
					<telerik:AjaxUpdatedControl ControlID="lblMessage" />
				</UpdatedControls>
			</telerik:AjaxSetting>
			<telerik:AjaxSetting AjaxControlID="ddlArea">
				<UpdatedControls>
					<telerik:AjaxUpdatedControl ControlID="ddlBoss" />
				</UpdatedControls>
			</telerik:AjaxSetting>
			<telerik:AjaxSetting AjaxControlID="ddlBoss">
				<UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlBoss" />
				</UpdatedControls>
			</telerik:AjaxSetting>
			<telerik:AjaxSetting AjaxControlID="ddlSubstitute">
				<UpdatedControls>
					<telerik:AjaxUpdatedControl ControlID="ddlSubstitute" />
				</UpdatedControls>
			</telerik:AjaxSetting>
			<telerik:AjaxSetting AjaxControlID="btnAddEmployed">
				<UpdatedControls>
					<telerik:AjaxUpdatedControl ControlID="gridEmpleado" LoadingPanelID="RadAjaxLoadingPanel1" />
					<telerik:AjaxUpdatedControl ControlID="pnEmployed" />
					<telerik:AjaxUpdatedControl ControlID="lblMessage" />
				</UpdatedControls>
			</telerik:AjaxSetting>
		</AjaxSettings>
	</telerik:RadAjaxManager>
	<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
	<table style="border-width: thin; border-style: none; width: 100%; vertical-align: top;
		text-align: center;">
		<tr>
			<td style="vertical-align: top; text-align: left; border-right-style: groove; border-right-width: 2px;"
				width="270px">
				<asp:Menu ID="menuCatalog" runat="server" BackColor="#B5C7DE" Font-Names="Verdana"
					Font-Size="X-Small" ForeColor="#284E98" OnMenuItemClick="menuCatalog_MenuItemClick"
					StaticSubMenuIndent="10px" Width="148px">
					<StaticSelectedStyle BackColor="#FF6600" BorderColor="#9999FF" />
					<StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
					<DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
					<DynamicMenuStyle BackColor="#B5C7DE" />
					<DynamicSelectedStyle BackColor="#507CD1" />
					<DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
					<StaticHoverStyle BackColor="#284E98" ForeColor="White" />
				</asp:Menu>
			</td>
			<td>
				<asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="#4B4B4B"></asp:Label>
				<br />
				<asp:Label ID="lblIdEntity" runat="server" Text="0" Visible="False"></asp:Label>
				<hr />
				<telerik:RadMultiPage ID="RadMultiPage1" runat="server">
					<telerik:RadPageView ID="RadPageView1" runat="server">
						<telerik:RadGrid ID="gridDescripcion" runat="server" AllowPaging="True" AllowSorting="True"
							AutoGenerateColumns="False" CellSpacing="0" GridLines="Horizontal" OnItemCommand="gridDescripcion_ItemCommand"
							Skin="WebBlue" ShowGroupPanel="True" AllowFilteringByColumn="True" Culture="es-MX">
							<ClientSettings AllowDragToGroup="True">
								<Selecting AllowRowSelect="True" />
								<Selecting AllowRowSelect="True"></Selecting>
							</ClientSettings>
                            <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
							<MasterTableView>
								<CommandItemSettings ExportToPdfText="Export to PDF" />
								<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
									<HeaderStyle Width="20px"></HeaderStyle>
								</RowIndicatorColumn>
								<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
									<HeaderStyle Width="20px"></HeaderStyle>
								</ExpandCollapseColumn>
								<Columns>
									<telerik:GridTemplateColumn AllowFiltering="false" HeaderText="" UniqueName="TemplateColumn">
										<ItemStyle HorizontalAlign="Center" Width="50" />
										<ItemTemplate>
											<asp:ImageButton ID="ibtnEdit" runat="server" AlternateText="Folio" CommandName="editId" ImageUrl="~/Img/verde.png" Width="22" Height="22"/>
                      <asp:ImageButton ID="ibtnDelete" runat="server" AlternateText="Folio" CommandName="deleteId" ImageUrl="~/Img/rojo.png" OnClientClick="return confirm('¿Confirma que desea eliminar el registro seleccionado? \n No se puede eliminar un registro cuyo valor sea referenciado a un folio activo!!!');" Width="22" Height="22"/>
										</ItemTemplate>
									</telerik:GridTemplateColumn>
									<telerik:GridBoundColumn DataField="Id" HeaderText="" ReadOnly="true" Visible="false">
									</telerik:GridBoundColumn>
									<telerik:GridBoundColumn DataField="sDescription" HeaderText="Descripción" ReadOnly="true">
										<HeaderStyle HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Left" />
									</telerik:GridBoundColumn>
								</Columns>
								<EditFormSettings>
									<EditColumn FilterControlAltText="Filter EditCommandColumn column">
									</EditColumn>
								</EditFormSettings>
							</MasterTableView>
              <HeaderStyle Font-Names="Verdana" Font-Size="X-Small" HorizontalAlign="Left" />
                            <ItemStyle Font-Names="Verdana" Font-Size="X-Small" />
              <FilterMenu EnableImageSprites="False" Skin="Web20">
							</FilterMenu>
							<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
							</HeaderContextMenu>
						</telerik:RadGrid><hr />
						<asp:Panel ID="pnDescription" runat="server" Width="100%">
							<table align="left" style="width: 100%;">
								<tr>
									<td width="20%" align="left">
										<asp:Label ID="Label20" runat="server" Text="Descripción:"></asp:Label>
									</td>
									<td width="80%" align="left">
										<asp:TextBox ID="txtDescription" runat="server" MaxLength="50" Width="90%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td>&nbsp;</td>
									<td align="right">
										<asp:Button ID="btnCancelDesc" runat="server" Text="Cancelar" OnClick="btnCancelDesc_Click" ></asp:Button>
										<asp:Button ID="btnAddDesc" runat="server" Text="Guardar" OnClick="btnAddDesc_Click"></asp:Button>
									</td>
								</tr>
							</table>
						</asp:Panel>
					</telerik:RadPageView>
					<telerik:RadPageView ID="RadPageView2" runat="server">
						<telerik:RadGrid ID="gridDescValue" runat="server" AllowPaging="True" AllowSorting="True"
							AutoGenerateColumns="False" CellSpacing="0" GridLines="Horizontal"
							OnItemCommand="gridDescValue_ItemCommand" Skin="WebBlue" ShowGroupPanel="True" 
							AllowFilteringByColumn="True" ondatabinding="gridDescValue_DataBinding">
							<ClientSettings AllowDragToGroup="True">
								<Selecting AllowRowSelect="True" />
								<Selecting AllowRowSelect="True" />
							</ClientSettings>
                            <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
							<MasterTableView>
								<CommandItemSettings ExportToPdfText="Export to PDF" />
								<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
									<HeaderStyle Width="20px"></HeaderStyle>
								</RowIndicatorColumn>
								<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
									<HeaderStyle Width="20px"></HeaderStyle>
								</ExpandCollapseColumn>
								<Columns>
									<telerik:GridTemplateColumn AllowFiltering="false" HeaderText="" UniqueName="TemplateColumn">
										<ItemStyle HorizontalAlign="Center" Width="50" />
										<ItemTemplate>
											<asp:ImageButton ID="ibtnEdit" runat="server" AlternateText="Folio" CommandName="editId" ImageUrl="~/Img/verde.png" Width="22" Height="22"/>
                      <asp:ImageButton ID="ibtnDelete" runat="server" AlternateText="Folio" CommandName="deleteId" ImageUrl="~/Img/rojo.png" OnClientClick="return confirm('¿Confirma que desea eliminar el registro seleccionado? No se puede eliminar un registro cuyo valor sea referenciado por un folio activo!!!');" Width="22" Height="22"  />
                                         </ItemTemplate>
									</telerik:GridTemplateColumn>
									<telerik:GridBoundColumn DataField="Id" HeaderText="Id" ReadOnly="true" Visible="false">
										<HeaderStyle HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Left" />
									</telerik:GridBoundColumn>
									<telerik:GridBoundColumn DataField="sDesc1" HeaderText="Descripción" ReadOnly="true">
										<HeaderStyle HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Left" />
									</telerik:GridBoundColumn>
									<telerik:GridBoundColumn DataField="sDesc2" HeaderText="Descripción" ReadOnly="true">
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
						</telerik:RadGrid><hr />
						<asp:Panel ID="pnKeyValue" runat="server" Width="100%">
							<table style="width: 100%;">
								<tr>
									<td width="20%" align="left">
										<asp:Label ID="lblDescriptionArea" runat="server" Text="Descripción:"></asp:Label>
									</td>
									<td width="80%" align="left">
										<asp:TextBox ID="txtDescriptionKV" runat="server" Width="90%"></asp:TextBox>
										<telerik:RadComboBox ID="ddlTaskTaskGroup" runat="server" 
											DataSourceID="sqlDSTask" DataTextField="sDescription"
											DataValueField="iIdTask" EnableLoadOnDemand="True" Width="300px" >
										</telerik:RadComboBox>
									</td>
								</tr>
								<tr>
									<td align="left">
										<asp:Label ID="lblNumberArea" runat="server" Text="Número:"></asp:Label>
									</td>
									<td align="left">
										<asp:TextBox ID="txtValueKV" runat="server" MaxLength="6" Width="100px"></asp:TextBox>
										<telerik:RadComboBox ID="ddlAreaTask" runat="server" DataSourceID="sqlDSArea" DataTextField="sDescription"
											DataValueField="iIdArea" EnableLoadOnDemand="True" Width="300px" >
										</telerik:RadComboBox>
										<telerik:RadComboBox ID="ddlGroupTaskGroup" runat="server" DataSourceID="sqlDSGroup"
											DataTextField="sDescription" DataValueField="iIdGroup" EnableLoadOnDemand="True" 
											Width="300px" >
										</telerik:RadComboBox>
									</td>
								</tr>
								<tr>
									<td>&nbsp;</td>
									<td align="right">
										<asp:Button ID="btnCancelKV" runat="server" Text="Cancelar" OnClick="btnCancelKV_Click" />
                                        <asp:Button ID="btnAddKV" runat="server" Text="Guardar" OnClick="btnAddKV_Click" />
									</td>
								</tr>
							</table>
						</asp:Panel>
					</telerik:RadPageView>
					<telerik:RadPageView ID="RadPageView3" runat="server">
						<telerik:RadGrid ID="gridTriara" runat="server" AllowPaging="True"
							AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" GridLines="Horizontal"
							OnItemCommand="gridTriara_ItemCommand" Skin="WebBlue" ShowGroupPanel="True" 
							AllowFilteringByColumn="True" ondatabinding="gridTriara_DataBinding">
							<ClientSettings AllowDragToGroup="True">
								<Selecting AllowRowSelect="True" />
								<Selecting AllowRowSelect="True" />
							</ClientSettings>
                            <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
							<MasterTableView>
								<CommandItemSettings ExportToPdfText="Export to PDF" />
								<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
									<HeaderStyle Width="20px"></HeaderStyle>
								</RowIndicatorColumn>
								<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
									<HeaderStyle Width="20px"></HeaderStyle>
								</ExpandCollapseColumn>
								<Columns>
									<telerik:GridTemplateColumn AllowFiltering="false" HeaderText="" UniqueName="TemplateColumn">
										<ItemStyle HorizontalAlign="Center" Width="50" />
										<ItemTemplate>
											<asp:ImageButton ID="ibtnEdit" runat="server" AlternateText="Folio" CommandName="editId" ImageUrl="~/Img/verde.png" Width="22" Height="22"/>
                      <asp:ImageButton ID="ibtnDelete" runat="server" AlternateText="Folio" CommandName="deleteId" ImageUrl="~/Img/rojo.png" OnClientClick="return confirm('¿Confirma que desea eliminar el registro seleccionado? No se puede eliminar un registro cuyo valor sea referenciado por un folio activo!!!');" Width="22" Height="22" />
                                        </ItemTemplate>
									</telerik:GridTemplateColumn>
									<telerik:GridBoundColumn DataField="Id" HeaderText="Id" ReadOnly="true" Visible="false">
										<HeaderStyle HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Left" />
									</telerik:GridBoundColumn>
									<telerik:GridBoundColumn DataField="sDesc1" HeaderText="Descripción" ReadOnly="true">
										<HeaderStyle HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Left" />
									</telerik:GridBoundColumn>
									<telerik:GridBoundColumn DataField="sDesc2" HeaderText="Descripción" ReadOnly="true">
										<HeaderStyle HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Left" />
									</telerik:GridBoundColumn>
									<telerik:GridBoundColumn DataField="sDesc3" HeaderText="Descripción" ReadOnly="true">
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
						</telerik:RadGrid><hr />
						<asp:Panel ID="pnTriara" runat="server">
							<table style="width: 100%;">
								<tr>
									<td width="20%" align="left">
										<asp:Label ID="lblDescriptionPartList" runat="server" Text="Descripción:"></asp:Label>
									</td>
									<td width="80%" align="left">
										<asp:TextBox ID="txtDescriptionTriara" runat="server" MaxLength="50" Width="90%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td align="left">
										<asp:Label ID="lblNumberPartList" runat="server" Text="No. Parte Bocar:"></asp:Label>
									</td>
									<td align="left">
										<asp:TextBox ID="txtNumberPartList" runat="server" MaxLength="20" Width="200px"></asp:TextBox>										
										<telerik:RadComboBox ID="ddl_Triara1" runat="server" 
											DataSourceID="sqlDSTask" DataTextField="sDescription"
											DataValueField="iIdTask" AutoPostBack="True" 
											EnableVirtualScrolling="True" EnableLoadOnDemand="True" Width="300px" >
										</telerik:RadComboBox>
									</td>
								</tr>
								<tr>
									<td align="left">
										<asp:Label ID="lblNumberPartListClient" runat="server" Text="No. Parte Cliente:"></asp:Label>
									</td>
									<td align="left">
										<asp:TextBox ID="txtNumberPartListClient" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
										<telerik:RadComboBox ID="ddl_Triara2" runat="server" Width="300px" DataSourceID="sqlDSDataType" DataTextField="sDescription" DataValueField="iIdDataType">
										</telerik:RadComboBox>
									    <telerik:RadComboBox ID="ddl_Triara3" runat="server" Width="300px" 
                                            DataTextField="sCompleteName" DataValueField="Id" DataSourceID="sqlDSEmployed" 
                                            AutoPostBack="True">
                                        </telerik:RadComboBox>
									</td>
								</tr>
								<tr>
									<td>&nbsp;</td>
									<td align="right">
										<asp:Button ID="btnCancelTriara" runat="server" OnClick="btnCancelTriara_Click" Text="Cancelar" />
                                        <asp:Button ID="btnAddTriara" runat="server" Text="Guardar" OnClick="btnAddTriara_Click" />
									</td>
								</tr>
							</table>
						</asp:Panel>
					</telerik:RadPageView>
					<telerik:RadPageView ID="RadPageView4" runat="server">
						<telerik:RadGrid ID="gridEmpleado" runat="server" AllowPaging="True"
							AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" GridLines="Horizontal"
							OnItemCommand="gridEmpleado_ItemCommand" Skin="WebBlue" ShowGroupPanel="True" 
							AllowFilteringByColumn="True">
							<ClientSettings AllowDragToGroup="True">
								<Selecting AllowRowSelect="True" />
								<Selecting AllowRowSelect="True" />
							</ClientSettings>
                            <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
							<MasterTableView>																
								<CommandItemSettings ExportToPdfText="Export to PDF" />
								<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
									<HeaderStyle Width="20px"></HeaderStyle>
								</RowIndicatorColumn>
								<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
									<HeaderStyle Width="20px"></HeaderStyle>
								</ExpandCollapseColumn>
								<Columns>
									<telerik:GridTemplateColumn AllowFiltering="false" HeaderText="" UniqueName="TemplateColumn">
										<ItemStyle HorizontalAlign="Center" Width="50" />
										<ItemTemplate>
											<asp:ImageButton ID="ibtnEdit" runat="server" AlternateText="Folio" CommandName="editId" ImageUrl="~/Img/verde.png" Width="22" Height="22"/>
                      <asp:ImageButton ID="ibtnDelete" runat="server" AlternateText="Folio" CommandName="deleteId" ImageUrl="~/Img/rojo.png" OnClientClick="return confirm('¿Confirma que desea eliminar el Empleado indicado?');" Width="22" Height="22"/>
                                        </ItemTemplate>
									</telerik:GridTemplateColumn>
									<telerik:GridBoundColumn DataField="Id" HeaderText="iIdEmployed" ReadOnly="true" Visible="false">
									</telerik:GridBoundColumn>
									<telerik:GridBoundColumn DataField="sCompleteName" HeaderText="Nombre" ReadOnly="true">
										<HeaderStyle HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Left" />
									</telerik:GridBoundColumn>
									<telerik:GridBoundColumn DataField="iNumber" HeaderText="Num Empleado" ReadOnly="true" >
									</telerik:GridBoundColumn>
									<telerik:GridBoundColumn DataField="sName" HeaderText="sName" ReadOnly="true" Visible="false">
									</telerik:GridBoundColumn>
									<telerik:GridBoundColumn DataField="sMLastName" HeaderText="sMLastName" ReadOnly="true"
										Visible="false">
									</telerik:GridBoundColumn>
									<telerik:GridBoundColumn DataField="sFLastName" HeaderText="sFLastName" ReadOnly="true"
										Visible="false">
									</telerik:GridBoundColumn>
									<telerik:GridBoundColumn DataField="sEMail" HeaderText="EMail" ReadOnly="true">
										<HeaderStyle HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Left" />
									</telerik:GridBoundColumn>
									<telerik:GridBoundColumn DataField="iStatus" HeaderText="iStatus" ReadOnly="true"
										Visible="false">
									</telerik:GridBoundColumn>
									<telerik:GridBoundColumn DataField="iIdArea" HeaderText="iIdArea" ReadOnly="true"
										Visible="false">
									</telerik:GridBoundColumn>
									<telerik:GridBoundColumn DataField="sDescriptionArea" HeaderText="Area" ReadOnly="true">
										<HeaderStyle HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Left" />
									</telerik:GridBoundColumn>
									<telerik:GridBoundColumn DataField="iIdPlant" HeaderText="iIdPlant" ReadOnly="true"
										Visible="false">
									</telerik:GridBoundColumn>
									<telerik:GridBoundColumn DataField="sBoss" HeaderText="Jefe" ReadOnly="true">
										<HeaderStyle HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Left" />
									</telerik:GridBoundColumn>
									<telerik:GridBoundColumn DataField="sSubstitute" HeaderText="Substituto" ReadOnly="true">
										<HeaderStyle HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Left" />
									</telerik:GridBoundColumn>
								</Columns>
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
						</telerik:RadGrid><hr />
						<asp:Panel ID="pnEmployed" runat="server" Width="100%">
							    <table style="width: 100%;">
								    <tr align="left">
									    <td width="20%">
										    <asp:Label ID="lblNumberEmployed" runat="server" Text="Número:"></asp:Label>
									    </td>
									    <td width="80%">
										    <telerik:RadMaskedTextBox ID="txtNumberEmployed" runat="server" EmptyMessage="Número de Empleado"
											    Mask="######" Skin="WebBlue" ToolTip="Número de Empleado" style="text-align: left">
										    </telerik:RadMaskedTextBox>
									    </td>
								    </tr>
								    <tr align="left">
									    <td>
										    <asp:Label ID="lblNameEmployed" runat="server" Text="Nombre:"></asp:Label>
									    </td>
									    <td>
										    <asp:TextBox ID="txtNameEmployed" runat="server" MaxLength="30" Width="300px"></asp:TextBox>
									    </td>
								    </tr>
								    <tr align="left">
									    <td>
										    <asp:Label ID="lblFatherLastName" runat="server" Text="Apellido Paterno:"></asp:Label>
									    </td>
									    <td>
										    <asp:TextBox ID="txtFatherLastName" runat="server" MaxLength="30" Width="300px"></asp:TextBox>
									    </td>
								    </tr>
								    <tr align="left">
									    <td>
										    <asp:Label ID="lblMotherLastName" runat="server" Text="Apellido Materno:"></asp:Label>
									    </td>
									    <td>
										    <asp:TextBox ID="txtMotherLastName" runat="server" MaxLength="30" Width="300px"></asp:TextBox>
									    </td>
								    </tr>
								    <tr align="left">
									    <td>
										    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
									    </td>
									    <td>
										    <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" Width="300px"></asp:TextBox>
									    </td>
								    </tr>
								    <tr align="left">
									    <td>
										    <asp:Label ID="lblArea" runat="server" Text="Area:"></asp:Label>
									    </td>
									    <td>
										    <telerik:RadComboBox ID="ddlArea" runat="server" DataSourceID="sqlDSArea" DataTextField="sDescription"
											    DataValueField="iIdArea" Width="300px" 
                                                onselectedindexchanged="ddlArea_SelectedIndexChanged" AutoPostBack="True" >
										    </telerik:RadComboBox>
									    </td>
								    </tr>
								    <tr align="left">
									    <td>
										    <asp:Label ID="lblPlant" runat="server" Text="Planta:"></asp:Label>
									    </td>
									    <td>
										    <telerik:RadComboBox ID="ddlPlant" runat="server" DataSourceID="sqlDSPlant" DataTextField="sDescription"
											    DataValueField="iIdPlant" EnableLoadOnDemand="True" Width="300px" >
										    </telerik:RadComboBox>
									    </td>
								    </tr>
								    <tr align="left">
									    <td>
										    <asp:Label ID="lblBoss" runat="server" Text="Jefe Directo:"></asp:Label>
									    </td>
									    <td>
										    <telerik:RadComboBox ID="ddlBoss" runat="server" Width="300px" AutoPostBack="True" 
											    DataTextField="sNameComplete" DataValueField="fiid_employed" 
                                                EmptyMessage="Jefe Asignado" EnableVirtualScrolling="True" >
										    </telerik:RadComboBox>
									    </td>
								    </tr>
								    <tr align="left">
									    <td>
										    <asp:Label ID="lblSubstitute" runat="server" Text="Suplente:"></asp:Label>
									    </td>
									    <td>
										    <telerik:RadComboBox ID="ddlSubstitute" runat="server" Width="300px" 
											    DataTextField="sNameComplete" DataValueField="fiid_employed" AutoPostBack="True" 
                                                EmptyMessage="Sustituto Asignado" 
													EnableVirtualScrolling="True" >
										    </telerik:RadComboBox>
									    </td>
								    </tr>
								    <tr>
									    <td>&nbsp;</td>
									    <td align="right">
										    <asp:Button ID="btnCancelEmployed" runat="server" OnClick="btnCancelEmployed_Click" Text="Cancelar"></asp:Button>
                                            <asp:Button ID="btnAddEmployed" runat="server" OnClick="btnAddEmployed_Click" Text="Guardar"></asp:Button>
									    </td>
								    </tr>
							    </table>
						</asp:Panel>
					</telerik:RadPageView>

				</telerik:RadMultiPage>
				<br />
				<asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300"></asp:Label>
			</td>
		</tr>
	</table>
    
    <!-- Controles de origenes de datos -->
    <asp:Panel ID="ctlsOrigen" runat="server">
	    <asp:SqlDataSource ID="sqlDSAffectationType" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
		    SelectCommand="sp_selectAffectationType" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
	    <asp:SqlDataSource ID="sqlDSClient" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
		    SelectCommand="sp_selectClient" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
	    <asp:SqlDataSource ID="sqlDSDataType" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
		    SelectCommand="sp_selectDataType" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
	    <asp:SqlDataSource ID="sqlDSGroup" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
		    SelectCommand="sp_selectGroup" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
	    <asp:SqlDataSource ID="sqlDSLockingType" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
		    SelectCommand="sp_selectLockingType" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
	    <asp:SqlDataSource ID="sqlDSPlant" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
		    SelectCommand="sp_selectPlant" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
	    <asp:SqlDataSource ID="sqlDSPriority" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
		    SelectCommand="sp_selectPriority" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
	    <asp:SqlDataSource ID="sqlDSReviewType" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
		    SelectCommand="sp_selectReviewType" SelectCommandType="StoredProcedure"></asp:SqlDataSource>	    
	    <asp:SqlDataSource ID="sqlDSArea" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
		    SelectCommand="sp_selectAreaCatalogo" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
	    <asp:SqlDataSource ID="sqlDSExchangeType" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
		    SelectCommand="sp_selectExchangeType" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
	    <asp:SqlDataSource ID="sqlDSTask" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
		    SelectCommand="sp_selectTask" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
	    <asp:SqlDataSource ID="sqlDSTaskGroup" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
		    SelectCommand="sp_selectTaskGroup" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
	    <asp:SqlDataSource ID="sqlDSPartList" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
		    SelectCommand="sp_selectPartList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
	    <asp:SqlDataSource ID="sqlDSTaskData" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
		    SelectCommand="sp_selectTaskData" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
	    <asp:SqlDataSource ID="sqlDSEmployed" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
		    SelectCommand="sp_selectEmployed" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sqlDSSalesAutorization" runat="server" 
			ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>" 
			SelectCommand="sp_selectSalesAutorization_Type" SelectCommandType="StoredProcedure">
		</asp:SqlDataSource>
    </asp:Panel>

</asp:Content>
