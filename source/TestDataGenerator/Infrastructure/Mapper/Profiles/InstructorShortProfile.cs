using AutoMapper;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Adapters.DataObjects;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class InstructorShortProfile : Profile
    {
        public InstructorShortProfile() => CreateMap<Instructor, InstructorShortDto>()
        .ForMember(dto => dto.Type, u => u.MapFrom(src => Globals.noSqlInstructorShortType))
        .ForMember(dto => dto.Version, u => u.MapFrom(src => Globals.noSqlInstructorShortVersion));
    }
}