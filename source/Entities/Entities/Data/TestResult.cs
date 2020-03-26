using System;

namespace EllAid.Entities.Data
{
    public class TestResult<T> : Entity
    {
        public TestSession Session { get; set; }
        public TestSection Section { get; set; }
        public Student Student { get; set; }
        public DateTime Date { get; set; }
        public T Score { get; set; }
    }
}