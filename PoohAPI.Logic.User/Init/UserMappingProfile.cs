﻿using AutoMapper;
using PoohAPI.Infrastructure.UserDB.Models;

namespace PoohAPI.Logic.Users.Init
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<WPUser, Common.Models.User>()
                .ForMember(d => d.EmailAddress, o => o.MapFrom(s => s.user_email))
                .ForMember(d => d.NiceName, o => o.MapFrom(s => s.display_name))
                .ForMember(d => d.RegistrationDate, o => o.MapFrom(s => s.user_registered))
                .ReverseMap();
        }
    }
}