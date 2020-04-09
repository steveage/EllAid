using AutoMapper;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles;
using EllAid.TestDataGenerator.Infrastructure.Mapper;
using Xunit;
using System;
using EllAid.DataSource.Adapters.DataObjects;
using EllAid.TestDataGenerator.Infrastructure.DataAccess;

namespace EllAid.TestDataGenerator.Tests.Infrastructure
{
    public class MappingProviderTests
    {
        [Fact]
        public void Map_WhenMappingUser_SetsVersionNumber()
        {
            // Given, When
            PersonDto dto = GetMapped<PersonDto, Person>(new Person());

            // Then
            Assert.Equal(DataAccessConstants.noSqlPersonVersion, dto.Version);
        }

        internal static MappingProvider GetProvider()
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

        T GetMapped<T, S>(S source) where T : EntityDto where S : Entity => GetProvider().Map<T, S>(source);

        [Fact]
        public void Map_WhenMappingUser_SetsSameValues()
        {
            //Given
            Person user = new Person(){
                Id = Guid.NewGuid(),
                FirstName = "firstName",
                LastName = "lastName",
                Gender = Gender.Female
            };

            //When
            PersonDto dto = GetMapped<PersonDto, Person>(user);

            //Then
            Assert.Equal(user.Id.ToString(), dto.Id);
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
            Assert.Equal(DataAccessConstants.noSqlPersonType, dto.Type);
        }
        
        [Fact]
        public void Map_WhenMappingSchoolClass_SetsSameValues()
        {
            //Given
            MappingProvider provider = GetProvider();
            SchoolClass schoolClass = new SchoolClass(){
                // Name = "className",
                // Section = 1,
                // Grade = "grade1",
                // Year = "2000",
                // Department = "department1"
            };

            //When
            SchoolClassDto dto = GetMapped<SchoolClassDto, SchoolClass>(schoolClass);

            //Then
            // Assert.Equal(schoolClass.Name, dto.Name);
            // Assert.Equal(schoolClass.Section, dto.Section);
            // Assert.Equal(schoolClass.Grade, dto.Grade);
            // Assert.Equal(schoolClass.Year, dto.Year);
            // Assert.Equal(schoolClass.Department, dto.Department);
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
            Assert.Equal(DataAccessConstants.noSqlSchoolClassVersion, dto.Version);
        }
            
        [Fact]
        public void Map_WhenMappingCourse_SetsSameValues()
        {
            //Given
            Course course = new Course(){
                Id = Guid.NewGuid(),
                Name = "testName",
                Department = Department.EarlyChildhood,
            };

            //When
            CourseDto dto = GetMapped<CourseDto, Course>(course);

            //Then
            Assert.Equal(course.Id.ToString(), dto.Id);
            // Assert.Equal(course.Class.ToString(), dto.Class);
            // Assert.Equal(course.IsCurrent, dto.IsCurrent);
            // Assert.Equal(course.Score, dto.Score);
        }

        [Fact]
        public void Map_WhenMappingCourse_SetsVersion()
        {
            //Given
            Course course = new Course();

            //When
            CourseDto dto = GetMapped<CourseDto, Course>(course);
            
            //Then
            Assert.Equal(DataAccessConstants.noSqlCourseVersion, dto.Version);
        }

        [Fact]
        public void Map_WhenMappingTestResult_SetsSameValues()
        {
        //     //Given
        //     TestResult<int> result = new TestResult<int>(){
        //         Id = Guid.NewGuid(),
        //         // TestId = 2,
        //         TestSessionId = Guid.NewGuid(),
        //         StudentId = Guid.NewGuid(),
        //         // Subject = "subject1",
        //         // Name = "name1",
        //         // Term = "term1",
        //         Date = new DateTime(),
        //         // Sections = new List<TestSection>{
        //             // new TestSection(){
        //                 // AreaName = "area1",
        //                 // Score = "score1"
        //             // }
        //         // }
        //     };

        //     //When
        //     TestResultDto<int> dto = GetMapped<TestResultDto<int>, TestResult<int>>(result);

        //     //Then
        //     Assert.Equal(result.Id.ToString(), dto.Id);
        //     // Assert.Equal(result.TestId, dto.TestId);
        //     Assert.Equal(result.TestSessionId.ToString(), dto.TestSessionId);
        //     // Assert.Equal(result.Subject, dto.Subject);
        //     // Assert.Equal(result.Name, dto.Name);
        //     // Assert.Equal(result.Term, dto.Term);
        //     Assert.Equal(result.Date, dto.Date);
        //     // Assert.Equal(result.Sections, dto.Sections);
        }

