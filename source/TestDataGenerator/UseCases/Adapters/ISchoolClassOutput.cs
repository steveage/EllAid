using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Adapters
{
    interface ISchoolClassOutput
    {
        Task SavePreKClassesAsync(List<SchoolClass> schoolClasses);
    }
}