using AutoMapper;
using EllAid.Adapters.DataObjects;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.DataAccess;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class EllCoachShortProfile : Profile
    {
        public EllCoachShortProfile() => CreateMap<EllCoach, EllCoachShortDto>()
        .ForMember(dto => dto.Type, c => c.MapFrom(src => DataAccessConstants.noSqlEllCoachShortType))
        .ForMember(dto => dto.Version, c => c.MapFrom(src => DataAccessConstants.noSqlEllCoachShortVersion));
    }
}