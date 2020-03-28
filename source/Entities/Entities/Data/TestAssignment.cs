using System.Collections.Generic;

namespace EllAid.Entities.Data
{
    public class TestAssignment : Entity
    {
        public TestAssignment() => Results = new List<TestResult>();
        public TestSession Session { get; set; }
        public Enrollment Enrollment { get; set; }
        public List<TestResult> Results { get; set; }
    }
}