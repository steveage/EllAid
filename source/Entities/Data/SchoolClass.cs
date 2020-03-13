using System;

namespace EllAid.Entities.Data
{
    public class SchoolClass : Entity
    {
        public Guid InstructorId { get; set; }
        public Guid TermId { get; set; }
        public Guid GradeId { get; set; }
    }
}