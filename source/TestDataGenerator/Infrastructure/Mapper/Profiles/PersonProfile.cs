using AutoMapper;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Adapters.DataObjects;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile() => 
            CreateMap<Person, PersonDto>()
                .ForMember(dto => dto.Version, u => u.MapFrom(src => Globals.noSqlUserVersion))
                .ForMember(dto => dto.Type, opt => opt.Ignore());
    }
}