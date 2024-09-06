using APITesting.Core.Client;
using log4net.Config;
using NUnit.Framework;
using APITesting.Business.User;
using Microsoft.Extensions.Configuration;

namespace APITesting.Test.Tests
{
    internal class TestBase
    {
        protected UserService? userService;
        protected BaseClient? baseClient;
        private IConfigurationRoot configuration;


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

            configuration = ConfigurationHelper.GetConfiguration();
            var baseUrl = configuration["ApiSettings:BaseUrl"];

            baseClient = new BaseClient(baseUrl);
            userService = new UserService(baseClient); 
        }
    }
}
