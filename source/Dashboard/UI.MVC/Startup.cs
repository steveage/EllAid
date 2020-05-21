using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Identity.DocumentDb;
using AspNetCore.Identity.DocumentDb.Stores;
using EllAid.Adapters.DataObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
            Uri dbUri = new Uri(config["DataStore:Uri"]);
            services.AddDefaultDocumentClientForIdentity(dbUri, config["DataStore:Key"], GetJsonSettings());
            //TODO: Move identity sign in logic out to that datastore service.
            // services.AddIdentity<DocumentDbIdentityUser, DocumentDbIdentityRole>(SetUpIdentity).AddDocumentDbStores(SetUpDocumentDb);
            // AddIdentityCore is necessary because there can be only one type added to AddIdentity method.
            // AddRoles and AddRoleStore are necessary because DocumentDb provider for Identity requires roles.
            // services.AddIdentityCore<EllCoachDto>(SetUpIdentity)
            //     .AddRoles<DocumentDbIdentityRole>()
            //     .AddRoleStore<DocumentDbRoleStore<DocumentDbIdentityRole>>()
            //     .AddDocumentDbStores(SetUpDocumentDb);
            // services.AddIdentityCore<InstructorDto>(SetUpIdentity)
            //     .AddRoles<DocumentDbIdentityRole>()
            //     .AddRoleStore<DocumentDbRoleStore<DocumentDbIdentityRole>>()
            //     .AddDocumentDbStores(SetUpDocumentDb);
            // // Manual registration of services like RoleStore, SignInManager, UserManager, etc. is necessary because AddIdentityCore, as opposed to AddIdentity, does not register them by default.
            // services.AddScoped<DocumentDbRoleStore<DocumentDbIdentityRole>>();
            // services.AddScoped(typeof(SignInManager<>));
            services.AddControllersWithViews();
            services.AddRazorPages();
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
            options.UserStoreDocumentCollection = config["DataStore:Containers:People:Id"];
        }

        JsonSerializerSettings GetJsonSettings() => new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() };


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
