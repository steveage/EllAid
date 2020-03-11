using AutoMapper;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles;
using EllAid.TestDataGenerator.Infrastructure.Mapper;
using Xunit;
using System;
using EllAid.TestDataGenerator.Infrastructure;
using EllAid.TestDataGenerator.UseCases.Adapters.DataObjects;

namespace EllAid.TestDataGenerator.Tests.Infrastructure
{
    public class MappingProviderTests
    {
        const string testType = "testType";
        [Fact]
        public void Map_WhenMappingUser_SetsVersionNumber()
        {
            // Given, When
            PersonDto dto = GetMapped<PersonDto, Person>(new Person());

            // Then
            Assert.Equal(Globals.noSqlUserVersion, dto.Version);
        }

        MappingProvider GetProvider()
        {
            MapperConfiguration config = new MapperConfiguration(cfg=>
                {
                    // Add all profiles from the assembly
                    cfg.AddMaps(typeof(PersonProfile).Assembly);
                    // to allow mapping internal properties
                    cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                });
            Mapper mapper = new Mapper(config);
            return new MappingProvider(mapper);
        }

        T GetMapped<T, S>(S source) where T : EntityDto where S : Entity => GetProvider().Map<T, S>(source, testType);

        [Fact]
        public void Map_WhenMappingUser_SetsSameValues()
        {
            //Given
            Person user = new Person(){
                Id = 1,
                FirstName = "firstName",
                LastName = "lastName",
                Gender = Gender.Female
            };

            //When
            PersonDto dto = GetMapped<PersonDto, Person>(user);

            //Then
            Assert.Equal(user.Id, dto.Id);
            Assert.Equal(user.FirstName, dto.FirstName);
            Assert.Equal(user.LastName, dto.LastName);
            Assert.Equal(user.Gender, dto.Gender);
        }

        [Fact]
        public void Map_SetsType()
        {
            //Given, When
            PersonDto dto = GetMapped<PersonDto, Person>(new Person());

            //Then
            Assert.Equal(testType, dto.Type);
        }
        
        [Fact]
        public void Map_WhenMappingSchoolClass_SetsSameValues()
        {
            //Given
            MappingProvider provider = GetProvider();
            SchoolClass schoolClass = new SchoolClass(){
                Name = "className",
                Section = 1,
                Grade = "grade1",
                Year = "2000",
                Department = "department1"
            };

            //When
            SchoolClassDto dto = GetMapped<SchoolClassDto, SchoolClass>(schoolClass);

            //Then
            Assert.Equal(schoolClass.Name, dto.Name);
            Assert.Equal(schoolClass.Section, dto.Section);
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
            SchoolClassDto dto = GetMapped<SchoolClassDto, SchoolClass>(schoolClass);

            //Then
            Assert.Equal(Globals.noSqlSchoolClassVersion, dto.Version);
        }
            
        [Fact]
        public void Map_WhenMappingCourse_SetsSameValues()
        {
            //Given
            Course course = new Course(){
                Id = 1,
                Class = 2,
                IsCurrent = true,
                Score = "score1"
            };

            //When
            CourseDto dto = GetMapped<CourseDto, Course>(course);

            //Then
            Assert.Equal(course.Id, dto.Id);
            Assert.Equal(course.Class, dto.Class);
            Assert.Equal(course.IsCurrent, dto.IsCurrent);
            Assert.Equal(course.Score, dto.Score);
        }

        [Fact]
        public void Map_WhenMappingCourse_SetsVersion()
        {
            //Given
            Course course = new Course();

            //When
            CourseDto dto = GetMapped<CourseDto, Course>(course);
            
            //Then
            Assert.Equal(Globals.noSqlCourseVersion, dto.Version);
        }

        [Fact]
        public void Map_WhenMappingTestResult_SetsSameValues()
        {
            //Given
            TestResult<int> result = new TestResult<int>(){
                Id = 1,
                // TestId = 2,
                TestSessionId = 3,
                StudentId = "userId1",
                // Subject = "subject1",
                // Name = "name1",
                // Term = "term1",
                Date = new DateTime(),
                // Sections = new List<TestSection>{
                    // new TestSection(){
                        // AreaName = "area1",
                        // Score = "score1"
                    // }
                // }
            };

            //When
            TestResultDto<int> dto = GetMapped<TestResultDto<int>, TestResult<int>>(result);

            //Then
            Assert.Equal(result.Id, dto.Id);
            // Assert.Equal(result.TestId, dto.TestId);
            Assert.Equal(result.TestSessionId, dto.TestSessionId);
            // Assert.Equal(result.Subject, dto.Subject);
            // Assert.Equal(result.Name, dto.Name);
            // Assert.Equal(result.Term, dto.Term);
            Assert.Equal(result.Date, dto.Date);
            // Assert.Equal(result.Sections, dto.Sections);
        }

        [Fact]
        public void Map_WhenMappingTestResult_SetsVersion()
        {
            //Given, When
            TestResultDto<int> dto = GetMapped<TestResultDto<int>, TestResult<int>>(new TestResult<int>());

            //Then
            Assert.Equal(Globals.noSqlTestResultVersion, dto.Version);
        }

        [Fact]
        public void Map_WhenMappingTestSession_SetsSameValues()
        {
            //Given
            TestSession session = new TestSession(){
                Id = 1,
                // TestId = 2,
                // Teacher = "teacher1",
                // Grade = "grade1",
                // Year = 2000.ToString(),
                // Term = "term1",
                Date = new DateTime()
            };

            //When
            TestSessionDto dto = GetMapped<TestSessionDto, TestSession>(session);

            //Then
            Assert.Equal(session.Id, dto.Id);
            // Assert.Equal(session.TestId, dto.TestId);
            // Assert.Equal(session.Teacher, dto.Teacher);
            // Assert.Equal(session.Grade, dto.Grade);
            // Assert.Equal(session.Year, dto.Year);
            // Assert.Equal(session.Term, dto.Term);
            Assert.Equal(session.Date, dto.Date);
        }

        [Fact]
        public void Map_WhenMappingTestSession_SetsVersion()
        {
            //Given
            MappingProvider provider = GetProvider();
            TestSession session = new TestSession();

            //When
            TestSessionDto dto = GetMapped<TestSessionDto, TestSession>(new TestSession());

            //Then
            Assert.Equal(Globals.noSqlTestSessionVersion, dto.Version);
        }

        [Fact]
        public void Map_WhenMappingStudent_SetsSameValues()
        {
            //Given
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
            StudentDto dto = GetMapped<StudentDto, Student>(student);

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