using System;

namespace EllAid.Entities.Data
{
    public class Enrollment : Entity
    {
        public Guid StudentId { get; set; }
        public Guid CourseGradeId { get; set; }
        public Guid TermId { get; set; }
        public string Score { get; set; }
    }
}