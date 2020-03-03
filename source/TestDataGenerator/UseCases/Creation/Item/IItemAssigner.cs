using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface IItemAssigner
    {
        void AssignUsersToClass(SchoolClass schoolClass, User teacher, User ellCoach, List<User> assistants);
        void AssignStudentsToClass(List<Student> students, List<Course> studentClasses, SchoolClass schoolClass, User teacher);
        void AssignStudentToTestResult(Student student, SchoolClass schoolClass, TestResult result, TestSession session);
    }
}