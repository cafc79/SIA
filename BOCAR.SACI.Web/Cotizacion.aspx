<%@ Page Title="" Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true"
	CodeFile="Cotizacion.aspx.cs" Inherits="Cotizacion" %>

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
									<asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="#4B4B4B">Cotización</asp:Label>
									<br />
									<hr />
								</td>
							</tr>
							<tr>
								<td>
									<asp:Panel ID="pnQuoteA" runat="server">
										<table style="border-style: solid; border-width: thin; width: 100%; 
											vertical-align: top; text-align: left;">
											<tr>
												<td width="5%">
												</td>
												<td width="80%" height="15px">
												</td>
												<td width="5%">
												</td>
											</tr>
											<tr>
												<td>
												</td>
												<td>
													<table width="100%">
														<tr>
															<td width="35%" valign="top">
																<table style="border-width: 0px; width: 100%;">
																	<tr>
																		<td>
																			<asp:Label ID="lblPartNameC" runat="server" Text="Parte:"></asp:Label>
																		</td>
																		<td>
																			<telerik:RadComboBox ID="ddlPartListC" runat="server" DataTextField="sPartListDescription"
																				DataValueField="iIdPartList" OnSelectedIndexChanged="ddlPartListC_SelectedIndexChanged"
																				AutoPostBack="True">
																			</telerik:RadComboBox>
																		</td>
																	</tr>
																	<tr>
																		<td>
																			<asp:Label ID="lblNoPartTitleC" runat="server" Text="No. Parte:"></asp:Label>
																		</td>
																		<td>
																			<asp:Label ID="lblNoParC" runat="server" Font-Size="Small"></asp:Label>
																		</td>
																	</tr>
																	<tr>
																		<td>
																			<asp:Label ID="lblClientTitleC" runat="server" Text="Cliente: "></asp:Label>
																		</td>
																		<td>
																			<asp:Label ID="lblClientC" runat="server" Font-Size="Small"></asp:Label>
																		</td>
																	</tr>
																	<tr>
																		<td>
																			<asp:Label ID="lblProyectTitleC" runat="server" Text="Proyecto: "></asp:Label>
																		</td>
																		<td height="100%">
																			<asp:Label ID="lblProyectC" runat="server" Font-Size="Small"></asp:Label>
																		</td>
																	</tr>
																</table>
															</td>
															<td width="35%" valign="top">
																<table width="100%" style="border-width: 0px;">
																	<tr>
																		<td>
																			<asp:Label ID="Label31" runat="server" Text="Entrada:">
																			</asp:Label>
																		</td>
																		<td width="160px">
																			<telerik:RadTextBox ID="txtDateIn" runat="server" Enabled="false"></telerik:RadTextBox><asp:ImageButton
																				ID="imbDateIn" runat="server" ImageUrl="Img/calendar.png" OnClick="imbDateIn_Click" />
																		</td>
																	</tr>
																	<tr>
																		<td>
																			<asp:Label ID="Label32" runat="server" Text="Promesa::">
																			</asp:Label>
																		</td>
																		<td>
																			<telerik:RadTextBox ID="txtDateProm" runat="server" Enabled="false"></telerik:RadTextBox><asp:ImageButton
																				ID="imbDateProm" runat="server" ImageUrl="Img/calendar.png" OnClick="imbDateProm_Click" />
																		</td>
																	</tr>
																	<tr>
																		<td>
																			<asp:Label ID="lblDateOut" runat="server" Text="Entrega:">
																			</asp:Label>
																		</td>
																		<td>
																			<telerik:RadTextBox ID="txtDateOut" runat="server" Enabled="false"></telerik:RadTextBox><asp:ImageButton
																				ID="imbDateOut" runat="server" ImageUrl="Img/calendar.png" OnClick="imbDateOut_Click" />
																		</td>
																	</tr>
																	<tr>
																		<td>
																			<asp:Label ID="lblSOP" runat="server" Text="SOP Cliente"></asp:Label>
																		</td>
																		<td>
																			<telerik:RadTextBox ID="txtSOPClientC" runat="server" ForeColor="Red"></telerik:RadTextBox>
																		</td>
																	</tr>
																</table>
															</td>
															<td width="30%" valign="top">
																<asp:Calendar ID="cCalendarCot" runat="server" OnSelectionChanged="cCalendarCot_SelectionChanged"
																	Visible="False"></asp:Calendar>
															</td>
														</tr>
													</table>
													<table width="100%" style="border-width: 0px;">
														<tr>
															<td height="15px">
																<asp:Label ID="lblDescriptionTitleC" runat="server" Text="Descripcion del cambio:"></asp:Label>
															</td>
														</tr>
														<tr>
															<td style="border-style: solid">
																<asp:Label ID="lblDescriptionC" runat="server" Font-Size="Small"></asp:Label>
															</td>
														</tr>
														<tr>
															<td height="15px">
															</td>
														</tr>
													</table>
													<table width="100%">
														<tr>
															<td>
																<table width="100%" style="border-width: 0px; font-size: xx-small;">
																	<tr>
																		<td width="110px" align="center" bgcolor="#FF3300">
																			<asp:Label ID="lblAfectationTitleC" runat="server" Text="Afectación" ForeColor="White"></asp:Label>
																		</td>
																		<td width="30px">
																			<asp:Label ID="Label24" runat="server" Text="si"></asp:Label>
																		</td>
																		<td width="120px">
																			<asp:Label ID="Label25" runat="server" Text="Costo"></asp:Label>
																		</td>
																		<td bgcolor="Yellow">
																			&#160;&nbsp;
																		</td>
																		<td width="30px" bgcolor="Yellow">
																			<asp:Label ID="Label26" runat="server" Text="si"></asp:Label>
																		</td>
																		<td width="120px" align="center" bgcolor="Yellow">
																			<asp:Label ID="Label27" runat="server" Text="Costo"></asp:Label>
																		</td>
																		<td bgcolor="#000066">
																		</td>
																		<td width="70px" align="center" bgcolor="#000066">
																			<asp:Label ID="Label28" runat="server" Text="Gramos" ForeColor="White"></asp:Label>
																		</td>
																		<td>
																		</td>
																		<td>
																		</td>
																	</tr>
																	<tr>
																		<td>
																			<asp:Label ID="lblProtMoldC" runat="server" Text="Molde Prototipo"></asp:Label>
																		</td>
																		<td bgcolor="#FF3300">
																			<asp:CheckBox ID="chkMoldC" runat="server" OnCheckedChanged="CheckCotizacion_CheckedChanged"
																				AutoPostBack="True" />
																		</td>
																		<td>
																			<asp:Label ID="Label82" runat="server" Text="$"></asp:Label>
																			<telerik:RadTextBox ID="txtMoldC" runat="server" Font-Size="XX-Small" Width="100px" Visible="False"></telerik:RadTextBox>
																		</td>
																		<td width="120px">
																			<asp:Label ID="lblComponets" runat="server" Text="Componentes:"></asp:Label>
																		</td>
																		<td bgcolor="#FF3300">
																			<asp:CheckBox ID="chkComponetsC" runat="server" AutoPostBack="True" OnCheckedChanged="CheckCotizacion_CheckedChanged" />
																		</td>
																		<td>
																			<asp:Label ID="Label76" runat="server" Text="$"></asp:Label>
																			<telerik:RadTextBox ID="txtComponentsC" runat="server" Font-Size="XX-Small" Width="100px"></telerik:RadTextBox>
																		</td>
																		<td width="70px">
																			<asp:Label ID="lblPound" runat="server" Text="Peso Actual:"></asp:Label>
																		</td>
																		<td>
																			<telerik:RadTextBox ID="txtPoundC" runat="server" Font-Size="XX-Small" Width="50px"></telerik:RadTextBox>
																		</td>
																		<td>
																		</td>
																		<td>
																		</td>
																	</tr>
																	<tr>
																		<td>
																			<asp:Label ID="lblMoldSerie" runat="server" Text="Molde Serie:"></asp:Label>
																		</td>
																		<td bgcolor="#FF3300">
																			<asp:CheckBox ID="chkMoldSC" runat="server" OnCheckedChanged="CheckCotizacion_CheckedChanged"
																				AutoPostBack="True" />
																		</td>
																		<td>
																			<asp:Label ID="Label83" runat="server" Text="$"></asp:Label>
																			<telerik:RadTextBox ID="txtMoldSC" runat="server" Font-Size="XX-Small" Width="100px" Visible="False"></telerik:RadTextBox>
																		</td>
																		<td>
																			<telerik:RadTextBox ID="txtOthersTitleWC" runat="server" Font-Size="XX-Small" Width="100px"></telerik:RadTextBox>
																		</td>
																		<td bgcolor="#FF3300">
																			<asp:CheckBox ID="chkOthersWC" runat="server" 
																				OnCheckedChanged="CheckCotizacion_CheckedChanged" AutoPostBack="True" />
																		</td>
																		<td>
																			<asp:Label ID="Label77" runat="server" Text="$"></asp:Label>
																			<telerik:RadTextBox ID="txtOthersWC" runat="server" Font-Size="XX-Small" Width="100px" Visible="False"></telerik:RadTextBox>
																		</td>
																		<td>
																			<asp:Label ID="lblDelta1" runat="server" Text="Delta 1:"></asp:Label>
																		</td>
																		<td>
																			<telerik:RadNumericTextBox ID="txtDelta1" runat="server" Font-Size="XX-Small" 
																				Width="50px" Culture="es-MX" Value="0" ontextchanged="txtCalculoCosto_TextChanged" 
																				Skin="WebBlue" AutoPostBack="True">
																			</telerik:RadNumericTextBox>
																		</td>
																		<td>
																		</td>
																		<td>
																		</td>
																	</tr>
																	<tr>
																		<td>
																			<asp:Label ID="lblCF" runat="server" Text="C/F:"></asp:Label>
																		</td>
																		<td bgcolor="#FF3300">
																			<asp:CheckBox ID="chkCFC" runat="server" OnCheckedChanged="CheckCotizacion_CheckedChanged"
																				AutoPostBack="True" />
																		</td>
																		<td>
																			<asp:Label ID="Label84" runat="server" Text="$"></asp:Label>
																			<telerik:RadTextBox ID="txtCFC" runat="server" Font-Size="XX-Small" Width="100px" Visible="False"></telerik:RadTextBox>
																		</td>
																		<td>
																			<asp:Label ID="lblPaint" runat="server" Text="Pintura:"></asp:Label>
																		</td>
																		<td bgcolor="#FF3300">
																			<asp:CheckBox ID="chkPaintC" runat="server" AutoPostBack="True" OnCheckedChanged="CheckCotizacion_CheckedChanged" />
																		</td>
																		<td>
																			<asp:Label ID="Label78" runat="server" Text="$"></asp:Label>
																			<telerik:RadTextBox ID="txtPaintC" runat="server" Font-Size="XX-Small" Width="100px" Visible="False"></telerik:RadTextBox>
																		</td>
																		<td>
																			<asp:Label ID="Label60" runat="server" Text="Delta 2:"></asp:Label>
																		</td>
																		<td>
																			<telerik:RadNumericTextBox ID="txtDelta2" runat="server" Font-Size="XX-Small" 
																				Width="50px" Culture="es-MX" ontextchanged="txtCalculoCosto_TextChanged" 
																				Skin="WebBlue" Value="0" AutoPostBack="True">
																			</telerik:RadNumericTextBox>
																		</td>
																		<td>
																		</td>
																		<td>
																		</td>
																	</tr>
																	<tr>
																		<td>
																			<asp:Label ID="lblDeviceEms" runat="server" Text="Dispositivo ensamble:"></asp:Label>
																		</td>
																		<td bgcolor="#FF3300">
																			<asp:CheckBox ID="chkDeviceC" runat="server" AutoPostBack="True" OnCheckedChanged="CheckCotizacion_CheckedChanged" />
																		</td>
																		<td>
																			<asp:Label ID="Label85" runat="server" Text="$"></asp:Label>
																			<telerik:RadTextBox ID="txtDeviceC" runat="server" Font-Size="XX-Small" Width="100px" Visible="False"></telerik:RadTextBox>
																		</td>
																		<td>
																			<asp:Label ID="lblEmp" runat="server" Text="Empaque"></asp:Label>
																		</td>
																		<td bgcolor="#FF3300">
																			<asp:CheckBox ID="chkEmpC" runat="server" OnCheckedChanged="CheckCotizacion_CheckedChanged"
																				AutoPostBack="True" />
																		</td>
																		<td>
																			<asp:Label ID="Label79" runat="server" Text="$"></asp:Label>
																			<telerik:RadTextBox ID="txtEmpC" runat="server" Font-Size="XX-Small" Width="100px" Visible="False"></telerik:RadTextBox>
																		</td>
																		<td>
																			<asp:Label ID="lblCostPC" runat="server" Text="Costo:"></asp:Label>
																		</td>
																		<td>
																		<telerik:RadNumericTextBox ID="txtCost" runat="server" Font-Size="XX-Small" 
																				Width="50px" Culture="es-MX" 
																				Skin="WebBlue" Value="0" ReadOnly="True" DataType="System.Decimal">
																			</telerik:RadNumericTextBox>
																		</td>
																		<td width="30px" align="right">
																			<asp:Label ID="lblR1" runat="server" Text="R1"></asp:Label>
																		</td>
																		<td>
																			<asp:Label ID="Label74" runat="server" Text="$"></asp:Label>
																			<telerik:RadNumericTextBox ID="txtR1" runat="server" Font-Size="XX-Small" 
																				Width="50px" Culture="es-MX" ontextchanged="txtCalculoCosto_TextChanged" 
																				Skin="WebBlue" Value="0" AutoPostBack="True">
																			</telerik:RadNumericTextBox>
																			<asp:Label ID="Label72" runat="server" Text="usd/kg"></asp:Label>
																		</td>
																	</tr>
																	<tr>
																		<td>
																			<asp:Label ID="lblObsolet" runat="server" Text="Obsoletos:"></asp:Label>
																		</td>
																		<td bgcolor="#FF3300">
																			<asp:CheckBox ID="chkObsoletC" runat="server" AutoPostBack="True" OnCheckedChanged="CheckCotizacion_CheckedChanged" />
																		</td>
																		<td>
																			<asp:Label ID="Label86" runat="server" Text="$"></asp:Label>
																			<telerik:RadTextBox ID="txtObsoletC" runat="server" Font-Size="XX-Small" Width="100px" Visible="False"></telerik:RadTextBox>
																		</td>
																		<td>
																			<asp:Label ID="lblBank" runat="server" Text="Banco"></asp:Label>
																		</td>
																		<td bgcolor="#FF3300">
																			<asp:CheckBox ID="chkBankC" runat="server" OnCheckedChanged="CheckCotizacion_CheckedChanged"
																				AutoPostBack="True" />
																		</td>
																		<td>
																			<asp:Label ID="Label80" runat="server" Text="$"></asp:Label>
																			<telerik:RadTextBox ID="txtBankC" runat="server" Font-Size="XX-Small" Width="100px" Visible="False"></telerik:RadTextBox>
																		</td>
																		<td>
																		</td>
																		<td>
																		</td>
																		<td align="right">
																			<asp:Label ID="lblR2" runat="server" Text="R2"></asp:Label>
																		</td>
																		<td>
																			<asp:Label ID="Label75" runat="server" Text="$"></asp:Label>
																			<telerik:RadNumericTextBox ID="txtR2" runat="server" Font-Size="XX-Small" 
																				Width="50px" Culture="es-MX" ontextchanged="txtCalculoCosto_TextChanged" 
																				Skin="WebBlue" Value="0" AutoPostBack="True">
																			</telerik:RadNumericTextBox>
																			<asp:Label ID="Label73" runat="server" Text="usd/kg"></asp:Label>
																		</td>
																	</tr>
																	<tr>
																		<td>
																			<asp:Label ID="lblEngenerManager" runat="server" Text="Admon. Ingeniería:"></asp:Label>
																		</td>
																		<td bgcolor="#FF3300">
																			<asp:CheckBox ID="chkManEngC" runat="server" AutoPostBack="True" OnCheckedChanged="CheckCotizacion_CheckedChanged" />
																		</td>
																		<td>
																			<asp:Label ID="Label87" runat="server" Text="$"></asp:Label>
																			<telerik:RadTextBox ID="txtManEngC" runat="server" Font-Size="XX-Small" Width="100px" Visible="False"></telerik:RadTextBox>
																		</td>
																		<td>
																		</td>
																		<td>
																		</td>
																		<td>
																			&#160;&nbsp;
																		</td>
																		<td>
																		</td>
																		<td>
																		</td>
																		<td>
																		</td>
																		<td>
																		</td>
																	</tr>
																	<tr>
																		<td>
																			<asp:Label ID="lblDesign" runat="server" Text="Diseño:"></asp:Label>
																		</td>
																		<td bgcolor="#FF3300">
																			<asp:CheckBox ID="chkDesingC" runat="server" AutoPostBack="True" OnCheckedChanged="CheckCotizacion_CheckedChanged" />
																		</td>
																		<td>
																			<asp:Label ID="Label88" runat="server" Text="$"></asp:Label>
																			<telerik:RadTextBox ID="txtDesignC" runat="server" Font-Size="XX-Small" Width="100px" Visible="False"></telerik:RadTextBox>
																		</td>
																		<td>
																			<asp:Label ID="lblOthers" runat="server" Text="Otros:"></asp:Label>
																		</td>
																		<td>
																		</td>
																		<td>
																			<asp:Label ID="Label81" runat="server" Text="$"></asp:Label>
																			<telerik:RadTextBox ID="txtPrue" runat="server" Font-Size="XX-Small" Width="100px"></telerik:RadTextBox>
																		</td>
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
																<table width="100%" style="border-style: 0; border-color: 0; border-width: 0px; font-size: xx-small;">
																	<tr>
																		<td width="120px" align="center" bgcolor="#FF3300">
																			<asp:Label ID="lblPlazo" runat="server" ForeColor="White" Text="Plazos"></asp:Label>
																		</td>
																		<td width="120px" align="center">
																			<asp:Label ID="Label94" runat="server" Text="Semanas"></asp:Label>
																		</td>
																		<td>
																		</td>
																		<td>
																		</td>
																	</tr>
																	<tr>
																		<td>
																			<asp:Label ID="lblMold" runat="server" Text="Molde:"></asp:Label>
																		</td>
																		<td>
																			<telerik:RadTextBox ID="txtMoldPlazoC" runat="server" Font-Size="XX-Small" Width="100px"></telerik:RadTextBox>
																		</td>
																		<td>
																			<asp:Label ID="lblFistInyection" runat="server" Text="primera inyeccion"></asp:Label>
																		</td>
																		<td>
																		</td>
																	</tr>
																	<tr>
																		<td>
																			<asp:Label ID="lblMoldProtC" runat="server" Text="Molde Prototipo:"></asp:Label>
																		</td>
																		<td>
																			<telerik:RadTextBox ID="txtMoldProtC" runat="server" Font-Size="XX-Small" Width="100px"></telerik:RadTextBox>
																		</td>
																		<td>
																			<asp:Label ID="lblFistInyection0" runat="server" Text="primera inyeccion"></asp:Label>
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
																	<tr>
																		<td bgcolor="#FF3300">
																			<asp:Label ID="lblDateInChange" runat="server" Text="Fecha de inicio Cambio:" ForeColor="White"></asp:Label>
																		</td>
																		<td>
																			<telerik:RadTextBox ID="txtDateStart" runat="server" Font-Size="XX-Small" Width="100px"></telerik:RadTextBox>
																		</td>
																		<td width="120px">
																			<asp:Label ID="Label95" runat="server" Text="Semanas depués de PO"></asp:Label>
																		</td>
																		<td>
																		</td>
																	</tr>
																</table>
																<table style="border-style: 0; border-color: 0; border-width: 0px; font-size: xx-small;"
																	width="100%">
																	<tr>
																		<td width="120px" bgcolor="#000066" valign="top">
																			<asp:Label ID="lblObs" runat="server" Text="Observaciones:" ForeColor="White"></asp:Label>
																		</td>
																		<td width="80%">
																			<telerik:RadTextBox ID="txtObsC" runat="server" Font-Size="XX-Small" Width="90%" ForeColor="#000066"
																				TextMode="MultiLine"></telerik:RadTextBox>
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
																<table style="border-style: 0; border-color: 0; border-width: 0px; font-size: xx-small;"
																	width="100%">
																	<tr>
																		<td bgcolor="#FF3300" width="140px">
																			<asp:Label ID="lblTotalInv" runat="server" Text="TOTAL Inversión" ForeColor="White"></asp:Label>
																		</td>
																		<td bgcolor="#FF3300" width="140px">
																			<asp:Label ID="lblINVTotal" runat="server" ForeColor="White"></asp:Label>
																		</td>
																		<td>
																		</td>
																	</tr>
																	<tr>
																		<td bgcolor="#FF3300">
																			<asp:Label ID="lblTotalPiece" runat="server" Text="TOTAL / PIEZA" ForeColor="White"></asp:Label>
																		</td>
																		<td bgcolor="#FF3300">
																			<asp:Label ID="lblTotalPieceTotal" runat="server" ForeColor="White"></asp:Label>
																		</td>
																		<td>
																		</td>
																	</tr>
																</table>
																<table style="border-style: 0; border-color: 0; border-width: 0px; font-size: xx-small;"
																	width="100%">
																	<tr>
																		<td width="10%">
																		</td>
																		<td align="center">
																			<telerik:RadButton Skin="Windows7" ID="btnUpdateQuoteGuardar" runat="server" OnClick="btnUpdateQuoteGuardar_Click"
																				Text="Guardar" Visible="False" />
																			<telerik:RadButton Skin="Windows7" ID="btnUpdateQuote" runat="server" Text="Modificar" OnClick="btnUpdateQuote_Click"
																				Visible="False" />
																			<telerik:RadButton Skin="Windows7" ID="btnAddQuote" runat="server" OnClick="btnAddQuote_Click" Text="Agregar" />
																		</td>
																		<td width="10%">
																		</td>
																	</tr>
																</table>
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
													<asp:Label ID="Label12" runat="server" Visible="true" Text="No se han Introducido números de parte"></asp:Label>
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
								</td>
							</tr>
							<tr>
								<td>
									<asp:Panel ID="pnMessage" runat="server">
										<table style="width: 100%;">
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
</asp:Content>
