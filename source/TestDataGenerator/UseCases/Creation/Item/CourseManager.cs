using System;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class CourseManager : ICourseManager
    {
        public Course CreateCourse(string name, Department department) => new Course()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Department = department
        };

        public CourseAssignment CreateCourseAssignment(TermCourse termCourse, Instructor instructor) => new CourseAssignment()
        {
            Id = Guid.NewGuid(),
            TermCourse = termCourse,
            Instructor = instructor
        };

        // public Enrollment CreateEnrollment(Student student, CourseAssignment assignment) => new Enrollment()
        // {
        //     Id = Guid.NewGuid(),
        //     Student = student,
        //     CourseAssignment = assignment
        // };

        public GradeCourse CreateGradeCourse(Course course, SchoolGrade grade) => new GradeCourse()
        {
            Id = Guid.NewGuid(),
            Course = course,
            Grade = grade
        };

        public TermCourse CreateTermCourse(Term term, GradeCourse gradeCourse) => new TermCourse()
        {
            Id = Guid.NewGuid(),
            Term = term,
            GradeCourse = gradeCourse
        };

        public void EnrollStudent(Student student, CourseAssignment assignment)
        {
            Enrollment enrollment = new Enrollment()
            {
                Id = Guid.NewGuid(),
                Student = student,
                CourseAssignment = assignment
            };
            student.Enrollments.Add(enrollment);
        }
    }
}