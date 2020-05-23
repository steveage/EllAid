using System;
using Xunit;
using EllAid.Entities.Data;

namespace EllAid.Tests.Entities.Data
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
            Assert.NotNull(assignment.TestSessions);
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
            Assert.NotNull(assignment.TestSessions);
            Assert.Equal(termCourse, assignment.TermCourse);
            Assert.Equal(instructor, assignment.Instructor);
        }
    }
}