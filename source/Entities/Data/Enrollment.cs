namespace EllAid.Entities.Data
{
    public class Enrollment : Entity
    {
        public Student Student { get; set; }
        public CourseAssignment CourseAssignment { get; set; }
        public string Score { get; set; }
    }
}   