using Sample.ViewModels;
using Xamarin.Forms;

namespace Sample.Views
{
    public partial class LayoutExamplesPage : ContentPage
    {
        public LayoutExamplesViewModel viewModel;

        public LayoutExamplesPage()
        {
            viewModel = new LayoutExamplesViewModel();
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
