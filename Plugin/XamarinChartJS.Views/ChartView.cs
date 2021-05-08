using System;
using System.ComponentModel;
using Plugin.XamarinChartJS.Helpers;
using Plugin.XamarinChartJS.Models;
using Xamarin.Forms;

namespace Plugin.XamarinChartJS
{
    public class ChartView : WebView
    {
        public static readonly BindableProperty ConfigProperty =
            BindableProperty.Create("Config", typeof(ChartViewConfig), typeof(ChartView), null, propertyChanged: OnChartViewConfigChanged);

        public ChartView()
        {
            Navigated += WebViewOnNavigated;
        }

        public ChartView(ChartViewConfig config) : base()
        {
            this.Config = config;
        }

        private void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {
        }

        public ChartViewConfig Config
        {
            get { return (ChartViewConfig)GetValue(ConfigProperty); }
            set { SetValue(ConfigProperty, value); }
        }

        private static void OnChartViewConfigChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var chartView = bindable as ChartView;

            if (oldValue != null)
            {
                var oldChartViewConfig = oldValue as ChartViewConfig;
                oldChartViewConfig.PropertyChanged -= chartView.ChartViewConfigInternalPropertyChanged;
            }

            if (newValue != null)
            {
                var newChartViewConfig = newValue as ChartViewConfig;
                newChartViewConfig.PropertyChanged += chartView.ChartViewConfigInternalPropertyChanged;
                chartView.BuildChartInWebView(newChartViewConfig);
            }
        }

        private void BuildChartInWebView(ChartViewConfig config)
        {
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = ChartBuilder.BuildHTML(config);

            if (Device.RuntimePlatform == Device.Android)
            {
                htmlSource.BaseUrl = string.Empty;
            }

            Source = htmlSource;
        }

        private void ChartViewConfigInternalPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(Config.BackgroundColor)))
            {
                ChangeChartBackgroundColor(Config.BackgroundColor);
            }
            else if (e.PropertyName.Equals(nameof(Config.ChartConfig)))
            {
                LoadChart((Config.ChartConfig));
            }
        }

        private void ChangeChartBackgroundColor(Color color)
        {
            Eval($"changeChartBackgroundColor('{ ChartBuilder.GetRGBColor(color) }');");
        }

        private void LoadChart(ChartConfig config)
        {
            var json = ChartBuilder.GetChartConfigJSON(config);
            Eval($"loadChart({ json });");
        }
    }
}
