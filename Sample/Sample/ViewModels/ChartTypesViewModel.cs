using Plugin.XamarinChartJS.Models;
using Sample.Helpers;
using Xamarin.Forms;

namespace Sample.ViewModels
{
    public class ChartTypesViewModel
    {
        public ChartViewConfig LineConfig { get; set; }
        public ChartViewConfig BarConfig { get; set; }
        public ChartViewConfig RadarConfig { get; set; }
        public ChartViewConfig DoughnutConfig { get; set; }
        public ChartViewConfig PieConfig { get; set; }
        public ChartViewConfig PolarAreaConfig { get; set; }
        public ChartViewConfig BubbleConfig { get; set; }
        public ChartViewConfig ScatterConfig { get; set; }

        public ChartTypesViewModel()
        {
            LineConfig = RandomChartBuilder.GetChartConfig(Plugin.XamarinChartJS.ChartTypes.Line, Color.White);
            BarConfig = RandomChartBuilder.GetChartConfig(Plugin.XamarinChartJS.ChartTypes.Bar, Color.White);
            RadarConfig = RandomChartBuilder.GetChartConfig(Plugin.XamarinChartJS.ChartTypes.Radar, Color.White);
            DoughnutConfig = RandomChartBuilder.GetChartConfig(Plugin.XamarinChartJS.ChartTypes.Doughnut, Color.White);
            PieConfig = RandomChartBuilder.GetChartConfig(Plugin.XamarinChartJS.ChartTypes.Pie, Color.White);
            PolarAreaConfig = RandomChartBuilder.GetChartConfig(Plugin.XamarinChartJS.ChartTypes.PolarArea, Color.White);
            BubbleConfig = RandomChartBuilder.GetBubbleChartConfig(Color.White);
            ScatterConfig = RandomChartBuilder.GetScatterChartConfig(Color.White);
        }
    }
}
