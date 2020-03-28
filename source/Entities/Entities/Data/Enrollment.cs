using System.Collections.Generic;

namespace EllAid.Entities.Data
{
    public class Enrollment : Entity
    {
        public Enrollment() => TestAssignments = new List<TestAssignment>();
        public Enrollment(CourseAssignment assignment) : this() => CourseAssignment = assignment;
        public Student Student { get; set; }
        public CourseAssignment CourseAssignment { get; set; }
        public string Score { get; set; }
        public List<TestAssignment> TestAssignments { get; set; }
    }
}