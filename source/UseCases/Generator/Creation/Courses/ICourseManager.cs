using EllAid.Entities.Data;

namespace EllAid.UseCases.Generator.Creation.Courses
{
    interface ICourseManager
    {
        void Enroll(Student student, Enrollment enrollment);
        void AddTestSession(TestSession session, CourseAssignment assignment);
    }
}