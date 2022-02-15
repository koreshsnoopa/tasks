using System;
using NLog;
using OpenQA.Selenium;

namespace SeleniumTaskTests
{
    public class SettingSenderInformation : WebPage
    {
        By NameInputXPath = By.XPath("//input[@name='from_name']");
        By SaveChangesButtonXPath = By.XPath("//button[@type='submit']");

        IWebElement _nameInput;
        IWebElement _saveChagesButton;
        Logger logger = LogManager.GetCurrentClassLogger();

        public SettingSenderInformation() : base()
        {
            _nameInput = _driver.FindElement(NameInputXPath);
        }

        public string GetName()
        {
            string name = _nameInput.GetAttribute("value");
            return name;
        }

        public void ChangeName(string newName)
        {
            if (string.IsNullOrEmpty(newName))
            {
                logger.Error("Name is not changed: New name is empty!");
                throw new ArgumentException("New name is empty!");
            }
            _nameInput.Clear();
            _nameInput.SendKeys(newName);
            _saveChagesButton = _driver.FindElement(SaveChangesButtonXPath);
            _saveChagesButton.Click();
            logger.Info($"Name is changed: New name {newName}");
        }
    }
}
