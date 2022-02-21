using NUnit.Framework;

namespace framework_tests
{
    [TestFixture]
    public class SearchInformationTests : CommonConditions
    {
        [Test]
        [Category("Smoke")]
        [Category("All")]
        public void SearchInformationTest()
        {
            driver.Navigate().GoToUrl(GOOGLE_CLOUD_URL);
            GCPlatformPricingCalculator calc = new GCHomePage()
               .SearchInformation("Google Cloud Platform Pricing Calculator")
               .GoToCalculator();

            Assert.NotNull(calc);
        }
    }
}