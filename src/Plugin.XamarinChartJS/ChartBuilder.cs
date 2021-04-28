using System;
using Newtonsoft.Json;
using Plugin.XamarinChartJS.Models;

namespace Plugin.XamarinChartJS
{
    public class ChartBuilder
    {
        public string BuildHTML(ChartTypes chartType, ChartData data, ChartOptions options = null)
        {
            var chartScript = GetChartScript(chartType, data, options);
            return GetChartHTML(chartScript);
        }

        private string GetChartScript(ChartTypes chartType, ChartData data, ChartOptions options)
        {
            var chartConfig = new
            {
                type = Enum.GetName(typeof(ChartTypes), chartType).ToLower(),
                data = data,
                options = options
            };
            var jsonConfig = JsonConvert.SerializeObject(chartConfig);

            var script = $@"var config = { jsonConfig };
            window.onload = function() {{
              var canvasContext = document.getElementById(""chart"").getContext(""2d"");
              new Chart(canvasContext, config);
            }};";
            return script;
        }

        private string GetChartHTML(string chartConfig)
        {
            var inlineStyle = "style=\"width:100%;height:100%;\"";
            var chartJsScript = "<script src=\"Chart.bundle.min.js\"></script>";
            var chartConfigJsScript = $"<script>{chartConfig}</script>";

            var chartContent = $@"<div id=""chart-container"" {inlineStyle}>
              <canvas id=""chart"" />
                </div>";
                        var document = $@"<html style=""width:97%;height:100%;"">
              <head>{chartJsScript}</head>
              <body {inlineStyle}>
                {chartContent}
                {chartConfigJsScript}
              </body>
            </html>";
            return document;
        }
    }
}
