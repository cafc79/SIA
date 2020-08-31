<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Autentication.ascx.cs" Inherits="UsrCtrls_Autentication" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

        <table style="width: 100%;">
            <tr>
                <td colspan="3">
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 33%">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <div>
                                            <table style="width: 80%">
                                                <tr>
                                                    <td align="left" >
                                                        <asp:Label ID="lblUsuario" runat="server" SkinID="lblDescripcionCampo" 
                                                            Text="Usuario :" Font-Bold="True" Font-Size="Small"></asp:Label>
                                                    </td>
                                                    <td style="width: 60%">
                                                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario"
                                                            ErrorMessage="El nombre de usuario es un campo obligatorio" ValidationGroup="ErroresInicio"
                                                            SkinID="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblContrasena" runat="server" SkinID="lblDescripcionCampo" 
                                                            Text="Contraseña :" Font-Bold="True" Font-Size="Small"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvContrasena" runat="server" ControlToValidate="txtContrasena"
                                                            ErrorMessage="La contraseña es un campo obligatorio" ValidationGroup="ErroresInicio"
                                                            SkinID="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:ValidationSummary ID="vlsErrores" runat="server" ValidationGroup="ErroresInicio"
                                                            DisplayMode="List" EnableTheming="True" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        <asp:Button ID="cmdAceptarInicio" runat="server"  OnClick="cmdAceptarInicio_Click"
                                                            Text="Aceptar" ValidationGroup="ErroresInicio" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td style="width: 33%">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                       
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblError" runat="server" SkinID="lblError"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
        </table>
<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DynamicLayout="true">
    <ProgressTemplate>
        <div style=" position:absolute; top:50%; left:50%; width:400px; margin-left:-200px; height:300px; margin-top:-150px; padding:5px;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/loading.gif" />
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
