using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace framework_tests
{
    public class CommonConditions
    {
        protected IWebDriver driver;
        public const string GOOGLE_CLOUD_URL = "https://cloud.google.com/";
        public const string YOPMAIL_URL = "https://yopmail.com/ru/";

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
