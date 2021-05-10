using NUnit.Framework;
using Plugin.XamarinChartJS.Helpers;
using Xamarin.Forms;

namespace PluginTests
{
    public class ChartBuilderTests
    {
        [Test]
        public void GetRGBColorFormatsCorrectly()
        {
            Assert.AreEqual("rgb(255, 0, 0)", ChartBuilder.GetRGBColor(Color.Red));
            Assert.AreEqual("rgb(0, 128, 0)", ChartBuilder.GetRGBColor(Color.Green));
            Assert.AreEqual("rgb(0, 0, 255)", ChartBuilder.GetRGBColor(Color.Blue));
        }
    }
}