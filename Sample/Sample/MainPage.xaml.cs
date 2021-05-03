using System;
using System.ComponentModel;
using Plugin.XamarinChartJS;
using Sample.ViewModels;
using Xamarin.Forms;

namespace Sample
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private MainPageViewModel viewModel;

        public MainPage()
        {
            viewModel = new MainPageViewModel();
            InitializeComponent();
            BindingContext = viewModel;
        }

        public void OnChartTypeChanged(object sender, EventArgs e)
        {
            var selectedChartType = (string)chartTypePicker.SelectedItem;

            if (selectedChartType != null)
                viewModel.ChangeConfigType(selectedChartType);
        }

        async void ChangeColorTest(object sender, EventArgs args)
        {
            viewModel.ChangeConfigBackgroundColor((string)chartTypePicker.SelectedItem, Color.Orange);
        }
    }
}
