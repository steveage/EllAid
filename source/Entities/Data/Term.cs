namespace EllAid.Entities.Data
{
    public enum SchoolTerm
    {
        Invalid = 0,
        Spring,
        Fall,
        Summer
    }
    public class Term : Entity
    {
        public int Year { get; set; }
        public SchoolTerm SchoolTerm { get; set; }
    }
}