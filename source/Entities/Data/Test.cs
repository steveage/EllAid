using System.Collections.Generic;

namespace EllAid.Entities.Data
{
    public enum TestSubject
    {
        Invalid = 0,
        EnglishLearning
    }

    public class Test : Entity
    {
        public Test() => Sections = new List<TestSection>();
        public string Name { get; set; }
        public TestSubject Subject { get; set; }
        public List<TestSection> Sections { get; set; }
    }
}