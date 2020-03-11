namespace EllAid.Entities.Data
{
    public class SchoolClass : Entity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int Section { get; set; }
        public string Grade { get; set; }
        public string Year { get; set; }
        public string Department { get; set; }
    }
}