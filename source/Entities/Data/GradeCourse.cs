using System;

namespace EllAid.Entities.Data
{
    public class GradeCourse : Entity
    {
        public GradeCourse() : base()
        {
        }

        public GradeCourse(Course course, SchoolGrade grade)
        {
            Course = course;
            Grade = grade;
        }
        public Course Course { get; set; }
        public SchoolGrade Grade { get; set; }
    }
}