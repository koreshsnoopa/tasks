using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace framework_tests
{
    [TestFixture]
    public class SendFormTests : CommonConditions
    {
        const string MODE = "Compute Engine";

        [Test]
        [Category("All")]
        public void FillFormAndCheckTest()
        {
            ComputerEngineForm form = ComputerEngineFormCreator.WithCredentialsFromProperty();

            driver.Navigate().GoToUrl(GOOGLE_CLOUD_URL);
            GCPlatformPricingCalculator calc = new GCHomePage()
                .SearchInformation(INFO_TO_SEARCH)
                .GoToCalculator()
                .ActivateMode(MODE).FillComputerEngineForm(form);

            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Navigate().GoToUrl(YOPMAIL_URL);

            var mailPage = new MailMain().GenerateNewEmail();
            string mail = mailPage.GetEmailName();

            driver.SwitchTo().Window(driver.WindowHandles[0]);

            calc.AddEstimate();
            double priceFromGC = calc.GetTotalPrice();
            calc.EmailEstimate(mail);

            driver.SwitchTo().Window(driver.WindowHandles[1]);

            double priceFromEmail = mailPage.GoToMails().GetPriceFromMail();

            Assert.AreEqual(priceFromGC, priceFromEmail);
        }
    }
}
