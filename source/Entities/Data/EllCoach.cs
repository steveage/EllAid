using System.Collections.Generic;

namespace EllAid.Entities.Data
{
    public class EllCoach : Person
    {
        public EllCoach() => Instructors = new List<Instructor>();
        public List<Instructor> Instructors { get; set; }
    }
}