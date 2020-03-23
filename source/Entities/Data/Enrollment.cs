namespace EllAid.Entities.Data
{
    public class Enrollment : Entity
    {
        public Enrollment() : base()
        {
        }
        public Enrollment(Student student, CourseAssignment assignment) : this()
        {
            Student = student;
            CourseAssignment = assignment;
            // Student.Enrollments.Add(this);
        }
        public Student Student { get; set; }
        public CourseAssignment CourseAssignment { get; set; }
        public string Score { get; set; }
    }
}   