namespace EllAid.Entities.Data
{

    public enum Gender
    {
        Invalid = 0,
        Male,
        Female
    }

    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
    }
}