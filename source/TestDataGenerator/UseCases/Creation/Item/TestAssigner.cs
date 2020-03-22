using System;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class TestAssigner : ITestAssigner
    {
        public CourseTest AssignCourse(Test test, Course course) => new CourseTest()
        {
            Id = Guid.NewGuid(),
            Course = course,
            Test = test
        };

        public GradeCourseTest AssignGrade(Test test, GradeCourse gradeCourse) => new GradeCourseTest() 
        {
            Id = Guid.NewGuid(),
            GradeCourse = gradeCourse,
            Test = test
        };

        public void AssignSection(Test test, TestSection testSection)
        {
            test.Sections.Add(testSection);
            testSection.Test = test;
        }

        public TermCourseTest AssignTerm(Test test, TermCourse termCourse)
        {
            return new TermCourseTest()
            {
                Id = Guid.NewGuid(),
                TermCourse = termCourse,
                Test = test
            };
        }
    }
}