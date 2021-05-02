namespace Plugin.XamarinChartJS.Models
{
    public class ChartConfig
    {
        public ViewProperties ViewProperties { get; set; } = new ViewProperties();
        public ChartTypes Type { get; set; }
        public ChartData Data { get; set; }
        public ChartOptions Options { get; set; }
    }
}
