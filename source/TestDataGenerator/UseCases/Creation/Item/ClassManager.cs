using System;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class ClassManager : IClassManager
    {
        public void AddStudent(Student student, SchoolClass schoolClass)
        {
            student.Class = schoolClass;
            schoolClass.Students.Add(student);
        }

        public SchoolClass Create(string className) => new SchoolClass()
        {
            Id = Guid.NewGuid(),
            Name = className
        };
    }
}