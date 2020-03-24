using System;
using EllAid.Entities.Data;
using Xunit;

namespace EllAid.Entities.Tests.Data
{
    public class TermCourseTests
    {
        [Fact]
        public void New_SetsId()
        {
            //Given
            //When
            TermCourse termCourse = new TermCourse();
            //Then
            Assert.NotEqual(Guid.Empty, termCourse.Id);
        }

        [Fact]
        public void New_SetsTermAndGradeCourse()
        {
            //Given
            Term term = new Term();
            GradeCourse gradeCourse = new GradeCourse();
            //When
            TermCourse termCourse = new TermCourse(term, gradeCourse);
            //Then
            Assert.NotEqual(Guid.Empty, termCourse.Id);
            Assert.Equal(term, termCourse.Term);
            Assert.Equal(gradeCourse, termCourse.GradeCourse);
        }
    }
}