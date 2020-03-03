using AutoMapper;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.Mapper.DataObjects;

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