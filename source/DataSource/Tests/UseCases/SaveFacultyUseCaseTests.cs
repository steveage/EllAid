using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Adapters;
using EllAid.Adapters.DataObjects;
using EllAid.DataSource.Tests.Infrastructure.Map;
using EllAid.DataSource.UseCases;
using EllAid.Entities.Data;
using Xunit;

namespace EllAid.DataSource.Tests.UseCases
{
    public class SaveFacultyUseCaseTests
    {
        [Fact]
        public async Task Save_SendsDtosToRepository()
        {
            // Given
            RepositoryStub<InstructorDto> repository = new RepositoryStub<InstructorDto>();
            SaveFacultyUseCase<Instructor, InstructorDto> useCase = GetUseCase<Instructor, InstructorDto>(repository);
            List<Instructor> instructors = GetFaculty<Instructor>();
            // When
            await useCase.SaveAsync(instructors);
            // Then
            Assert.Equal(instructors.Count, repository.Faculty.Count);
        }

        SaveFacultyUseCase<S, T> GetUseCase<S, T>(RepositoryStub<T> repository) where S : Person where T : PersonDto => new SaveFacultyUseCase<S, T>(repository, MappingProviderTests.GetProvider());

        List<S> GetFaculty<S>() where S : Person, new() => new List<S>() { new S(), new S(), new S() };

        private class RepositoryStub<T> : IRepository<T> where T : PersonDto
        {
            public List<T> Faculty { get; private set; }

            public async Task CreateDataStoreAsync()
            {
                await Task.CompletedTask;
            }

            public async Task DeleteDataStoreAsync()
            {
                await Task.CompletedTask;
            }

            public async Task SaveFacultyAsync(List<T> faculty)
            {
                Faculty = faculty;
                await Task.CompletedTask;
            }
        }

        [Fact]
        public async Task Save_SendsAssistantsToRepository()
        {
            // Given
            RepositoryStub<AssistantDto> repository = new RepositoryStub<AssistantDto>();
            SaveFacultyUseCase<Assistant, AssistantDto> useCase = GetUseCase<Assistant, AssistantDto>(repository);
            List<Assistant> assistants = GetFaculty<Assistant>();
            // When
            await useCase.SaveAsync(assistants);
            // Then
            Assert.Equal(assistants.Count, repository.Faculty.Count);
        }

        [Fact]
        public async Task Save_SendsCoachesToRepository()
        {
            // Given
            RepositoryStub<EllCoachDto> repository = new RepositoryStub<EllCoachDto>();
            SaveFacultyUseCase<EllCoach, EllCoachDto> useCase = GetUseCase<EllCoach, EllCoachDto>(repository);
            List<EllCoach> coaches = GetFaculty<EllCoach>();
            // When
            await useCase.SaveAsync(coaches);
            // Then
            Assert.Equal(coaches.Count, repository.Faculty.Count);
        }
    }
}