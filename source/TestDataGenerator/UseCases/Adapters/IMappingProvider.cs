using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Adapters
{
    public interface IMappingProvider
    {
        T Map<T, S>(S source) where T: class where S: Item;
    }
}