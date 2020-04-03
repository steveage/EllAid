using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases
{
    public interface IDataCreationInputBoundary
    {
        Task CreateClassesAsync();
    }
}