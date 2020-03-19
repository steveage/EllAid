using System;
using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class SchoolClassBuilder : ISchoolClassBuilder
    {
        readonly IPersonCreator personCreator;
        readonly IClassManager classManager;
        readonly ICourseManager courseManager;
        readonly IInstructorManager instructorManager;

        public SchoolClassBuilder(IPersonCreator personCreator, IClassManager classManager, ICourseManager courseManager, IInstructorManager instructorManager)
        {
            this.personCreator = personCreator;
            this.classManager = classManager;
            this.courseManager = courseManager;
            this.instructorManager = instructorManager;
        }

        public SchoolClass CreateClass(string name, Instructor instructor, List<Assistant> assistants, EllCoach coach, List<Student> students, TermCourse termCourse)
        {
            CourseAssignment assignment = courseManager.CreateCourseAssignment(termCourse, instructor);
            assistants.ForEach(assistant => instructorManager.AddAssistant(assistant, instructor));
            instructorManager.AddCoach(coach, instructor);
            SchoolClass schoolClass = classManager.Create(name, assignment);
            students.ForEach(student => classManager.AddStudent(student, schoolClass));
            students.ForEach(student => courseManager.EnrollStudent(student, assignment));
            
            return schoolClass;
        }
    }
}