using AutoMapper;
using EllAid.Adapters;
using EllAid.Adapters.DataObjects;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.Infrastructure.Map
{
    class MappingProvider : IMappingProvider
    {
        readonly IMapper mapper;

        public MappingProvider(IMapper mapper) => this.mapper = mapper;

        public T Map<T, S>(S source)
            where T : class
            where S : Entity => mapper.Map<T>(source);

        // public T Map<T, S>(S source)
        //     where T : EntityDto
        //     where S : Entity => mapper.Map<S, T>(source,
        //         opt => opt.AfterMap((src, dest) => dest.Type = type));
    }
}