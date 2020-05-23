using System.Threading.Tasks;

namespace EllAid.Entities.Services
{
    public interface IDataStoreManager
    {
        Task CreateDataStoreAsync();
        Task DeleteDataStoreAsync();
    }
}