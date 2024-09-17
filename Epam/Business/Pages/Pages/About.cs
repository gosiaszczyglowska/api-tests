using OpenQA.Selenium;
using System;
using System.IO;
using PageObject.Core.Utilities;
using PageObject.Business.Pages.Locators;
using PageObject.Business.Pages.Scripts;

namespace PageObject.Business.Pages.Pages
{
    public class About
    {
        private readonly SeleniumScripts scripts;
        public IWebDriver driver { get; set; }

        public About(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            scripts = new SeleniumScripts(driver);
        }



        public void DownloadOverviewFile()
        {
            Log.LogInfo("Downloading Overview File...");
            var downloadButton = driver.FindElement(AboutLocators.downloadButtonLocator);
            scripts.ScrollToElement(downloadButton);
            downloadButton.Click();
        }

        public void DeleteFile(string downloadedFilePath)
        {

            if (File.Exists(downloadedFilePath))
            {
                try
                {
                    Log.LogInfo("Deleting file...");
                    File.Delete(downloadedFilePath);
                    Log.LogInfo("File deleted successfully");
                }
                catch (Exception ex)
                {
                    Log.LogError("Failed to delete file", ex);
                    Log.LogInfo($"{ex.Message}");
                }
            }
            else
            {
                Log.LogWarn("File does not exist");
            }
        }
    }
}
