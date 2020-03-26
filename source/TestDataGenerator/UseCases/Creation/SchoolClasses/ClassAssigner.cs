using System.Collections.Generic;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Creation.Courses;
using EllAid.TestDataGenerator.UseCases.Creation.People;

namespace EllAid.TestDataGenerator.UseCases.Creation.SchoolClasses
{
    class ClassAssigner : IClassAssigner
    {
        readonly IInstructorManager instructorManager;
        readonly ICourseManager courseManager;

        public ClassAssigner(IInstructorManager instructorManager, ICourseManager courseManager)
        {
            this.instructorManager = instructorManager;
            this.courseManager = courseManager;
        }

        public void AddStudent(Student student, SchoolClass schoolClass)
        {
            student.Class = schoolClass;
            schoolClass.Students.Add(student);
        }

        public void AssignClass(SchoolClass schoolClass, Instructor instructor, List<Assistant> assistants, EllCoach coach, List<Student> students, TermCourse termCourse)
        {
            CourseAssignment assignment = new CourseAssignment(termCourse, instructor);
            assistants.ForEach(assistant => instructorManager.AddAssistant(assistant, instructor));
            instructorManager.AddCoach(coach, instructor);
            schoolClass.CourseAssignment = assignment;
            students.ForEach(student => AddStudent(student, schoolClass));
            students.ForEach(student => courseManager.Enroll(student, new Enrollment(assignment)));
        }
    }
}