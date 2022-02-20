using NUnit.Framework;

namespace framework_tests
{
    [TestFixture]
    [Category("Smoke")]
    public class SearchInformationTests : CommonConditions
    {
        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl(GOOGLE_CLOUD_URL);
             new GCHomePage()
                .SearchInformation(INFO_TO_SEARCH)
                .GoToCalculator();

            Assert.Pass();
        }
    }
}