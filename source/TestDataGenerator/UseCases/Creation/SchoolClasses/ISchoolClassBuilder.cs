using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.SchoolClasses
{
    interface ISchoolClassBuilder
    {
        void Build();
        List<SchoolClass> GetClasses(SchoolGrade grade, int year);
    }
}