using System;
using NLog;
using OpenQA.Selenium;

namespace selenium_task_tests
{
    public class SettingSenderInformation : WebPage
    {
        static string NameInputXPath = "//input[@name='from_name']";
        static string SaveChangesButtonXPath = "//button[@type='submit']";

        IWebElement _nameInput;
        IWebElement _saveChagesButton;
        Logger logger = LogManager.GetCurrentClassLogger();

        public SettingSenderInformation() : base()
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
            if (string.IsNullOrEmpty(newName))
            {
                logger.Error("Name is not changed: New name is empty!");
                throw new ArgumentException("New name is empty!");
            }
            _nameInput.Clear();
            _nameInput.SendKeys(newName);
            _saveChagesButton = FindElementByXPath(SaveChangesButtonXPath);
            _saveChagesButton.Click();
            logger.Info($"Name is changed: New name {newName}");
        }
    }
}
