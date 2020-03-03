using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.DataObjects
{
    class TestSessionDto : TestSession
    {
        internal int Version { get; set; }
        internal string Type { get; set; }       
    }
}