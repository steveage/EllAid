using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.TestData;
using Xunit;

namespace EllAid.TestDataGenerator.Tests.Infrastructure
{
    public class FakeDataProviderTests
    {
        [Fact]
        public void PickRandomGender_ReturnsValidGender()
        {
            //Given
            FakeDataProvider provider = new FakeDataProvider();

            //When
            Gender gender = provider.PickRandomGender();

            //Then
            Assert.True(gender!=Gender.Invalid);
        }
    }
}