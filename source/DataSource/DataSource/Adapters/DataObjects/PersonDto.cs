using EllAid.Entities.Data;

namespace EllAid.DataSource.Adapters.DataObjects
{
    public class PersonDto : DigitalEntityDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
    }
}