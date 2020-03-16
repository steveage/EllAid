using System;
using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class SchoolClassBuilder : ISchoolClassBuilder
    {
        readonly IPersonCreator personCreator;

        public SchoolClassBuilder(IPersonCreator personCreator)
        {
            this.personCreator = personCreator;
        }

        public SchoolClass BuildGenEdClass(string name)
        {
            SchoolClass schoolClass = new SchoolClass();
            Instructor instructor = personCreator.CreatePerson<Instructor>();
            instructor.Department = Department.EarlyChildhood;
            List<Assistant> assistants = personCreator.CreatePeople<Assistant>(2);
            assistants.ForEach(a => a.Instructor = instructor);
            List<Student> students = personCreator.CreateStudents(20, 2015);
            students.ForEach(s => s.Class = schoolClass);
            EllCoach coach = personCreator.CreatePerson<EllCoach>();
            coach.Instructors = new List<Instructor> {instructor};
            Term term = new Term()
            {
                Id = Guid.NewGuid(),
                Year = 2020,
                SchoolTerm = SchoolTerm.Fall
            };
            Course course = new Course()
            {
                Id = Guid.NewGuid(),
                Department = Department.EarlyChildhood,
                Name = "Pre-Kindergarten General Education"
            };
            CourseAssignment courseAssignment = new CourseAssignment()
            {
                Id = Guid.NewGuid(),
                Course = course,
                Grade = SchoolGrade.PreKindergarten,
                Instructor = instructor,
                Term = term
            };

            students.ForEach(s => s.Enrollments = GetEnrollments(s, courseAssignment));
            
            instructor.Assistants = assistants;
            instructor.EllCoach = coach;
            schoolClass.Id = Guid.NewGuid();
            schoolClass.Name = name;
            schoolClass.Instructor = instructor;
            schoolClass.Term = term;
            schoolClass.Grade = SchoolGrade.PreKindergarten;
            schoolClass.Students = students;
            return schoolClass;
        }

        List<Enrollment> GetEnrollments(Student student, CourseAssignment courseAssignment)
        {
            Enrollment enrollment = new Enrollment()
            {
                Id = Guid.NewGuid(),
                Student = student,
                CourseAssignment = courseAssignment
            };
            List<Enrollment> enrollments = new List<Enrollment>() {enrollment};
            return enrollments;
        }
    }
}