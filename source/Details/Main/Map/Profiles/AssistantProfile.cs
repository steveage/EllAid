using AutoMapper;
using EllAid.Adapters.DataObjects;
using EllAid.Entities.Data;
using EllAid.Details.Main.DataAccess;

namespace EllAid.Details.Main.Map.Profiles
{
    public class AssistantProfile : Profile
    {
        public AssistantProfile() => CreateMap<Assistant, AssistantDto>()
        .ForMember(dto => dto.Type, u => u.MapFrom(src => DataAccessConstants.noSqlAssistantType))
        .ForMember(dto => dto.Version, u => u.MapFrom(src => DataAccessConstants.noSqlAssistantVersion));
    }
}