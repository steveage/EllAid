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
using System;
using Microsoft.AspNetCore.Identity;
using AspNetCore.Identity.DocumentDb;
using EllAid.DataSource.Infrastructure.Web;

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
            Uri dbUri = new Uri(config["DataStore:Uri"]);
            services.AddDbContext<PeopleContext>(builder => CreateCosmosDbOptions(builder));
            services.AddDefaultDocumentClientForIdentity(dbUri, config["DataStore:Key"]);
            services.AddIdentity<DocumentDbIdentityUser, DocumentDbIdentityRole>(SetUpIdentity).AddDocumentDbStores(SetUpDocumentDb);
            services.AddTransient<IMappingProvider, MappingProvider>();
            services.AddTransient(typeof(IFacultyRepository<>), typeof(FacultyRepository<>));
            services.AddTransient<IIdentityRepository<DocumentDbIdentityUser>, IdentityRepository<DocumentDbIdentityUser>>();
            services.AddTransient(typeof(ISaveFacultyUseCase<,,>), typeof(SaveFacultyUseCase<,,>));
            services.AddTransient<IUserSignInManager, UserSignInManager>();
            services.AddTransient<SignInResultConverter>();
            services.AddAutoMapper(typeof(SchoolClassProfile));
            services.AddControllers();
            services.AddLogging();
        }

        void SetUpIdentity(IdentityOptions options)
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
        }

        void SetUpDocumentDb(DocumentDbOptions options)
        {
            options.Database = config["DataStore:Id"];
            options.UserStoreDocumentCollection = config["DataStore:Containers:Identities:Id"];
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
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}