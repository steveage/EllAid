using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface ISchoolBuilder
    {
        void Build();
        List<SchoolClass> GetClasses(SchoolGrade grade, int year);
    }
}