using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;
using System.Linq;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {   
        public AutoMapperProfiles()
        {
            
            CreateMap<Photo,PhotoDto>();
            CreateMap<AppUser, MemberDto>()
                .ForMember(d=> d.PhotoUrl,opt=>opt.MapFrom(src=>src.Photos.FirstOrDefault(x=>x.IsMain).Url))
                .ForMember(d => d.Age, opt =>opt.MapFrom(src =>src.DateOfBirth.CalculateAge()));
        }
    }
}