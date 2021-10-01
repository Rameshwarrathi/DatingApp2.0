using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;
using System;
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

            CreateMap<MemberUpdateDto,AppUser>();

            CreateMap<RegisterDto,AppUser>();
            CreateMap<Message,MessageDto>()
                .ForMember(d=> d.SenderPhotoUrl,opt=>opt.MapFrom(src=>src.Sender.Photos.FirstOrDefault(x=>x.IsMain).Url))
                .ForMember(d=> d.RecipientPhotoUrl,opt=>opt.MapFrom(src=>src.Recipient.Photos.FirstOrDefault(x=>x.IsMain).Url));

            //CreateMap<DateTime, DateTime>().ConvertUsing(d => DateTime.SpecifyKind(d,DateTimeKind.Utc));
        }
    }
}