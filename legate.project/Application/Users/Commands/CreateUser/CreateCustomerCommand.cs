using Application.Common.Interfaces;
using Application.Common.Mapping;
using Application.Users.Commands.CreateUser;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {

        public int Id { get; set; }
        public string Name { set; get; }
        public int Age { set; get; }
        public int salary { set; get; }
        public string Address { set; get; }
        public int Phone { set; get; }
        public string Postion { set; get; }
        public string JoiningDate { set; get; }

    }
}
