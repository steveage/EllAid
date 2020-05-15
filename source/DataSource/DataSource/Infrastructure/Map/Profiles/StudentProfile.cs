using AutoMapper;
using EllAid.Adapters.DataObjects;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile() => CreateMap<Student, StudentDto>();
    }
}