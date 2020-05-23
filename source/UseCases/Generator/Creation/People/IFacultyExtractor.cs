using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.UseCases.Generator.Creation.People
{
    interface IFacultyExtractor
    {
        List<Instructor> ExtractInstructors(List<SchoolClass> schoolClasses);
        List<EllCoach> ExtractEllCoaches(List<SchoolClass> schoolClasses);
        List<Assistant> ExtractAssistants(List<SchoolClass> schoolClasses);
    }
}