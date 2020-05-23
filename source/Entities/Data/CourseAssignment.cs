using System.Collections.Generic;

namespace EllAid.Entities.Data
{
    public class CourseAssignment : Entity
    {
        public CourseAssignment() => TestSessions = new List<TestSession>();
        public CourseAssignment(TermCourse termCourse, Instructor instructor) : this()
        {
            TermCourse = termCourse;
            Instructor = instructor;
        }
        public List<TestSession> TestSessions { get; set; }
        public TermCourse TermCourse { get; set; }
        public Instructor Instructor { get; set; }
    }
}