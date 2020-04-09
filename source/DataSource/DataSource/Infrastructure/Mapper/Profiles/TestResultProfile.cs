using AutoMapper;
using EllAid.DataSource.Adapters.DataObjects;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class TestResultProfile : Profile
    {
        public TestResultProfile()
        {
            CreateMap(typeof(TestResult), typeof(TestResultDto<>))
                .ForMember("Version", t=>t.MapFrom(src=>Globals.noSqlTestResultVersion))
                .ForMember("Type", t=>t.MapFrom(src=>Globals.noSqlTestResultType));
        }
    }
}