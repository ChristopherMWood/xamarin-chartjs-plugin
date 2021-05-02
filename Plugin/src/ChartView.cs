using Plugin.XamarinChartJS.Models;
using Xamarin.Forms;

namespace Plugin.XamarinChartJS
{
    public class ChartView : WebView
    {
        private ChartBuilder chartBuilder;
        public bool webViewLoaded { get; private set; }
        public static readonly BindableProperty ConfigProperty =
            BindableProperty.Create("Config", typeof(ChartConfig), typeof(ChartView), null, propertyChanged: OnConfigChanged);

        public ChartView()
        {
            chartBuilder = new ChartBuilder();
            Navigated += WebViewOnNavigated;
        }

        public ChartView(ChartConfig config) : base()
        {
            this.Config = config;
        }

        private void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {
            webViewLoaded = true;
        }

        public ChartConfig Config
        {
            get { return (ChartConfig)GetValue(ConfigProperty); }
            set { SetValue(ConfigProperty, value); }
        }

        private static void OnConfigChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var chartView = bindable as ChartView;
                var config = newValue as ChartConfig;

                if (chartView.webViewLoaded)
                {
                    chartView.LoadChart((ChartConfig)newValue);
                }
                else
                {
                    chartView.BuildChartInWebView(config);
                }
            }
        }

        private void BuildChartInWebView(ChartConfig config)
        {
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = chartBuilder.BuildHTML(config);
            htmlSource.BaseUrl = string.Empty;
            Source = htmlSource;
        }

        private void LoadChart(ChartConfig config)
        {
            var json = chartBuilder.GetChartConfigJSON(config);
            Eval($"loadChart({ json });");
        }
    }
}
