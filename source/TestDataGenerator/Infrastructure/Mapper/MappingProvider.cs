using AutoMapper;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Adapters;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper
{
    class MappingProvider : IMappingProvider
    {
        readonly IMapper mapper;

        public MappingProvider(IMapper mapper) => this.mapper = mapper;

        public T Map<T, S>(S source)
            where T : class
            where S : Item => mapper.Map<T>(source);
    }   
}