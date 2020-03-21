using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class ClassAssigner : IClassAssigner
    {
        readonly IClassManager classManager;
        readonly ICourseManager courseManager;
        readonly IInstructorManager instructorManager;

        public ClassAssigner(IClassManager classManager, ICourseManager courseManager, IInstructorManager instructorManager)
        {
            this.classManager = classManager;
            this.courseManager = courseManager;
            this.instructorManager = instructorManager;
        }

        public void AssignClass(SchoolClass schoolClass, Instructor instructor, List<Assistant> assistants, EllCoach coach, List<Student> students, TermCourse termCourse)
        {
            CourseAssignment assignment = courseManager.CreateCourseAssignment(termCourse, instructor);
            assistants.ForEach(assistant => instructorManager.AddAssistant(assistant, instructor));
            instructorManager.AddCoach(coach, instructor);
            schoolClass.CourseAssignment = assignment;
            students.ForEach(student => classManager.AddStudent(student, schoolClass));
            students.ForEach(student => courseManager.EnrollStudent(student, assignment));
        }
    }
}