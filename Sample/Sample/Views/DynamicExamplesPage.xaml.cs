using System;
using System.Collections.Generic;
using Plugin.XamarinChartJS;
using Plugin.XamarinChartJS.Models;
using Sample.Helpers;
using Xamarin.Forms;

namespace Sample.Views
{
    public partial class DynamicExamplesPage : ContentPage
    {
        public string SelectedType { get; set; } = Plugin.XamarinChartJS.ChartTypes.Line;
        public List<string> Types { get; set; } = new List<string>()
        {
            ChartTypes.Line,
            ChartTypes.Bar,
            ChartTypes.Radar,
            ChartTypes.Doughnut,
            ChartTypes.Pie,
            ChartTypes.PolarArea,
            ChartTypes.Bubble,
            ChartTypes.Scatter
        };

        public Color SelectedColor { get; set; } = Color.White;
        public List<Color> Colors { get; set; } = new List<Color>()
        {
            Color.Red,
            Color.Orange,
            Color.Black,
            Color.White
        };

        public DynamicExamplesPage()
        {
            InitializeComponent();
            BindingContext = this;
            dynamicChart.Config = RandomChartBuilder.GetChartConfig(Plugin.XamarinChartJS.ChartTypes.Pie, Color.White);
        }

        public void OnChartTypeChanged(object sender, EventArgs e)
        {
            var selectedChartType = (string)chartTypePicker.SelectedItem;

            if (selectedChartType != null)
            {
                ChartViewConfig newConfig;

                if (selectedChartType == ChartTypes.Bubble)
                {
                    newConfig = RandomChartBuilder.GetBubbleChartConfig(Color.White);
                }
                else if (selectedChartType == ChartTypes.Scatter)
                {
                    newConfig = RandomChartBuilder.GetScatterChartConfig(Color.White);
                }
                else
                {
                    newConfig = RandomChartBuilder.GetChartConfig(selectedChartType, Color.White);
                }

                dynamicChart.Config.ChartConfig = newConfig.ChartConfig;
            }
        }

        public void OnChartColorChanged(object sender, EventArgs e)
        {
            var selectedColor = (Color)colorPicker.SelectedItem;
            dynamicChart.Config.BackgroundColor = selectedColor;
        }
    }
}
