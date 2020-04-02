using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Adapters.DataObjects
{
    public class InstructorShortDto : PersonDto
    {
        public Department Department { get; set; }
    }
}