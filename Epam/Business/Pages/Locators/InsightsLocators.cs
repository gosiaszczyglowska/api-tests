using OpenQA.Selenium;


namespace PageObject.Business.Pages.Locators
{
    public static class InsightsLocators
    {
        public static By sliderRightArrowLocator = By.XPath("//button[@type='button' and @class='slider__right-arrow slider-navigation-arrow']");
        public static By firstSliderLocator = By.XPath("(//div[@class='slider section'])[1]");
        public static By activeSlideLocator = By.XPath(".//*[@class='owl-item active' and @aria-hidden='false']");
        public static By slideTextElementLocator = By.XPath(".//p[@class='scaling-of-text-wrapper']");
        public static By readMoreButtonLocator = By.TagName("a");
        public static By articleFirstSectionLocator = By.XPath("//main[@id='main']//div[@class='section'][1]");
        public static By articleTitleElementLocator = By.XPath("//div[contains(@class, 'column-control')]//div[contains(@class, 'text')]");
    }
}
