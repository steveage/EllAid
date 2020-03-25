using System;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Creation.Item;
using Xunit;

namespace EllAid.TestDataGenerator.Tests.UseCases.Creation.Item
{
    public class CourseManagerTests
    {
        [Fact]
        public void EnrollStudent_CreatesEnrollmentAndAddsStudent()
        {
            //Given
            Student student = new Student();
            CourseAssignment assignment = new CourseAssignment();
            Enrollment enrollment = new Enrollment(assignment);
            CourseManager manager = new CourseManager();
            //When
            manager.Enroll(student, enrollment);
            //Then
            Assert.Equal(1, student.Enrollments.Count);
            Assert.NotEqual(Guid.Empty, student.Enrollments[0].Id);
            Assert.Equal(student, student.Enrollments[0].Student);
            Assert.Equal(assignment, student.Enrollments[0].CourseAssignment);
        }

        [Fact]
        public void AddTestSession_AssignsTestSessionAndCourseAssignment()
        {
            //Given
            CourseAssignment assignment = new CourseAssignment();
            TestSession session = new TestSession();
            CourseManager manager = new CourseManager();
            //When
            manager.AddTestSession(session, assignment);
            //Then
            Assert.Equal(assignment, session.CourseAssignment);
            Assert.Contains(session, assignment.TestSessions);
        }        
    }
}