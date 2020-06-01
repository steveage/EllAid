using System;
using EllAid.Details.Main;
using EllAid.UseCases.Dashboard;
using Microsoft.AspNetCore.Http;

namespace EllAid.Details.UI.Dashboard.Services
{
    class FacultyNavigationConverter : IFacultyNavigationConverter
    {
        readonly IHttpContextAccessor accessor;

        public FacultyNavigationConverter(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        public string Convert(NavigationDestinations destination) =>
            destination switch
            {
                NavigationDestinations.Login => Constants.loginViewPath,
                NavigationDestinations.Faculty => GetTargetPath(),
                _ => throw new ArgumentException("Invalid enum value.", nameof(destination))
            };
        
        string GetTargetPath()
        {
            bool returnPathIsProvided = accessor.HttpContext.Request.Query.Keys.Contains(Constants.returnUrlKey);
            string targetPath;
            if (returnPathIsProvided)
            {
                targetPath = accessor.HttpContext.Request.Query[Constants.returnUrlKey];
            }
            else
            {
                targetPath = Constants.facultyViewPath;
            }
            return targetPath;
        }
    }
}