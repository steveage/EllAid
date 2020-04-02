using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Adapters.DataObjects
{
    public class AssistantDto : PersonDto
    {
        public InstructorShortDto Instructor { get; set; }
    }
}