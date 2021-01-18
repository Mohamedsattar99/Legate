using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand: IRequest
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
