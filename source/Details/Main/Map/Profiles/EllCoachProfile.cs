using AutoMapper;
using EllAid.Adapters.DataObjects;
using EllAid.Entities.Data;
using EllAid.Details.Main.DataAccess;

namespace EllAid.Details.Main.Mapper.Profiles
{
    public class EllCoachProfile : Profile
    {
        public EllCoachProfile() => CreateMap<EllCoach, EllCoachDto>()
        .ForMember(dto => dto.Type, u => u.MapFrom(src => DataAccessConstants.noSqlEllCoachType))
        .ForMember(dto => dto.Version, u => u.MapFrom(src => DataAccessConstants.noSqlEllCoachVersion));
    }
}