using System;
using System.Collections.Generic;
using System.Net.Mail;
using EllAid.Entities.Data;
using EllAid.Details.Main.DataAccess;
using EllAid.UseCases.Generator.Creation.People;
using Xunit;
using EllAid.Details.Main.DataFabricator;

namespace EllAid.Tests.UseCases.Generator.Creation.People
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
            List<Person> users = creator.CreatePeople<Person>(userCount);

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

        static internal bool IsEmailAddress(string text)
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

        [Fact]
        public void GetPerson_ReturnsPopulatedPerson()
        {
            //Given
            PersonCreator creator = GetCreator();

            //When
            Person person = creator.CreatePerson<Person>();
        
            //Then
            Assert.NotEqual(Guid.Empty, person.Id);
            Assert.NotEmpty(person.FirstName);
            Assert.NotEmpty(person.LastName);
            Assert.True(IsEmailAddress(person.Email));
            Assert.NotEqual(Gender.Invalid, person.Gender);
        }
    }
}