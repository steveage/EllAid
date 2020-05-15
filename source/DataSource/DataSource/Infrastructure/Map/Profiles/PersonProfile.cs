using AutoMapper;
using EllAid.Adapters.DataObjects;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.DataAccess;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile() => 
            CreateMap<Person, PersonDto>()
                .ForMember(dto => dto.Version, u => u.MapFrom(src => DataAccessConstants.noSqlPersonVersion))
                .ForMember(dto => dto.Type, u => u.MapFrom(src => "person"))
                .ForMember(dto => dto.UserName, u => u.MapFrom(src => $"{src.FirstName.Substring(0,1)}{src.LastName}"))
                .IncludeAllDerived();
    }
}