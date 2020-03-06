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
            const int userCount = 4;

            IDataFabricator fabricator = new BogusFabricator();
            IUserDataAccess userData = new InMemoryUserDataProvider();
            UserCreator creator = new UserCreator(fabricator, userData);
            
            //When
            List<User> users = creator.CreateUsers<User>(userCount);

            //Then
            Assert.All<User>(users, user => Assert.True(user.Id>0));
            Assert.All<User>(users, user => Assert.NotEmpty(user.FirstName));
            Assert.All<User>(users, user => Assert.True(IsEmailAddress(user.Email)));
            Assert.All<User>(users, user => Assert.NotEmpty(user.FirstName));
            Assert.All<User>(users, user => Assert.NotEmpty(user.LastName));
            Assert.All<User>(users, user => Assert.NotEqual(Gender.Invalid, user.Gender));
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
            IDataFabricator fabricator = new BogusFabricator();
            IUserDataAccess userData = new InMemoryUserDataProvider();
            UserCreator creator = new UserCreator(fabricator, userData);
            const int userCount = 4;
            const int birthYear = 2012;
            
            //When
            List<Student> students = creator.CreateStudents(userCount, birthYear);

            //Then
            Assert.All<Student>(students, user => Assert.True(user.Id>0));
            Assert.All<Student>(students, user => Assert.NotEmpty(user.FirstName));
            Assert.All<Student>(students, user => Assert.True(IsEmailAddress(user.Email)));
            Assert.All<Student>(students, user => Assert.NotEmpty(user.FirstName));
            Assert.All<Student>(students, user => Assert.NotEmpty(user.LastName));
            Assert.All<Student>(students, user => Assert.NotEqual(DateTime.MinValue, user.DateOfBirth));
            Assert.All<Student>(students, user => Assert.NotEqual(DateTime.MinValue, user.EntryDate));
            Assert.All<Student>(students, user => Assert.NotEmpty(user.HomeLanguage));
            Assert.All<Student>(students, user => Assert.NotEmpty(user.HomeCommunicationLanguage));
            Assert.All<Student>(students, user => Assert.NotEmpty(user.PictureUrl));
            Assert.All<Student>(students, user => Assert.NotEqual(Gender.Invalid, user.Gender));
        }
    }
}