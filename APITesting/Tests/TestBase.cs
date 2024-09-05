using APITesting.Business;
using APITesting.Core.Client;
using log4net.Config;
using log4net;
using NUnit.Framework;
using APITesting.Business.User;

namespace APITesting.Test.Tests
{
    internal class TestBase
    {
        protected UserService? userService;
        protected BaseClient? baseClient;
        //private static readonly ILog Logger = LogManager.GetLogger(typeof(UserServiceTests));//TODO: What does it log?

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Core", "Log.config"))); // TODO: What does it do and can it be moved to another class?
            //create a private method
            Console.WriteLine($"Logs will be stored in: {Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")}");
        }

        [SetUp]
        public void Setup()
        {
            baseClient = new BaseClient("https://jsonplaceholder.typicode.com"); //TODO: move to config
            userService = new UserService(baseClient); //TODO: create UserService object in UserServiceTests class (one for all the tests)
            //Logger.Info("Test setup complete.");
        }
    }
}
