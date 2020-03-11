namespace EllAid.Entities.Data
{
    public class Enrollment : Entity
    {
        public int StudentId { get; set; }
        public int CourseAssignmentId { get; set; }
        public int TermId { get; set; }
    }
}