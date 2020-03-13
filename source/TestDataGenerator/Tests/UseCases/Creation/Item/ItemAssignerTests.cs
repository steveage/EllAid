using System;
using System.Collections.Generic;
using System.Linq;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.TestData;
using EllAid.TestDataGenerator.UseCases.Creation.Item;
using Xunit;

namespace EllAid.TestDataGenerator.Tests.UseCases.Creation.Item
{
    public class ItemAssignerTests
    {
        [Fact]
        public void AssignStudentsToClass_AddsClassToStudent()
        {
            //Arrange
            const int numberOfStudents = 10;
            ItemProvider provider = new ItemProvider(new TestProvider(), new BogusFabricator(), new InMemoryUserDataProvider());
            ItemAssigner assigner = new ItemAssigner(provider);
            List<Student> students = provider.GetStudents(numberOfStudents);
            List<Course> studentClasses = new List<Course>();
            SchoolClass schoolClass = provider.GetClass(string.Empty, string.Empty, 0, string.Empty, 0);
            Person teacher = provider.GetUser<Person>();

            //Act
            assigner.AssignStudentsToClass(students, studentClasses, schoolClass, teacher);
            // List<string> classes = students.Select(s => s.Classes[0]).ToList();
            // List<SchoolClass> classes = students[0].Classes;
            // List<SchoolClass> matchedClasses = classes.FindAll(s => s.Email==schoolClass.Email);
            // int numberOfMatchedClasses = matchedClasses.Count;

            //Assert
            // Assert.Equal(numberOfStudents, classes.Count);
            // Assert.Equal(numberOfStudents, numberOfMatchedClasses);
        }

        [Fact]
        public void AssignStudentToClass_CreatesStudentClass()
        {
            //Arrange
            const int numberOfStudents = 10;
            ItemProvider provider = new ItemProvider(new TestProvider(), new BogusFabricator(), new InMemoryUserDataProvider());
            ItemAssigner assigner = new ItemAssigner(provider);
            List<Student> students = provider.GetStudents(numberOfStudents);
            List<Course> studentClasses = new List<Course>();
            SchoolClass schoolClass = provider.GetClass(string.Empty, string.Empty, 0, string.Empty, 0);
            Person teacher = provider.GetUser<Person>();

            //Act
            assigner.AssignStudentsToClass(students, studentClasses, schoolClass, teacher);
            List<string> studentIdsFromStudent = students.Select(s=>s.Email).ToList();
            // List<string> studentIdsFromStudentClass = studentClasses.Select(s=>s.Email).ToList();
            // List<Guid> classIdsFromStudentClass = studentClasses.Select(s=>s.Class).ToList();
            // int numberOfMatchedClasses = studentClasses.FindAll(s=>s.Class==schoolClass.Id).Count;
            // List<string> teachersFromStudentClasses = studentClasses.SelectMany(s=>s.Teachers).ToList();
            // int numberOfMatchedTeachers = teachersFromStudentClasses.FindAll(s=>s==teacher.Email).Count;

            //Assert
            Assert.Equal(numberOfStudents, studentClasses.Count);
            // Assert.Equal(studentIdsFromStudent, studentIdsFromStudentClass);
            // Assert.Equal(numberOfStudents, numberOfMatchedClasses);
            // Assert.Equal(numberOfStudents, numberOfMatchedTeachers);
        }

        [Fact]
        public void AssignStudentToClass_AddsStudentsToClass()
        {
            //Arrange
            const int numberOfStudents = 10;
            ItemProvider provider = new ItemProvider(new TestProvider(), new BogusFabricator(), new InMemoryUserDataProvider());
            ItemAssigner assigner = new ItemAssigner(provider);
            List<Student> students = provider.GetStudents(numberOfStudents);
            List<Course> studentClasses = new List<Course>();
            SchoolClass schoolClass = provider.GetClass(string.Empty, string.Empty, 0, string.Empty, 0);
            Person teacher = provider.GetUser<Person>();

            //Act
            assigner.AssignStudentsToClass(students, studentClasses, schoolClass, teacher);
            // List<string> studentIdsFromStudentClasses = studentClasses.Select(s=>s.Email).ToList();
            List<string> studentIds = students.Select(s=>s.Email).ToList();

            //Assert
            // Assert.Equal(studentIds, studentIdsFromStudentClasses);
        }

        [Fact]
        public void AssignUsersToClass_AddsTeacher()
        {
            //Arrange
            ItemProvider provider = new ItemProvider(new TestProvider(), new BogusFabricator(), new InMemoryUserDataProvider()); 
            SchoolClass schoolClass = provider.GetClass(string.Empty, string.Empty, 0, string.Empty, 0);
            Person teacher = provider.GetUser<Person>();
            Person ellCoach = provider.GetUser<Person>();
            List<Person> assistants = provider.GetUsers<Person>(2);
            ItemAssigner assigner = new ItemAssigner(provider);

            //Act
            assigner.AssignUsersToClass(schoolClass, teacher, ellCoach, assistants);
            // int matchedTeacherIds =schoolClass.Teachers.FindAll(s=>s==teacher.Email).Count;

            //Assert
            // Assert.Equal(teacher.Email, schoolClass.Email);
            // Assert.Equal(1, matchedTeacherIds);
        }

