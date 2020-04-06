using AutoMapper;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Adapters.DataObjects;

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