using System.Collections.Generic;

namespace EllAid.Entities.Data
{
    public class EllCoach : Person
    {
        public List<Instructor> Instructors { get; set; }
    }
}