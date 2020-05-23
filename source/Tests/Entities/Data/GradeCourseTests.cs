using System;
using EllAid.Entities.Data;
using Xunit;

namespace EllAid.Tests.Entities.Data
{
    public class GradeCourseTests
    {
        [Fact]
        public void New_SetsId()
        {
            //Given, When
            GradeCourse gradeCourse = new GradeCourse();
            //Then
            Assert.NotEqual(Guid.Empty, gradeCourse.Id);
        }

        [Fact]
        public void New_SetsCourseAndGrade()
        {
            //Given
            Course course = new Course();
            SchoolGrade grade = SchoolGrade.PreKindergarten;
            //When
            GradeCourse gradeCourse = new GradeCourse(course, grade);
            //Then
            Assert.NotEqual(Guid.Empty, gradeCourse.Id);
            Assert.Equal(course, gradeCourse.Course);
            Assert.Equal(grade, gradeCourse.Grade);
        }
    }
}