using System;
using EllAid.Entities.Data;
using Xunit;

namespace EllAid.Tests.Entities.Data
{
    public class TermCourseTestTests
    {
        
        [Fact]
        public void New_SetsIdAndTermCourseAndTest()
        {
            //Given
            TermCourse termCourse = new TermCourse();
            Test test = new Test();
            //When
            TermCourseTest termTest = new TermCourseTest(test, termCourse);
            //Then
            Assert.NotEqual(Guid.Empty, termTest.Id);
            Assert.Equal(termCourse, termTest.TermCourse);
            Assert.Equal(test, termTest.Test);
        }
    }
}