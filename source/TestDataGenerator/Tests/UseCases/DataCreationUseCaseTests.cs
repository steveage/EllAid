using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.TestData;
using EllAid.TestDataGenerator.Tests.Infrastructure;
using EllAid.TestDataGenerator.UseCases.Adapters;
using EllAid.TestDataGenerator.UseCases.Adapters.DataObjects;
using EllAid.TestDataGenerator.UseCases.Creation.Courses;
using EllAid.TestDataGenerator.UseCases.Creation.People;
using EllAid.TestDataGenerator.UseCases.Creation.SchoolClasses;
using EllAid.TestDataGenerator.UseCases.Creation.Tests;
using Xunit;

namespace EllAid.TestDataGenerator.UseCases
{
    public class DataCreationUseCaseTests
    {
        [Fact]
        public async Task CreateClasses_PersistsCreatedInstructorsAsync()
        {
            //Given
            RepositoryStub repositoryStub = new RepositoryStub();
            DataCreationUseCase useCase = GetUseCase(repositoryStub);
            //When
            await useCase.CreateClassesAsync();
            //Then
            Assert.Equal(4, repositoryStub.Instructors.Count);
        }
        DataCreationUseCase GetUseCase(ITestDataRepository repository) => new DataCreationUseCase(
        new SchoolClassBuilder(new ClassAssigner(new InstructorManager(), new CourseManager()), new PersonCreator(new BogusFabricator(), new InMemoryUserDataProvider()), new WidaTestBuilder(new TestAssigner(), new BogusFabricator()), new CourseManager(), new TestAssigner()), new FacultyExtractor(), MappingProviderTests.GetProvider(), repository);

        private class RepositoryStub : ITestDataRepository
        {
            public List<InstructorDto> Instructors { get; private set; }
            public List<EllCoachDto> EllCoaches { get; private set; }
            public List<AssistantDto> Assistants { get; private set; }

            public async Task SaveAssistantsAsync(List<AssistantDto> assistants)
            {
                Assistants = assistants;
                await Task.CompletedTask;
            }

            public async Task SaveEllCoachesAsync(List<EllCoachDto> coaches)
            {
                EllCoaches = coaches;
                await Task.CompletedTask;
            }

            public async Task SaveInstructorsAsync(List<InstructorDto> instructors)
            {
                Instructors = instructors;
                await Task.CompletedTask;
            }
        }

        [Fact]
        public async Task CreateClasses_PersistsCreatedEllCoachesAsync()
        {
            //Given
            RepositoryStub repositoryStub = new RepositoryStub();
            DataCreationUseCase useCase = GetUseCase(repositoryStub);
            //When
            await useCase.CreateClassesAsync();
            //Then
            Assert.Equal(1, repositoryStub.EllCoaches.Count);
        }

        [Fact]
        public async Task CreateClasses_PersistsCreatedAssistantsAsync()
        {
            //Given
            RepositoryStub repository = new RepositoryStub();
            DataCreationUseCase useCase = GetUseCase(repository);
            //When
            await useCase.CreateClassesAsync();
            //Then
            Assert.Equal(8, repository.Assistants.Count);
        }
    }
}