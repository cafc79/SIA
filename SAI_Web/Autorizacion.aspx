<%@ Page Title="" Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true"
    CodeFile="Autorizacion.aspx.cs" Inherits="Autorizacion" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="border-width: thin; border-style: none; width: 100%; vertical-align: top;
        text-align: center;">
        <tr>
            <td height="30px">
                <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="#4B4B4B"></asp:Label>
                <br />
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadWindowManager ID="owManager" runat="server" Skin="Sitefinity">
                    <Windows>
                        <telerik:RadWindow runat="server" ID="wndRequerimiento" Skin="Web20" Modal="true"
                            VisibleOnPageLoad="False" Behaviors="Resize, Close" Height="510px" Width="680px"
                            EnableEmbeddedScripts="True" RegisterWithScriptManager="True" ShowContentDuringLoad="False"
                            VisibleStatusbar="False" Animation="FlyIn" EnableShadow="True">
                        </telerik:RadWindow>
                        <telerik:RadWindow runat="server" ID="wndDocumentos" Skin="Web20" Modal="true" VisibleOnPageLoad="False"
                            Behaviors="Resize, Close" Height="510px" Width="680px" EnableEmbeddedScripts="True"
                            RegisterWithScriptManager="True" ShowContentDuringLoad="False" VisibleStatusbar="False"
                            Animation="FlyIn" EnableShadow="True">
                        </telerik:RadWindow>
                    </Windows>
                </telerik:RadWindowManager>
                <asp:ImageButton ID="imbRequerimiento" runat="server" ImageUrl="~/Img/remove.png"
                    ToolTip="Ver Requerimiento" />
                <asp:ImageButton ID="imgPdf" runat="server" ImageUrl="~/Img/Acrobat.png" Height="32"
                    Width="32" ToolTip="Ver Requerimiento en PDF" OnClick="imgPdf_Click" />
                <asp:ImageButton ID="imbDocs" runat="server" ImageUrl="~/Img/documents.png" Height="32"
                    Width="32" ToolTip="Ver Documentos Asociados" />
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPrefolioTitle" runat="server" Text="Prefolio: " Visible="False"
                    ForeColor="#FF3300"></asp:Label>
                <asp:Label ID="lblPrefolio" runat="server" Visible="False" ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="MultiPage_Autorizacion" runat="server">
                    <telerik:RadPageView ID="pnEngeenerAutorization" runat="server">
                        <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                            <tr>
                                <td width="25%">
                                </td>
                                <td>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblEngenerAutorization" runat="server" Text="Ingeniero de Producto:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <telerik:RadComboBox ID="ddlEngenerAutorization" runat="server" Width="200px" DataSourceID="sqlDSReviewType"
                                                    DataTextField="sDescription" DataValueField="iIdReviewType" Skin="Vista">
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="50px">
                                                Observaciones:
                                            </td>
                                            <td>
                                                <telerik:RadTextBox Skin="Transparent" ID="txtObsEngProduct" runat="server" Height="73px"
                                                    TextMode="MultiLine" Width="328px">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblGerenteIngenieria" runat="server" Text="Gerente de ingenieria:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <telerik:RadComboBox ID="ddlAdminAutorization" runat="server" Width="200px" DataSourceID="sqlDSReviewType"
                                                    DataTextField="sDescription" DataValueField="iIdReviewType" Skin="Vista">
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="50px">
                                                Observaciones:
                                            </td>
                                            <td>
                                                <telerik:RadTextBox Skin="Transparent" ID="txtObsEngManager" runat="server" Height="73px"
                                                    TextMode="MultiLine" Width="328px">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="25%">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right">
                                    <telerik:RadButton Skin="Windows7" ID="btnUpdateAutorization" runat="server" Text="Actualizar"
                                        OnClick="btnUpdate_Click" Visible="False" />
                                    <telerik:RadButton Skin="Windows7" ID="btnExchangeAutorization" runat="server" Text="Aceptar"
                                        OnClick="btnExchangeAutorization_Click" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="pnReviewExchange" runat="server">
                        <asp:Panel ID="pnReviewExchangegv" runat="server">
                            <table style="width: 100%; vertical-align: top; text-align: left; border-style: none"
                                align="center">
                                <tr>
                                    <td width="25%">
                                    </td>
                                    <td>
                                    </td>
                                    <td width="25%">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="center">
                                        <telerik:RadGrid ID="gvExchangeReview" runat="server" AutoGenerateColumns="False"
                                            CellPadding="4" AllowPaging="True" DataKeyNames="iIdReviewExchange" DataSourceID="sqlDSReviewTypeExchange"
                                            GridLines="None" Font-Size="XX-Small" HorizontalAlign="Left" EmptyDataText="No existen datos registrados."
                                            AllowSorting="True" Culture="es-MX" Skin="Transparent">
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
                                                    <telerik:GridTemplateColumn HeaderText="iIdReviewExchange" SortExpression="iIdReviewExchange"
                                                        Visible="False">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("iIdReviewExchange") %>'></asp:Label></EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("iIdReviewExchange") %>'></asp:Label></ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="iIdReviewType" SortExpression="iIdReviewType"
                                                        Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("iIdReviewType") %>'></asp:Label></ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="iIdExchange" SortExpression="iIdExchange"
                                                        Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("iIdExchange") %>'></asp:Label></ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="iIdUser" SortExpression="iIdUser" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("iIdUser") %>'></asp:Label></ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="bStatus" SortExpression="bStatus" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("bStatus") %>' Enabled="false" /></ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Nombre" SortExpression="sCompleteName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("sCompleteName") %>'></asp:Label></ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Evaluación" SortExpression="sReview">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("sReview") %>'></asp:Label></ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Descripción" SortExpression="sDescription">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("sDescription") %>'></asp:Label></ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imbSelectReviewExchange" runat="server" CausesValidation="false"
                                                                CommandName="" ImageUrl="~/Img/select.png" ToolTip="Modificar registro" CommandArgument='<%# Bind("iIdReviewExchange") %>'
                                                                Text="Botón" Style="height: 16px" OnClick="imbSelectReviewExchange_Click" /></ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                                <EditFormSettings>
                                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                    </EditColumn>
                                                </EditFormSettings>
                                            </MasterTableView><HeaderStyle Font-Names="Verdana" Font-Size="X-Small" />
                                            <ItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                            <FilterMenu EnableImageSprites="False">
                                            </FilterMenu>
                                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                            </HeaderContextMenu>
                                        </telerik:RadGrid>
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
                            <asp:Panel ID="pnReviewExchangeAdd" runat="server" Visible="False">
                                <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                                    <tr>
                                        <td width="25%">
                                        </td>
                                        <td>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="35%">
                                                        <asp:Label ID="lblReviewExchangeReview" runat="server" Text="Evaluación:"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <telerik:RadComboBox ID="ddlReviewExchangeReview" runat="server" DataSourceID="sqlDSReviewType"
                                                            DataTextField="sDescription" DataValueField="iIdReviewType" Skin="Vista">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <asp:Label ID="lblReviewExchangeObservation" runat="server" Text="Observación:"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <telerik:RadTextBox Skin="Transparent" ID="txtReviewExchangeObs" runat="server" Height="60px"
                                                            TextMode="MultiLine" Width="90%">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td align="right">
                                                        <telerik:RadButton Skin="Windows7" ID="btnUpdateReviewExchange" runat="server" OnClick="btnUpdateReviewExchange_Click"
                                                            Text="Modificar" Visible="False" />
                                                        <telerik:RadButton Skin="Windows7" ID="btnAddExchangeReview" runat="server" OnClick="btnAddExchangeReview_Click"
                                                            Text="Aceptar" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="25%">
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <br />
                        </asp:Panel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView1" runat="server">
                        <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                            <tr>
                                <td width="25%">
                                </td>
                                <td>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="35%">
                                                <asp:Label ID="Label8" runat="server" Text="Evaluación:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <telerik:RadComboBox ID="ddlSalesAutorization" runat="server" DataSourceID="sqlDSSalesAutorization"
                                                    DataTextField="sDescription" DataValueField="id" Skin="Vista">
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <asp:Label ID="Label9" runat="server" Text="Observación:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <telerik:RadTextBox Skin="Transparent" ID="txtSalesAutorization" runat="server" Height="60px"
                                                    TextMode="MultiLine" Width="90%">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="right">
                                                <telerik:RadButton Skin="Windows7" ID="btnSalesCancelar" runat="server" Text="Cancelar"
                                                    OnClick="btnSalesCancelar_Click" />
                                                <telerik:RadButton Skin="Windows7" ID="btnSalesAceptar" runat="server" Text="Aceptar"
                                                    OnClick="btnSalesAceptar_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="25%">
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
        <tr>
            <td width="100%">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300" Visible="False"></asp:Label>
                <asp:Label ID="lblIdExchange" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:Label ID="lblReviewExchange" runat="server" Text="0" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="sqlDSReviewTypeExchange" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectReviewExchangeByIdExchange" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblIdExchange" DefaultValue="0" Name="fiid_exchange"
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSReviewType" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectReviewType" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSSalesAutorization" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectSalesAutorization_Type" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
</asp:Content>
