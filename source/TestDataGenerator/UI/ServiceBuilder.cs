using System;
using System.IO;
using EllAid.TestDataGenerator.UseCases.Adapters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EllAid.TestDataGenerator.UseCases.Creation.Datasource;
using EllAid.TestDataGenerator.Infrastructure.TestData;
using EllAid.TestDataGenerator.UseCases;
using EllAid.TestDataGenerator.UseCases.Creation.Courses;
using EllAid.TestDataGenerator.UseCases.Creation.People;
using EllAid.TestDataGenerator.UseCases.Creation.SchoolClasses;
using EllAid.TestDataGenerator.UseCases.Creation.Tests;
using EllAid.TestDataGenerator.Infrastructure.Mapper;

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
                //EllAid.TestDataGenerator.Infrastructure
                .AddTransient<IMappingProvider, MappingProvider>()
                .AddTransient<IDataFabricator, BogusFabricator>()
                .AddSingleton<IDataSourceBuilder, CosmosDbBuilder>()
                .AddSingleton<IDatabaseAccess, CosmosDbBuilder>()
                .AddTransient<IUserDataAccess, InMemoryUserDataProvider>()
                .AddTransient<ITestDataRepository, TestDataRepository>()
                //EllAid.TestDataGenerator.UseCases
                .AddTransient<IDataCreationInputBoundary, DataCreationUseCase>()
                .AddTransient<ISchoolClassOutput, SchoolClassOutput>()
                .AddTransient<ICourseManager, CourseManager>()
                .AddTransient<IInstructorManager, InstructorManager>()
                .AddTransient<IPersonCreator, PersonCreator>()
                .AddTransient<IPersonProvider, PersonProvider>()
                .AddTransient<IClassAssigner, ClassAssigner>()
                .AddTransient<ISchoolClassBuilder, SchoolClassBuilder>()
                .AddTransient<ITestAssigner, TestAssigner>()
                .AddTransient<ITestBuilder, WidaTestBuilder>()
                .AddLogging(cfg => cfg.AddApplicationInsights(config["ApplicationInsightsKey"]))
                .AddLogging(cfg => cfg.AddConsole().AddConfiguration(config.GetSection("Logging")))
                .BuildServiceProvider();
    }
}