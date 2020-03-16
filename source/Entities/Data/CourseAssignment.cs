using System;

namespace EllAid.Entities.Data
{
    public class CourseAssignment : Entity
    {
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
        public SchoolGrade Grade { get; set; }
        public Term Term { get; set; }
    }
}