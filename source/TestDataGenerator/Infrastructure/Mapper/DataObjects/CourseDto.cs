using System.Collections.Generic;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.DataObjects
{
    class CourseDto : ItemDto
    {
        internal int Class { get; set; }
        internal List<string> Teachers { get; set; }
        internal bool IsCurrent { get; set; }
        internal string Score { get; set; }
        internal string UserId { get; set; }
    }
}