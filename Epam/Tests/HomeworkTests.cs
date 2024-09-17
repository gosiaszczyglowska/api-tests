using System.IO;
using NUnit.Framework;
using PageObject.Core.Utilities;

namespace PageObject.Tests
{

    [TestFixture]

    public class HomeworkTests : TestBase  
    {

        [TestCase("Java", "All Locations")]
        [TestCase("Python", "All Cities in Poland")]
        public void PositionSearch(string language, string location)
        {
            navigation.CareersTab();
            careers.StepSearchPostition(language, location);
            careers.StepSortByDateAndVerify();
            careers.ApplyForFirstPosition();

            waits.Wait(5);                 //-to removeTODO: this menhod is not waiting, it Initializes a new instance of WebDriverWait class
            Log.LogInfo("Verifying that searched programming language is present in the opened article");
            Assert.IsTrue(careers.IsLanguagePresent(language), $"Text {language} not found on the page.");
        }

        [TestCase("BLOCKCHAIN")]
        [TestCase("Cloud")]
        [TestCase("Automation")]
        public void GlobalSearch(string query)
        {
            indexPage.StepSearchQuery(query);
            bool checkSearchResultsContainQuery = indexPage.CheckSearchResultsContainQuery(query);

            Assert.IsTrue(checkSearchResultsContainQuery, $"Not all links contain the query term '{query}'");
        }


        [TestCase("EPAM_Corporate_Overview_Q4_EOY.pdf")]
        public void DownloadCheck(string downloadedFileName)
        {
            string downloadDirectory = Core.Utilities.Configuration.Instance.GetAppSettings().DownloadDirectory;//move it to (static class) files

            navigation.AboutTab();
            about.DownloadOverviewFile();

            string downloadedFilePath = Path.Combine(downloadDirectory, downloadedFileName);

            waits.WaitForFileToDownload(downloadedFilePath, 30);

            Assert.IsTrue(File.Exists(downloadedFilePath));
        }


        [Test]
        public void TitleCheck()
        {
            Log.LogInfo("Running TitleCheck test");
            navigation.InsightsTab();
            insights.SwipeToTheThirdSlide();
            string slideText = insights.GetTitleFromSlide();
            insights.CLickReadMoreOnActiveSlide();
            string titleElement = insights.GetTitleFromArticle();

            Assert.True(slideText.Equals(titleElement), "Verifying that Slide Title is the same as Article Title");
        }

        [Test]
        public void ExampleTest_Failure()
        {
            Assert.Fail("This test is expected to fail, triggering the screenshot capture.");
        }

        [Test]
        public void ExampleTest_Success()
        {
            Assert.Pass("This test will pass, and no screenshot will be taken.");
        }
    }
}
