using AutoMapper;
using EllAid.DataSource.Adapters.DataObjects;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class EllCoachProfile : Profile
    {
        public EllCoachProfile() => CreateMap<EllCoach, EllCoachDto>()
        .ForMember(dto => dto.Type, u => u.MapFrom(src => Globals.noSqlEllCoachType))
        .ForMember(dto => dto.Version, u => u.MapFrom(src => Globals.noSqlEllCoachVersion));
    }
}