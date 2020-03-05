using System.Collections.Generic;
using EllAid.TestDataGenerator.Infrastructure.TestData;
using Xunit;

namespace EllAid.TestDataGenerator.Tests.Infrastructure
{
    public class InMemoryUserDataProviderTests
    {
        [Fact]
        public void GetFemalePictures_ReturnsListOfStrings()
        {
            //Given
            InMemoryUserDataProvider provider = new InMemoryUserDataProvider();

            //When
            List<string> urls = provider.GetFemalePictures();

            //Then
            Assert.All<string>(urls, url => Assert.NotEmpty(url));
            Assert.All<string>(urls, url => Assert.NotNull(url));
        }

        [Fact]
        public void GetLanguages_ReturnsListOfStrings()
        {
            //Given
            InMemoryUserDataProvider provider = new InMemoryUserDataProvider();

            //When
            List<string> languages = provider.GetLanguages();

            //Then
            Assert.All<string>(languages, language => Assert.NotEmpty(language));
            Assert.All<string>(languages, language => Assert.NotNull(language));
        }

        [Fact]
        public void GetMalePictures_ReturnsListOfStrings()
        {
            //Given
            InMemoryUserDataProvider provider = new InMemoryUserDataProvider();
            
            //When
            List<string> urls = provider.GetMalePictures();
        
            //Then
            Assert.All<string>(urls, url => Assert.NotEmpty(url));
            Assert.All<string>(urls, url => Assert.NotNull(url));
        }
    }
}