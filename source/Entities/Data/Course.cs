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
        public Course(){}
        public Course(string name, Department department)
        {
            Name = name;
            Department = department;
        }
        public string Name { get; set; }
        public Department Department { get; set; }
    }
}