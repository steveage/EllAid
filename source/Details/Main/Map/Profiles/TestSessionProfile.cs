using AutoMapper;
using EllAid.Adapters.DataObjects;
using EllAid.Entities.Data;
using EllAid.Details.Main.DataAccess;

namespace EllAid.Details.Main.Mapper.Profiles
{
    public class TestSessionProfile : Profile
    {
        public TestSessionProfile() => 
            CreateMap<TestSession, TestSessionDto>()
                .ForMember(dto => dto.Version, t => t.MapFrom(src => DataAccessConstants.noSqlTestSessionVersion))
                .ForMember(dto=>dto.Type, t=>t.MapFrom(src=> DataAccessConstants.noSqlTestSessionType));
    }
}