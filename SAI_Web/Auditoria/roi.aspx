<%@ Page Title="" Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true"
    CodeFile="roi.aspx.cs" Inherits="roi" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <label>
        Costo de Fabricación Molde</label><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <label>
        Costo de Ajuste de Maquinaria</label><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <label>
        Costo de Molde</label><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <label>
        Precio Unitario</label><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    <label>
        Porcentaje de ROI por Unidad</label><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    <label>
        Unidades Requeridas</label><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
</asp:Content>
