using EllAid.Entities.Data;

namespace EllAid.UseCases.Generator.Creation.Courses
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