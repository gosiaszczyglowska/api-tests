using OpenQA.Selenium;
using System;

namespace PageObject.Business.Pages.Scripts
{
    public class Actions
    {
        private readonly IWebDriver driver;
        public Actions(IWebDriver driver) => this.driver = driver ?? throw new ArgumentException(nameof(driver));

        public void DoubleClick(IWebElement element)
        {
            new OpenQA.Selenium.Interactions.Actions(driver)
              .Click(element)
              .Click(element)
              .Perform();
        }

        public void ClickAndSendKeys(IWebElement element, int pauseTime, string query)
        {
            new OpenQA.Selenium.Interactions.Actions(driver)
            .Click(element)
            .Pause(TimeSpan.FromSeconds(pauseTime))
            .SendKeys(query)
            .Perform();
        }

        public void SendKey(string key)
        {
            new OpenQA.Selenium.Interactions.Actions(driver)
            .SendKeys(key)
            .Perform();
        }
    }
}
