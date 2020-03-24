namespace EllAid.Entities.Data
{
    public class CourseAssignment : Entity
    {
        public CourseAssignment(){}
        public CourseAssignment(TermCourse termCourse, Instructor instructor)
        {
            TermCourse = termCourse;
            Instructor = instructor;
        }
        public TermCourse TermCourse { get; set; }
        public Instructor Instructor { get; set; }
    }
}