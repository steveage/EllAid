using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.UseCases.Generator.Creation.SchoolClasses
{
    interface IClassAssigner
    {
        void AssignClass(SchoolClass schoolClass, Instructor instructor, List<Assistant> assistants, EllCoach coach, List<Student> students, TermCourse termCourse);
        void AddStudent(Student student, SchoolClass schoolClass);
    }
}