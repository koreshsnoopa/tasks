using System;
using System.IO;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace selenium_task_tests
{ 
    public class TestListener : ITestListener
    {
        public TestListener()
        {
        }

        Logger logger = LogManager.GetCurrentClassLogger();

        void ITestListener.SendMessage(TestMessage message)
        {
            throw new NotImplementedException();
        }

        void ITestListener.TestFinished(ITestResult result)
        {
            DateTime dt = new DateTime();
            //var result = TestContext.CurrentContext.Result.Outcome;
            if (result.Equals(ResultState.Failure) || result.Equals(ResultState.Error))
            {
                var screenFile = ((ITakesScreenshot)DriverSingleton.GetDriver()).GetScreenshot();
                screenFile
                    .SaveAsFile($"/Users/marialukasova/Projects/epam_tasks/selenium_task_tests/bin/Debug/netcoreapp3.1/screenshots/{DateTime.Now.ToString("dd_MM_yy_HH_mm_ss")}.png", ScreenshotImageFormat.Png);
            }
            DriverSingleton.CloseDriver();
        }

        void ITestListener.TestOutput(TestOutput output)
        {
            throw new NotImplementedException();
        }

        void ITestListener.TestStarted(ITest test)
        {
            throw new NotImplementedException();
        }

        private void SaveScreenshot()
        {
            try
            {
            var screenshot = ((ITakesScreenshot)DriverSingleton.GetDriver()).GetScreenshot();
            var filename = "_screenshot_" + DateTime.Now.Ticks + ".jpg";
            var path = "/Users/marialukasova/Projects/epam_tasks/selenium_task_tests/bin/Debug/netcoreapp3.1/screenshots/" + filename;
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Jpeg);
            var ScreenCapture = ((ITakesScreenshot)DriverSingleton.GetDriver()).GetScreenshot();
                logger.Info($"Save screenshot test");
            }
            catch(Exception ex)
            {
                logger.Error($"Failed to save screenshot: {ex.Message}");
            }
        }
    }
}
