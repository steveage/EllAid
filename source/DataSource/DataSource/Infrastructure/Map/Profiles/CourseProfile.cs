using AutoMapper;
using EllAid.Adapters.DataObjects;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.DataAccess;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile() => 
            CreateMap<Course, CourseDto>()
                .ForMember(dto=>dto.Version, c=>c.MapFrom(src => DataAccessConstants.noSqlCourseVersion))
                .ForMember(dto=>dto.Type, c=>c.MapFrom(src=> DataAccessConstants.noSqlCourseType));
    }
}