using OpenQA.Selenium;

namespace SeleniumTaskTests
{
    public class SettingsPage : WebPage
    {
        By InformationAboutSenderXPath = By.XPath("//span[contains(text(),'Информация')]");

        IWebElement _informationAboutSender;

        public SettingsPage() : base()
        {
            _informationAboutSender = _driver.FindElement(InformationAboutSenderXPath);
        }

        public SettingSenderInformation ChangeInformationAboutSender()
        {
            _informationAboutSender.Click();
            return new SettingSenderInformation();
        }
    }
}
