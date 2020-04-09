using AutoMapper;
using EllAid.DataSource.Adapters.DataObjects;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile() => CreateMap<Instructor, InstructorDto>()
        .ForMember(dto => dto.Version, u => u.MapFrom(src => Globals.noSqlInstructorVersion))
        .ForMember(dto => dto.Type, u => u.MapFrom(src => Globals.noSqlInstructorType));
    }
}