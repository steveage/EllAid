using EllAid.Entities.Data;

namespace EllAid.DataSource.Adapters.DataObjects
{
    public class InstructorShortDto : PersonDto
    {
        public Department Department { get; set; }
    }
}