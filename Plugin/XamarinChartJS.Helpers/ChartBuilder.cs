using System.Collections.Generic;
using Newtonsoft.Json;
using Plugin.XamarinChartJS.Models;
using Xamarin.Forms;

namespace Plugin.XamarinChartJS.Helpers
{
    public class ChartBuilder
    {
        public string BuildHTML(ChartViewConfig config)
        {
            var parentHtmlStyles = new Dictionary<string, string>
            {
                { "width", "100%" },
                { "height", "100%" },
                { "overflow", "hidden" },
            };

            var bodyStyles = new Dictionary<string, string>
            {
                { "overflow", "hidden" },
                { "background-color", GetRGBColor(config.BackgroundColor) }
            };

            var contentDivStyles = new Dictionary<string, string>
            {
                { "height", "100%" },
                { "width", "100%" }
            };

            var chartJsScript = $"<script type=\"text/javascript\" src=\"{ GetChartJSLocalPath() }\"></script>";
            var viewportMeta = "<meta name='viewport' content='width=device-width,initial-scale=1,maximum-scale=1'/>";

            var canvasStyles = new Dictionary<string, string>
            {
                { "width", "100" },
                { "height", "100" }
            };

            return $@"
            <html style=""{ GetStyleString(parentHtmlStyles) }"">
              <head>
                {chartJsScript}
                {viewportMeta}
              </head>
              <body style=""{ GetStyleString(bodyStyles) }"">
                <div style=""{ GetStyleString(contentDivStyles) }"">
                  <canvas id=""chartCanvas"" style=""{ GetStyleString(canvasStyles) }"">
                  </canvas>
                </div>
                { BuildChartJavascript(config) }
              </body>
            </html>";
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

        private string GetChartJSLocalPath()
        {
            return Device.RuntimePlatform == Device.Android ? "file:///android_asset/chart.min.js" : "chart.min.js";
        }

        private string GetRGBColor(Color color)
        {
            var red = (int)(color.R * 255);
            var green = (int)(color.G * 255);
            var blue = (int)(color.B * 255);
            return $"rgb({red}, {green}, {blue})";
        }

        private string GetStyleString(Dictionary<string, string> styleSettings)
        {
            var styleString = string.Empty;

            foreach (var setting in styleSettings)
            {
                styleString += $"{ setting.Key }: { setting.Value }; ";
            }

            return styleString;
        }
    }
}
