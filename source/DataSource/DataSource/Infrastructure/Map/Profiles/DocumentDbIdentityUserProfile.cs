using AspNetCore.Identity.DocumentDb;
using AutoMapper;
using EllAid.Entities.Data;

namespace EllAid.DataSource.Infrastructure.Mapper.Profiles
{
    public class DocumentDbIdentityUserProfile : Profile
    {
        public DocumentDbIdentityUserProfile() =>
            CreateMap<Person, DocumentDbIdentityUser>()
                .ForMember(idt => idt.UserName, u => u.MapFrom(src => $"{src.FirstName.Substring(0,1)}{src.LastName}"));
    }
}