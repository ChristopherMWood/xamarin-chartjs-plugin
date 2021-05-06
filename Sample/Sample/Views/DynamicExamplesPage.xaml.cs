using System;
using Sample.ViewModels;
using Xamarin.Forms;

namespace Sample.Views
{
    public partial class DynamicExamplesPage : ContentPage
    {
        public DynamicExamplesViewModel viewModel;

        public DynamicExamplesPage()
        {
            viewModel = new DynamicExamplesViewModel();
            InitializeComponent();
            BindingContext = viewModel;
        }

        public void OnChartTypeChanged(object sender, EventArgs e)
        {
            var selectedChartType = (string)chartTypePicker.SelectedItem;

            if (selectedChartType != null)
                viewModel.ChangeConfigType(selectedChartType);
        }

        public void OnChartColorChanged(object sender, EventArgs e)
        {
            var selectedColor = (Color)colorPicker.SelectedItem;
            viewModel.ChangeConfigBackgroundColor(selectedColor);
        }
    }
}
