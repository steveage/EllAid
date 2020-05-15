using System.Collections.Generic;

namespace EllAid.Adapters.DataObjects
{
    public class EllCoachDto : PersonDto
    {
        public List<InstructorShortDto> Instructors { get; set; }
    }
}