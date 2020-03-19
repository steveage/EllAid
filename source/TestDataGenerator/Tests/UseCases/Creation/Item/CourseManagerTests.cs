using System;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Creation.Item;
using Xunit;

namespace EllAid.TestDataGenerator.Tests.UseCases.Creation.Item
{
    public class CourseManagerTests
    {
        [Fact]
        public void CreateCourse_ReturnsCourseWithValues()
        {
            //Given
            CourseManager manager = new CourseManager();
            const string courseName = "PreK General Education";
            const Department department = Department.EarlyChildhood;
            //When
            Course course = manager.CreateCourse(courseName, department);
            //Then
            Assert.NotEqual(Guid.Empty, course.Id);
            Assert.Equal(courseName, course.Name);
            Assert.Equal(department, course.Department);
        }

        [Fact]
        public void CreateCourseGrade_ReturnsCourseGradeWithValues()
        {
            //Given
            CourseManager manager = new CourseManager();
            Course course = new Course();
            const SchoolGrade grade = SchoolGrade.PreKindergarten;
            //When
            GradeCourse courseGrade = manager.CreateGradeCourse(course, grade);
            //Then
            Assert.NotEqual(Guid.Empty, courseGrade.Id);
            Assert.Equal(course, courseGrade.Course);
            Assert.Equal(grade, courseGrade.Grade);
        }

        [Fact]
        public void CreateTermCourse_ReturnsTermCourseWithValues()
        {
            //Given
            CourseManager manager = new CourseManager();
            GradeCourse gradeCourse = new GradeCourse();
            Term term = new Term();
            //When
            TermCourse termCourse = manager.CreateTermCourse(term, gradeCourse);
            //Then
            Assert.NotEqual(Guid.Empty, termCourse.Id);
            Assert.Equal(gradeCourse, termCourse.GradeCourse);
            Assert.Equal(term, termCourse.Term);
        }

        [Fact]
        public void CreateCourseAssignment_ReturnsCourseAssignmentWithValues()
        {
            //Given
            CourseManager manager = new CourseManager();
            TermCourse termCourse = new TermCourse();
            Instructor instructor = new Instructor();
            //When
            CourseAssignment assignment = manager.CreateCourseAssignment(termCourse, instructor);
            //Then
            Assert.NotEqual(Guid.Empty, assignment.Id);
            Assert.Equal(termCourse, assignment.TermCourse);
            Assert.Equal(instructor, assignment.Instructor);
        }

        [Fact]
        public void EnrollStudent_CreatesEnrollmentAndAddsStudent()
        {
            //Given
            CourseManager manager = new CourseManager();
            Student student = new Student();
            CourseAssignment assignment = new CourseAssignment();
            //When
            manager.EnrollStudent(student, assignment);
            //Then
            Assert.Equal(1, student.Enrollments.Count);
            Assert.NotEqual(Guid.Empty, student.Enrollments[0].Id);
            Assert.Equal(student, student.Enrollments[0].Student);
            Assert.Equal(assignment, student.Enrollments[0].CourseAssignment);
        }
    }
}