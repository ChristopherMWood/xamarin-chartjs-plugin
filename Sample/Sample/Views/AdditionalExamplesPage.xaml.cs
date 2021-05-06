using System;
using Sample.Views.AdditionalExamples;
using Xamarin.Forms;

namespace Sample.Views
{
    public partial class AdditionalExamplesPage : ContentPage
    {
        public AdditionalExamplesPage()
        {
            InitializeComponent();
        }

        async void PageLoadTest(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ChartLoadStressTest());
        }
    }
}
