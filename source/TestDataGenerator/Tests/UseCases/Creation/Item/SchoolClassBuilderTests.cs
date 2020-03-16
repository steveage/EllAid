using System;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.TestData;
using EllAid.TestDataGenerator.UseCases.Creation.Item;
using Xunit;

namespace EllAid.TestDataGenerator.Tests.UseCases.Creation.Item
{
    public class SchoolClassBuilderTests
    {
        [Fact]
        public void BuildGenEdClass_ReturnsClassWithInstructor()
        {
            //Given
            SchoolClassBuilder builder = new SchoolClassBuilder(new PersonCreator(new BogusFabricator(), new InMemoryUserDataProvider()));
            const string className = "section A";
            const string courseName = "Pre-Kindergarten General Education";
            //When
            SchoolClass schoolClass = builder.BuildGenEdClass(className);
            //Then
            Assert.NotEqual(Guid.Empty, schoolClass.Id);
            Assert.Equal(className, schoolClass.Name);
            Assert.Equal(SchoolGrade.PreKindergarten, schoolClass.Grade);
            // Test Instructor
            Assert.NotEqual(Guid.Empty, schoolClass.Instructor.Id);
            Assert.NotEmpty(schoolClass.Instructor.FirstName);
            Assert.NotEmpty(schoolClass.Instructor.LastName);
            Assert.True(PersonCreatorTests.IsEmailAddress(schoolClass.Instructor.Email));
            Assert.NotEqual(Gender.Invalid, schoolClass.Instructor.Gender);
            Assert.Equal(Department.EarlyChildhood, schoolClass.Instructor.Department);
            // Test Assistants
            Assert.Equal(2, schoolClass.Instructor.Assistants.Count);
            Assert.All(schoolClass.Instructor.Assistants, assistant => Assert.NotEqual(Guid.Empty, assistant.Id));
            Assert.All(schoolClass.Instructor.Assistants, assistant => Assert.NotEmpty(assistant.FirstName));
            Assert.All(schoolClass.Instructor.Assistants, assistant => Assert.NotEmpty(assistant.LastName));
            Assert.All(schoolClass.Instructor.Assistants, assistant => Assert.NotEmpty(assistant.Email));
            Assert.All(schoolClass.Instructor.Assistants, assistant => Assert.NotEqual(Gender.Invalid, assistant.Gender));
            Assert.All(schoolClass.Instructor.Assistants, assistant => Assert.Equal(schoolClass.Instructor, assistant.Instructor));
            // Test EllCoach
            Assert.NotEqual(Guid.Empty, schoolClass.Instructor.EllCoach.Id);
            Assert.NotEmpty(schoolClass.Instructor.EllCoach.FirstName);
            Assert.NotEmpty(schoolClass.Instructor.EllCoach.LastName);
            Assert.True(PersonCreatorTests.IsEmailAddress(schoolClass.Instructor.EllCoach.Email));
            Assert.NotEqual(Gender.Invalid, schoolClass.Instructor.EllCoach.Gender);
            Assert.Equal(1, schoolClass.Instructor.EllCoach.Instructors.Count);
            Assert.Equal(schoolClass.Instructor, schoolClass.Instructor.EllCoach.Instructors[0]);
            // Test Term
            Assert.NotEqual(Guid.Empty, schoolClass.Term.Id);
            Assert.NotEqual(0, schoolClass.Term.Year);
            Assert.Equal(SchoolTerm.Fall, schoolClass.Term.SchoolTerm);
            // Test Students
            Assert.Equal(20, schoolClass.Students.Count);
            Assert.All(schoolClass.Students, student => Assert.NotEqual(Guid.Empty, student.Id));
            Assert.All(schoolClass.Students, student => Assert.NotEmpty(student.FirstName));
            Assert.All(schoolClass.Students, student => Assert.NotEmpty(student.LastName));
            Assert.All(schoolClass.Students, student => Assert.True(PersonCreatorTests.IsEmailAddress(student.Email)));
            Assert.All(schoolClass.Students, student => Assert.NotEqual(Gender.Invalid, student.Gender));
            Assert.All(schoolClass.Students, student => Assert.NotEqual(DateTime.MinValue, student.DateOfBirth));
            Assert.All(schoolClass.Students, student => Assert.NotEqual(DateTime.MinValue, student.EntryDate));
            Assert.All(schoolClass.Students, student => Assert.NotEmpty(student.HomeLanguage));
            Assert.All(schoolClass.Students, student => Assert.NotEmpty(student.HomeCommunicationLanguage));
            Assert.All(schoolClass.Students, student => Assert.NotEmpty(student.PictureUrl));
            Assert.All(schoolClass.Students, student => Assert.Equal(schoolClass, student.Class));
            Assert.All(schoolClass.Students, student => Assert.Equal(1, student.Enrollments.Count));
            // Test Student.Enrollment
            Assert.All(schoolClass.Students, student => Assert.Equal(student, student.Enrollments[0].Student));
            Assert.All(schoolClass.Students, student => Assert.NotEqual(Guid.Empty, student.Enrollments[0].Id));
            // Test Enrollment.CourseAssignment
            Assert.All(schoolClass.Students, student => Assert.NotEqual(Guid.Empty, student.Enrollments[0].CourseAssignment.Id));
            Assert.All(schoolClass.Students, student => Assert.Equal(schoolClass.Instructor, student.Enrollments[0].CourseAssignment.Instructor));
            Assert.All(schoolClass.Students, student => Assert.Equal(schoolClass.Grade, student.Enrollments[0].CourseAssignment.Grade));
            Assert.All(schoolClass.Students, student => Assert.Equal(schoolClass.Term, student.Enrollments[0].CourseAssignment.Term));
            // Test Enrollment.CourseAssignment.Course
            Assert.All(schoolClass.Students, student => Assert.NotEqual(Guid.Empty, student.Enrollments[0].CourseAssignment.Course.Id));
            Assert.All(schoolClass.Students, student => Assert.Equal(Department.EarlyChildhood, student.Enrollments[0].CourseAssignment.Course.Department));
            Assert.All(schoolClass.Students, student => Assert.Equal(courseName, student.Enrollments[0].CourseAssignment.Course.Name));
        }
    }
}