using OpenQA.Selenium;
using System;
using PageObject.Core.Utilities;
using PageObject.Business.Pages.Locators;
using PageObject.Business.Pages.Scripts;

namespace PageObject.Business.Pages.Pages
{
    public class Insights
    {
        private readonly Actions actions;
        private readonly Waits waits;
        public IWebDriver driver { get; set; }
        public Insights(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            waits = new Waits(driver);
            actions = new Actions(driver);
        }

        public void SwipeToTheThirdSlide()
        {
            Log.LogInfo("Swipping to the 3rd slide");
            var sliderRightArrow = driver.FindElement(InsightsLocators.sliderRightArrowLocator);
            actions.DoubleClick(sliderRightArrow);
        }

        public string GetTitleFromSlide()
        {
            Log.LogInfo("Saving Slide Title as SLideTextElement...");
            IWebElement firstSlider = waits.WaitUntilVisible(InsightsLocators.firstSliderLocator, 10);
            IWebElement activeSlide = firstSlider.FindElement(InsightsLocators.activeSlideLocator);
            IWebElement slideTextElement = activeSlide.FindElement(InsightsLocators.slideTextElementLocator);
            return slideTextElement.Text.Trim();
        }

        public void CLickReadMoreOnActiveSlide()
        {
            Log.LogInfo("Clicking Read More button...");
            IWebElement firstSlider = waits.WaitUntilVisible(InsightsLocators.firstSliderLocator, 10);
            IWebElement activeSlide = firstSlider.FindElement(InsightsLocators.activeSlideLocator);
            IWebElement readMoreButton = activeSlide.FindElement(InsightsLocators.readMoreButtonLocator);
            readMoreButton.Click();
        }

        public string GetTitleFromArticle()
        {
            Log.LogInfo("Saving Article Title as ArticleTitleElement...");
            IWebElement articleFirstSection = driver.FindElement(InsightsLocators.articleFirstSectionLocator);
            IWebElement articleTitleElement = articleFirstSection.FindElement(InsightsLocators.articleTitleElementLocator);
            return articleTitleElement.Text.Trim();
        }
    }
}
