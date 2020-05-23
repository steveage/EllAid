using System.Threading.Tasks;

namespace EllAid.UseCases.Generator
{
    public interface IDataCreationInputBoundary
    {
        Task CreateClassesAsync();
    }
}