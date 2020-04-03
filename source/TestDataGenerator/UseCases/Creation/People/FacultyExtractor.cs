using System.Collections.Generic;
using System.Linq;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.People
{
    class FacultyExtractor : IFacultyExtractor
    {
        public List<Assistant> ExtractAssistants(List<SchoolClass> schoolClasses)
        {
            List<Assistant> assistants = new List<Assistant>();
            schoolClasses.ForEach(schoolClass => schoolClass.CourseAssignment.Instructor.Assistants.ForEach(assistant => assistants.Add(assistant)));
            return assistants;
        }

        public List<EllCoach> ExtractEllCoaches(List<SchoolClass> schoolClasses) => schoolClasses.Select(schoolClass => schoolClass.CourseAssignment.Instructor.EllCoach).Distinct().ToList();

        public List<Instructor> ExtractInstructors(List<SchoolClass> schoolClasses)
        {
            List<Instructor> instructors = new List<Instructor>();
            schoolClasses.ForEach(schoolClass => instructors.Add(schoolClass.CourseAssignment.Instructor));
            return instructors;
        }
    }
}