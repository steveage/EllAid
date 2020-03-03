using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class ItemCreator : IItemCreator
    {
        readonly IItemProvider itemProvider;
        readonly IUserProvider<User> ellCoachProvider;
        readonly IItemAssigner itemAssigner;
        readonly ITestProvider testProvider;
        readonly ITestDataRepository repository;

        public ItemCreator(IItemProvider fakeGenerator, IUserProvider<User> ellCoachProvider, IItemAssigner itemAssigner, ITestProvider testProvider, ITestDataRepository repository)
        {
            this.itemProvider = fakeGenerator;
            this.ellCoachProvider = ellCoachProvider;
            this.ellCoachProvider.Initialize("ellCoach", 4);
            this.itemAssigner = itemAssigner;
            this.testProvider = testProvider;
            this.repository = repository;
        }

        public async Task CreateAsync()
        {
            int currentYear = DateTime.UtcNow.Year;
            //TODO:
            // Create teacher list
            // Create assistant list
            // Get teacher and assistants from list
            // Create
            await CreateClassSetForOneYearAsync("genEd", "K", currentYear, "EC");
        }

        async Task CreateClassSetForOneYearAsync(string className, string grade, int year, string department)
        {
            List<Task> tasks = new List<Task>();
            const int sectionsPerYear = 4;
            for (int i = 0; i < sectionsPerYear; i++)
            {
                tasks.Add(CreateClassSetAsync(className, grade, year, department, i+1));
            }
            await Task.WhenAll(tasks);
        }
        
        async Task CreateClassSetAsync(string className, string grade, int year, string department, int section)
        {
            SchoolClass schoolClass = itemProvider.GetClass(className, grade, year, department, section);
            User teacher = itemProvider.GetUser<User>("teacher");
            User ellCoach = ellCoachProvider.GetUser();
            const int assistantsPerClass = 2;
            List<User> assistants = itemProvider.GetUsers<User>("assistant", assistantsPerClass);
            const int studentsPerClass = 20;
            List<Student> students = itemProvider.GetStudents(studentsPerClass);
            List<Course> studentClasses = new List<Course>();
            const int sessionAndResultDaysGap = 15;
            DateTime testSessionDate = DateTime.UtcNow.AddDays(-sessionAndResultDaysGap);
            List<TestResult> widaFallTestResults = itemProvider.GetWidaTestResults(testSessionDate.AddDays(sessionAndResultDaysGap), "fall", studentsPerClass);
            List<TestSession> testSessions = itemProvider.GetTestSessions(widaFallTestResults[0].TestId, testSessionDate, studentsPerClass);
            itemAssigner.AssignUsersToClass(schoolClass, teacher, ellCoach, assistants);
            itemAssigner.AssignStudentsToClass(students, studentClasses, schoolClass, teacher);
            AssignStudentsToTestResults(students, schoolClass, widaFallTestResults, testSessions);

            // await SaveUserItemAsync(schoolClass);
            await SaveUserItemAsync(teacher);
            await SaveUserItemAsync(ellCoach);
            await SaveUserItemsAsync(assistants.ConvertAll(a => (User)a));
            await SaveUserItemsAsync(students.ConvertAll(s => (User)s));
            // await SaveUserItemsAsync(studentClasses.ConvertAll(s => (User)s));
            await SaveTestItemsAsync(testProvider.GetTests().ConvertAll(t => (TestBase)t));
            await SaveTestItemsAsync(widaFallTestResults.ConvertAll(t => (TestBase)t));
            await SaveTestItemsAsync(testSessions.ConvertAll(t => (TestBase)t));
        }

        void AssignStudentsToTestResults(List<Student> students, SchoolClass schoolClass, List<TestResult> widaFallTestResults, List<TestSession> testSessions)
        {
            int studentCount = students.Count;

            for (int i = 0; i < studentCount; i++)
            {
                itemAssigner.AssignStudentToTestResult(students[i], schoolClass, widaFallTestResults[i], testSessions[i]);
            }
        }

        async Task SaveUserItemAsync(User user)
        {
            await repository.CreateUserItemAsync(user);
        }

        async Task SaveTestItemsAsync(List<TestBase> tests)
        {
            await repository.CreateTestItemsAsync(tests);
        }

        async Task SaveUserItemsAsync(List<User> users)
        {
            await repository.CreateUserItemsAsync(users);
        }
    }
}