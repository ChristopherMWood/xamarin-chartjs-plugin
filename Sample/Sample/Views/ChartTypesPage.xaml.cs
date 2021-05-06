using System;
using System.ComponentModel;
using Sample.ViewModels;
using Xamarin.Forms;

namespace Sample.Views
{
    public partial class ChartTypesPage : ContentPage, INotifyPropertyChanged
    {
        private ChartTypesViewModel viewModel;

        public ChartTypesPage()
        {
            viewModel = new ChartTypesViewModel();
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
