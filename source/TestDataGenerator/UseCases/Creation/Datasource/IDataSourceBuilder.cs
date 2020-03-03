using System.Threading.Tasks;

namespace EllAid.TestDataGenerator.UseCases.Creation.Datasource
{
    public interface IDataSourceBuilder
    {
        Task<bool> BuildAsync();
    }
}