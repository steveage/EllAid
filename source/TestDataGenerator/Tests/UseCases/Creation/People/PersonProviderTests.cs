using System;
using System.Collections.Generic;
using System.Linq;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure;
using EllAid.TestDataGenerator.UseCases.Creation.People;
using Xunit;

namespace EllAid.TestDataGenerator.Tests.UseCases.Creation.People
{
    public class PersonProviderTests
    {
        [Fact]
        public void GetPerson_WhenCalledUpToCountTimes_ReturnsDifferentPerson()
        {
            // Arrange
            List<string> userIds = new List<string>();
            IPersonProvider provider =  new PersonProvider(new PersonCreator(new BogusFabricator(), new InMemoryUserDataProvider()));
            const int userCount = 4;
            provider.Initialize(userCount);

            // Act
            for (int i = 0; i < userCount; i++)
            {
                userIds.Add(provider.GetPerson().Email);
            }

            // Assert
            foreach (string userId in userIds)
            {
                int userIdCount = userIds.Count( u=>u.Equals(userId));
                Assert.Equal(1, userIdCount);
            }
        }

        [Fact]
        void GetPerson_WhenCalledMoreThanCountTimes_ReturnsSamePeople()
        {
            // Arrange
            List<string> userIds = new List<string>();
            IPersonProvider provider =  new PersonProvider(new PersonCreator(new BogusFabricator(), new InMemoryUserDataProvider()));
            const int userCount = 4;
            provider.Initialize(userCount);
            const int requestSets = 3;
            int requestCount = requestSets * provider.Count;

            // Act
            for (int i = 0; i < requestCount; i++)
            {
                userIds.Add(provider.GetPerson().Email);
            }

            // Assert
            foreach (string userId in userIds)
            {
                int userIdCount = userIds.Count(u=>u.Equals(userId));
                Assert.Equal(requestSets, userIdCount);
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Initialize_WhenInvalidParameters_ThrowsException(int count)
        {
            //Given
            IPersonProvider provider =  new PersonProvider(new PersonCreator(new BogusFabricator(), new InMemoryUserDataProvider()));

            //When
            Action initializeAction = () => provider.Initialize(count);

            //Then
            Assert.Throws<PersonProviderNotInitializedException>(initializeAction);
        }

        [Fact]
        public void GetPerson_WhenNotInitialized_ThrowsException()
        {
            //Given
            IPersonProvider provider = new PersonProvider(new PersonCreator(new BogusFabricator(), new InMemoryUserDataProvider()));

            //When
            Action action = ()=> provider.GetPerson();

            //Then
            Assert.Throws<PersonProviderNotInitializedException>(action);
        }

        [Fact]
        public void GetPeople_WhenNotInitialized_ThrowsException()
        {
            //Given
            IPersonProvider provider =  new PersonProvider(new PersonCreator(new BogusFabricator(), new InMemoryUserDataProvider()));

            //When
            Action action = ()=> provider.GetPeople();

            //Then
            Assert.Throws<PersonProviderNotInitializedException>(action);
        }

        [Fact]
        public void GetPeople_WhenInitialized_ReturnsSameCountOfPeople()
        {
            //Given
            IPersonProvider provider =  new PersonProvider(new PersonCreator(new BogusFabricator(), new InMemoryUserDataProvider()));
            const int count = 4;
            provider.Initialize(count);

            //When
            List<Person> users = provider.GetPeople();

            //Then
            Assert.Equal(count, users.Count);
        }
    }
}