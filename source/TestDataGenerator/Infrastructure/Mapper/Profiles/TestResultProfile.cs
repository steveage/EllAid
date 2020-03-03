using AutoMapper;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.Mapper.DataObjects;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class TestResultProfile : Profile
    {
        public TestResultProfile()
        {
            CreateMap<TestResult, TestResultDto>()
                .ForMember(dto=>dto.Version, t=>t.MapFrom(src=>Globals.noSqlTestResultVersion))
                .ForMember(dto=>dto.Type, t=>t.MapFrom(src=>Globals.noSqlTestResultType));
        }
    }
}