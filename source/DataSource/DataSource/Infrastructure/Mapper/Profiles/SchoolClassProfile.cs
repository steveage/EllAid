using AutoMapper;
using EllAid.DataSource.Adapters.DataObjects;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class SchoolClassProfile : Profile
    {
        public SchoolClassProfile() => 
            CreateMap<SchoolClass, SchoolClassDto>()
                .ForMember(dto => dto.Version, u => u.MapFrom(src => Globals.noSqlSchoolClassVersion))
                .ForMember(dto => dto.Type, s => s.MapFrom(src=>Globals.noSqlSchoolClassType));
    }
}