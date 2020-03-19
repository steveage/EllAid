using System;
using System.Collections.Generic;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.TestData;
using EllAid.TestDataGenerator.UseCases.Creation.Item;
using Xunit;

namespace EllAid.TestDataGenerator.Tests.UseCases.Creation.Item
{
    public class SchoolClassBuilderTests
    {
        [Fact]
        public void BuildPreKClass_ReturnsPopulatedClass()
        {
            //Given
            SchoolClassBuilder builder = new SchoolClassBuilder(new PersonCreator(new BogusFabricator(), new InMemoryUserDataProvider()), new ClassManager(), new CourseManager(), new InstructorManager());
            const string className = "section A";
            Instructor instructor = new Instructor();
            List<Assistant> assistants = new List<Assistant>() { new Assistant(), new Assistant()};
            EllCoach coach = new EllCoach();
            List<Student> students = new List<Student>() { new Student(), new Student(), new Student() };
            TermCourse termCourse = new TermCourse();
            //When
            SchoolClass schoolClass = builder.CreateClass(className, instructor, assistants, coach, students, termCourse);
            //Then
            Assert.Equal(className, schoolClass.Name);
            Assert.Equal(instructor, schoolClass.CourseAssignment.Instructor);
            Assert.Equal(termCourse, schoolClass.CourseAssignment.TermCourse);
            Assert.Equal(students, schoolClass.Students);
            Assert.NotEmpty(schoolClass.Students);
            Assert.All(schoolClass.Students, student => Assert.Equal(schoolClass, student.Class));
            Assert.All(schoolClass.Students, student => Assert.NotEmpty(student.Enrollments));
            Assert.All(schoolClass.Students, student => Assert.NotEmpty(student.Enrollments));
            Assert.All(schoolClass.Students, student => Assert.All(student.Enrollments, enrollment => Assert.Equal(student, enrollment.Student)));
            Assert.NotEmpty(schoolClass.CourseAssignment.Instructor.Assistants);
            Assert.All(assistants, assistant => Assert.Equal(instructor, assistant.Instructor));
            Assert.NotEmpty(instructor.Assistants);
            Assert.All(instructor.Assistants, assistant => Assert.Contains(assistant, instructor.Assistants));
            Assert.Equal(coach, instructor.EllCoach);
            Assert.Contains(instructor, coach.Instructors);
        }
    }
}