using System;
using OpenQA.Selenium;

namespace framework_tests
{
    public class MUnreadMails : WebPage
    {
        By PriceFromMailLocator = By.XPath("//*[contains(text(),'Estimated Bill')]/following-sibling::*[contains(text(),'Monthly')]");
        By FrameWithMailLocator = By.Id("ifmail");
        By RefreshButtonLocator = By.Id("refresh");

        IWebElement _priceFromMail;

        public MUnreadMails()
        {
        }

        public double GetPriceFromMail()
        {
            int count = 0;
            while (count < 10)
            {
                try
                {
                    _driver.SwitchTo().Frame(_driver.FindElement(FrameWithMailLocator));
                    _priceFromMail = wait.Until(d => d.FindElement(PriceFromMailLocator));
                    break;
                }
                catch
                {
                    _driver.SwitchTo().DefaultContent();
                    _driver.FindElement(RefreshButtonLocator).Click();
                    count++;
                }
            }
            string message = _priceFromMail.Text;
            int first = message.IndexOf('D') + 1;
            message.Replace(",", "");

            _driver.SwitchTo().DefaultContent();
            return double.Parse(message.Substring(first));
        }
    }
}
