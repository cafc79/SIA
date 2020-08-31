<%@ Page Title="Seguimiento" Language="C#" MasterPageFile="~/RadMasterPage.master"
    AutoEventWireup="true" CodeFile="Seguimiento.aspx.cs" Inherits="Seguimiento" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnableEmbeddedScripts="False"
        EnablePageHeadUpdate="False" UpdatePanelsRenderMode="Inline">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="imbSerach">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtSrchFolio" />
                    <telerik:AjaxUpdatedControl ControlID="gridFolio" />
                    <telerik:AjaxUpdatedControl ControlID="lblCurrentFolio" />
                    <telerik:AjaxUpdatedControl ControlID="gridTareas" />
                    <telerik:AjaxUpdatedControl ControlID="gridReporte" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDisplayOpSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rbListOpSearch" LoadingPanelID="RadAjaxLoadingPanel1"
                        UpdatePanelRenderMode="Inline" />
                    <telerik:AjaxUpdatedControl ControlID="btnHideOpSearch" LoadingPanelID="RadAjaxLoadingPanel1"
                        UpdatePanelRenderMode="Inline" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnHideOpSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnDisplayOpSearch" LoadingPanelID="RadAjaxLoadingPanel1"
                        UpdatePanelRenderMode="Inline" />
                    <telerik:AjaxUpdatedControl ControlID="rbListOpSearch" LoadingPanelID="RadAjaxLoadingPanel1"
                        UpdatePanelRenderMode="Inline" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="gridFolio">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblCurrentFolio" UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="comboTareas" />
                    <telerik:AjaxUpdatedControl ControlID="gridTareas" LoadingPanelID="RadAjaxLoadingPanel1"
                        UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="gridReporte" LoadingPanelID="RadAjaxLoadingPanel1"
                        UpdatePanelRenderMode="Inline" />
                    <telerik:AjaxUpdatedControl ControlID="txtDescDocumento" />
                    <telerik:AjaxUpdatedControl ControlID="RadAsyncUpload1" />
                    <telerik:AjaxUpdatedControl ControlID="btnGraba" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="comboTareas">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gridTareas" />
                    <telerik:AjaxUpdatedControl ControlID="gridReporte" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="gridTareas">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gridReporte" UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="txtDescDocumento" />
                    <telerik:AjaxUpdatedControl ControlID="RadAsyncUpload1" />
                    <telerik:AjaxUpdatedControl ControlID="btnGraba" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="gridReporte">
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnGraba">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gridReporte" />
                    <telerik:AjaxUpdatedControl ControlID="txtDescDocumento" />
                    <telerik:AjaxUpdatedControl ControlID="RadAsyncUpload1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" AnimationDuration="10"
        EnableEmbeddedScripts="False" Skin="Web20" Transparency="25">
    </telerik:RadAjaxLoadingPanel>
    <table style="border-width: thin; border-style: none; width: 100%; vertical-align: top;
        text-align: center;">
        <tr>
            <td style="vertical-align: top; text-align: left; border-right-style: groove; border-right-width: 2px;"
                width="190px">
                <asp:Menu ID="menuSolicitud" runat="server" BackColor="#B5C7DE" Font-Names="Verdana"
                    Font-Size="XX-Small" ForeColor="#284E98" StaticSubMenuIndent="10px" Width="148px"
                    Enabled="False">
                    <StaticSelectedStyle BackColor="#BBC6BF" BorderColor="#9999FF" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
                    <DynamicMenuStyle BackColor="#B5C7DE" />
                    <DynamicSelectedStyle BackColor="#507CD1" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
                </asp:Menu>
            </td>
            <td>
                <table style="vertical-align: top; text-align: left; border-style: none">
                    <tr>
                        <td>
                            <fieldset>
                                <legend>Folio:</legend>
                                <table style="width: 100%; vertical-align: top; text-align: left; border-style: none">
                                    <tr>
                                        <td align="right">
                                            <telerik:RadTextBox ID="txtSrchFolio" runat="server" Skin="WebBlue" Width="280px">
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
                                    Skin="WebBlue" GridLines="None" AutoGenerateColumns="False" OnItemCommand="gridFolio_ItemCommand"
                                    Font-Size="X-Small" AllowSorting="True" ShowGroupPanel="True">
                                    <ClientSettings AllowDragToGroup="True">
                                        <Selecting AllowRowSelect="True" />
                                    </ClientSettings>
                                    <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                    <MasterTableView DataSourceID="sqlDS_Folio" DataKeyNames="IdFolio" Width="100%" AllowMultiColumnSorting="True">
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
                                                ReadOnly="true">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DescAltaAviso" HeaderText="Descripción del Alta de Aviso"
                                                ReadOnly="true">
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
                                            <telerik:RadComboBox ID="comboTareas" runat="server" AllowCustomText="true" 
                                                AutoPostBack="True" EmptyMessage="Que tarea buscas?" 
                                                EnableLoadOnDemand="true" EnableVirtualScrolling="True" Height="140px" 
                                                MarkFirstMatch="true" OnSelectedIndexChanged="comboTareas_SelectedIndexChanged" 
                                                Skin="Web20" Width="590px">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="gridTareas" runat="server" AllowPaging="True" CellSpacing="0"
                                                OnItemDataBound="gridTarea_ItemDataBound" OnItemCommand="gridTarea_ItemCommand"
                                                GridLines="None" Skin="WebBlue" AutoGenerateColumns="False" HorizontalAlign="Left"
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
                                                Skin="WebBlue" HorizontalAlign="Left" Font-Size="X-Small">
                                                <AlternatingItemStyle Font-Names="Verdana" Font-Size="X-Small" />
                                                <MasterTableView>
                                                    <Columns>
                                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:Panel ID="Panel1" runat="server">
                                                                    <asp:ImageButton ID="rbtnSelect" runat="server" AutoPostBack="true" ImageUrl="~/img/msg-refresh.jpg"
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
                                                        <telerik:RadTextBox ID="txtDescDocumento" runat="server" Skin="WebBlue" Width="280px" Enabled="false">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label id="ruta">
                                                            Seleccione Ruta:</label>
                                                    </td>
                                                    <td>
                                                        <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" Skin="WebBlue" AutoAddFileInputs="False"
                                                            Width="280px" Culture="es-MX" Enabled="false">
                                                        </telerik:RadAsyncUpload>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <telerik:RadButton ID="btnGraba" runat="server" OnClick="btnGrabar_Click" Text="Agregar"
                                                            Skin="WebBlue" Enabled="false" ToolTip="En esta fase, solo se pueden agregar documentos a tareas cerradas" />
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
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="sqlDS_Folio" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectFolio" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtSrchFolio" DefaultValue="0" Name="strFolio" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="rbListOpSearch" DefaultValue="1" Name="intType"
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDSTareas" runat="server" ConnectionString="<%$ ConnectionStrings:SACIConnectionString %>"
        SelectCommand="sp_selectCatTask" SelectCommandType="StoredProcedure" />
</asp:Content>
