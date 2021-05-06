using Plugin.XamarinChartJS;
using Plugin.XamarinChartJS.Models;
using Sample.Helpers;
using Xamarin.Forms;

namespace Sample.Views.AdditionalExamples
{
    public partial class ChartLoadStressTest : ContentPage
    {
        public ChartViewConfig Config { get; set; }

        public ChartLoadStressTest()
        {
            Config = RandomChartBuilder.GetChartConfig(ChartTypes.Line, Color.White);
            InitializeComponent();
            BindingContext = this;
        }
    }
}
