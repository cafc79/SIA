<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Requerimiento.aspx.cs"
	Inherits="Services.Requerimiento" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>SACI BOcar</title>
	<link href="../Styles/BocarStyle.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin-top: auto">
	<form id="form1" runat="server" style="margin-top: auto">
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
	</telerik:RadScriptManager>
	<table width="100%" style="vertical-align: top; text-align: left; border-style: none">
		<tr>
			<td width="90px">
				<asp:Label ID="lblExchangeType" runat="server" Text="Tipo de Cambio:" Font-Bold="True"
					Font-Size="X-Small"></asp:Label>
			</td>
			<td width="180px">
				<telerik:RadTextBox ID="ddlExchange" runat="server" 
					DataTextField="sDescription" DataValueField="iIdExchangeType" Width="160px" Font-Size="X-Small">
				</telerik:RadTextBox>
			</td>
			<td width="10">
			</td>
			<td width="90px">
				<asp:Label ID="lblPriority" runat="server" Text="Prioridad:" Font-Bold="True" Font-Size="X-Small"></asp:Label>
			</td>
			<td width="180px">
				<telerik:RadTextBox ID="ddlPriority" runat="server" DataTextField="sDescription" Width="160px" Font-Size="X-Small">
				</telerik:RadTextBox>
			</td>
			<td width="10px">
			</td>
			<td width="90px">
				<asp:Label ID="lblSerie" runat="server" Text="Tipo:" Font-Bold="True" Font-Size="X-Small"></asp:Label>
			</td>
			<td width="180">
				<telerik:RadTextBox ID="ddlSerie" runat="server" 
					DataTextField="fvdescription" DataValueField="fiid_serie_proyect" Width="160px"
					Font-Size="X-Small">
				</telerik:RadTextBox>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="lblPlant" runat="server" Text="Planta:" Font-Bold="True" Font-Size="X-Small"></asp:Label>
			</td>
			<td>
				<telerik:RadTextBox ID="ddlPlant" runat="server" DataTextField="sDescription"
					DataValueField="iIdPlant" Width="160px" Font-Size="X-Small">
				</telerik:RadTextBox>
			</td>
			<td>
			</td>
			<td>
				<asp:Label ID="lblClient" runat="server" Text="Cliente:" Font-Bold="True" Font-Size="X-Small"></asp:Label>
			</td>
			<td>
				<telerik:RadTextBox ID="ddlClient" runat="server" DataSourceID="sqlDSClient" DataTextField="sDescription"
					DataValueField="iIdClient" Width="160px" Font-Size="X-Small">
				</telerik:RadTextBox>
			</td>
			<td>
			</td>
			<td>
				<asp:Label ID="lblLastFolio" runat="server" Text="Folio Anterior:" Font-Bold="True"
					Font-Size="X-Small"></asp:Label>
			</td>
			<td>
				<telerik:RadTextBox ID="txtLastFolio" runat="server" MaxLength="20" Width="150px"
					ReadOnly="true" Font-Size="X-Small">
				</telerik:RadTextBox>
			</td>
		</tr>
	</table>
	<table width="100%" style="line-height: 10px; vertical-align: top; text-align: left;
		border-style: none">
		<tr valign="top">
			<td width="90px">
				<asp:Label ID="lblLimitDate" runat="server" Text="Fecha Limite Cotización:" Font-Bold="True" Font-Size="X-Small"></asp:Label>
			</td>
			<td width="390px">
				<telerik:RadTextBox ID="txtLimitDate" runat="server" Enabled="False" MaxLength="10"
					TargetControlID="txtLimitDate" Width="150px" ReadOnly="true">
				</telerik:RadTextBox>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="lblProyectPlatDes" runat="server" Text="Proyecto/Plataforma" Font-Bold="True" Font-Size="X-Small"></asp:Label>
			</td>
			<td>
				<telerik:RadTextBox ID="txtProyectPlataformDescription" runat="server" MaxLength="50"
					Width="250px" ReadOnly="true">
				</telerik:RadTextBox>
			</td>
		</tr>
		<tr valign="top">
			<td>
				<asp:Label ID="lblDescription" runat="server" Text="Descripción:" Font-Bold="True" Font-Size="X-Small"></asp:Label>
			</td>
			<td valign="top">
				<telerik:RadTextBox ID="txtDescription" runat="server" MaxLength="250" TextMode="MultiLine"
					Width="90%" ReadOnly="true" Skin="Web20">
				</telerik:RadTextBox>
			</td>
		</tr>
		<tr valign="top">
			<td>
				<asp:Label ID="lblIssue" runat="server" Text="Problema" Font-Bold="True" Font-Size="X-Small"></asp:Label>
			</td>
			<td>
				<telerik:RadTextBox ID="txtIssue" runat="server" MaxLength="250" TextMode="MultiLine"
					Width="90%" ReadOnly="true" Skin="Web20">
				</telerik:RadTextBox>
			</td>
		</tr>
		<tr valign="top">
			<td>
				<asp:Label ID="lblReason" runat="server" Text="Motivo" Font-Bold="True" Font-Size="X-Small"></asp:Label>
			</td>
			<td>
				<telerik:RadTextBox ID="txtReason" runat="server" MaxLength="250" TextMode="MultiLine"
					Width="90%" ReadOnly="true" Skin="Web20">
				</telerik:RadTextBox>
			</td>
		</tr>
		<tr valign="top">
			<td>
				<asp:Label ID="lblAction" runat="server" Text="Acción:" Font-Bold="True" Font-Size="X-Small"></asp:Label>
			</td>
			<td>
				<telerik:RadTextBox ID="txtAction" runat="server" MaxLength="250" TextMode="MultiLine"
					Width="90%" ReadOnly="true" Skin="Web20">
				</telerik:RadTextBox>
			</td>
		</tr>
		<tr valign="top" style="height:26px">
			<td>
				<asp:Label ID="lblEngeneer" runat="server" Text="Ingeniero de producto" Font-Bold="True"
					Font-Size="X-Small"></asp:Label>
			</td>
			<td valign="top">
				<telerik:RadTextBox ID="ddlEngeenerProduct" runat="server" DataSourceID="sqlSPEmployedEP"
					DataTextField="sCompleteName" DataValueField="iIdEmployed" Width="60%" 
					Skin="Web20">
				</telerik:RadTextBox>
			</td>
		</tr>
		<tr valign="top">
			<td>
				<asp:Label ID="lblContact" runat="server" Text="Contacto del Cliente" Font-Bold="True" Font-Size="X-Small"></asp:Label>
			</td>
			<td>
				<telerik:RadTextBox ID="txtContact" runat="server" Width="90%" ReadOnly="true" 
					Skin="Web20">
				</telerik:RadTextBox>
			</td>
		</tr>
	</table>	
	</form>
</body>
</html>
