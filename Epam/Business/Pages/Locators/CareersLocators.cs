using OpenQA.Selenium;


namespace PageObject.Business.Pages.Locators
{
    public static class CareersLocators
    {
        public static readonly By searchPanelLocator = By.Id("jobSearchFilterForm");
        public static readonly By keywordFieldLocator = By.Id("new_form_job_search-keyword");
        public static readonly By locationsDropdownLocator = By.CssSelector("span.select2-selection__rendered[title='All Cities in Poland']");
        public static readonly By remoteCheckboxLocator = By.ClassName("recruiting-search__filter-label-23");
        public static readonly By findButtonLocator = By.XPath("//*[@id = 'jobSearchFilterForm']/button");
        public static readonly By sortByDateLocator = By.XPath("//*[@class='search-result__sorting-label list' and text()='Date']");
        public static readonly By initialFirstItemTitleLocator = By.XPath("//*[@id='main']//ul/li[1]//h5/a");
        public static readonly By newFirstItemTitleLocator = By.XPath("//*[@id='main']//ul/li[1]//h5/a");
        public static readonly By resulItem1Locator = By.XPath("//*[@id='main']//ul/li[1]");
        public static readonly By viewAndApplyButtonLocator = By.XPath("//a[contains(text(), 'View and apply')]");
        public static By GetLocationDropdownOptionLocator(string location) 
        { 
        return By.XPath($"//li[contains(text(), '{location}')]");
        }
    
    }
}
