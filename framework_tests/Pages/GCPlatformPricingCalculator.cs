using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace framework_tests
{
    public class GCPlatformPricingCalculator : WebPage
    {
        By InputNomberOfInstancesLocator = By.XPath("//*[@ng-model='listingCtrl.computeServer.quantity']");
        By FirstFrameLocator = By.XPath("//iframe[@src][@allow]");
        By FrameWithFormLocator = By.Id("myFrame");
        By VMClassLocator = By.XPath("//*[@placeholder='VM Class']//div");
        By InstanceTypeLocator = By.XPath("//md-select[@placeholder='Instance type']//div");
        By SeriesLocator = By.XPath("//md-select[@placeholder='Series']//span/div");
        By GPUsLocator = By.XPath("//md-checkbox[@aria-label='Add GPUs']");
        By ChooseSSDLocator = By.XPath("//md-select[@placeholder='Local SSD'][not(@ng-disabled)]//span[@class]");
        By ChooseDatacenterLocationLocator = By.XPath("//md-select[@placeholder='Datacenter location'][contains(@ng-change,'Server')]//span[@*]");
        By SearchCityLocator = By.XPath("//input[@region-input][contains(@ng-model,'Server')]");
        By ChooseCityLocator = By.XPath("//md-option[@region-option][contains(@ng-repeat,'computeServer')]");
        By ChooseCommittedUsageLocator = By.XPath("//md-select[@placeholder='Committed usage'][contains(@ng-change,'Server')]//span[@*]");
        By AddToEstimateCFLocator = By.XPath("//button[contains(@ng-disabled,'Compute')]");
        By EmailEstimateLocator = By.XPath("//button[contains(@ng-click,'EmailForm')]");
        By EnterEmailLocator = By.XPath("//input[@ng-model='emailQuote.user.email']");
        By SendEmailLocator = By.XPath("//button[@aria-label='Send Email']");

        IWebElement _inputNumberOfInst;
        IWebElement _mode;
        IWebElement _instanceType;
        IWebElement _series;
        IWebElement _addToEstimateCompForm;
        IWebElement _emailEstimate;
        IWebElement _emailInput;
        IWebElement _sendEmail;

        public GCPlatformPricingCalculator() : base()
        {
        }

        public GCPlatformPricingCalculator ActivateMode(string mode)
        {
            _driver.SwitchTo().Frame(_driver.FindElement(FirstFrameLocator)).SwitchTo()
               .Frame(_driver.FindElement(FrameWithFormLocator));
            _mode = _driver.FindElement(By.XPath($"//div[@title='{mode}']/parent::md-tab-item"));
            if (_mode.GetAttribute("aria-selected").Equals("false"))
            {
                _mode.Click();
            }
            _driver.SwitchTo().DefaultContent();

            return this;
        }

        public GCPlatformPricingCalculator InputNumberOfInstances(int number)
        {
            _driver.SwitchTo().Frame(_driver.FindElement(FirstFrameLocator)).SwitchTo()
                .Frame(_driver.FindElement(FrameWithFormLocator));
            _inputNumberOfInst = _driver.FindElement(InputNomberOfInstancesLocator);
            _inputNumberOfInst.SendKeys(number.ToString());
            _driver.SwitchTo().DefaultContent();

            return this;
        }

        public GCPlatformPricingCalculator ChooseSystem(string operatingSystem)
        {
            _driver.SwitchTo().Frame(_driver.FindElement(FirstFrameLocator)).SwitchTo()
                 .Frame(_driver.FindElement(FrameWithFormLocator));
            var systems = _driver.FindElements(By.XPath($"//md-content//div[@class='md-text'][contains(text(),'{operatingSystem}')]"));
            if (systems.Count == 1)
            {
                _driver.FindElement(By.XPath("//md-select[contains(@aria-label, 'Operating System')]//span[@class]")).Click();
                _driver.FindElement(By.XPath($"//md-content//div[@class='md-text'][contains(text(),'{operatingSystem}')]")).Click();
            }
            _driver.SwitchTo().DefaultContent();

            return this;
        }

        public GCPlatformPricingCalculator ChooseVMClass(string vmClass)
        {
            _driver.SwitchTo().Frame(_driver.FindElement(FirstFrameLocator)).SwitchTo()
                .Frame(_driver.FindElement(FrameWithFormLocator));

            if (_driver.FindElement(VMClassLocator).Text != vmClass)
            {
                _driver.FindElement(By.XPath("//*[@placeholder='VM Class']//span[@class]")).Click();
                _driver.FindElement(By.XPath($"//md-option[@value='{vmClass.ToLower()}'][@aria-selected='false'][@ng-disabled]")).Click();
            }
            _driver.SwitchTo().DefaultContent();

            return this;
        }

        private void ChooseSeries(string series)
        {
            _series = _driver.FindElement(SeriesLocator);

            if (!_series.Text.Equals(series))
            {
                _driver.FindElement(By.XPath("//md-select[@placeholder='Series']//span[@class]")).Click();
                _driver.FindElement(By.XPath($"//md-option[@value='{series.ToLower()}']")).Click();
            }
        }

        public GCPlatformPricingCalculator ChooseInstanceType(string instanceType)
        {
            _driver.SwitchTo().Frame(_driver.FindElement(FirstFrameLocator)).SwitchTo()
                .Frame(_driver.FindElement(FrameWithFormLocator));

            _instanceType = _driver.FindElement(InstanceTypeLocator);
            string text = _instanceType.Text.Trim();
            ChooseSeries(instanceType.Split('-')[0]);

            if (!text.Equals(instanceType.Trim()))
            {
                _driver.FindElement(By.XPath("//md-select[@placeholder='Instance type']//span[@class]")).Click();
                _driver.FindElement(By.XPath($"//md-option/div[contains(text(),'{instanceType}')]/..")).Click();
            }
            _driver.SwitchTo().DefaultContent();

            return this;
        }

        public GCPlatformPricingCalculator SetGPUs(int numberOfGPUs, string GPUtype)
        {
            _driver.SwitchTo().Frame(_driver.FindElement(FirstFrameLocator)).SwitchTo()
               .Frame(_driver.FindElement(FrameWithFormLocator));

            wait.Until(d => d.FindElements(GPUsLocator)[0]).Click();

            _driver.FindElement(By.XPath("//md-select[@placeholder='GPU type']")).Click();
            _driver.FindElement(By.XPath($"//md-option[@value='{GPUtype.Replace(' ', '_').ToUpper()}']/following-sibling::md-option")).Click();
            _driver.FindElement(By.XPath("//md-select[@placeholder='Number of GPUs']")).Click();
            _driver.FindElement(By.XPath($"//md-option[@value='{numberOfGPUs}'][contains(@ng-repeat, 'Gpu')]")).Click();

            _driver.SwitchTo().DefaultContent();
            return this;
        }

        public GCPlatformPricingCalculator ChooseLocalSSD(string localSSD)
        {
            _driver.SwitchTo().Frame(_driver.FindElement(FirstFrameLocator)).SwitchTo()
              .Frame(_driver.FindElement(FrameWithFormLocator));

            _driver.FindElement(ChooseSSDLocator).Click();
            _driver.FindElement(By.XPath($"//md-option[@value='{localSSD[0]}']/div[contains(text(),'375')]/..")).Click();

            _driver.SwitchTo().DefaultContent();
            return this;
        }

        public GCPlatformPricingCalculator ChooseDatacenterLocation(string dcLocation)
        {
            _driver.SwitchTo().Frame(_driver.FindElement(FirstFrameLocator)).SwitchTo()
             .Frame(_driver.FindElement(FrameWithFormLocator));

            _driver.FindElement(ChooseDatacenterLocationLocator).Click();
            string city = dcLocation.Split(' ')[0];
            _driver.FindElement(SearchCityLocator).SendKeys(city);
            _driver.FindElement(ChooseCityLocator).Click();

            _driver.SwitchTo().DefaultContent();
            return this;
        }

        public GCPlatformPricingCalculator ChooseCommittedUsage(string committedUsage)
        {
            _driver.SwitchTo().Frame(_driver.FindElement(FirstFrameLocator)).SwitchTo()
            .Frame(_driver.FindElement(FrameWithFormLocator));

            _driver.FindElement(ChooseCommittedUsageLocator).Click();

            if (!int.TryParse(committedUsage[0].ToString(), out int res))
            {
                wait.Until(d => d.FindElements(By.XPath($"//div[text()='None']/..")))[1].Click();
            }
            else
            {
                wait.Until(d => d.FindElements(By.XPath($"//div[contains(text(),'{committedUsage[0]} Year')]/..")))[1].Click();
            }
           
            _driver.SwitchTo().DefaultContent();
            return this;
        }

        public GCPlatformPricingCalculator AddEstimate()
        {
            _driver.SwitchTo().Frame(_driver.FindElement(FirstFrameLocator)).SwitchTo()
            .Frame(_driver.FindElement(FrameWithFormLocator));

            _addToEstimateCompForm = _driver.FindElement(AddToEstimateCFLocator);
            _addToEstimateCompForm.Click();

            _driver.SwitchTo().DefaultContent();
            return this;
        }

        public GCPlatformPricingCalculator EmailEstimate(string email)
        {
            _driver.SwitchTo().Frame(_driver.FindElement(FirstFrameLocator)).SwitchTo()
            .Frame(_driver.FindElement(FrameWithFormLocator));

            _emailEstimate = _driver.FindElement(EmailEstimateLocator);
            _emailEstimate.Click();
            _emailInput = _driver.FindElement(EnterEmailLocator);
            _emailInput.SendKeys(email);
            _sendEmail = _driver.FindElement(SendEmailLocator);
            _sendEmail.Click();

            _driver.SwitchTo().DefaultContent();
            return this;
        }

        public double GetTotalPrice()
        {
            _driver.SwitchTo().Frame(_driver.FindElement(FirstFrameLocator)).SwitchTo()
          .Frame(_driver.FindElement(FrameWithFormLocator));

            string message = _driver.FindElement(By.XPath("//b[contains(text(),'Total')]")).Text;
            message.Replace(",", "");
            int first = message.IndexOf('D') + 1;
            int last = message.IndexOf('p') - 1;

            _driver.SwitchTo().DefaultContent();
            return double.Parse(message.Substring(first, last - first));
        }

        public GCPlatformPricingCalculator FillComputerEngineForm(ComputerEngineForm computerEngineForm)
        {
           InputNumberOfInstances(computerEngineForm.NumberOfInstances)
                .ChooseSystem(computerEngineForm.SoftWare).ChooseVMClass(computerEngineForm.VMClass)
                .ChooseInstanceType(computerEngineForm.InstanceType)
                .SetGPUs(computerEngineForm.NumberOfGPUs, computerEngineForm.GPUType)
                .ChooseLocalSSD(computerEngineForm.LocalSSD)
                .ChooseDatacenterLocation(computerEngineForm.DatacenterLocation)
                .ChooseCommittedUsage(computerEngineForm.CommitedUsage);

            return this;
        }
    }
}
