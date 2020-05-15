using AutoMapper;
using EllAid.Adapters.DataObjects;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.DataAccess;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class SchoolClassProfile : Profile
    {
        public SchoolClassProfile() => 
            CreateMap<SchoolClass, SchoolClassDto>()
                .ForMember(dto => dto.Version, u => u.MapFrom(src => DataAccessConstants.noSqlSchoolClassVersion))
                .ForMember(dto => dto.Type, s => s.MapFrom(src=>DataAccessConstants.noSqlSchoolClassType));
    }
}