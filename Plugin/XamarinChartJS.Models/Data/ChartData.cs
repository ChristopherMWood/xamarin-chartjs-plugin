using System.Collections.Generic;

namespace Plugin.XamarinChartJS.Models
{
    public class ChartData
    {
        public IEnumerable<IChartDataset> datasets { get; set; }
        public IEnumerable<string> labels { get; set; }
    }
}
