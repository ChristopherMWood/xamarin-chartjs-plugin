using NUnit.Framework;
using Plugin.XamarinChartJS;

namespace PluginTests
{
    public class Tests
    {
        [Test]
        public void ChartTypesMatchChartJsTypes()
        {
            Assert.AreEqual("line", ChartTypes.Line);
            Assert.AreEqual("bar", ChartTypes.Bar);
            Assert.AreEqual("radar", ChartTypes.Radar);
            Assert.AreEqual("doughnut", ChartTypes.Doughnut);
            Assert.AreEqual("pie", ChartTypes.Pie);
            Assert.AreEqual("polarArea", ChartTypes.PolarArea);
            Assert.AreEqual("bubble", ChartTypes.Bubble);
            Assert.AreEqual("scatter", ChartTypes.Scatter);
        }
    }
}