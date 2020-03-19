namespace EllAid.Entities.Data
{
    public class CourseAssignment : Entity
    {
        public TermCourse TermCourse { get; set; }
        public Instructor Instructor { get; set; }
    }
}