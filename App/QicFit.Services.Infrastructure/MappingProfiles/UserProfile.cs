
using AutoMapper;
using Common.DTO;
using QicFit.Entities.System;
using System.Linq;

namespace QicFit.Services.Infrastructure.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(d => d.Login, opt => opt.MapFrom(src => src.UserName)).ReverseMap();
                //.ForMember(d => d.Address,
                //    opt => opt.MapFrom(src => new AddressDTO(src.AddressZipCode,
                //    src.CityId, src.AddressLat, src.AddressLng, src.StateId)))
                //.ForMember(d => d.Login, opt => opt.MapFrom(src => src.UserName)).ReverseMap()

            //.ForMember(d => d.AddressZipCode, opt => opt.MapFrom(src => src.Address.ZipCode))
            //.ForMember(d => d.AddressLat, opt => opt.MapFrom(src => src.Address.Lat))
            //.ForMember(d => d.AddressLng, opt => opt.MapFrom(src => src.Address.Lng))
            //.ForMember(d => d.City, opt => opt.MapFrom(src => src.Address.CityId))
            //.ForMember(d => d.StateId, opt => opt.MapFrom(src => src.Address.StateId))
            //.ForMember(d => d.UserName, opt => opt.MapFrom(src => src.Login));
        }
    }
}