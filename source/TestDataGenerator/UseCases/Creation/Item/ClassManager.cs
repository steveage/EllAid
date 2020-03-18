using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class ClassManager : IClassManager
    {
        public void AddStudent(Student student, SchoolClass schoolClass)
        {
            (schoolClass.Students ??= new List<Student>()).Add(student);
        }

        public SchoolClass Create(string className, SchoolGrade grade)
        {
            SchoolClass schoolClass = new SchoolClass()
            {
                Name = className,
                Grade = grade
            };
            return schoolClass;
        }
    }
}