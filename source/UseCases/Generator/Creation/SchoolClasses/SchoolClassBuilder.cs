using System;
using System.Collections.Generic;
using EllAid.Entities.Data;
using EllAid.UseCases.Generator.Creation.Courses;
using EllAid.UseCases.Generator.Creation.People;
using EllAid.UseCases.Generator.Creation.Tests;

namespace EllAid.UseCases.Generator.Creation.SchoolClasses
{
    class SchoolClassBuilder : ISchoolClassBuilder
    {
        List<Term> terms;
        List<SchoolClass> classes;
        bool isBuilt;
        readonly IClassAssigner classAssigner;
        readonly IPersonCreator personCreator;
        readonly ITestBuilder testBuilder;
        readonly ICourseManager courseManager;
        readonly ITestAssigner testAssigner;

        public SchoolClassBuilder(IClassAssigner classAssigner, IPersonCreator personCreator, ITestBuilder testBuilder, ICourseManager courseManager, ITestAssigner testAssigner)
        {
            terms = new List<Term>();
            classes = new List<SchoolClass>();
            this.classAssigner = classAssigner;
            this.personCreator = personCreator;
            this.testBuilder = testBuilder;
            this.courseManager = courseManager;
            this.testAssigner = testAssigner;
        }

        void CreatePreKClasses()
        {
            EllCoach coach = personCreator.CreatePerson<EllCoach>();
            for (int i = 0; i < 4; i++)
            {
                CreatePreKClass(coach);
            }
        }

        private void CreatePreKClass(EllCoach coach)
        {
            int schoolYear = DateTime.Now.Year;
            DateTime testSessionDate = new DateTime(schoolYear, 10, 1);
            DateTime testResultDate = testSessionDate.AddDays(14);
            Department department = Department.EarlyChildhood;
            Term term = CreateTerm(SchoolTerm.Fall, schoolYear);
            terms.Add(term);
            Course course = new Course("PreKindergarten General Education", department);
            GradeCourse gradeCourse = new GradeCourse(course, SchoolGrade.PreKindergarten);
            TermCourse termCourse = new TermCourse(term, gradeCourse);
            Instructor instructor = personCreator.CreatePerson<Instructor>();
            instructor.Department = department;
            List<Assistant> assistants = personCreator.CreatePeople<Assistant>(2);
            List<Student> students = personCreator.CreateStudents(20, schoolYear-4);
            SchoolClass schoolClass = new SchoolClass("Section A");
            classAssigner.AssignClass(schoolClass, instructor, assistants, coach, students, termCourse);
            Test widaTest = testBuilder.Build();
            TestSession session = new TestSession("Fall Test Session 1", testSessionDate, widaTest);
            courseManager.AddTestSession(session, schoolClass.CourseAssignment);
            students.ForEach(student=> widaTest.Sections.ForEach(section=> testAssigner.AssignTest(student.Enrollments[0], session, ((IWidaTestBuilder)testBuilder).BuildResult(section, testResultDate))));    
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
                Build();
            }
            Predicate<SchoolClass> gradeAndYearMatch = schoolClass => schoolClass.CourseAssignment.TermCourse.Term.Year == year && schoolClass.CourseAssignment.TermCourse.GradeCourse.Grade == grade;

            return classes.FindAll(gradeAndYearMatch);
        }
        
        void Build()
        {
            CreatePreKClasses();
            isBuilt = true;
        }
    }
}