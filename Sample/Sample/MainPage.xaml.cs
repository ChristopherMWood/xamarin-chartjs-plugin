using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ChartTest.src;
using Plugin.XamarinChartJS;
using Plugin.XamarinChartJS.Models;
using Xamarin.Forms;

namespace Sample
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private ChartConfig _config;
        public ChartConfig Config
        {
            get { return _config; }
            set
            { _config = value; OnPropertyChanged("Config"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainPage()
        {
            Config = GetChartConfig(ChartTypes.Pie, Color.White);
            InitializeComponent();
            BindingContext = this;

            //var chart = new ChartView(Config);
            //chart.HorizontalOptions = LayoutOptions.FillAndExpand;
            //chart.HeightRequest = 400;

            //pageLayout.Children.Add(chart);
        }

        async void ChangeColorTest(object sender, EventArgs args)
        {
            Config = GetChartConfig(ChartTypes.Line, Color.Red);
        }

        private ChartConfig GetChartConfig(ChartTypes chartType, Color color)
        {
            return new ChartConfig()
            {
                ViewProperties = new ViewProperties
                {
                    PrimaryAxis = PrimaryAxis.Vertical,
                    BackgroundColor = color,
                    Padding = 0
                },
                Type = chartType,
                Data = GetChartData(),
                Options = new ChartOptions
                {
                    responsive = true,
                    maintainAspectRatio = true,
                    legend = new ChartLegend
                    {
                        position = "top"
                    },
                    animation = new ChartAnimation
                    {
                        animateScale = false
                    }
                }
            };
        }

        private ChartData GetChartData()
        {
            var colors = GetDefaultColors();
            var labels = new[] { "Groceries", "Car", "Flat", "Electronics", "Entertainment", "Insurance" }.ToList();
            var randomGen = new Random();
            var dataPoints = Enumerable.Range(0, labels.Count)
                .Select(i => randomGen.Next(5, 25))
                .ToList();
            //var data = new
            //{
            //    datasets = new[]
            //    {
            //        new
            //        {
            //            label = "Spending",
            //            data = dataPoints,
            //            backgroundColor = dataPoints.Select((d, i) =>
            //            {
            //                var color = colors[i % colors.Count];
            //                return $"rgb({color.Item1},{color.Item2},{color.Item3})";
            //            })
            //        }
            //    },
            //    labels
            //};
            return new ChartData()
            {
                datasets = new List<ChartDataset>
                {
                    new ChartDataset
                    {
                        label = "Spending",
                        data = dataPoints,
                        backgroundColor = dataPoints.Select((d, i) =>
                        {
                            var color = colors[i % colors.Count];
                            return $"rgb({color.Item1},{color.Item2},{color.Item3})";
                        })
                    }
                },
                labels = labels
            };
        }

        private List<Tuple<int, int, int>> GetDefaultColors()
        {
            return new List<Tuple<int, int, int>>
            {
                new Tuple<int, int, int>(255, 99, 132),
                new Tuple<int, int, int>(255, 159, 64),
                new Tuple<int, int, int>(255, 205, 86),
                new Tuple<int, int, int>(75, 192, 192),
                new Tuple<int, int, int>(54, 162, 235),
                new Tuple<int, int, int>(153, 102, 255),
                new Tuple<int, int, int>(201, 203, 207)
            };
        }
    }
}
