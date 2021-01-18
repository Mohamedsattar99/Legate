using Application.Common.Mapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsVM: IMapFrom<Domain.Entities.User>
    {
        public int UserId { get; set; }
        public string  Name { set; get; }
        public int Age { set; get; }
        public int salary { set; get; }
        public string Address { set; get; }
        public int Phone { set; get; }
        public string Postion { set; get; }
        public string JoiningDate { set; get; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.User, GetUserDetailsVM>().ForMember(
                d => d.UserId, opt => opt.MapFrom(s => s.Id));
                
        }
    }
}
