using System.Text;
using LiteStarNote.bean;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace LiteStarNote
{
    public partial class ChartForm : Form
    {
        DataBaseManager dataBaseManager = new DataBaseManager();
        string languge = "中文";
        public ChartForm(string langugeStr, string queryDateStart, string queryDateEnd, string queryType, string queryContent, string queryState)
        {
            InitializeComponent();
            languge = langugeStr;
            showData(queryDateStart, queryDateEnd, queryType, queryContent, queryState);
        }

        public void showData(string queryDateStart, string queryDateEnd, string queryType, string queryContent, string queryState)
        {
            List<WorkListBean> workList = dataBaseManager.queryData(queryDateStart, queryDateEnd, queryType, queryContent, queryState);
            Dictionary<string, int> typeMap = new Dictionary<string, int>();
            Dictionary<string, int> stateMap = new Dictionary<string, int>();
            Dictionary<string, int> dayMap = new Dictionary<string, int>();
            Dictionary<string, int> monthMap = new Dictionary<string, int>();
            foreach (WorkListBean work in workList)
            {
                if (work != null)
                {
                    string type = work.Type;
                    string state = work.State;
                    string day = work.Date;
                    string month = day.Substring(0, 7);
                    if (typeMap.ContainsKey(type))
                    {

                        typeMap[type] = typeMap[type] + 1;
                    }
                    else
                    {
                        typeMap.Add(type, 1);
                    }
                    if (stateMap.ContainsKey(state))
                    {

                        stateMap[state] = stateMap[state] + 1;
                    }
                    else
                    {
                        stateMap.Add(state, 1);
                    }
                    if (dayMap.ContainsKey(day))
                    {

                        dayMap[day] = dayMap[day] + 1;
                    }
                    else
                    {
                        dayMap.Add(day, 1);
                    }
                    if (monthMap.ContainsKey(month))
                    {

                        monthMap[month] = monthMap[month] + 1;
                    }
                    else
                    {
                        monthMap.Add(month, 1);
                    }
                }
            }
            typeChart(typeMap);
            stateChart(stateMap);
            dayChart(dayMap);
            monthChart(monthMap);
        }

        private void typeChart(Dictionary<string, int> typeMap)
        {
            int count = typeMap.Count;
            if (count < 1)
            {
                return;
            }
            string title = "按分类统计数量";
            if (languge == "English")
            {
                title = "Count the quantity by type";
            }
            var plotModel = new PlotModel();
            plotModel.Title = title;
            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                IsZoomEnabled = false,
                IsPanEnabled = false,
            });
            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };

            BarSeries barSeries = new BarSeries();
            barSeries.FillColor = OxyColor.Parse("#454CAF50");
            barSeries.StrokeColor = OxyColor.Parse("#4CAF50");
            barSeries.StrokeThickness = 1;
            StringBuilder textSb = new StringBuilder(title);
            textSb.Append(Environment.NewLine);
            foreach (KeyValuePair<string, int> entry in typeMap)
            {
                textSb.Append(entry.Key);
                textSb.Append("     ");
                textSb.Append(entry.Value);
                textSb.Append(Environment.NewLine);
                barSeries.Items.Add(new BarItem { Value = entry.Value });
                categoryAxis.Labels.Add(entry.Key);
            }
            text_type.Text = textSb.ToString();
            plotModel.Axes.Add(categoryAxis);
            plotModel.Series.Add(barSeries);

            plotView_type.Model = plotModel;
        }

        private void stateChart(Dictionary<string, int> stateMap)
        {
            int count = stateMap.Count;
            if (count < 1)
            {
                return;
            }
            string title = "按状态统计数量";
            if (languge == "English")
            {
                title = "Count the quantity by state";
            }
            var plotModel = new PlotModel();
            plotModel.Title = title;

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                IsZoomEnabled = false,
                IsPanEnabled = false,
            });
            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };

            BarSeries barSeries = new BarSeries();
            barSeries.FillColor = OxyColor.Parse("#454CAF50");
            barSeries.StrokeColor = OxyColor.Parse("#4CAF50");
            barSeries.StrokeThickness = 1;
            StringBuilder textSb = new StringBuilder(title);
            textSb.Append(Environment.NewLine);
            foreach (KeyValuePair<string, int> entry in stateMap)
            {
                barSeries.Items.Add(new BarItem { Value = entry.Value });
                categoryAxis.Labels.Add(entry.Key);
                textSb.Append(entry.Key);
                textSb.Append("     ");
                textSb.Append(entry.Value);
                textSb.Append(Environment.NewLine);
            }
            text_state.Text = textSb.ToString();
            plotModel.Axes.Add(categoryAxis);
            plotModel.Series.Add(barSeries);

            plotView_state.Model = plotModel;
        }

        private void stateChart2(Dictionary<string, int> stateMap)
        {
            int count = stateMap.Count;
            if (count < 1)
            {
                return;
            }
            var plotModel = new PlotModel();
            plotModel.Title = "按状态统计数量";

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
            });
            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                IsZoomEnabled = false,
                IsPanEnabled = false,
            });

            var categoryAxis = new CategoryAxis { Position = AxisPosition.Bottom };

            LinearBarSeries linearBarSeries = new LinearBarSeries();
            linearBarSeries.FillColor = OxyColor.Parse("#454CAF50");
            linearBarSeries.StrokeColor = OxyColor.Parse("#4CAF50");
            linearBarSeries.StrokeThickness = 1;
            linearBarSeries.TrackerFormatString = "状态 : {2} \r\n数量 : {4:0}";
            linearBarSeries.CanTrackerInterpolatePoints = false;
            linearBarSeries.BarWidth = 30;
            int i = 0;
            foreach (KeyValuePair<string, int> entry in stateMap)
            {
                i++;
                linearBarSeries.Points.Add(new DataPoint(i, entry.Value));
                categoryAxis.Labels.Add(entry.Key);
            }
            plotModel.Axes.Add(categoryAxis);
            plotModel.Series.Add(linearBarSeries);
            plotView_state.Model = plotModel;
        }

        private void dayChart(Dictionary<string, int> dayMap)
        {
            int count = dayMap.Count;
            if (count < 1)
            {
                return;
            }
            string title = "按天统计数量";
            string formatStr = "日期 : {2:yyyy-MM-dd} \r\n数量 : {4:0}";
            if (languge == "English")
            {
                title = "Count the quantity by days";
                formatStr = "date : {2:yyyy-MM-dd} \r\ncount : {4:0}";
            }
            var plotModel = new PlotModel();
            plotModel.Title = title;

            DateTimeAxis dateAxis = new DateTimeAxis()
            {
                StringFormat = "yyyy-MM-dd",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                IntervalLength = 60,
            };
            plotModel.Axes.Add(dateAxis);

            LinearAxis valueAxis = new LinearAxis()
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                IntervalLength = 80,
                IsZoomEnabled = false,
                IsPanEnabled = false,
                Minimum = -1,
            };
            plotModel.Axes.Add(valueAxis);

            LineSeries lineSeries = new OxyPlot.Series.LineSeries()
            {
                CanTrackerInterpolatePoints = false,
                Color = OxyColor.Parse("#4CAF50"),
                StrokeThickness = 2,
                MarkerSize = 5,
                MarkerStroke = OxyColors.DarkGreen,
                MarkerType = MarkerType.Circle,
                TrackerFormatString = formatStr,
            };
            StringBuilder textSb = new StringBuilder(title);
            textSb.Append(Environment.NewLine);
            foreach (KeyValuePair<string, int> entry in dayMap)
            {
                DateTime date = DateTime.Parse(entry.Key);
                lineSeries.Points.Add(new OxyPlot.DataPoint(DateTimeAxis.ToDouble(date), entry.Value));
                textSb.Append(entry.Key);
                textSb.Append("     ");
                textSb.Append(entry.Value);
                textSb.Append(Environment.NewLine);
            }
            text_day.Text = textSb.ToString();
            plotModel.Series.Add(lineSeries);

            plotView_day.Model = plotModel;
        }

        private void monthChart(Dictionary<string, int> monthMap)
        {
            int count = monthMap.Count;
            if (count < 1)
            {
                return;
            }
            string title = "按月统计数量";
            string formatStr = "月份 : {2:yyyy-MM} \r\n数量 : {4:0}";
            if (languge == "English")
            {
                title = "Count the quantity by months";
                formatStr = "month : {2:yyyy-MM} \r\ncount : {4:0}";
            }
            var plotModel = new PlotModel();
            plotModel.Title = title;

            DateTimeAxis dateAxis = new DateTimeAxis()
            {
                StringFormat = "yyyy-MM",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                IntervalLength = 60,
            };
            plotModel.Axes.Add(dateAxis);

            LinearAxis valueAxis = new LinearAxis()
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                IntervalLength = 80,
                IsZoomEnabled = false,
                IsPanEnabled = false,
                Minimum = -1,
            };
            plotModel.Axes.Add(valueAxis);

            LineSeries lineSeries = new OxyPlot.Series.LineSeries()
            {
                CanTrackerInterpolatePoints = false,
                Color = OxyColor.Parse("#4CAF50"),
                StrokeThickness = 2,
                MarkerSize = 5,
                MarkerStroke = OxyColors.DarkGreen,
                MarkerType = MarkerType.Circle,
                TrackerFormatString = formatStr,
            };
            StringBuilder textSb = new StringBuilder(title);
            textSb.Append(Environment.NewLine);
            foreach (KeyValuePair<string, int> entry in monthMap)
            {
                DateTime date = DateTime.Parse(entry.Key);
                lineSeries.Points.Add(new OxyPlot.DataPoint(DateTimeAxis.ToDouble(date), entry.Value));
                textSb.Append(entry.Key);
                textSb.Append("     ");
                textSb.Append(entry.Value);
                textSb.Append(Environment.NewLine);
            }
            text_month.Text = textSb.ToString();
            plotModel.Series.Add(lineSeries);

            plotView_month.Model = plotModel;
        }

        private void buttonSwitchShow_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (languge == "中文") {
                if (button.Text == "显示数据")
                {
                    text_type.Visible = true;
                    text_state.Visible = true;
                    text_day.Visible = true;
                    text_month.Visible = true;
                    button.Text = "显示图形";
                }
                else
                {
                    text_type.Visible = false;
                    text_state.Visible = false;
                    text_day.Visible = false;
                    text_month.Visible = false;
                    button.Text = "显示数据";
                }
            }
            if (languge == "English")
            {
                if (button.Text == "Display Data")
                {
                    text_type.Visible = true;
                    text_state.Visible = true;
                    text_day.Visible = true;
                    text_month.Visible = true;
                    button.Text = "Display Graphics";
                }
                else
                {
                    text_type.Visible = false;
                    text_state.Visible = false;
                    text_day.Visible = false;
                    text_month.Visible = false;
                    button.Text = "Display Data";
                }
            }

        }
    }
}