        [Fact]
        public void Map_WhenMappingTestResult_SetsVersion()
        {
            //Given, When
            // TestResultDto<int> dto = GetMapped<TestResultDto<int>, TestResult<int>>(new TestResult<int>());

            // //Then
            // Assert.Equal(Globals.noSqlTestResultVersion, dto.Version);
        }

        [Fact]
        public void Map_WhenMappingTestSession_SetsSameValues()
        {
            //Given
            TestSession session = new TestSession(){
                Id = Guid.NewGuid(),
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
            Assert.Equal(session.Id.ToString(), dto.Id);
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
            Assert.Equal(DataAccessConstants.noSqlTestSessionVersion, dto.Version);
        }

        [Fact]
        public void Map_WhenMappingStudent_SetsSameValues()
        {
            //Given
            Student student = new Student(){
                Id = Guid.NewGuid(),
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
            Assert.Equal(student.Id.ToString(), dto.Id);
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

        [Fact]
        public void Map_MapsAssistant()
        {
            //Given
            Instructor instructor = new Instructor()
            {
                FirstName = "instructorFirst",
                LastName = "instructorLast",
                Gender = Gender.Male,
                Email = "instructor@school.com",
                Department = Department.EarlyChildhood
            };
            Assistant assistant = new Assistant()
            {
                FirstName = "firstName1",
                LastName = "lastName1",
                Gender = Gender.Female,
                Email = "test@email.com",
                Instructor = instructor
            };
            //When
            AssistantDto dto = GetMapped<AssistantDto, Assistant>(assistant);
            //Then
            Assert.Equal(assistant.Id.ToString(), dto.Id);
            Assert.Equal(assistant.FirstName, dto.FirstName);
            Assert.Equal(assistant.LastName, dto.LastName);
            Assert.Equal(assistant.Gender, dto.Gender);
            Assert.Equal(DataAccessConstants.noSqlAssistantType, dto.Type);
            Assert.Equal(DataAccessConstants.noSqlAssistantVersion, dto.Version);
            Assert.Equal(assistant.Instructor.Id.ToString(), dto.Instructor.Id);
            Assert.Equal(assistant.Instructor.FirstName, dto.Instructor.FirstName);
            Assert.Equal(assistant.Instructor.LastName, dto.Instructor.LastName);
            Assert.Equal(assistant.Instructor.Gender, dto.Instructor.Gender);
            Assert.Equal(assistant.Instructor.Email, dto.Instructor.Email);
            Assert.Equal(assistant.Instructor.Department, dto.Instructor.Department);
            Assert.Equal(DataAccessConstants.noSqlInstructorShortType, dto.Instructor.Type);
            Assert.Equal(DataAccessConstants.noSqlInstructorShortVersion, dto.Instructor.Version);
        }

        [Fact]
        public void Map_MapsEllCoach()
        {
            //Given
            Instructor instructor1 = new Instructor()
            {
                FirstName = "instructor1First",
                LastName = "instructor1Last",
                Gender = Gender.Male,
                Email = "instructor1@school.com"
            };
            Instructor instructor2 = new Instructor()
            {
                FirstName = "instructor2First",
                LastName = "instructor2Last",
                Gender = Gender.Male,
                Email = "instructor2@school.com"
            };
            EllCoach coach = new EllCoach()
            {
                FirstName = "coachFirst",
                LastName = "coachLast",
                Gender = Gender.Male,
                Email = "coach@school.com"
            };
            coach.Instructors.Add(instructor1);
            coach.Instructors.Add(instructor2);
            //When
            EllCoachDto dto = GetMapped<EllCoachDto, EllCoach>(coach);
            //Then
            Assert.Equal(coach.Id.ToString(), dto.Id);
            Assert.Equal(coach.FirstName, dto.FirstName);
            Assert.Equal(coach.LastName, dto.LastName);
            Assert.Equal(coach.Email, dto.Email);
            Assert.Equal(coach.Gender, dto.Gender);
            Assert.Equal(DataAccessConstants.noSqlEllCoachType, dto.Type);
            Assert.Equal(DataAccessConstants.noSqlEllCoachVersion, dto.Version);
            Assert.Equal(2, dto.Instructors.Count);
            Assert.Equal(instructor1.Id.ToString(), dto.Instructors[0].Id);
            Assert.Equal(instructor1.FirstName, dto.Instructors[0].FirstName);
            Assert.Equal(instructor1.LastName, dto.Instructors[0].LastName);
            Assert.Equal(instructor1.Email, dto.Instructors[0].Email);
            Assert.Equal(instructor1.Gender, dto.Instructors[0].Gender);
            Assert.Equal(instructor1.Department, dto.Instructors[0].Department);
            Assert.Equal(instructor2.Id.ToString(), dto.Instructors[1].Id);
            Assert.Equal(instructor2.FirstName, dto.Instructors[1].FirstName);
            Assert.Equal(instructor2.LastName, dto.Instructors[1].LastName);
            Assert.Equal(instructor2.Email, dto.Instructors[1].Email);
            Assert.Equal(instructor2.Gender, dto.Instructors[1].Gender);
            Assert.Equal(instructor2.Department, dto.Instructors[1].Department);
            Assert.All(dto.Instructors, instructor => Assert.Equal(DataAccessConstants.noSqlInstructorShortType, instructor.Type));
            Assert.All(dto.Instructors, instructor => Assert.Equal(DataAccessConstants.noSqlInstructorShortVersion, instructor.Version));
        }

        [Fact]
        public void Map_MapsInstructor()
        {
            //Given
            Instructor instructor = new Instructor()
            {
                FirstName = "instructorFirst",
                LastName = "instructorLast",
                Gender = Gender.Female,
                Email = "instructor@school.com"
            };
            EllCoach coach = new EllCoach()
            {
                FirstName = "coachFirst",
                LastName = "coachLast",
                Gender = Gender.Female,
                Email = "coach@school.com"
            };
            Assistant assistant1 = new Assistant()
            {
                FirstName = "assistantFirst",
                LastName = "assistantLast",
                Gender = Gender.Female,
                Email = "assistant1@school.com"
            };
            Assistant assistant2 = new Assistant()
            {
                FirstName = "assistantFist",
                LastName = "assistantLast",
                Gender = Gender.Male,
                Email = "assistant2@school.com"
            };
            instructor.EllCoach = coach;
            instructor.Assistants.Add(assistant1);
            instructor.Assistants.Add(assistant2);
            //When
            InstructorDto dto = GetMapped<InstructorDto, Instructor>(instructor);
            //Then
            Assert.Equal(instructor.Id.ToString(), dto.Id);
            Assert.Equal(instructor.FirstName, dto.FirstName);
            Assert.Equal(instructor.LastName, dto.LastName);
            Assert.Equal(instructor.Email, dto.Email);
            Assert.Equal(instructor.Gender, dto.Gender);
            Assert.Equal(instructor.Department, dto.Department);
            Assert.Equal(DataAccessConstants.noSqlInstructorVersion, dto.Version);
            Assert.Equal(DataAccessConstants.noSqlInstructorType, dto.Type);
            Assert.Equal(instructor.EllCoach.Id.ToString(), dto.EllCoach.Id);
            Assert.Equal(instructor.EllCoach.FirstName, dto.EllCoach.FirstName);
            Assert.Equal(instructor.EllCoach.LastName, dto.EllCoach.LastName);
            Assert.Equal(instructor.EllCoach.Email, dto.EllCoach.Email);
            Assert.Equal(instructor.EllCoach.Gender, dto.EllCoach.Gender);
            Assert.Equal(DataAccessConstants.noSqlPersonType, dto.EllCoach.Type);
            Assert.Equal(DataAccessConstants.noSqlPersonVersion, dto.EllCoach.Version);
            Assert.Equal(assistant1.Id.ToString(), dto.Assistants[0].Id);
            Assert.Equal(assistant1.FirstName, dto.Assistants[0].FirstName);
            Assert.Equal(assistant1.LastName, dto.Assistants[0].LastName);
            Assert.Equal(assistant1.Email, dto.Assistants[0].Email);
            Assert.Equal(assistant1.Gender, dto.Assistants[0].Gender);
            Assert.Equal(assistant2.Id.ToString(), dto.Assistants[1].Id);
            Assert.Equal(assistant2.FirstName, dto.Assistants[1].FirstName);
            Assert.Equal(assistant2.LastName, dto.Assistants[1].LastName);
            Assert.Equal(assistant2.Email, dto.Assistants[1].Email);
            Assert.Equal(assistant2.Gender, dto.Assistants[1].Gender);
            Assert.All(dto.Assistants, assistant => Assert.Equal(DataAccessConstants.noSqlPersonVersion, assistant.Version));
            Assert.All(dto.Assistants, assistant => Assert.Equal(DataAccessConstants.noSqlPersonType, assistant.Type));
        }

        ///TODO: test if userId is set to id of entity.
    }
}