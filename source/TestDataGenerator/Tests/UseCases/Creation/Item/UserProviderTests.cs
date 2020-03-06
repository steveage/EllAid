using System;
using System.Collections.Generic;
using System.Linq;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.TestData;
using EllAid.TestDataGenerator.UseCases.Creation.Item;
using Xunit;

namespace EllAid.TestDataGenerator.Tests.UseCases.Creation.Item
{
    public class UserProviderTests
    {
        [Fact]
        public void GetUser_ReturnsTypeUser()
        {
            // Arrange
            IUserProvider<User> provider = new UserProvider<User>(new UserCreator(new BogusFabricator(), new InMemoryUserDataProvider()));
            provider.Initialize(4);

            // Act
            User user = provider.GetUser();

            // Assert
            //Assert.Equal(userType, user.Type);
        }

        [Fact]
        public void GetUser_WhenCalledUpToCountTimes_ReturnsDifferentUser()
        {
            // Arrange
            List<string> userIds = new List<string>();
            IUserProvider<User> provider =  new UserProvider<User>(new UserCreator(new BogusFabricator(), new InMemoryUserDataProvider()));
            const int userCount = 4;
            provider.Initialize(userCount);

            // Act
            for (int i = 0; i < userCount; i++)
            {
                userIds.Add(provider.GetUser().Email);
            }

            // Assert
            foreach (string userId in userIds)
            {
                int userIdCount = userIds.Count( u=>u.Equals(userId));
                Assert.Equal(1, userIdCount);
            }
        }

        [Fact]
        void GetUser_WhenCalledMoreThanCountTimes_ReturnsSameUsers()
        {
            // Arrange
            List<string> userIds = new List<string>();
            IUserProvider<User> provider =  new UserProvider<User>(new UserCreator(new BogusFabricator(), new InMemoryUserDataProvider()));
            const int userCount = 4;
            provider.Initialize(userCount);
            const int requestSets = 3;
            int requestCount = requestSets * provider.Count;

            // Act
            for (int i = 0; i < requestCount; i++)
            {
                userIds.Add(provider.GetUser().Email);
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
        [InlineData(4)]
        public void Initialize_WhenInvalidParameters_ThrowsException(int count)
        {
            //Given
            IUserProvider<User> provider =  new UserProvider<User>(new UserCreator(new BogusFabricator(), new InMemoryUserDataProvider()));

            //When
            Action initializeAction = () => provider.Initialize(count);

            //Then
            Assert.Throws<UserProviderNotInitializedException>(initializeAction);
        }

        [Fact]
        public void GetUser_WhenNotInitialized_ThrowsException()
        {
            //Given
            IUserProvider<User> provider = new UserProvider<User>(new UserCreator(new BogusFabricator(), new InMemoryUserDataProvider()));

            //When
            Action action = ()=> provider.GetUser();

            //Then
            Assert.Throws<UserProviderNotInitializedException>(action);
        }

        [Fact]
        public void GetUsers_WhenNotInitialized_ThrowsException()
        {
            //Given
            IUserProvider<User> provider =  new UserProvider<User>(new UserCreator(new BogusFabricator(), new InMemoryUserDataProvider()));

            //When
            Action action = ()=> provider.GetUsers();

            //Then
            Assert.Throws<UserProviderNotInitializedException>(action);
        }

        [Fact]
        public void GetUsers_WhenInitialized_ReturnsSameCountOfUsers()
        {
            //Given
            IUserProvider<User> provider =  new UserProvider<User>(new UserCreator(new BogusFabricator(), new InMemoryUserDataProvider()));
            const int count = 4;
            provider.Initialize(count);

            //When
            List<User> users = provider.GetUsers();

            //Then
            Assert.Equal(count, users.Count);
        }
    }
}