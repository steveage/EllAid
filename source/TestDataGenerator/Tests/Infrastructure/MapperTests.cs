using AutoMapper;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.Mapper.DataObjects;
using EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles;
using EllAid.TestDataGenerator.Infrastructure.Mapper;
using Xunit;
using System.Collections.Generic;
using System;
using EllAid.TestDataGenerator.Infrastructure;

namespace EllAid.TestDataGenerator.Tests.Infrastructure
{
    public class MapperTests
    {
        [Fact]
        public void Map_WhenMappingUser_SetsVersionNumber()
        {
            // Given
            MappingProvider provider = GetProvider();
            User user = new User();

            // When
            UserDto dto = provider.Map<UserDto, User>(user);

            // Then
            Assert.Equal(Globals.noSqlUserVersion, dto.Version);
        }

        MappingProvider GetProvider()
        {
            MapperConfiguration config = new MapperConfiguration(cfg=>
                {
                    // Add all profiles from the assembly
                    cfg.AddMaps(typeof(UserProfile).Assembly);
                    // to allow mapping internal properties
                    cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                });
            Mapper mapper = new Mapper(config);
            return new MappingProvider(mapper);
        }

        [Fact]
        public void Map_WhenMappingUser_SetsSameValues()
        {
            //Given
            MappingProvider provider = GetProvider();
            User user = new User(){
                Id = 1,
                FirstName = "firstName",
                LastName = "lastName",
                Gender = Gender.Female
            };

            //When
            UserDto dto = provider.Map<UserDto, User>(user);

            //Then
            Assert.Equal(user.Id, dto.Id);
            Assert.Equal(user.FirstName, dto.FirstName);
            Assert.Equal(user.LastName, dto.LastName);
            Assert.Equal(user.Gender, dto.Gender);
        }

        [Fact]
        public void Map_WhenMappingUser_SetsType()
        {
            //Given
            MappingProvider provider = GetProvider();
            User user = new User();

            //When
            UserDto dto = provider.Map<UserDto, User>(user);

            //Then
            Assert.Equal("assistant", dto.Type);
        }
        
        [Fact]
        public void Map_WhenMappingSchoolClass_SetsSameValues()
        {
            //Given
            MappingProvider provider = GetProvider();
            SchoolClass schoolClass = new SchoolClass(){
                Name = "className",
                Section = 1,
                Teachers = new List<string>() {"teacher1"},
                Assistants = new List<string>(){"assistant1"},
                EllCoaches = new List<string>(){"ellCoach1"},
                Students = new List<string>(){"student1"},
                Grade = "grade1",
                Year = "2000",
                Department = "department1"
            };

            //When
            SchoolClassDto dto = provider.Map<SchoolClassDto, SchoolClass>(schoolClass);

            //Then
            Assert.Equal(schoolClass.Name, dto.Name);
            Assert.Equal(schoolClass.Section, dto.Section);
            Assert.Equal(schoolClass.Teachers, dto.Teachers);
            Assert.Equal(schoolClass.Assistants, dto.Assistants);
            Assert.Equal(schoolClass.EllCoaches, dto.EllCoaches);
            Assert.Equal(schoolClass.Students, dto.Students);
            Assert.Equal(schoolClass.Grade, dto.Grade);
            Assert.Equal(schoolClass.Year, dto.Year);
            Assert.Equal(schoolClass.Department, dto.Department);
        }

        [Fact]
        public void Map_WhenMappingSchoolClass_SetsVersion()
        {
            //Given
            MappingProvider provider = GetProvider();
            SchoolClass schoolClass = new SchoolClass();

            //When
            SchoolClassDto dto = provider.Map<SchoolClassDto, SchoolClass>(schoolClass);

            //Then
            Assert.Equal(Globals.noSqlSchoolClassVersion, dto.Version);
        }

        [Fact]
        public void Map_WhenMappingSchoolClass_SetsType()
        {
            //Given
            MappingProvider provider = GetProvider();
            SchoolClass schoolClass = new SchoolClass();

            //When
            SchoolClassDto dto = provider.Map<SchoolClassDto, SchoolClass>(schoolClass);

            //Then
            Assert.Equal(Globals.noSqlSchoolClassType, dto.Type);
        }
            
        [Fact]
        public void Map_WhenMappingCourse_SetsSameValues()
        {
            //Given
            MappingProvider provider = GetProvider();
            Course course = new Course(){
                Id = 1,
                Class = 2,
                Teachers = new List<string>() {"teacher1"},
                IsCurrent = true,
                Score = "score1"
            };

            //When
            CourseDto dto = provider.Map<CourseDto, Course>(course);

            //Then
            Assert.Equal(course.Id, dto.Id);
            Assert.Equal(course.Class, dto.Class);
            Assert.Equal(course.Teachers, dto.Teachers);
            Assert.Equal(course.IsCurrent, dto.IsCurrent);
            Assert.Equal(course.Score, dto.Score);
        }

        [Fact]
        public void Map_WhenMappingCourse_SetsVersion()
        {
            //Given
            MappingProvider provider = GetProvider();
            Course course = new Course();

            //When
            CourseDto dto = provider.Map<CourseDto, Course>(course);
            
            //Then
            Assert.Equal(Globals.noSqlCourseVersion, dto.Version);
        }

