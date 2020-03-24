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
        public Course() : base()
        {
        }
        public Course(string name, Department department) : this()
        {
            Name = name;
            Department = department;
        }
        public string Name { get; set; }
        public Department Department { get; set; }
    }
}