namespace EllAid.Entities.Data
{
    public class CourseTest : Entity
    {
        public CourseTest(){}
        public CourseTest(Test test, Course course)
        {
            Test = test;
            Course = course;
        }
        public Course Course { get; set; }
        public Test Test { get; set; }
    }
}