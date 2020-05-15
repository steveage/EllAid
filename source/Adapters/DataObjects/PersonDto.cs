using EllAid.Entities.Data;
using Mobsites.AspNetCore.Identity.Cosmos;

namespace EllAid.Adapters.DataObjects
{
    public class PersonDto : IdentityUser //DigitalEntityDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int Version { get; set; }
        public string Type { get; set; }
        public override string PartitionKey => Email;
    }
}