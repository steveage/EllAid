using System.Threading.Tasks;
using EllAid.TestDataGenerator.UseCases.Creation.Datasource;
using EllAid.TestDataGenerator.UseCases.Creation.Item;

namespace EllAid.TestDataGenerator.UseCases
{
    // This use case is too big in scope and took too much time to implement. It should have been split during the first iteration planning meeting into research, create data source, create students, create teachers, create tests, etc. If split, velocity could have been measured and each use case could be implemented in each iteration.
    class DataCreationUseCase : IDataCreationInputBoundary
    {
        private readonly IDataSourceBuilder builder;

        public DataCreationUseCase(IDataSourceBuilder builder)
        {
            this.builder = builder;
        }

        public async Task BuildDatabaseAsync()
        {
            bool databaseIsBuilt = await builder.BuildAsync();
            if(databaseIsBuilt)
            {
                // await itemCreator.CreateAsync();
            }
        }
    }
}