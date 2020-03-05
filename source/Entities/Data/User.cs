using System.Collections.Generic;

namespace EllAid.Entities.Data
{

    public enum Gender
    {
        Invalid = 0,
        Male,
        Female
    }

    public enum UserType
    {
        Invalid = 0,
        Student,
        Teacher,
        Assistant,
        EllCoach
    }

    public class User : Entity
    {
        public User() => Classes = new List<SchoolClass>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }
        public List<SchoolClass> Classes { get; set; }
    }
}