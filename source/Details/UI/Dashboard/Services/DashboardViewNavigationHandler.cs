using System;
using EllAid.UseCases.Dashboard;
using Microsoft.AspNetCore.Http;

namespace EllAid.Details.UI.Dashboard.Services
{
    public class DashboardViewNavigationHandler : INavigationHandler
    {
        readonly IHttpContextAccessor contextAccessor;

        public DashboardViewNavigationHandler(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }
        public void Handle(NavigationDestinations destination)
        {
            contextAccessor.HttpContext.Response.Redirect(GetPath(destination));
        }

        string GetPath(NavigationDestinations destination) =>
            destination switch
            {
                NavigationDestinations.Login => "/Account/Login/",
                NavigationDestinations.Faculty => GetTargetPath(),
                _ => throw new ArgumentException("Invalid enum value.", nameof(destination))
            };
        
        string GetTargetPath()
        {
            bool returnPathIsProvided = contextAccessor.HttpContext.Request.Query.Keys.Contains("ReturnUrl");
            string targetPath;
            if (returnPathIsProvided)
            {
                targetPath = contextAccessor.HttpContext.Request.Query["ReturnUrl"];
            }
            else
            {
                targetPath = "/Home/Faculty";
            }
            return targetPath;
        }
    }
}