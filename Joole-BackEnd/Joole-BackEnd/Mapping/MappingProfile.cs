using AutoMapper;
using Joole_BackEnd.Controllers.Dto;
using Joole_BackEnd.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joole_BackEnd.Mapping
{
    public class MappingProfile : Profile
    {
        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<MappingProfile>();
            });
        }
        public MappingProfile()
        {
            // Domain -> Dto
            CreateMap<User, UserLoginDto>();

            // Dto -> Domain
            CreateMap<UserLoginDto, User>();
        }
    }
}