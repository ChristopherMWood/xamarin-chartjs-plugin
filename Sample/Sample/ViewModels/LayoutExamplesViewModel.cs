using Plugin.XamarinChartJS.Models;
using Sample.Helpers;
using Xamarin.Forms;

namespace Sample.ViewModels
{
    public class LayoutExamplesViewModel
    {
        public ChartViewConfig LineConfig { get; set; }
        public ChartViewConfig BarConfig { get; set; }
        public ChartViewConfig PieConfig { get; set; }

        public LayoutExamplesViewModel()
        {
            LineConfig = RandomChartBuilder.GetChartConfig(Plugin.XamarinChartJS.ChartTypes.Line, Color.White);
            BarConfig = RandomChartBuilder.GetChartConfig(Plugin.XamarinChartJS.ChartTypes.Bar, Color.White);
            PieConfig = RandomChartBuilder.GetChartConfig(Plugin.XamarinChartJS.ChartTypes.Pie, Color.White);
        }
    }
}
