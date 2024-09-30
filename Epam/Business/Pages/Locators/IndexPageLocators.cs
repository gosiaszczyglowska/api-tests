using OpenQA.Selenium;


namespace PageObject.Business.Pages.Locators
{
    public static class IndexPageLocators
    {
        public static readonly By acceptCookiesButtonLocator = By.Id("onetrust-accept-btn-handler");
        public static readonly By searchIconLocator = By.ClassName("header-search__button");
        public static readonly By searchPanelLocator = By.ClassName("header-search__panel");
        public static readonly By searchInputLocator = By.Name("q");
        public static readonly By findButtonLocator = By.XPath("//button[contains(span/text(), 'Find')]");
        public static readonly By resultsLinksLocator = By.ClassName("search-results__title-link");
        public static readonly By cookiePopUpLocator = By.Id("onetrust-banner-sdk");
        public static readonly By acceptAllLocator = By.Id("onetrust-accept-btn-handler");
    }
}
