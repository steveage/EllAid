namespace EllAid.Entities.Data
{
    public class Enrollment : Entity
    {
        public Enrollment(){}
        public Enrollment(CourseAssignment assignment) => CourseAssignment = assignment;
        public Student Student { get; set; }
        public CourseAssignment CourseAssignment { get; set; }
        public string Score { get; set; }
    }
}