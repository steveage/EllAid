using System.Collections.Generic;
using System.Linq;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class ItemAssigner : IItemAssigner
    {
        readonly IItemProvider itemProvider;

        public ItemAssigner(IItemProvider itemProvider)
        {
            this.itemProvider = itemProvider;
        }

        public void AssignStudentsToClass(List<Student> students, List<Course> studentClasses, SchoolClass schoolClass, User teacher)
        {
            foreach (Student student in students)
            {
                // student.Classes.Add(schoolClass);
                Course studentClass = itemProvider.GetStudentCourse(student.Email, schoolClass.Id, teacher.Email, string.Empty, true);
                studentClasses.Add(studentClass);
                schoolClass.Students.Add(student.Email);
            }
        }

        public void AssignUsersToClass(SchoolClass schoolClass, User teacher, User ellCoach, List<User> assistants)
        {
            schoolClass.Email = teacher.Email;
            schoolClass.Teachers.Add(teacher.Email);
            schoolClass.Assistants = assistants.Select(a => a.Email).ToList();
            schoolClass.EllCoaches.Add(ellCoach.Email);
            // assistants.ForEach(a => a.Classes.Add(schoolClass));
            // assistants.ForEach(a => a.Classes.Add(teacher.Email));
            // ellCoach.Classes.Add(schoolClass);
        }

        public void AssignStudentToTestResult(Student student, SchoolClass schoolClass, TestResult result, TestSession session)
        {
            result.TestSessionId = session.Id;
            result.UserId = student.Email;
            session.Term = result.Term;
            session.Grade = schoolClass.Grade;
            session.Teacher = schoolClass.Email;
            session.Year = schoolClass.Year;
        }
    }
}