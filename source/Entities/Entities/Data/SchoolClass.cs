using System;
using System.Collections.Generic;

namespace EllAid.Entities.Data
{
    public enum SchoolGrade
    {
        Invalid = 0,
        PreKindergarten,
        Kindergarten,
        Grade1,
        Grade2,
        Grade3,
        Grade4,
        Grade5,
        Grade6,
        Grade7,
        Grade8,
        Grade9,
        Grade10,
        Grade11,
        Grade12
    }

    public class SchoolClass : Entity
    {
        public SchoolClass() => Students = new List<Student>();
        public SchoolClass(string name) : this() => Name = name;
        public string Name { get; set; }
        public CourseAssignment CourseAssignment { get; set; }
        public List<Student> Students { get; set; }
    }
}