        [Fact]
        public void AssignUsersToClass_AddsAssistants()
        {
            //Arrange
            ItemProvider provider = new ItemProvider(new TestProvider(), new BogusFabricator(), new InMemoryUserDataProvider()); 
            SchoolClass schoolClass = provider.GetClass(string.Empty, string.Empty, 0, string.Empty, 0);
            Person teacher = provider.GetUser<Person>();
            Person ellCoach = provider.GetUser<Person>();
            const int numberOfAssistants = 2;
            List<Person> assistants = provider.GetUsers<Person>(numberOfAssistants);
            ItemAssigner assigner = new ItemAssigner(provider);

            //Act
            assigner.AssignUsersToClass(schoolClass, teacher, ellCoach, assistants);
            List<string> assistantIds = assistants.Select(a=>a.Email).ToList();
            // List<SchoolClass> classesFromAssistants = assistants.SelectMany(a=>a.Classes).ToList();
            // int matchedClasses = classesFromAssistants.FindAll(c=>c.Email==teacher.Email).Count;

            //Assert
            // Assert.Equal(assistantIds, schoolClass.Assistants);
            // Assert.Equal(numberOfAssistants, matchedClasses);
        }

        [Fact]
        public void AssignUsersToClass_AddsEllCoaches()
        {
            //Arrange
            ItemProvider provider = new ItemProvider(new TestProvider(), new BogusFabricator(), new InMemoryUserDataProvider()); 
            SchoolClass schoolClass = provider.GetClass(string.Empty, string.Empty, 0, string.Empty, 0);
            Person teacher = provider.GetUser<Person>();
            Person ellCoach = provider.GetUser<Person>();
            List<Person> assistants = provider.GetUsers<Person>(2);
            ItemAssigner assigner = new ItemAssigner(provider);

            //Act
            assigner.AssignUsersToClass(schoolClass, teacher, ellCoach, assistants);

            //Assert
            // Assert.Equal(ellCoach.Email, schoolClass.EllCoaches[0]);
            // Assert.Equal(teacher.Email, ellCoach.Classes[0].Email);
        }
        
        [Fact]
        public void AssignStudentToTestResult_AddsTestSessionToTestResult()
        {
            //Arrange
            TestSession session = new TestSession()
            {
                Id = Guid.NewGuid()
            };
            TestResult<int> result = new TestResult<int>();
            Student student = new Student();
            SchoolClass schoolClass = new SchoolClass();
            ItemAssigner assigner = new ItemAssigner(new ItemProvider(new TestProvider(), new BogusFabricator(), new InMemoryUserDataProvider()));

            //Act
            assigner.AssignStudentToTestResult(student, schoolClass, result, session);
            //Assert
            Assert.NotEqual(Guid.Empty, result.TestSessionId);
            Assert.Equal(session.Id, result.TestSessionId);
        }

        [Fact]
        public void AssignStudentToTestResult_AddsStudentToTestResult()
        {
            //Arrange
            TestSession session = new TestSession();
            TestResult<int> result = new TestResult<int>();
            Student student = new Student()
            {
                Email = Guid.NewGuid().ToString()
            };
            SchoolClass schoolClass = new SchoolClass();
            ItemAssigner assigner = new ItemAssigner(new ItemProvider(new TestProvider(), new BogusFabricator(), new InMemoryUserDataProvider()));

            //Act
            assigner.AssignStudentToTestResult(student, schoolClass, result, session);
            //Assert
            Assert.NotNull(result.StudentId);
            Assert.Equal(student.Id, result.StudentId);
        }

        [Fact]
        public void AssignStudentToTestResult_AddsClassToTestSession()
        {
            //Given
            TestSession session = new TestSession();
            TestResult<int> result = new TestResult<int>()
            {
                // Term = "beginning"
            };
            Student student = new Student();
            SchoolClass schoolClass = new SchoolClass()
            {
                // Grade = "PK",
                // Email = "test.teacher@school.com",
                // Year = DateTime.UtcNow.Year.ToString()
            };
            ItemAssigner assigner = new ItemAssigner(new ItemProvider(new TestProvider(), new BogusFabricator(), new InMemoryUserDataProvider()));

            //When
            assigner.AssignStudentToTestResult(student, schoolClass, result, session);
            //Then
            // Assert.NotNull(session.Term);
            // Assert.NotNull(session.Grade);
            // Assert.NotNull(session.Teacher);
            // Assert.NotNull(session.Year);
            // Assert.Equal(result.Term, session.Term);
            // Assert.Equal(schoolClass.Email, session.Teacher);
            // Assert.Equal(schoolClass.Grade, session.Grade);
            // Assert.Equal(schoolClass.Year, session.Year);
        }
    }
}