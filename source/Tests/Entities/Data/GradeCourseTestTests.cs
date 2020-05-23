using System;
using EllAid.Entities.Data;
using Xunit;

namespace EllAid.Tests.Entities.Data
{
    public class GradeCourseTestTests
    {
        [Fact]
        public void New_SetsId()
        {
            //Given, When
            GradeCourseTest gradeTest = new GradeCourseTest();
            //Then
            Assert.NotEqual(Guid.Empty, gradeTest.Id);
        }

        [Fact]
        public void New_SetsTestAndGradeCourse()
        {
            //Given
            Test test = new Test();
            GradeCourse gradeCourse = new GradeCourse();
            //When
            GradeCourseTest gradeTest = new GradeCourseTest(test, gradeCourse);
            //Then
            Assert.NotEqual(Guid.Empty, gradeTest.Id);
            Assert.Equal(test, gradeTest.Test);
            Assert.Equal(gradeCourse, gradeTest.GradeCourse);
        }
    }
}