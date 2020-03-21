using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface IClassAssigner
    {
        void AssignClass(SchoolClass schoolClass, Instructor instructor, List<Assistant> assistants, EllCoach coach, List<Student> students, TermCourse termCourse);
    }
}