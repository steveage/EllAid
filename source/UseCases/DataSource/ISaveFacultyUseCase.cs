using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Entities.Data;
using EllAid.Entities.Services;

namespace EllAid.UseCases.DataSource
{
    public interface ISaveFacultyUseCase<S, T, U> : IDataStoreManager where S : Person where T : class where U : class
    {
        Task SaveAsync(List<S> people);
    }
}