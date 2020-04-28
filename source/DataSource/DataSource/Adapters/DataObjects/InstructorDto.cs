using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.DataSource.Adapters.DataObjects
{
    public class InstructorDto : PersonDto
    {
        public EllCoachShortDto EllCoach { get; set; }
        public List<AssistantShortDto> Assistants { get; set; }
        public Department Department { get; set; }
    }
}