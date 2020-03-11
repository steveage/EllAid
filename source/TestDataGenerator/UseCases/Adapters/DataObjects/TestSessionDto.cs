using System;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Adapters.DataObjects
{
    public class TestSessionDto : EntityDto
    {
        public string Teacher { get; set; }
        public string Grade { get; set; }
        public string Year { get; set; }
        public string Term { get; set; }
        public DateTime Date { get; set; }
    }
}