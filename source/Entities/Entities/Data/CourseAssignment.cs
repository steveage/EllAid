namespace EllAid.Entities.Data
{
    public class CourseAssignment : Entity
    {
        public CourseAssignment() : base()
        {
        }
        public CourseAssignment(TermCourse termCourse, Instructor instructor) : this()
        {
            TermCourse = termCourse;
            Instructor = instructor;
        }
        public TermCourse TermCourse { get; set; }
        public Instructor Instructor { get; set; }
    }
}