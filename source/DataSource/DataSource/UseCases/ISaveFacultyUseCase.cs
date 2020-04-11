using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.DataSource.Adapters.DataObjects;
using EllAid.Entities.Data;

namespace EllAid.DataSource.UseCases
{
    interface ISaveFacultyUseCase<S, T> where S : Person where T : PersonDto
    {
        Task SaveAsync(List<S> people);
    }
}