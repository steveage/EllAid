using System;
using System.Collections.Generic;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.TestData;
using EllAid.TestDataGenerator.UseCases.Creation.Item;
using Xunit;

namespace EllAid.TestDataGenerator.Tests.UseCases.Creation.Item
{
    public class SchoolBuilderTests
    {
        [Fact]
        public void GetClasses_WhenNotBuilt_ThrowsException()
        {
            //Given
            SchoolBuilder builder = GetBuilder();  
            //When, Then
            Assert.Throws<DomainModelNotBuiltException>(()=>builder.GetClasses(SchoolGrade.PreKindergarten, 2020));
        }

        [Fact]
        public void GetClasses_WhenBuilt_ReturnsFourClassesPerYear()
        {
            //Given
            SchoolBuilder builder = GetBuilder();
            //When
            builder.Build();
            List<SchoolClass> classes = builder.GetClasses(SchoolGrade.PreKindergarten, 2020);
            //Then
            Assert.Equal(4, classes.Count);
            Assert.All(classes, schoolClass => Assert.NotEqual(Guid.Empty,schoolClass.Id));
            Assert.All(classes, schoolClass => Assert.NotEmpty(schoolClass.Name));
            // SchoolClass.CourseAssignment.TermCourse.GradeCourse.Course
            Assert.All(classes, schoolClass => Assert.NotEqual(Guid.Empty, schoolClass.CourseAssignment.TermCourse.GradeCourse.Course.Id));
            Assert.All(classes, schoolClass => Assert.Equal(Department.EarlyChildhood, schoolClass.CourseAssignment.TermCourse.GradeCourse.Course.Department));
            Assert.All(classes, schoolClass => Assert.NotEmpty(schoolClass.CourseAssignment.TermCourse.GradeCourse.Course.Name));
            // SchoolClass.CourseAssignment.TermCourse.GradeCourse
            Assert.All(classes, schoolClass => Assert.NotEqual(Guid.Empty, schoolClass.CourseAssignment.TermCourse.GradeCourse.Id));
            Assert.All(classes, schoolClass => Assert.Equal(SchoolGrade.PreKindergarten, schoolClass.CourseAssignment.TermCourse.GradeCourse.Grade));
            // SchoolClass.CourseAssignment.TermCourse
            Assert.All(classes, schoolClass => Assert.NotEqual(Guid.Empty, schoolClass.CourseAssignment.TermCourse.Id));
            // SchoolClass.CourseAssignment
            Assert.All(classes, schoolClass => Assert.NotEqual(Guid.Empty, schoolClass.CourseAssignment.Id));
            // SchoolClass.CourseAssignment.Instructor
            Assert.All(classes, schoolClass => Assert.NotEqual(Guid.Empty, schoolClass.CourseAssignment.Instructor.Id));
            Assert.All(classes, schoolClass => Assert.Equal(Department.EarlyChildhood, schoolClass.CourseAssignment.Instructor.Department));
            Assert.All(classes, schoolClass => Assert.True(PersonCreatorTests.IsEmailAddress(schoolClass.CourseAssignment.Instructor.Email)));
            Assert.All(classes, schoolClass => Assert.NotEmpty(schoolClass.CourseAssignment.Instructor.FirstName));
            Assert.All(classes, schoolClass => Assert.NotEmpty(schoolClass.CourseAssignment.Instructor.LastName));
            Assert.All(classes, schoolClass => Assert.NotEqual(Gender.Invalid, schoolClass.CourseAssignment.Instructor.Gender));
            // SchoolClass.CourseAssignment.Instructor.EllCoach
            Assert.All(classes, schoolClass => Assert.NotEqual(Guid.Empty, schoolClass.CourseAssignment.Instructor.EllCoach.Id));
            Assert.All(classes, schoolClass => Assert.True(PersonCreatorTests.IsEmailAddress(schoolClass.CourseAssignment.Instructor.EllCoach.Email)));
            Assert.All(classes, schoolClass => Assert.NotEmpty(schoolClass.CourseAssignment.Instructor.EllCoach.FirstName));
            Assert.All(classes, schoolClass => Assert.NotEmpty(schoolClass.CourseAssignment.Instructor.EllCoach.LastName));
            Assert.All(classes, schoolClass => Assert.NotEqual(Gender.Invalid, schoolClass.CourseAssignment.Instructor.EllCoach.Gender));
            Assert.All(classes, schoolClass => Assert.Equal(1, schoolClass.CourseAssignment.Instructor.EllCoach.Instructors.Count));
            Assert.All(classes, schoolClass => Assert.Contains(schoolClass.CourseAssignment.Instructor, schoolClass.CourseAssignment.Instructor.EllCoach.Instructors));
            // SchoolClass.CourseAssignment.Instructor.Assistants
            Assert.All(classes, schoolClass => Assert.Equal(2, schoolClass.CourseAssignment.Instructor.Assistants.Count));
            Assert.All(classes, schoolClass => Assert.All(schoolClass.CourseAssignment.Instructor.Assistants, assistant => Assert.Equal(schoolClass.CourseAssignment.Instructor, assistant.Instructor)));
            Assert.All(classes, schoolClass => Assert.All(schoolClass.CourseAssignment.Instructor.Assistants, assistant => Assert.NotEqual(Guid.Empty, assistant.Id)));
            Assert.All(classes, schoolClass => Assert.All(schoolClass.CourseAssignment.Instructor.Assistants, assistant => Assert.True(PersonCreatorTests.IsEmailAddress(assistant.Email))));
            Assert.All(classes, schoolClass => Assert.All(schoolClass.CourseAssignment.Instructor.Assistants, assistant => Assert.NotEmpty(assistant.FirstName)));
            Assert.All(classes, schoolClass => Assert.All(schoolClass.CourseAssignment.Instructor.Assistants, assistant => Assert.NotEmpty(assistant.LastName)));
            Assert.All(classes, schoolClass => Assert.All(schoolClass.CourseAssignment.Instructor.Assistants, assistant => Assert.NotEqual(Gender.Invalid, assistant.Gender)));
            // SchoolClass.Students
            Assert.All(classes, schoolClass => Assert.All(schoolClass.Students, student => Assert.NotEqual(Guid.Empty, student.Id)));
            Assert.All(classes, schoolClass => Assert.All(schoolClass.Students, student => Assert.NotEmpty(student.FirstName)));
            Assert.All(classes, schoolClass => Assert.All(schoolClass.Students, student => Assert.NotEmpty(student.LastName)));
            Assert.All(classes, schoolClass => Assert.All(schoolClass.Students, student => Assert.True(PersonCreatorTests.IsEmailAddress(student.Email))));
            Assert.All(classes, schoolClass => Assert.All(schoolClass.Students, student => Assert.NotEqual(Gender.Invalid, student.Gender)));
            Assert.All(classes, schoolClass => Assert.All(schoolClass.Students, student => Assert.NotEqual(DateTime.MinValue, student.DateOfBirth)));
            Assert.All(classes, schoolClass => Assert.All(schoolClass.Students, student => Assert.NotEqual(DateTime.MinValue, student.EntryDate)));
            Assert.All(classes, schoolClass => Assert.All(schoolClass.Students, student => Assert.NotEmpty(student.HomeLanguage)));
            Assert.All(classes, schoolClass => Assert.All(schoolClass.Students, student => Assert.NotEmpty(student.HomeCommunicationLanguage)));
            Assert.All(classes, schoolClass => Assert.All(schoolClass.Students, student => Assert.NotEmpty(student.PictureUrl)));
            Assert.All(classes, schoolClass => Assert.All(schoolClass.Students, student => Assert.Equal(schoolClass, student.Class)));
            // SchoolClass.Students.Enrollments
            Assert.All(classes, schoolClass => Assert.All(schoolClass.Students, student => Assert.Equal(1, student.Enrollments.Count)));
            Assert.All(classes, schoolClass => Assert.All(schoolClass.Students, student => Assert.All(student.Enrollments, enrollment => Assert.Equal(student, enrollment.Student))));
            Assert.All(classes, schoolClass => Assert.All(schoolClass.Students, student => Assert.All(student.Enrollments, enrollment => Assert.Equal(schoolClass.CourseAssignment, enrollment.CourseAssignment))));
            Assert.All(classes, schoolClass => Assert.All(schoolClass.Students, student => Assert.All(student.Enrollments, enrollment => Assert.Null(enrollment.Score))));
        }

        SchoolBuilder GetBuilder() =>
        new SchoolBuilder(new ClassManager(), new ClassAssigner(new ClassManager(), new CourseManager(), new InstructorManager()), new CourseManager(), new PersonCreator(new BogusFabricator(), new InMemoryUserDataProvider()));
    }
}