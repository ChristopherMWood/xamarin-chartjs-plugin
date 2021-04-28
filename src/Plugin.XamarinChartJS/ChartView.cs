using Plugin.XamarinChartJS.Models;
using Xamarin.Forms;

namespace Plugin.XamarinChartJS
{
    public class ChartView : WebView
    {
        public ChartView()
        {
        }

        public ChartView(ChartTypes chartType, ChartData data, ChartOptions options)
        {
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = new ChartBuilder().BuildHTML(chartType, data, options);
            this.Source = htmlSource;
        }

        private string _chartType;
        public string ChartType
        {
            get
            {
                return _chartType;
            }
            set
            {
                _chartType = value;

                var htmlSource = new HtmlWebViewSource();
                htmlSource.Html = "<h1>TESTING</h1>";// new ChartBuilder().BuildHTML(chartType, data, options);
                this.Source = htmlSource;
            }
        }

        public ChartData ChartData
        {
            get; set;
        }

        public ChartOptions ChartOptions
        {
            get; set;
        }
    }
}
