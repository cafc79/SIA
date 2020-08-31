<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login"
    Title="Acceso al Sistema" %>

<html>
<head id="Head1" runat="server">
    <title>Acceso</title>
    <link rel="stylesheet" type="text/css" href="Styles/cssreset-min.css" />
    <link rel="stylesheet" type="text/css" href="Styles/grids-min.css" />
    <link rel="stylesheet" type="text/css" href="Styles/patternlock.css" />
</head>
<body>
    <div id="content_container">
        <div id="content">
            <div class="page">
                <div class="header">
                    <div class="title yui3-u-1">
                        <h1>
                            Acceso al Sistema
                        </h1>
                    </div>
                </div>
                <div class="main yui3-u-1">
                    <form id="Form1" runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="yui3-u-1">
                                <div class="yui3-u-1-5">
                                </div>
                                <div class="yui3-u-3-5">
                                    <div class="loginPleca">
                                        <div class="yui3-u-1-3" style="text-align: right">
                                            <asp:Image ID="imgLogin" runat="server" ImageUrl="~/Img/login-sign.gif" />
                                        </div>
                                    </div>
                                    <div class="loginContent">
                                        <div class="loginFields">
                                            <div class="yui3-u-1">
                                                <input type="text" value="Usuario" onfocus="if(this.value=='Usuario'){this.value=''};"
                                                    onblur="if(this.value==''){this.value='Nombre de Usuario'};" id="txtUsuario"
                                                    name="txtUsuario" runat="server" />
                                                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario"
                                                    ErrorMessage="El nombre de usuario es un campo obligatorio" ValidationGroup="ErroresInicio"
                                                    SkinID="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                            </div>
                                            <br />
                                            <div class="yui3-u-1">
                                                <input type="password" value="Password" id="txtContrasena" name="txtContrasena" runat="server" />
                                                <asp:RequiredFieldValidator ID="rfvContrasena" runat="server" ControlToValidate="txtContrasena"
                                                    ErrorMessage="La contraseña es un campo obligatorio" ValidationGroup="ErroresInicio"
                                                    SkinID="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="yui3-u-1">
                                                <asp:ValidationSummary ID="vlsErrores" runat="server" ValidationGroup="ErroresInicio"
                                                    DisplayMode="List" EnableTheming="True" />
                                            </div>
                                            <br />
                                            <div class="yui3-u-1">
                                                <asp:Button runat="server" ID="cmdCancelarInicio" OnClick="cmdCancelarInicio_Click"
                                                    Text="Cancelar" />
                                                <asp:Button runat="server" ID="cmdAceptarInicio" ValidationGroup="ErroresInicio"
                                                    OnClick="cmdAceptarInicio_Click" Text="Aceptar" />
                                            </div>
                                        </div>
                                    </div>
                                    <asp:Label ID="lblError" runat="server" SkinID="lblError"></asp:Label>
                                </div>
                                <div class="yui3-u-1-5">
                                </div>
                            </div>
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                                DynamicLayout="true">
                                <ProgressTemplate>
                                    <div style="position: absolute; top: 50%; left: 50%; width: 400px; margin-left: -200px;
                                        height: 300px; margin-top: -150px; padding: 5px;">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/updateProgress/loader.gif" />
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </form>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
    <div class="footer">
    </div>
</body>
</html>
