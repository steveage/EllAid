using System;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.TestData;
using EllAid.TestDataGenerator.UseCases.Creation.Item;
using Xunit;

namespace EllAid.TestDataGenerator.Tests.UseCases.Creation.Item
{
    public class SchoolClassBuilderTests
    {
        [Fact]
        public void BuildGenEdClass_ReturnsClassWithInstructor()
        {
            //Given
            SchoolClassBuilder builder = new SchoolClassBuilder(new PersonCreator(new BogusFabricator(), new InMemoryUserDataProvider()));

            //When
            SchoolClass schoolClass = builder.BuildGenEdClass();
            
            //Then
            // Test Instructor
            Assert.NotEqual(Guid.Empty, schoolClass.Instructor.Id);
            Assert.NotEmpty(schoolClass.Instructor.FirstName);
            Assert.NotEmpty(schoolClass.Instructor.LastName);
            Assert.True(PersonCreatorTests.IsEmailAddress(schoolClass.Instructor.Email));
            Assert.NotEqual(Gender.Invalid, schoolClass.Instructor.Gender);
            // Test Assistants
            Assert.NotEmpty(schoolClass.Instructor.Assistants);
            Assert.All(schoolClass.Instructor.Assistants, assistant => Assert.NotEqual(Guid.Empty, assistant.Id));
            Assert.All(schoolClass.Instructor.Assistants, assistant => Assert.NotEmpty(assistant.FirstName));
            Assert.All(schoolClass.Instructor.Assistants, assistant => Assert.NotEmpty(assistant.LastName));
            Assert.All(schoolClass.Instructor.Assistants, assistant => Assert.NotEmpty(assistant.Email));
            Assert.All(schoolClass.Instructor.Assistants, assistant => Assert.NotEqual(Gender.Invalid, assistant.Gender));
            // Test EllCoach
            Assert.NotEqual(Guid.Empty, schoolClass.Instructor.EllCoach.Id);
            Assert.NotEmpty(schoolClass.Instructor.EllCoach.FirstName);
            Assert.NotEmpty(schoolClass.Instructor.EllCoach.LastName);
            Assert.True(PersonCreatorTests.IsEmailAddress(schoolClass.Instructor.EllCoach.Email));
            Assert.NotEqual(Gender.Invalid, schoolClass.Instructor.EllCoach.Gender);
        }
    }
}