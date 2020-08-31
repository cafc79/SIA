<%@ Page Title="" Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true"
    CodeFile="Produccion.aspx.cs" Inherits="Auditoria_Produccion" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Charting" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadComboBox ID="ddlPartListExchangePartList" runat="server" DataSourceID="sqlDSddlPartList"
        DataTextField="sDesc1" DataValueField="iIdPart" Width="300px" AutoPostBack="True"
        EnableVirtualScrolling="True" Skin="Metro" AllowCustomText="True" MarkFirstMatch="True">
    </telerik:RadComboBox>
    <asp:SqlDataSource ID="sqlDSddlPartList" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
        SelectCommand="sp_selectddlPartList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <telerik:RadChart ID="RadChart1" runat="server" Skin="Mac" Width="900px" Height="300">
        <ChartTitle>
            <TextBlock Text="Producción - al Dia">
            </TextBlock>
        </ChartTitle>
        <Series>
            <telerik:ChartSeries Name="Index" Type="Area">
                <Appearance ShowLabels="False">
                </Appearance>
            </telerik:ChartSeries>
        </Series>
        <Appearance TextQuality="AntiAlias">
        </Appearance>
        <PlotArea>
            <Appearance Dimensions-Margins="18%, 24%, 22%, 10%">
            </Appearance>
            <XAxis LayoutMode="Inside" AutoScale="false">
                <Appearance ValueFormat="ShortTime" MajorGridLines-Visible="false">
                    <LabelAppearance RotationAngle="45" Position-AlignedPosition="Top">
                    </LabelAppearance>
                </Appearance>
            </XAxis>
            <YAxis IsZeroBased="false">
            </YAxis>
        </PlotArea>
    </telerik:RadChart>
    <br />
    <telerik:RadChart ID="RadChart2" runat="server" Skin="Mac" Width="900px" Height="300">
        <ChartTitle>
            <TextBlock Text="Producción - al Mes">
            </TextBlock>
        </ChartTitle>
        <Series>
            <telerik:ChartSeries Name="Index" Type="Area">
                <Appearance ShowLabels="False">
                </Appearance>
            </telerik:ChartSeries>
        </Series>
        <Appearance TextQuality="AntiAlias">
        </Appearance>
        <PlotArea>
            <Appearance Dimensions-Margins="18%, 24%, 22%, 10%">
            </Appearance>
            <XAxis LayoutMode="Inside" AutoScale="false" LabelStep="5">
                <Appearance ValueFormat="ShortDate" MajorGridLines-Visible="false">
                    <LabelAppearance RotationAngle="45" Position-AlignedPosition="Top">
                    </LabelAppearance>
                </Appearance>
            </XAxis>
            <YAxis IsZeroBased="false">
            </YAxis>
        </PlotArea>
    </telerik:RadChart>
</asp:Content>
