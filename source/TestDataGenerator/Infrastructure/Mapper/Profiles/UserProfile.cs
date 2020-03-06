using AutoMapper;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.Mapper.DataObjects;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() => 
            CreateMap<Person, UserDto>()
                .ForMember(dto => dto.Version, u => u.MapFrom(src => Globals.noSqlUserVersion));
    }
}