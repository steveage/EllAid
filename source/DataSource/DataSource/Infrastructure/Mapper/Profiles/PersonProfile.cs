using AutoMapper;
using EllAid.DataSource.Adapters.DataObjects;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile() => 
            CreateMap<Person, PersonDto>()
                .ForMember(dto => dto.Version, u => u.MapFrom(src => Globals.noSqlPersonVersion))
                .ForMember(dto => dto.Type, u => u.MapFrom(src => "person"));
    }
}