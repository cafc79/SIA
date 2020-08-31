using System;
using Telerik.Charting;

public partial class Auditoria_Produccion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            const double hourStep = 1 / 24.0;
            const double minuteStep = hourStep / 60;
            const double fiveMinuteStep = minuteStep * 5;

            double startTime = new DateTime(2008, 1, 1, 8, 0, 0, 0).ToOADate();
            double endTime = new DateTime(2008, 1, 1, 17, 0, 0, 0).ToOADate();

            RadChart1.PlotArea.XAxis.AddRange(startTime, endTime, hourStep);

            Random r = new Random();
            ChartSeries s = RadChart1.Series[0];

            for (double currentTime = startTime; currentTime < endTime; currentTime += fiveMinuteStep)
            {
                ChartSeriesItem item = new ChartSeriesItem();
                item.XValue = currentTime + (r.NextDouble() - 0.5) * fiveMinuteStep;
                item.YValue = 7065 + (r.NextDouble() - 0.5) * 90;
                s.Items.Add(item);
            }

            double today = DateTime.Now.Date.ToOADate();
            double lastMonth = DateTime.Now.Date.AddMonths(-1).ToOADate();
            RadChart2.PlotArea.XAxis.AddRange(lastMonth, today, 1);
            s = RadChart2.Series[0];
            for (double currentDate = lastMonth; currentDate <= today; currentDate++)
            {
                ChartSeriesItem item = new ChartSeriesItem();
                item.YValue = 7065 + (r.NextDouble() - 0.5) * 90;
                s.Items.Add(item);
            }
        }
    }
}