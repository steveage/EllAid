using System;

namespace EllAid.Entities.Data
{
    public class StudentClass : Entity
    {
        public Guid SchoolClassId { get; set; }
        public Guid StudentId { get; set; }
    }
}