using AutoMapper;
using EllAid.DataSource.Adapters.DataObjects;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.DataAccess;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class TestSessionProfile : Profile
    {
        public TestSessionProfile() => 
            CreateMap<TestSession, TestSessionDto>()
                .ForMember(dto => dto.Version, t => t.MapFrom(src => DataAccessConstants.noSqlTestSessionVersion))
                .ForMember(dto=>dto.Type, t=>t.MapFrom(src=> DataAccessConstants.noSqlTestSessionType));
    }
}