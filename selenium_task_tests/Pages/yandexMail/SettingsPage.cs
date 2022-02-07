using OpenQA.Selenium;

namespace SeleniumTaskTests
{
    public class SettingsPage : WebPage
    {
        static string InformationAboutSenderXPath = "//span[contains(text(),'Информация')]";

        IWebElement _informationAboutSender;

        public SettingsPage() : base()
        {
            _informationAboutSender = FindElementByXPath(InformationAboutSenderXPath);
        }

        public SettingSenderInformation ChangeInformationAboutSender()
        {
            _informationAboutSender.Click();
            return new SettingSenderInformation();
        }
    }
}
