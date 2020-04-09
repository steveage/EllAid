using AutoMapper;
using EllAid.DataSource.Adapters.DataObjects;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.DataAccess;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class TestResultProfile : Profile
    {
        public TestResultProfile()
        {
            CreateMap(typeof(TestResult), typeof(TestResultDto<>))
                .ForMember("Version", t=>t.MapFrom(src=>DataAccessConstants.noSqlTestResultVersion))
                .ForMember("Type", t=>t.MapFrom(src=>DataAccessConstants.noSqlTestResultType));
        }
    }
}