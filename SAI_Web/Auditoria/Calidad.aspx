<%@ Page Title="" Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true"
    CodeFile="Calidad.aspx.cs" Inherits="Auditoria_Calidad" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadComboBox ID="ddlPartListExchangePartList" runat="server" DataSourceID="sqlDSddlPartList"
        DataTextField="sDesc1" DataValueField="iIdPart" Width="300px" AutoPostBack="True"
        EnableVirtualScrolling="True" Skin="Metro" AllowCustomText="True" MarkFirstMatch="True">
    </telerik:RadComboBox>
    <asp:SqlDataSource ID="sqlDSddlPartList" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectddlPartList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
