using System.Collections.Generic;
using EllAid.Entities.Data;
using System;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class ItemProvider : IItemProvider
    {

        readonly ITestProvider testProvider;
        readonly IDataFabricator fakeDataProvider;
        List<string> malePictureUrls;
        List<string> femalePictureUrls;
        List<string> languages;
        List<Test> tests;

        public ItemProvider(ITestProvider testProvider, IDataFabricator fakeDataProvider, IUserDataAccess userData)
        {
            this.testProvider = testProvider;
            this.fakeDataProvider = fakeDataProvider;
            malePictureUrls  = userData.GetMalePictures();
            femalePictureUrls = userData.GetFemalePictures();
            languages = userData.GetLanguages();
        }

        List<Test> Tests
        {
            get
            {
                if(tests==null)
                {
                    tests = testProvider.GetTests();
                }

                return tests;
            }
        }

        public SchoolClass GetClass(string className, string grade, int year, string department, int section)
        {
            SchoolClass schoolClass = new SchoolClass()
            {
                // TODO: Setup Id provider that will generate unique number.
                Id = Guid.NewGuid(),
                // Id = Guid.NewGuid().ToString(),
                //Type = "class",
                // Name = className,
                // Section = section,
                // Grade = grade,
                // Year = year.ToString(),
                // Department = department,
                // Version = 1,
                // Teachers = new List<string>(),
                // Assistants = new List<string>(),
                // EllCoaches = new List<string>(),
                // Students = new List<string>()
            };

            return schoolClass;
        }

        public Student GetStudent()
        {
            Student student = GetUser<Student>();
            string language = fakeDataProvider.PickRandom(languages);
            List<string> pictureUrls = student.Gender==Gender.Male? malePictureUrls: femalePictureUrls; 
            string pictureUrl = fakeDataProvider.PickRandom(pictureUrls);

            student.Email = Guid.NewGuid().ToString();
            student.DateOfBirth = fakeDataProvider.GetRandomPastDate(4, DateTime.UtcNow);
            student.EntryDate = new DateTime(DateTime.Now.Year, 1, 1).AddMonths(8);
            student.HomeLanguage = language;
            student.HomeCommunicationLanguage = language;
            student.PictureUrl = pictureUrl;
            
            return student;
        }

        public Course GetStudentCourse(Guid userId, Guid classId, Guid teacherId, string score, bool isCurrent)
        {
            // Course studentCourse = new Course()
            // {
            //     // TODO: Setup Id provider that will generate unique number.
            //     Id =Guid.NewGuid(),
            //     // Id = Guid.NewGuid().ToString(),
            //     // Email = userId,
            //     //Type = "studentCourse",
            //     // Class = classId,
            //     // Teachers = new List<string>() { teacherId },
            //     // IsCurrent = isCurrent,
            //     // Score = score,
            //     // Version = 1
            // };

            // return studentCourse;
            return null;
        }

        public List<Student> GetStudents(int count)
        {
            List<Student> students = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                students.Add(GetStudent());
            }

            return students;
        }

        public T GetUser<T>() where T : Person, new()
        {
            Gender gender = fakeDataProvider.PickRandomGender();
            // TODO: Setup Id provider that will generate unique number.
            // string id = Guid.NewGuid().ToString();
            Guid id = Guid.NewGuid();
            string firstName = fakeDataProvider.PickRandomFirstName(gender);
            string lastName = fakeDataProvider.PickRandomLastName(gender);
            string email = GetEmail(firstName, lastName);
            int userNumber = fakeDataProvider.PickRandomNumber(10000000, 99999999);

            T user = new T()
            {
                Id = id,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
            };

            return user;
        }

        private static string GetEmail(string firstName, string lastName) => $"{firstName}.{lastName}@school.com";

        public List<T> GetUsers<T>(int count) where T : Person, new()
        {
            List<T> users = new List<T>();

            for (int i = 0; i < count; i++)
            {
                users.Add(GetUser<T>());
            }

            return users;
        }

        public List<TestResult<T>> GetWidaTestResults<T>(DateTime resultDate, string term, int count)
        {
            List<TestResult<T>> results = new List<TestResult<T>>();

            for (int i = 0; i < count; i++)
            {
                results.Add(GetWidaTestResult<T>(resultDate, term));
            }

            return results;
        }

        public TestResult<T> GetWidaTestResult<T>(DateTime resultDate, string term)
        {
            Test test = Tests.Find(t=>t.Name=="WIDA");
            TestResult<T> result = new TestResult<T>()
            {
                // TODO: Setup Id provider that will generate unique number.
                // Id = Guid.NewGuid().ToString(),
                Id = Guid.NewGuid(),
                // TestId = test.Id,
                //Type = "testResult",
                // Subject = test.Subject,
                // Name = test.Name,
                // Term = term,
                Date = resultDate,
                // Sections = new List<TestSection>
                // {
                //     GetWidaTestSection("Listening"),
                //     GetWidaTestSection("Speaking"),
                //     GetWidaTestSection("Reading"),
                //     GetWidaTestSection("Writing-RAW"),
                //     GetWidaTestSection("Writing-GRADE ADJ"),
                //     GetWidaTestSection("Overall"),
                // },
                // Version = 1
            };

            return result;
        }

        TestSection GetWidaTestSection(string area) => new TestSection
            {
                // AreaName = area,
                // Score = fakeDataProvider.PickRandomNumber(0, 30).ToString()
            };

        public List<TestSession> GetTestSessions(int testId, DateTime sessionDate, int count)
        {
            List<TestSession> sessions = new List<TestSession>();

            for (int i = 0; i < count; i++)
            {
                sessions.Add(GetTestSession(testId, sessionDate));
            }

            return sessions;
        }

        TestSession GetTestSession(int testId, DateTime sessionDate) =>
            new TestSession()
            {
                // TODO: Setup Id provider that will generate unique number.
                // Id = Guid.NewGuid().ToString(),
                Id = Guid.NewGuid(),
                // TestId = testId,
                //Type = "testSession",
                Date = sessionDate,
                // Version = 1
            };
    }
}