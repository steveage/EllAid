using EllAid.Adapters.DataObjects;
using EllAid.Entities.Data;

namespace EllAid.Adapters
{
    public interface IMappingProvider
    {
        T Map<T, S>(S source) where T: class where S: Entity;
    }
}