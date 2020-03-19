using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface ICourseManager
    {
        Course CreateCourse(string name, Department department);
        GradeCourse CreateGradeCourse(Course course, SchoolGrade grade);
        TermCourse CreateTermCourse(Term term, GradeCourse gradeCourse);
        CourseAssignment CreateCourseAssignment(TermCourse termCourse, Instructor instructor);
        void EnrollStudent(Student student, CourseAssignment assignment);
    }
}