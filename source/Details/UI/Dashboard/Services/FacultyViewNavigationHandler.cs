using EllAid.UseCases.Dashboard;
using Microsoft.AspNetCore.Http;

namespace EllAid.Details.UI.Dashboard.Services
{
    class FacultyViewNavigationHandler : INavigationHandler
    {
        readonly IFacultyNavigationConverter converter;
        readonly IHttpContextAccessor contextAccessor;

        public FacultyViewNavigationHandler(IFacultyNavigationConverter converter, IHttpContextAccessor contextAccessor)
        {
            this.converter = converter;
            this.contextAccessor = contextAccessor;
        }
        
        public void Handle(NavigationDestinations destination)
        {
            contextAccessor.HttpContext.Response.Redirect(converter.Convert(destination));
        }
    }
}