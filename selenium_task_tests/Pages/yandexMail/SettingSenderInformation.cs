using OpenQA.Selenium;

namespace selenium_task_tests
{
    public class SettingSenderInformation : WebPage
    {
        static string NameInputXPath = "//input[@name='from_name']";
        static string SaveChangesButtonXPath = "//button[@type='submit']";

        IWebElement _nameInput;
        IWebElement _saveChagesButton;

        public SettingSenderInformation(IWebDriver driver) : base(driver)
        {
            _nameInput = FindElementByXPath(NameInputXPath);
        }

        public string GetName()
        {
            string name = _nameInput.GetAttribute("value");
            return name;
        }

        public void ChangeName(string newName)
        {
            _nameInput.Clear();
            _nameInput.SendKeys(newName);
            _saveChagesButton = FindElementByXPath(SaveChangesButtonXPath);
            _saveChagesButton.Click();
        }
    }
}
