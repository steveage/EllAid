using AutoMapper;
using EllAid.Entities.Data;
using EllAid.UseCases.DataSource;

namespace EllAid.Details.Main.Map
{
    public class MappingProvider : IMappingProvider
    {
        readonly IMapper mapper;

        public MappingProvider(IMapper mapper) => this.mapper = mapper;

        public T Map<T, S>(S source)
            where T : class
            where S : Entity => mapper.Map<T>(source);
    }
}