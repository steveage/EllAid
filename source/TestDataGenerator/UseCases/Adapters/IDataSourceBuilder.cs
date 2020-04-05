using System.Threading.Tasks;

namespace EllAid.TestDataGenerator.UseCases.Adapters
{
    public interface IDataSourceBuilder
    {
        Task<bool> BuildAsync();
    }
}