using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.People
{
    interface IFacultyExtractor
    {
        List<Instructor> ExtractInstructors(List<SchoolClass> schoolClasses);
        List<EllCoach> ExtractEllCoaches(List<SchoolClass> schoolClasses);
        List<Assistant> ExtractAssistants(List<SchoolClass> schoolClasses);
    }
}