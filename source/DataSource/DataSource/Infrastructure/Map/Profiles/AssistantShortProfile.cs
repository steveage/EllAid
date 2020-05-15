using AutoMapper;
using EllAid.Adapters.DataObjects;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.DataAccess;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class AssistantShortProfile : Profile
    {
        public AssistantShortProfile() => CreateMap<Assistant, AssistantShortDto>()
            .ForMember(dto => dto.Type, a => a.MapFrom(src => DataAccessConstants.noSqlAssistantShortType))
            .ForMember(dto => dto.Version, a => a.MapFrom(src => DataAccessConstants.noSqlAssistantShortVersion));
    }
}