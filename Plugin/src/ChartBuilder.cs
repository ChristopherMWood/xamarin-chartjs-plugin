using System;
using Newtonsoft.Json;
using Plugin.XamarinChartJS.Models;

namespace Plugin.XamarinChartJS
{
    public class ChartBuilder
    {
        public string BuildHTML(ChartConfig config)
        {
            var sizing = "width:100%;";

            if (config.ViewProperties.PrimaryAxis == ChartTest.src.PrimaryAxis.Vertical)
            {
                sizing = "height:100%;";
            }

            var padding = config.ViewProperties.Padding < 0 ? 0 : config.ViewProperties.Padding;

            //TODO: Swap with local resource
            var chartJsScript = "<script src=\"https://cdn.jsdelivr.net/npm/chart.js\"></script>";
            var bodyStyle = $"style=\"{sizing}background-color:{config.ViewProperties.BackgroundColor.ToHex()};\"";

            var document = $@"<html style=""width:100%;height:100%;"">
              <head>{chartJsScript}</head>
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

        public string GetChartConfigJSON(ChartConfig config)
        {
            var chartConfig = new
            {
                type = ChartTypeToString(config.Type),
                data = config.Data,
                options = config.Options
            };

            return JsonConvert.SerializeObject(chartConfig,
                new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
        }

        private string BuildChartJavascript(ChartConfig config)
        {
            return $@"
             <script>
                var chartConfig = { GetChartConfigJSON(config) };
                var loadChartCalled = false;
                var chart;

                function loadChart(config) {{
                    if (loadChartCalled) {{
                        chart.destroy();
                    }}

                    chartLoadCalled = true;
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
