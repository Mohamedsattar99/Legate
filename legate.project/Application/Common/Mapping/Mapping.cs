using Application.User.Commands.CreateUser;
using Application.Users.Commands.UpdateUser;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Mapping
{
    public class Mapping: Profile
    {
        public Mapping()
        {
            CreateMap<CreateUserCommand, Domain.Entities.User>()
                .ForMember(s => s.JoiningDate, opt => opt.MapFrom(d => DateTime.Parse(d.JoiningDate)));
        }
    }
}
