namespace EllAid.Entities.Data
{
    public class GradeCourseTest : Entity
    {
        public GradeCourseTest(){}
        public GradeCourseTest(Test test, GradeCourse gradeCourse)
        {
            Test = test;
            GradeCourse = gradeCourse;  
        }
        public GradeCourse GradeCourse { get; set; }
        public Test Test { get; set; }
    }
}