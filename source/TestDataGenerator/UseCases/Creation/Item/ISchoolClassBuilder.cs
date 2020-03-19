using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface ISchoolClassBuilder
    {
        SchoolClass CreateClass(string name, Instructor instructor, List<Assistant> assistants, EllCoach coach, List<Student> students, TermCourse termCourse);
    }
}