using OpenQA.Selenium;


namespace PageObject.Business.Pages.Locators
{
    public static class AboutLocators
    {
        public static readonly By downloadButtonLocator = By.XPath("//span[contains(@class, 'button__content') and contains(text(), 'DOWNLOAD')]");
    }
}
