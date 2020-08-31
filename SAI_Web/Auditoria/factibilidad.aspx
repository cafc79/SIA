<%@ Page Title="" Language="C#" MasterPageFile="~/RadMasterPage.master" AutoEventWireup="true"
    CodeFile="factibilidad.aspx.cs" Inherits="Auditoria_factibilidad" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Charting" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
            <telerik:RadComboBox ID="ddlPartListExchangePartList" runat="server" DataSourceID="sqlDSddlPartList"
                DataTextField="sDesc1" DataValueField="iIdPart" Width="300px" AutoPostBack="True"
                EnableVirtualScrolling="True" Skin="Metro" AllowCustomText="True" MarkFirstMatch="True">
            </telerik:RadComboBox>
            <asp:SqlDataSource ID="sqlDSddlPartList" runat="server" ConnectionString="<%$ ConnectionStrings:SAIConnectionString %>"
                SelectCommand="sp_selectddlPartList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            <br />
            <telerik:RadChart runat="server" ID="RadChart2" Skin="Mac" Height="400px" Width="900px"
                IntelligentLabelsEnabled="true">
                <Appearance Corners="Round, Round, Round, Round, 6">
                    <FillStyle FillType="Image">
                        <FillSettings BackgroundImage="{chart}" ImageDrawMode="Flip" ImageFlip="FlipX">
                        </FillSettings>
                    </FillStyle>
                    <Border Color="138, 138, 138"></Border>
                </Appearance>
                <Series>
                    <telerik:ChartSeries Name="Acumulada" Type="Bar">
                        <Appearance>
                            <FillStyle MainColor="55, 167, 226" SecondColor="22, 85, 161">
                                <FillSettings GradientMode="Vertical">
                                </FillSettings>
                            </FillStyle>
                            <TextAppearance TextProperties-Color="Black">
                            </TextAppearance>
                        </Appearance>
                        <Items>
                            <telerik:ChartSeriesItem YValue="0" />
                            <telerik:ChartSeriesItem YValue="50" />
                            <telerik:ChartSeriesItem YValue="175" />
                            <telerik:ChartSeriesItem YValue="600" />
                            <telerik:ChartSeriesItem YValue="800" />
                            <telerik:ChartSeriesItem YValue="1390" />
                            <telerik:ChartSeriesItem YValue="2790" />
                            <telerik:ChartSeriesItem YValue="4590" />
                            <telerik:ChartSeriesItem YValue="5260" />
                        </Items>
                    </telerik:ChartSeries>
                    <telerik:ChartSeries Name="Unitaria" Type="Spline">
                        <Appearance>
                            <FillStyle MainColor="223, 87, 60" SecondColor="200, 38, 37">
                                <FillSettings GradientMode="Vertical">
                                </FillSettings>
                            </FillStyle>
                            <TextAppearance TextProperties-Color="Black">
                            </TextAppearance>
                        </Appearance>
                        <Items>
                            <telerik:ChartSeriesItem YValue="0" />
                            <telerik:ChartSeriesItem YValue="50" />
                            <telerik:ChartSeriesItem YValue="125" />
                            <telerik:ChartSeriesItem YValue="425" />
                            <telerik:ChartSeriesItem YValue="200" />
                            <telerik:ChartSeriesItem YValue="590" />
                            <telerik:ChartSeriesItem YValue="1400" />
                            <telerik:ChartSeriesItem YValue="1800" />
                            <telerik:ChartSeriesItem YValue="670" />
                        </Items>
                    </telerik:ChartSeries>
                </Series>
                <Legend>
                    <Appearance Dimensions-Margins="15.4%, 3%, 1px, 1px" Position-AlignedPosition="TopRight">
                        <ItemMarkerAppearance Figure="Square">
                            <Border Color="134, 134, 134" />
                        </ItemMarkerAppearance>
                        <FillStyle MainColor="">
                        </FillStyle>
                        <Border Color="Transparent"></Border>
                    </Appearance>
                </Legend>
                <PlotArea>
                    <XAxis>
                        <Appearance Color="134, 134, 134" MajorTick-Color="134, 134, 134">
                            <MajorGridLines Color="209, 222, 227" PenStyle="Solid"></MajorGridLines>
                            <TextAppearance TextProperties-Color="51, 51, 51">
                            </TextAppearance>
                        </Appearance>
                        <AxisLabel>
                            <TextBlock>
                                <Appearance TextProperties-Color="51, 51, 51">
                                </Appearance>
                            </TextBlock>
                        </AxisLabel>
                    </XAxis>
                    <YAxis ScaleBreaks-Enabled="true" ScaleBreaks-MaxCount="2">
                        <ScaleBreaks Enabled="True" MaxCount="2">
                            <Segments>
                                <telerik:AxisSegment Name="" MinValue="4000" MaxValue="5500" Step="1500"></telerik:AxisSegment>
                                <telerik:AxisSegment Name="" MinValue="2500" MaxValue="3600" Step="1100"></telerik:AxisSegment>
                                <telerik:AxisSegment Name="" MaxValue="2100" Step="150"></telerik:AxisSegment>
                            </Segments>
                        </ScaleBreaks>
                        <Appearance Color="134, 134, 134" MinorTick-Color="134, 134, 134" MajorTick-Color="134, 134, 134"
                            MinorTick-Width="0">
                            <MajorGridLines Color="209, 222, 227"></MajorGridLines>
                            <MinorGridLines Color="233, 239, 241"></MinorGridLines>
                            <TextAppearance TextProperties-Color="51, 51, 51">
                            </TextAppearance>
                        </Appearance>
                        <AxisLabel>
                            <TextBlock>
                                <Appearance TextProperties-Color="51, 51, 51">
                                </Appearance>
                            </TextBlock>
                        </AxisLabel>
                    </YAxis>
                    <Appearance>
                        <FillStyle MainColor="White" FillType="Solid">
                        </FillStyle>
                        <Border Color="134, 134, 134"></Border>
                    </Appearance>
                </PlotArea>
                <ChartTitle>
                    <Appearance Position-AlignedPosition="Top">
                        <FillStyle MainColor="">
                        </FillStyle>
                    </Appearance>
                    <TextBlock Text="Factibilidad por Producción">
                        <Appearance TextProperties-Font="Tahoma, 13pt">
                        </Appearance>
                    </TextBlock>
                </ChartTitle>
            </telerik:RadChart>
</asp:Content>
