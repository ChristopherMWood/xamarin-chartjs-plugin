using System.Collections.Generic;
using Plugin.Models;

namespace Plugin.XamarinChartJS.Models
{
    public class ChartOptions
    {
        public bool? responsive { get; set; }
        public bool? maintainAspectRatio { get; set; } = false;
        public double? aspectRatio { get; set; }
        public double? resizeDelay { get; set; }
        public double? devicePixelRatio { get; set; }
        public string locale { get; set; }
        public ChartInteraction interaction { get; set; }
        public ChartAnimation animation { get; set; }
        public ChartLayout layout { get; set; }
        public ChartLegend legend { get; set; }
    }
}
