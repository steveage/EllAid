using AutoMapper;
using EllAid.Adapters.DataObjects;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.DataAccess;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class InstructorShortProfile : Profile
    {
        public InstructorShortProfile() => CreateMap<Instructor, InstructorShortDto>()
        .ForMember(dto => dto.Type, u => u.MapFrom(src => DataAccessConstants.noSqlInstructorShortType))
        .ForMember(dto => dto.Version, u => u.MapFrom(src => DataAccessConstants.noSqlInstructorShortVersion));
    }
}