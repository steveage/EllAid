using System;
using EllAid.Entities.Data;
using Xunit;

namespace EllAid.Tests.Entities.Data
{
    public class EnrollmentTests
    {
        [Fact]
        public void New_setsId()
        {
            //Given, When
            Enrollment enrollment = new Enrollment();
            //Then
            Assert.NotEqual(Guid.Empty, enrollment.Id);
        }

        [Fact]
        public void New_SetsCourseAssignment()
        {
            //Given
            CourseAssignment assignment = new CourseAssignment();
            //When
            Enrollment enrollment = new Enrollment(assignment);
            //Then
            Assert.NotEqual(Guid.Empty, enrollment.Id);
            Assert.Equal(assignment, enrollment.CourseAssignment);
        }
    }
}