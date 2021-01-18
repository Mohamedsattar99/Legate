using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Mapping;
using Application.Users.Commands.CreateUser;
using AutoMapper;
using MediatR;

namespace Application.User.Commands.CreateUser {
    public class CreateUserCommand : IRequest<int> {

        public int Id { get; set; }
        public string Name { set; get; }
        //TODO: data type int is too much for an age, ages never exceeds 255 yeas :)
        public int Age { set; get; }
        //TODO: the propety name should be camel case i.e. Salary
        //TODO: salary data type should be decimal not int
        public int salary { set; get; }
        public string Address { set; get; }
        //TODO: Phone should be string not int
        public int Phone { set; get; }
        //TODO: Position should be enum not string
        public string Postion { set; get; }
        // TODO: joiningDate should be DateTime not string.
        public string JoiningDate { set; get; }

    }
}