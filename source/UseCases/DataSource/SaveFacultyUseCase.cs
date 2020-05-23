using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Entities.Data;

namespace EllAid.UseCases.DataSource
{
    public class SaveFacultyUseCase<S, T, U> : ISaveFacultyUseCase<S, T, U> where S : Person where T : class where U : class
    {
        readonly IFacultyRepository<T> repository;
        readonly IIdentityRepository<U> identityRepository;
        readonly IMappingProvider mapper;

        public SaveFacultyUseCase(IFacultyRepository<T> repository, IIdentityRepository<U> identityRepository, IMappingProvider mapper)
        {
            this.repository = repository;
            this.identityRepository = identityRepository;
            this.mapper = mapper;
        }

        public async Task CreateDataStoreAsync()
        {
            await repository.CreateDataStoreAsync();
            await identityRepository.SetupDataSource();
        }

        public async Task DeleteDataStoreAsync()
        {
            await repository.DeleteDataStoreAsync();
        }

        public async Task SaveAsync(List<S> people)
        {
            List<T> dtos = new List<T>();
            List<U> identities = new List<U>();
            people.ForEach(person => 
            {
                dtos.Add(mapper.Map<T, S>(person));
                identities.Add(mapper.Map<U, S>(person));
            });
            await repository.SaveFacultyAsync(dtos);
            await identityRepository.SaveAsync(identities);
        }
    }
}