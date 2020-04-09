using AutoMapper;
using EllAid.DataSource.Adapters.DataObjects;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class InstructorShortProfile : Profile
    {
        public InstructorShortProfile() => CreateMap<Instructor, InstructorShortDto>()
        .ForMember(dto => dto.Type, u => u.MapFrom(src => Globals.noSqlInstructorShortType))
        .ForMember(dto => dto.Version, u => u.MapFrom(src => Globals.noSqlInstructorShortVersion));
    }
}