using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Adapters.DataObjects
{
    public class InstructorDto : PersonDto
    {
        public PersonDto EllCoach { get; set; }
        public List<PersonDto> Assistants { get; set; }
        public Department Department { get; set; }
    }
}