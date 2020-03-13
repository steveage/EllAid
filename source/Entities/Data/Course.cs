namespace EllAid.Entities.Data
{
    public enum Department
    {
        Invalid = 0,
        EarlyChildhood,
        ElementarySchool,
        MiddleSchool,
        HighSchool
    }
    public class Course : Entity
    {
        public string Name { get; set; }
        public Department Department { get; set; }
    }
}