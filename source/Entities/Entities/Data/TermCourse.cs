namespace EllAid.Entities.Data
{
    public class TermCourse : Entity
    {
        public TermCourse() : base(){}
        public TermCourse(Term term, GradeCourse gradeCourse)
        {
            Term = term;
            GradeCourse = gradeCourse;
        }
        public GradeCourse GradeCourse { get; set; }
        public Term Term { get; set; }
    }
}