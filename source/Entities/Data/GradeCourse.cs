using System;

namespace EllAid.Entities.Data
{
    public class GradeCourse : Entity
    {
        public Course Course { get; set; }
        public SchoolGrade Grade { get; set; }
    }
}