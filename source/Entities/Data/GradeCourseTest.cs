namespace EllAid.Entities.Data
{
    public class GradeCourseTest : Entity
    {
        public GradeCourseTest() : base()
        {
        }

        public GradeCourseTest(Test test, GradeCourse gradeCourse) : this()
        {
            Test = test;
            GradeCourse = gradeCourse;  
        }
        public GradeCourse GradeCourse { get; set; }
        public Test Test { get; set; }
    }
}