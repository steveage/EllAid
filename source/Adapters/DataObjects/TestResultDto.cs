using System;
using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.Adapters.DataObjects
{
    public class TestResultDto<T> : EntityDto
    {
        public string TestSessionId { get; set; }
        public string UserId { get; set; }
        public string Subject { get; set; }
        public string Name { get; set; }
        public string Term { get; set; }
        public DateTime Date { get; set; }
        public List<TestSection> Sections { get; set; }
    }
}