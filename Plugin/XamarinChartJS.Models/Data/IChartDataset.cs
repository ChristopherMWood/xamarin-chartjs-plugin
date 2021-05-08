using System.Collections.Generic;

namespace Plugin.XamarinChartJS.Models
{
    public interface IChartDataset
    {
        string type { get; set; }
        string label { get; set; }
        int? order { get; set; }
    }
}
