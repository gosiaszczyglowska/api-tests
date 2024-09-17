using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using PageObject.Core.Utilities;
using PageObject.Business.Pages.Locators;
using PageObject.Business.Pages.Scripts;


namespace PageObject.Business.Pages.Pages
{
    public class Careers
    {
        private readonly SeleniumScripts scripts;
        private readonly Actions actions;
        private readonly Waits waits;
        public IWebDriver driver { get; set; }
        public Careers(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            waits = new Waits(driver);
            scripts = new SeleniumScripts(driver);
            actions = new Actions(driver);
        }


        public void StepSearchPostition(string language, string location)
        {
            SearchKeyword(language);
            scripts.CloseAutocompleteDropdown();
            SearchLocation(location);
            ClickRemoteCheckbox();
            ClickFindButton();
        }
        public void SearchKeyword(string language)
        {
            IWebElement searchPanel = driver.FindElement(CareersLocators.searchPanelLocator);
            IWebElement keywordField = searchPanel.FindElement(CareersLocators.keywordFieldLocator);
            keywordField.Click();
            keywordField.SendKeys(language);
        }

        public void SearchLocation(string location)
        {
            IWebElement searchPanel = driver.FindElement(CareersLocators.searchPanelLocator);
            IWebElement locationsDropdown = searchPanel.FindElement(CareersLocators.locationsDropdownLocator);
            locationsDropdown.Click();

            actions.SendKey(Keys.LeftControl);
            By locationDropdownOptionLocator = CareersLocators.GetLocationDropdownOptionLocator(location);
            IWebElement locationDropdownOption = driver.FindElement(locationDropdownOptionLocator);
            locationDropdownOption.Click();
        }

        public void ClickRemoteCheckbox()
        {
            IWebElement searchPanel = driver.FindElement(CareersLocators.searchPanelLocator);
            IWebElement remoteCheckbox = searchPanel.FindElement(CareersLocators.remoteCheckboxLocator);
            remoteCheckbox.Click();
        }

        public void ClickFindButton()
        {
            IWebElement searchPanel = driver.FindElement(CareersLocators.searchPanelLocator);
            IWebElement findButton = searchPanel.FindElement(CareersLocators.findButtonLocator);
            findButton.Click();
        }

        public void StepSortByDateAndVerify()
        {
            Log.LogInfo("Sorting Postitions by date...");
            string initialFirstItemTitle = driver.FindElement(CareersLocators.initialFirstItemTitleLocator).Text;
            Console.WriteLine($"Initial first item title is: {initialFirstItemTitle}");
            SortByDate();
            VerifyIfSortingWasDone(initialFirstItemTitle);
            string newFirstItemTitle = driver.FindElement(CareersLocators.newFirstItemTitleLocator).Text;
            Console.WriteLine($"First item title after sorting is: {newFirstItemTitle}");
        }

        public void SortByDate()
        {
            IWebElement sortByDate = waits.WaitUntilVisible(CareersLocators.sortByDateLocator, 5);
            sortByDate.Click();
        }

        public void ApplyForFirstPosition()
        {
            Log.LogInfo("Opening details of the first position on the list...");
            IWebElement resulItem1 = driver.FindElement(CareersLocators.resulItem1Locator);
            scripts.ScrollToElement(resulItem1);
            IWebElement viewAndApplyButton = resulItem1.FindElement(CareersLocators.viewAndApplyButtonLocator);
            viewAndApplyButton.Click();
        }

        public void VerifyIfSortingWasDone(string initialFirstItemTitle)
        {
            Log.LogInfo("Verifying if sorting was done...");
            WebDriverWait waitUntilSorted = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                bool isSorted = waitUntilSorted.Until(driver =>
                {
                    string newFirstItemTitle = driver.FindElement(CareersLocators.newFirstItemTitleLocator).Text;

                    return newFirstItemTitle != initialFirstItemTitle;
                });

                if (!isSorted)
                {
                    Log.LogInfo("Sorting was not done.");
                    Console.WriteLine("The list was not sorted within 3 seconds. Proceeding with the initial order.");
                }
            }
            catch (WebDriverTimeoutException ex)
            {
                Log.LogError("It's the same position after sorting", ex);
            }

        }

        public bool IsLanguagePresent(string language)
        {
            return driver.FindElements(By.XPath($"//*[contains(text(), '{language}')]")).Count > 0;
        }
    }
}
