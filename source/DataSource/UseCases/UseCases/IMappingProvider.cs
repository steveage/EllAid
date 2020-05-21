using EllAid.Entities.Data;

namespace EllAid.DataSource.UseCases
{
    public interface IMappingProvider
    {
        T Map<T, S>(S source) where T: class where S: Entity;
    }
}