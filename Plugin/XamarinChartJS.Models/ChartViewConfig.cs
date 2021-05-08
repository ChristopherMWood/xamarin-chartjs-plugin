using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Plugin.XamarinChartJS.Models
{
    public class ChartViewConfig : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Color _backgroundColor = Color.White;
        public Color BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            set
            {
                if (_backgroundColor != value)
                {
                    _backgroundColor = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private ChartConfig _chartConfig { get; set; }
        public ChartConfig ChartConfig
        {
            get
            {
                return _chartConfig;
            }
            set
            {
                if (_chartConfig != value)
                {
                    _chartConfig = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
