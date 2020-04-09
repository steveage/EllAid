using EllAid.DataSource.DataAccess.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EllAid.DataSource
{
    public class Startup
    {
        internal const string dbUriConfigKey = "dbUri";
        internal const string dbKeyConfigKey = "dbKey";
        internal const string dbIdConfigKey = "dbId";
        readonly IConfiguration config;

        public Startup(IConfiguration config) => this.config = config;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PeopleContext>(builder => CreateCosmosDbOptions(builder));
        }

        void CreateCosmosDbOptions(DbContextOptionsBuilder builder)
        {
            string dbEndpointName = config[dbUriConfigKey];
            string dbAccountKey = config[dbKeyConfigKey];
            string dbName = config[dbIdConfigKey];
            
            builder.UseCosmos(dbEndpointName, dbAccountKey, dbName);
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
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
