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
        private static readonly ILog Logger = LogManager.GetLogger(typeof(UserServiceTests));

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Core", "Log.config")));
            Console.WriteLine($"Logs will be stored in: {Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")}");
        }

        [SetUp]
        public void Setup()
        {
            baseClient = new BaseClient("https://jsonplaceholder.typicode.com");
            userService = new UserService(baseClient);
            Logger.Info("Test setup complete.");
        }
    }
}
