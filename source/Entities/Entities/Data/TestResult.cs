using System;

namespace EllAid.Entities.Data
{
    public class TestResult<T> : Entity
    {
        public Guid TestSessionId { get; set; }
        public Guid TestSectionId { get; set; }
        public Guid StudentId { get; set; }
        public DateTime Date { get; set; }
        public T Score { get; set; }
    }
}