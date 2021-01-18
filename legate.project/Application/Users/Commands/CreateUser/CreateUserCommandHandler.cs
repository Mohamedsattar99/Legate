using Application.Common.Interfaces;
using Application.User.Commands.CreateUser;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,int>
    {
        private readonly ILegateDbContext context;
        private readonly IMapper mapper;
        public CreateUserCommandHandler(ILegateDbContext legateDb, IMapper _mapper)
        {
            context = legateDb;
            mapper = _mapper;
        }
        public async Task<int> Handle(CreateUserCommand request,CancellationToken cancellationToken)
        {
            //var entity = new Domain.Entities.User()
            //{
            //    Id = request.Id,
            //    Name = request.Name,
            //    Address = request.Address,
            //    Age = request.Age,
            //    salary = request.salary,
            //    Postion = request.Postion,
            //    JoiningDate = DateTime.Parse(request.JoiningDate),
            //    Phone = request.Phone,
            //};
            var entity = mapper.Map<Domain.Entities.User>(request);
            context.Users.Add(entity);
            await context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
