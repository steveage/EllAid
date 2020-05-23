using AutoMapper;
using EllAid.Adapters.DataObjects;
using EllAid.Entities.Data;
using EllAid.Details.Main.DataAccess;

namespace EllAid.Details.Main.Mapper.Profiles
{
    public class SchoolClassProfile : Profile
    {
        public SchoolClassProfile() => 
            CreateMap<SchoolClass, SchoolClassDto>()
                .ForMember(dto => dto.Version, u => u.MapFrom(src => DataAccessConstants.noSqlSchoolClassVersion))
                .ForMember(dto => dto.Type, s => s.MapFrom(src=>DataAccessConstants.noSqlSchoolClassType));
    }
}