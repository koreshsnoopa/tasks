using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace selenium_task_tests
{
    public class CommonConditions
    {
        protected IWebDriver driver;
        public static string YahooURL = "https://www.yahoo.com/";
        public static string YandexURL = "https://mail.yandex.by/";

        [SetUp]
        public void SetUp()
        {
            driver = DriverSingleton.GetDriver();
        }

        [TearDown]
        public void StopBrowser()
        {
            var result = TestContext.CurrentContext.Result.Outcome;
            if (result.Equals(ResultState.Failure) || result.Equals(ResultState.Error))
            {
                var screenFile = ((ITakesScreenshot)DriverSingleton.GetDriver()).GetScreenshot();
                screenFile
                    .SaveAsFile($"/Users/marialukasova/Projects/epam_tasks/selenium_task_tests/bin/Debug/netcoreapp3.1/screenshots/{DateTime.Now.ToString("dd_MM_yy_HH_mm_ss")}.png", ScreenshotImageFormat.Png);
            }
            DriverSingleton.CloseDriver();
        }

    }
}
