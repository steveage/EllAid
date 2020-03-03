using Microsoft.Azure.Cosmos;

namespace EllAid.TestDataGenerator.Infrastructure.TestData
{
    interface IDatabaseAccess
    {
        Container TestsContainer { get; }
        Container UsersContainer { get; }
    }
}