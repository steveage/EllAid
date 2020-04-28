using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.DataSource.Adapters;
using EllAid.DataSource.Adapters.DataObjects;
using EllAid.Entities.Data;

namespace EllAid.DataSource.UseCases
{
    class SaveFacultyUseCase<S, T> : ISaveFacultyUseCase<S, T> where S : Person where T : PersonDto
    {
        readonly IRepository<T> repository;
        private readonly IMappingProvider mapper;

        public SaveFacultyUseCase(IRepository<T> repository, IMappingProvider mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task CreateDataStoreAsync()
        {
            await repository.CreateDataStoreAsync();
        }

        public async Task DeleteDataStoreAsync()
        {
            await repository.DeleteDataStoreAsync();
        }

        public async Task SaveAsync(List<S> people)
        {
            List<T> dtos = new List<T>();
            people.ForEach(person => dtos.Add(mapper.Map<T, S>(person)));
            await repository.SaveFacultyAsync(dtos);
        }
    }
}