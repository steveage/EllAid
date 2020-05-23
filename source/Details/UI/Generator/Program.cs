using System.Threading.Tasks;
using EllAid.UseCases.Generator;

namespace EllAid.Details.UI.Generator
{
    class Program
    {
        static ServiceBuilder serviceBuilder;

        static async Task Main(string[] args)
        {
            Initialize();
            await CheckClassBuilderAsync();
        }

        static void Initialize()
        {
            serviceBuilder = new ServiceBuilder();
        }

        static async Task CheckClassBuilderAsync()
        {
            IDataCreationInputBoundary builder = serviceBuilder.GetService<IDataCreationInputBoundary>();
            await builder.CreateClassesAsync();
        }
    }
}