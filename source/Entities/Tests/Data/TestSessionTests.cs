using System;
using EllAid.Entities.Data;
using Xunit;

namespace EllAid.Entities.Tests.Data
{
    public class TestSessionTests
    {
        [Fact]
        public void New_SetsId()
        {
            //Given
            //When
            TestSession session = new TestSession();
            //Then
            Assert.NotEqual(Guid.Empty, session.Id);
        }

        [Fact]
        public void New_SetsAllValues()
        {
            //Given
            Test test = new Test();
            CourseAssignment assignment = new CourseAssignment();
            string name = "WIDA Spring Test Session";
            DateTime date = DateTime.Now;
            //When
            TestSession session = new TestSession(name, date, test, assignment);
            //Then
            Assert.NotEqual(Guid.Empty, session.Id);
            Assert.Equal(name, session.Name);
            Assert.Equal(date, session.Date);
            Assert.Equal(test, session.Test);
            Assert.Equal(assignment, session.CourseAssignment);
        }
    }
}