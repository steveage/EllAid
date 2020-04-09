using EllAid.Entities.Data;

namespace EllAid.DataSource.Adapters.DataObjects
{
    public class PersonDto : EntityDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
    }
}