using System;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Creation.Item;
using Xunit;

namespace EllAid.TestDataGenerator.Tests.UseCases.Creation.Item
{
    public class ClassManagerTests
    {
        [Fact]
        public void Create_ReturnsSchoolClassWithData()
        {
            //Given
            ClassManager manager = new ClassManager();
            const string className = "Ms Brandon's Butterflies";
            //When
            SchoolClass schoolClass = manager.Create(className);
            //Then
            Assert.NotEqual(Guid.Empty, schoolClass.Id);
            Assert.Equal(className, schoolClass.Name);
        }

        [Fact]
        public void AddStudent_AddsStudentToClassAndClassToStudent()
        {
            //Given
            ClassManager manager = new ClassManager();
            SchoolClass schoolClass = new SchoolClass();
            Student student = new Student();
            //When
            manager.AddStudent(student, schoolClass);
            //Then
            Assert.Contains(student, schoolClass.Students);
            Assert.All(schoolClass.Students, classStudent => Assert.Equal(schoolClass, classStudent.Class));
        }
    }
}