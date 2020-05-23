using System;

namespace EllAid.Entities.Data
{
    public class TestResult : Entity
    {
        public TestSection Section { get; set; }
        public DateTime Date { get; set; }
        public string Score { get; set; }
        public TestAssignment TestAssignment { get; set; }
    }
}