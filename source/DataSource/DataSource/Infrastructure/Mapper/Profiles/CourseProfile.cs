using AutoMapper;
using EllAid.DataSource.Adapters.DataObjects;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile() => 
            CreateMap<Course, CourseDto>()
                .ForMember(dto=>dto.Version, c=>c.MapFrom(src => Globals.noSqlCourseVersion))
                .ForMember(dto=>dto.Type, c=>c.MapFrom(src=> Globals.noSqlCourseType));
    }
}