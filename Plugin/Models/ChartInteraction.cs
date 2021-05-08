using System.Collections.Generic;

namespace Plugin.XamarinChartJS.Models
{
    public class ChartInteraction
    {
        public string mode { get; set; }
        public bool? intersect { get; set; }
        public string axis { get; set; }
        public IEnumerable<string> events { get; set; }
    }
}
