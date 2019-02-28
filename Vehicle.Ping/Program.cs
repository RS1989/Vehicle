using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Vehicle.Ping.Ping;
using Vehicle.Ping.Simulation;

namespace Vehicle.Ping
{
    class Program
    {
        public static IConfigurationRoot configuration;

        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            Int32 ticker = 0;
            if (!Int32.TryParse(configuration.GetSection(Constants.Constants.ConfigSection.UpdateTicker).Value, out ticker))
            {
                ticker = 3;
            }
            var serviceUrl = configuration.GetSection(Constants.Constants.ConfigSection.ServiceUrl).Value;
            var endpoint = configuration.GetSection(Constants.Constants.ConfigSection.UpdateStatus).Value;

            var ping = new Ping.Ping(ticker, serviceUrl, endpoint);
            ping.PingExecute();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Build configuration
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile(Constants.Constants.ConfigSection.Appsetting, false)
                .Build();


            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);

            // Add services
            serviceCollection.AddTransient<IResponse, Response>();
            serviceCollection.AddTransient<IPingReposnse, PingReposnse>();
            serviceCollection.AddTransient<IPing, Ping.Ping>();

        }
    }
}
