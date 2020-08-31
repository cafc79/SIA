<%@ Page Title="" Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true"
    CodeFile="Etapas.aspx.cs" Inherits="Auditoria_Etapas" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
            <telerik:RadComboBox ID="ddlPartListExchangePartList" runat="server" DataSourceID="sqlDSddlPartList"
                DataTextField="sDesc1" DataValueField="iIdPart" Width="300px" AutoPostBack="True"
                EnableVirtualScrolling="True" Skin="Metro" AllowCustomText="True" MarkFirstMatch="True">
            </telerik:RadComboBox>
            <asp:SqlDataSource ID="sqlDSddlPartList" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
                SelectCommand="sp_selectddlPartList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            <telerik:RadOrgChart ID="RadOrgChart1" runat="server" Skin="Metro" EnableGroupCollapsing="true">
                <RenderedFields>
                    <NodeFields>
                        <telerik:OrgChartRenderedField DataField="TeamName" Label="Etapa" />
                    </NodeFields>
                    <ItemFields>
                        <telerik:OrgChartRenderedField DataField="Certificates" Label="Obs" />
                    </ItemFields>
                </RenderedFields>
            </telerik:RadOrgChart>
</asp:Content>
