using EllAid.UseCases.Dashboard;
using EllAid.Details.UI.Dashboard.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EllAid.Entities.Services;
using EllAid.UseCases.Dashboard.Identity;
using EllAid.Details.Main.Validation;
using FluentValidation.AspNetCore;

namespace EllAid.Details.UI.Dashboard
{
    public class Startup
    {
        readonly IConfiguration config;
        public Startup(IConfiguration config) => this.config = config;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddFluentValidation(opt =>
                {
                    opt.RegisterValidatorsFromAssemblyContaining<UserLoginValidator>();
                });
            services.AddRazorPages();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddHttpContextAccessor();
            services.AddHttpClient<IHttpClientProvider, HttpClientProvider>();
            services.AddScoped<SignInUseCase>();
            services.AddScoped<IValidator<UserLoginModel>, UserLoginValidator>();
            services.AddScoped<IIdentityProvider, IdentityProvider>();
            services.AddScoped<ISignInExecutor, CookieSignInExecutor>();
            services.AddTransient<INavigationHandler, DashboardViewNavigationHandler>();
            services.AddTransient<INavigator, SignInNavigator>();
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
