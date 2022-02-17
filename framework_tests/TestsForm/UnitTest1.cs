using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace framework_tests
{
    public class Tests : CommonConditions
    {
        //IWebDriver driver;
        //[SetUp]
        //public void Setup()
        //{
        //    driver = DriverSingleton.GetDriver();
        //}

        [Test]
        public void Test1()
        {
            ComputerEngineForm form = ComputerEngineFormCreator.WithCredentialsFromProperty();

            driver.Navigate().GoToUrl("https://cloud.google.com/");
            GCPlatformPricingCalculator calc = new GCHomePage()
                .SearchInformation("Google Cloud Platform Pricing Calculator")
                .GoToCalculator()
                .ActivateMode("Compute Engine").FillComputerEngineForm(form);
                //InputNumberOfInstances(4)
                //.ChooseSystem("Free").ChooseVMClass("Regular")
                //.ChooseInstanceType("n1-standard-8")
                //.SetGPUs(1, "NVIDIA Tesla V100")
                //.ChooseLocalSSD("2x375 Gb")
                //.ChooseDatacenterLocation("Frankfurt (europe-west3)")
                //.ChooseCommittedUsage("1 Year");
                //.AddEstimate().EmailEstimate("mlv418@yandex.ru");

            //((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            //driver.SwitchTo().Window(driver.WindowHandles.Last());
            //driver.Navigate().GoToUrl("https://yopmail.com/ru/");

            //var mailPage = new MailMain().GenerateNewEmail();
            //string mail = mailPage.GetEmailName();

            //driver.SwitchTo().Window(driver.WindowHandles[0]);

            //calc.AddEstimate();
            //double priceFromGC = calc.GetTotalPrice();
            //calc.EmailEstimate(mail);

            //driver.SwitchTo().Window(driver.WindowHandles[1]);

            //double priceFromEmail = mailPage.GoToMails().GetPriceFromMail();

            //Console.WriteLine("\n\n\n\n 1:" + priceFromGC + "\n\n\n\n 2:" + priceFromEmail);

            driver.Quit();
            Thread.Sleep(1000);
            Assert.Pass();
        }
    }
}
