using System;
using EllAid.Entities.Data;
using Xunit;

namespace EllAid.Tests.Entities.Data
{
    public class CourseTestTests
    {
        [Fact]
        public void New_SetsIdAndCourseAndTest()
        {
            //Given
            Course course = new Course();
            Test test = new Test();
            //When
            CourseTest courseTest = new CourseTest(test, course);
            //Then
            Assert.NotEqual(Guid.Empty, courseTest.Id);
            Assert.Equal(course, courseTest.Course);
            Assert.Equal(test, courseTest.Test);
        }
    }
}