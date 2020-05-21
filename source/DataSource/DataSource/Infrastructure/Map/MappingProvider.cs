using AutoMapper;
using EllAid.DataSource.UseCases;
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
    }
}