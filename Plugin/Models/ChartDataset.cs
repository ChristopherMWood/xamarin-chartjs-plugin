using System.Collections.Generic;

namespace Plugin.XamarinChartJS.Models
{
    public class ChartDataset
    {
        public ChartTypes type { get; set; }
        public string label { get; set; }
        public IEnumerable<string> backgroundColor { get; set; }
        public IEnumerable<int> data { get; set; }
    }
}
