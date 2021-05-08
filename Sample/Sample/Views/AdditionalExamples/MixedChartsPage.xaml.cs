using System.Collections.Generic;
using Plugin.XamarinChartJS;
using Plugin.XamarinChartJS.Models;
using Sample.Helpers;
using Xamarin.Forms;

namespace Sample.Views.AdditionalExamples
{
    public partial class MixedChartsPage : ContentPage
    {
        public ChartViewConfig LineBarConfig { get; set; }
        public ChartViewConfig LinePieConfig { get; set; }

        public MixedChartsPage()
        {
            LineBarConfig = RandomChartBuilder.GetChartConfig(new List<string> { ChartTypes.Line, ChartTypes.Bar }, Color.White);
            LinePieConfig = RandomChartBuilder.GetChartConfig(new List<string> { ChartTypes.Line, ChartTypes.Pie }, Color.White);
            InitializeComponent();
            BindingContext = this;
        }
    }
}
