using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.DataSource.Adapters.DataObjects;
using EllAid.Entities.Data;
using EllAid.Entities.Services;

namespace EllAid.DataSource.UseCases
{
    public interface ISaveFacultyUseCase<S, T> : IDataStoreManager where S : Person where T : PersonDto
    {
        Task SaveAsync(List<S> people);
    }
}