using AutoMapper;
using EllAid.Adapters.DataObjects;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.DataAccess;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile() => CreateMap<Instructor, InstructorDto>()
        .ForMember(dto => dto.Version, u => u.MapFrom(src => DataAccessConstants.noSqlInstructorVersion))
        .ForMember(dto => dto.Type, u => u.MapFrom(src => DataAccessConstants.noSqlInstructorType));
    }
}