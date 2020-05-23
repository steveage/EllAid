namespace EllAid.Entities.Data
{
    public class TestAssignment : Entity
    {
        public TestSession Session { get; set; }
        public Enrollment Enrollment { get; set; }
        public TestResult Result { get; set; }
    }
}