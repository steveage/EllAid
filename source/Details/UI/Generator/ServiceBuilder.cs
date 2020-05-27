using System;
using System.IO;
using EllAid.UseCases.Generator.Creation.People;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EllAid.Details.Main.DataAccess;
using EllAid.UseCases.Generator;
using EllAid.UseCases.Generator.Creation.Courses;
using EllAid.UseCases.Generator.Creation.SchoolClasses;
using EllAid.UseCases.Generator.Creation.Tests;
using EllAid.Details.Main.DataFabricator;
using EllAid.Details.Main.DataSaver;
using EllAid.Entities.Services;

namespace EllAid.Details.UI.Generator
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
            //EllAid.Entities.Services
            services.AddHttpClient<IHttpClientProvider, HttpClientProvider>();
            //EllAid.Details.Main.DataAccess
            services.AddTransient<IDataFabricator, BogusFabricator>();
            services.AddTransient<IUserDataAccess, InMemoryUserDataProvider>();
            services.AddTransient<IDataSaver, HttpDataSaver>();
            //EllAid.UseCases.Generator
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