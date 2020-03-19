namespace EllAid.Entities.Data
{
    public class TermCourse : Entity
    {
        public GradeCourse GradeCourse { get; set; }
        public Term Term { get; set; }
    }
}