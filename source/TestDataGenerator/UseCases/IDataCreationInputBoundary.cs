using System.Threading.Tasks;

namespace EllAid.TestDataGenerator.UseCases
{
    public interface IDataCreationInputBoundary
    {
        Task CreateClassesAsync();
    }
}