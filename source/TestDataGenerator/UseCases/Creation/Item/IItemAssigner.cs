using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface IItemAssigner
    {
        void AssignUsersToClass(SchoolClass schoolClass, Person teacher, Person ellCoach, List<Person> assistants);
        void AssignStudentsToClass(List<Student> students, List<Course> studentClasses, SchoolClass schoolClass, Person teacher);
        void AssignStudentToTestResult(Student student, SchoolClass schoolClass, TestResult result, TestSession session);
    }
}