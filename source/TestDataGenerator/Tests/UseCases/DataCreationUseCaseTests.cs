using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure;
using EllAid.TestDataGenerator.UseCases.Adapters;
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
        public async Task CreateClasses_DeletesDataStoreAsync()
        {
            //Given
            SaverStub saverStub = new SaverStub();
            DataCreationUseCase useCase = GetUseCase(saverStub);
            //When
            await useCase.CreateClassesAsync();
            //Then
            Assert.True(saverStub.DataSourceWasDeleted);
        }

        [Fact]
        public async Task CreateClasses_CreatesDataStoreAsync()
        {
            //Given
            SaverStub saverStub = new SaverStub();
            DataCreationUseCase useCase = GetUseCase(saverStub);
            //When
            await useCase.CreateClassesAsync();
            //Then
            Assert.True(saverStub.DataSourceWasCreated);
        }

        [Fact]
        public async Task CreateClasses_SendsInstructorsForSavingAsync()
        {
            //Given
            SaverStub saverStub = new SaverStub();
            DataCreationUseCase useCase = GetUseCase(saverStub);
            //When
            await useCase.CreateClassesAsync();
            //Then
            Assert.Equal(4, saverStub.Instructors.Count);
        }
        DataCreationUseCase GetUseCase(SaverStub saverStub) => new DataCreationUseCase(new SchoolClassBuilder(new ClassAssigner(new InstructorManager(), new CourseManager()), new PersonCreator(new BogusFabricator(), new InMemoryUserDataProvider()), new WidaTestBuilder(new TestAssigner(), new BogusFabricator()), new CourseManager(), new TestAssigner()), new FacultyExtractor(), saverStub);

        private class SaverStub : IDataSaver
        {
            public List<Instructor> Instructors { get; private set; }
            public List<EllCoach> EllCoaches { get; private set; }
            public List<Assistant> Assistants { get; private set; }
            public bool DataSourceWasDeleted { get; private set; }
            public bool DataSourceWasCreated { get; set; }

            public async Task CreateDataStoreAsync()
            {
                DataSourceWasCreated = true;
                await Task.CompletedTask;
            }

            public async Task DeleteDataStoreAsync()
            {
                DataSourceWasDeleted = true;
                await Task.CompletedTask;
            }

            public async Task SaveAssistantsAsync(List<Assistant> assistants)
            {
                Assistants = assistants;
                await Task.CompletedTask;
            }

            public async Task SaveEllCoachesAsync(List<EllCoach> coaches)
            {
                EllCoaches = coaches;
                await Task.CompletedTask;
            }

            public async Task SaveInstructorsAsync(List<Instructor> instructors)
            {
                Instructors = instructors;
                await Task.CompletedTask;
            }
        }

        [Fact]
        public async Task CreateClasses_PersistsCreatedEllCoachesAsync()
        {
            //Given
            SaverStub saverStub = new SaverStub();
            DataCreationUseCase useCase = GetUseCase(saverStub);
            //When
            await useCase.CreateClassesAsync();
            //Then
            Assert.Equal(1, saverStub.EllCoaches.Count);
        }

        [Fact]
        public async Task CreateClasses_PersistsCreatedAssistantsAsync()
        {
            //Given
            SaverStub saverStub = new SaverStub();
            DataCreationUseCase useCase = GetUseCase(saverStub);
            //When
            await useCase.CreateClassesAsync();
            //Then
            Assert.Equal(8, saverStub.Assistants.Count);
        }
    }
}