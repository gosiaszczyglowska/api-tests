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


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            LogConfig();
        }

        private void LogConfig()
        {
            XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Core", "Log.config")));
            Console.WriteLine($"Logs will be stored in: {Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")}");
        }

        [SetUp]
        public void Setup()
        {
            baseClient = new BaseClient("https://jsonplaceholder.typicode.com"); //TODO: move to config
            userService = new UserService(baseClient); 
        }
    }
}
