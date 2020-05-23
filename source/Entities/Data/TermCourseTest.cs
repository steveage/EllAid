namespace EllAid.Entities.Data
{
    public class TermCourseTest : Entity
    {
        public TermCourseTest(){}
        public TermCourseTest(Test test, TermCourse termCourse)
        {
            Test = test;
            TermCourse = termCourse;
        }
        public TermCourse TermCourse { get; set; }
        public Test Test { get; set; }
    }
}