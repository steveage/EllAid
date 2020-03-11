using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface IItemAssigner
    {
        void AssignUsersToClass(SchoolClass schoolClass, Person teacher, Person ellCoach, List<Person> assistants);
        void AssignStudentsToClass(List<Student> students, List<Course> studentClasses, SchoolClass schoolClass, Person teacher);
        void AssignStudentToTestResult<T>(Student student, SchoolClass schoolClass, TestResult<T> result, TestSession session);
    }
}