using System;

namespace EllAid.Entities.Data
{
    public class TestResult : Entity
    {
        // public TestSession Session { get; set; }
        public TestSection Section { get; set; }
        // public Student Student { get; set; }
        public DateTime Date { get; set; }
        public string Score { get; set; }
        public TestAssignment TestAssignment { get; set; }
    }
}