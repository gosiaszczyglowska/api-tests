using NUnit.Framework;
using PageObject.Core;
using PageObject.Core.Utilities;
using PageObject.Business.Pages.Pages;

namespace PageObject.Tests
{
    public class TestBase
    {
        protected BrowserFactory browserFactory;
        protected IndexPage indexPage;
        protected Waits waits;
        protected Navigation navigation;
        protected Careers careers;
        protected Insights insights;
        protected About about;

        [SetUp]
        public void SetUp()
        {
            browserFactory = new BrowserFactory();
            browserFactory.ConfigureLogging();
            InitializePageObjects();
            PrepareTestEnvironment();
        }

        private void InitializePageObjects()
        {
            indexPage = new IndexPage(browserFactory.Driver);
            waits = new Waits(browserFactory.Driver);
            navigation = new Navigation(browserFactory.Driver);
            careers = new Careers(browserFactory.Driver);
            insights = new Insights(browserFactory.Driver);
            about = new About(browserFactory.Driver);
        }

        private void PrepareTestEnvironment()
        {
            indexPage.Open();
            indexPage.AcceptCookies();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Screenshot.TakeScreenshot(browserFactory.Driver, TestContext.CurrentContext.Test.Name);
            }
            
            browserFactory.DeleteAllFilesInDownloadDirectory(); //TODO: This should not be in browserFactory
                                                                //Instead create a Files (utilites)class and move all fales related actions there, including the ones  in the tests
            browserFactory.CloseAndQuit();
        }
    }
}
