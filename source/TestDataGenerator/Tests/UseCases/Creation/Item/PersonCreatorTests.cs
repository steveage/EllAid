using System;
using System.Collections.Generic;
using System.Net.Mail;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.TestData;
using EllAid.TestDataGenerator.UseCases.Creation.Item;
using Xunit;

namespace EllAid.TestDataGenerator.Tests.UseCases.Creation.Item
{
    public class PersonCreatorTests
    {
        [Fact]
        public void CreatePeople_ReturnsPopulatedPeople()
        {
            //Given
            const int userCount = 4;
            PersonCreator creator = GetCreator();

            //When
            List<Person> users = creator.CreatePeople(userCount);

            //Then
            Assert.All<Person>(users, user => Assert.NotEqual(Guid.Empty, user.Id));
            Assert.All<Person>(users, user => Assert.True(IsEmailAddress(user.Email)));
            Assert.All<Person>(users, user => Assert.NotEmpty(user.FirstName));
            Assert.All<Person>(users, user => Assert.NotEmpty(user.LastName));
            Assert.All<Person>(users, user => Assert.NotEqual(Gender.Invalid, user.Gender));
        }

        PersonCreator GetCreator()
        {
            IDataFabricator fabricator = new BogusFabricator();
            IUserDataAccess userData = new InMemoryUserDataProvider();
            PersonCreator creator = new PersonCreator(fabricator, userData);
            return creator;
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
        public void CreateStudents_ReturnsPopulatedStudents()
        {
            //Given
            PersonCreator creator = GetCreator();
            const int userCount = 4;
            const int birthYear = 2012;
            
            //When
            List<Student> students = creator.CreateStudents(userCount, birthYear);

            //Then
            Assert.All<Student>(students, user => Assert.NotEqual(Guid.Empty, user.Id));
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