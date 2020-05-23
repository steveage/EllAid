using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Entities.Services;

namespace EllAid.UseCases.DataSource
{
    public interface IFacultyRepository<T> : IDataStoreManager where T : class
    {
        Task SaveFacultyAsync(List<T> faculty);
    }
}