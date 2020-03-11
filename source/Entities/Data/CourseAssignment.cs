namespace EllAid.Entities.Data
{
    public class CourseAssignment : Entity
    {
        public int CourseGradeId { get; set; }
        public int InstructorId { get; set; }
        public int TermId { get; set; }
    }
}