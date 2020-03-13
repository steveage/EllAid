using System;

namespace EllAid.Entities.Data
{
    public class SchoolClass : Entity
    {
        public Instructor Instructor { get; set; }
        public Guid TermId { get; set; }
        public Guid GradeId { get; set; }
    }
}