using System;
using System.IO;
using EllAid.TestDataGenerator.UseCases.Creation.Item;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EllAid.TestDataGenerator.UseCases.Creation.Datasource;
using EllAid.TestDataGenerator.Infrastructure.TestData;
using EllAid.TestDataGenerator.UseCases;

namespace EllAid.TestDataGenerator.UI
{
    class ServiceBuilder
    {
        readonly IConfiguration config;
        IServiceProvider serviceProvider;

        public ServiceBuilder()
        {
            string baseDirPath = Path.Combine(AppContext.BaseDirectory);
            config = new ConfigurationBuilder()
                .SetBasePath(baseDirPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        internal T GetService<T>()
        {
            serviceProvider??=CreateServiceProvider();
            return serviceProvider.GetService<T>();
        }

        IServiceProvider CreateServiceProvider() =>
            new ServiceCollection()
                .AddSingleton<IConfiguration>(config)
                .AddSingleton<IDataSourceBuilder, CosmosDbBuilder>()
                .AddSingleton<IDatabaseAccess, CosmosDbBuilder>()
                .AddTransient<ITestDataRepository, TestDataRepository>()
                .AddTransient<IDataCreationInputBoundary, DataCreationUseCase>()
                .AddTransient<IUserDataAccess, InMemoryUserDataProvider>()
                .AddTransient<IDataFabricator, BogusFabricator>()
                .AddLogging(cfg => cfg.AddApplicationInsights(config["ApplicationInsightsKey"]))
                .AddLogging(cfg => cfg.AddConsole().AddConfiguration(config.GetSection("Logging")))
                .BuildServiceProvider();
    }
}