using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class ClassAssigner : IClassAssigner
    {
        readonly IInstructorManager instructorManager;

        public ClassAssigner(IInstructorManager instructorManager)
        {
            this.instructorManager = instructorManager;
        }

        public void AddStudent(Student student, SchoolClass schoolClass)
        {
            student.Class = schoolClass;
            schoolClass.Students.Add(student);
        }

        public void AssignClass(SchoolClass schoolClass, Instructor instructor, List<Assistant> assistants, EllCoach coach, List<Student> students, TermCourse termCourse)
        {
            CourseAssignment assignment = new CourseAssignment(termCourse, instructor);
            assistants.ForEach(assistant => instructorManager.AddAssistant(assistant, instructor));
            instructorManager.AddCoach(coach, instructor);
            schoolClass.CourseAssignment = assignment;
            students.ForEach(student => AddStudent(student, schoolClass));
            students.ForEach(student => student.Enrollments.Add(new Enrollment(student, assignment)));
        }
    }
}