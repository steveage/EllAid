using System;

namespace EllAid.Entities.Data
{
    public class TestSession : TestBase
    {
        public string Teacher { get; set; }
        public string Grade { get; set; }
        public string Year { get; set; }
        public string Term { get; set; }
        public DateTime Date { get; set; }
    }
}