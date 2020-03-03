using System;

namespace EllAid.Entities.Data
{
    public class TestResult : TestBase
    {
        public int TestSessionId { get; set; }
        public string UserId { get; set; }
        public string Subject { get; set; }
        public string Name { get; set; }
        public string Term { get; set; }
        public DateTime Date { get; set; }
        public TestSection[] Sections { get; set; }
    }
}