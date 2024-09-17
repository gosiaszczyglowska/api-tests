using OpenQA.Selenium;
using PageObject.Business.Pages.Locators;
using System;

namespace PageObject.Business.Pages.Pages
{
    public class Navigation
    {
        private readonly IWebDriver driver;



        public Navigation(IWebDriver driver) => this.driver = driver ?? throw new ArgumentException(nameof(driver));

        public void CareersTab()
        {
            var careersTab = driver.FindElement(NavigationLocators.careersTabLocator);
            careersTab.Click();
        }
        public void AboutTab()
        {
            var careersTab = driver.FindElement(NavigationLocators.aboutTabLocator);
            careersTab.Click();
        }
        public void InsightsTab()
        {
            var careersTab = driver.FindElement(NavigationLocators.insightsTabLocator);
            careersTab.Click();
        }
    }
}
