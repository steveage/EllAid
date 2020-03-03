using AutoMapper;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.Mapper.DataObjects;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class TestSessionProfile : Profile
    {
        public TestSessionProfile() => 
            CreateMap<TestSession, TestSessionDto>()
                .ForMember(dto => dto.Version, t => t.MapFrom(src => Globals.noSqlTestSessionVersion))
                .ForMember(dto=>dto.Type, t=>t.MapFrom(src=> Globals.noSqlTestSessionType));
    }
}