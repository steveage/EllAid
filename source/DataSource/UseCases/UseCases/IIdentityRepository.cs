using System.Collections.Generic;
using System.Threading.Tasks;

namespace EllAid.DataSource.UseCases
{
    public interface IIdentityRepository<T> where T : class
    {
        Task SaveAsync(List<T> identityUsers);
        Task SetupDatasource();
    }
}