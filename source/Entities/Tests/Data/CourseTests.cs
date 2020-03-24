using System;
using EllAid.Entities.Data;
using Xunit;

namespace EllAid.Entities.Tests.Data
{
    public class CourseTests
    {
        [Fact]
        public void New_SetsId()
        {
            // Given, When
            Course course = new Course();
            // Then
            Assert.NotEqual(Guid.Empty, course.Id);
        }

        [Fact]
        public void New_SetsNameAndDepartment()
        {
            //Given
            string name = "General Education";
            Department department = Department.EarlyChildhood;
            //When
            Course course = new Course(name, department);
            //Then
            Assert.NotEqual(Guid.Empty, course.Id);
            Assert.Equal(name, course.Name);
            Assert.Equal(department, course.Department);
        }
    }
}