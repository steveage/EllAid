using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Adapters.DataObjects;

namespace EllAid.TestDataGenerator.UseCases.Adapters
{
    public interface IMappingProvider
    {
        T Map<T, S>(S source, string type) where T: EntityDto where S: Entity;
    }
}