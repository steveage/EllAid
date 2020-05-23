using AutoMapper;
using EllAid.Adapters.DataObjects;
using EllAid.Entities.Data;
using EllAid.Details.Main.DataAccess;

namespace EllAid.Details.Main.Mapper.Profiles
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