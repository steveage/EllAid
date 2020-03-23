using System;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Creation.Item;
using Xunit;

namespace EllAid.TestDataGenerator.Tests.UseCases.Creation.Item
{
    public class TestAssignerTests
    {
        [Fact]
        public void AssignCourse_ReturnsCourseAssignedToTest()
        {
            //Given
            TestAssigner assigner = new TestAssigner();
            Course course = new Course();
            Test test = new Test();
            //When
            CourseTest courseTest = new CourseTest(test, course);
            //Then
            Assert.NotEqual(Guid.Empty, courseTest.Id);
            Assert.Equal(course, courseTest.Course);
            Assert.Equal(test, courseTest.Test);
        }

        [Fact]
        public void AssignGrade_ReturnsGradeCourseAssignedToTest()
        {
            //Given
            TestAssigner assigner = new TestAssigner();
            GradeCourse gradeCourse = new GradeCourse();
            Test test = new Test();            
            //When
            GradeCourseTest gradeTest = new GradeCourseTest(test, gradeCourse);
            //Then
            Assert.NotEqual(Guid.Empty, gradeTest.Id);
            Assert.Equal(gradeCourse, gradeTest.GradeCourse);
            Assert.Equal(test, gradeTest.Test);
        }

        [Fact]
        public void AssignTerm_ReturnsTermCourseAssignedToTest()
        {
            //Given
            TestAssigner assigner = new TestAssigner();
            TermCourse termCourse = new TermCourse();
            Test test = new Test();
            //When
            TermCourseTest termTest = new TermCourseTest(test, termCourse);
            //Then
            Assert.NotEqual(Guid.Empty, termTest.Id);
            Assert.Equal(termCourse, termTest.TermCourse);
            Assert.Equal(test, termTest.Test);
        }

        [Fact]
        public void AssignSection_AddsSectionToTest()
        {
            //Given
            TestAssigner assigner = new TestAssigner();
            Test test = new Test();
            TestSection section = new TestSection();
            //When
            assigner.AssignSection(test, section);
            //Then
            Assert.Equal(section, test.Sections[0]);
            Assert.Equal(test, section.Test);
        }
    }
}