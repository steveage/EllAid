using AutoMapper;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Adapters.DataObjects;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class TestResultProfile : Profile
    {
        public TestResultProfile()
        {
            CreateMap(typeof(TestResult<>), typeof(TestResultDto<>))
                .ForMember("Version", t=>t.MapFrom(src=>Globals.noSqlTestResultVersion))
                .ForMember("Type", t=>t.MapFrom(src=>Globals.noSqlTestResultType));
        }
    }
}