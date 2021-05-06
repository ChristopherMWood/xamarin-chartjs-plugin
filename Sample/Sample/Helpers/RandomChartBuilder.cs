using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.XamarinChartJS.Models;
using Xamarin.Forms;

namespace Sample.Helpers
{
    public class RandomChartBuilder
    {
        public static ChartViewConfig GetChartConfig(string chartType, Color color)
        {
            return new ChartViewConfig()
            {
                ViewProperties = new ViewProperties
                {
                    BackgroundColor = color,
                    Padding = 0
                },
                ChartConfig = new
                {
                    type = chartType,
                    data = GetChartData(),
                    options = new ChartOptions
                    {
                        responsive = true,
                        maintainAspectRatio = false,
                        legend = new ChartLegend
                        {
                            position = "top"
                        },
                        animation = new ChartAnimation
                        {
                            animateScale = false
                        }
                    }
                }
            };
        }

        private static ChartData GetChartData()
        {
            var colors = GetDefaultColors();
            var labels = new[] { "Groceries", "Car", "Flat", "Electronics", "Entertainment", "Insurance" }.ToList();
            var randomGen = new Random();
            var dataPoints = Enumerable.Range(0, labels.Count)
                .Select(i => randomGen.Next(5, 25))
                .ToList();

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

        private static List<Tuple<int, int, int>> GetDefaultColors()
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
