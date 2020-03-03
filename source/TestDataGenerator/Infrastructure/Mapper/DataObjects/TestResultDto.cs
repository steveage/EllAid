using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.DataObjects
{
    class TestResultDto : TestResult
    {
        internal int Version { get; set; }
        internal string Type { get; set; }
    }
}