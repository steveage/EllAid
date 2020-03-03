using System;
using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class UserCreator : IUserCreator
    {
        readonly IFakeData fakeDataProvider;
        readonly string[] malePictureUrls;
        readonly string[] femalePictureUrls;
        readonly string[] languages;

        public UserCreator(IFakeData fakeDataProvider, IUserDataAccess userData)
        {
            this.fakeDataProvider = fakeDataProvider;
            malePictureUrls = userData.GetMalePictures();
            femalePictureUrls = userData.GetFemalePictures();
            languages = userData.GetLanguages();
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
            Student student = GetUser<Student>("student");
            string language = fakeDataProvider.PickRandom(languages);
            string[] pictureUrls = student.Gender==Gender.Male? malePictureUrls: femalePictureUrls; 
            string pictureUrl = fakeDataProvider.PickRandom(pictureUrls);
            const int yearsToGoBack = 1;
            DateTime birthYearDate = new DateTime(birthYear, 1, 1);
            DateTime birthDate = fakeDataProvider.GetRandomPastDate(yearsToGoBack, birthYearDate);
            int enrollmentYear = birthYear + 4;
            DateTime enrollmentDate = new DateTime(enrollmentYear, 1, 1).AddMonths(8);

            student.Email = GetEmail(student.FirstName, student.LastName);
            student.DateOfBirth = birthDate;
            student.EntryDate = enrollmentDate;
            student.HomeLanguage = language;
            student.HomeCommunicationLanguage = language;
            student.PictureUrl = pictureUrl;
            student.Classes = new List<SchoolClass>();
            
            return student;
        }

        public List<T> CreateUsers<T>(string userType, int count) where T : User, new()
        {
            List<T> users = new List<T>();

            for (int i = 0; i < count; i++)
            {
                users.Add(GetUser<T>(userType));
            }

            return users;
        }
        
        T GetUser<T>(string userType) where T : User, new()
        {
            Gender gender = fakeDataProvider.PickRandomGender();
            // TODO: Setup Id provider that will generate unique number.
            // string id = Guid.NewGuid().ToString();
            int id = 1;
            string firstName = fakeDataProvider.PickRandomFirstName(gender);
            string lastName = fakeDataProvider.PickRandomLastName(gender);
            string userId = GetEmail(firstName, lastName);
            int userNumber = fakeDataProvider.PickRandomNumber(10000000, 99999999);

            T user = new T()
            {
                Id = id,
                Email = userId,
                //Type = userType,
                FirstName = firstName,
                LastName = lastName,
                // Version = 1
            };

            return user;
        }

        string GetEmail(string firstName, string lastName) => $"{firstName}.{lastName}@school.com";
    }
}