using EllAid.UseCases.Dashboard;

namespace EllAid.Details.UI.Dashboard.Services
{
    interface IFacultyNavigationConverter
    {
        string Convert(NavigationDestinations destination);
    }
}