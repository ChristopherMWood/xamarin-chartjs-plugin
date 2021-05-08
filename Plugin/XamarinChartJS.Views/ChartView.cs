using Plugin.XamarinChartJS.Helpers;
using Plugin.XamarinChartJS.Models;
using Xamarin.Forms;

namespace Plugin.XamarinChartJS
{
    public class ChartView : WebView
    {
        private ChartBuilder chartBuilder;
        public bool webViewLoaded { get; private set; }
        public static readonly BindableProperty ConfigProperty =
            BindableProperty.Create("Config", typeof(ChartViewConfig), typeof(ChartView), null, propertyChanged: OnConfigChanged);

        public ChartView()
        {
            chartBuilder = new ChartBuilder();
            Navigated += WebViewOnNavigated;
        }

        public ChartView(ChartViewConfig config) : base()
        {
            this.Config = config;
        }

        private void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {
            webViewLoaded = true;
        }

        public ChartViewConfig Config
        {
            get { return (ChartViewConfig)GetValue(ConfigProperty); }
            set { SetValue(ConfigProperty, value); }
        }

        private static void OnConfigChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var chartView = bindable as ChartView;
                var config = newValue as ChartViewConfig;

                if (chartView.webViewLoaded)
                {
                    chartView.LoadChart((ChartViewConfig)newValue);
                }
                else
                {
                    chartView.BuildChartInWebView(config);
                }
            }
        }

        private void BuildChartInWebView(ChartViewConfig config)
        {
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = chartBuilder.BuildHTML(config);

            if (Device.RuntimePlatform == Device.Android)
            {
                htmlSource.BaseUrl = string.Empty;
            }

            Source = htmlSource;
        }

        private void LoadChart(ChartViewConfig config)
        {
            var json = chartBuilder.GetChartConfigJSON(config);
            Eval($"loadChart({ json });");
        }
    }
}
