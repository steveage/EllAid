namespace EllAid.Entities.Data
{
    public class TermCourseTest : Entity
    {
        public TermCourseTest() : base()
        {
        }
        public TermCourseTest(Test test, TermCourse termCourse) : this()
        {
            Test = test;
            TermCourse = termCourse;
        }
        public TermCourse TermCourse { get; set; }
        public Test Test { get; set; }
    }
}