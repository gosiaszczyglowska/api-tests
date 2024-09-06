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


        [SetUp]
        public void Setup()
        {
            ConfigureLogging();
            LoadConfiguration();
            InitializeServices();
        }

        private void ConfigureLogging()
        {
            XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Core", "Log.config")));
            Console.WriteLine($"Logs will be stored in: {Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")}");
        }

        private void LoadConfiguration() 
        {
            configuration = ConfigurationHelper.GetConfiguration();           
        }

        private void InitializeServices() 
        {
            var baseUrl = configuration["ApiSettings:BaseUrl"];
            baseClient = new BaseClient(baseUrl);
            userService = new UserService(baseClient);
        }     
    }
}
