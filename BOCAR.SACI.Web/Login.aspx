<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Acceso al Sistema" %>

<%@ Register src="UsrCtrls/Autentication.ascx" tagname="Autentication" tagprefix="uc1" %>
<asp:Content ID="cntLogin" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <uc1:Autentication ID="Autenticacion1" runat="server" />
    </center>
</asp:Content>