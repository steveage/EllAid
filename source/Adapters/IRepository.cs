using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Adapters.DataObjects;
using EllAid.Entities.Services;

namespace EllAid.Adapters
{
    public interface IRepository<T> : IDataStoreManager where T : PersonDto
    {
        Task SaveFacultyAsync(List<T> faculty);
    }
}