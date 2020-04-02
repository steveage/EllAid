using System.Collections.Generic;

namespace EllAid.TestDataGenerator.UseCases.Adapters.DataObjects
{
    public class EllCoachDto : PersonDto
    {
        public List<InstructorShortDto> Instructors { get; set; }
    }
}