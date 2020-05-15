using AutoMapper;
using EllAid.Adapters.DataObjects;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.DataAccess;

namespace EllAid.DataSource.Infrastructure.Mapper.Profiles
{
    public class AssistantProfile : Profile
    {
        public AssistantProfile() => CreateMap<Assistant, AssistantDto>()
        .ForMember(dto => dto.Type, u => u.MapFrom(src => DataAccessConstants.noSqlAssistantType))
        .ForMember(dto => dto.Version, u => u.MapFrom(src => DataAccessConstants.noSqlAssistantVersion));
    }
}