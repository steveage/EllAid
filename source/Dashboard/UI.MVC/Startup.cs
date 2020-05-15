using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EllAid.Adapters.DataObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mobsites.AspNetCore.Identity.Cosmos;

namespace EllAid.Dashboard.UI.MVC
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
                        // Camel case is a standard for json. It cannot be used however because as for now cosmos db provider for ef does not support camel case.
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
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
