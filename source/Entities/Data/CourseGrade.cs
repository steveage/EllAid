using System;

namespace EllAid.Entities.Data
{
    public class CourseGrade : Entity
    {
        public Guid CourseId { get; set; }
        public Guid GradeId { get; set; }
    }
}