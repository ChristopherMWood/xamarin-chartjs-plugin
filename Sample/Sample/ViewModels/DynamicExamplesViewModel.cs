using System.Collections.Generic;
using System.ComponentModel;
using Plugin.XamarinChartJS.Models;
using Sample.Helpers;
using Xamarin.Forms;

namespace Sample.ViewModels
{
    public class DynamicExamplesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string SelectedType { get; set; } = Plugin.XamarinChartJS.ChartTypes.Line;
        public List<string> Types { get; set; } = new List<string>()
        {
            Plugin.XamarinChartJS.ChartTypes.Line,
            Plugin.XamarinChartJS.ChartTypes.Bar,
            Plugin.XamarinChartJS.ChartTypes.Radar,
            Plugin.XamarinChartJS.ChartTypes.Doughnut,
            Plugin.XamarinChartJS.ChartTypes.Pie,
            Plugin.XamarinChartJS.ChartTypes.PolarArea,
            Plugin.XamarinChartJS.ChartTypes.Bubble,
            Plugin.XamarinChartJS.ChartTypes.Scatter
        };

        public Color SelectedColor { get; set; } = Color.White;
        public List<Color> Colors { get; set; } = new List<Color>()
        {
            Color.Red,
            Color.Orange,
            Color.Black,
            Color.White
        };

        private ChartViewConfig _config;
        public ChartViewConfig Config
        {
            get { return _config; }
            set
            { _config = value; OnPropertyChanged("Config"); }
        }
        public ChartViewConfig ConfigTwo { get; set; }
        public ChartViewConfig ConfigThree { get; set; }

        public DynamicExamplesViewModel()
        {
            Config = RandomChartBuilder.GetChartConfig(Plugin.XamarinChartJS.ChartTypes.Pie, Color.White);
            ConfigTwo = RandomChartBuilder.GetChartConfig(Plugin.XamarinChartJS.ChartTypes.Line, Color.White);
            ConfigThree = RandomChartBuilder.GetChartConfig(Plugin.XamarinChartJS.ChartTypes.Pie, Color.White);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ChangeConfigType(string chartType)
        {
            Config = RandomChartBuilder.GetChartConfig(chartType, Color.White);
        }

        public void ChangeConfigBackgroundColor(Color color)
        {
            Config.ViewProperties.BackgroundColor = Color.Red;
            Config = Config;
            //OnPropertyChanged("Config");
        }
    }
}
