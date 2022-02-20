using OpenQA.Selenium;

namespace framework_tests
{
    public class GCHomePage : WebPage
    {
        By SearchButtonLocator = By.XPath("//input[@name]");

        IWebElement _searchButton;

        public GCHomePage() : base()
        {
            _searchButton = _driver.FindElement(SearchButtonLocator);
        }

        public GCSearchResultPage SearchInformation(string input)
        {
            _searchButton.Click();
            _searchButton.SendKeys(input);
            _searchButton.SendKeys(Keys.Enter);

            return new GCSearchResultPage();
        }
    }
}
