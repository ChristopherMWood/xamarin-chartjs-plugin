using ChartTest.src;
using Xamarin.Forms;

namespace Plugin.XamarinChartJS.Models
{
    public class ViewProperties
    {
        public Color BackgroundColor { get; set; } = Color.White;
        public PrimaryAxis PrimaryAxis { get; set; } = PrimaryAxis.Horizontal;
        public int Padding { get; set; }
    }
}
