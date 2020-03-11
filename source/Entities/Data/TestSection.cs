namespace EllAid.Entities.Data
{
    public enum TestMetric
    {
        Invalid = 0,
        Point0To15,
        Point0To18,
        Point0To30
    }
    public class TestSection : Entity
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public TestMetric Metric { get; set; }
    }
}