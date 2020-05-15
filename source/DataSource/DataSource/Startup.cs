using EllAid.Adapters;
using EllAid.DataSource.UseCases;
using EllAid.DataSource.DataAccess.Context;
using EllAid.DataSource.Infrastructure.DataAccess;
using EllAid.TestDataGenerator.Infrastructure.Map;
using EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Mobsites.AspNetCore.Identity.Cosmos;
using Microsoft.Azure.Cosmos;
using System;
using EllAid.Adapters.DataObjects;

namespace EllAid.DataSource
{
    public class Startup
    {
        readonly IConfiguration config;

        public Startup(IConfiguration config) => this.config = config;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCosmosStorageProvider(options =>
            {
                options.ConnectionString = config["DataStore:ConnectionString"];
                options.CosmosClientOptions = new CosmosClientOptions
                {
                    SerializerOptions = new CosmosSerializationOptions
                    {
                        IgnoreNullValues = false,
                        // PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                        // as for now cosmos provider for ef does not support camel case.
                    }
                };
                options.DatabaseId = config["DataStore:Id"];
                options.ContainerProperties = new ContainerProperties
                {
                    Id = config["DataStore:Containers:People:Id"],
                    PartitionKeyPath = $"/{config["DataStore:Containers:People:PartitionKey"]}"
                };
            });
            services.AddDefaultCosmosIdentity<PersonDto>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.MaxFailedAccessAttempts = 5;
            });
            services.AddDbContext<PeopleContext>(builder => CreateCosmosDbOptions(builder));
            services.AddTransient<IMappingProvider, MappingProvider>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(ISaveFacultyUseCase<,>), typeof(SaveFacultyUseCase<,>));
            services.AddAutoMapper(typeof(SchoolClassProfile));
            services.AddControllers();
            services.AddLogging();
        }

        void CreateCosmosDbOptions(DbContextOptionsBuilder builder)
        {
            string dbEndpointName = config["DataStore:Uri"];
            string dbAccountKey = config["DataStore:Key"];
            string dbName = config["DataStore:Id"];
            
            builder.UseCosmos(dbEndpointName, dbAccountKey, dbName);
            builder.EnableSensitiveDataLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}