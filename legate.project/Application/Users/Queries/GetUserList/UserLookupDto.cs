using Application.Common.Mapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Queries.GetUserList
{
    public class UserLookupDto:IMapFrom<Domain.Entities.User>
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.User, UserLookupDto>();
        }


    }
}
