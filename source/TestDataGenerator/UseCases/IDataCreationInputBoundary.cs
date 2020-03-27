using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases
{
    public interface IDataCreationInputBoundary
    {
        List<SchoolClass> GetClasses();
    }
}