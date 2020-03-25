using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class CourseManager : ICourseManager
    {
        public void AddTestSession(TestSession session, CourseAssignment assignment)
        {
            session.CourseAssignment = assignment;
            assignment.TestSessions.Add(session);
        }

        public void Enroll(Student student, Enrollment enrollment)
        {
            student.Enrollments.Add(enrollment);
            enrollment.Student = student;
        }
    }
}