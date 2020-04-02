using AutoMapper;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Adapters.DataObjects;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class EllCoachProfile : Profile
    {
        public EllCoachProfile() => CreateMap<EllCoach, EllCoachDto>();
    }
}