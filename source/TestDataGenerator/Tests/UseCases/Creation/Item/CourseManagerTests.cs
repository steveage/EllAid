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
            const string courseName = "PreK General Education";
            const Department department = Department.EarlyChildhood;
            //When
            Course course = new Course(courseName, department);
            //Then
            Assert.NotEqual(Guid.Empty, course.Id);
            Assert.Equal(courseName, course.Name);
            Assert.Equal(department, course.Department);
        }

        [Fact]
        public void CreateCourseGrade_ReturnsCourseGradeWithValues()
        {
            //Given
            Course course = new Course();
            const SchoolGrade grade = SchoolGrade.PreKindergarten;
            //When
            GradeCourse courseGrade = new GradeCourse(course, grade);
            //Then
            Assert.NotEqual(Guid.Empty, courseGrade.Id);
            Assert.Equal(course, courseGrade.Course);
            Assert.Equal(grade, courseGrade.Grade);
        }

        [Fact]
        public void CreateTermCourse_ReturnsTermCourseWithValues()
        {
            //Given
            GradeCourse gradeCourse = new GradeCourse();
            Term term = new Term();
            //When
            TermCourse termCourse = new TermCourse(term, gradeCourse);
            //Then
            Assert.NotEqual(Guid.Empty, termCourse.Id);
            Assert.Equal(gradeCourse, termCourse.GradeCourse);
            Assert.Equal(term, termCourse.Term);
        }

        [Fact]
        public void CreateCourseAssignment_ReturnsCourseAssignmentWithValues()
        {
            //Given
            TermCourse termCourse = new TermCourse();
            Instructor instructor = new Instructor();
            //When
            CourseAssignment assignment = new CourseAssignment(termCourse, instructor);
            //Then
            Assert.NotEqual(Guid.Empty, assignment.Id);
            Assert.Equal(termCourse, assignment.TermCourse);
            Assert.Equal(instructor, assignment.Instructor);
        }

        [Fact]
        public void EnrollStudent_CreatesEnrollmentAndAddsStudent()
        {
            //Given
            Student student = new Student();
            CourseAssignment assignment = new CourseAssignment();
            //When
            student.Enrollments.Add(new Enrollment(student, assignment));
            //Then
            Assert.Equal(1, student.Enrollments.Count);
            Assert.NotEqual(Guid.Empty, student.Enrollments[0].Id);
            Assert.Equal(student, student.Enrollments[0].Student);
            Assert.Equal(assignment, student.Enrollments[0].CourseAssignment);
        }
    }
}