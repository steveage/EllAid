using System;
using Xunit;
using EllAid.Entities.Data;

namespace EllAid.Entities.Tests.Data
{
    public class CourseAssignmentTests
    {
        [Fact]
        public void New_SetsId()
        {
            //Given, When
            CourseAssignment assignment = new CourseAssignment();        
            //Then
            Assert.NotEqual(Guid.Empty, assignment.Id);
        }

        [Fact]
        public void New_SetsTermCourseAndInstructor()
        {
            //Given, When
            TermCourse termCourse = new TermCourse();
            Instructor instructor = new Instructor();
            CourseAssignment assignment = new CourseAssignment(termCourse, instructor);
            //Then
            Assert.NotEqual(Guid.Empty, assignment.Id);
            Assert.Equal(termCourse, assignment.TermCourse);
            Assert.Equal(instructor, assignment.Instructor);
        }
    }
}