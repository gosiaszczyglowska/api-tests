using OpenQA.Selenium;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace PageObject.Core.Utilities
{
    internal class Screenshot
    {
        public static void TakeScreenshot(IWebDriver driver, string testName)
        {
            string screenshotsDirectory = Path.Combine(Environment.CurrentDirectory, "Screenshots");

            if (!Directory.Exists(screenshotsDirectory))
            {
                Directory.CreateDirectory(screenshotsDirectory);
            }

            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string sanitizedTestName = SanitizeFileName(testName);

            var screenshotPath = Path.Combine(screenshotsDirectory, $"{sanitizedTestName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

            screenshot.SaveAsFile(screenshotPath);
            Console.WriteLine($"Screenshot saved to: {screenshotPath}");
        }

        private static string SanitizeFileName(string fileName)
        {
            return Regex.Replace(fileName, @"[<>:""/\\|?*\[\]]", "_");
        }
    }
}
