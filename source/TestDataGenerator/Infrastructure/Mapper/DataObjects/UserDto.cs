using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.DataObjects
{
    class UserDto : ItemDto
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
    }
}