using System.Threading.Tasks;
using EllAid.TestDataGenerator.UseCases;

namespace EllAid.TestDataGenerator.UI
{
    class Program
    {
        static ServiceBuilder serviceBuilder;

        static async Task Main(string[] args)
        {
            Initialize();
            await BuildDatabaseAsync();
        }

        static void Initialize()
        {
            serviceBuilder = new ServiceBuilder();
        }

        static async Task BuildDatabaseAsync()
        {
            IDataCreationInputBoundary builder = serviceBuilder.GetService<IDataCreationInputBoundary>();
            // await builder.BuildDatabaseAsync();
        }
    }
}