        [Fact]
        public void Map_WhenMappingCourse_SetsType()
        {
            //Given
            MappingProvider provider = GetProvider();
            Course course = new Course();

            //When
            CourseDto dto = provider.Map<CourseDto, Course>(course);
            
            //Then
            Assert.Equal(Globals.noSqlCourseType, dto.Type);
        }

        [Fact]
        public void Map_WhenMappingTestResult_SetsSameValues()
        {
            //Given
            MappingProvider provider = GetProvider();
            TestResult result = new TestResult(){
                Id = 1,
                TestId = 2,
                TestSessionId = 3,
                UserId = "userId1",
                Subject = "subject1",
                Name = "name1",
                Term = "term1",
                Date = new DateTime(),
                Sections = new TestSection[]{
                    new TestSection(){
                        AreaName = "area1",
                        Score = "score1"
                    }
                }
            };

            //When
            TestResultDto dto = provider.Map<TestResultDto, TestResult>(result);

            //Then
            Assert.Equal(result.Id, dto.Id);
            Assert.Equal(result.TestId, dto.TestId);
            Assert.Equal(result.TestSessionId, dto.TestSessionId);
            Assert.Equal(result.Subject, dto.Subject);
            Assert.Equal(result.Name, dto.Name);
            Assert.Equal(result.Term, dto.Term);
            Assert.Equal(result.Date, dto.Date);
            Assert.Equal(result.Sections, dto.Sections);
        }

        [Fact]
        public void Map_WhenMappingTestResult_SetsVersion()
        {
            //Given
            MappingProvider provider = GetProvider();
            TestResult result = new TestResult();

            //When
            TestResultDto dto = provider.Map<TestResultDto, TestResult>(result);

            //Then
            Assert.Equal(Globals.noSqlTestResultVersion, dto.Version);
        }

        [Fact]
        public void Map_WhenMappingTestResult_SetsType()
        {
            //Given
            MappingProvider provider = GetProvider();
            TestResult result = new TestResult();

            //When
            TestResultDto dto = provider.Map<TestResultDto, TestResult>(result);

            //Then
            Assert.Equal(Globals.noSqlTestResultType, dto.Type);
        }

        [Fact]
        public void Map_WhenMappingTestSession_SetsSameValues()
        {
            //Given
            MappingProvider provider = GetProvider();
            TestSession session = new TestSession(){
                Id = 1,
                TestId = 2,
                Teacher = "teacher1",
                Grade = "grade1",
                Year = 2000.ToString(),
                Term = "term1",
                Date = new DateTime()
            };

            //When
            TestSessionDto dto = provider.Map<TestSessionDto, TestSession>(session);

            //Then
            Assert.Equal(session.Id, dto.Id);
            Assert.Equal(session.TestId, dto.TestId);
            Assert.Equal(session.Teacher, dto.Teacher);
            Assert.Equal(session.Grade, dto.Grade);
            Assert.Equal(session.Year, dto.Year);
            Assert.Equal(session.Term, dto.Term);
            Assert.Equal(session.Date, dto.Date);
        }

        [Fact]
        public void Map_WhenMappingTestSession_SetsVersion()
        {
            //Given
            MappingProvider provider = GetProvider();
            TestSession session = new TestSession();

            //When
            TestSessionDto dto = provider.Map<TestSessionDto, TestSession>(session);

            //Then
            Assert.Equal(Globals.noSqlTestSessionVersion, dto.Version);
        }

        [Fact]
        public void Map_WhenMappingTestSession_SetsType()
        {
            //Given
            MappingProvider provider = GetProvider();
            TestSession session = new TestSession();

            //When
            TestSessionDto dto = provider.Map<TestSessionDto, TestSession>(session);

            //Then
            Assert.Equal(Globals.noSqlTestSessionType, dto.Type);
        }

        [Fact]
        public void Map_WhenMappingStudent_SetsSameValues()
        {
            //Given
            MappingProvider provider = GetProvider();
            Student student = new Student(){
                Id = 1,
                FirstName = "firstName1",
                LastName = "lastName1",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(),
                EntryDate = new DateTime(),
                HomeLanguage = "homeLanguage1",
                HomeCommunicationLanguage = "communicationLanguage1",
                PictureUrl = "url1"
            };

            //When
            StudentDto dto = provider.Map<StudentDto, Student>(student);

            //Then
            Assert.Equal(student.Id, dto.Id);
            Assert.Equal(student.FirstName, dto.FirstName);
            Assert.Equal(student.LastName, dto.LastName);
            Assert.Equal(student.Gender, dto.Gender);
            // TODO: Add dedicated test to compare each element in both collections.
            // Assert.Equal(student.Classes, dto.Classes);
            Assert.Equal(student.DateOfBirth, dto.DateOfBirth);
            Assert.Equal(student.EntryDate, dto.EntryDate);
            Assert.Equal(student.HomeLanguage, dto.HomeLanguage);
            Assert.Equal(student.HomeCommunicationLanguage, dto.HomeCommunicationLanguage);
            Assert.Equal(student.PictureUrl, dto.PictureUrl);
        }

        ///TODO: test if userId is set to id of entity.
    }
}