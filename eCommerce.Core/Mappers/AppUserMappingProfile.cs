using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eCommerce.Core.Mappers
{
    public class AppUserMappingProfile : Profile
    {
        public AppUserMappingProfile()
        {
            CreateMap<AppUser, AuthenticationResponse>()
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.PersonName, opt => opt.MapFrom(s => s.PersonName))
                .ForMember(d => d.Gender, opt => opt.MapFrom(s => s.Gender))
                .ForMember(d => d.Token, opt => opt.Ignore())
                .ForMember(d => d.Success, opt => opt.Ignore())
                ;

        }

    }
}
