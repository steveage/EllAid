using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface ICourseManager
    {
        void Enroll(Student student, Enrollment enrollment);
        void AddTestSession(TestSession session, CourseAssignment assignment);
    }
}