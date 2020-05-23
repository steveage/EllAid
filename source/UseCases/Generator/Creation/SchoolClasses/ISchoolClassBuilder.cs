using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.UseCases.Generator.Creation.SchoolClasses
{
    interface ISchoolClassBuilder
    {
        List<SchoolClass> GetClasses(SchoolGrade grade, int year);
    }
}