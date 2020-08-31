<%@ Page Title="Seguimiento" Language="C#" MasterPageFile="~/RadMasterPage.master"
    AutoEventWireup="true" CodeFile="Seguimiento.aspx.cs" Inherits="Seguimiento" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2012.1.215.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdateProgress runat="server" ID="uprogressMain" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div id="UpdateProgressFullScreen">
                <div id="UpdateProgressFullScreenChild">
                    <table border="0">
                        <tr>
                            <td>
                                <asp:Image runat="server" ID="imgLoader" ImageUrl="~/img/updateProgress/loader.gif" />
                            </td>
                            <td>
                                &nbsp;&nbsp;Procesando...
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="vertical-align: top; text-align: left; border-style: none">
                <tr>
                    <td>
                        <fieldset>
                            <legend>Folio:</legend>
                            <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                                <tr>
                                    <td align="right">
                                        <telerik:RadTextBox ID="txtSrchFolio" runat="server" Skin="Transparent" Width="280px">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td align="left">
                                        <asp:ImageButton ID="imbSerach" runat="server" ImageUrl="~/Img/btn_search.gif" OnClick="imbSearch_Click"
                                            ToolTip="Ejecutar Búsqueda" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnDisplayOpSearch" runat="server" ImageUrl="~/Img/FlechaDer.jpg"
                                            Height="24px" ToolTip="Mostrar opciones de búsqueda" OnClick="btnDisplayOpSearch_Click" />
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rbListOpSearch" runat="server" AutoPostBack="True" Font-Size="X-Small"
                                            RepeatDirection="Horizontal" Visible="False">
                                            <asp:ListItem Value="1" Selected="True">Ambos</asp:ListItem>
                                            <asp:ListItem Value="2">Folio</asp:ListItem>
                                            <asp:ListItem Value="3">Prefolio</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnHideOpSearch" runat="server" ImageUrl="~/Img/Flechaizq.jpg"
                                            Height="24px" ToolTip="Ocultar opciones de búsqueda" OnClick="btnHideOpSearch_Click"
                                            Visible="False" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <telerik:RadGrid ID="gridFolio" runat="server" AllowPaging="True" CellSpacing="0"
                                Skin="Transparent" GridLines="None" AutoGenerateColumns="False" OnItemCommand="gridFolio_ItemCommand"
                                Font-Size="X-Small" AllowSorting="True" AllowFilteringByColumn="True">
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                    <Selecting AllowRowSelect="True" CellSelectionMode="None" />
                                </ClientSettings>
                                <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                <MasterTableView Width="100%" AllowMultiColumnSorting="True">
                                    <Columns>
                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn" AllowFiltering="false" HeaderText="">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibtnFolio" runat="server" ImageUrl="~/Img/msg-info.png" AlternateText="Folio"
                                                    CommandName="ReviewFolio" Width="23" Height="23" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="IdFolio" HeaderText="IdFolio" ReadOnly="true"
                                            Visible="false">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Folio" HeaderText="Folio" ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PreFolio" HeaderText="PreFolio" ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fvdescription_exchange" HeaderText="Descripción del Requerimiento"
                                            ReadOnly="true" AllowFiltering="False">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="DescAltaAviso" HeaderText="Descripción del Alta de Aviso"
                                            ReadOnly="true" AllowFiltering="False">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EdoSolicitud" HeaderText="Estado de Solicitud"
                                            ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EdoAvisoCambio" HeaderText="Aviso de Cambio"
                                            ReadOnly="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>
                                <HeaderStyle Font-Size="X-Small" Font-Names="Verdana" />
                                <ItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                </HeaderContextMenu>
                            </telerik:RadGrid>
                            <br />
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td>
                        <fieldset>
                            <legend>Tareas del Folio:<asp:Label ID="lblCurrentFolio" runat="server" ForeColor="#999999"></asp:Label></legend>
                            <table width="100%" style="vertical-align: top; text-align: center; border-style: none">
                                <tr>
                                    <td align="left">
                                        <telerik:RadComboBox ID="comboTareas" runat="server" AllowCustomText="true" AutoPostBack="True"
                                            EmptyMessage="Que tarea buscas?" EnableLoadOnDemand="true" EnableVirtualScrolling="True"
                                            Height="140px" MarkFirstMatch="true" OnSelectedIndexChanged="comboTareas_SelectedIndexChanged"
                                            Skin="Web20" Width="590px">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="gridTareas" runat="server" AllowPaging="True" CellSpacing="0"
                                            OnItemDataBound="gridTarea_ItemDataBound" OnItemCommand="gridTarea_ItemCommand"
                                            GridLines="None" Skin="Transparent" AutoGenerateColumns="False" HorizontalAlign="Left"
                                            Font-Size="X-Small" AllowSorting="True">
                                            <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                            <MasterTableView>
                                                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                    <HeaderStyle Width="20px" />
                                                </RowIndicatorColumn>
                                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                    <HeaderStyle Width="20px" />
                                                </ExpandCollapseColumn>
                                                <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                                <Columns>
                                                    <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:Panel ID="Panel1" runat="server">
                                                                <asp:RadioButton ID="rbtnSelect" runat="server" AutoPostBack="true" OnCheckedChanged="Tareas_CheckedChanged" />
                                                            </asp:Panel>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridImageColumn UniqueName="SemaforoImg" DataImageUrlFields="Semaforo" DataImageUrlFormatString="~/img/{0}.png"
                                                        HeaderText="Semaforo" ImageWidth="23" ImageHeight="23">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </telerik:GridImageColumn>
                                                    <telerik:GridBoundColumn DataField="fiid_task_exchange" HeaderText="IdGrupo" ReadOnly="true"
                                                        Visible="false">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="IdGrupo" HeaderText="IdGrupo" ReadOnly="true"
                                                        Visible="false">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="IdTarea" HeaderText="IdTarea" ReadOnly="true"
                                                        Visible="false">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="IdArea" HeaderText="IdArea" ReadOnly="true" Visible="false">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="GrupoDesc" HeaderText="Grupo" ReadOnly="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="TareaAnt" HeaderText="Tarea Precedente" ReadOnly="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="TareaDesc" HeaderText="Tarea" ReadOnly="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="AREA" HeaderText="Área" ReadOnly="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="FechaVencimiento" HeaderText="Fecha de Vencimiento"
                                                        DataFormatString="{0:d}" ReadOnly="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Responsable" HeaderText="Responsable" ReadOnly="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="FechaTermino" HeaderText="Fecha Termino" ReadOnly="true">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="fiid_employed" HeaderText="Empleado" ReadOnly="true"
                                                        Visible="false">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn UniqueName="TaskFinished" AllowFiltering="false" HeaderText="Terminada"
                                                        DataField="FechaTermino">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ibtnFolio" runat="server" ImageUrl="~/Img/working.png" AlternateText="Tarea Terminada"
                                                                CommandName="FinishTask" Width="21" Height="21" />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridImageColumn UniqueName="EnvioMail" DataImageUrlFields="EnvioMail" DataImageUrlFormatString="~/img/{0}.png"
                                                        HeaderText="Mail Enviado" DataAlternateTextField="">
                                                    </telerik:GridImageColumn>
                                                    <telerik:GridBoundColumn DataField="fd_sendDate" HeaderText="FechaCorreo" ReadOnly="true"
                                                        Visible="false">
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                                <EditFormSettings>
                                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                    </EditColumn>
                                                </EditFormSettings>
                                            </MasterTableView>
                                            <HeaderStyle Font-Size="X-Small" Font-Names="Verdana" />
                                            <ItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                            <FilterMenu EnableImageSprites="False">
                                            </FilterMenu>
                                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Vista">
                                            </HeaderContextMenu>
                                        </telerik:RadGrid>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td>
                        <fieldset>
                            <legend>Documentos:</legend>
                            <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="gridReporte" runat="server" AllowPaging="True" CellSpacing="0"
                                            OnItemCommand="gridReporte_ItemCommand" AutoGenerateColumns="False" GridLines="None"
                                            Skin="Transparent" HorizontalAlign="Left" Font-Size="X-Small">
                                            <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                            <MasterTableView>
                                                <Columns>
                                                    <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:Panel ID="Panel1" runat="server">
                                                                <!--AutoPostBack="true"-->
                                                                <asp:ImageButton ID="rbtnSelect" runat="server" ImageUrl="~/img/msg-refresh.jpg"
                                                                    Width="23" Height="23" CommandName="Download" />
                                                            </asp:Panel>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="fvlabel_file" HeaderText="Archivo" ReadOnly="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="fvaddress_file" HeaderText="Ruta" ReadOnly="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                    <HeaderStyle Width="20px" />
                                                </RowIndicatorColumn>
                                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                    <HeaderStyle Width="20px" />
                                                </ExpandCollapseColumn>
                                                <EditFormSettings>
                                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                    </EditColumn>
                                                </EditFormSettings>
                                            </MasterTableView>
                                            <HeaderStyle Font-Size="X-Small" Font-Names="Verdana" />
                                            <ItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                            <FilterMenu EnableImageSprites="False">
                                            </FilterMenu>
                                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Vista">
                                            </HeaderContextMenu>
                                        </telerik:RadGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" style="vertical-align: top; text-align: center; border-style: none">
                                            <tr>
                                                <td>
                                                    <label id="documento">
                                                        Etiqueta de Documento:</label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadTextBox ID="txtDescDocumento" runat="server" Skin="Transparent" Width="280px"
                                                        Enabled="false">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label id="ruta">
                                                        Seleccione Ruta:</label>
                                                </td>
                                                <td>
                                                    <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" Skin="Transparent" AutoAddFileInputs="False"
                                                        Width="280px" Culture="es-MX" Enabled="false">
                                                    </telerik:RadAsyncUpload>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <telerik:RadButton ID="btnGraba" runat="server" OnClick="btnGrabar_Click" Text="Agregar"
                                                        Skin="Transparent" Enabled="false" ToolTip="En esta fase, solo se pueden agregar documentos a tareas cerradas" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:SqlDataSource ID="sqlDSTareas" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectCatTask" SelectCommandType="StoredProcedure" />
</asp:Content>
