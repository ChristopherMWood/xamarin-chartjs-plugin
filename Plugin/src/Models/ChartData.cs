using System.Collections.Generic;

namespace Plugin.XamarinChartJS.Models
{
    public class ChartData
    {
        public IEnumerable<ChartDataset> datasets { get; set; }
        public IEnumerable<string> labels { get; set; }
    }
}
