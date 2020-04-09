using System.Collections.Generic;

namespace EllAid.DataSource.Adapters.DataObjects
{
    public class EllCoachDto : PersonDto
    {
        public List<InstructorShortDto> Instructors { get; set; }
    }
}