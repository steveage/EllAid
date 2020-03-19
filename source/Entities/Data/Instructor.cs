using System.Collections.Generic;

namespace EllAid.Entities.Data
{
    public class Instructor : Person
    {
        public Instructor() => Assistants = new List<Assistant>();
        public List<Assistant> Assistants { get; set; }
        public EllCoach EllCoach { get; set; }
        public Department Department { get; set; }
    }
}