using System;
using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class SchoolBuilder : ISchoolBuilder
    {
        List<Term> terms;
        List<SchoolClass> classes;
        bool isBuilt;
        readonly IClassAssigner classAssigner;
        readonly IPersonCreator personCreator;

        public SchoolBuilder(IClassAssigner classAssigner, IPersonCreator personCreator)
        {
            terms = new List<Term>();
            classes = new List<SchoolClass>();
            this.classAssigner = classAssigner;
            this.personCreator = personCreator;
        }

        public void Build()
        {
            CreatePreKClasses();
            isBuilt = true;
        }

        void CreatePreKClasses()
        {
            for (int i = 0; i < 4; i++)
            {
                CreatePreKClass();
            }
        }

        private void CreatePreKClass()
        {
            int schoolYear = DateTime.Now.Year;
            Department department = Department.EarlyChildhood;
            Term term = CreateTerm(SchoolTerm.Fall, schoolYear);
            terms.Add(term);
            Course course = new Course("PreKindergarten General Education", department);
            GradeCourse gradeCourse = new GradeCourse(course, SchoolGrade.PreKindergarten);
            TermCourse termCourse = new TermCourse(term, gradeCourse);
            Instructor instructor = personCreator.CreatePerson<Instructor>();
            instructor.Department = department;
            EllCoach coach = personCreator.CreatePerson<EllCoach>();
            List<Assistant> assistants = personCreator.CreatePeople<Assistant>(2);
            List<Student> students = personCreator.CreateStudents(20, schoolYear-4);
            SchoolClass schoolClass = new SchoolClass("Section A");
            classAssigner.AssignClass(schoolClass, instructor, assistants, coach, students, termCourse);
            
            classes.Add(schoolClass);
        }

        Term CreateTerm(SchoolTerm term, int year) => new Term()
        {
            Id = Guid.NewGuid(),
            SchoolTerm = term,
            Year = year
        };

        public List<SchoolClass> GetClasses(SchoolGrade grade, int year)
        {
            if (!isBuilt)
            {
                throw new DomainModelNotBuiltException("Domain model not built. Use Build() method first.");
            }
            Predicate<SchoolClass> gradeAndYearMatch = schoolClass => schoolClass.CourseAssignment.TermCourse.Term.Year == year && schoolClass.CourseAssignment.TermCourse.GradeCourse.Grade == grade;

            return classes.FindAll(gradeAndYearMatch);
        }
    }
}