using System.Collections.Generic;

namespace EllAid.Entities.Data
{
    public class Instructor : Person
    {
        public List<Assistant> Assistants { get; set; }
        public EllCoach EllCoach { get; set; }
    }
}