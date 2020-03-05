using System;
using System.Collections.Generic;
using System.Net.Mail;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.TestData;
using EllAid.TestDataGenerator.UseCases.Creation.Item;
using Moq;
using Xunit;

namespace EllAid.TestDataGenerator.Tests.UseCases.Creation.Item
{
    public class UserCreatorTests
    {
        [Fact]
        public void GetUsers_ReturnsPopulatedUsers()
        {
            //Given
            DateTime expectedData = DateTime.Now;
            const string expectedString = "fakeString";
            const int expectedInt = 1000;
            const string userType = "teacher";
            const int userCount = 4;
            Mock<IDataFabricator> fakeData = new Mock<IDataFabricator>() {
                DefaultValueProvider = new FakeDataValueProvider(expectedData, expectedString, expectedInt)
            };
            IDataFabricator fabricator = new BogusFabricator();
            IUserDataAccess userData = new InMemoryUserDataProvider();
            UserCreator creator = new UserCreator(fabricator, userData);
            
            //When
            List<User> users = creator.CreateUsers<User>(userType, userCount);

            //Then
            //Assert.All<User>(users, user => Assert.Equal(userType, user.Type));
            //Assert.All<User>(users, user => Assert.True(Guid.TryParse(user.Id, out Guid newGuid)));
            Assert.All<User>(users, user => Assert.True(user.Id>0));
            Assert.All<User>(users, user => Assert.Equal(expectedString, user.FirstName));
            Assert.All<User>(users, user => Assert.True(IsEmailAddress(user.Email)));
            Assert.All<User>(users, user => Assert.Equal(expectedString, user.FirstName));
            Assert.All<User>(users, user => Assert.Equal(expectedString, user.LastName));
        }

        bool IsEmailAddress(string text)
        {
            try
            {
                MailAddress address = new MailAddress(text);
                return address.Address == text;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [Fact]
        public void GetStudents_ReturnsPopulatedStudents()
        {
            //Given
            DateTime expectedDate = DateTime.Now;
            const string expectedString = "fakeString";
            const int expectedInt = 1000;
            const int userCount = 4;
            const int birthYear = 2012;
            Mock<IDataFabricator> fakeData = new Mock<IDataFabricator>() {
                DefaultValueProvider = new FakeDataValueProvider(expectedDate, expectedString, expectedInt)
            };
            Mock<IUserDataAccess> userData = new Mock<IUserDataAccess>() {
                DefaultValueProvider = new FakeDataValueProvider(expectedDate, expectedString, expectedInt)
            };
            UserCreator creator = new UserCreator(fakeData.Object, userData.Object);
            
            //When
            List<Student> students = creator.CreateStudents(userCount, birthYear);

            //Then
            Assert.All<Student>(students, user => Assert.True(user.Id>0));
            Assert.All<Student>(students, user => Assert.Equal(expectedString, user.FirstName));
            Assert.All<Student>(students, user => Assert.True(IsEmailAddress(user.Email)));
            Assert.All<Student>(students, user => Assert.Equal(expectedString, user.FirstName));
            Assert.All<Student>(students, user => Assert.Equal(expectedString, user.LastName));
            Assert.All<Student>(students, user => Assert.Equal(expectedDate, user.DateOfBirth));
            Assert.All<Student>(students, user => Assert.True(user.EntryDate>DateTime.MinValue));
            Assert.All<Student>(students, user => Assert.Equal(expectedString, user.HomeLanguage));
            Assert.All<Student>(students, user => Assert.Equal(expectedString, user.HomeCommunicationLanguage));
            Assert.All<Student>(students, user => Assert.Equal(expectedString, user.PictureUrl));
            Assert.All<Student>(students, user => Assert.NotNull(user.Classes));
        }
    }

    class FakeDataValueProvider : LookupOrFallbackDefaultValueProvider
    {
        public FakeDataValueProvider(DateTime expectedDate, string expectedString, int expectedInt)
        {
            base.Register(typeof(string), (type, mock) => expectedString);
            base.Register(typeof(DateTime), (type, mock) => expectedDate);
            base.Register(typeof(int), (type, mock) => expectedInt);
            base.Register(typeof(string[]), (type, mock) => new string[]{ expectedString });
        }
    }
}