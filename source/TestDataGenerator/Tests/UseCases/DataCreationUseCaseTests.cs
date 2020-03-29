using System.Collections.Generic;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.TestData;
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
        public void CreateClasses_ReturnsPopulatedClasses()
        {
            //Given
            DataCreationUseCase useCase = GetUseCase();
            //When
            List<SchoolClass> schoolClasses = useCase.GetClasses();
            //Then
            Assert.Equal(4, schoolClasses.Count);
        }

        DataCreationUseCase GetUseCase() => new DataCreationUseCase(
        new SchoolClassBuilder(new ClassAssigner(new InstructorManager(), new CourseManager()), new PersonCreator(new BogusFabricator(), new InMemoryUserDataProvider()), new WidaTestBuilder(new TestAssigner(), new BogusFabricator()), new CourseManager(), new TestAssigner()));
    }
}