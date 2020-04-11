using EllAid.DataSource.Adapters.DataObjects;
using EllAid.Entities.Data;

namespace EllAid.DataSource.Adapters
{
    public interface IMappingProvider
    {
        T Map<T, S>(S source) where T: EntityDto where S: Entity;
    }
}