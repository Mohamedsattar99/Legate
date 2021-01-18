using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.User.Commands.CreateUser;
using AutoMapper;
using MediatR;

namespace Application.Users.Commands.CreateUser {
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int> {
        //TODO: by convension private readonly members names starts with _ i.e. _context, and _mapper
        private readonly ILegateDbContext context;
        private readonly IMapper mapper;
        //TODO: parameters names never starts with _        
        public CreateUserCommandHandler (ILegateDbContext legateDb, IMapper _mapper) {
            context = legateDb;
            mapper = _mapper;
        }
        public async Task<int> Handle (CreateUserCommand request, CancellationToken cancellationToken) {
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
            var entity = mapper.Map<Domain.Entities.User> (request);
            context.Users.Add (entity);
            await context.SaveChangesAsync (cancellationToken);
            return entity.Id;
        }
    }
}