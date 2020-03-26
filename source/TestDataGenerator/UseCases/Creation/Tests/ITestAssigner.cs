using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Tests
{
    interface ITestAssigner
    {
        // CourseTest AssignCourse(Test test, Course course);
        // GradeCourseTest AssignGrade(Test test, GradeCourse gradeCourse);
        // TermCourseTest AssignTerm(Test test, TermCourse termCourse);
        void AssignSection(Test test, TestSection testSection);
    }
}