using System.Collections.Generic;

namespace EllAid.TestDataGenerator.UseCases.Adapters.DataObjects
{
    public class CourseDto : EntityDto
    {
        public string Class { get; set; }
        public List<string> Teachers { get; set; }
        public bool IsCurrent { get; set; }
        public string Score { get; set; }
        public string UserId { get; set; }
    }
}