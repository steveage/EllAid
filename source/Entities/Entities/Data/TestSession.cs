using System;

namespace EllAid.Entities.Data
{
    public class TestSession : Entity
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public int CourseAssignmentId { get; set; }
        public DateTime Date { get; set; }
    }
}