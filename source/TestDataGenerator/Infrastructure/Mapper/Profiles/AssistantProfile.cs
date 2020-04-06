using AutoMapper;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Adapters.DataObjects;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.Profiles
{
    public class AssistantProfile : Profile
    {
        public AssistantProfile() => CreateMap<Assistant, AssistantDto>()
        .ForMember(dto => dto.Type, u => u.MapFrom(src => Globals.noSqlAssistantType))
        .ForMember(dto => dto.Version, u => u.MapFrom(src => Globals.noSqlAssistantVersion));
    }
}