using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;

namespace PageObject.Core.Utilities
{
    public class Waits
    {
        private readonly IWebDriver driver;

        public Waits(IWebDriver driver) => this.driver = driver ?? throw new ArgumentException(nameof(driver));


        public WebDriverWait Wait(int time)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(time));
        }

        public IWebElement WaitUntilVisible(By locator, int time)
        {
            var wait = Wait(time);
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public IWebElement WaitUntilClickable(By locator, int time) 
        {
            var wait = Wait(time); 
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public IReadOnlyCollection<IWebElement> WaitUntilElementsArePresent(By locator, int time)
        {
            var wait = Wait(time);
            return wait.Until(driver => driver.FindElements(locator));
        }

        public bool WaitForFileToDownload(string filePath, int time)
        {
            var wait = Wait(time);
            return wait.Until(d => File.Exists(filePath));
        }
    }
}
