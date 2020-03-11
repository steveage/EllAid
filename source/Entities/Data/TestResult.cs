using System;

namespace EllAid.Entities.Data
{
    public class TestResult<T> : Entity
    {
        public int TestSessionId { get; set; }
        public int TestSectionId { get; set; }
        public string StudentId { get; set; }
        public DateTime Date { get; set; }
        public T Score { get; set; }
    }
}