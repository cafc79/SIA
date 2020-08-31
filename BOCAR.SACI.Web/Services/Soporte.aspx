<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Soporte.aspx.cs" Inherits="Services_Soporte" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2011.1.315.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server" style="margin-top: auto">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <table width="100%" style="vertical-align: top; text-align: left; border-style: none">
        <tr>
            <td>
                <telerik:RadGrid ID="gvDocuments" runat="server" CellPadding="4" AllowPaging="True"
                                                    AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" DataKeyNames="iIdExchangeFile"
                                                    DataSourceID="sqlDSExchangeFile" GridLines="None" Skin="WebBlue" OnItemCommand="gvDocuments_ItemCommand">
                                                    <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                                                        <Selecting AllowRowSelect="True" />
                                                    </ClientSettings>
                                                    <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                                    <MasterTableView>
                                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                            <HeaderStyle Width="20px" />
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                            <HeaderStyle Width="20px" />
                                                        </ExpandCollapseColumn>
                                                        <Columns>
                                                            <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:Panel ID="Panel1" runat="server">
                                                                        <asp:ImageButton ID="rbtnSelect" runat="server" AutoPostBack="true" ImageUrl="~/img/msg-refresh.jpg"
                                                                            Width="21" Height="21" CommandName="Download" />
                                                                    </asp:Panel>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn DataField="iIdExchangeFile" HeaderText="" ReadOnly="true"
                                                                Visible="false">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="iFile" HeaderText="" ReadOnly="true" Visible="false">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="iExchange" HeaderText="" ReadOnly="true" Visible="false">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="sURL" HeaderText="" ReadOnly="true" Visible="false">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="iTiype" HeaderText="" ReadOnly="true" Visible="false">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="sType" HeaderText="" ReadOnly="true" Visible="false">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="sLabel" HeaderText="Archivo" ReadOnly="true">
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
                                                    <FilterMenu EnableImageSprites="False">
                                                    </FilterMenu>
                                                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                                    </HeaderContextMenu>
                                                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="sqlDSExchangeFile" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>" 
        SelectCommand="sp_selectFileEechangeByExchange" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="fiid_exchange" 
                QueryStringField="ex" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
