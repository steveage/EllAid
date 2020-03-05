using System.Collections.Generic;
using EllAid.Entities.Data;
using System;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class ItemProvider : IItemProvider
    {

        readonly ITestProvider testProvider;
        readonly IDataFabricator fakeDataProvider;
        string[] malePictureUrls;
        string[] femalePictureUrls;
        string[] languages;
        List<Test> tests;

        public ItemProvider(ITestProvider testProvider, IDataFabricator fakeDataProvider)
        {
            this.testProvider = testProvider;
            this.fakeDataProvider = fakeDataProvider;
            malePictureUrls  = new[] {
                "https://randomuser.me/api/portraits/lego/0.jpg",
                "https://randomuser.me/api/portraits/lego/1.jpg",
                "https://randomuser.me/api/portraits/lego/2.jpg", 
                "https://randomuser.me/api/portraits/lego/3.jpg",
                "https://randomuser.me/api/portraits/lego/4.jpg",
                "https://randomuser.me/api/portraits/lego/5.jpg",
                "https://randomuser.me/api/portraits/lego/6.jpg",
                "https://randomuser.me/api/portraits/lego/7.jpg",
                "https://randomuser.me/api/portraits/lego/8.jpg",
                };
            femalePictureUrls = new[] {
                "https://randomuser.me/api/portraits/lego/9.jpg"};
            languages = new[] {"English", "Polish", "Portuguese", "German", "Spanish", "Mandarin", "Thai", "Hindi", "Vietnamese"};
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
                Id = 1,
                // Id = Guid.NewGuid().ToString(),
                //Type = "class",
                Name = className,
                Section = section,
                Grade = grade,
                Year = year.ToString(),
                Department = department,
                // Version = 1,
                Teachers = new List<string>(),
                Assistants = new List<string>(),
                EllCoaches = new List<string>(),
                Students = new List<string>()
            };

            return schoolClass;
        }

        public Student GetStudent()
        {
            Student student = GetUser<Student>("student");
            string language = fakeDataProvider.PickRandom(languages);
            string[] pictureUrls = student.Gender==Gender.Male? malePictureUrls: femalePictureUrls; 
            string pictureUrl = fakeDataProvider.PickRandom(pictureUrls);

            student.Email = Guid.NewGuid().ToString();
            student.DateOfBirth = fakeDataProvider.GetRandomPastDate(4, DateTime.UtcNow);
            student.EntryDate = new DateTime(DateTime.Now.Year, 1, 1).AddMonths(8);
            student.HomeLanguage = language;
            student.HomeCommunicationLanguage = language;
            student.PictureUrl = pictureUrl;
            student.Classes = new List<SchoolClass>();
            
            return student;
        }

        public Course GetStudentCourse(string userId, int classId, string teacherId, string score, bool isCurrent)
        {
            Course studentCourse = new Course()
            {
                // TODO: Setup Id provider that will generate unique number.
                Id =1,
                // Id = Guid.NewGuid().ToString(),
                Email =userId,
                //Type = "studentCourse",
                Class = classId,
                Teachers = new List<string>() { teacherId },
                IsCurrent = isCurrent,
                Score = score,
                // Version = 1
            };

            return studentCourse;
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

        public T GetUser<T>(string userType) where T : User, new()
        {
            Gender gender = fakeDataProvider.PickRandomGender();
            // TODO: Setup Id provider that will generate unique number.
            // string id = Guid.NewGuid().ToString();
            int id = 1;
            string firstName = fakeDataProvider.PickRandomFirstName(gender);
            string lastName = fakeDataProvider.PickRandomLastName(gender);
            string email = GetEmail(firstName, lastName);
            int userNumber = fakeDataProvider.PickRandomNumber(10000000, 99999999);

            T user = new T()
            {
                Id = id,
                Email = email,
                //Type = userType,
                FirstName = firstName,
                LastName = lastName,
                // Version = 1
            };

            return user;
        }

        private static string GetEmail(string firstName, string lastName) => $"{firstName}.{lastName}@school.com";

        public List<T> GetUsers<T>(string userType, int count) where T : User, new()
        {
            List<T> users = new List<T>();

            for (int i = 0; i < count; i++)
            {
                users.Add(GetUser<T>(userType));
            }

            return users;
        }

        public List<TestResult> GetWidaTestResults(DateTime resultDate, string term, int count)
        {
            List<TestResult> results = new List<TestResult>();

            for (int i = 0; i < count; i++)
            {
                results.Add(GetWidaTestResult(resultDate, term));
            }

            return results;
        }

        public TestResult GetWidaTestResult(DateTime resultDate, string term)
        {
            Test test = Tests.Find(t=>t.Name=="WIDA");
            TestResult result = new TestResult()
            {
                // TODO: Setup Id provider that will generate unique number.
                // Id = Guid.NewGuid().ToString(),
                Id = 1,
                TestId = test.Id,
                //Type = "testResult",
                Subject = test.Subject,
                Name = test.Name,
                Term = term,
                Date = resultDate,
                Sections = new TestSection[]
                {
                    GetWidaTestSection("Listening"),
                    GetWidaTestSection("Speaking"),
                    GetWidaTestSection("Reading"),
                    GetWidaTestSection("Writing-RAW"),
                    GetWidaTestSection("Writing-GRADE ADJ"),
                    GetWidaTestSection("Overall"),
                },
                // Version = 1
            };

            return result;
        }

        TestSection GetWidaTestSection(string area) => new TestSection
            {
                AreaName = area,
                Score = fakeDataProvider.PickRandomNumber(0, 30).ToString()
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
                Id = 1,
                TestId = testId,
                //Type = "testSession",
                Date = sessionDate,
                // Version = 1
            };
    }
}