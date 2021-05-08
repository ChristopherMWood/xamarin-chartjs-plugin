using System.Collections.Generic;

namespace Plugin.XamarinChartJS.Models
{
    public class ChartNumberDataset : IChartDataset
    {
        public string type { get; set; }
        public string label { get; set; }
        public int? order { get; set; }
        public IEnumerable<int> data { get; set; }
        public IEnumerable<string> backgroundColor { get; set; }
    }
}
