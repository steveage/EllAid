using System;

namespace EllAid.Entities.Data
{
    public class CourseAssignment : Entity
    {
        public Guid CourseGradeId { get; set; }
        public Guid InstructorId { get; set; }
        public Guid TermId { get; set; }
    }
}