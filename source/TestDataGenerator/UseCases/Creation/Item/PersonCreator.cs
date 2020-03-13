using System;
using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class PersonCreator : IPersonCreator
    {
        readonly IDataFabricator fakeDataProvider;
        readonly IUserDataAccess userData;

        public PersonCreator(IDataFabricator fakeDataProvider, IUserDataAccess userData)
        {
            this.fakeDataProvider = fakeDataProvider;
            this.userData = userData;
        }

        public List<Student> CreateStudents(int count, int birthYear)
        {
            List<Student> students = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                students.Add(GetStudent(birthYear));
            }

            return students;
        }

        Student GetStudent(int birthYear)
        {
            Student student = CreatePerson<Student>();
            string language = fakeDataProvider.PickRandom(userData.GetLanguages());
            List<string> pictureUrls = student.Gender==Gender.Male? userData.GetMalePictures(): userData.GetFemalePictures(); 
            string pictureUrl = fakeDataProvider.PickRandom(pictureUrls);
            const int yearsToGoBack = 1;
            DateTime birthYearDate = new DateTime(birthYear, 1, 1);
            DateTime birthDate = fakeDataProvider.GetRandomPastDate(yearsToGoBack, birthYearDate);
            int enrollmentYear = birthYear + 4;
            DateTime enrollmentDate = new DateTime(enrollmentYear, 1, 1).AddMonths(8);

            student.DateOfBirth = birthDate;
            student.EntryDate = enrollmentDate;
            student.HomeLanguage = language;
            student.HomeCommunicationLanguage = language;
            student.PictureUrl = pictureUrl;
            
            return student;
        }

        public List<T> CreatePeople<T>(int count) where T : Person , new()
        {
            List<T> users = new List<T>();

            for (int i = 0; i < count; i++)
            {
                users.Add(CreatePerson<T>());
            }

            return users;
        }

        public T CreatePerson<T>() where T: Person, new()
        {
            T person = new T();
            Gender gender = fakeDataProvider.PickRandomGender();
            // TODO: Setup Id provider that will generate unique number.
            // string id = Guid.NewGuid().ToString();
            Guid id = Guid.NewGuid();
            string firstName = fakeDataProvider.PickRandomFirstName(gender);
            string lastName = fakeDataProvider.PickRandomLastName(gender);
            string email = GetEmail(firstName, lastName);
            int userNumber = fakeDataProvider.PickRandomNumber(10000000, 99999999);
            person.Id = id;
            person.Email = email;
            person.Gender = gender;
            person.FirstName = firstName;
            person.LastName = lastName;

            return person;
        }

        Person Populate(Person person)
        {
            Gender gender = fakeDataProvider.PickRandomGender();
            // TODO: Setup Id provider that will generate unique number.
            // string id = Guid.NewGuid().ToString();
            Guid id = Guid.NewGuid();
            string firstName = fakeDataProvider.PickRandomFirstName(gender);
            string lastName = fakeDataProvider.PickRandomLastName(gender);
            string email = GetEmail(firstName, lastName);
            int userNumber = fakeDataProvider.PickRandomNumber(10000000, 99999999);
            person.Id = id;
            person.Email = email;
            person.Gender = gender;
            person.FirstName = firstName;
            person.LastName = lastName;

            return person;
        }

        string GetEmail(string firstName, string lastName) => $"{firstName}.{lastName}@school.com";
    }
}