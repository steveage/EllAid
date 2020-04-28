using System;
using System.IO;
using EllAid.TestDataGenerator.UseCases.Adapters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EllAid.TestDataGenerator.Infrastructure;
using EllAid.TestDataGenerator.UseCases;
using EllAid.TestDataGenerator.UseCases.Creation.Courses;
using EllAid.TestDataGenerator.UseCases.Creation.People;
using EllAid.TestDataGenerator.UseCases.Creation.SchoolClasses;
using EllAid.TestDataGenerator.UseCases.Creation.Tests;

namespace EllAid.TestDataGenerator.UI
{
    class ServiceBuilder
    {
        internal const string applicationInsightsConfigKey = "applicationInsightsKey";
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

        IServiceProvider CreateServiceProvider()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(config);
            //EllAid.TestDataGenerator.Infrastructure
            services.AddTransient<IDataFabricator, BogusFabricator>();
            services.AddTransient<IUserDataAccess, InMemoryUserDataProvider>();
            services.AddHttpClient<IDataSaver, HttpDataSaver>();
            //EllAid.TestDataGenerator.UseCases
            services.AddTransient<IDataCreationInputBoundary, DataCreationUseCase>();
            services.AddTransient<ICourseManager, CourseManager>();
            services.AddTransient<IInstructorManager, InstructorManager>();
            services.AddTransient<IPersonCreator, PersonCreator>();
            services.AddTransient<IPersonProvider, PersonProvider>();
            services.AddTransient<IClassAssigner, ClassAssigner>();
            services.AddTransient<ISchoolClassBuilder, SchoolClassBuilder>();
            services.AddTransient<ITestAssigner, TestAssigner>();
            services.AddTransient<ITestBuilder, WidaTestBuilder>();
            services.AddTransient<IFacultyExtractor, FacultyExtractor>();
            // .AddAutoMapper(typeof(SchoolClassProfile))
            services.AddLogging(cfg => cfg.AddApplicationInsights(config[applicationInsightsConfigKey]));
            services.AddLogging(cfg => cfg.AddConsole().AddConfiguration(config.GetSection("Logging")));
            return services.BuildServiceProvider();
        }
    }
}