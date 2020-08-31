<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageError_byCatalog.aspx.cs" Inherits="Error_PageError_byCatalog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SACI Bocar</title>
    <link href="../Styles/BocarStyle.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin-top: auto">
    <form id="form1" runat="server" style="margin-top: auto">
    <br />
    <table style="width: 100%; height: 100%;">
        <tr style="width: 100%; vertical-align: top">
            <td valign="top" colspan="3" style="background-image: url(img/ExtremoDerecho.jpg);
                background-repeat: repeat-x">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Img/Bocarbn.jpg" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="currentUser" runat="server" ImageUrl="~/Img/user.png" Width="36" Height="36" />
            </td>
            <td align="center" width="100%">
                <asp:Menu ID="MenuHorizontal" runat="server" Orientation="Horizontal" BackColor="#E3EAEB"
                    DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#666666"
                    StaticSubMenuIndent="10px">
                    <StaticSelectedStyle BackColor="#1C5E55" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                    <DynamicMenuStyle BackColor="#E3EAEB" />
                    <DynamicSelectedStyle BackColor="#1C5E55" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticHoverStyle BackColor="#666666" ForeColor="White" />
                </asp:Menu>
            </td>
            <td>
                <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/Img/system-log-out.png" Width="36"
                    Height="36" ToolTip="Salir del Sistema" PostBackUrl="~/Services/Logout.ashx" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <div>
                    <table style="width: 100%; height: 100%; border-style: none">
                        <tr>
                            <td align="center">
                                <asp:Image ID="imgPicture" CssClass="picture" GenerateEmptyAlternateText="true" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <br style="clear: both" />
                    <asp:Label ID="lblMessage" CssClass="errorMessage" runat="server" />
                    <br />
                    <br />
                    <asp:Label ID="lblFile" CssClass="file" runat="server" />
                    <div class="source">
                        <asp:Literal ID="ltlSource" runat="server" />
                    </div>
                    <br />
                    <br />
                    <fieldset>
                        <legend>Motivation</legend>
                        <div class="motivation">
                            <asp:Label ID="lblMotivation" runat="server" />
                        </div>
                    </fieldset>
                </div>
            </td>
            <td>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
