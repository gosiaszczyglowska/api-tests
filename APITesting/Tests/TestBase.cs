using APITesting.Business;
using APITesting.Core;
using log4net.Config;
using log4net;
using NUnit.Framework;
using static APITesting.Tests.Tests;

namespace APITesting.Tests
{
    internal class TestBase
    {
        protected UserService? userService;
        protected BaseClient? baseClient;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(UserServiceTests));//TODO: What does it log?

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Core", "Log.config"))); // TODO: What does it do and can it be moved to another class?
            Console.WriteLine($"Logs will be stored in: {Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")}");
        }

        [SetUp]
        public void Setup()
        {
            baseClient = new BaseClient("https://jsonplaceholder.typicode.com"); //TODO: move to config
            userService = new UserService(baseClient); //TODO: create UserService object in UserServiceTests class
            Logger.Info("Test setup complete.");
        }
    }
}
