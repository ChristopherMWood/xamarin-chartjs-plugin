using System;
using System.IO;
using Newtonsoft.Json;
using Plugin.XamarinChartJS.Models;
using Xamarin.Forms;

namespace Plugin.XamarinChartJS
{
    public class ChartBuilder
    {
        public string BuildHTML(ChartViewConfig config)
        {
            var sizing = "width:100%;";

            if (config.ViewProperties.PrimaryAxis == ChartTest.src.PrimaryAxis.Vertical)
            {
                sizing = "height:100%;";
            }

            var chartJSFilePath = "chart.min.js";

            if (Device.RuntimePlatform == Device.Android)
            {
                chartJSFilePath = $"file:///android_asset/chart.min.js";
            }

            var padding = config.ViewProperties.Padding < 0 ? 0 : config.ViewProperties.Padding;
            //TODO: Swap with local resource
            var chartJsScript = $"<script type=\"text/javascript\" src=\"{chartJSFilePath}\"></script>";
            var viewportMeta = "<meta name='viewport' content='width=device-width,initial-scale=1,maximum-scale=1'/>";
            var bodyStyle = $"style=\"{sizing}background-color:{config.ViewProperties.BackgroundColor.ToHex()};\"";

            var document = $@"<html style=""width:100%;height:100%;"">
              <head>
                {chartJsScript}
                {viewportMeta}
              </head>
              <body {bodyStyle}>
                <div style=""padding: {padding}px;"">
                    <canvas id=""chartCanvas"">
                    </canvas>
                </div>
                { BuildChartJavascript(config) }
              </body>
            </html>";
            return document;
        }

        public string GetChartConfigJSON(ChartViewConfig config)
        {
            return JsonConvert.SerializeObject(config.ChartConfig,
                new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        private string BuildChartJavascript(ChartViewConfig config)
        {
            var jsonConfig = GetChartConfigJSON(config);

            return $@"
             <script>
                var chartConfig = { jsonConfig };
                var loadChartCalled = false;
                var chart;

                function loadChart(config) {{
                    if (loadChartCalled) {{
                        chart.destroy();
                    }}

                    loadChartCalled = true;
                    chart = new Chart(
                        document.getElementById('chartCanvas'),
                        config
                    );
                }};

                window.onload = function() {{
                    if (!loadChartCalled) {{
                        loadChart(chartConfig);
                    }}
                }};
            </script>
            ";
        }

        private string ChartTypeToString(ChartTypes type)
        {
            var enumString = Enum.GetName(typeof(ChartTypes), type);
            return char.ToLowerInvariant(enumString[0]) + enumString.Substring(1);
        }
    }
}
