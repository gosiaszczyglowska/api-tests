using Microsoft.Extensions.Configuration;
using System;


namespace PageObject.Core.Utilities
{
    public class Configuration
    {
        private static Configuration instance;
        private static readonly object instanceLock = new object();
        private readonly AppSettings appSettings;

        private Configuration()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("Core/appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            appSettings = config.GetSection("AppSettings").Get<AppSettings>();
        }

        public static Configuration Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (instanceLock)
                    {
                        instance = new Configuration();
                    }
                }
                return instance;
            }
        }

        public AppSettings GetAppSettings()
        {
            return appSettings;
        }

    }
}
