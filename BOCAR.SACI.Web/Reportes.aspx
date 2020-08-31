<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true"
	CodeFile="Reportes.aspx.cs" Inherits="Reportes" EnableEventValidation="false" %>

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
	<telerik:RadScriptManager runat="server" ID="RadScriptManager1">
	</telerik:RadScriptManager>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
		<ClientEvents OnRequestStart="onRequestStart" />
		<AjaxSettings>
			<telerik:AjaxSetting AjaxControlID="RadGrid1">
				<UpdatedControls>
					<telerik:AjaxUpdatedControl ControlID="RadGrid1" />
				</UpdatedControls>
			</telerik:AjaxSetting>
		</AjaxSettings>
	</telerik:RadAjaxManager>
	<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" AnimationDuration="10"
		EnableEmbeddedScripts="False" Skin="Web20" Transparency="25">
	</telerik:RadAjaxLoadingPanel>
	<table style="border-width: thin; border-style: none; width: 100%; vertical-align: top;
		text-align: center;">
		<tr>
			<td style="vertical-align: top; text-align: left; border-right-style: groove; border-right-width: 2px;"
				width="190px">
				<asp:Menu ID="menuReporte" runat="server" BackColor="#B5C7DE" Font-Names="Verdana"
					Font-Size="XX-Small" ForeColor="#284E98" StaticSubMenuIndent="10px" Width="148px"
					OnMenuItemClick="menuSolicitud_MenuItemClick">
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
						<legend>Exportar Datos:</legend>
						<div id="bmx" class="deneb">
							<table>
								<tr>
									<td colspan="4">
										<asp:CheckBox ID="CheckBox1" Text="Exportar solo datos" runat="server"></asp:CheckBox>
									</td>
								</tr>
								<tr>
									<td colspan="4">
										<asp:CheckBox ID="CheckBox2" Text="Exportar todas las paginas" runat="server"></asp:CheckBox>
									</td>
								</tr>
								<tr>
									<td colspan="4">
										<table>
											<tr>
												<td>
													<img alt="" src="Img/format_xlsx.png" />
													<telerik:RadButton ID="RadButton1" runat="server" Skin="Sitefinity" Width="120px"
														Text="Exportar a Excel" OnClick="Button1_Click" EnableBrowserButtonStyle="True"
														ButtonType="ToggleButton">
													</telerik:RadButton>
												</td>
												<td>
													<img alt="" src="Img/format_docx_mac.png" />
													<telerik:RadButton ID="RadButton2" runat="server" Skin="Default" Width="120px" Text="Exportar a Word"
														OnClick="Button2_Click" ButtonType="ToggleButton">
													</telerik:RadButton>
												</td>
												<td>
													<img alt="" src="Img/format_text.png" />
													<telerik:RadButton ID="RadButton3" runat="server" Skin="Default" Width="120px" Text="Exportar a CSV"
														OnClick="Button3_Click" ButtonType="ToggleButton">
													</telerik:RadButton>
												</td>
												<td>
													<img alt="" src="Img/format_pdf.png" />
													<telerik:RadButton ID="RadButton4" runat="server" Skin="Default" Width="120px" Text="Exportar a PDF"
														OnClick="Button4_Click" ButtonType="ToggleButton">
													</telerik:RadButton>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</div>
					</fieldset>
				</div>
				<div class="deneb">
					<telerik:RadMultiPage ID="rmpBusqueda" runat="server" Width="600" 
                        RenderSelectedPageOnly="True">
						<telerik:RadPageView ID="Pageview1" runat="server">
							<div id="box">
								 <table width="100%" style="vertical-align: top; border-style: none">
									<tr>
										<td align="right">
											<asp:Label ID="Label1" runat="server" Text="Área"></asp:Label>
										</td>
										<td align="left">
											<telerik:RadComboBox ID="ddlOpArea" runat="server" DataSourceID="sqlDSArea" Skin="Web20"
												DataTextField="sDescription" DataValueField="iIdArea">
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
											<telerik:RadButton ID="btnBusqueda_v1" runat="server" Text="Busqueda" Skin="Web20"
												OnClick="btnBusqueda_v1_Click">
											</telerik:RadButton>
										</td>
									</tr>
								</table>
							</div>
						</telerik:RadPageView>
						<telerik:RadPageView ID="Pageview2" runat="server">
							<div>
								<table width="100%" style="vertical-align: top; border-style: none">
									<tr>
										<td align="right">
											<asp:Label ID="Label6" runat="server" Text="Cliente"></asp:Label>
										</td>
										<td align="left">
											<telerik:RadComboBox ID="ddlCliente" runat="server" DataSourceID="sqlDSClient" Skin="Web20"
												DataTextField="sDescription" DataValueField="iIdClient" Width="300">
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
											<telerik:RadButton ID="btnBusqueda_v2" runat="server" Text="Busqueda" Skin="Web20"
												OnClick="btnBusqueda_v2_Click">
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
					<telerik:RadMultiPage ID="rmpDatos" runat="server" 
                        RenderSelectedPageOnly="True">
						<telerik:RadPageView ID="RadPageView1" runat="server">
							<telerik:RadGrid ID="repOperArea" runat="server" AllowPaging="True" AllowSorting="True"
								CellSpacing="0" GridLines="None" ShowGroupPanel="True" Skin="WebBlue" OnItemCommand="grid_ItemCommand"
								AutoGenerateColumns="False">
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
								CellSpacing="0" GridLines="None" ShowGroupPanel="True" Skin="WebBlue" 
								OnItemCommand="grid_ItemCommand" AutoGenerateColumns="False">
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
										<telerik:GridBoundColumn DataField="IdTareaExchange" HeaderText="Id" ReadOnly="true" Visible="false">
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
										<telerik:GridBoundColumn DataField="fvtiming_task_Exchange" HeaderText="Timming" ReadOnly="true">
											<HeaderStyle HorizontalAlign="Center" />
											<ItemStyle HorizontalAlign="Left" />
										</telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="SumaTiming" HeaderText="Timming Acumulado" ReadOnly="true">
											<HeaderStyle HorizontalAlign="Center" />
											<ItemStyle HorizontalAlign="Left" />
										</telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="Porcentaje" HeaderText="Porcentaje"
											ReadOnly="true">
											<HeaderStyle HorizontalAlign="Center" />
											<ItemStyle HorizontalAlign="Left" />
										</telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="FechaVencimiento" HeaderText="Fecha Vencimiento"
											ReadOnly="true">
											<HeaderStyle HorizontalAlign="Center" />
											<ItemStyle HorizontalAlign="Left" />
										</telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FechaTermino" HeaderText="Fecha de Termino"
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
						<telerik:RadPageView ID="RadPageView3" runat="server">
							<telerik:RadGrid ID="repEjecTiempos" runat="server" AllowPaging="True" AllowSorting="True"
								CellSpacing="0" GridLines="None" ShowGroupPanel="True" Skin="WebBlue" 
								OnItemCommand="grid_ItemCommand" AutoGenerateColumns="False">
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
										<telerik:GridBoundColumn DataField="IdTareaExchange" HeaderText="Id" ReadOnly="true" Visible="false">
										</telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="FechaOperativa" HeaderText="Fecha Operativa" ReadOnly="true">
											<HeaderStyle HorizontalAlign="Center" />
											<ItemStyle HorizontalAlign="Left" />
										</telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="fvnumber_part_bocar" HeaderText="Num Parte" ReadOnly="true">
											<HeaderStyle HorizontalAlign="Center" />
											<ItemStyle HorizontalAlign="Left" />
										</telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="fvnumber_part_client" HeaderText="Num Parte Cliente" ReadOnly="true">
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
										<telerik:GridBoundColumn DataField="DispositivoEnsamble" HeaderText="Dispositivo Ensamble" ReadOnly="true">
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
								CellSpacing="0" GridLines="None" ShowGroupPanel="True" Skin="WebBlue" 
								OnItemCommand="grid_ItemCommand" AutoGenerateColumns="False">
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
										<telerik:GridBoundColumn DataField="fiid_client" HeaderText="Id" ReadOnly="true" Visible="false">
										</telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" ReadOnly="true">
											<HeaderStyle HorizontalAlign="Center" />
											<ItemStyle HorizontalAlign="Left" />
										</telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="NumAvisosDeCambios" HeaderText="Avisos de Cambio" ReadOnly="true">
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
								CellSpacing="0" GridLines="None" ShowGroupPanel="True" Skin="WebBlue" 
								OnItemCommand="grid_ItemCommand" AutoGenerateColumns="False">
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
										<telerik:GridBoundColumn DataField="IdRevisionIng" HeaderText="Id" ReadOnly="true" Visible="false">
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
										<telerik:GridBoundColumn DataField="numParteCliente" HeaderText="Num Parte Cliente" ReadOnly="true">
											<HeaderStyle HorizontalAlign="Center" />
											<ItemStyle HorizontalAlign="Left" />
										</telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="DescAltaAviso" HeaderText="Descripción" ReadOnly="true">
											<HeaderStyle HorizontalAlign="Center" />
											<ItemStyle HorizontalAlign="Left" />
										</telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="Problema" HeaderText="Problema"
											ReadOnly="true">
											<HeaderStyle HorizontalAlign="Center" />
											<ItemStyle HorizontalAlign="Left" />
										</telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="Motivo" HeaderText="Motivo"
											ReadOnly="true">
											<HeaderStyle HorizontalAlign="Center" />
											<ItemStyle HorizontalAlign="Left" />
										</telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="Accion" HeaderText="Acción"
											ReadOnly="true">
											<HeaderStyle HorizontalAlign="Center" />
											<ItemStyle HorizontalAlign="Left" />
										</telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="Contacto" HeaderText="Contacto"
											ReadOnly="true">
											<HeaderStyle HorizontalAlign="Center" />
											<ItemStyle HorizontalAlign="Left" />
										</telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="RevisionIng" HeaderText="Revisión"
											ReadOnly="true">
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
			</td>
		</tr>
	</table>
	<asp:SqlDataSource ID="sqlDSArea" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
		SelectCommand="sp_selectArea" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
	<asp:SqlDataSource ID="sqlDSClient" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
		SelectCommand="sp_selectClient" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSPartList" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
		    SelectCommand="sp_selectPartList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
