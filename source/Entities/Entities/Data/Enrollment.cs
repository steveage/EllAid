namespace EllAid.Entities.Data
{
    public class Enrollment : Entity
    {
        public Enrollment() : base(){}
        public Enrollment(CourseAssignment assignment) : this() => CourseAssignment = assignment;
        public Student Student { get; set; }
        public CourseAssignment CourseAssignment { get; set; }
        public string Score { get; set; }
    }
}