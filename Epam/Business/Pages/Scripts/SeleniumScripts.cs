using OpenQA.Selenium;
using System;

namespace PageObject.Business.Pages.Scripts
{
    public class SeleniumScripts
    {
        private readonly IWebDriver driver;

        public SeleniumScripts(IWebDriver driver) => this.driver = driver ?? throw new ArgumentException(nameof(driver));

        public readonly By autocompleteDropdownLocator = By.ClassName("autocomplete-suggestions");

        public void CloseAutocompleteDropdown()
        {
            IWebElement autocompleteDropdown = driver.FindElement(autocompleteDropdownLocator);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].style.display='none';", autocompleteDropdown);
        }
        public void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
